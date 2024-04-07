using EmployeeManagment.Data;
using EmployeeManagment.Repositories;

namespace EmployeeManagment.Service
{
    public class EmployeeService : IEmployeeServices
    {
        public readonly EmployeeRepository _employeeRepository;

        public EmployeeService(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public void CreateEmployee(Employee employee)
        {
            _employeeRepository.CreateEmployee(employee);
        }
        public void UpdateEmployee(Employee employee)
        {
            _employeeRepository.UpdateEmployee(employee);
        }
        public void DeleteEmployee(Employee employee)
        {
            _employeeRepository.DeleteEmployee(employee);
        }
        public Employee GetEmployee(int id)
        {
            return _employeeRepository.GetEmployee(id);
        }
        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeRepository.GetEmployees();
        }
    }
}
