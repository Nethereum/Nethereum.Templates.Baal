using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace ExampleBaal.Contracts.Shares.ContractDefinition
{
    public partial class Checkpoint : CheckpointBase { }

    public class CheckpointBase 
    {
        [Parameter("uint32", "fromTimeStamp", 1)]
        public virtual uint FromTimeStamp { get; set; }
        [Parameter("uint256", "votes", 2)]
        public virtual BigInteger Votes { get; set; }
    }
}
