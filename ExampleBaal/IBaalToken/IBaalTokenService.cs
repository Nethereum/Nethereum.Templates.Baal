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
using ExampleBaal.Contracts.IBaalToken.ContractDefinition;

namespace ExampleBaal.Contracts.IBaalToken
{
    public partial class IBaalTokenService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, IBaalTokenDeployment iBaalTokenDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<IBaalTokenDeployment>().SendRequestAndWaitForReceiptAsync(iBaalTokenDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, IBaalTokenDeployment iBaalTokenDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<IBaalTokenDeployment>().SendRequestAsync(iBaalTokenDeployment);
        }

        public static async Task<IBaalTokenService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, IBaalTokenDeployment iBaalTokenDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, iBaalTokenDeployment, cancellationTokenSource);
            return new IBaalTokenService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public IBaalTokenService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<BigInteger> BalanceOfQueryAsync(BalanceOfFunction balanceOfFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<BalanceOfFunction, BigInteger>(balanceOfFunction, blockParameter);
        }

        
        public Task<BigInteger> BalanceOfQueryAsync(string account, BlockParameter blockParameter = null)
        {
            var balanceOfFunction = new BalanceOfFunction();
                balanceOfFunction.Account = account;
            
            return ContractHandler.QueryAsync<BalanceOfFunction, BigInteger>(balanceOfFunction, blockParameter);
        }

        public Task<string> BurnRequestAsync(BurnFunction burnFunction)
        {
             return ContractHandler.SendRequestAsync(burnFunction);
        }

        public Task<TransactionReceipt> BurnRequestAndWaitForReceiptAsync(BurnFunction burnFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(burnFunction, cancellationToken);
        }

        public Task<string> BurnRequestAsync(string account, BigInteger amount)
        {
            var burnFunction = new BurnFunction();
                burnFunction.Account = account;
                burnFunction.Amount = amount;
            
             return ContractHandler.SendRequestAsync(burnFunction);
        }

        public Task<TransactionReceipt> BurnRequestAndWaitForReceiptAsync(string account, BigInteger amount, CancellationTokenSource cancellationToken = null)
        {
            var burnFunction = new BurnFunction();
                burnFunction.Account = account;
                burnFunction.Amount = amount;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(burnFunction, cancellationToken);
        }

        public Task<GetCheckpointOutputDTO> GetCheckpointQueryAsync(GetCheckpointFunction getCheckpointFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetCheckpointFunction, GetCheckpointOutputDTO>(getCheckpointFunction, blockParameter);
        }

        public Task<GetCheckpointOutputDTO> GetCheckpointQueryAsync(string returnValue1, BigInteger returnValue2, BlockParameter blockParameter = null)
        {
            var getCheckpointFunction = new GetCheckpointFunction();
                getCheckpointFunction.ReturnValue1 = returnValue1;
                getCheckpointFunction.ReturnValue2 = returnValue2;
            
            return ContractHandler.QueryDeserializingToObjectAsync<GetCheckpointFunction, GetCheckpointOutputDTO>(getCheckpointFunction, blockParameter);
        }

        public Task<string> MintRequestAsync(MintFunction mintFunction)
        {
             return ContractHandler.SendRequestAsync(mintFunction);
        }

        public Task<TransactionReceipt> MintRequestAndWaitForReceiptAsync(MintFunction mintFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(mintFunction, cancellationToken);
        }

        public Task<string> MintRequestAsync(string recipient, BigInteger amount)
        {
            var mintFunction = new MintFunction();
                mintFunction.Recipient = recipient;
                mintFunction.Amount = amount;
            
             return ContractHandler.SendRequestAsync(mintFunction);
        }

        public Task<TransactionReceipt> MintRequestAndWaitForReceiptAsync(string recipient, BigInteger amount, CancellationTokenSource cancellationToken = null)
        {
            var mintFunction = new MintFunction();
                mintFunction.Recipient = recipient;
                mintFunction.Amount = amount;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(mintFunction, cancellationToken);
        }

        public Task<string> NameQueryAsync(NameFunction nameFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<NameFunction, string>(nameFunction, blockParameter);
        }

        
        public Task<string> NameQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<NameFunction, string>(null, blockParameter);
        }

        public Task<BigInteger> NumCheckpointsQueryAsync(NumCheckpointsFunction numCheckpointsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<NumCheckpointsFunction, BigInteger>(numCheckpointsFunction, blockParameter);
        }

        
        public Task<BigInteger> NumCheckpointsQueryAsync(string returnValue1, BlockParameter blockParameter = null)
        {
            var numCheckpointsFunction = new NumCheckpointsFunction();
                numCheckpointsFunction.ReturnValue1 = returnValue1;
            
            return ContractHandler.QueryAsync<NumCheckpointsFunction, BigInteger>(numCheckpointsFunction, blockParameter);
        }

        public Task<string> SetUpRequestAsync(SetUpFunction setUpFunction)
        {
             return ContractHandler.SendRequestAsync(setUpFunction);
        }

        public Task<TransactionReceipt> SetUpRequestAndWaitForReceiptAsync(SetUpFunction setUpFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setUpFunction, cancellationToken);
        }

        public Task<string> SetUpRequestAsync(string name, string symbol)
        {
            var setUpFunction = new SetUpFunction();
                setUpFunction.Name = name;
                setUpFunction.Symbol = symbol;
            
             return ContractHandler.SendRequestAsync(setUpFunction);
        }

        public Task<TransactionReceipt> SetUpRequestAndWaitForReceiptAsync(string name, string symbol, CancellationTokenSource cancellationToken = null)
        {
            var setUpFunction = new SetUpFunction();
                setUpFunction.Name = name;
                setUpFunction.Symbol = symbol;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setUpFunction, cancellationToken);
        }

        public Task<BigInteger> TotalSupplyQueryAsync(TotalSupplyFunction totalSupplyFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TotalSupplyFunction, BigInteger>(totalSupplyFunction, blockParameter);
        }

        
        public Task<BigInteger> TotalSupplyQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TotalSupplyFunction, BigInteger>(null, blockParameter);
        }
    }
}
