using EmployeeManagment.Data;
using EmployeeManagment.Models;
using EmployeeManagment.Models.EmployeeViewModels;
using EmployeeManagment.Service;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagment.Controllers
{
    public class EmployeeController : Controller
    {
        public readonly IEmployeeServices _employeeService;
        public readonly IEmployeePositionService _employeePositionsService;



        public EmployeeController(IEmployeeServices employeeService)
        {
            _employeeService = employeeService;
            _employeePositionsService = _employeePositionsService;
        }

        public IActionResult Index()
        {
            //duhet te marr te gjith employeet nga databasa dhe ti ruaj ne nje variabel
            var employees = _employeeService.GetAllEmployees(); // mar te gjithe employeet duke perdorur metodeen GetALlEmployees qe me ndodhet ne service
            return View(employees); //hapim view e index duke i derguat views employeet si paramatra kujdes : duhet te presim ne view nje list me employee
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new EmployeeForCreationDto(); //krijojm nje objekt me modelin qe do perdorim per te krijuar
            return View(model); //kte model do ta dergojme ne view
        }
        [HttpPost]
        public IActionResult Create(EmployeeForCreationDto model) 
        {
            var employee = new Data.Employee(); //krijome objektin bosh qe do ta mbushim me te dhena qe na vine nga view kto te dhena do ti gjejme tek EmployeeForCreationDto
            employee.FirstName = model.FirstName;
            employee.LastName = model.LastName;
            employee.Address = model.Address;  //=> ky proces quhet mapim pra objektin bosh e mbushim me te dhena
            employee.Age = model.Age;
            employee.Gender = model.Gender;

            _employeeService.CreateEmployee(employee); //me kete metod nga servici e ruajme objektin employee ne database

            return RedirectToAction("Index"); //hapi i fundit me te cilin ne pas ruajtjes se employee kthehemi ne index
        }

        
        public IActionResult Delete(int id) //mer nje parameter id per shkak sepse ne duhet te na vij nga view id e employeet qe duam te fshim
        {
            var employeeToDelete =  _employeeService.GetEmployee(id); //per te mare employeen qe duam te fshime me id qe na vjen si parameter
            _employeeService.DeleteEmployee(employeeToDelete); //therrsim servisin dhe aksesojme metoden qe fshin nje employee ne database , duke i derkuar si parameter employeen qe morem me id qe duam te fshim
            return RedirectToAction("Index"); //kthemi ne index pas fshirjes
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var employeeToEdit=_employeeService.GetEmployee(id); // eshte nje variabel e cila merr employee me id-n qe na ka ardhur nga view
            var model = new EmployeeForModificationDto(); // 
            model.FirstName = employeeToEdit.FirstName; 
            model.LastName = employeeToEdit.LastName;
            model.Address = employeeToEdit.Address;  //=> ky proces quhet mapim pra objektin bosh e mbushim me te dhena
            model.Age = employeeToEdit.Age;
            model.Gender = employeeToEdit.Gender;
            return View(model);

        }
        [HttpPost]
        public IActionResult Edit(EmployeeForModificationDto dto)
        {
            var employeeToEdit = _employeeService.GetEmployee(dto.Id);
            employeeToEdit.FirstName = dto.FirstName;
            employeeToEdit.LastName = dto.LastName;
            employeeToEdit.Address = dto.Address;  
            employeeToEdit.Age = dto.Age;
            employeeToEdit.Gender = dto.Gender;
            _employeeService.UpdateEmployee(employeeToEdit);
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var employee = _employeeService.GetEmployee(id);

                return View(employee);
        }
        public IActionResult EmployeePositionIndex(int employee)
        {
            var employeePositions = _employeePositionsService.GetEmployeePositionsByEmployeeId (employee);
            return View(employeePositions);
        }
        [HttpGet]

        public IActionResult CreateEmployeePosition(int employeeId)
        {
            var model = new EmployeePositionForCreationDto(); 
            return View(model); 
        }

    }
}
