var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(policyBuilder =>
    policyBuilder.AddDefaultPolicy(policy =>
        policy.WithOrigins("*").AllowAnyHeader().AllowAnyHeader())
);

var app = builder.Build();
app.UseCors();

app.MapGet("/", () => "Hello World!!!");

app.MapGet("/add", (int num1, int num2) => AddNumbers(num1, num2));

app.MapGet("/subtract", (int num1, int num2) => SubtractNumbers(num1, num2));

app.Run();


string AddNumbers(int num1, int num2)
{
    return $"Summan av {num1} och {num2} är: {num1 + num2}";
}

string SubtractNumbers(int num1, int num2)
{
    return $"Differensen av {num1} och {num2} är: {num1 - num2}";
}



