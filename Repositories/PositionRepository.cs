using EmployeeManagment.Data;

namespace EmployeeManagment.Repositories
{
    public class PositionRepository
    {
        public readonly ApplicationDbContext _context;

        public PositionRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void CreatePosition(Position position)
        {
            _context.Positions.Add(position);
            _context.SaveChanges();
        }
        public void DeletePosition(Position position)
        {
            _context.Positions.Remove(position);
            _context.SaveChanges();
        }
        public Position GetPosition(int id)
        {
            return _context.Positions.Where(x => x.Id == id).FirstOrDefault();

        }
        public List<Position> GetPosition()
        {
            return _context.Positions.ToList();
        }
        public void UpdatePosition(Position position)
        {
            _context.Positions.Update(position);
            _context.SaveChanges();
        }
    }
}
