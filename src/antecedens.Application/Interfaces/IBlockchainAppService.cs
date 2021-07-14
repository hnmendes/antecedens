using antecedens.Domain.Entities;

namespace antecedens.Application.Interfaces
{
    public interface IBlockchainAppService : IAppServiceBase<Block>
    {
        Block GetBlockByHash(string hash);

        void Add(Chain chain);
    }
}
