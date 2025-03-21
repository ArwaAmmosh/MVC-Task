namespace Company.BLL.ModelVM.Employee
{
    public class DisplayEmployee(string fName, string lName, int age, DateTime createdOn, string imagepath)
    {
        public string FName { get; set; } = fName;
        public string LName { get; set; } = lName;
        public int Age { get; set; } = age;
        public string ImagePath { get; set; }= imagepath;
        public DateTime CreatedOn { get; set; } = createdOn;

    }
}
