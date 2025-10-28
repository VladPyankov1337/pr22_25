using MySql.Data.MySqlClient;
using Shop.Data.Common;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Data.DataBase
{
    public class DBItems : IItems
    {
        public IEnumerable<Categorys> Categorys = new DBCategory().AllCategorys;
        public IEnumerable<Items> AllItems
        {
            get
            {
                List<Items> items = new List<Items>();
                MySqlConnection MySqlConnection = Connection.OpenConnection();
                MySqlDataReader ItemsData = Connection.Query("SELECT * FROM Shop.items ORDER BY `Name`;", MySqlConnection);
                while (ItemsData.Read())
                {
                    items.Add(new Items()
                    {
                        Id = ItemsData.IsDBNull(0) ? -1 : ItemsData.GetInt32(0),
                        Name = ItemsData.IsDBNull(1) ? "" : ItemsData.GetString(1),
                        Description = ItemsData.IsDBNull(2) ? "" : ItemsData.GetString(2),
                        Image = ItemsData.IsDBNull(3) ? "" : ItemsData.GetString(3),
                        Price = ItemsData.IsDBNull(4) ? -1 : ItemsData.GetInt32(4),
                        Category = ItemsData.IsDBNull(5) ? null : Categorys.Where(x => x.Id == ItemsData.GetInt32(5)).First()
                    });
                }
                MySqlConnection.Close();
                return items;
            }
        }
        public int Add(Items Item)
        {
            MySqlConnection MySqlConnection = Connection.OpenConnection();
            Connection.Query(
                $"INSERT INTO `items` (`Name`,`Description`,`Img`,`Price`,`IdCategorys`) VALUES ('{Item.Name}', '{Item.Description}', '{Item.Image}', {Item.Price},{Item.Category.Id});",
                MySqlConnection);
            MySqlConnection.Close();

            int IdItem = -1;
            MySqlConnection = Connection.OpenConnection();
            MySqlDataReader dataReaderItem = Connection.Query(
                $"SELECT `Id` FROM `items` WHERE `Name` = '{Item.Name}' AND `Description` = '{Item.Description}' AND `Price` = '{Item.Price}' AND `IdCategorys` = '{Item.Category.Id}' ;",
                MySqlConnection);
            if (dataReaderItem.HasRows)
            {
                dataReaderItem.Read();
                IdItem = dataReaderItem.GetInt32(0);
            }
            MySqlConnection.Close();
            return IdItem;
        }
        public bool Update(Items Item)
        {
            MySqlConnection MySqlConnection = Connection.OpenConnection();
            Connection.Query(
                $"UPDATE `items` SET `Name`='{Item.Name}', `Description`='{Item.Description}', " +
                $"`Img`='{Item.Image}', `Price`={Item.Price}, `IdCategorys`={Item.Category.Id} " +
                $"WHERE `Id`={Item.Id};",
                MySqlConnection);
            MySqlConnection.Close();
            return true;
        }

        public bool Delete(int id)
        {
            MySqlConnection MySqlConnection = Connection.OpenConnection();
            Connection.Query(
                $"DELETE FROM `items` WHERE `Id`={id};",
                MySqlConnection);
            MySqlConnection.Close();
            return true;
        }

        public Items GetItemById(int id)
        {
            MySqlConnection MySqlConnection = Connection.OpenConnection();
            MySqlDataReader dataReader = Connection.Query(
                $"SELECT * FROM `items` WHERE `Id`={id};",
                MySqlConnection);

            Items item = null;
            if (dataReader.HasRows)
            {
                dataReader.Read();
                item = new Items()
                {
                    Id = dataReader.IsDBNull(0) ? -1 : dataReader.GetInt32(0),
                    Name = dataReader.IsDBNull(1) ? "" : dataReader.GetString(1),
                    Description = dataReader.IsDBNull(2) ? "" : dataReader.GetString(2),
                    Image = dataReader.IsDBNull(3) ? "" : dataReader.GetString(3),
                    Price = dataReader.IsDBNull(4) ? -1 : dataReader.GetInt32(4),
                    Category = dataReader.IsDBNull(5) ? null : Categorys.Where(x => x.Id == dataReader.GetInt32(5)).First()
                };
            }
            MySqlConnection.Close();
            return item;
        }
    }
}
