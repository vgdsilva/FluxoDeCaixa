﻿namespace FluxoDeCaixa.MAUI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new NavigationPage(new Pages.Login.LoginPage());
            MainPage = new Pages.Onboarding.OnboardingPage();
        }
    }
}
