using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Respository
{
    using Contracts;
    using Dapper;

    using Shared.DataTransferObjects.Betting;

    public class BettingRepository : IBettingRepository
    {
        private readonly DapperContext _context;

        public BettingRepository(DapperContext Context)
        {
            _context = Context;
        }

        public async Task<PlaceBetDto> PlaceBet(PlaceBetRequestDto bet)
        {
            return null;
            //var query = playerQuery.InsertPlayerQuery;

            //var param = new DynamicParameters(player);

            //using (var connection = _context.CreateConnection())
            //{
            //    var id = await connection.QuerySingleAsync<Guid>(query, param);

            //    return new BettingDto(id, player.Name,
            //        string.Join(", ", player.Address, player.Country));
            //}
        }
    }
}
