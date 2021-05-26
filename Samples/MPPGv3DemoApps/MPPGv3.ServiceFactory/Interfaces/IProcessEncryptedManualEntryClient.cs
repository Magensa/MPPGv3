using MPPGv3.Dtos;

namespace MPPGv3.ServiceFactory
{
    public interface IProcessEncryptedManualEntryClient
    {
        (ProcessEncryptedManualEntryResponseDto Response, RawSoapDetails SoapDetails) ProcessEncryptedManualEntry(ProcessEncryptedManualEntryRequestDto ProcessEncryptedManualEntryRequestDto);
    }
}
