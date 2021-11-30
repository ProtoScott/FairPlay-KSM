using System.Threading.Tasks;

namespace Protostream.FairPlay.Interfaces
{
    public interface IContentKeyLocator
    {
        Task<IContentKey> FetchContentKey(byte[] contentId, object info);
    }
}