using MPPGv3.Dtos;

namespace MPPGv3.ServiceFactory
{
    public interface IGetProcessorReportClient
    {
        (GetProcessorReportResponseDto Response, RawSoapDetails SoapDetails) GetProcessorReport(GetProcessorReportRequestDto getProcessorReportRequestDto);
    }
}
