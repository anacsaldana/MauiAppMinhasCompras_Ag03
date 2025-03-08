using MauiAppMinhasCompras.Models;

namespace MauiAppMinhasCompras.Views;

public partial class ListaProduto : ContentPage
{
    public ListaProduto()
    {
        InitializeComponent();
    }

    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            Navigation.PushAsync(new Views.NovoProduto());
        }
        catch (Exception ex)
        {
            DisplayAlert("Ops", ex.Message, "OK");
        }
    }

    private async void ListaProduto_Appearing(object sender, EventArgs e)
    {
        listaProdutosView.ItemsSource = await App.Db.GetAll();
    }

    private async void OnItemSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection != null && e.CurrentSelection.Count > 0)
        {
            Produto produtoSelecionado = (Produto)e.CurrentSelection[0];
            await DisplayAlert("Produto Selecionado", produtoSelecionado.Descricao, "OK");

            listaProdutosView.SelectedItem = null;
        }
    }

    private async void DeleteButton_Clicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.CommandParameter is int id)
        {
            await App.Db.Delete(id);
            listaProdutosView.ItemsSource = await App.Db.GetAll();
        }
    }

    private async void SomarButton_Clicked(object sender, EventArgs e)
    {
        double total = 0;
        var produtos = await App.Db.GetAll();

        foreach (var produto in produtos)
        {
            total += produto.Quantidade * produto.Preco;
        }

        await DisplayAlert("Total", $"O valor total é: R$ {total:F2}", "OK");
    }
}
