var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder.AddPostgres("postgres");
var database = postgres.AddDatabase("triondb");

var webapi = builder.AddProject<Projects.Trion_WebApi>("webapi")
    .WithReference(database)
    .WaitFor(database);

builder.AddViteApp("frontend", "../../../frontend")
    .WithNpm()
    .WithReference(webapi)
    .WithEnvironment("VITE_API_BASE_URL", webapi.GetEndpoint("http"));

builder.Build().Run();
