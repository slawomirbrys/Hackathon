using figo;

namespace Hackathon.FigoApi.Interfaces
{
    public interface IFigoSessionProvider
    {
        FigoSession GetFigoSession();
    }
}
