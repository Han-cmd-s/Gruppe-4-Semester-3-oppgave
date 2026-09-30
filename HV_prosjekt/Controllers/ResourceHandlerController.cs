using HV_prosjekt.DataAccess;
using HV_prosjekt.Models.ViewModels.Resource;
using Microsoft.AspNetCore.Mvc;

namespace HV_prosjekt.Controllers
{
    public class ResourceHandlerController : Controller
    {
        private readonly IResourceRepository _resourceRepository;

        public ResourceHandlerController(IResourceRepository resourceRepository)
        {
            _resourceRepository = resourceRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var all = _resourceRepository.GetAll();
            //Map the resources to view models
            var model = all.Select(r => new ResourceViewModel
            {
                Id = r.Id,
                Name = r.Name,
                Description = r.Description,
                Type = r.Type
            }).ToList();

            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ResourceViewModel model) 
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var resource = _resourceRepository.Create(model);
       
            return RedirectToAction("Index","Resource", new { id = resource.Id });
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var resource = _resourceRepository.GetById(id);
            if (resource == null)
            {
                return NotFound();
            }
            var model = new ResourceViewModel
            {
                Id = resource.Id,
                Name = resource.Name,
                Description = resource.Description,
                Type = resource.Type
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(ResourceViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            if (model.Id == null)
            {
                return BadRequest();
            }
            var success = _resourceRepository.Update(model.Id.Value, model);
            if (!success)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }   

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var success = _resourceRepository.Delete(id);
            if (!success)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }
    }
}
