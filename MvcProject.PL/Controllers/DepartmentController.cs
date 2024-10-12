using Microsoft.AspNetCore.Mvc;
using MvcProject.BLL.IEnterfacies;
using MvcProject.BLL.Repositories;
using MvcProject.DAL.Models;

namespace MvcProject.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public IActionResult Index()
        {
            var department = _departmentRepository.GetAll();
            return View(department);
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                _departmentRepository.Add(department);
                return RedirectToAction(nameof(Index));
            }

            return View(department);
        }

        public IActionResult Details(int? id)
        {
            if (id is null)
                return BadRequest();
            var department = _departmentRepository.GetById(id.Value);
            if (department is null)
                return NotFound();
            return View(department);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id is null)
                return BadRequest();
            var department = _departmentRepository.GetById(id.Value);
            if (department is null)
                return NotFound();
            return View(department);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Department department, [FromRoute] int id)
        {
            if (id != department.Id)
                return BadRequest();
            if (ModelState.IsValid)
            {
                try
                {
                    _departmentRepository.Update(department);
                    return RedirectToAction(nameof(Index));

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            return View(department);
        }

        public IActionResult Delete(int? id)
        {
            if (id is null)
                return BadRequest();
            var department = _departmentRepository.GetById(id.Value);
            if (department is null)
                return NotFound();
            return View(department);
        }

        [HttpPost]
        public IActionResult Delete(Department department)
        {
            if (ModelState.IsValid)
            {
                _departmentRepository.Delete(department);
                return RedirectToAction(nameof(Index));
            }

            return View(department);
        }
    }
}
