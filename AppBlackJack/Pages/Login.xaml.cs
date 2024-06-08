
using AppBlackJack.Models;
using AppBlackJack.Services;
using Microsoft.Maui.Controls;
using System;
using System.Linq;

namespace AppBlackJack.Pages;

public partial class Login : ContentPage
{
    private ApiService _apiService;
    public Login()
    {
        InitializeComponent();
        _apiService = new ApiService();

        // Esta sección es para navegar a la página de registro si no tiene cuenta
        var tapGestureRecognizer = new TapGestureRecognizer();
        tapGestureRecognizer.Tapped += (s, e) => {
            // Aquí indicamos la navegación a la página deseada
            Navigation.PushAsync(new Pages.Register());
        };
        lblRegistro.GestureRecognizers.Add(tapGestureRecognizer);
    }

    private async void OnLoginButtonClicked(object sender, EventArgs e)
    {
        string cedula = CedulaEntry.Text;
        string password = PasswordEntry.Text;

        if (string.IsNullOrWhiteSpace(cedula) || string.IsNullOrWhiteSpace(password))
        {
            await DisplayAlert("Error", "Por favor ingrese su cédula y contraseña.", "OK");
            return;
        }

        var userLogin = new UserLogin
        {
            Cedula = cedula,
            Password = password
        };

        try
        {
            var loginResult = await _apiService.Login(userLogin);
            // Maneja el resultado del inicio de sesión
            await DisplayAlert("Éxito", "Inicio de sesión exitoso.", "OK");
            await Navigation.PopAsync(); // Cierra la página actual 
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Error durante el inicio de sesión: {ex.Message}", "OK");

            // Maneja la lógica después de que se cierra el cuadro de diálogo de error, si es necesario.
        }
    }

    private async void OnRegisterButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Pages.Register());
    }
}