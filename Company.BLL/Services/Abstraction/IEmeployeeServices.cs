namespace Company.BLL.Services.Abstraction
{
    public interface IEmeployeeServices
    {
        List<Employee> GetAllEmployee();
        bool Add(Employee employee);
        bool Update (Employee employee, string EditBy);
        bool Delete(long Id, string DeletedBy);
        Employee GetById(long Id);
    }
}
