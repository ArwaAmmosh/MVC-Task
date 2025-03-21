namespace Company.BLL.Services.Abstraction
{
    public interface IEmeployeeServices
    {
        List<DisplayEmployee> GetAllEmployee();
        bool Add(CreateEmployee employee);
        bool Update (long id, EditEmployee employee);
        bool Delete(long Id, string DeletedBy);
        DisplayEmployee? GetById(long Id);
    }
}
