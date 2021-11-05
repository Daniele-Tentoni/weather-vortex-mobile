namespace WeatherVortexMobile.Views
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    using WeatherVortexMobile.Models;
    using WeatherVortexMobile.ViewModels;

    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}