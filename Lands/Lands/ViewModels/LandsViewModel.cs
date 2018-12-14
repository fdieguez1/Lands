using GalaSoft.MvvmLight.Command;
using Lands.Models;
using Lands.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Lands.ViewModels
{
    public class LandsViewModel : BaseViewModel
    {

        private string textoPrueba;

        public string TextoPrueba {
            get { return this.textoPrueba; }
            set { SetValue(ref this.textoPrueba, value); }
        }

        private ApiService apiService;
        private ObservableCollection<Land> lands;

        public ObservableCollection<Land> Lands
        {
            get { return this.lands; }
            set { SetValue(ref this.lands, value); }
        }
        private bool isRefreshing;
        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { SetValue(ref this.isRefreshing, value); }
        }

        public LandsViewModel()
        {
            apiService = new ApiService();
            LoadLands();
        }
        

        
        private async void LoadLands()
        {
            IsRefreshing = true;
            var checkConection = await apiService.CheckConnection();
            if (!checkConection.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    checkConection.Message,
                    "Accept"
                    );
                await Application.Current.MainPage.Navigation.PopAsync();
                return;
            }
            else
            {
                var response = await apiService.GetList<Land>(
                    "http://restcountries.eu",
                    "/rest",
                    "/v2/all"
                    );

                if (!response.IsSuccess)
                {
                    await Application.Current.MainPage.DisplayAlert(
                        "Error",
                        response.Message,
                        "Accept"
                        );
                    await Application.Current.MainPage.Navigation.PopAsync();
                    return;
                }
                else
                {
                    var list = (List<Land>)response.Result;
                    Lands = new ObservableCollection<Land>(list);
                    IsRefreshing = false;
                }
            }
        }

        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(LoadLands);
            }
        }
    }
}
