using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CdisMartDAL;
using System.Transactions;

namespace CdisMartBLL
{
    public class Subasta_Registro_BLL
    {
        public List<object> cargarSubastaRegistroId(int Auctionid)
        {
            Subasta_Registro_DAL registro = new Subasta_Registro_DAL();
            return registro.cargarSubastaRegistroId(Auctionid);
        }

        public void agregarPuja(AuctionRecord record, int auctionID)
        {
            Subasta_Registro_DAL registro = new Subasta_Registro_DAL();
            Subasta_BLL subasta = new Subasta_BLL();
            object itemSubasta = new object();

            itemSubasta = subasta.cargarSubastaId(auctionID);
            var EndDate = Convert.ToDateTime(itemSubasta.GetType().GetProperty("EndDate").GetValue(itemSubasta, null)).ToString();

            if (DateTime.Compare(Convert.ToDateTime(EndDate), record.BidDate) >= 0)
            {
                if (record.Amount > 0 && record.Amount < 1000000)
                {
                    if (record.UserId != int.Parse((itemSubasta.GetType().GetProperty("UserId").GetValue(itemSubasta, null)).ToString()))
                    {
                        if (itemSubasta.GetType().GetProperty("HighestBid").GetValue(itemSubasta, null) is null)
                        {
                            using (TransactionScope ts = new TransactionScope())
                            {
                                registro.agregarPuja(record);
                                subasta.actualizarSubasta(record.Amount, record.UserId, auctionID);
                                ts.Complete();
                            }
                        }
                        else
                        {
                            if (record.Amount > Convert.ToDecimal((itemSubasta.GetType().GetProperty("HighestBid").GetValue(itemSubasta, null)).ToString()))
                            {
                                using (TransactionScope ts = new TransactionScope())
                                {
                                    registro.agregarPuja(record);
                                    subasta.actualizarSubasta(record.Amount, record.UserId, auctionID);
                                    ts.Complete();
                                }
                            }
                            else
                            {
                                throw new Exception("La oferta debe ser mayor que la oferta actual");
                            }
                        }
                    }
                    else
                    {
                        throw new Exception("No se le permite ofertar en esta subasta");
                    }
                }
                else
                {
                    throw new Exception("La cantidad ingresada debe ser un numero decimal mayor a 0 y menor que 1, 000, 000");
                }
            }
            else
            {
                throw new Exception("La subasta ha finalizado");
            }
        }
    }
}
