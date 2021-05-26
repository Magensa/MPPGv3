using System.Collections.Generic;

namespace MPPGv3.Dtos
{
    public class ProcessTokenRequestDto
    {
        public List<KeyValuePair<string, string>> AdditionalRequestData { get; set; }
        public string CustomerCode { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public string CustomerTransactionID { get; set; }
        public string Token { get; set; }
        public decimal? Amount { get; set; }
        public string TransactionType { get; set; }
        public string ProcessorName { get; set; }
        public List<KeyValuePair<string, string>> TransactionInputDetails { get; set; }
    }
}
