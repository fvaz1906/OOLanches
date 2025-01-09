namespace OOLanches.APP.Services
{
    public static class ServiceFactory
    {
        public static FavoritosService CreateFavoritosService()
        {
            return new FavoritosService();
        }
    }
}
