namespace Animate.Servicio
{   
    public interface IAnimateServicio
    {
        List<Animate.Entidad.Asset> ObtenerAssets();
        void AgregarAsset(Animate.Entidad.Asset asset);
    }

    public class AnimateServicio : IAnimateServicio
    {
        private List<Animate.Entidad.Asset> _assets;

        public AnimateServicio()
        {
            _assets = new List<Animate.Entidad.Asset>
            {
                new Animate.Entidad.Asset { Id = 1, Nombre = "Samurai", Descripcion = "Samurai listo pa pelear (parece enojado)", Imagen = "samurai" },
                new Animate.Entidad.Asset { Id = 2, Nombre = "Dragon", Descripcion = "Dragón rojo (Cabeza)", Imagen = "dragon" },
                new Animate.Entidad.Asset { Id = 3, Nombre = "Pez Koi", Descripcion = "Pez Koi (lindo)", Imagen = "pezkoi" }
            };
        }
        public List<Animate.Entidad.Asset> ObtenerAssets()
        {
            return _assets;
        }

        public void AgregarAsset(Animate.Entidad.Asset asset)
        {
            _assets.Add(asset);
        }

    }
}
