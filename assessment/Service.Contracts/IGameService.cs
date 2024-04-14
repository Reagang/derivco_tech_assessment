using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    using Shared.DataTransferObjects.Game;
    using Shared.DataTransferObjects.Payment;

    public interface IGameService
    {
        Task Spin(SpinRequestDto spin);
        Task ShowPreviousSpins(PreviousSpinRequestDto spinHistory);
    }
}
