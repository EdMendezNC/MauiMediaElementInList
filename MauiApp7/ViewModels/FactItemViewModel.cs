using CommunityToolkit.Mvvm.ComponentModel;
using MauiApp7.Models;

namespace MauiApp7.ViewModels
{
    public partial class FactItemViewModel : ObservableObject
    {
        FactItem _model;
        public FactItemViewModel(FactItem model)
        {
            _model = model;
            this.Load(model);
        }

        private void Load(FactItem model)
        {
            Id = model.Id;
            Caption = model.Caption;
            FactItemType = model.FactItemType;
            UriStoragePath = model.UriStoragePath;


            switch (model.FactItemType)
            {

                case FactItemType.Video:
                    ImageSource = "video_file.png";
                    break;

                case FactItemType.Image:
                    ImageSource = "image.png";
                    break;
                default:
                    throw new NotImplementedException("Fact Item Type ");
            }
        }

        [ObservableProperty]
        Guid id;

        [ObservableProperty]
        Guid dossierId;

        [ObservableProperty]
        Guid tenantId;

        [ObservableProperty]
        string caption;

        [ObservableProperty]
        FactItemType factItemType;

        [ObservableProperty]
        string uriStoragePath;


        [ObservableProperty]
        ImageSource imageSource;


    }
}
