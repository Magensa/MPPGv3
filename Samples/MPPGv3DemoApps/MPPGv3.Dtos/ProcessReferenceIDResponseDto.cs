using System.Text.Json;

namespace MPPGv3.Dtos
{
    public class ProcessReferenceIDResponseDto
    {
        public string CustomerTransactionID { get; set; }
        public string MagTranID { get; set; }
        public TransactionOutput TransactionOutput { get; set; }
        public string TransactionUTCTimestamp { get; set; }
        public override string ToString()
        {
            var json = JsonSerializer.Serialize(this, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            return json;
        }
    }
}
