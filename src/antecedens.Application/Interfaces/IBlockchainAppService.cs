
using antecedens.Domain.Entities;

namespace antecedens.Application.Interfaces
{
    public interface IBlockchainAppService : IAppServiceBase<Block>
    {
        Block GetBlockByHash(string hash);

        new void Add(Block block);

        bool IsValidHashDifficulty(string hash, int difficulty);

        string GenerateHash(Block block); 
    }
}
