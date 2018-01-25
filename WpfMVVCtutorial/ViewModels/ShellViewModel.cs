using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMVVCtutorial.Models;

/// <summary>
/// http://caliburnmicro.com/documentation/
/// </summary>
namespace WpfMVVCtutorial.ViewModels
{
    public class ShellViewModel : Conductor<object>         /* or : Screen*/
    {

        private string _firstName = "Tim";
        private string _lastName;
        private PersonModel _selectedPerson;
        private BindableCollection<PersonModel> _people = new BindableCollection<PersonModel>();

        //simulating database
        public ShellViewModel()
        {
            People.Add(new PersonModel { FirstName = "Viorel", LastName = "Munteanu" });
            People.Add(new PersonModel { FirstName = "Alexandra", LastName = "Irina" });
            People.Add(new PersonModel { FirstName = "Irina", LastName = "Voicu" });
        }

        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                NotifyOfPropertyChange(() => FirstName);
                NotifyOfPropertyChange(() => FullName);
            }
        }
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                NotifyOfPropertyChange(() => LastName);
                NotifyOfPropertyChange(() => FullName);
            }
        }
        public string FullName
        {
            get
            {
                return $"{ FirstName } { LastName }";
            }
        }
        public BindableCollection<PersonModel> People
        {
            get { return _people; }
            set { _people = value; }
        }
        public PersonModel SelectedPerson
        {
            get { return _selectedPerson; }
            set
            {
                _selectedPerson = value;
                NotifyOfPropertyChange(() => SelectedPerson);
            }
        }
        public bool CanClearText(string firstName, string lastName) /*=> !String.IsNullOrWhiteSpace(firstName) || !String.IsNullOrWhiteSpace(lastName);*/
        {
            //return !String.IsNullOrWhiteSpace(firstName) || !String.IsNullOrWhiteSpace(lastName);

            if (String.IsNullOrWhiteSpace(firstName) && String.IsNullOrWhiteSpace(lastName))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void ClearText(string firstName, string lastName)
        {
            FirstName = "";
            LastName = "";
        }


        public void LoadPageOne()
        {
           ActivateItem(new FirstChildViewModel());
        }
        public void LoadPageTwo()
        {
            ActivateItem(new SecondChildViewModel());
        }
    }
}
