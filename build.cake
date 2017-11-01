///////////////////////////////////////////////////////////////////////////////
// ARGUMENTS
///////////////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");
var botanNugetOutputPath = Argument<string>("botannugetpath", null);

///////////////////////////////////////////////////////////////////////////////
// SETUP / TEARDOWN
///////////////////////////////////////////////////////////////////////////////

var BOTAN_CLIENT_NUGET_PATH = ".artifacts/botanclient/nuget";

Setup(ctx =>
{
   // Executed BEFORE the first task.
   Information("Running tasks...");
});

Teardown(ctx =>
{
   // Executed AFTER the last task.
   Information("Finished running tasks.");
});

///////////////////////////////////////////////////////////////////////////////
// TASKS
///////////////////////////////////////////////////////////////////////////////

Task("Default")
.Does(() => {
   Information("Hello Cake!");
});

Task("BotanClient_Build")
.Does(() => {
    DotNetCoreBuild("src/BotanClient/BotanClient.csproj");
});

Task("BotanClient_Test")
.IsDependentOn("BotanClient_Build")
.Does(() => {
    DotNetCoreTest("tests/BotanClient.UnitTests/BotanClient.UnitTests.csproj");
});

Task("BotanClient_NuGetPack")
.IsDependentOn("BotanClient_Test")
.Does(() => {
    DotNetCorePack("src/BotanClient/BotanClient.csproj", new DotNetCorePackSettings
    {
        Configuration = "Release",
        OutputDirectory = botanNugetOutputPath ?? BOTAN_CLIENT_NUGET_PATH
    });
});

RunTarget(target);