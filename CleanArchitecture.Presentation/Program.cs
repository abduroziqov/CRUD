using CleanArchitecture.Infrastructure.Repository;

namespace CleanArchitecture.Presentation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Controller controller = new Controller();
            controller.Display();
        }
    }
}