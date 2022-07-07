using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts.ContractHandlers;
using Nethereum.Contracts;
using System.Threading;
using ExampleBaal.Contracts.ShamanMinter.ContractDefinition;

namespace ExampleBaal.Contracts.ShamanMinter
{
    public partial class ShamanMinterService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, ShamanMinterDeployment shamanMinterDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<ShamanMinterDeployment>().SendRequestAndWaitForReceiptAsync(shamanMinterDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, ShamanMinterDeployment shamanMinterDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<ShamanMinterDeployment>().SendRequestAsync(shamanMinterDeployment);
        }

        public static async Task<ShamanMinterService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, ShamanMinterDeployment shamanMinterDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, shamanMinterDeployment, cancellationTokenSource);
            return new ShamanMinterService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public ShamanMinterService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> BaalQueryAsync(BaalFunction baalFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<BaalFunction, string>(baalFunction, blockParameter);
        }

        
        public Task<string> BaalQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<BaalFunction, string>(null, blockParameter);
        }

        public Task<string> DoublerRequestAsync(DoublerFunction doublerFunction)
        {
             return ContractHandler.SendRequestAsync(doublerFunction);
        }

        public Task<TransactionReceipt> DoublerRequestAndWaitForReceiptAsync(DoublerFunction doublerFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(doublerFunction, cancellationToken);
        }

        public Task<string> DoublerRequestAsync(List<string> members)
        {
            var doublerFunction = new DoublerFunction();
                doublerFunction.Members = members;
            
             return ContractHandler.SendRequestAsync(doublerFunction);
        }

        public Task<TransactionReceipt> DoublerRequestAndWaitForReceiptAsync(List<string> members, CancellationTokenSource cancellationToken = null)
        {
            var doublerFunction = new DoublerFunction();
                doublerFunction.Members = members;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(doublerFunction, cancellationToken);
        }

        public Task<string> InitRequestAsync(InitFunction initFunction)
        {
             return ContractHandler.SendRequestAsync(initFunction);
        }

        public Task<TransactionReceipt> InitRequestAndWaitForReceiptAsync(InitFunction initFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(initFunction, cancellationToken);
        }

        public Task<string> InitRequestAsync(string baal)
        {
            var initFunction = new InitFunction();
                initFunction.Baal = baal;
            
             return ContractHandler.SendRequestAsync(initFunction);
        }

        public Task<TransactionReceipt> InitRequestAndWaitForReceiptAsync(string baal, CancellationTokenSource cancellationToken = null)
        {
            var initFunction = new InitFunction();
                initFunction.Baal = baal;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(initFunction, cancellationToken);
        }

        public Task<string> SharesTokenQueryAsync(SharesTokenFunction sharesTokenFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SharesTokenFunction, string>(sharesTokenFunction, blockParameter);
        }

        
        public Task<string> SharesTokenQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SharesTokenFunction, string>(null, blockParameter);
        }
    }
}
