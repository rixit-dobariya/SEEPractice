using Microsoft.AspNetCore.Mvc;
using SEEPractice.Models;

namespace SEEPractice.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            Student student = new Student();
            return View(student.GetStudents(0));
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student obj)
        {
            if (ModelState.IsValid)
            {
                Student temp = new Student();
                if (temp.insert(obj))
                {
                    TempData["msg"] = "Insertion successful";
                }
                else
                {
                    TempData["msg"] = "Insertion failed";
                }
                return RedirectToAction("Index");
            }
            
            return View();
        }

        public IActionResult Edit(int id)
        {
            Student student = new Student();
            List<Student> students = student.GetStudents(id);
            //1 
            Student temp = students.FirstOrDefault();
            return View(temp);
            
        }
        [HttpPost]
        public IActionResult Edit(Student obj)
        {
            if (ModelState.IsValid)
            {
                Student temp = new Student();
                if (temp.update(obj))
                {
                    TempData["msg"] = "Updation successful";
                }
                else
                {
                    TempData["msg"] = "Update failed";
                }
                return RedirectToAction("Index");
            }

            return View();
        }
        public IActionResult Delete(int id)
        {

            Student student = new Student();
            List<Student> students = student.GetStudents(id);
            //1 
            Student temp = students.FirstOrDefault();
            return View(temp);
        }
        [HttpPost]
        public IActionResult Delete(Student obj)
        {
            if (ModelState.IsValid)
            {
                Student temp = new Student();
                if (temp.delete(obj.Id))
                {
                    TempData["msg"] = "Deletion successful";
                }
                else
                {
                    TempData["msg"] = "Delete failed";
                }
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
