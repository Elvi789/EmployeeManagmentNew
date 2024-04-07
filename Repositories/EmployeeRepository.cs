using EmployeeManagment.Data;

namespace EmployeeManagment.Repositories
{
    public class EmployeeRepository
    {
        public readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void CreateEmployee(Employee employee) 
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }
        public void DeleteEmployee(Employee employee)
        {
            _context.Employees.Remove(employee);
            _context.SaveChanges();
        }
        public Employee GetEmployee(int id)
        {
            return _context.Employees.Where(x => x.Id == id).FirstOrDefault();

        }
        public List<Employee> GetEmployees()
        {
            return _context.Employees.ToList();
        }
        public void UpdateEmployee(Employee employee)
        {
            _context.Employees.Update(employee);
        }
        
    }
}
