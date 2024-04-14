using Shared.DataTransferObjects.Betting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IBettingRepository
    {
        Task<PlaceBetDto> PlaceBet(PlaceBetRequestDto request);
    }
}
