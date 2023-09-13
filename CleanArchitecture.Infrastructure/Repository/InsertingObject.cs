using CleanArchitecture.Domain.Models;
using CleanArchitecture.Infrastructure.DbConfiguration;
using System.Security.Cryptography.X509Certificates;

namespace CleanArchitecture.Infrastructure.Repository
{
    public class InsertingObject
    {
        public static E_Book E_Book = new E_Book();
        public static AppDbContext appDbContext = new AppDbContext();

        public E_Book CreateData()
        {
            Console.Clear();
            using (var context = new AppDbContext())
            {
                Console.WriteLine("Enter [Name], [Description], [Price]");
                var std = new E_Book()
                {
                    Name =  Console.ReadLine(),
                    Description = Console.ReadLine(),
                    Price = int.Parse(Console.ReadLine())
                };
                context.Books.Add(std);

                context.SaveChanges();

                Console.WriteLine("Succesfully created");

                return std;
            }
        }

        public void GetAllData()
        {
            Console.Clear();
            using (var context = new AppDbContext())
            {
                var std = appDbContext.Books.ToList();

                std.ForEach(x =>
                {
                    Console.WriteLine($"Id : {x.Id}\nName : {x.Name}\nDescreption : {x.Description}\nPrice : {x.Price}\n");
                });
            }
        }

        public void UpdateData(int id)
        {
            Console.Clear();
            Console.Write("Enter book Id that you want to change : ");
            int updetaId = int.Parse(Console.ReadLine());
            
            using (var context = new AppDbContext())
            {
                var book = context.Books.FirstOrDefault(x => x.Id == id);
                if (book != null)
                {
                    Console.Write("Enter new name : ");
                    string newName = Console.ReadLine();
                    book.Name = newName;
                    context.Update(book);
                    context.SaveChanges();
                    Console.WriteLine("Succesfully updated!");
                }
                else
                {
                    Console.WriteLine($"There is no record with this ID : {updetaId}");
                }
            }
        }

        public E_Book DeleteData()
        {
            Console.Clear();
            Console.Write("Enter Id to delete record : ");
            int deletedId = Convert.ToInt32(Console.ReadLine());

            using (var context = new AppDbContext())
            {
                int count = context.Books.Select(x => x).Where(x => x.Id == deletedId).Count();
                if (count > 0) {
                    var std = context.Books.Select(x => x).Where(x => x.Id == deletedId).First();
                    context.Books.Remove(std);
                    context.SaveChanges();
                    Console.WriteLine($"Record has been deleted: ID = {deletedId}");
                }
                else
                {
                    Console.WriteLine($"There is no record with this ID : {deletedId}");
                }
            }
            return E_Book;
        }
    }
}
