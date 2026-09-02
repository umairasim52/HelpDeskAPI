using HelpDeskBlazor.Models;
using System.Net.Http.Json;

namespace HelpDeskBlazor.Services
{
    public class EmployeeService
    {
        private readonly IHttpClientFactory _factory;
        private readonly ILogger<EmployeeService>? _logger;

        public EmployeeService(IHttpClientFactory factory, ILogger<EmployeeService>? logger = null)
        {
            _factory = factory;
            _logger = logger;
        }

        public async Task<List<Employee>> GetEmployees()
        {
            try
            {
                var client = _factory.CreateClient("HelpDeskAPI");
                var response = await client.GetAsync("api/Employees");

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<List<Employee>>();
                    return result ?? new List<Employee>();
                }

                var error = await response.Content.ReadAsStringAsync();
                _logger?.LogError($"GetEmployees failed: {(int)response.StatusCode} - {error}");
                throw new Exception($"Failed to load employees: {error}");
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error in GetEmployees");
                throw;
            }
        }

        public async Task AddEmployee(Employee employee)
        {
            try
            {
                var client = _factory.CreateClient("HelpDeskAPI");
                var response = await client.PostAsJsonAsync("api/Employees", employee);

                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    _logger?.LogError($"AddEmployee failed: {(int)response.StatusCode} - {error}");
                    throw new Exception($"Failed to add employee: {error}");
                }
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error in AddEmployee");
                throw;
            }
        }

        public async Task UpdateEmployee(Employee employee)
        {
            try
            {
                var client = _factory.CreateClient("HelpDeskAPI");
                var response = await client.PutAsJsonAsync($"api/Employees/{employee.Id}", employee);

                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    _logger?.LogError($"UpdateEmployee failed: {(int)response.StatusCode} - {error}");
                    throw new Exception($"Failed to update employee: {error}");
                }
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error in UpdateEmployee");
                throw;
            }
        }

        public async Task DeleteEmployee(int id)
        {
            try
            {
                var client = _factory.CreateClient("HelpDeskAPI");
                var response = await client.DeleteAsync($"api/Employees/{id}");

                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    _logger?.LogError($"DeleteEmployee failed: {(int)response.StatusCode} - {error}");
                    throw new Exception($"Failed to delete employee: {error}");
                }
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error in DeleteEmployee");
                throw;
            }
        }
    }
}