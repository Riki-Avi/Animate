using Microsoft.AspNetCore.Mvc;

namespace Animate.MVC.Controllers
{
    public class AnimateController : Controller
    {
        private readonly IWebHostEnvironment _environment;
        private readonly Animate.Servicio.IAnimateServicio _animateServicio;

        public AnimateController(Animate.Servicio.IAnimateServicio animateServicio, IWebHostEnvironment environment)
        {
            _animateServicio = animateServicio;
            _environment = environment;
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
        public async Task<IActionResult> Agregar(Entidad.Asset asset, IFormFile? imagenFile)
        {
            if (imagenFile is null || imagenFile.Length == 0)
                return BadRequest("Debes seleccionar una imagen .png");

            var ext = Path.GetExtension(imagenFile.FileName);
            if (!string.Equals(ext, ".png", StringComparison.OrdinalIgnoreCase))
                return BadRequest("Solo .png");

            if (!string.Equals(imagenFile.ContentType, "image/png", StringComparison.OrdinalIgnoreCase))
                return BadRequest("El archivo no es un PNG válido.");

            var webRoot = _environment.WebRootPath ?? Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            var carpetaImagenes = Path.Combine(webRoot, "Imagenes");
            Directory.CreateDirectory(carpetaImagenes);

            var nombre = $"{Guid.NewGuid():N}.png";
            var ruta = Path.Combine(carpetaImagenes, nombre);

            using var stream = System.IO.File.Create(ruta);
            await imagenFile.CopyToAsync(stream);

            asset.Imagen = nombre;

            _animateServicio.AgregarAsset(asset);
            return RedirectToAction(nameof(Index));
        }
    }
}
