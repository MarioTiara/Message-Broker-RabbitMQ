using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormulaAirLine.API.Services
{
    public interface IMessageProducer
    {
        void SendingMessage<T>(T message);
    }
}