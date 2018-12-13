using Lands.Models;
using Lands.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace Lands.ViewModels
{
    public class LandsViewModel : BaseViewModel
    {
        private ApiService apiService;
        private ObservableCollection<Land> lands;

        public ObservableCollection<Land> Lands
        {
            get { return lands; }
            set { SetValue(ref lands, value); }
        }

        public LandsViewModel()
        {
            apiService = new ApiService();
            LoadLands();
        }
        private bool isRefreshing;

        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set { SetValue(ref isRefreshing, value); }
        }



        private async void LoadLands()
        {
            IsRefreshing = true;
            var checkConection = await apiService.CheckConnection();
            if (!checkConection.IsSuccess) {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    checkConection.Message,
                    "Accept"
                    );
                await Application.Current.MainPage.Navigation.PopAsync();
                return;
            }
            var response = await apiService.GetList<Land>(
                "http://restcountries.eu",
                "/rest",
                "/v2/all"
                );
            if (response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Accept"
                    );
                return;
            }
            var list = (List<Land>)response.Result;
            Lands = new ObservableCollection<Land>(list);
        }
    }
}
