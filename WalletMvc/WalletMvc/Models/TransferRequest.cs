namespace WalletMvc.Models
{
    public class TransferRequest
    {
        public string FromWalletId { get; set; }
        public string ToWalletId { get; set; }
        public decimal Amount { get; set; }
    }
}
