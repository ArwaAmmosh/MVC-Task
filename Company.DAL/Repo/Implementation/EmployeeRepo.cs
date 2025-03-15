using Company.DAL.DataBase;
namespace Company.DAL.Repo.Implementation
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private static readonly ApplicationDBContext _dbContext = new();

        public bool Add(Employee employee)
        {
            try
            {
                _dbContext.Employees.Add(employee);
                _dbContext.SaveChanges();
                return true;
            }
            catch
            { 
                return false;
            }

        }

        public bool Delete(long Id,string DeletedBy)
        {
            try
            {
                var employee = _dbContext.Employees.Where(a => a.Id == Id).FirstOrDefault();
                if (employee == null)
                    return false;
                var result = employee.Deleted(DeletedBy);
                if (result)
                {
                    _dbContext.SaveChanges();
                    return true;
                }
                return false;

            }
            catch
            {
                return false;
            }
        }

        public List<Employee> GetAll()
        {
            return [.. _dbContext.Employees];
        }

        public Employee? GetById(long Id)
        {
            return _dbContext.Employees.FirstOrDefault(a => a.Id == Id);
        }

        public bool Update(Employee employee, string EditBy)
        {
            try
            {
                var emp = _dbContext.Employees.Where(a => a.Id == employee.Id).FirstOrDefault();
                if (employee == null)
                    return false;
                var result = emp.Edit(EditBy, employee.FName, employee.LName, employee.Age, employee.Salary);
                if (result)
                {
                    _dbContext.SaveChanges();
                    return true;
                }
                return false;

            }
            catch
            {
                return false;
            }
        }
    }
    }
