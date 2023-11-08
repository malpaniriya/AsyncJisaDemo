using AsyncJisaDemo.Data;
using AsyncJisaDemo.Models;
using Dapper;

namespace AsyncJisaDemo.Repositories
{
    public class EmployeeRepository: IEmployeeRepository
    {
        private readonly ApplicationDbContext context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<int> AddEmployee(Employee employee)
        {
            int result = 0;
            var query = "insert into Employee values(@name,@city)";
            var parameters = new DynamicParameters();
            parameters.Add("@name",employee.Name);
            parameters.Add("@city", employee.City);
            
            using (var connection = context.CreateConnection())
            {
                result = await connection.ExecuteAsync(query, parameters);
            }
            return result;
        }

        public async Task<int> DeleteEmployee(int id)
        {
            int result = 0;
            var query = "delete from Employee where id=@id";

            using (var connection = context.CreateConnection())
            {
                result = await connection.ExecuteAsync(query, new { id });
            }
            return result;
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            var qry = "select * from Employee where id=@id";
            using (var connection = context.CreateConnection())
            {
                var result = await connection.QuerySingleOrDefaultAsync<Employee>(qry, new { id });
                return result;
            }
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            var qry = "select * from Employee";
            using (var connection = context.CreateConnection())
            {
                var result = await connection.QueryAsync<Employee>(qry);
                return result.ToList();
            }
        }

        public async Task<int> UpdateEmployee(Employee employee)
        {
            int result = 0;
            var query = "update Employee set name=@name,city=@city where id=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@name", employee.Name);
            parameters.Add("@city", employee.City);
            parameters.Add("@id", employee.Id);
            using (var connection = context.CreateConnection())
            {
                result = await connection.ExecuteAsync(query, parameters);
            }
            return result;
        }
    }

}

