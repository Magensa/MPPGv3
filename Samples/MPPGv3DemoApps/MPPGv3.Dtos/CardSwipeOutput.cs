using System;
using System.Collections.Generic;

namespace MPPGv3.Dtos
{
    public class CardSwipeOutput
    {
        public KeyValuePair<string, string>[] AdditionalOutputData { get; set; }
        public string CardID { get; set; }
        public Nullable<bool> IsReplay { get; set; }
        public Nullable<decimal> MagnePrintScore { get; set; }
    }
}