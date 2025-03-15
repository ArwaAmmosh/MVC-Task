using System.Linq.Expressions;

namespace Company.DAL.Repo.Abstraction
{
    public interface IEmployeeRepo
    {
        Employee? GetById(long Id);
        bool Add(Employee employee);
        bool Update(Employee employee, string EditBy);
        bool Delete(long Id, string DeletedBy);
        List<Employee> GetAll();   

    }
}
