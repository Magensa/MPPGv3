using System.Text.Json;

namespace MPPGv3.Dtos
{
    public class ProcessDataResponseDto
    {
        public string RequestXml { get; set; }
        public string ResponseXml { get; set; }
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
