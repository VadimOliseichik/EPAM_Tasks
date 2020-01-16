using System;
using System.Linq;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using DependencyResolver;
using Ninject;
using BLL.ServiceImplementation;
using System.Data.Entity;
using DAL.Repositories;

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
            using (var context = new ScoreContext())
            {
                IScoreService scoreService = new ScoreService(context);

                int id = scoreService.OpenScore(new Client("Vadim", "Oliseichik"), ScoreType.Base);

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
}
