using _3_Semester_HV_prosjekt.DataAccess;
using _3_Semester_HV_prosjekt.Models.ViewModels.Resource;
using Microsoft.AspNetCore.Mvc;

namespace _3_Semester_HV_prosjekt.Web.Controllers
{
    public class ResourceController : Controller
    {
        private readonly IResourceRepository _resourceRepository;

        public ResourceController(IResourceRepository resourceRepository)
        {
            _resourceRepository = resourceRepository;
        }
        public IActionResult Index(int? id)
        {

            var resource = id.HasValue ? _resourceRepository.GetById(id.Value) : null;
            var viewModel = new ResourceViewModel();
            if (resource == null)
            {
                return View(viewModel);
            }
            viewModel = new ResourceViewModel
            {
                Id = resource.Id,
                Name = resource.Name,
                Description = resource.Description,
                Type = resource.Type
            };

            return View(viewModel);
        }
    }
}
