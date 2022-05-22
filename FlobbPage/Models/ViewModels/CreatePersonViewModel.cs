namespace FlobbPage.Models.ViewModels
{
    public class CreatePersonViewModel
    {
        public static void Create(Person p)
        {
            var personList = ViewModels.PeopleViewModel.Persons;

            if (personList.Any(pl => pl.Id == p.Id))
            {
                return;
            }
            else {
                ViewModels.PeopleViewModel.Persons.Add(p);
            }
        } 
    }
}
