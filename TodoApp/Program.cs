using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Configure MongoDB Service
builder.Services.AddSingleton<MongoService>();

var app = builder.Build();

// CRUD API Endpoints
app.MapGet("/api/todos", (MongoService db) => Results.Ok(db.Get()));
app.MapGet("/api/todos/{id}", (MongoService db, string id) => db.Get(id) is Todo todo ? Results.Ok(todo) : Results.NotFound());
app.MapPost("/api/todos", (MongoService db, Todo todo) => { db.Create(todo); return Results.Created($"/api/todos/{todo.Id}", todo); });
app.MapPut("/api/todos/{id}", (MongoService db, string id, Todo todo) => { db.Update(id, todo); return Results.NoContent(); });
app.MapDelete("/api/todos/{id}", (MongoService db, string id) => { db.Remove(id); return Results.NoContent(); });

app.Run();

// ---- Classes ----
public class MongoService
{
    private readonly IMongoCollection<Todo> _todos;

    public MongoService(IConfiguration config)
    {
        var client = new MongoClient(config.GetValue<string>("MongoDbConnection"));
        var database = client.GetDatabase("TodoDb");
        _todos = database.GetCollection<Todo>("Todos");
    }

    public List<Todo> Get() => _todos.Find(todo => true).ToList();
    public Todo Get(string id) => _todos.Find(todo => todo.Id == id).FirstOrDefault();

    public void Create(Todo todo) => _todos.InsertOne(todo);

  
    public void Update(string id, Todo todo)
    {
        var filter = Builders<Todo>.Filter.Eq(t => t.Id, id);
        var update = Builders<Todo>.Update
            .Set(t => t.Task, todo.Task)
            .Set(t => t.IsCompleted, todo.IsCompleted);

        _todos.UpdateOne(filter, update);
    }

    // Remove a Todo item by its Id
    public void Remove(string id) => _todos.DeleteOne(t => t.Id == id);
}

public class Todo
{
    [BsonId] public ObjectId ObjectId { get; set; }
    public string Id => ObjectId.ToString(); 
    public string Task { get; set; }
    public bool IsCompleted { get; set; }
}
