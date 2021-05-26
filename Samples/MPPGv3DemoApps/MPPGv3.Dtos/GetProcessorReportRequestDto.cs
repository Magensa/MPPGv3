namespace MPPGv3.Dtos
{
    public class GetProcessorReportRequestDto
    {
        public string CustomerCode { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public string CustomerTransactionID { get; set; }
        public decimal? Amount { get; set; }
        public string ProcessorName { get; set; }
        public string TransactionID { get; set; }
        public string TransactionType { get; set; }

    }
}
