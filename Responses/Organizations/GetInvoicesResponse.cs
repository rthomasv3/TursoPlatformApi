using System;
using System.Collections.Generic;

namespace TursoPlatformApi.Responses.Organizations
{
    internal class GetInvoicesResponse
    {
        public List<Invoice> Invoices { get; set; }
    }

    /// <summary>
    /// Invoice information.
    /// </summary>
    public class Invoice
    {
        /// <summary>
        /// The unique ID for the invoice.
        /// </summary>
        public string InvoiceNumber { get; set; }

        /// <summary>
        /// The formatted price in USD for the invoice.
        /// </summary>
        public string amountDue { get; set; }

        /// <summary>
        /// The due date for the invoice.
        /// </summary>
        public DateTime DueDate { get; set; }

        /// <summary>
        /// The date the invoice was paid.
        /// </summary>
        public DateTime PaidAt { get; set; }

        /// <summary>
        /// The date the invoice payment last failed.
        /// </summary>
        public DateTime PaymentFailedAt { get; set; }

        /// <summary>
        /// The link to the invoice PDF you can download.
        /// </summary>
        public string InvoicePdf { get; set; }
    }

}
