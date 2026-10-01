using App7_507.Models;
using SQLite;

namespace App7_507.Services;

public class DatabaseService
{
    SQLiteAsyncConnection db;

    async Task Init()
    {
        if (db != null)
            return;

        string rute =
            Path.Combine(FileSystem.AppDataDirectory,
            "Students.db3");

        db = new SQLiteAsyncConnection(rute);

        await db.CreateTableAsync<Student>();
    }

    public async Task<List<Student>> GetAll()
    {
        await Init();
        return await db.Table<Student>().ToListAsync();
    }

    public async Task Save(Student Student)
    {
        await Init();

        if (Student.ID_A != 0)
            await db.UpdateAsync(Student);
        else
            await db.InsertAsync(Student);
    }

    public async Task Delete(Student Student)
    {
        await Init();
        await db.DeleteAsync(Student);
    }
}