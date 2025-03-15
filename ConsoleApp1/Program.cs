using Company.BLL.Services.Abstraction;
using Company.BLL.Services.Implementation;
using Company.DAL.Entities;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IEmeployeeServices services = new EmeployeeServices();
            Employee emp = new Employee("Magda", "Elseidy", 45, 10000, "me");
            services.Add(emp);
        }
    }
}
