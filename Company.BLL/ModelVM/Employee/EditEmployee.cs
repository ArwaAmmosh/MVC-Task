namespace Company.BLL.ModelVM.Employee
{
    public class EditEmployee
    {
        public required string FName { get; set; }
        public required string LName { get;  set; } 
        public int Age { get;  set; }
        public double Salary { get;  set; }
        public required string ModifiedBy { get;  set; }

    }
}
