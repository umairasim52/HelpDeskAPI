using HelpDeskBlazor.Models;
using System.Net.Http.Json;

namespace HelpDeskBlazor.Services
{
    public class DepartmentService
    {
        private readonly IHttpClientFactory _factory;
        private readonly ILogger<DepartmentService>? _logger;

        public DepartmentService(IHttpClientFactory factory, ILogger<DepartmentService>? logger = null)
        {
            _factory = factory;
            _logger = logger;
        }

        public async Task<List<Department>> GetDepartments()
        {
            try
            {
                var client = _factory.CreateClient("HelpDeskAPI");
                var response = await client.GetAsync("api/Departments");

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<List<Department>>();
                    return result ?? new List<Department>();
                }

                var error = await response.Content.ReadAsStringAsync();
                _logger?.LogError($"GetDepartments failed: {(int)response.StatusCode} - {error}");
                throw new Exception($"Failed to load departments: {error}");
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error in GetDepartments");
                throw;
            }
        }

        public async Task AddDepartment(Department department)
        {
            try
            {
                var client = _factory.CreateClient("HelpDeskAPI");
                var response = await client.PostAsJsonAsync("api/Departments", department);

                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    _logger?.LogError($"AddDepartment failed: {(int)response.StatusCode} - {error}");
                    throw new Exception($"Failed to add department: {error}");
                }
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error in AddDepartment");
                throw;
            }
        }

        public async Task UpdateDepartment(Department department)
        {
            try
            {
                var client = _factory.CreateClient("HelpDeskAPI");
                var response = await client.PutAsJsonAsync($"api/Departments/{department.Id}", department);

                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    _logger?.LogError($"UpdateDepartment failed: {(int)response.StatusCode} - {error}");
                    throw new Exception($"Failed to update department: {error}");
                }
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error in UpdateDepartment");
                throw;
            }
        }

        public async Task DeleteDepartment(int id)
        {
            try
            {
                var client = _factory.CreateClient("HelpDeskAPI");
                var response = await client.DeleteAsync($"api/Departments/{id}");

                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    _logger?.LogError($"DeleteDepartment failed: {(int)response.StatusCode} - {error}");
                    throw new Exception($"Failed to delete department: {error}");
                }
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error in DeleteDepartment");
                throw;
            }
        }
    }
}