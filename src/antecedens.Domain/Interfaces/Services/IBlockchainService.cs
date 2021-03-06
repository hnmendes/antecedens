using antecedens.Domain.Entities;

namespace antecedens.Domain.Interfaces.Services
{
    public interface IBlockchainService : IServiceBase<Block>
    {
        Block GetBlockByHash(string hash);

        Block GetLastBlock();

        Block GetBlockByTimeStamp(string timeStamp);
    }
}
