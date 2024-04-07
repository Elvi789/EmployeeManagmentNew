using EmployeeManagment.Data;

namespace EmployeeManagment.Service
{
    public interface IEmployeePositionService
    {
        void CreateEmployeePosition(EmployeePosition employeePosition);
        void UpdateEmployeePosition(EmployeePosition employeePosition);
        Task DeleteEmployeePosition(EmployeePosition employeePosition);
        Task<EmployeePosition> GetEmployeePosition(int id);
        Task<List<EmployeePosition>> GetAllEmployeesPosition();
        Task<List<EmployeePosition>> GetEmployeePositionsByEmployeeId(int employeeId);


    }
}