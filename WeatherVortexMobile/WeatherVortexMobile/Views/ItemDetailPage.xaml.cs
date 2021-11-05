﻿namespace WeatherVortexMobile.Views
{
    using System.ComponentModel;

    using WeatherVortexMobile.ViewModels;

    using Xamarin.Forms;

    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}