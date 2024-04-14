using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    using Shared.DataTransferObjects;

    public interface IServiceManager
    {
        IBettingService BettingService { get; }
        IPaymentService PaymentService { get; }
        IGameService GameService { get; }
    }
}
