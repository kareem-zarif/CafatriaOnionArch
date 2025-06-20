namespace Cafe.API_.IOC
{
    public static class Extensions
    {
        public static IServiceCollection ConfigApiMapping(this IServiceCollection apiServices)
        {
            apiServices.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());//get this project assembllies (dll) for curernt or refenced projects

            return apiServices;
        }
    }
}
