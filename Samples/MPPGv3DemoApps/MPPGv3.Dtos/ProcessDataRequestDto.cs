using System.Collections.Generic;

namespace MPPGv3.Dtos
{
    public class ProcessDataRequestDto
    {
        public List<KeyValuePair<string, string>> AdditionalRequestData { get; set; }
        public string CustomerCode { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public string CustomerTransactionID { get; set; }
        public string Data { get; set; }
        public string DataFormatType { get; set; }
        public string EncryptionType { get; set; }
        public string KSN { get; set; }
        public int NumberOfPaddedBytes { get; set; }
        public string IsEncrypted { get; set; }
        public string PaymentMode { get; set; }
        public decimal? Amount { get; set; }
        public string ProcessorName { get; set; }
        public string TransactionType { get; set; }
        public List<KeyValuePair<string, string>> TransactionInputDetails { get; set; }

    }
}
