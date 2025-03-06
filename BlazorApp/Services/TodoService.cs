using BlazorApp.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BlazorApp.Services
{
    public class TodoService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "http://localhost:5172/api/todos"; // Your API URL here

        public TodoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Get all todos
        public async Task<List<Todo>> GetTodosAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Todo>>(_baseUrl);
        }

        // Create a new todo
        public async Task CreateTodoAsync(Todo todo)
        {
            await _httpClient.PostAsJsonAsync(_baseUrl, todo);
        }

        // Update an existing todo
        public async Task UpdateTodoAsync(string id, Todo todo)
        {
            await _httpClient.PutAsJsonAsync($"{_baseUrl}/{id}", todo);
        }

        // Delete a todo by Id
        public async Task DeleteTodoAsync(string id)
        {
            await _httpClient.DeleteAsync($"{_baseUrl}/{id}");
        }
    }
}
