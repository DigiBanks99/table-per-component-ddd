var builder = DistributedApplication.CreateBuilder(args);

var database = builder.AddSqlServer("sql-server")
    .WithDataVolume("TablePerComponentDdd")
    .AddDatabase("database", "TablePerComponentDdd");

builder.AddProject<Projects.TablePerComponentDDD_App>("tpc-ddd-app", "https")
    .WithReference(database)
    .WaitFor(database);

builder.Build().Run();