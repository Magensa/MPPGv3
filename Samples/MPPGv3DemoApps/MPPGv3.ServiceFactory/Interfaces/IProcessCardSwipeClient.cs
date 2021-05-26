using MPPGv3.Dtos;

namespace MPPGv3.ServiceFactory
{
    public interface IProcessCardSwipeClient
    {
        (ProcessCardSwipeResponseDto Response, RawSoapDetails SoapDetails) ProcessCardSwipe(ProcessCardSwipeRequestDto processCardSwipeRequestDto);
    }
}
