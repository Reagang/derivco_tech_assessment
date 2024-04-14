using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.Betting
{
    public class PlaceBetRequestDto
    {
        public string PlayerId { get; set; }
        public string BetType { get; set; }
        public decimal BetAmount { get; set; }
        public int BetNumber { get; set; }
    }
}
