using CommunityToolkit.Mvvm.ComponentModel;
using MauiApp7.Models;
using System.Collections.ObjectModel;

namespace MauiApp7.ViewModels
{
    public partial class FactViewModel : ObservableObject
    {
        //private readonly Fact _model;

        public FactViewModel(Fact model)
        {
            //_model = model;
            this.Load(model);
        }

        private void Load(Fact model)
        {
            Id = model.Id;
            Description = model.Description;
            Data = model.Data;

            foreach (var m in model.FactItems)
            {
                FactItems.Add(new FactItemViewModel(m));
            }
        }

        [ObservableProperty]
        Guid id;

        [ObservableProperty]
        string description;

        [ObservableProperty]
        string data;

        [ObservableProperty]
        ObservableCollection<FactItemViewModel> factItems = new ObservableCollection<FactItemViewModel>();


    }
}
