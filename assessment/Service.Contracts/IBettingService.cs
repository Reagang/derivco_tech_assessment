using Shared.DataTransferObjects.Betting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IBettingService
    {
        Task<PlaceBetDto> PlaceBet(PlaceBetRequestDto request);
    }
}
