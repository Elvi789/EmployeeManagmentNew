using EmployeeManagment.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagment.Repositories
{
    public class EmployeePositionRepository
    {
        public readonly ApplicationDbContext _context;

        public EmployeePositionRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void CreateEmployeePosition(EmployeePosition employeePosition)
        {
            _context.EmployeePositions.Add(employeePosition);
            _context.SaveChanges();
        }
        public void EditEmployeePosition(EmployeePosition employeePosition)
        {
            _context.EmployeePositions.Update(employeePosition);
            _context.SaveChanges();
        }
        public async Task DeleteEmployeePosition(EmployeePosition employeePosition)
        {
            _context.EmployeePositions.Remove(employeePosition);
            _context.SaveChanges();
        }
        public Task<EmployeePosition> GetEmployeePositionById(int id)
        {
            return _context.EmployeePositions.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async Task<List<EmployeePosition>> GetAllEmployeePosition()
        {
        return await _context.EmployeePositions.Include(x => x.Employee).Include(x => x.Position).ToListAsync();
        }
        public async Task <List<EmployeePosition>>GetAllEmployeePositionsByEmployeeId(int employeeId)
        {
            return await _context.EmployeePositions.Include(x => x.Employee).Include(x => x.Position).Where(x => x.EmployeeId == employeeId).ToListAsync();
        }
        public async Task <List<EmployeePosition>> GetAllEmployeePositionsByPositionId(int positionId)
        {
            return await _context.EmployeePositions.Where(x=>x.PositionId == positionId).ToListAsync();
        }
    }
}
