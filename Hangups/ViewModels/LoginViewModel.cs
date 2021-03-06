﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Hangups.Interfaces;
using Hangups.Services;
using HangupsCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;

namespace Hangups.ViewModels
{
    public class LoginViewModel : ViewModelBase, INavigable
    {
        public LoginViewModel()
        {
        }

        public bool AllowGoBack()
        {
            return false;
        }

        public void OnNavigatedFrom(NavigationEventArgs e)
        {

        }

        public void OnNavigatedTo(NavigationEventArgs e)
        {

        }

        public void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {

        }

        private RelayCommand _loginCommand;
        public RelayCommand LoginCommand
        {
            get
            {
                if (_loginCommand == null)
                    _loginCommand = new RelayCommand(async () =>
                    {
                        await App.Current.Manager.HangoutsService.Login();
                        if (!App.Current.Manager.SettingsService.CheckLocalSettingAvailable("profile_image"))
                        {
                            var user = await App.Current.Manager.HangoutsService.GetProfile("me");
                            App.Current.Manager.SettingsService.SetValueLocal("profile_image", user.image.url);
                        }
                        App.Current.NavigationService.NavigateTo("Home");
                    });

                return _loginCommand;
            }
        }
    }
}
