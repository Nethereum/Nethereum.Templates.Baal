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
using ExampleBaal.Contracts.Shares.ContractDefinition;

namespace ExampleBaal.Contracts.Shares
{
    public partial class SharesService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, SharesDeployment sharesDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<SharesDeployment>().SendRequestAndWaitForReceiptAsync(sharesDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, SharesDeployment sharesDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<SharesDeployment>().SendRequestAsync(sharesDeployment);
        }

        public static async Task<SharesService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, SharesDeployment sharesDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, sharesDeployment, cancellationTokenSource);
            return new SharesService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public SharesService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<BigInteger> AllowanceQueryAsync(AllowanceFunction allowanceFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<AllowanceFunction, BigInteger>(allowanceFunction, blockParameter);
        }

        
        public Task<BigInteger> AllowanceQueryAsync(string owner, string spender, BlockParameter blockParameter = null)
        {
            var allowanceFunction = new AllowanceFunction();
                allowanceFunction.Owner = owner;
                allowanceFunction.Spender = spender;
            
            return ContractHandler.QueryAsync<AllowanceFunction, BigInteger>(allowanceFunction, blockParameter);
        }

        public Task<string> ApproveRequestAsync(ApproveFunction approveFunction)
        {
             return ContractHandler.SendRequestAsync(approveFunction);
        }

        public Task<TransactionReceipt> ApproveRequestAndWaitForReceiptAsync(ApproveFunction approveFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(approveFunction, cancellationToken);
        }

        public Task<string> ApproveRequestAsync(string spender, BigInteger amount)
        {
            var approveFunction = new ApproveFunction();
                approveFunction.Spender = spender;
                approveFunction.Amount = amount;
            
             return ContractHandler.SendRequestAsync(approveFunction);
        }

        public Task<TransactionReceipt> ApproveRequestAndWaitForReceiptAsync(string spender, BigInteger amount, CancellationTokenSource cancellationToken = null)
        {
            var approveFunction = new ApproveFunction();
                approveFunction.Spender = spender;
                approveFunction.Amount = amount;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(approveFunction, cancellationToken);
        }

        public Task<string> BaalQueryAsync(BaalFunction baalFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<BaalFunction, string>(baalFunction, blockParameter);
        }

        
        public Task<string> BaalQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<BaalFunction, string>(null, blockParameter);
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

        public Task<CheckpointsOutputDTO> CheckpointsQueryAsync(CheckpointsFunction checkpointsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<CheckpointsFunction, CheckpointsOutputDTO>(checkpointsFunction, blockParameter);
        }

        public Task<CheckpointsOutputDTO> CheckpointsQueryAsync(string returnValue1, BigInteger returnValue2, BlockParameter blockParameter = null)
        {
            var checkpointsFunction = new CheckpointsFunction();
                checkpointsFunction.ReturnValue1 = returnValue1;
                checkpointsFunction.ReturnValue2 = returnValue2;
            
            return ContractHandler.QueryDeserializingToObjectAsync<CheckpointsFunction, CheckpointsOutputDTO>(checkpointsFunction, blockParameter);
        }

        public Task<byte> DecimalsQueryAsync(DecimalsFunction decimalsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<DecimalsFunction, byte>(decimalsFunction, blockParameter);
        }

        
        public Task<byte> DecimalsQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<DecimalsFunction, byte>(null, blockParameter);
        }

        public Task<string> DecreaseAllowanceRequestAsync(DecreaseAllowanceFunction decreaseAllowanceFunction)
        {
             return ContractHandler.SendRequestAsync(decreaseAllowanceFunction);
        }

        public Task<TransactionReceipt> DecreaseAllowanceRequestAndWaitForReceiptAsync(DecreaseAllowanceFunction decreaseAllowanceFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(decreaseAllowanceFunction, cancellationToken);
        }

        public Task<string> DecreaseAllowanceRequestAsync(string spender, BigInteger subtractedValue)
        {
            var decreaseAllowanceFunction = new DecreaseAllowanceFunction();
                decreaseAllowanceFunction.Spender = spender;
                decreaseAllowanceFunction.SubtractedValue = subtractedValue;
            
             return ContractHandler.SendRequestAsync(decreaseAllowanceFunction);
        }

        public Task<TransactionReceipt> DecreaseAllowanceRequestAndWaitForReceiptAsync(string spender, BigInteger subtractedValue, CancellationTokenSource cancellationToken = null)
        {
            var decreaseAllowanceFunction = new DecreaseAllowanceFunction();
                decreaseAllowanceFunction.Spender = spender;
                decreaseAllowanceFunction.SubtractedValue = subtractedValue;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(decreaseAllowanceFunction, cancellationToken);
        }

        public Task<string> DelegateRequestAsync(DelegateFunction @delegateFunction)
        {
             return ContractHandler.SendRequestAsync(@delegateFunction);
        }

        public Task<TransactionReceipt> DelegateRequestAndWaitForReceiptAsync(DelegateFunction @delegateFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(@delegateFunction, cancellationToken);
        }

        public Task<string> DelegateRequestAsync(string delegatee)
        {
            var @delegateFunction = new DelegateFunction();
                @delegateFunction.Delegatee = delegatee;
            
             return ContractHandler.SendRequestAsync(@delegateFunction);
        }

        public Task<TransactionReceipt> DelegateRequestAndWaitForReceiptAsync(string delegatee, CancellationTokenSource cancellationToken = null)
        {
            var @delegateFunction = new DelegateFunction();
                @delegateFunction.Delegatee = delegatee;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(@delegateFunction, cancellationToken);
        }

        public Task<string> DelegateBySigRequestAsync(DelegateBySigFunction delegateBySigFunction)
        {
             return ContractHandler.SendRequestAsync(delegateBySigFunction);
        }

        public Task<TransactionReceipt> DelegateBySigRequestAndWaitForReceiptAsync(DelegateBySigFunction delegateBySigFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(delegateBySigFunction, cancellationToken);
        }

        public Task<string> DelegateBySigRequestAsync(string delegatee, BigInteger nonce, BigInteger deadline, byte[] signature)
        {
            var delegateBySigFunction = new DelegateBySigFunction();
                delegateBySigFunction.Delegatee = delegatee;
                delegateBySigFunction.Nonce = nonce;
                delegateBySigFunction.Deadline = deadline;
                delegateBySigFunction.Signature = signature;
            
             return ContractHandler.SendRequestAsync(delegateBySigFunction);
        }

        public Task<TransactionReceipt> DelegateBySigRequestAndWaitForReceiptAsync(string delegatee, BigInteger nonce, BigInteger deadline, byte[] signature, CancellationTokenSource cancellationToken = null)
        {
            var delegateBySigFunction = new DelegateBySigFunction();
                delegateBySigFunction.Delegatee = delegatee;
                delegateBySigFunction.Nonce = nonce;
                delegateBySigFunction.Deadline = deadline;
                delegateBySigFunction.Signature = signature;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(delegateBySigFunction, cancellationToken);
        }

        public Task<string> DelegatesQueryAsync(DelegatesFunction delegatesFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<DelegatesFunction, string>(delegatesFunction, blockParameter);
        }

        
        public Task<string> DelegatesQueryAsync(string returnValue1, BlockParameter blockParameter = null)
        {
            var delegatesFunction = new DelegatesFunction();
                delegatesFunction.ReturnValue1 = returnValue1;
            
            return ContractHandler.QueryAsync<DelegatesFunction, string>(delegatesFunction, blockParameter);
        }

        public Task<GetCheckpointOutputDTO> GetCheckpointQueryAsync(GetCheckpointFunction getCheckpointFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetCheckpointFunction, GetCheckpointOutputDTO>(getCheckpointFunction, blockParameter);
        }

        public Task<GetCheckpointOutputDTO> GetCheckpointQueryAsync(string delegatee, BigInteger nCheckpoints, BlockParameter blockParameter = null)
        {
            var getCheckpointFunction = new GetCheckpointFunction();
                getCheckpointFunction.Delegatee = delegatee;
                getCheckpointFunction.NCheckpoints = nCheckpoints;
            
            return ContractHandler.QueryDeserializingToObjectAsync<GetCheckpointFunction, GetCheckpointOutputDTO>(getCheckpointFunction, blockParameter);
        }

        public Task<string> IncreaseAllowanceRequestAsync(IncreaseAllowanceFunction increaseAllowanceFunction)
        {
             return ContractHandler.SendRequestAsync(increaseAllowanceFunction);
        }

        public Task<TransactionReceipt> IncreaseAllowanceRequestAndWaitForReceiptAsync(IncreaseAllowanceFunction increaseAllowanceFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(increaseAllowanceFunction, cancellationToken);
        }

        public Task<string> IncreaseAllowanceRequestAsync(string spender, BigInteger addedValue)
        {
            var increaseAllowanceFunction = new IncreaseAllowanceFunction();
                increaseAllowanceFunction.Spender = spender;
                increaseAllowanceFunction.AddedValue = addedValue;
            
             return ContractHandler.SendRequestAsync(increaseAllowanceFunction);
        }

        public Task<TransactionReceipt> IncreaseAllowanceRequestAndWaitForReceiptAsync(string spender, BigInteger addedValue, CancellationTokenSource cancellationToken = null)
        {
            var increaseAllowanceFunction = new IncreaseAllowanceFunction();
                increaseAllowanceFunction.Spender = spender;
                increaseAllowanceFunction.AddedValue = addedValue;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(increaseAllowanceFunction, cancellationToken);
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

        public Task<BigInteger> NoncesQueryAsync(NoncesFunction noncesFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<NoncesFunction, BigInteger>(noncesFunction, blockParameter);
        }

        
        public Task<BigInteger> NoncesQueryAsync(string returnValue1, BlockParameter blockParameter = null)
        {
            var noncesFunction = new NoncesFunction();
                noncesFunction.ReturnValue1 = returnValue1;
            
            return ContractHandler.QueryAsync<NoncesFunction, BigInteger>(noncesFunction, blockParameter);
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

        public Task<string> PermitRequestAsync(PermitFunction permitFunction)
        {
             return ContractHandler.SendRequestAsync(permitFunction);
        }

        public Task<TransactionReceipt> PermitRequestAndWaitForReceiptAsync(PermitFunction permitFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(permitFunction, cancellationToken);
        }

        public Task<string> PermitRequestAsync(string owner, string spender, BigInteger amount, BigInteger deadline, byte[] signature)
        {
            var permitFunction = new PermitFunction();
                permitFunction.Owner = owner;
                permitFunction.Spender = spender;
                permitFunction.Amount = amount;
                permitFunction.Deadline = deadline;
                permitFunction.Signature = signature;
            
             return ContractHandler.SendRequestAsync(permitFunction);
        }

        public Task<TransactionReceipt> PermitRequestAndWaitForReceiptAsync(string owner, string spender, BigInteger amount, BigInteger deadline, byte[] signature, CancellationTokenSource cancellationToken = null)
        {
            var permitFunction = new PermitFunction();
                permitFunction.Owner = owner;
                permitFunction.Spender = spender;
                permitFunction.Amount = amount;
                permitFunction.Deadline = deadline;
                permitFunction.Signature = signature;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(permitFunction, cancellationToken);
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

        public Task<string> SymbolQueryAsync(SymbolFunction symbolFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SymbolFunction, string>(symbolFunction, blockParameter);
        }

        
        public Task<string> SymbolQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SymbolFunction, string>(null, blockParameter);
        }

        public Task<BigInteger> TotalSupplyQueryAsync(TotalSupplyFunction totalSupplyFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TotalSupplyFunction, BigInteger>(totalSupplyFunction, blockParameter);
        }

        
        public Task<BigInteger> TotalSupplyQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TotalSupplyFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> TransferRequestAsync(TransferFunction transferFunction)
        {
             return ContractHandler.SendRequestAsync(transferFunction);
        }

        public Task<TransactionReceipt> TransferRequestAndWaitForReceiptAsync(TransferFunction transferFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferFunction, cancellationToken);
        }

        public Task<string> TransferRequestAsync(string to, BigInteger amount)
        {
            var transferFunction = new TransferFunction();
                transferFunction.To = to;
                transferFunction.Amount = amount;
            
             return ContractHandler.SendRequestAsync(transferFunction);
        }

        public Task<TransactionReceipt> TransferRequestAndWaitForReceiptAsync(string to, BigInteger amount, CancellationTokenSource cancellationToken = null)
        {
            var transferFunction = new TransferFunction();
                transferFunction.To = to;
                transferFunction.Amount = amount;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferFunction, cancellationToken);
        }

        public Task<string> TransferFromRequestAsync(TransferFromFunction transferFromFunction)
        {
             return ContractHandler.SendRequestAsync(transferFromFunction);
        }

        public Task<TransactionReceipt> TransferFromRequestAndWaitForReceiptAsync(TransferFromFunction transferFromFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferFromFunction, cancellationToken);
        }

        public Task<string> TransferFromRequestAsync(string from, string to, BigInteger amount)
        {
            var transferFromFunction = new TransferFromFunction();
                transferFromFunction.From = from;
                transferFromFunction.To = to;
                transferFromFunction.Amount = amount;
            
             return ContractHandler.SendRequestAsync(transferFromFunction);
        }

        public Task<TransactionReceipt> TransferFromRequestAndWaitForReceiptAsync(string from, string to, BigInteger amount, CancellationTokenSource cancellationToken = null)
        {
            var transferFromFunction = new TransferFromFunction();
                transferFromFunction.From = from;
                transferFromFunction.To = to;
                transferFromFunction.Amount = amount;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferFromFunction, cancellationToken);
        }
    }
}
