using ClassModels;
using Microsoft.AspNetCore.Mvc;

namespace FirstAPIApplication.Services
{
    public interface ICustomerService
    {
        Task<IReadOnlyList<Customer>> GetCustomers(); 
        Task<IActionResult> GetCustomerById(int id);
        Task AddCustomer(Customer customer);
        Task<IActionResult> UpdateCustomer(int id, Customer customer);
        Task<IActionResult> DeleteCustomer(int id);
    }
}
