using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace ShoppingCartApp.Common
{
    class MySQLiteHelper
    {

        //Database name
        public static string DbName = "emarket.sqlite";

        //Full Database Path
        public static string DbPath = Path.Combine(ApplicationData.Current.LocalFolder.Path, DbName);

        public async static Task<bool> Createdatabase()
        {
            var result = await Checkdatabase();
            if (!result)
            {
                //Creating a database
                var connection = new SQLite.SQLiteConnection(DbPath);
                {
                    //Creating a table
                    connection.RunInTransaction(() =>
                    {
                        connection.CreateTable<Model.Product>();
                        connection.CreateTable<Model.Provider>();
                        connection.CreateTable<Model.ShoppingCart>();

                    });
                }

                connection.Close();
                return true;
            }
            else
                return false;
        }

        public static async Task<bool> Checkdatabase()
        {
            var dbexist = true;
            try
            {
                var storageFile = await ApplicationData.Current.LocalFolder.GetFileAsync(DbName);
                if (storageFile == null) dbexist = false;
            }
            catch (Exception ex)
            {
                dbexist = false;
            }
            return dbexist;
        }


        public static async Task<bool> DeleteDatabase()
        {
            try
            {
                var storageFile = await StorageFile.GetFileFromPathAsync(DbPath);
                await storageFile.DeleteAsync(StorageDeleteOption.PermanentDelete);
                return true;
            }
            catch (Exception ex)
            {
            }
            return false;
        }

    }
}
