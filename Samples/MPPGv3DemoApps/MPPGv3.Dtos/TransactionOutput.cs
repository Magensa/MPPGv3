namespace MPPGv3.Dtos
{
    public class TransactionOutput
    {
        public string AuthCode { get; set; }
        public string AVSResult { get; set; }
        public decimal? AuthorizedAmount { get; set; }
        public string CVVResult { get; set; }
        public bool? IsTransactionApproved { get; set; }
        public string IssuerAuthenticationData { get; set; }
        public string IssuerScriptTemplate1 { get; set; }
        public string IssuerScriptTemplate2 { get; set; }
        public string Token { get; set; }
        public string TransactionID { get; set; }
        public string TransactionMessage { get; set; }
        public TransactionOutputDetails TransactionOutputDetails { get; set; }
        public string TransactionStatus { get; set; }
    }

}
