using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts;
using System.Threading;

namespace ExampleBaal.Contracts.RageQuitBank.ContractDefinition
{


    public partial class RageQuitBankDeployment : RageQuitBankDeploymentBase
    {
        public RageQuitBankDeployment() : base(BYTECODE) { }
        public RageQuitBankDeployment(string byteCode) : base(byteCode) { }
    }

    public class RageQuitBankDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "608060405260008054600160a11b6001600160a01b03909116179055600180546001600160601b031916600217905534801561003a57600080fd5b5061027c8061004a6000396000f3fe6080604052600436106100345760003560e01c806319ab453c14610039578063e5a2a2a514610078578063ff4c9884146100b5575b600080fd5b34801561004557600080fd5b5061007661005436600461018d565b600080546001600160a01b0319166001600160a01b0392909216919091179055565b005b34801561008457600080fd5b50600054610098906001600160a01b031681565b6040516001600160a01b0390911681526020015b60405180910390f35b6100c86100c33660046101c6565b6100e8565b604080516001600160601b039384168152929091166020830152016100ac565b6000805481906001600160a01b031633146101315760405162461bcd60e51b8152602060048201526005602482015264085898585b60da1b604482015260640160405180910390fd5b60005461014e90600160a01b90046001600160601b031685610209565b600154909250610167906001600160601b031684610209565b9050935093915050565b80356001600160a01b038116811461018857600080fd5b919050565b60006020828403121561019f57600080fd5b6101a882610171565b9392505050565b80356001600160601b038116811461018857600080fd5b6000806000606084860312156101db57600080fd5b6101e484610171565b92506101f2602085016101af565b9150610200604085016101af565b90509250925092565b60006001600160601b038083168185168183048111821515161561023d57634e487b7160e01b600052601160045260246000fd5b0294935050505056fea2646970667358221220fe10746c3dc8060bd81a29098919793e951794bef5d06413b83f9502845d025964736f6c634300080f0033";
        public RageQuitBankDeploymentBase() : base(BYTECODE) { }
        public RageQuitBankDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class BaalFunction : BaalFunctionBase { }

    [Function("baal", "address")]
    public class BaalFunctionBase : FunctionMessage
    {

    }

    public partial class InitFunction : InitFunctionBase { }

    [Function("init")]
    public class InitFunctionBase : FunctionMessage
    {
        [Parameter("address", "_baal", 1)]
        public virtual string Baal { get; set; }
    }

    public partial class MemberActionFunction : MemberActionFunctionBase { }

    [Function("memberAction", typeof(MemberActionOutputDTO))]
    public class MemberActionFunctionBase : FunctionMessage
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
        [Parameter("uint96", "loot", 2)]
        public virtual BigInteger Loot { get; set; }
        [Parameter("uint96", "shares", 3)]
        public virtual BigInteger Shares { get; set; }
    }

    public partial class BaalOutputDTO : BaalOutputDTOBase { }

    [FunctionOutput]
    public class BaalOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }



    public partial class MemberActionOutputDTO : MemberActionOutputDTOBase { }

    [FunctionOutput]
    public class MemberActionOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint96", "lootOut", 1)]
        public virtual BigInteger LootOut { get; set; }
        [Parameter("uint96", "sharesOut", 2)]
        public virtual BigInteger SharesOut { get; set; }
    }
}
