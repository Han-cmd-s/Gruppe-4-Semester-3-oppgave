using HV_prosjekt.Aspire.AppHost.MariaDb;

var builder = DistributedApplication.CreateBuilder(args);

var mariaDbServer = builder.AddMariaDb("mariadb")
                   .WithDataBindMount(source: @"../../../MariaDb/Data")
                   .WithLifetime(ContainerLifetime.Persistent);

var mariaDb = mariaDbServer.AddDatabase("hvprosjektdb");

builder.AddDockerfile("hvprosjekt", "../../", "HV_prosjekt/Dockerfile")
                       .WithExternalHttpEndpoints()
                       .WithReference(mariaDb)
                       .WaitFor(mariaDb)
                       .WithHttpEndpoint(port: 8080, targetPort: 8080, name: "hvprosjekt");

builder.Build().Run();
