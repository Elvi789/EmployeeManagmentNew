using Microsoft.AspNetCore.Identity;

namespace EmployeeManagment.Data.UserManagement
{
    public class ApplicationUser : IdentityUser //application user trazhgon nga idenitty user per shkak se na duhen propertit e UServa ne database dhe na duhet ti editojme ato
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsCompanyEmployee { get; set; } //property e re qe do shtohet ne USera ne Database
    }
}
