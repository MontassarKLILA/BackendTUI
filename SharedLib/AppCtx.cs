using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using SharedLib.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace SharedLib
{
    public class AppCtx : DbContext
    {

        private static string connectionString = @"Data Source=..\SharedLib\Files\TravelAgency.db;Version=3";

        public AppCtx(DbContextOptions<AppCtx> options) : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerFile> CustomerFiles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductPhoto> ProductPhotos { get; set; }

        public static void InitializeDatabase()
        {
            if (!File.Exists(@"..\SharedLib\Files\TravelAgency.db"))
            {
                InitDB();
            }
        }


        // InitDB : This fuction implements 
        // Create tables
        // Load data into tables created
        public  static void InitDB()
        {
            SQLiteConnection.CreateFile(@"..\SharedLib\Files\TravelAgency.db");
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                CreateDbTables(connection);
                Thread.Sleep(1000);
                LoadDataToDbTables(connection);
                connection.Close();
            }
        }

        public static void CreateDbTables(SQLiteConnection connection)
        {
            string createCustomersTableQuery = @"
                      CREATE TABLE IF NOT EXISTS Customers (
                        uid TEXT PRIMARY KEY,
                        first_name TEXT NOT NULL,
                        last_name TEXT NOT NULL,
                        birthdate DATETIME NOT NULL,
                        email TEXT NOT NULL,
                        phone TEXT NULL,
                        password TEXT NULL,
                        address_1 TEXT NOT NULL,
                        address_2 TEXT NULL,
                        city TEXT NOT NULL,
                        country TEXT NOT NULL,
                        zipcode TEXT NOT NULL,
                        travel_document TEXT NULL,
                        travel_document_number TEXT NULL
                      );";
            string createCustomerFileTableQuery = @"
                      CREATE TABLE IF NOT EXISTS CustomerFiles (
                        uid TEXT PRIMARY KEY,
                        customeruid TEXT NOT NULL,
                        hoteluid TEXT NOT NULL,
                        check_in_date DATETIME NOT NULL,
                        check_out_date DATETIME NOT NULL,
                        travel_type TEXT NULL,
                        flight_number TEXT NULL,
                        departure_date DATETIME NULL,
                        arrival_date DATETIME NULL,
                        destination_country TEXT NULL,
                        destination_city TEXT NULL
                      );";
            string createProductsTableQuery = @"
                      CREATE TABLE IF NOT EXISTS Products (
                        uid TEXT PRIMARY KEY,
                        hotel_name TEXT NOT NULL,
                        hotel_description TEXT NULL,
                        stars INTEGER NULL,
                        total_capacity INTEGER NULL
                      );";
            string createProductPhotosTableQuery = @"
                      CREATE TABLE IF NOT EXISTS ProductPhotos (
                        uid TEXT PRIMARY KEY,
                        productuid TEXT NOT NULL,
                        meta_title TEXT NOT NULL,
                        meta_description TEXT NULL,
                        url TEXT NOT NULL,
                        type TEXT NOT NULL
                      );";

            using (var cmd = new SQLiteCommand(connection))
            {
                cmd.CommandText = createCustomersTableQuery;
                cmd.ExecuteNonQuery();
           
                cmd.CommandText = createCustomerFileTableQuery;
                cmd.ExecuteNonQuery();
            
                cmd.CommandText = createProductsTableQuery;
                cmd.ExecuteNonQuery();
         
                cmd.CommandText = createProductPhotosTableQuery;
                cmd.ExecuteNonQuery();
          
            }
        }

        public static void LoadDataToDbTables(SQLiteConnection connection)
        {
            string loadCustomersDataQuery = @"INSERT INTO Customers 
                (uid,first_name,last_name,birthdate,email,phone,password,address_1,address_2,city,country,zipcode,travel_document,travel_document_number)
                VALUES
                ('1','Montassar','KLILA KERKENI','1989-10-06','montassar@test.com','+33685974632','m123456789','Rue xxxx xxxx','','Paris','France','75010','Passport','Z02365'),
                ('2','Francesco','TOTTI','1982-01-18','francesco@test.com','+33923974777','f123456789','Rue xxxx xxxx','','Rome','Italie','8852','CIN','06873359');";
            string loadCustomerFileDataQuery = @"INSERT INTO CustomerFiles 
                (uid,customeruid,hoteluid,check_in_date,check_out_date,travel_type,flight_number,departure_date,arrival_date,destination_country,destination_city)
                VALUES
                ('1','1','1','2023-11-12','2023-11-25','Tourisme','TO987','2023-11-12','2023-11-25','Marroc','Marrakech'),
                ('2','2','2','2023-11-18','2023-11-22','Affaire','IT0236','2023-11-18','2023-11-22','Marroc','Casablanca');";
            string loadProductsDataQuery = @"INSERT INTO Products 
                (uid,hotel_name,hotel_description,stars,total_capacity)
                VALUES
                ('1','Club Medina Marrakech','Le Club Madina - All Inclusive possède également un centre de spa et propose des massages. Vous profiterez d un restaurant sur place. Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem.','4','600'),
                ('2','Hôtel Mövenpick Casablanca','Hôtel Mövenpick Casablanca - All Inclusive Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem. possède également un centre de spa et propose des massages. Vous profiterez d un restaurant sur place','5','200');";
            string loadProductPhotosDataQuery = @"INSERT INTO ProductPhotos 
                (uid,productuid,meta_title,meta_description,url,type)
                VALUES
                ('1','1','img01','','https://cf.bstatic.com/xdata/images/hotel/max1024x768/351749128.jpg?k=583cd1b99419abb1460eac2d9bc60c7066456fa42a5e5e065c260cf612282b0d&o=&hp=1','Primary'),
                ('2','1','img02','','https://cf.bstatic.com/xdata/images/hotel/max1024x768/178885152.jpg?k=29dadcaeeb8dcdf2b74193d31aed521e56d162e6084e3406e6eb9e5b6829a147&o=&hp=1','Cover'),
                ('3','1','img03','','https://cf.bstatic.com/xdata/images/hotel/max1280x900/178864843.jpg?k=e69b1dd2b537a93bb9dffc24af7cebb77b552c688d71fa660fa22926b0b67bc5&o=&hp=1','Secondary'),
                ('4','2','img01','','https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ6f1IMg_GUPvFc_9iheiRPIrKdzpQuWzASSfALRZ0tVGHuDYH00zuhWDpoxJIdB9ZE_ZM&usqp=CAU','Primary'),
                ('5','2','img02','','https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQgFpTnmxah6aGAYBccNUcEx-bbJTGQOWnaAurD80zftujUMLNcEa0DxkW7PjYLAbFuG-s&usqp=CAU','Cover'),
                ('6','2','img03','','https://lh3.googleusercontent.com/gps-proxy/AFm_dcQVPwa8-hKdt-_UvfgGHpzjEjl-cDH_7eKbRUy3HS3zpiiFNToIA2zwauzD-bhYJS-ehYDVicAnYDAVXxO5pOwD6FpFTYjAa4vMKaBfUjtF7zlFxTWDoEF7-3CP82S36HokKsc5ERjXuZkdK3MWyjAqRI86Do-lNw8_ljWDGYPI3C9C6-2qHWk=w287-h192-n-k-rw-no-v1','Secondary');";

            using (var cmd = new SQLiteCommand(connection))
            {
                cmd.CommandText = loadCustomersDataQuery;
                cmd.ExecuteNonQuery();
           
                cmd.CommandText = loadProductsDataQuery;
                cmd.ExecuteNonQuery();
       
                cmd.CommandText = loadCustomerFileDataQuery;
                cmd.ExecuteNonQuery();
       
                cmd.CommandText = loadProductPhotosDataQuery;
                cmd.ExecuteNonQuery();
            }
        }

    }
}
