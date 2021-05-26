using MPPGv3.Dtos;

namespace MPPGv3.ServiceFactory
{
    public interface IProcessReferenceIDClient
    {
        (ProcessReferenceIDResponseDto Response, RawSoapDetails SoapDetails) ProcessReferenceID(ProcessReferenceIDRequestDto processReferenceIDRequestDto);
    }
}
