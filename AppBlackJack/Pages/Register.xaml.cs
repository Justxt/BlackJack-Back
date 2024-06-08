using AppBlackJack.Models;
using AppBlackJack.Services;

namespace AppBlackJack.Pages;

public partial class Register : ContentPage
{
    private ApiService _apiService;

    public Register()
    {
        InitializeComponent();
        _apiService = new ApiService();

        //esta seccion es para navegar a la pagina de login si no tiene cuenta
        var tapGestureRecognizer = new TapGestureRecognizer();
        tapGestureRecognizer.Tapped += (s, e) => {
            Navigation.PushAsync(new Pages.Login());
        };
        lblLogin.GestureRecognizers.Add(tapGestureRecognizer);
    }

    private async void OnRegisterButtonClicked(object sender, EventArgs e)
    {
        string cedula = CedulaEntry.Text;
        string name = NameEntry.Text;
        string lastName = LastNameEntry.Text;
        string email = EmailEntry.Text;
        string phone = PhoneEntry.Text;
        string password = PasswordEntry.Text;
        string confirmPassword = ConfirmPasswordEntry.Text;

        if (string.IsNullOrWhiteSpace(cedula) || string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(lastName) ||
            string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(phone) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword))
        {
            await DisplayAlert("Error", "Llena todos los campos.", "OK");
            return;
        }

        if (password != confirmPassword)
        {
            await DisplayAlert("Error", "Las contraseñas no coinciden.", "OK");
            return;
        }

        var userRegister = new UserRegister
        {
            Cedula = cedula,
            Name = name,
            LastName = lastName,
            Email = email,
            Phone = phone,
            Password = password,
            ConfirmPassword = confirmPassword
        };

        try
        {
            var registerResult = await _apiService.Register(userRegister);
            await DisplayAlert("Éxito", "Se registro correctamente.", "OK");
            await Navigation.PopAsync();
            await Navigation.PushAsync(new Pages.Login());
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Error al registrarse: {ex.Message}", "OK");
        }
    }
}
