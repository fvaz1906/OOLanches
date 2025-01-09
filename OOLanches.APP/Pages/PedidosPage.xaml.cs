using OOLanches.APP.Services;
using OOLanches.APP.Validations;
using OOLanches.Core.Models;

namespace OOLanches.APP.Pages;

public partial class PedidosPage : ContentPage
{
    private readonly ApiService _apiService;
    private readonly IValidator _validator;
    private bool _loginPageDisplayed = false;

    public PedidosPage(ApiService apiService, IValidator validator)
	{
		InitializeComponent();
        _apiService = apiService;
        _validator = validator;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await GetListaPedidos();
    }

    private async Task GetListaPedidos()
    {
        try
        {
            // Exibe o indicador de carregamento
            loadPedidosIndicator.IsRunning = true;
            loadPedidosIndicator.IsVisible = true;

            var (pedidos, errorMessage) = await _apiService.GetPedidosPorUsuario(Preferences.Get("usuarioid", 0));

            if (errorMessage == "Unauthorized" && !_loginPageDisplayed)
            {
                await DisplayLoginPage();
                return;
            }
            if (errorMessage == "NotFound")
            {
                await DisplayAlert("Aviso", "N o existem pedidos para o cliente.", "OK");
                return;
            }
            if (pedidos is null)
            {
                await DisplayAlert("Erro", errorMessage ?? "N o foi poss vel obter pedidos.", "OK");
                return;
            }
            else
            {
                CvPedidos.ItemsSource = pedidos;
            }
        }
        catch (Exception)
        {
            await DisplayAlert("Erro", "Ocorreu um erro ao obter os pedidos. Tente novamente mais tarde.", "OK");
        }
        finally
        {
            // Esconde o indicador de carregamento
            loadPedidosIndicator.IsRunning = false;
            loadPedidosIndicator.IsVisible = false;
        }
    }

    private void CvPedidos_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var selectedItem = e.CurrentSelection.FirstOrDefault() as PedidoPorUsuario;

        if (selectedItem == null) return;

        Navigation.PushAsync(new PedidoDetalhesPage(selectedItem.Id,
                                                    selectedItem.PedidoTotal,
                                                    _apiService,
                                                    _validator));

        ((CollectionView)sender).SelectedItem = null;
    }

    private async Task DisplayLoginPage()
    {
        _loginPageDisplayed = true;
        await Navigation.PushAsync(new LoginPage(_apiService, _validator));
    }
}