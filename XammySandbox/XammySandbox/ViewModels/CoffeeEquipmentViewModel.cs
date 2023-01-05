using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using XammySandbox.Models;

namespace XammySandbox.ViewModels
{
    public class CoffeeEquipmentViewModel : BaseViewModel
    {
        public ObservableRangeCollection<Coffee>Coffee { get; }
        //groupings allow for lists of lists 
        public ObservableRangeCollection<Grouping<string, Coffee>> CoffeeGroups { get; }
        public AsyncCommand RefreshCommand { get; }
        public CoffeeEquipmentViewModel() 
        {
            Title = "Coffee Equipment";

            Coffee = new ObservableRangeCollection<Coffee>();
            CoffeeGroups = new ObservableRangeCollection<Grouping<string, Coffee>>();

            var image = "https://media.istockphoto.com/id/1303583671/photo/cup-glass-of-coffee-with-smoke-and-coffee-beans-on-old-wooden-background.jpg?s=612x612&w=0&k=20&c=fAh3m6Hqxz-qeA45Tj2jGARhRiGFhgm80dLVthnvlD8=";

            Coffee.Add(new Coffee { Roaster = "Yes Plz", Name = "Sip of Sunshine", Image = image });
            Coffee.Add(new Coffee { Roaster = "Yes Plz", Name = "Potent Potable", Image = image });
            Coffee.Add(new Coffee { Roaster = "Yes Plz", Name = "Potent Potable", Image = image });
            Coffee.Add(new Coffee { Roaster = "Blue Bottle", Name = "Kenya Kiambu Handege", Image = image });
            Coffee.Add(new Coffee { Roaster = "Blue Bottle", Name = "Kenya Kiambu Handege", Image = image });

            CoffeeGroups.Add(new Grouping<string, Coffee>("Blue Bottle", Coffee.Where(c => c.Roaster == "Blue Bottle")));
            CoffeeGroups.Add(new Grouping<string, Coffee>("Yes Plz", Coffee.Where(c => c.Roaster == "Yes Plz")));

            RefreshCommand = new AsyncCommand(Refresh);
        }

        async Task Refresh()
        {
            IsBusy = true;
            await Task.Delay(2000);
            isBusy = false; 
        }
       

        

        //example of using setProperty once more
        bool isBusy; 
        public bool IsBusy
        {
            get => isBusy;
            set=> SetProperty(ref isBusy, value);
        }
    }
}
