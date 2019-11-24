using CerveceriaManeadero.API.Models;
using MySql.Data.MySqlClient;

namespace CerveceriaManeadero.API.Services
{
    public class UserService
    {
        const string ID_COLUMN = "idUser";
        const string NAME_COLUMN = "Name";
        const string LASTNAME_COLUMN = "Lastname";
        const string USERNAME_COLUMN = "Username";
        const string PASSWORD_COLUMN = "Password";

        private MySqlConnection connection;

        public MySqlConnection OpenConnection()
        {
            connection = new MySqlConnection("server=127.0.0.1; uid=root; pwd=123456; database=brewery");
            connection.Open();

            return connection;
        }

        public void CloseConnection()
        {
            if (!(connection.State == System.Data.ConnectionState.Open))
            {
                return;
            }
            connection.Close();
        }

        public User Login(string username, string password)
        {
            MySqlDataReader reader;
            User user = null;

            try
            {
                string sqlCommand = $"SELECT * FROM user where Username = '{username}' and Password = '{password}'";
                MySqlConnection conn = OpenConnection();
                MySqlCommand cmd = new MySqlCommand(sqlCommand, conn);

                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        user = new User
                        {
                            Id = reader.GetInt32(ID_COLUMN),
                            FirstName = reader.GetString(NAME_COLUMN),
                            LastName = reader.GetString(LASTNAME_COLUMN),
                            Username = reader.GetString(USERNAME_COLUMN),
                            Password = reader.GetString(PASSWORD_COLUMN)
                        };
                    }
                }

                return user;
            }
            catch (System.Exception)
            {
                user = null;
                throw;
            }
        }

    }

    /*public void AddUser()
    {
        Usuario usuario = new Usuario("Hector", "Hernandez");
        bool result = usuarioDAO.InsertUsuario(usuario);
        Console.WriteLine(result);
    }
    public bool AddUsuario(Usuario usuario)
    {
        return usuarioDAO.InsertUsuario(usuairo);
    }
    public bool UpdateUsuario(Usuario usuario)
    {
        return usuarioDAO.UpdateUsuario(usuario);
    }
    public List<Usuario> GetUsuarios()
    {
        return usuarioDAO.GetUsuario();
    }

    public bool DeleteUsuario(Usuario usuario)
    {
        return usuarioDAO.DeleteUsuario(usuario);
    }*/
}
