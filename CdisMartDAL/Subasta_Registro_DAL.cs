using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CdisMartDAL
{
    public class Subasta_Registro_DAL
    {
        CdisMartEntities modelo;

        public Subasta_Registro_DAL()
        {
            modelo = new CdisMartEntities();
        }

        public List<object> cargarSubastaRegistroId(int Auctionid)
        {
            var temporal = (from mSubasta in modelo.AuctionRecord
                            where mSubasta.AuctionId == Auctionid
                            select new
                            {
                                UserId = mSubasta.User.UserName,
                                Amount = mSubasta.Amount,
                                BidDate = mSubasta.BidDate
                            });
            return temporal.AsEnumerable<object>().ToList();
        }

        public void agregarPuja(AuctionRecord record)
        {
            modelo.AuctionRecord.Add(record);
            modelo.SaveChanges();
        }
    }
}
