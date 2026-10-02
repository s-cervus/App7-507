using App7_507.Models;
using App7_507.Services;
using System;
using System.ComponentModel.DataAnnotations;

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
        
        StudentsCollection.ItemsSource =
        await database.GetAll();
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        // string phone_i = phoneEntry.Text; int.TryParse(phone_i, out int convertedNUM);

/*
        if (phoneEntry == null || phoneEntry.Length != 10)
        {
            return;
        }

        
        // ^ = inicio, \d = número, {10} = exactamente diez veces, $ = fin
        if (!Regex.IsMatch(textoIngresado, @"^\d{10}$"))
        {
            
            return;
        }
*/
        
        long numeroFinal = long.Parse(textoIngresado);

        


        Student Student = new()
        {
            name_student = nombreEntry.Text,
            group_student = grupoEntry.Text,
            rfc_student = rfcEntry.Text,
            phone_num_student = phoneEntry.Text
        };

        await database.Save(Student);

        nombreEntry.Text = "";
        grupoEntry.Text = "";
        rfcEntry.Text = "";
        phoneEntry.Text = "";

        StudentsCollection.ItemsSource =
            await database.GetAll();
    }
}


