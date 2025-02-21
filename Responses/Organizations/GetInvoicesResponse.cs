using System;
using System.Collections.Generic;

namespace TursoPlatformApi.Responses.Organizations
{
    public class GetInvoicesResponse
    {
        public List<Invoice> invoices { get; set; }
    }

    public class Invoice
    {
        /// <summary>
        /// The unique ID for the invoice.
        /// </summary>
        public string invoice_number { get; set; }

        /// <summary>
        /// The formatted price in USD for the invoice.
        /// </summary>
        public string amount_due { get; set; }

        /// <summary>
        /// The due date for the invoice.
        /// </summary>
        public DateTime due_date { get; set; }

        /// <summary>
        /// The date the invoice was paid.
        /// </summary>
        public DateTime paid_at { get; set; }

        /// <summary>
        /// The date the invoice payment last failed.
        /// </summary>
        public DateTime payment_failed_at { get; set; }

        /// <summary>
        /// The link to the invoice PDF you can download.
        /// </summary>
        public string invoice_pdf { get; set; }
    }

}
