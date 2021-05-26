using System.Collections.Generic;

namespace MPPGv3.Dtos
{
    public class ProcessKeyPadEntryRequestDto
    {
        public List<KeyValuePair<string, string>> AdditionalRequestData { get; set; }
        public string CustomerCode { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public string CustomerTransactionID { get; set; }
        public string CVV { get; set; }
        public string ZIP { get; set; }
        public string DeviceSN { get; set; }
        public string KSN { get; set; }
        public string MagnePrint { get; set; }
        public string MagnePrintStatus { get; set; }
        public string Track1 { get; set; }
        public string Track2 { get; set; }
        public string Track3 { get; set; }
        public decimal? Amount { get; set; }
        public string TransactionType { get; set; }
        public string ProcessorName { get; set; }
        public List<KeyValuePair<string, string>> TransactionInputDetails { get; set; }

    }
}
