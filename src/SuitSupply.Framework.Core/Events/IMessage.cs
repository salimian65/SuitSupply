using System;

namespace SuitSupply.Framework.Core.Events
{
    public interface IMessage
    {
        DateTime TimeStamp { get; }
    }
}