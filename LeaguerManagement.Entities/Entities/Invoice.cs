using System;
using System.Collections.Generic;

namespace LeaguerManagement.Entities.Entities
{
    public partial class Invoice
    {
        public Invoice()
        {
            FileDetail = new HashSet<FileDetail>();
        }

        public int Id { get; set; }
        public string InvoiceCode { get; set; }
        public int Fee { get; set; }
        public DateTime? PaidDate { get; set; }
        public string BankIdCode { get; set; }
        public string BankName { get; set; }
        public string DealNote { get; set; }
        public int? ChargeMethodId { get; set; }

        public virtual ChargeMethod ChargeMethod { get; set; }
        public virtual ICollection<FileDetail> FileDetail { get; set; }
    }
}
