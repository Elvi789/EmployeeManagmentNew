using EmployeeManagment.Data;

namespace EmployeeManagment.Models.EmployeeViewModels
{
    public class EmployeePositionForCreationDto
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int PositionId { get; set; }
        public IEnumerable<Position>Positions { get; set; }
    }
}
