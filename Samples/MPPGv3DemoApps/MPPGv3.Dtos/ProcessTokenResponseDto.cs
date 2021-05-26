using System.Text.Json;

namespace MPPGv3.Dtos
{

    public class ProcessTokenResponseDto
    {
        public string CustomerTransactionID { get; set; }
        public string MagTranID { get; set; }
        public TransactionOutput TransactionOutput { get; set; }
        public TransactionOutputDetails TransactionOutputDetails { get; set; }
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
