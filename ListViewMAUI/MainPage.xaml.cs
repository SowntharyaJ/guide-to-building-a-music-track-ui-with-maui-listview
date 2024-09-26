using ListViewMAUI.Service;

namespace ListViewMAUI
{
    public partial class MainPage : ContentPage
    {
        public MainPage(AudioInfoViewModel audioInfoViewModel)
        {
            InitializeComponent();
            BindingContext = audioInfoViewModel;
        }   
    }

}
