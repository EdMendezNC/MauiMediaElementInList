using CommunityToolkit.Mvvm.ComponentModel;
using MauiApp7.Services;

namespace MauiApp7.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        public MainViewModel()
        {
            var dataService = new Dataservice();
            var models = dataService.GetFacts();
            Facts = models.Select(x => new FactViewModel(x)).ToList();
        }

        [ObservableProperty]
        List<FactViewModel> facts = new List<FactViewModel>();
    }
}
