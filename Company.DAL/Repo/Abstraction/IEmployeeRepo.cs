using System.Linq.Expressions;

namespace Company.DAL.Repo.Abstraction
{
    public interface IEmployeeRepo
    {
        Employee? GetById(long Id);
        bool Add(Employee employee);
        bool Update(long id, string updatedBy, string fname, string lname, int age, double salary);
        bool Delete(long Id, string DeletedBy);
        List<Employee> GetAll();   

    }
}
