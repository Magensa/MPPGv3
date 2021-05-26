namespace MPPGv3.Dtos
{
    public class ProcessEMVSREDRequestDto
    {
        public string CustomerCode { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string CustomerTransactionID { get; set; }
        public string EMVSREDData { get; set; }
        public string EncryptionType { get; set; }
        public string KSN { get; set; }
        public int NumberOfPaddedBytes { get; set; }
        public string PaymentMode { get; set; }
        public decimal? Amount { get; set; }
        public string ProcessorName { get; set; }
        public string TransactionType { get; set; }
        public string PayloadResponseFieldsToMask { get; set; }
        public string NonremovableTags { get; set; }
    }
}
