using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagment.Data
{
    public class EmployeePosition

    {
        public int Id { get; set; }
        
        public int? EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }

        public int? PositionId { get; set; }
        [ForeignKey("PositionId")]
        public Position Position { get; set; }

    }
}
