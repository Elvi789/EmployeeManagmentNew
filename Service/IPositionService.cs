using EmployeeManagment.Data;

namespace EmployeeManagment.Service
{
    public interface IPositionService
    {
        void CreatePosition(Position position);
        void UpdatePosition(Position position);
        void DeletePosition(Position position);
        Position GetPosition(int id);
        IEnumerable<Position> GetAllPosition();

        
    }
}
