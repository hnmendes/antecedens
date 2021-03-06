using antecedens.Domain.Entities;

namespace antecedens.Domain.Interfaces.Repositories
{
    public interface IBlockchainRepository : IRepositoryBase<Block>
    {
        Block GetBlockByHash(string hash);

        Block GetLastBlock();

        Block GetBlockByTimeStamp(string timeStamp);
    }
}
