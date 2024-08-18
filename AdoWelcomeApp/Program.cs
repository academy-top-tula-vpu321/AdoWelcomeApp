using Microsoft.Data.SqlClient;
using System.Data.Common;

string connectionString = "Data Source=Y5-0\\MSSQLSERVER01;Database=BookShop;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";

//DbConnection connection = new SqlConnection(connectionString);

//try
//{
//    await connection.OpenAsync();
//    Console.WriteLine("Connection open");
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}
//finally
//{
//    if(connection.State == System.Data.ConnectionState.Open)
//    {
//        await connection.CloseAsync();
//        Console.WriteLine("Connection close");
//    }
//}

using (DbConnection connection = new SqlConnection(connectionString))
{
    await connection.OpenAsync();
    //Console.WriteLine("Connection open");
    //Console.WriteLine($"Connection string: {connection.ConnectionString}");
    //Console.WriteLine($"Database: {connection.Database}");
    //Console.WriteLine($"Server: {connection.DataSource}");
    //Console.WriteLine($"Server's version: {connection.ServerVersion}");
    //Console.WriteLine($"State: {connection.State}");

    string commandText;

    //commandText = "DROP TABLE Author";
    //commandText = @"CREATE TABLE Author
    //                (
    //                id INT IDENTITY PRIMARY KEY,
    //                first_name NVARCHAR(50),
    //                last_name NVARCHAR(50),
    //                country NVARCHAR(50)
    //                )";

    //commandText = @"CREATE TABLE Book
    //                (
    //                    id INT IDENTITY PRIMARY KEY,
    //                    author_id INT NULL,
    //                    title NVARCHAR(100),
    //                    year INT,
    //                    price DECIMAL(8,2),
    //                    activity BIT
    //                )";

    // 1
    //DbCommand command = new SqlCommand();
    //command.CommandText = commandText;
    //command.Connection = connection;

    // 2
    //DbCommand command = new SqlCommand(commandText, (connection as SqlConnection));

    // 3

    //commandText = @"INSERT INTO Author 
    //                    (first_name, last_name, country)
    //                    VALUES
    //                    (N'Александр', N'Пушкин', N'Россия'),
    //                    (N'Федор', N'Достоевский', N'Россия'),
    //                    (N'Николай', N'Гоголь', N'Россия'),
    //                    (N'Джон', N'Стейнбек', N'Америка'),
    //                    (N'Виктор', N'Гюго', N'Франция'),
    //                    (N'Ярослав', N'Гашек', N'Чехия'),
    //                    (N'Ирвин', N'Шоу', N'Америка')";
    //commandText = @"UPDATE Author 
    //                    SET country = 'Россия' 
    //                    WHERE id = 2";
    //commandText = @"DELETE FROM Author
    //                    WHERE id = 2";


    //commandText = @"INSERT INTO Book
    //                    (author_id, title, year, price)
    //                    VALUES
    //                    (1, 'Руслан и Людмила', 1975, 210),
    //                    (2, 'Преступление и наказание', 2003, 340),
    //                    (3, 'Мертвые души', 2011, 520),
    //                    (1, 'Дубровский', 1998, 320),
    //                    (4, 'Гроздья гнева', 1989, 410)";

    //commandText = @"SELECT * FROM Book";

    commandText = @"SELECT COUNT(*) FROM Book";

    DbCommand command = connection.CreateCommand();
    command.CommandText = commandText;

    int? count = (int?)await command.ExecuteScalarAsync();
    Console.WriteLine($"Count of book: {count}");

    command.CommandText = "SELECT SUM(price) FROM Book";
    object? sum = await command.ExecuteScalarAsync();
    Console.WriteLine($"Summa prices of all book: {sum}");

    // await command.ExecuteNonQueryAsync();


    //DbDataReader reader = await command.ExecuteReaderAsync();

    //if (reader.HasRows)
    //{
    //    for (int i = 0; i < reader.FieldCount; i++)
    //        Console.Write($"{reader.GetName(i)}\t\t");
    //    Console.WriteLine($"\n{new String('-', 70)}");

    //    while (await reader.ReadAsync())
    //    {
    //        int id = reader.GetInt32(0);
    //        int author_id = reader.GetInt32(1);
    //        string title = reader.GetString(2);
    //        int year = reader.GetInt32(3);
    //        decimal price = reader.GetDecimal(4);
    //        bool activity = reader.GetBoolean(5);

    //        Console.WriteLine($"{id}\t\t{author_id}\t\t{title}\t\t{year}\t\t{price}\t\t{activity}\t\t");

    //        //string row = "";
    //        //for (int i = 0; i < reader.FieldCount; i++)
    //        //    row += reader.GetValue(i).ToString() + "\t\t";
    //        //Console.WriteLine(row);
    //    }
    //}

    //await reader.CloseAsync();

}

Console.WriteLine("Connection close");