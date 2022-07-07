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
using ExampleBaal.Contracts.Baal.ContractDefinition;

namespace ExampleBaal.Contracts.Baal
{
    public partial class BaalService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, BaalDeployment baalDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<BaalDeployment>().SendRequestAndWaitForReceiptAsync(baalDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, BaalDeployment baalDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<BaalDeployment>().SendRequestAsync(baalDeployment);
        }

        public static async Task<BaalService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, BaalDeployment baalDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, baalDeployment, cancellationTokenSource);
            return new BaalService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public BaalService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<bool> AdminLockQueryAsync(AdminLockFunction adminLockFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<AdminLockFunction, bool>(adminLockFunction, blockParameter);
        }

        
        public Task<bool> AdminLockQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<AdminLockFunction, bool>(null, blockParameter);
        }

        public Task<BigInteger> AllowanceQueryAsync(AllowanceFunction allowanceFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<AllowanceFunction, BigInteger>(allowanceFunction, blockParameter);
        }

        
        public Task<BigInteger> AllowanceQueryAsync(string returnValue1, string returnValue2, BlockParameter blockParameter = null)
        {
            var allowanceFunction = new AllowanceFunction();
                allowanceFunction.ReturnValue1 = returnValue1;
                allowanceFunction.ReturnValue2 = returnValue2;
            
            return ContractHandler.QueryAsync<AllowanceFunction, BigInteger>(allowanceFunction, blockParameter);
        }

        public Task<string> AvatarQueryAsync(AvatarFunction avatarFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<AvatarFunction, string>(avatarFunction, blockParameter);
        }

        
        public Task<string> AvatarQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<AvatarFunction, string>(null, blockParameter);
        }

        public Task<string> BurnLootRequestAsync(BurnLootFunction burnLootFunction)
        {
             return ContractHandler.SendRequestAsync(burnLootFunction);
        }

        public Task<TransactionReceipt> BurnLootRequestAndWaitForReceiptAsync(BurnLootFunction burnLootFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(burnLootFunction, cancellationToken);
        }

        public Task<string> BurnLootRequestAsync(List<string> from, List<BigInteger> amount)
        {
            var burnLootFunction = new BurnLootFunction();
                burnLootFunction.From = from;
                burnLootFunction.Amount = amount;
            
             return ContractHandler.SendRequestAsync(burnLootFunction);
        }

        public Task<TransactionReceipt> BurnLootRequestAndWaitForReceiptAsync(List<string> from, List<BigInteger> amount, CancellationTokenSource cancellationToken = null)
        {
            var burnLootFunction = new BurnLootFunction();
                burnLootFunction.From = from;
                burnLootFunction.Amount = amount;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(burnLootFunction, cancellationToken);
        }

        public Task<string> BurnSharesRequestAsync(BurnSharesFunction burnSharesFunction)
        {
             return ContractHandler.SendRequestAsync(burnSharesFunction);
        }

        public Task<TransactionReceipt> BurnSharesRequestAndWaitForReceiptAsync(BurnSharesFunction burnSharesFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(burnSharesFunction, cancellationToken);
        }

        public Task<string> BurnSharesRequestAsync(List<string> from, List<BigInteger> amount)
        {
            var burnSharesFunction = new BurnSharesFunction();
                burnSharesFunction.From = from;
                burnSharesFunction.Amount = amount;
            
             return ContractHandler.SendRequestAsync(burnSharesFunction);
        }

        public Task<TransactionReceipt> BurnSharesRequestAndWaitForReceiptAsync(List<string> from, List<BigInteger> amount, CancellationTokenSource cancellationToken = null)
        {
            var burnSharesFunction = new BurnSharesFunction();
                burnSharesFunction.From = from;
                burnSharesFunction.Amount = amount;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(burnSharesFunction, cancellationToken);
        }

        public Task<string> CancelProposalRequestAsync(CancelProposalFunction cancelProposalFunction)
        {
             return ContractHandler.SendRequestAsync(cancelProposalFunction);
        }

        public Task<TransactionReceipt> CancelProposalRequestAndWaitForReceiptAsync(CancelProposalFunction cancelProposalFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(cancelProposalFunction, cancellationToken);
        }

        public Task<string> CancelProposalRequestAsync(uint id)
        {
            var cancelProposalFunction = new CancelProposalFunction();
                cancelProposalFunction.Id = id;
            
             return ContractHandler.SendRequestAsync(cancelProposalFunction);
        }

        public Task<TransactionReceipt> CancelProposalRequestAndWaitForReceiptAsync(uint id, CancellationTokenSource cancellationToken = null)
        {
            var cancelProposalFunction = new CancelProposalFunction();
                cancelProposalFunction.Id = id;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(cancelProposalFunction, cancellationToken);
        }

        public Task<string> ExecuteAsBaalRequestAsync(ExecuteAsBaalFunction executeAsBaalFunction)
        {
             return ContractHandler.SendRequestAsync(executeAsBaalFunction);
        }

        public Task<TransactionReceipt> ExecuteAsBaalRequestAndWaitForReceiptAsync(ExecuteAsBaalFunction executeAsBaalFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(executeAsBaalFunction, cancellationToken);
        }

        public Task<string> ExecuteAsBaalRequestAsync(string to, BigInteger value, byte[] data)
        {
            var executeAsBaalFunction = new ExecuteAsBaalFunction();
                executeAsBaalFunction.To = to;
                executeAsBaalFunction.Value = value;
                executeAsBaalFunction.Data = data;
            
             return ContractHandler.SendRequestAsync(executeAsBaalFunction);
        }

        public Task<TransactionReceipt> ExecuteAsBaalRequestAndWaitForReceiptAsync(string to, BigInteger value, byte[] data, CancellationTokenSource cancellationToken = null)
        {
            var executeAsBaalFunction = new ExecuteAsBaalFunction();
                executeAsBaalFunction.To = to;
                executeAsBaalFunction.Value = value;
                executeAsBaalFunction.Data = data;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(executeAsBaalFunction, cancellationToken);
        }

        public Task<BigInteger> GetCurrentVotesQueryAsync(GetCurrentVotesFunction getCurrentVotesFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetCurrentVotesFunction, BigInteger>(getCurrentVotesFunction, blockParameter);
        }

        
        public Task<BigInteger> GetCurrentVotesQueryAsync(string account, BlockParameter blockParameter = null)
        {
            var getCurrentVotesFunction = new GetCurrentVotesFunction();
                getCurrentVotesFunction.Account = account;
            
            return ContractHandler.QueryAsync<GetCurrentVotesFunction, BigInteger>(getCurrentVotesFunction, blockParameter);
        }

        public Task<string> GetGuardQueryAsync(GetGuardFunction getGuardFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetGuardFunction, string>(getGuardFunction, blockParameter);
        }

        
        public Task<string> GetGuardQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetGuardFunction, string>(null, blockParameter);
        }

        public Task<BigInteger> GetPriorVotesQueryAsync(GetPriorVotesFunction getPriorVotesFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetPriorVotesFunction, BigInteger>(getPriorVotesFunction, blockParameter);
        }

        
        public Task<BigInteger> GetPriorVotesQueryAsync(string account, BigInteger timeStamp, BlockParameter blockParameter = null)
        {
            var getPriorVotesFunction = new GetPriorVotesFunction();
                getPriorVotesFunction.Account = account;
                getPriorVotesFunction.TimeStamp = timeStamp;
            
            return ContractHandler.QueryAsync<GetPriorVotesFunction, BigInteger>(getPriorVotesFunction, blockParameter);
        }

        public Task<List<bool>> GetProposalStatusQueryAsync(GetProposalStatusFunction getProposalStatusFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetProposalStatusFunction, List<bool>>(getProposalStatusFunction, blockParameter);
        }

        
        public Task<List<bool>> GetProposalStatusQueryAsync(uint id, BlockParameter blockParameter = null)
        {
            var getProposalStatusFunction = new GetProposalStatusFunction();
                getProposalStatusFunction.Id = id;
            
            return ContractHandler.QueryAsync<GetProposalStatusFunction, List<bool>>(getProposalStatusFunction, blockParameter);
        }

        public Task<bool> GovernorLockQueryAsync(GovernorLockFunction governorLockFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GovernorLockFunction, bool>(governorLockFunction, blockParameter);
        }

        
        public Task<bool> GovernorLockQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GovernorLockFunction, bool>(null, blockParameter);
        }

        public Task<uint> GracePeriodQueryAsync(GracePeriodFunction gracePeriodFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GracePeriodFunction, uint>(gracePeriodFunction, blockParameter);
        }

        
        public Task<uint> GracePeriodQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GracePeriodFunction, uint>(null, blockParameter);
        }

        public Task<string> GuardQueryAsync(GuardFunction guardFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GuardFunction, string>(guardFunction, blockParameter);
        }

        
        public Task<string> GuardQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GuardFunction, string>(null, blockParameter);
        }

        public Task<byte[]> HashOperationQueryAsync(HashOperationFunction hashOperationFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<HashOperationFunction, byte[]>(hashOperationFunction, blockParameter);
        }

        
        public Task<byte[]> HashOperationQueryAsync(byte[] transactions, BlockParameter blockParameter = null)
        {
            var hashOperationFunction = new HashOperationFunction();
                hashOperationFunction.Transactions = transactions;
            
            return ContractHandler.QueryAsync<HashOperationFunction, byte[]>(hashOperationFunction, blockParameter);
        }

        public Task<bool> IsAdminQueryAsync(IsAdminFunction isAdminFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<IsAdminFunction, bool>(isAdminFunction, blockParameter);
        }

        
        public Task<bool> IsAdminQueryAsync(string shaman, BlockParameter blockParameter = null)
        {
            var isAdminFunction = new IsAdminFunction();
                isAdminFunction.Shaman = shaman;
            
            return ContractHandler.QueryAsync<IsAdminFunction, bool>(isAdminFunction, blockParameter);
        }

        public Task<bool> IsGovernorQueryAsync(IsGovernorFunction isGovernorFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<IsGovernorFunction, bool>(isGovernorFunction, blockParameter);
        }

        
        public Task<bool> IsGovernorQueryAsync(string shaman, BlockParameter blockParameter = null)
        {
            var isGovernorFunction = new IsGovernorFunction();
                isGovernorFunction.Shaman = shaman;
            
            return ContractHandler.QueryAsync<IsGovernorFunction, bool>(isGovernorFunction, blockParameter);
        }

        public Task<bool> IsManagerQueryAsync(IsManagerFunction isManagerFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<IsManagerFunction, bool>(isManagerFunction, blockParameter);
        }

        
        public Task<bool> IsManagerQueryAsync(string shaman, BlockParameter blockParameter = null)
        {
            var isManagerFunction = new IsManagerFunction();
                isManagerFunction.Shaman = shaman;
            
            return ContractHandler.QueryAsync<IsManagerFunction, bool>(isManagerFunction, blockParameter);
        }

        public Task<uint> LatestSponsoredProposalIdQueryAsync(LatestSponsoredProposalIdFunction latestSponsoredProposalIdFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<LatestSponsoredProposalIdFunction, uint>(latestSponsoredProposalIdFunction, blockParameter);
        }

        
        public Task<uint> LatestSponsoredProposalIdQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<LatestSponsoredProposalIdFunction, uint>(null, blockParameter);
        }

        public Task<string> LockAdminRequestAsync(LockAdminFunction lockAdminFunction)
        {
             return ContractHandler.SendRequestAsync(lockAdminFunction);
        }

        public Task<string> LockAdminRequestAsync()
        {
             return ContractHandler.SendRequestAsync<LockAdminFunction>();
        }

        public Task<TransactionReceipt> LockAdminRequestAndWaitForReceiptAsync(LockAdminFunction lockAdminFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(lockAdminFunction, cancellationToken);
        }

        public Task<TransactionReceipt> LockAdminRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<LockAdminFunction>(null, cancellationToken);
        }

        public Task<string> LockGovernorRequestAsync(LockGovernorFunction lockGovernorFunction)
        {
             return ContractHandler.SendRequestAsync(lockGovernorFunction);
        }

        public Task<string> LockGovernorRequestAsync()
        {
             return ContractHandler.SendRequestAsync<LockGovernorFunction>();
        }

        public Task<TransactionReceipt> LockGovernorRequestAndWaitForReceiptAsync(LockGovernorFunction lockGovernorFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(lockGovernorFunction, cancellationToken);
        }

        public Task<TransactionReceipt> LockGovernorRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<LockGovernorFunction>(null, cancellationToken);
        }

        public Task<string> LockManagerRequestAsync(LockManagerFunction lockManagerFunction)
        {
             return ContractHandler.SendRequestAsync(lockManagerFunction);
        }

        public Task<string> LockManagerRequestAsync()
        {
             return ContractHandler.SendRequestAsync<LockManagerFunction>();
        }

        public Task<TransactionReceipt> LockManagerRequestAndWaitForReceiptAsync(LockManagerFunction lockManagerFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(lockManagerFunction, cancellationToken);
        }

        public Task<TransactionReceipt> LockManagerRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<LockManagerFunction>(null, cancellationToken);
        }

        public Task<bool> LootPausedQueryAsync(LootPausedFunction lootPausedFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<LootPausedFunction, bool>(lootPausedFunction, blockParameter);
        }

        
        public Task<bool> LootPausedQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<LootPausedFunction, bool>(null, blockParameter);
        }

        public Task<string> LootTokenQueryAsync(LootTokenFunction lootTokenFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<LootTokenFunction, string>(lootTokenFunction, blockParameter);
        }

        
        public Task<string> LootTokenQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<LootTokenFunction, string>(null, blockParameter);
        }

        public Task<bool> ManagerLockQueryAsync(ManagerLockFunction managerLockFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ManagerLockFunction, bool>(managerLockFunction, blockParameter);
        }

        
        public Task<bool> ManagerLockQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ManagerLockFunction, bool>(null, blockParameter);
        }

        public Task<bool> MemberVotedQueryAsync(MemberVotedFunction memberVotedFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<MemberVotedFunction, bool>(memberVotedFunction, blockParameter);
        }

        
        public Task<bool> MemberVotedQueryAsync(string returnValue1, uint returnValue2, BlockParameter blockParameter = null)
        {
            var memberVotedFunction = new MemberVotedFunction();
                memberVotedFunction.ReturnValue1 = returnValue1;
                memberVotedFunction.ReturnValue2 = returnValue2;
            
            return ContractHandler.QueryAsync<MemberVotedFunction, bool>(memberVotedFunction, blockParameter);
        }

        public Task<BigInteger> MinRetentionPercentQueryAsync(MinRetentionPercentFunction minRetentionPercentFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<MinRetentionPercentFunction, BigInteger>(minRetentionPercentFunction, blockParameter);
        }

        
        public Task<BigInteger> MinRetentionPercentQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<MinRetentionPercentFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> MintLootRequestAsync(MintLootFunction mintLootFunction)
        {
             return ContractHandler.SendRequestAsync(mintLootFunction);
        }

        public Task<TransactionReceipt> MintLootRequestAndWaitForReceiptAsync(MintLootFunction mintLootFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(mintLootFunction, cancellationToken);
        }

        public Task<string> MintLootRequestAsync(List<string> to, List<BigInteger> amount)
        {
            var mintLootFunction = new MintLootFunction();
                mintLootFunction.To = to;
                mintLootFunction.Amount = amount;
            
             return ContractHandler.SendRequestAsync(mintLootFunction);
        }

        public Task<TransactionReceipt> MintLootRequestAndWaitForReceiptAsync(List<string> to, List<BigInteger> amount, CancellationTokenSource cancellationToken = null)
        {
            var mintLootFunction = new MintLootFunction();
                mintLootFunction.To = to;
                mintLootFunction.Amount = amount;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(mintLootFunction, cancellationToken);
        }

        public Task<string> MintSharesRequestAsync(MintSharesFunction mintSharesFunction)
        {
             return ContractHandler.SendRequestAsync(mintSharesFunction);
        }

        public Task<TransactionReceipt> MintSharesRequestAndWaitForReceiptAsync(MintSharesFunction mintSharesFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(mintSharesFunction, cancellationToken);
        }

        public Task<string> MintSharesRequestAsync(List<string> to, List<BigInteger> amount)
        {
            var mintSharesFunction = new MintSharesFunction();
                mintSharesFunction.To = to;
                mintSharesFunction.Amount = amount;
            
             return ContractHandler.SendRequestAsync(mintSharesFunction);
        }

        public Task<TransactionReceipt> MintSharesRequestAndWaitForReceiptAsync(List<string> to, List<BigInteger> amount, CancellationTokenSource cancellationToken = null)
        {
            var mintSharesFunction = new MintSharesFunction();
                mintSharesFunction.To = to;
                mintSharesFunction.Amount = amount;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(mintSharesFunction, cancellationToken);
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

        public Task<string> OwnerQueryAsync(OwnerFunction ownerFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(ownerFunction, blockParameter);
        }

        
        public Task<string> OwnerQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(null, blockParameter);
        }

        public Task<string> ProcessProposalRequestAsync(ProcessProposalFunction processProposalFunction)
        {
             return ContractHandler.SendRequestAsync(processProposalFunction);
        }

        public Task<TransactionReceipt> ProcessProposalRequestAndWaitForReceiptAsync(ProcessProposalFunction processProposalFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(processProposalFunction, cancellationToken);
        }

        public Task<string> ProcessProposalRequestAsync(uint id, byte[] proposalData)
        {
            var processProposalFunction = new ProcessProposalFunction();
                processProposalFunction.Id = id;
                processProposalFunction.ProposalData = proposalData;
            
             return ContractHandler.SendRequestAsync(processProposalFunction);
        }

        public Task<TransactionReceipt> ProcessProposalRequestAndWaitForReceiptAsync(uint id, byte[] proposalData, CancellationTokenSource cancellationToken = null)
        {
            var processProposalFunction = new ProcessProposalFunction();
                processProposalFunction.Id = id;
                processProposalFunction.ProposalData = proposalData;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(processProposalFunction, cancellationToken);
        }

        public Task<uint> ProposalCountQueryAsync(ProposalCountFunction proposalCountFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ProposalCountFunction, uint>(proposalCountFunction, blockParameter);
        }

        
        public Task<uint> ProposalCountQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ProposalCountFunction, uint>(null, blockParameter);
        }

        public Task<BigInteger> ProposalOfferingQueryAsync(ProposalOfferingFunction proposalOfferingFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ProposalOfferingFunction, BigInteger>(proposalOfferingFunction, blockParameter);
        }

        
        public Task<BigInteger> ProposalOfferingQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ProposalOfferingFunction, BigInteger>(null, blockParameter);
        }

        public Task<ProposalsOutputDTO> ProposalsQueryAsync(ProposalsFunction proposalsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<ProposalsFunction, ProposalsOutputDTO>(proposalsFunction, blockParameter);
        }

        public Task<ProposalsOutputDTO> ProposalsQueryAsync(BigInteger returnValue1, BlockParameter blockParameter = null)
        {
            var proposalsFunction = new ProposalsFunction();
                proposalsFunction.ReturnValue1 = returnValue1;
            
            return ContractHandler.QueryDeserializingToObjectAsync<ProposalsFunction, ProposalsOutputDTO>(proposalsFunction, blockParameter);
        }

        public Task<BigInteger> QuorumPercentQueryAsync(QuorumPercentFunction quorumPercentFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<QuorumPercentFunction, BigInteger>(quorumPercentFunction, blockParameter);
        }

        
        public Task<BigInteger> QuorumPercentQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<QuorumPercentFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> RagequitRequestAsync(RagequitFunction ragequitFunction)
        {
             return ContractHandler.SendRequestAsync(ragequitFunction);
        }

        public Task<TransactionReceipt> RagequitRequestAndWaitForReceiptAsync(RagequitFunction ragequitFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(ragequitFunction, cancellationToken);
        }

        public Task<string> RagequitRequestAsync(string to, BigInteger sharesToBurn, BigInteger lootToBurn, List<string> tokens)
        {
            var ragequitFunction = new RagequitFunction();
                ragequitFunction.To = to;
                ragequitFunction.SharesToBurn = sharesToBurn;
                ragequitFunction.LootToBurn = lootToBurn;
                ragequitFunction.Tokens = tokens;
            
             return ContractHandler.SendRequestAsync(ragequitFunction);
        }

        public Task<TransactionReceipt> RagequitRequestAndWaitForReceiptAsync(string to, BigInteger sharesToBurn, BigInteger lootToBurn, List<string> tokens, CancellationTokenSource cancellationToken = null)
        {
            var ragequitFunction = new RagequitFunction();
                ragequitFunction.To = to;
                ragequitFunction.SharesToBurn = sharesToBurn;
                ragequitFunction.LootToBurn = lootToBurn;
                ragequitFunction.Tokens = tokens;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(ragequitFunction, cancellationToken);
        }

        public Task<string> RenounceOwnershipRequestAsync(RenounceOwnershipFunction renounceOwnershipFunction)
        {
             return ContractHandler.SendRequestAsync(renounceOwnershipFunction);
        }

        public Task<string> RenounceOwnershipRequestAsync()
        {
             return ContractHandler.SendRequestAsync<RenounceOwnershipFunction>();
        }

        public Task<TransactionReceipt> RenounceOwnershipRequestAndWaitForReceiptAsync(RenounceOwnershipFunction renounceOwnershipFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(renounceOwnershipFunction, cancellationToken);
        }

        public Task<TransactionReceipt> RenounceOwnershipRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<RenounceOwnershipFunction>(null, cancellationToken);
        }

        public Task<string> SetAdminConfigRequestAsync(SetAdminConfigFunction setAdminConfigFunction)
        {
             return ContractHandler.SendRequestAsync(setAdminConfigFunction);
        }

        public Task<TransactionReceipt> SetAdminConfigRequestAndWaitForReceiptAsync(SetAdminConfigFunction setAdminConfigFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setAdminConfigFunction, cancellationToken);
        }

        public Task<string> SetAdminConfigRequestAsync(bool pauseShares, bool pauseLoot)
        {
            var setAdminConfigFunction = new SetAdminConfigFunction();
                setAdminConfigFunction.PauseShares = pauseShares;
                setAdminConfigFunction.PauseLoot = pauseLoot;
            
             return ContractHandler.SendRequestAsync(setAdminConfigFunction);
        }

        public Task<TransactionReceipt> SetAdminConfigRequestAndWaitForReceiptAsync(bool pauseShares, bool pauseLoot, CancellationTokenSource cancellationToken = null)
        {
            var setAdminConfigFunction = new SetAdminConfigFunction();
                setAdminConfigFunction.PauseShares = pauseShares;
                setAdminConfigFunction.PauseLoot = pauseLoot;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setAdminConfigFunction, cancellationToken);
        }

        public Task<string> SetAvatarRequestAsync(SetAvatarFunction setAvatarFunction)
        {
             return ContractHandler.SendRequestAsync(setAvatarFunction);
        }

        public Task<TransactionReceipt> SetAvatarRequestAndWaitForReceiptAsync(SetAvatarFunction setAvatarFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setAvatarFunction, cancellationToken);
        }

        public Task<string> SetAvatarRequestAsync(string avatar)
        {
            var setAvatarFunction = new SetAvatarFunction();
                setAvatarFunction.Avatar = avatar;
            
             return ContractHandler.SendRequestAsync(setAvatarFunction);
        }

        public Task<TransactionReceipt> SetAvatarRequestAndWaitForReceiptAsync(string avatar, CancellationTokenSource cancellationToken = null)
        {
            var setAvatarFunction = new SetAvatarFunction();
                setAvatarFunction.Avatar = avatar;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setAvatarFunction, cancellationToken);
        }

        public Task<string> SetGovernanceConfigRequestAsync(SetGovernanceConfigFunction setGovernanceConfigFunction)
        {
             return ContractHandler.SendRequestAsync(setGovernanceConfigFunction);
        }

        public Task<TransactionReceipt> SetGovernanceConfigRequestAndWaitForReceiptAsync(SetGovernanceConfigFunction setGovernanceConfigFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setGovernanceConfigFunction, cancellationToken);
        }

        public Task<string> SetGovernanceConfigRequestAsync(byte[] governanceConfig)
        {
            var setGovernanceConfigFunction = new SetGovernanceConfigFunction();
                setGovernanceConfigFunction.GovernanceConfig = governanceConfig;
            
             return ContractHandler.SendRequestAsync(setGovernanceConfigFunction);
        }

        public Task<TransactionReceipt> SetGovernanceConfigRequestAndWaitForReceiptAsync(byte[] governanceConfig, CancellationTokenSource cancellationToken = null)
        {
            var setGovernanceConfigFunction = new SetGovernanceConfigFunction();
                setGovernanceConfigFunction.GovernanceConfig = governanceConfig;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setGovernanceConfigFunction, cancellationToken);
        }

        public Task<string> SetGuardRequestAsync(SetGuardFunction setGuardFunction)
        {
             return ContractHandler.SendRequestAsync(setGuardFunction);
        }

        public Task<TransactionReceipt> SetGuardRequestAndWaitForReceiptAsync(SetGuardFunction setGuardFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setGuardFunction, cancellationToken);
        }

        public Task<string> SetGuardRequestAsync(string guard)
        {
            var setGuardFunction = new SetGuardFunction();
                setGuardFunction.Guard = guard;
            
             return ContractHandler.SendRequestAsync(setGuardFunction);
        }

        public Task<TransactionReceipt> SetGuardRequestAndWaitForReceiptAsync(string guard, CancellationTokenSource cancellationToken = null)
        {
            var setGuardFunction = new SetGuardFunction();
                setGuardFunction.Guard = guard;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setGuardFunction, cancellationToken);
        }

        public Task<string> SetShamansRequestAsync(SetShamansFunction setShamansFunction)
        {
             return ContractHandler.SendRequestAsync(setShamansFunction);
        }

        public Task<TransactionReceipt> SetShamansRequestAndWaitForReceiptAsync(SetShamansFunction setShamansFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setShamansFunction, cancellationToken);
        }

        public Task<string> SetShamansRequestAsync(List<string> shamans, List<BigInteger> permissions)
        {
            var setShamansFunction = new SetShamansFunction();
                setShamansFunction.Shamans = shamans;
                setShamansFunction.Permissions = permissions;
            
             return ContractHandler.SendRequestAsync(setShamansFunction);
        }

        public Task<TransactionReceipt> SetShamansRequestAndWaitForReceiptAsync(List<string> shamans, List<BigInteger> permissions, CancellationTokenSource cancellationToken = null)
        {
            var setShamansFunction = new SetShamansFunction();
                setShamansFunction.Shamans = shamans;
                setShamansFunction.Permissions = permissions;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setShamansFunction, cancellationToken);
        }

        public Task<string> SetTargetRequestAsync(SetTargetFunction setTargetFunction)
        {
             return ContractHandler.SendRequestAsync(setTargetFunction);
        }

        public Task<TransactionReceipt> SetTargetRequestAndWaitForReceiptAsync(SetTargetFunction setTargetFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setTargetFunction, cancellationToken);
        }

        public Task<string> SetTargetRequestAsync(string target)
        {
            var setTargetFunction = new SetTargetFunction();
                setTargetFunction.Target = target;
            
             return ContractHandler.SendRequestAsync(setTargetFunction);
        }

        public Task<TransactionReceipt> SetTargetRequestAndWaitForReceiptAsync(string target, CancellationTokenSource cancellationToken = null)
        {
            var setTargetFunction = new SetTargetFunction();
                setTargetFunction.Target = target;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setTargetFunction, cancellationToken);
        }

        public Task<string> SetUpRequestAsync(SetUpFunction setUpFunction)
        {
             return ContractHandler.SendRequestAsync(setUpFunction);
        }

        public Task<TransactionReceipt> SetUpRequestAndWaitForReceiptAsync(SetUpFunction setUpFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setUpFunction, cancellationToken);
        }

        public Task<string> SetUpRequestAsync(byte[] initializationParams)
        {
            var setUpFunction = new SetUpFunction();
                setUpFunction.InitializationParams = initializationParams;
            
             return ContractHandler.SendRequestAsync(setUpFunction);
        }

        public Task<TransactionReceipt> SetUpRequestAndWaitForReceiptAsync(byte[] initializationParams, CancellationTokenSource cancellationToken = null)
        {
            var setUpFunction = new SetUpFunction();
                setUpFunction.InitializationParams = initializationParams;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setUpFunction, cancellationToken);
        }

        public Task<BigInteger> ShamansQueryAsync(ShamansFunction shamansFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ShamansFunction, BigInteger>(shamansFunction, blockParameter);
        }

        
        public Task<BigInteger> ShamansQueryAsync(string returnValue1, BlockParameter blockParameter = null)
        {
            var shamansFunction = new ShamansFunction();
                shamansFunction.ReturnValue1 = returnValue1;
            
            return ContractHandler.QueryAsync<ShamansFunction, BigInteger>(shamansFunction, blockParameter);
        }

        public Task<bool> SharesPausedQueryAsync(SharesPausedFunction sharesPausedFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SharesPausedFunction, bool>(sharesPausedFunction, blockParameter);
        }

        
        public Task<bool> SharesPausedQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SharesPausedFunction, bool>(null, blockParameter);
        }

        public Task<string> SharesTokenQueryAsync(SharesTokenFunction sharesTokenFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SharesTokenFunction, string>(sharesTokenFunction, blockParameter);
        }

        
        public Task<string> SharesTokenQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SharesTokenFunction, string>(null, blockParameter);
        }

        public Task<string> SponsorProposalRequestAsync(SponsorProposalFunction sponsorProposalFunction)
        {
             return ContractHandler.SendRequestAsync(sponsorProposalFunction);
        }

        public Task<TransactionReceipt> SponsorProposalRequestAndWaitForReceiptAsync(SponsorProposalFunction sponsorProposalFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(sponsorProposalFunction, cancellationToken);
        }

        public Task<string> SponsorProposalRequestAsync(uint id)
        {
            var sponsorProposalFunction = new SponsorProposalFunction();
                sponsorProposalFunction.Id = id;
            
             return ContractHandler.SendRequestAsync(sponsorProposalFunction);
        }

        public Task<TransactionReceipt> SponsorProposalRequestAndWaitForReceiptAsync(uint id, CancellationTokenSource cancellationToken = null)
        {
            var sponsorProposalFunction = new SponsorProposalFunction();
                sponsorProposalFunction.Id = id;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(sponsorProposalFunction, cancellationToken);
        }

        public Task<BigInteger> SponsorThresholdQueryAsync(SponsorThresholdFunction sponsorThresholdFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SponsorThresholdFunction, BigInteger>(sponsorThresholdFunction, blockParameter);
        }

        
        public Task<BigInteger> SponsorThresholdQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SponsorThresholdFunction, BigInteger>(null, blockParameter);
        }

        public Task<byte> StateQueryAsync(StateFunction stateFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<StateFunction, byte>(stateFunction, blockParameter);
        }

        
        public Task<byte> StateQueryAsync(uint id, BlockParameter blockParameter = null)
        {
            var stateFunction = new StateFunction();
                stateFunction.Id = id;
            
            return ContractHandler.QueryAsync<StateFunction, byte>(stateFunction, blockParameter);
        }

        public Task<string> SubmitProposalRequestAsync(SubmitProposalFunction submitProposalFunction)
        {
             return ContractHandler.SendRequestAsync(submitProposalFunction);
        }

        public Task<TransactionReceipt> SubmitProposalRequestAndWaitForReceiptAsync(SubmitProposalFunction submitProposalFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(submitProposalFunction, cancellationToken);
        }

        public Task<string> SubmitProposalRequestAsync(byte[] proposalData, uint expiration, BigInteger baalGas, string details)
        {
            var submitProposalFunction = new SubmitProposalFunction();
                submitProposalFunction.ProposalData = proposalData;
                submitProposalFunction.Expiration = expiration;
                submitProposalFunction.BaalGas = baalGas;
                submitProposalFunction.Details = details;
            
             return ContractHandler.SendRequestAsync(submitProposalFunction);
        }

        public Task<TransactionReceipt> SubmitProposalRequestAndWaitForReceiptAsync(byte[] proposalData, uint expiration, BigInteger baalGas, string details, CancellationTokenSource cancellationToken = null)
        {
            var submitProposalFunction = new SubmitProposalFunction();
                submitProposalFunction.ProposalData = proposalData;
                submitProposalFunction.Expiration = expiration;
                submitProposalFunction.BaalGas = baalGas;
                submitProposalFunction.Details = details;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(submitProposalFunction, cancellationToken);
        }

        public Task<string> SubmitVoteRequestAsync(SubmitVoteFunction submitVoteFunction)
        {
             return ContractHandler.SendRequestAsync(submitVoteFunction);
        }

        public Task<TransactionReceipt> SubmitVoteRequestAndWaitForReceiptAsync(SubmitVoteFunction submitVoteFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(submitVoteFunction, cancellationToken);
        }

        public Task<string> SubmitVoteRequestAsync(uint id, bool approved)
        {
            var submitVoteFunction = new SubmitVoteFunction();
                submitVoteFunction.Id = id;
                submitVoteFunction.Approved = approved;
            
             return ContractHandler.SendRequestAsync(submitVoteFunction);
        }

        public Task<TransactionReceipt> SubmitVoteRequestAndWaitForReceiptAsync(uint id, bool approved, CancellationTokenSource cancellationToken = null)
        {
            var submitVoteFunction = new SubmitVoteFunction();
                submitVoteFunction.Id = id;
                submitVoteFunction.Approved = approved;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(submitVoteFunction, cancellationToken);
        }

        public Task<string> SubmitVoteWithSigRequestAsync(SubmitVoteWithSigFunction submitVoteWithSigFunction)
        {
             return ContractHandler.SendRequestAsync(submitVoteWithSigFunction);
        }

        public Task<TransactionReceipt> SubmitVoteWithSigRequestAndWaitForReceiptAsync(SubmitVoteWithSigFunction submitVoteWithSigFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(submitVoteWithSigFunction, cancellationToken);
        }

        public Task<string> SubmitVoteWithSigRequestAsync(uint id, bool approved, byte[] signature)
        {
            var submitVoteWithSigFunction = new SubmitVoteWithSigFunction();
                submitVoteWithSigFunction.Id = id;
                submitVoteWithSigFunction.Approved = approved;
                submitVoteWithSigFunction.Signature = signature;
            
             return ContractHandler.SendRequestAsync(submitVoteWithSigFunction);
        }

        public Task<TransactionReceipt> SubmitVoteWithSigRequestAndWaitForReceiptAsync(uint id, bool approved, byte[] signature, CancellationTokenSource cancellationToken = null)
        {
            var submitVoteWithSigFunction = new SubmitVoteWithSigFunction();
                submitVoteWithSigFunction.Id = id;
                submitVoteWithSigFunction.Approved = approved;
                submitVoteWithSigFunction.Signature = signature;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(submitVoteWithSigFunction, cancellationToken);
        }

        public Task<string> TargetQueryAsync(TargetFunction targetFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TargetFunction, string>(targetFunction, blockParameter);
        }

        
        public Task<string> TargetQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TargetFunction, string>(null, blockParameter);
        }

        public Task<BigInteger> TotalLootQueryAsync(TotalLootFunction totalLootFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TotalLootFunction, BigInteger>(totalLootFunction, blockParameter);
        }

        
        public Task<BigInteger> TotalLootQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TotalLootFunction, BigInteger>(null, blockParameter);
        }

        public Task<BigInteger> TotalSharesQueryAsync(TotalSharesFunction totalSharesFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TotalSharesFunction, BigInteger>(totalSharesFunction, blockParameter);
        }

        
        public Task<BigInteger> TotalSharesQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TotalSharesFunction, BigInteger>(null, blockParameter);
        }

        public Task<BigInteger> TotalSupplyQueryAsync(TotalSupplyFunction totalSupplyFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TotalSupplyFunction, BigInteger>(totalSupplyFunction, blockParameter);
        }

        
        public Task<BigInteger> TotalSupplyQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TotalSupplyFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> TransferOwnershipRequestAsync(TransferOwnershipFunction transferOwnershipFunction)
        {
             return ContractHandler.SendRequestAsync(transferOwnershipFunction);
        }

        public Task<TransactionReceipt> TransferOwnershipRequestAndWaitForReceiptAsync(TransferOwnershipFunction transferOwnershipFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferOwnershipFunction, cancellationToken);
        }

        public Task<string> TransferOwnershipRequestAsync(string newOwner)
        {
            var transferOwnershipFunction = new TransferOwnershipFunction();
                transferOwnershipFunction.NewOwner = newOwner;
            
             return ContractHandler.SendRequestAsync(transferOwnershipFunction);
        }

        public Task<TransactionReceipt> TransferOwnershipRequestAndWaitForReceiptAsync(string newOwner, CancellationTokenSource cancellationToken = null)
        {
            var transferOwnershipFunction = new TransferOwnershipFunction();
                transferOwnershipFunction.NewOwner = newOwner;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferOwnershipFunction, cancellationToken);
        }

        public Task<uint> VotingPeriodQueryAsync(VotingPeriodFunction votingPeriodFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<VotingPeriodFunction, uint>(votingPeriodFunction, blockParameter);
        }

        
        public Task<uint> VotingPeriodQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<VotingPeriodFunction, uint>(null, blockParameter);
        }
    }
}
