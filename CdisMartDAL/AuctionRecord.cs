//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CdisMartDAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class AuctionRecord
    {
        public int RecordId { get; set; }
        public int AuctionId { get; set; }
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public System.DateTime BidDate { get; set; }
    
        public virtual Auction Auction { get; set; }
        public virtual User User { get; set; }
    }
}
