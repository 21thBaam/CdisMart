using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CdisMartDAL
{
    public class Subasta_DAL
    {
        CdisMartEntities modelo;

        public Subasta_DAL()
        {
            modelo = new CdisMartEntities();
        }

        public List<Auction> cargarSubasta()
        {
            var subastas = from mSubasta in modelo.Auction
                           select mSubasta;

            return subastas.AsEnumerable<Auction>().ToList();
        }

        public object cargarSubastaId(int id)
        {
            var consulta = (from mSubasta in modelo.Auction
                           where mSubasta.AuctionId == id
                           select mSubasta).FirstOrDefault();

            if (consulta.Winner is null || consulta.HighestBid is null)
            {
                return consulta;
            }
            else
            {
                var subasta = (from mSubasta in modelo.Auction
                           join mUser in modelo.User on mSubasta.Winner equals mUser.UserId
                           where mSubasta.AuctionId == id
                           select new
                           {
                               AuctionId = mSubasta.AuctionId,
                               ProductName = mSubasta.ProductName,
                               Description = mSubasta.Description,
                               StartDate = mSubasta.StartDate,
                               EndDate = mSubasta.EndDate,
                               HighestBid = mSubasta.HighestBid,
                               Winner = mSubasta.Winner,
                               UserId = mSubasta.UserId,
                               WinnerName = mUser.UserName
                           }).FirstOrDefault();
                return subasta;
            }
        }

        public void altaSubasta(Auction subasta)
        {
            modelo.Auction.Add(subasta);
            modelo.SaveChanges();
        }

        public void actualizarSubasta(Decimal HighBid, int UserId, int AuctionID)
        {
            var subasta = (from mSubasta in modelo.Auction
                          where mSubasta.AuctionId == AuctionID
                          select mSubasta).FirstOrDefault(); ;
            subasta.HighestBid = HighBid;
            subasta.Winner = UserId;
            modelo.SaveChanges();
        }
    }
}
