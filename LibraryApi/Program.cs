using LibraryCore;
using LibraryDataAccess;
using LibraryDataAccess.Repositories;
using LibraryService.Interfaces;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

// Add the database context
builder.Services.AddDbContext<DatabaseConnection>();
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<MapProfile>());// Service Implementations
//Addtransient: A new instance of the service will be created each time it is requested. This is suitable for lightweight, stateless services.
//AddScoped: A new instance of the service will be created per scope. In web applications, a scope typically corresponds to a single request. This is suitable for services that need to maintain state within a request but should not be shared across requests.
builder.Services.AddScoped<IGenericRepository<Author>, Repository<Author>>();
builder.Services.AddScoped<IGenericRepository<Category>, Repository<Category>>();
builder.Services.AddScoped<IGenericRepository<Book>, Repository<Book>>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.Run();

// Configure the HTTP request pipeline.
