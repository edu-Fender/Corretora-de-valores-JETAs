using System.Linq;
using System.Configuration;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace Corretora
{
    static public class Connect
    {
        static public string name;
        static public string lastname;
        static public string email;
        static public string cel;
        static public string cpf;
        static public string login;
        static public string password;

        static public string[] userInfo;

        static public int Login(string login, string password)
        {           
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["string"].ConnectionString))
            {
                var user = connection.Query<User>("dbo.Login @login, @password", new { login = login, password = password }).ToList();

                if (user.Count > 0)
                {        
                    userInfo = new string[] { user[0].name, user[0].lastname, user[0].email, user[0].cel, user[0].cpf, user[0].login };
                    return 0;                     
                }
                else 
                {
                    return -1;
                }
            }
        }
        static public int Register(string name, string lastname, string email, string cel, string cpf, string login, string password)
        {
            using(var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["string"].ConnectionString))
            {
                var user = connection.Query<User>("dbo.register @name, @lastname, @email, @cel, @cpf, @login, @password", new { name = name, lastname = lastname, email = email, cel = cel, cpf = cpf, login = login, password = password }).ToList();
                
                if (user.Count > 0)
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
        }
        static public string ForgotMyPassword(string login, string sobrenome, string cpf)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["string"].ConnectionString))
            {
                var user = connection.Query<User>("dbo.ForgotMyPassword @login, @sobrenome, @cpf", new { login = login, sobrenome = sobrenome, cpf = cpf }).ToList();
                if (user.Count > 0)
                {
                    return user[0].password;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
