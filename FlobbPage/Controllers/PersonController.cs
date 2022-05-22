using Microsoft.AspNetCore.Mvc;
using FlobbPage.Models;

namespace FlobbPage.Controllers
{
    public class PersonController : Controller
    {
        

        public IActionResult Index()
        {

            List<Person> personList = new List<Person>();

            if (Models.ViewModels.PeopleViewModel.Persons == null)
            {
                Guid uuid = Guid.NewGuid();
                

                Person person = new Person();
                person.Id = uuid.ToString();
                person.City = "Stockholm";
                person.Name = "Totte";
                person.PhoneNumber = "+46 070-393939";

                uuid = Guid.NewGuid();

                Person person2 = new Person();
                person2.Id = uuid.ToString();
                person2.City = "Stockholm";
                person2.Name = "Lotte";
                person2.PhoneNumber = "+46 070-393931";

                personList.Add(person);
                personList.Add(person2);

                Models.ViewModels.PeopleViewModel.Persons = personList;

            }
           


            return View(Models.ViewModels.PeopleViewModel.Persons);
        }

        [HttpPost]
        public IActionResult Index(string search)
        {
            
            var personList = Models.ViewModels.PeopleViewModel.Persons;
            List<Person> sortList = new();
            if (search == null) { return View(sortList); }

            foreach (var p in personList)
            {
                if(p.Name.Contains(search) || p.City.Contains(search))
                {
                    sortList.Add(p);
                }
            }

            return View(sortList);
        }

        public IActionResult ViewPerson()
        {
            var model = Models.ViewModels.PeopleViewModel.Persons;
            return PartialView("_PersonsPart", model);
        }

        public IActionResult Create(string txtName, string txtCity, string txtPhone) {

            

            Guid uuid = Guid.NewGuid();

            Person p = new Person();
            p.Id = uuid.ToString();
            p.Name = txtName;
            p.PhoneNumber = txtPhone;
            p.City = txtCity;

            if (ModelState.IsValid)
            {
                Models.ViewModels.CreatePersonViewModel.Create(p);

                return RedirectToAction("Index", "Person");
            }
            return (RedirectToAction("Index", "Person"));


        }

        public IActionResult Delete(string id) {

            Models.ViewModels.PeopleViewModel.Persons.RemoveAll(m=>m.Id==id);

            return RedirectToAction("Index", "Person");
        }

        public IActionResult DeleteLive(string id)
        {
            Models.ViewModels.PeopleViewModel.Persons.RemoveAll(m => m.Id == id);
            

            return PartialView("_personsPart",Models.ViewModels.PeopleViewModel.Persons);
        }

        public IActionResult GetDetails(string id)
        {
            var person = Models.ViewModels.PeopleViewModel.Persons.Where(m => m.Id == id);
            return PartialView("_personPart", person.FirstOrDefault());
        }

    }
}
