N5 company requests a Web API for registering user permissions, to carry out this task it is necessary to comply with the following steps:

1. Create a **Permissions** table with the following fields:

[Untitled](https://www.notion.so/31697119b0c645fdbbb2ad7cb9595998)

1. Create a **PermissionTypes** table with the following fields:

[Untitled](https://www.notion.so/d507d069c5e44e10973851e1cafbdd3b)

2. Create relationship between **Permission** and **PermissionType.**

3. Create a Web API using net core on Visual Studio and persist data on SQL Server.

4. Make use of **EntityFramework**.

5. The Web API must have 3 services “Request Permission”, “Modify Permission” and “Get Permissions”. Every service should persist a permission registry in an elasticsearch index, the register inserted in elasticsearch must contains the same structure of database table “permission”.

6. Create apache kafka in local environment and create new topic where persist every operation a message with the next dto structure:

- Id: random Guid
- Name operation: “modify”, “request” or “get”.

(desired)

7. Making use of repository pattern and Unit of Work and CQRS pattern(Desired). Bear in mind that is required to stick to a proper service architecture so that creating different layers and dependency injection is a must-have.

8. Create Unit Testing and Integration Testing to call the three of the services.

9. Use good practices as much as possible.

10. Prepare the solution to be containerized in a docker image.

11. Upload exercise to some repository (github, gitlab,etc).

**Resources**

- Elasticsearch: [https://www.elastic.co/guide/en/elasticsearch/reference/current/docker.html](https://www.elastic.co/guide/en/elasticsearch/reference/current/docker.html) , [https://www.elastic.co/guide/en/elasticsearch/client/net-api/7.x/nest.html](https://www.elastic.co/guide/en/elasticsearch/client/net-api/7.x/nest.html)

  [docker-compose.yml](https://s3-us-west-2.amazonaws.com/secure.notion-static.com/5a459295-c447-4c71-b36f-5561e77c6d5a/docker-compose.yml)

- Sql server express: [https://hub.docker.com/\_/microsoft-mssql-server](https://hub.docker.com/_/microsoft-mssql-server)
  [docker-compose.yml](https://s3-us-west-2.amazonaws.com/secure.notion-static.com/7a3ad640-6041-4dd6-9711-6d0845edd25e/docker-compose.yml)
- Kafka: [https://www.notion.so/n5now/Kafka-242a5fd883bf49ffa77190fb16eb4ecf#74a1076feed24ea482c804f54483773d](https://www.notion.so/Kafka-242a5fd883bf49ffa77190fb16eb4ecf)
  [docker-compose.yml](https://s3-us-west-2.amazonaws.com/secure.notion-static.com/d01fd595-7d37-4a4e-8160-79e69272d165/docker-compose.yml)
- **Serilog**: [https://serilog.net/](https://serilog.net/)
- **CQRS**: [https://docs.microsoft.com/en-us/azure/architecture/patterns/cqrs](https://docs.microsoft.com/en-us/azure/architecture/patterns/cqrs)
- **EF**: [https://docs.microsoft.com/en-us/ef/core/](https://docs.microsoft.com/en-us/ef/core/)
