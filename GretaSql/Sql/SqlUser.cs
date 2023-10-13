using GretaSql.Modele;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GretaSql.Sql
{
    public  class SqlUser
    {

        public static void SelectUser()
        {
            string connectionString = "Server=localhost;UserId=root;Password=;Database=MaNouvelleBaseMySQL";

            List<string> usersJsonList = new List<string>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string selectQuery = @"SELECT JSON_OBJECT('Id', Id, 'Nom', Nom, 'Email', Email) 
                                   FROM User
                                   WHERE Nom = @Nom AND Email = @MotDePasse";  // Remarque : vous devriez comparer les hashes, pas les mots de passe en clair.

                using (MySqlCommand cmd = new MySqlCommand(selectQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@Nom", "Jean Dupont");
                    cmd.Parameters.AddWithValue("@MotDePasse", "monmotdepasse");

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string userJson = reader.GetString(0);  // considering the JSON is in the first column
                            usersJsonList.Add(userJson);
                        }
                    }
                }
            }

            if (usersJsonList.Count > 0)
            {
                foreach (var userJson in usersJsonList)
                {
                    Console.WriteLine($"JSON: {userJson}");

                    // Deserialize to a User object
                    User user = JsonConvert.DeserializeObject<User>(userJson);
                   //
                }
            }
            else
            {
                //
            }
        }
    }

}

