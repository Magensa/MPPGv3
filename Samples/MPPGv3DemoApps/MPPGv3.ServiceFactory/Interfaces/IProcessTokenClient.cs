using MPPGv3.Dtos;

namespace MPPGv3.ServiceFactory
{
    public interface IProcessTokenClient
    {
        (ProcessTokenResponseDto Response, RawSoapDetails SoapDetails) ProcessToken(ProcessTokenRequestDto processTokenRequestDto);
    }
}
