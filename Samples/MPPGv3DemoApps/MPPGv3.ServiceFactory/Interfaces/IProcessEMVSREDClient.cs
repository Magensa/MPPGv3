using MPPGv3.Dtos;

namespace MPPGv3.ServiceFactory
{
    public interface IProcessEMVSREDClient
    {
        (ProcessEMVSREDResponseDto Response, RawSoapDetails SoapDetails) ProcessEMVSRED(ProcessEMVSREDRequestDto ProcessEMVSREDRequestDto);
    }
}
