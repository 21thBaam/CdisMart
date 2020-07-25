using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CdisMartDAL;

namespace CdisMartBLL
{
    public class Usuario_BLL
    {
        public User consultarUsuario(string username, string password)
        {
            Usuario_DAL usuario = new Usuario_DAL();
            return usuario.consultarUsuario(username, password);
        }

        public void altaUsuario(User paramUsuario)
        {
            Usuario_DAL usuario = new Usuario_DAL();
            usuario.altaUsuario(paramUsuario);
        }
    }
}
