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
using ExampleBaal.Contracts.RageQuitBank.ContractDefinition;

namespace ExampleBaal.Contracts.RageQuitBank
{
    public partial class RageQuitBankService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, RageQuitBankDeployment rageQuitBankDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<RageQuitBankDeployment>().SendRequestAndWaitForReceiptAsync(rageQuitBankDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, RageQuitBankDeployment rageQuitBankDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<RageQuitBankDeployment>().SendRequestAsync(rageQuitBankDeployment);
        }

        public static async Task<RageQuitBankService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, RageQuitBankDeployment rageQuitBankDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, rageQuitBankDeployment, cancellationTokenSource);
            return new RageQuitBankService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public RageQuitBankService(Nethereum.Web3.Web3 web3, string contractAddress)
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

        public Task<string> MemberActionRequestAsync(MemberActionFunction memberActionFunction)
        {
             return ContractHandler.SendRequestAsync(memberActionFunction);
        }

        public Task<TransactionReceipt> MemberActionRequestAndWaitForReceiptAsync(MemberActionFunction memberActionFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(memberActionFunction, cancellationToken);
        }

        public Task<string> MemberActionRequestAsync(string returnValue1, BigInteger loot, BigInteger shares)
        {
            var memberActionFunction = new MemberActionFunction();
                memberActionFunction.ReturnValue1 = returnValue1;
                memberActionFunction.Loot = loot;
                memberActionFunction.Shares = shares;
            
             return ContractHandler.SendRequestAsync(memberActionFunction);
        }

        public Task<TransactionReceipt> MemberActionRequestAndWaitForReceiptAsync(string returnValue1, BigInteger loot, BigInteger shares, CancellationTokenSource cancellationToken = null)
        {
            var memberActionFunction = new MemberActionFunction();
                memberActionFunction.ReturnValue1 = returnValue1;
                memberActionFunction.Loot = loot;
                memberActionFunction.Shares = shares;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(memberActionFunction, cancellationToken);
        }
    }
}
