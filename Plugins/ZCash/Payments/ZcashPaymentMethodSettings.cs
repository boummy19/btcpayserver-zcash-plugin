namespace BTCPayServer.Plugins.ZCash.Payments
{
    public class ZcashPaymentMethodSettings
    {
        public long AccountIndex { get; set; } = 0;
        public long? InvoiceSettledConfirmationThreshold { get; set; }
        public bool Enabled { get; set; } = false;
    }
}