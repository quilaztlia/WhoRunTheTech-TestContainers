### WhoRunTheTech

## TestContainers: un allié pour faire des tests d’intégration sans douleur

 
## Abstract
Lorsqu’on développe, nos codes interagissent avec d’acteurs externes. Par exemple : une API, un service de messagerie, un serveur de fichiers, une base de données.

Dans ce cas, comment être sûr que nos codes réagissent correctement aux réponses des acteurs externes?

On peut tester manuellement en installant une instance locale de l’acteur sur notre machine.

On peut aussi installer une instance locale partagée avec l’équipe.

On peut si on a les connaissances et le temps, créer et détruire des instances éphémères de notre acteur en utilisant Docker (ou une autre techno)

Ou encore mieux on peut créer des tests d’intégration (TI) automatisés, qui prennent en compte notre acteur.

Mais la mise en place et la rédaction de tels tests, est parfois complexe ou effrayante. Heureusement « TestContainers » est là pour nous faciliter la tâche.

Je vous propose de voir rapidement les fondamentaux de cet outil. Et ensuite j’essayer un ou deux cas d’usage très concrets.

Vous partirez prêt.es à implémenter votre premier TI avec TestContainers du lendemain.


# Réferences

## TestContainers :
https://testcontainers.com/
https://dotnet.testcontainers.org/
https://dotnet.testcontainers.org/modules/
https://www.atomicjar.com/2023/09/state-of-local-development-and-testing-2023/
https://www.thoughtworks.com/en-au/radar/languages-and-frameworks/testcontainers

## TestContainers (videos):

https://www.youtube.com/watch?v=eFILbyaMI2A

## Docker :
https://www.youtube.com/watch?v=8IRNC7qZBmk&t=11s


##Meetup CraftsRecords - Devenez Tech Speaker :
## https://www.meetup.com/fr-FR/craftsrecords/events/297445915