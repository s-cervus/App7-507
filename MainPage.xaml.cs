using App7_507.Models;
using App7_507.Services;

namespace App7_507;

public partial class MainPage : ContentPage
{
    DatabaseService database;

    public MainPage(DatabaseService db)
    {
        InitializeComponent();

        database = db;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        // StudentsCollection.ItemsSource =
        await database.GetAll();
    }

    private async void OnGuardarClicked(object sender, EventArgs e)
    {
        Student Student = new()
        {
            name_student = NombreEntry.Text,
            group = GrupoEntry.Text
        };

        await database.Save(Student);

        NombreEntry.Text = "";
        GrupoEntry.Text = "";

        // StudentsCollection.ItemsSource =
            await database.GetAll();
    }
}


