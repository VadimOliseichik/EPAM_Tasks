using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using BLL.ServiceImplementation;
using DAL.Fake.Repositories;
using DAL.Interface.Interfaces;
using DAL.Repositories;
// using DAL.Repositories;
using Ninject;

namespace DependencyResolver
{
    public static class ResolverConfig
    {
        public static void ConfigurateResolver(this IKernel kernel)
        {
            kernel.Bind<IScoreService>().To<ScoreService>();

            kernel.Bind<IStorage>().To<FakeStorage>();

            kernel.Bind<IStorage>().To<BinaryScoreRepository>().WithConstructorArgument("test.bin");

            kernel.Bind<IGenerateScoreIdService>().To<GenerateScoreId>().InSingletonScope();

            //kernel.Bind<IApplicationSettings>().To<ApplicationSettings>();
        }
    }
}
