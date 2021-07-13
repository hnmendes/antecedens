using antecedens.Application.Interfaces;
using antecedens.Domain.Entities;
using antecedens.Domain.Interfaces.Services;

namespace antecedens.Application
{
    public class BlockchainAppService : AppServiceBase<Block>, IBlockchainAppService
    {

        private readonly IBlockchainService _blockchainService;

        public BlockchainAppService(IBlockchainService blockchainService) : base(blockchainService)
        {
            _blockchainService = blockchainService;
        }

        public Block GetBlockByHash(string hash)
        {
            return _blockchainService.GetBlockByHash(hash);
        }
    }
}
