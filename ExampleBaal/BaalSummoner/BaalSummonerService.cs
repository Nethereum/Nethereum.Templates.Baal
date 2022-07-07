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
using ExampleBaal.Contracts.BaalSummoner.ContractDefinition;

namespace ExampleBaal.Contracts.BaalSummoner
{
    public partial class BaalSummonerService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, BaalSummonerDeployment baalSummonerDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<BaalSummonerDeployment>().SendRequestAndWaitForReceiptAsync(baalSummonerDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, BaalSummonerDeployment baalSummonerDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<BaalSummonerDeployment>().SendRequestAsync(baalSummonerDeployment);
        }

        public static async Task<BaalSummonerService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, BaalSummonerDeployment baalSummonerDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, baalSummonerDeployment, cancellationTokenSource);
            return new BaalSummonerService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public BaalSummonerService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> DeployModuleRequestAsync(DeployModuleFunction deployModuleFunction)
        {
             return ContractHandler.SendRequestAsync(deployModuleFunction);
        }

        public Task<TransactionReceipt> DeployModuleRequestAndWaitForReceiptAsync(DeployModuleFunction deployModuleFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(deployModuleFunction, cancellationToken);
        }

        public Task<string> DeployModuleRequestAsync(string masterCopy, byte[] initializer, BigInteger saltNonce)
        {
            var deployModuleFunction = new DeployModuleFunction();
                deployModuleFunction.MasterCopy = masterCopy;
                deployModuleFunction.Initializer = initializer;
                deployModuleFunction.SaltNonce = saltNonce;
            
             return ContractHandler.SendRequestAsync(deployModuleFunction);
        }

        public Task<TransactionReceipt> DeployModuleRequestAndWaitForReceiptAsync(string masterCopy, byte[] initializer, BigInteger saltNonce, CancellationTokenSource cancellationToken = null)
        {
            var deployModuleFunction = new DeployModuleFunction();
                deployModuleFunction.MasterCopy = masterCopy;
                deployModuleFunction.Initializer = initializer;
                deployModuleFunction.SaltNonce = saltNonce;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(deployModuleFunction, cancellationToken);
        }

        public Task<byte[]> EncodeMultisendQueryAsync(EncodeMultisendFunction encodeMultisendFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<EncodeMultisendFunction, byte[]>(encodeMultisendFunction, blockParameter);
        }

        
        public Task<byte[]> EncodeMultisendQueryAsync(List<byte[]> calls, string target, BlockParameter blockParameter = null)
        {
            var encodeMultisendFunction = new EncodeMultisendFunction();
                encodeMultisendFunction.Calls = calls;
                encodeMultisendFunction.Target = target;
            
            return ContractHandler.QueryAsync<EncodeMultisendFunction, byte[]>(encodeMultisendFunction, blockParameter);
        }

        public Task<string> GnosisFallbackLibraryQueryAsync(GnosisFallbackLibraryFunction gnosisFallbackLibraryFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GnosisFallbackLibraryFunction, string>(gnosisFallbackLibraryFunction, blockParameter);
        }

        
        public Task<string> GnosisFallbackLibraryQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GnosisFallbackLibraryFunction, string>(null, blockParameter);
        }

        public Task<string> GnosisMultisendLibraryQueryAsync(GnosisMultisendLibraryFunction gnosisMultisendLibraryFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GnosisMultisendLibraryFunction, string>(gnosisMultisendLibraryFunction, blockParameter);
        }

        
        public Task<string> GnosisMultisendLibraryQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GnosisMultisendLibraryFunction, string>(null, blockParameter);
        }

        public Task<string> GnosisSingletonQueryAsync(GnosisSingletonFunction gnosisSingletonFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GnosisSingletonFunction, string>(gnosisSingletonFunction, blockParameter);
        }

        
        public Task<string> GnosisSingletonQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GnosisSingletonFunction, string>(null, blockParameter);
        }

        public Task<string> SummonBaalRequestAsync(SummonBaalFunction summonBaalFunction)
        {
             return ContractHandler.SendRequestAsync(summonBaalFunction);
        }

        public Task<TransactionReceipt> SummonBaalRequestAndWaitForReceiptAsync(SummonBaalFunction summonBaalFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(summonBaalFunction, cancellationToken);
        }

        public Task<string> SummonBaalRequestAsync(string safe)
        {
            var summonBaalFunction = new SummonBaalFunction();
                summonBaalFunction.Safe = safe;
            
             return ContractHandler.SendRequestAsync(summonBaalFunction);
        }

        public Task<TransactionReceipt> SummonBaalRequestAndWaitForReceiptAsync(string safe, CancellationTokenSource cancellationToken = null)
        {
            var summonBaalFunction = new SummonBaalFunction();
                summonBaalFunction.Safe = safe;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(summonBaalFunction, cancellationToken);
        }

        public Task<string> SummonBaalAndSafeRequestAsync(SummonBaalAndSafeFunction summonBaalAndSafeFunction)
        {
             return ContractHandler.SendRequestAsync(summonBaalAndSafeFunction);
        }

        public Task<TransactionReceipt> SummonBaalAndSafeRequestAndWaitForReceiptAsync(SummonBaalAndSafeFunction summonBaalAndSafeFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(summonBaalAndSafeFunction, cancellationToken);
        }

        public Task<string> SummonBaalAndSafeRequestAsync(byte[] initializationParams, List<byte[]> initializationActions, BigInteger saltNonce)
        {
            var summonBaalAndSafeFunction = new SummonBaalAndSafeFunction();
                summonBaalAndSafeFunction.InitializationParams = initializationParams;
                summonBaalAndSafeFunction.InitializationActions = initializationActions;
                summonBaalAndSafeFunction.SaltNonce = saltNonce;
            
             return ContractHandler.SendRequestAsync(summonBaalAndSafeFunction);
        }

        public Task<TransactionReceipt> SummonBaalAndSafeRequestAndWaitForReceiptAsync(byte[] initializationParams, List<byte[]> initializationActions, BigInteger saltNonce, CancellationTokenSource cancellationToken = null)
        {
            var summonBaalAndSafeFunction = new SummonBaalAndSafeFunction();
                summonBaalAndSafeFunction.InitializationParams = initializationParams;
                summonBaalAndSafeFunction.InitializationActions = initializationActions;
                summonBaalAndSafeFunction.SaltNonce = saltNonce;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(summonBaalAndSafeFunction, cancellationToken);
        }

        public Task<string> TemplateQueryAsync(TemplateFunction templateFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TemplateFunction, string>(templateFunction, blockParameter);
        }

        
        public Task<string> TemplateQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TemplateFunction, string>(null, blockParameter);
        }
    }
}
