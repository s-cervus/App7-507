using App7_507.Models;
using App7_507.Services;
using System;
using System.ComponentModel.DataAnnotations;

namespace App7_507;

public partial class MainPage : ContentPage
{
    DatabaseService database;
    Student selectedStudent = null;

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

        if (string.IsNullOrWhiteSpace(nombreEntry.Text))
        { 
            return;
            // error_Mark.Text = "Error: Ingrese un mobre primero.";
        }
        if (phoneEntry == null || phoneEntry.Text.Length > 10) { return; }

        grupoEntry.Text = string.IsNullOrWhiteSpace(grupoEntry.Text) ? "No especifica Grupo." : grupoEntry.Text;
        rfcEntry.Text = string.IsNullOrWhiteSpace(rfcEntry.Text) ? "No especifica RFC." : rfcEntry.Text;
        phoneEntry.Text = string.IsNullOrWhiteSpace(phoneEntry.Text) ? "No especifica Número." : phoneEntry.Text;




        // string phone_i = phoneEntry.Text; int.TryParse(phone_i, out int convertedNUM);

        /*
        // ^ = inicio, \d = número, {10} = exactamente diez veces, $ = fin
        if (!Regex.IsMatch(phoneEntry, @"^\d{10}$"))
        {

            return;
        }

        long numeroFinal = long.Parse(phoneEntry.Text);
        */

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

    private void OnSelectionChanged(object sender,
    SelectionChangedEventArgs e)
    {
        selectedStudent =
        e.CurrentSelection.FirstOrDefault() as Student;
        if (selectedStudent != null)
        {
            nombreEntry.Text = selectedStudent.name_student;
            grupoEntry.Text = selectedStudent.group_student;
            rfcEntry.Text = selectedStudent.rfc_student;
            phoneEntry.Text = selectedStudent.phone_num_student;
        }
    }
    private async void OnDeleteClicked(object sender, EventArgs e)
    {
        if (selectedStudent != null)
        {
            await database.Delete(selectedStudent);
            StudentsCollection.ItemsSource = await database.GetAll();
            nombreEntry.Text = "";
            grupoEntry.Text = "";
            rfcEntry.Text = "";
            phoneEntry.Text = "";


            selectedStudent = null;
        }
    }

    private async void OnChange(object sender, EventArgs e)
    {

        if (selectedStudent != null)
        {
            await database.Delete(selectedStudent);
            StudentsCollection.ItemsSource = await database.GetAll();
            OnSaveClicked(null, null);

            selectedStudent = null;
        }
    }
}

    /*
    private async void OnSelect(object sender, EventArgs e)
    {
        if (nombreEntry.IsReadOnly)
        {
            nombreEntry.IsReadOnly = false;
            grupoEntry.IsReadOnly = false;
            rfcEntry.IsReadOnly = false;
            phoneEntry.IsReadOnly = false;
        }
        else
        {
            nombreEntry.IsReadOnly = true;
            grupoEntry.IsReadOnly = true;
            rfcEntry.IsReadOnly = true;
            phoneEntry.IsReadOnly = true;
        }
        
    }

*/