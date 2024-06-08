namespace AppBlackJack
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private async void toLogin(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Pages.Login());
        }

    }

}
