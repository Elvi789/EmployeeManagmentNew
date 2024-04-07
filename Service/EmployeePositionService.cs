using EmployeeManagment.Data;
using EmployeeManagment.Repositories;
using static EmployeeManagment.Service.EmployeePositionService;

namespace EmployeeManagment.Service
{
    
        public class EmployeePositionService : IEmployeePositionService
        {
            public readonly EmployeePositionRepository _employeePositionRepository;

            public EmployeePositionService(EmployeePositionRepository employeePositionRepository)
            {
                _employeePositionRepository = employeePositionRepository;
            }
            public void CreateEmployeePosition(EmployeePosition employeePosition)
            {
                _employeePositionRepository.CreateEmployeePosition(employeePosition);
            }
            public void UpdateEmployeePosition(EmployeePosition employeePosition)
            {
                _employeePositionRepository.EditEmployeePosition(employeePosition);
            }
            public async Task DeleteEmployeePosition(EmployeePosition employeePosition)
            {
                _employeePositionRepository.DeleteEmployeePosition(employeePosition);
            }
            public Task<EmployeePosition> GetEmployeePosition(int id)
            {
                return _employeePositionRepository.GetEmployeePositionById(id);
            }
            public Task<List<EmployeePosition>> GetAllEmployeesPosition()
            {
                return _employeePositionRepository.GetAllEmployeePosition();
            }
            public Task<List<EmployeePosition>>GetEmployeePositionsByEmployeeId(int employeeId)
            {
                return _employeePositionRepository.GetAllEmployeePositionsByEmployeeId(employeeId);
            }
        }
    }


