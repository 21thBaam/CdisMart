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
    
    public partial class Auction
    {
        public Auction()
        {
            this.AuctionRecord = new HashSet<AuctionRecord>();
        }
    
        public int AuctionId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public Nullable<decimal> HighestBid { get; set; }
        public Nullable<int> Winner { get; set; }
        public int UserId { get; set; }
    
        public virtual User User { get; set; }
        public virtual ICollection<AuctionRecord> AuctionRecord { get; set; }
    }
}
