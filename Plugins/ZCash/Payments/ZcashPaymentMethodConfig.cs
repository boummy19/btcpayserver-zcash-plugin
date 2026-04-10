using BTCPayServer.Payments;
using Newtonsoft.Json;

namespace BTCPayServer.Plugins.ZCash.Payments
{
    public class ZcashPaymentMethodConfig
    {
        public long AccountIndex { get; set; }
        public long? InvoiceSettledConfirmationThreshold { get; set; }

        // Store ID this config belongs to - enables per-store isolation
        public string StoreId { get; set; }
    }
}