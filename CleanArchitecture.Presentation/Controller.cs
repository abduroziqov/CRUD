using CleanArchitecture.Infrastructure.Repository;

namespace CleanArchitecture.Presentation
{
    public class Controller
    {
        public void Display()
        {
            InsertingObject insertingObject = new InsertingObject();
            Console.WriteLine("             ----- Welcome to online library -----\n");
            Console.WriteLine("                          Choose options\n");
            Console.WriteLine("1.Add book     2.Get all books     " +
                "3.Change book name      4.Delete book\n");
            Console.Write("Your option : ");

            try
            {
                while(true)
                {
                    switch (int.Parse(Console.ReadLine()))
                    {
                        case 1:
                            insertingObject.CreateData();
                            break;
                        case 2:
                            insertingObject.GetAllData();
                            break;
                        case 3:
                            insertingObject.UpdateData(15);
                            break;
                        case 4:
                            insertingObject.DeleteData();
                            break;
                    }
                    Console.ReadKey();
                    Console.Clear();
                    Display();
                }
            }
            catch(Exception ex)
            {
                Console.Write($"Error has occured : {ex}");
            }
        }
    }
}
