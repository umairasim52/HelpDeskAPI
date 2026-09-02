using HelpDeskBlazor.Models;
using System.Net.Http.Json;

namespace HelpDeskBlazor.Services
{
    public class TicketService
    {
        private readonly IHttpClientFactory _factory;
        private readonly ILogger<TicketService>? _logger;

        public TicketService(IHttpClientFactory factory, ILogger<TicketService>? logger = null)
        {
            _factory = factory;
            _logger = logger;
        }

        public async Task<List<Ticket>> GetTickets()
        {
            try
            {
                var client = _factory.CreateClient("HelpDeskAPI");
                var response = await client.GetAsync("api/Tickets");

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<List<Ticket>>();
                    return result ?? new List<Ticket>();
                }

                var error = await response.Content.ReadAsStringAsync();
                _logger?.LogError($"GetTickets failed: {(int)response.StatusCode} - {error}");
                throw new Exception($"Failed to load tickets: {error}");
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error in GetTickets");
                throw;
            }
        }

        public async Task AddTicket(Ticket ticket)
        {
            try
            {
                var client = _factory.CreateClient("HelpDeskAPI");
                var response = await client.PostAsJsonAsync("api/Tickets", ticket);

                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    _logger?.LogError($"AddTicket failed: {(int)response.StatusCode} - {error}");
                    throw new Exception($"Failed to add ticket: {error}");
                }
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error in AddTicket");
                throw;
            }
        }

        public async Task UpdateTicket(Ticket ticket)
        {
            try
            {
                var client = _factory.CreateClient("HelpDeskAPI");
                var response = await client.PutAsJsonAsync($"api/Tickets/{ticket.Id}", ticket);

                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    _logger?.LogError($"UpdateTicket failed: {(int)response.StatusCode} - {error}");
                    throw new Exception($"Failed to update ticket: {error}");
                }
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error in UpdateTicket");
                throw;
            }
        }

        public async Task DeleteTicket(int id)
        {
            try
            {
                var client = _factory.CreateClient("HelpDeskAPI");
                var response = await client.DeleteAsync($"api/Tickets/{id}");

                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    _logger?.LogError($"DeleteTicket failed: {(int)response.StatusCode} - {error}");
                    throw new Exception($"Failed to delete ticket: {error}");
                }
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error in DeleteTicket");
                throw;
            }
        }
    }
}