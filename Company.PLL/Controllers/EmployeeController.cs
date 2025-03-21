namespace Company.PLL.Controllers
{
    public class EmployeeController(IEmeployeeServices services) : Controller
    {
        private readonly IEmeployeeServices emeployeeServices = services;

        public ActionResult Index()
        {
            ViewBag.Employees=emeployeeServices.GetAllEmployee();
            return View();
        }

        // GET: EmployeeController/Details/5
        [HttpGet]
        public ActionResult Details(int id)
        {  
            var emp= emeployeeServices.GetById(id);
            if (emp == null)
            {
                ViewBag.Massege = "Enter Valid Id To Retrive Data!";
                return View();
            }
            ViewBag.Employee=emp;
            return View();
        }

        // GET: EmployeeController/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateEmployee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = emeployeeServices.Add(employee);
                    if (result)
                        return RedirectToAction(nameof(Index));
                }
                else
                    ViewBag.Massege = "Enter Valid Data !";
                    return View();
            }
            catch
            {
                ViewBag.Massege = "Enter Valid Data !";
                return View();
            }
        }

        // GET: EmployeeController/Edit/5
        [HttpGet]
        public ActionResult Edit(long id)
        {
            ViewBag.Employee = emeployeeServices.GetById(id);
            return View();
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(long id,EditEmployee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = emeployeeServices.Update(id,employee);
                    if (result)
                        return RedirectToAction(nameof(Index));
                }
                else
                    ViewBag.Massege = "The Data Isn't Valid To Update The Employee!";
                return View();
            }
            catch
            {
                ViewBag.Massege = "The Data Isn't Valid To Update The Employee";
                return View();
            }
        }

        // GET: EmployeeController/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            ViewBag.Employee = emeployeeServices.GetById(id);
            return View();
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id, string deletedBy)
        {
            try
            {
               
                    var result = emeployeeServices.Delete(id, deletedBy);
                    if (result)
                        return RedirectToAction(nameof(Index));
                    else
                    {
                        ViewBag.Massege = "Something went Wrong While removing !";
                        return View();
                    }
            }
            catch
            {
                ViewBag.Massege = "Something went Wrong While removing !";
                return View();
            }
        }
    }
}
