using cqrs_example.Entity;
namespace cqrs_example.FakeDB;

public class FakeDB
{
    private static List<Customer> _customers;

    public FakeDB()
    {
        _customers = new List<Customer>
        {
            new() { Id = 1, Name = "Furkan" },
            new() { Id = 2, Name = "Ahmet" },
            new() { Id = 3, Name = "Mehmet" }
        };
    }

    public async Task AddCustomerAsync(Customer customer)
    {
        _customers.Add(customer);
        await Task.CompletedTask;
    }

    public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
    {
        return await Task.FromResult(_customers);
    }

    public async Task<Customer> GetCustomerByIdAsync(int id)
    {
        return await Task.FromResult(_customers.FirstOrDefault(x => x.Id == id, null));
    }

    public async Task DeleteCustomerById(int id)
    {
        var customerToRemove = _customers.FirstOrDefault(x => x.Id == id);
        if (customerToRemove != null) await Task.FromResult(_customers.Remove(customerToRemove));
    }

    public async Task<Customer> UpdateCustomerAsync(Customer customer)
    {
        var customerToUpdate = _customers.FirstOrDefault(x => x.Id == customer.Id);
        if (customerToUpdate != null) customerToUpdate.Name = customer.Name;

        return await Task.FromResult(customerToUpdate);
    }
}