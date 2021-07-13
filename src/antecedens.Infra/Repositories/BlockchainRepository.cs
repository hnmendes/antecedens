using antecedens.Domain.Entities;
using antecedens.Domain.Interfaces.Repositories;
using System.Linq;

namespace antecedens.Infra.Repositories
{
    public class BlockchainRepository : RepositoryBase<Block>, IBlockchainRepository
    {
        public Block GetBlockByHash(string hash)
        {
            var block = GetAll().Where(b => b.Hash == hash);

            return block.FirstOrDefault();
        }
    }
}
