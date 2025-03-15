namespace Company.BLL.Services.Implementation
{
    public class EmeployeeServices : IEmeployeeServices
    {
        private readonly EmployeeRepo employeeRepo;
        public EmeployeeServices()
        {
            employeeRepo = new EmployeeRepo();
        }
        public bool Add(Employee employee)
        {
         return employeeRepo.Add(employee);
        }

        public bool Delete(long Id, string DeletedBy)
        {
            return employeeRepo.Delete(Id, DeletedBy);
        }

        public List<Employee> GetAllEmployee()
        {
            return employeeRepo.GetAll();
        }

        public Employee GetById(long Id)
        {
            return employeeRepo.GetById(Id);
        }

        public bool Update(Employee employee, string EditBy)
        {
            return employeeRepo.Update(employee, EditBy);
        }
    }
}
