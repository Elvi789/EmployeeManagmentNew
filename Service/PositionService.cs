using EmployeeManagment.Data;
using EmployeeManagment.Repositories;

namespace EmployeeManagment.Service
{
    public class PositionService : IPositionService
    { 
        public readonly PositionRepository _positionRepository;
         public PositionService(PositionRepository positionRepository)
         {
                _positionRepository = positionRepository;
         }
        public void CreatePosition(Position position)
        {
            _positionRepository.CreatePosition(position);
        }
        public void UpdatePosition(Position position)
        {
            _positionRepository.UpdatePosition(position);
        }
        public void DeletePosition(Position position)
        {
            _positionRepository.DeletePosition(position);
        }
        public Position GetPosition(int id)
        {
            return _positionRepository.GetPosition(id);
        }
        public IEnumerable<Position> GetAllPosition()
        {
            return _positionRepository.GetPosition();
        }
    }
}
