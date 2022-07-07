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
using ExampleBaal.Contracts.TributeMinion.ContractDefinition;

namespace ExampleBaal.Contracts.TributeMinion
{
    public partial class TributeMinionService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, TributeMinionDeployment tributeMinionDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<TributeMinionDeployment>().SendRequestAndWaitForReceiptAsync(tributeMinionDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, TributeMinionDeployment tributeMinionDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<TributeMinionDeployment>().SendRequestAsync(tributeMinionDeployment);
        }

        public static async Task<TributeMinionService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, TributeMinionDeployment tributeMinionDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, tributeMinionDeployment, cancellationTokenSource);
            return new TributeMinionService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public TributeMinionService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<byte[]> EncodeTributeProposalQueryAsync(EncodeTributeProposalFunction encodeTributeProposalFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<EncodeTributeProposalFunction, byte[]>(encodeTributeProposalFunction, blockParameter);
        }

        
        public Task<byte[]> EncodeTributeProposalQueryAsync(string baal, BigInteger shares, BigInteger loot, string recipient, uint proposalId, string escrow, BlockParameter blockParameter = null)
        {
            var encodeTributeProposalFunction = new EncodeTributeProposalFunction();
                encodeTributeProposalFunction.Baal = baal;
                encodeTributeProposalFunction.Shares = shares;
                encodeTributeProposalFunction.Loot = loot;
                encodeTributeProposalFunction.Recipient = recipient;
                encodeTributeProposalFunction.ProposalId = proposalId;
                encodeTributeProposalFunction.Escrow = escrow;
            
            return ContractHandler.QueryAsync<EncodeTributeProposalFunction, byte[]>(encodeTributeProposalFunction, blockParameter);
        }

        public Task<string> ReleaseEscrowRequestAsync(ReleaseEscrowFunction releaseEscrowFunction)
        {
             return ContractHandler.SendRequestAsync(releaseEscrowFunction);
        }

        public Task<TransactionReceipt> ReleaseEscrowRequestAndWaitForReceiptAsync(ReleaseEscrowFunction releaseEscrowFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(releaseEscrowFunction, cancellationToken);
        }

        public Task<string> ReleaseEscrowRequestAsync(string baal, uint proposalId)
        {
            var releaseEscrowFunction = new ReleaseEscrowFunction();
                releaseEscrowFunction.Baal = baal;
                releaseEscrowFunction.ProposalId = proposalId;
            
             return ContractHandler.SendRequestAsync(releaseEscrowFunction);
        }

        public Task<TransactionReceipt> ReleaseEscrowRequestAndWaitForReceiptAsync(string baal, uint proposalId, CancellationTokenSource cancellationToken = null)
        {
            var releaseEscrowFunction = new ReleaseEscrowFunction();
                releaseEscrowFunction.Baal = baal;
                releaseEscrowFunction.ProposalId = proposalId;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(releaseEscrowFunction, cancellationToken);
        }

        public Task<string> SubmitTributeProposalRequestAsync(SubmitTributeProposalFunction submitTributeProposalFunction)
        {
             return ContractHandler.SendRequestAsync(submitTributeProposalFunction);
        }

        public Task<TransactionReceipt> SubmitTributeProposalRequestAndWaitForReceiptAsync(SubmitTributeProposalFunction submitTributeProposalFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(submitTributeProposalFunction, cancellationToken);
        }

        public Task<string> SubmitTributeProposalRequestAsync(string baal, string token, BigInteger amount, BigInteger shares, BigInteger loot, uint expiration, string details)
        {
            var submitTributeProposalFunction = new SubmitTributeProposalFunction();
                submitTributeProposalFunction.Baal = baal;
                submitTributeProposalFunction.Token = token;
                submitTributeProposalFunction.Amount = amount;
                submitTributeProposalFunction.Shares = shares;
                submitTributeProposalFunction.Loot = loot;
                submitTributeProposalFunction.Expiration = expiration;
                submitTributeProposalFunction.Details = details;
            
             return ContractHandler.SendRequestAsync(submitTributeProposalFunction);
        }

        public Task<TransactionReceipt> SubmitTributeProposalRequestAndWaitForReceiptAsync(string baal, string token, BigInteger amount, BigInteger shares, BigInteger loot, uint expiration, string details, CancellationTokenSource cancellationToken = null)
        {
            var submitTributeProposalFunction = new SubmitTributeProposalFunction();
                submitTributeProposalFunction.Baal = baal;
                submitTributeProposalFunction.Token = token;
                submitTributeProposalFunction.Amount = amount;
                submitTributeProposalFunction.Shares = shares;
                submitTributeProposalFunction.Loot = loot;
                submitTributeProposalFunction.Expiration = expiration;
                submitTributeProposalFunction.Details = details;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(submitTributeProposalFunction, cancellationToken);
        }
    }
}
