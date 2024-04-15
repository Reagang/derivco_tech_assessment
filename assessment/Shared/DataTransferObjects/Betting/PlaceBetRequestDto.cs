using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.Betting
{
    using System.ComponentModel.DataAnnotations;

    public class PlaceBetRequestDto
    {
        [Required]
        public string PlayerId { get; set; }
        [Required]
        public string BetType { get; set; }
        [Required]
        public decimal BetAmount { get; set; }
        [Required]
        public int BetNumber { get; set; }
    }
}
