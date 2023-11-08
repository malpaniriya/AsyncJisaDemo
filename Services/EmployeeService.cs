using AsyncJisaDemo.Models;
using AsyncJisaDemo.Repositories;

namespace AsyncJisaDemo.Services
{
    public class EmployeeService:IEmployeeService
    {
        private readonly IEmployeeRepository repo;
        public EmployeeService(IEmployeeRepository repo)
        {
            this.repo = repo;
        }
        public async Task<int> AddEmployee(Employee employee)
        {
            return await repo.AddEmployee(employee);
        }

        public async Task<int> DeleteEmployee(int id)
        {
            return await repo.DeleteEmployee(id);
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await repo.GetEmployeeById(id);
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await repo.GetEmployees();
        }

        public async Task<int> UpdateEmployee(Employee employee)
        {
            return await repo.UpdateEmployee(employee);
        }
    }

}

