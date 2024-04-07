namespace EmployeeManagment.Data
{
    public class Position
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<EmployeePosition> employeePositions { get; set; }
    }
}
