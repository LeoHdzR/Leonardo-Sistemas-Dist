using SoapCore;

var builder = WebApplication.CreateBulder(args);
builder.Services.AddSoapCore();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserContract, UserService>();

builder.Services.AddSoapCore<RelationalContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString(name:"DefaultConnection")));

var app WebApplication = builder.Build();
app.UseSoapEndPoint<IUserContract>("/UserService.svc", new SoapEncoderOptions());
app.Run()