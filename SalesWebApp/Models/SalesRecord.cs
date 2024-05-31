using System;
using System.ComponentModel.DataAnnotations;
using SalesWebApp.Models.Enums;

namespace SalesWebApp.Models
{
    public class SalesRecord
    {
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy}")]
        public DateTime Date { get; set; }

        
        public double Amount { get; set; }
        public SaleStatus Status { get; set; }
        public Seller Seller { get; set; }

        public SalesRecord() { }

        public SalesRecord(int id, DateTime date, double amount, SaleStatus status, Seller seller)
        {
            this.Id = id;
            this.Date = date;
            this.Amount = amount;
            this.Status = status;
            this.Seller = seller;
        }
    }
}
