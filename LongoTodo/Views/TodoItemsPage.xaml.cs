using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LongoTodo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TodoItemsPage : ContentPage
    {
        public TodoItemsPage()
        {
            InitializeComponent();
        }
    }
}
