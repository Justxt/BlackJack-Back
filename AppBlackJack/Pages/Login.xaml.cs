
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

        // Esta secci�n es para navegar a la p�gina de registro si no tiene cuenta
        var tapGestureRecognizer = new TapGestureRecognizer();
        tapGestureRecognizer.Tapped += (s, e) => {
            // Aqu� indicamos la navegaci�n a la p�gina deseada
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
            await DisplayAlert("Error", "Por favor ingrese su c�dula y contrase�a.", "OK");
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
            // Maneja el resultado del inicio de sesi�n
            await DisplayAlert("�xito", "Inicio de sesi�n exitoso.", "OK");
            await Navigation.PopAsync(); // Cierra la p�gina actual 
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Error durante el inicio de sesi�n: {ex.Message}", "OK");

            // Maneja la l�gica despu�s de que se cierra el cuadro de di�logo de error, si es necesario.
        }
    }

    private async void OnRegisterButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Pages.Register());
    }
}