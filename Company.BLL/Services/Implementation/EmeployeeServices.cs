namespace Company.BLL.Services.Implementation
{
    public class EmeployeeServices(IEmployeeRepo employeeRepo) : IEmeployeeServices
    {
        private readonly IEmployeeRepo employeeRepo = employeeRepo;
        public bool Add(CreateEmployee employee)
        {
            if(employee.FName == null || employee.LName == null|| employee.CreatedBy == null || employee.FName == "" || employee.LName == "" || employee.Age == 0  || employee.Salary == 0 || employee.CreatedBy == "") 
                return false;
            var imagepath = ImageServices.UploadImage(employee.Image);
            if (imagepath is null)
                return false;
            Employee emp = new(employee.FName, employee.LName, employee.Age, employee.Salary, employee.CreatedBy)
            {
                Imagepath = imagepath
            };
            return employeeRepo.Add(emp);
        }

        public bool Delete(long Id, string DeletedBy)
        {
            return employeeRepo.Delete(Id, DeletedBy);
        }

        public List<DisplayEmployee> GetAllEmployee()
        {
            var emps= employeeRepo.GetAll();
            var result= new List<DisplayEmployee>();
            foreach(var item in emps)
            {
                if (item.IsDeleted == false)
                {
                    DisplayEmployee emp = new(item.FName, item.LName, item.Age, item.CreatedOn,item.Imagepath);
                    result.Add(emp);
                }
            }
            return result;
        }

        public DisplayEmployee? GetById(long Id)
        {
            var employee = employeeRepo.GetById(Id);
            if (employee == null) return null;
            DisplayEmployee emp = new(employee.FName, employee.LName, employee.Age, employee.CreatedOn,employee.Imagepath);
            return emp;
        }

        public bool Update(long id,EditEmployee employee)
        {
            if (employee.FName == null || employee.LName == null || employee.ModifiedBy == null || employee.FName == "" || employee.LName == "" || employee.Age == 0 || employee.Salary == 0 || employee.ModifiedBy == "")
                return false;
            return employeeRepo.Update( id,employee.ModifiedBy,employee.FName,employee.LName,employee.Age,employee.Salary);
        }
    }
}
