using System;
using System.Linq;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using DependencyResolver;
using Ninject;
using BLL.ServiceImplementation;

namespace ConsolePL
{
    class Program
    {
        private static readonly IKernel resolver;

        static Program()
        {
            resolver = new StandardKernel();

            resolver.ConfigurateResolver();
        }

        private static void Main(string[] args)
        {
            IScoreService scoreService = new ScoreService();

            string id = scoreService.OpenScore(new Client("Vadim", "Oliseichik"), ScoreType.Base);

            Console.WriteLine(scoreService.ShowInformation(id));

            scoreService.TopUpAccount(id, 1000);

            scoreService.DebitTheAccount(id, 10);

            Console.WriteLine(scoreService.ShowInformation(id));

            scoreService.CloseScore(id);

            Console.WriteLine(scoreService.ShowInformation(id));

            Console.ReadKey();
        }
    }
}
