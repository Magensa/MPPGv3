using MPPGv3.Dtos;

namespace MPPGv3.ServiceFactory
{
    public interface IProcessKeyPadEntryClient
    {
        (ProcessKeyPadEntryResponseDto Response, RawSoapDetails SoapDetails) ProcessKeyPadEntry(ProcessKeyPadEntryRequestDto processKeyPadEntryRequestDto);
    }
}
