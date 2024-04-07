using EmployeeManagment.Data;

namespace EmployeeManagment.Service
{
    public interface IEmployeeServices
    {
        void CreateEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(Employee employee);
        Employee GetEmployee(int id);
        IEnumerable<Employee> GetAllEmployees();

    }
}
