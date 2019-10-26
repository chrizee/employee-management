
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    //[Route("Home")]
    //[Route("[controller]/[action]")] //using token in route attribute. this is for the current controller
    public class HomeController : Controller
    {
        //readonly means we can't change it again in this class
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly ILogger logger;

        public HomeController(IEmployeeRepository employeeRepository, IHostingEnvironment hostingEnvironment, ILogger<HomeController> logger)
        {
            _employeeRepository = employeeRepository;
            this.hostingEnvironment = hostingEnvironment;
            this.logger = logger;
        }
        
        //[Route("")]
        //[Route("~/")]   //when a route template begins with '~/' or '/' the controller route template is not combined with it when matching route
        //[Route("Index")]   //route template doesn't have to match controller/action. it can be anything
        //[Route("[action]")] //using tokens in route template
        [AllowAnonymous]
        public ViewResult Index()
        {
            var model = _employeeRepository.GetAllEmployees();
            return View("~/Views/Home/index.cshtml", model);
            //return "hello fron home controller";
        }

        //[Route("Details/{id?}")]
        //[Route("[action]/{id?}")]
        //[Route("{id?}")]
        [AllowAnonymous]
        public ViewResult Details(int? id = 3)  //nullable int
        {
            //throw new Exception("exception");

            logger.LogTrace("Trace log");
            logger.LogWarning("Warning Log");
            logger.LogDebug("Debug Log");
            logger.LogError("Error Log");
            logger.LogCritical("Critical log");
            logger.LogInformation("Information Log");

            Employee employee = _employeeRepository.GetEmployee(id??1);
            //when returning views, the default view selected is in Views/ControllerName/ActionMethod.cshtml
            //can be override by passing a relative or absolute filepath to the view method. Relative path is wrt to the Actionname directory and .cshtml is not required
            //return View("../folder/view");
            //for absolute file path, the .cshtml extension is required  
            //return View("/path/to/view.cshtml");
            //return View("~/path/to/view.cshtml");

            //using viewData to pass data to the view - all data are strings so we have to cast to the required type using 'as' keyword 
            // ViewData["PageTitle"] = "Employee details";
            // ViewData["Employee"] = model;

            //using viewBag to pass data the view - uses dynamic properties on the ViewBag instance
            //ViewBag.PageTitle = "Employee details";
            //ViewBag.Employee = model;
            //return View();

            //passing the model directly to the view - when we don't need to pass additional data
            //we have to inject it the view using @model directive
            //return View(model);

            //using viewModel
            if(employee == null)
            {
                Response.StatusCode = 404;
                return View("EmployeeNotFound", id.Value);
            }
            HomeDetailViewModel homeDetailViewModel = new HomeDetailViewModel()
            {
                Employee = employee,
                PageTitle = "Employee Details"
            };
            return View(homeDetailViewModel);
        }

        [HttpGet, Authorize]
        public ViewResult Create()
        {
            return View();
        }

        [HttpGet, Authorize]
        public ViewResult Edit(int id)
        {
            Employee employee = _employeeRepository.GetEmployee(id);
            EmployeeEditViewModel employeeEditViewModel = new EmployeeEditViewModel
            {
                Id = employee.Id,
                Name = employee.Name,
                Email = employee.Email,
                Department = employee.Department,
                existingPhotoPath = employee.PhotoPath
            };
            return View(employeeEditViewModel);
        }

        [HttpPost, Authorize]
        //the model in the parameter here matches the one in the create view model, in this case it is the view model.
        public IActionResult Edit(EmployeeEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Employee employee = _employeeRepository.GetEmployee(model.Id);
                employee.Name = model.Name;
                employee.Email = model.Email;
                employee.Department = model.Department;
                if(model.Photo != null) 
                {
                    if(model.existingPhotoPath != null)
                    {
                        string filePath = Path.Combine(hostingEnvironment.WebRootPath, "images", model.existingPhotoPath);
                        System.IO.File.Delete(filePath);
                    }
                    employee.PhotoPath = ProcessUploadedFile(model);
                }
                _employeeRepository.Update(employee);
                
                return RedirectToAction("details", new { id = employee.Id });
            }

            return View();
        } 

        private string ProcessUploadedFile(EmployeeCreateViewModel model)
        {
            string UniqueFileName = null;
            if (model.Photo != null)
            {
                string UploadPath = Path.Combine(hostingEnvironment.WebRootPath, "images");
                UniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(UploadPath, UniqueFileName);
                using( var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Photo.CopyTo(fileStream);
                }
            }

            return UniqueFileName;
        }

        [HttpPost, Authorize]
        //the model in the parameter here matches the one in the create view model, in this case it is the view model.
         public IActionResult Create(EmployeeCreateViewModel model)
         {
            if(ModelState.IsValid)
            {
                string UniqueFileName = ProcessUploadedFile(model);
                Employee newEmployee = new Employee
                {
                    Name = model.Name,
                    Department = model.Department,
                    Email = model.Email,
                    PhotoPath = UniqueFileName
                };
                _employeeRepository.Add(newEmployee);
                 return RedirectToAction("details", new {id = newEmployee.Id});
            }

            return View();
         }

        //public JsonResult Efe() => Json(new {id=1, name="chriser"});
    }
}   