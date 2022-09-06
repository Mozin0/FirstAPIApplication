using ClassModels;
using System.Net;
using System.Net.Http.Json;

namespace CustomerBlazorApp.Services
{
    public class CustomerService
    {
        private readonly HttpClient _httpClient;

        public CustomerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Customer> GetCustomerById(int id)
        {
            //var result = await _httpClient.GetFromJsonAsync<Customer>($"api/Customers/{id}");
            //if (result == null)
            //{
            //    throw new Exception("Customer Not Found");
            //}

            //return result;
            //
            var response = await _httpClient.GetAsync($"api/Customers/{id}");
            response.EnsureSuccessStatusCode();
            //if (!response.IsSuccessStatusCode)
            //{
            //}

            //handle success an keep going
            var customer = await response.Content.ReadFromJsonAsync<Customer>();
            if (customer == null)
            {
                throw new Exception("No customer found");
            }
            return customer;

        }

        public async Task<IReadOnlyList<Customer>> GetCustomers()
        {            
            var allcustomers =  await _httpClient.GetFromJsonAsync<IReadOnlyList<Customer>>("api/Customers");
            if (allcustomers == null)
            {
                throw new InvalidDataException("No Customers found");
            }
            return allcustomers;
        }

        public async Task AddCustomer(Customer customer)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Customers", customer);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateCustomer(int id, Customer customer)
        {
           var response = await _httpClient.PutAsJsonAsync($"api/Customers/{id}", customer);
           response.EnsureSuccessStatusCode();
        }

        public async Task DeleteCustomer(int id)
        {
            await _httpClient.DeleteAsync($"api/Customers/{id}");
        }
    }
}
