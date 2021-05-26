namespace MPPGv3.Dtos
{
    public class EMVSREDOutput
    {
        public System.Collections.Generic.KeyValuePair<string, string>[] AdditionalOutputData { get; set; }

        public string CardID { get; set; }

        public System.Nullable<bool> IsReplay { get; set; }
    }
}
