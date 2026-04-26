using Microsoft.AspNetCore.Mvc;

namespace Animate.MVC.Controllers
{
    public class AnimateController : Controller
    {
        private readonly Animate.Servicio.IAnimateServicio _animateServicio;

        public AnimateController(Animate.Servicio.IAnimateServicio animateServicio)
        {
            _animateServicio = animateServicio;
        }

        public IActionResult Index()
        {
            return View(_animateServicio.ObtenerAssets());
        }

        [HttpGet]
        public IActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Agregar(Entidad.Asset asset){
            _animateServicio.AgregarAsset(asset);
            return RedirectToAction("Index");
        }
    }
}
