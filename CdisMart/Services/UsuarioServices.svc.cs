using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using CdisMartDAL;
using Newtonsoft.Json;

namespace CdisMart.Services
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class UsuarioServices
    {
        CdisMartEntities modelo;

        public UsuarioServices()
        {
            modelo = new CdisMartEntities();
        }

        [OperationContract]
        public string consultaNombreUsuario(string name)
        {
            try
            {
                var usuario = (from mUsuario in modelo.User
                               where mUsuario.UserName == name
                               select mUsuario).FirstOrDefault();
                string JSONString = string.Empty;
                JSONString = JsonConvert.SerializeObject(usuario);
                return JSONString;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                return null;
            }
            
        }
    }
}
