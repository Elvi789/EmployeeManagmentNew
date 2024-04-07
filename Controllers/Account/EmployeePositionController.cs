using EmployeeManagment.Models.EmployeeViewModels;
using EmployeeManagment.Models;
using EmployeeManagment.Service;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagment.Controllers.Account
{
    public class EmployeePositionController : Controller
    {
        public readonly IEmployeePositionService _employeepositionService;
        public readonly IPositionService _positionService;

        public EmployeePositionController(IEmployeePositionService employeepositionService,IPositionService positionService)
        {
            _employeepositionService = employeepositionService;
            _positionService = positionService;
        }

        public async Task <IActionResult> Index(int eId)
        {
            
            var employeepositions = (await _employeepositionService.GetAllEmployeesPosition()).Where(x=>x.EmployeeId == eId) ; 
            ViewBag.EmployeeId = eId ;
            return View(employeepositions); 
        }

        [HttpGet]
        public IActionResult Create(int eId)
        {

            var model = new EmployeePositionForCreationDto();
            model.Positions = _positionService.GetAllPosition();
            model.EmployeeId = eId;
            return View(model); 
        }
        [HttpPost]
        public IActionResult Create(EmployeePositionForCreationDto model)
        {
            var employeeposition = new Data.EmployeePosition(); 
            employeeposition.EmployeeId = model.EmployeeId;
            employeeposition.PositionId = model.PositionId;


            _employeepositionService.CreateEmployeePosition(employeeposition); 

            return RedirectToAction("Index"); 
        }


        public async Task <IActionResult> Delete(int id) 
        {
            var employeepositionToDelete = await _employeepositionService.GetEmployeePosition(id); 
            _employeepositionService.DeleteEmployeePosition(employeepositionToDelete); 
            return RedirectToAction("Index"); //kthemi ne index pas fshirjes
        }
        [HttpGet]
        public async Task <IActionResult> Edit(int id)
        {
            var employeepositionToEdit = await _employeepositionService.GetEmployeePosition(id); 
            var model = new EmployeePositionForModificationDto(); 
            model.EmployeeId = (int)employeepositionToEdit.EmployeeId;
            model.PositionId = (int)employeepositionToEdit.PositionId;
           
            return View(model);

        }
        [HttpPost]
        public async Task <IActionResult> Edit(EmployeePositionForModificationDto dto)
        {
            var employeepositionToEdit = await _employeepositionService.GetEmployeePosition(dto.Id);
            employeepositionToEdit.EmployeeId = dto.EmployeeId;
            employeepositionToEdit.PositionId = dto.PositionId;

            return RedirectToAction("Index");
        }
        public async Task <IActionResult> Details(int id)
        {
            var employeeposition = _employeepositionService.GetEmployeePosition(id);

            return View(employeeposition);
        }
        public async Task <IActionResult> EmployeePositionIndex(int employee)
        {
            var employeeposition = await _employeepositionService.GetEmployeePositionsByEmployeeId(employee);
            return View(employeeposition);
        }
        [HttpGet]

        public IActionResult CreateEmployeePosition(int employeepositionId)
        {
            var model = new EmployeePositionForCreationDto();
            return View(model);
        }
    }
}
