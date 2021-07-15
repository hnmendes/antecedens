using System.Linq;
using antecedens.Application.Interfaces;
using antecedens.Domain.Entities;
using antecedens.Domain.Interfaces.Services;
using antecedens.Application.ExtensionMethods;
using antecedens.Infra.CrossCutting;
using System;

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

        public void Add(Chain chain)
        {
            var blocks = _blockchainService.GetAll();
            var block = new Block();

            block.AssociatedChain = chain;
            block.Difficulty = 1;
            block.TimeStamp = DateTime.Now.ToString("ddMMyyyyHHmmssffff");

            if (blocks.Count() == 0)
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

        private Block GetLastBlock()
        {
            return _blockchainService.GetLastBlock();
        }

        private bool IsValidHashDifficulty(string hash, int difficulty)
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

        private string GenerateHash(Block block)
        {
            var blocks = _blockchainService.GetAll();           

            int nonce = 0;
            
            string hash = string.Empty;            
            
            block.Nonce = nonce;

            hash = block.TimeStamp.Sha256Hash();
            
            while(!IsValidHashDifficulty(hash, block.Difficulty))
            {
                if (!IsNonceExisting(nonce))
                {
                    nonce++;
                    block.Nonce = nonce;
                    hash = block.TimeStamp.Sha256Hash();
                }
                else
                {
                    nonce++;
                    block.Nonce = nonce;
                    hash = block.TimeStamp.Sha256Hash();
                    continue;                    
                }
            }

            return hash;
        }

        private bool IsNonceExisting(int nonce)
        {
            var blocks = _blockchainService.GetAll();

            return blocks.Any(b => b.Nonce == nonce);
        }

        public void CreatePdfFile(Block block)
        {
            PdfGenerationHelper.GenerateToDirectory(block);
        }

        public Block GetBlockByTimeStamp(string timeStamp)
        {
            return _blockchainService.GetBlockByTimeStamp(timeStamp);
        }
    }
}
