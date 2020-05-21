using Ninject.Modules;
using Ninject;
using UI;
using BLL;
using DAL;
using System.Data.Entity;
using DAL.UnitOfWork;
using DAL.UnitOfWorkInterface;

namespace BindingsDI
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IConsoleUI>().To<ConsoleUI>();
            this.Bind<IBoardService>().To<BoardService>();
            this.Bind<IUnitOfWork>().To<UnitOfWork>();
            this.Bind<DbContext>().To<BoardContext>();
        }
    }
}
