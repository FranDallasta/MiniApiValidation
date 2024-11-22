var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

// Inject AuthService
var authService = new AuthService();

app.MapGet("/", () => "Welcome to the Minimal API Validation Example!");

// Test SQL Injection
app.MapGet("/test-sql-injection", () =>
{
    authService.TestSqlInjection();
    return "SQL Injection Test Completed. Check the console for results.";
});

// Test XSS Input
app.MapGet("/test-xss", () =>
{
    authService.TestXssInput();
    return "XSS Test Completed. Check the console for results.";
});

app.Run();
