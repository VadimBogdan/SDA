using BindingsDI;
using Ninject;
using System.Reflection;
using UI;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var kernel = new StandardKernel();
            kernel.Load(new Assembly[] { typeof(Bindings).Assembly });
            var userInterface = kernel.Get<IConsoleUI>();
            userInterface.Attach();
        }
    }
}
