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
            var emp = _dbContext.Employees.FirstOrDefault(a => a.Id == Id);
            if (emp == null) return null;
            return emp;
        }

        public bool Update(long id, string updatedBy, string fname, string lname, int age, double salary)
        {
            try
            {
                var emp = _dbContext.Employees.Where(a => a.Id == id).FirstOrDefault();
                if (emp == null)
                    return false;
                var result = emp.Edit(updatedBy, fname, lname, age, salary);
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
