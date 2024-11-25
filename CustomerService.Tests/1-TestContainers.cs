using DotNet.Testcontainers.Builders;
using System.Diagnostics;
using System.Net;

namespace CustomerService.Tests;

public class TestContainers
{
    [Fact]
    public async Task LanceContainer() {
        const int port= 8080;
        var container = new ContainerBuilder()
           .WithImage("testcontainers/helloworld:1.1.0")
           .WithPortBinding(port, false)
           .WithWaitStrategy(Wait.ForUnixContainer().UntilHttpRequestIsSucceeded(p=> p.ForPort(port)))
           .Build();
           
        await container.StartAsync().ConfigureAwait(false);

        var client = new HttpClient();
        var requestUri = new UriBuilder(
            Uri.UriSchemeHttp,container.Hostname, container.GetMappedPublicPort(port), "uuid" ).Uri;

        var guid = await client.GetStringAsync(requestUri);

       Debug.Assert(Guid.TryParse(guid, out var result));
    }

    [Fact]
    public async Task LanceNginx()
    {
        const ushort httpPort = 80;

        var ngnixContainer = new ContainerBuilder()
            .WithName(Guid.NewGuid().ToString("D"))
            .WithImage("nginx")
            .WithPortBinding(httpPort, true)
            .Build();

        await ngnixContainer.StartAsync().ConfigureAwait(false);

        using var httpClient = new HttpClient();
        httpClient.BaseAddress = new UriBuilder(
            "http", ngnixContainer.Hostname, ngnixContainer.GetMappedPublicPort(httpPort)).Uri;

        var httpResponseMessage = await httpClient.GetAsync(string.Empty)
            .ConfigureAwait(false);

        Assert.Equal(HttpStatusCode.OK, httpResponseMessage.StatusCode);
    }

    public async Task LanceContainerFromDockerfile()
    {
        var futureImage = new ImageFromDockerfileBuilder()
            .WithDockerfileDirectory(CommonDirectoryPath.GetSolutionDirectory(),string.Empty)
            .WithDockerfile("Dockerfile")
            .Build();

        await futureImage.CreateAsync()
            .ConfigureAwait(false);
    }
}
