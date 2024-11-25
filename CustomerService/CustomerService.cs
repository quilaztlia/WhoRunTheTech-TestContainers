using CustomerService;
using System.Diagnostics;

namespace Customers;

public sealed class CustomerService
{
    private readonly DbConnectionProvider _dbConnectionProvider;

    public CustomerService(DbConnectionProvider dbConnectionProvider)
    {
        _dbConnectionProvider = dbConnectionProvider;
        CreateCustomersTable();
    }
   
    private void CreateCustomersTable()
    {
        using var connection = _dbConnectionProvider.GetConnection();
        using var command = connection.CreateCommand();
        command.CommandText = "create table if not exists "+ 
         "Customers(id bigint not null "+
                  ", name varchar not null "+
                  ", Primary Key(id))";
        command.Connection?.Open();
        command.ExecuteNonQuery();
    }

    public void Create(Customer customer)
    {
        using var connection = _dbConnectionProvider.GetConnection();
        using var command = connection.CreateCommand();

        var id = command.CreateParameter();
        id.ParameterName = "@id";
        id.Value = customer.Id;

        var name = command.CreateParameter();
        name.ParameterName = "@name";
        name.Value = customer.Name;

        command.CommandText = "insert into Customers(id, name) values(@id, @name)";
        command.Parameters.Add(id);
        command.Parameters.Add(name);
        command.Connection?.Open();
        command.ExecuteNonQuery();
    }

    public IEnumerable<Customer> GetCustomers()
    {
        IList<Customer> customers = new List<Customer>();

        using var connection = _dbConnectionProvider.GetConnection();
        using var command = connection.CreateCommand();

        command.CommandText = "select id, name from Customers";
        command.Connection?.Open();

        using var dataReader = command.ExecuteReader();
        while(dataReader.Read()){
            var id = dataReader.GetInt64(0);
            var name = dataReader.GetString(1);
            customers.Add(new Customer(id, name));
        }
        return customers;
    }

    
}
