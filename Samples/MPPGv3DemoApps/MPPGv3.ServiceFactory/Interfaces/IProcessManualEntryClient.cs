using MPPGv3.Dtos;

namespace MPPGv3.ServiceFactory
{
    public interface IProcessManualEntryClient
    {
        (ProcessManualEntryResponseDto Response, RawSoapDetails SoapDetails) ProcessManualEntry(ProcessManualEntryRequestDto processManualEntryRequestDto);
    }
}
