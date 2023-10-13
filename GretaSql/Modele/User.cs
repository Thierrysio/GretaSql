using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GretaSql.Modele
{

public class User
    {
        #region Attributs

        public static List<User> CollClasse = new List<User>();

        private int _id;
        private string _nom;
        private string _email;

        #endregion

        #region Constructeurs

        public User(int id, string nom, string email)
        {
            _id = id;
            _nom = nom;
            _email = email;

            User.CollClasse.Add(this);
        }

        #endregion

        #region Getters/Setters

        public int Id { get => _id; set => _id = value; }
        public string Nom { get => _nom; set => _nom = value; }
        public string Email { get => _email; set => _email = value; }

        #endregion

        #region Methodes

        // Vous pouvez ajouter des méthodes spécifiques à la classe ici.

        #endregion
    }

}

