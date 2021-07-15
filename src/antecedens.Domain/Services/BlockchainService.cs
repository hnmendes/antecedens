using antecedens.Domain.Entities;
using antecedens.Domain.Interfaces.Repositories;
using antecedens.Domain.Interfaces.Services;

namespace antecedens.Domain.Services
{
    public class BlockchainService : ServiceBase<Block>, IBlockchainService
    {
        private readonly IBlockchainRepository _repository;

        public BlockchainService(IBlockchainRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public Block GetBlockByHash(string hash)
        {
            return _repository.GetBlockByHash(hash);
        }

        public Block GetBlockByTimeStamp(string timeStamp)
        {
            return _repository.GetBlockByTimeStamp(timeStamp);
        }

        public Block GetLastBlock()
        {
            return _repository.GetLastBlock();
        }
    }
}
