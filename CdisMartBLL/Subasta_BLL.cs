using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CdisMartDAL;

namespace CdisMartBLL
{
    public class Subasta_BLL
    {
        public List<Auction> cargarSubasta()
        {
            Subasta_DAL subastas = new Subasta_DAL();
            return subastas.cargarSubasta();
        }

        public object cargarSubastaId(int id)
        {
            Subasta_DAL subastas = new Subasta_DAL();
            return subastas.cargarSubastaId(id);
        }

        public void altaSubasta(Auction subasta)
        {
            Subasta_DAL subastas = new Subasta_DAL();

            CdisMartEntities modelo = new CdisMartEntities();
            var subastasModelo = from tSubasta in modelo.Auction
                                 where tSubasta.UserId == subasta.UserId
                                 select tSubasta;

            if (subastasModelo.Count() <= 2)
            {
                var dateAndTime = DateTime.Now;
                if (DateTime.Compare(dateAndTime.Date, subasta.StartDate) <= 0)
                {
                   subastas.altaSubasta(subasta);
                }
                else
                {
                    throw new Exception("La fecha de inicio debe ser igual o mayor a la actual. " + dateAndTime.Date);
                }
            }
            else
            {
                throw new Exception("El usuario solo puede tener hasta un total de 3 subastas activas.");
            }

            
        }

        public void actualizarSubasta(Decimal HighBid, int UserId, int AuctionID)
        {
            Subasta_DAL subastas = new Subasta_DAL();
            subastas.actualizarSubasta(HighBid,UserId,AuctionID);
        }
    }
}
