using EmployeeManagment.Models.EmployeeViewModels;
using EmployeeManagment.Models;
using EmployeeManagment.Service;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagment.Controllers
{
    public class PositionController : Controller

    {
        public readonly IPositionService _positionService;

        public PositionController(IPositionService positionService)
        {
            _positionService = positionService;
        }

        public IActionResult Index()
        {
            var positions = _positionService.GetAllPosition();
            return View(positions);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new PositionForCreationDto();
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(PositionForCreationDto model)
        {
            var position = new Data.Position();
            position.Name = model.Name;
            position.Description = model.Description;
            _positionService.CreatePosition(position);
            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            var positionToDelete = _positionService.GetPosition(id);
            _positionService.DeletePosition(positionToDelete);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var positionToEdit = _positionService.GetPosition(id);
            var model = new PositionForModificationDto();
            model.Name = positionToEdit.Name;
            model.Description = positionToEdit.Description;

            return View(model);

        }
        [HttpPost]
        public IActionResult Edit(PositionForModificationDto dto)
        {
            var positionToEdit = _positionService.GetPosition(dto.Id);
            positionToEdit.Name = dto.Name;
            positionToEdit.Description = dto.Description;
            _positionService.UpdatePosition(positionToEdit);
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var position = _positionService.GetPosition(id);

            return View(position);
        }
        

    }
}
