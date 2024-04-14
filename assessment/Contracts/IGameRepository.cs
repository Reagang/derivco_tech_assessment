using Shared.DataTransferObjects.Game;
using Shared.DataTransferObjects.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IGameRepository
    {
        Task Spin(SpinRequestDto spin);
        Task ShowPreviousSpins(PreviousSpinRequestDto spinHistory);
    }
}
