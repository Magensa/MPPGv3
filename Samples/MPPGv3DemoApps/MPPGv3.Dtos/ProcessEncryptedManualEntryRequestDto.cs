namespace MPPGv3.Dtos
{
    public class ProcessEncryptedManualEntryRequestDto
    {
        public string CustomerCode { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string CustomerTransactionID { get; set; }
        public string EncryptedData { get; set; }
        public string KSN { get; set; }
        public string KeyVariant { get; set; }
        public int NumberOfPaddedBytes { get; set; }
        public decimal? Amount { get; set; }
        public string ProcessorName { get; set; }
        public string ExpirationDate { get; set; }
        public string TransactionType { get; set; }
    }
}
