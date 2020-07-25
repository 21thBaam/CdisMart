using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CdisMartDAL
{
    public class Usuario_DAL
    {
        CdisMartEntities modelo;

        public Usuario_DAL()
        {
            modelo = new CdisMartEntities();
        }

        public User consultarUsuario(string username, string password)
        {
            var usuario = (from mUsuario in modelo.User
                          where mUsuario.UserName == username && mUsuario.Password == password
                          select mUsuario).FirstOrDefault();
            return usuario;
        }

        public void altaUsuario(User usuario)
        {
            modelo.User.Add(usuario);
            modelo.SaveChanges();
        }
    }
}
