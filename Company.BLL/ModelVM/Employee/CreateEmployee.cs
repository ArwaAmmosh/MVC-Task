namespace Company.BLL.ModelVM.Employee
{
    public class CreateEmployee
    {
        public required string  FName { get; set; }
        public required string LName { get; set; }
        public required int Age { get; set; }
        public required double Salary { get;  set; }
        public required string CreatedBy { get; set; } 
        public required IFormFile Image { get; set; }


    }
}
