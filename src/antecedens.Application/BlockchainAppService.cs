using System.Linq;
using antecedens.Application.Interfaces;
using antecedens.Domain.Entities;
using antecedens.Domain.Interfaces.Services;
using antecedens.Application.ExtensionMethods;

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

        public new void Add(Block block)
        {
            if(_blockchainService.GetAll().Count() == 0)
            {
                block.Hash = GenerateHash(block);
            }
            else
            {
                var lastBlock = GetLastBlock();
                block.LastHash = lastBlock.Hash;
                block.Hash = GenerateHash(block);
            }

            _blockchainService.Add(block);
            _blockchainService.Dispose();
        }

        public Block GetLastBlock()
        {
            return _blockchainService.GetLastBlock();
        }

        public bool IsValidHashDifficulty(string hash, int difficulty)
        {
            int count = 0;

            for(int i = 0; i < hash.Length; i++)
            {
                count++;
                
                if(hash[i] != '0')
                {
                    break;
                }
            }

            return (count > difficulty);
        }

        public string GenerateHash(Block block)
        {
            int nonce = 0;
            
            string hash = string.Empty;            
            
            block.Nonce = nonce;

            hash = block.TimeStamp.Sha256Hash();
            
            while(!IsValidHashDifficulty(hash, block.Difficulty))
            {
                nonce++;
                block.Nonce = nonce;
                hash = block.TimeStamp.Sha256Hash();
            }

            return hash;
        }
    }
}
