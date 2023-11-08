using AsyncJisaDemo.Models;

namespace AsyncJisaDemo.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployees();

        Task<Employee> GetEmployeeById(int id);

        Task<int> AddEmployee(Employee employee);

        Task<int> UpdateEmployee(Employee employee);

        Task<int> DeleteEmployee(int id);

    }
}
