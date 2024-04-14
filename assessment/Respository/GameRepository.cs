using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Respository
{
    using Contracts;

    using Dapper;

    using Shared.DataTransferObjects.Game;
    using Shared.DataTransferObjects.Payment;
    using System.ComponentModel.Design;
    using System.Data;

    public class GameRepository:IGameRepository
    {
        private readonly DapperContext _context;

        public GameRepository(DapperContext Context)
        {
            _context = Context;
        }

        public Task ShowPreviousSpins(PreviousSpinRequestDto spinHistory)
        {
            return Task.CompletedTask;
            //var query = PlayerQuery.SelectPlayerByIdAndGameIdQuery;

            //using (var connection = _context.CreateConnection())
            //{
            //    var param = new { gameId, id };
            //    var spins = await connection.QuerySingleOrDefaultAsync<SpinDto>(query, param);

            //    return spins;
            //}
        }

        public Task Spin(SpinRequestDto spin)
        {
            return Task.CompletedTask;
            //var query = PlayerQuery.InsertPlayerWithOutputQuery;

            //var param = new DynamicParameters(playerDto);
            //param.Add("id", gameId, DbType.Guid);

            //using (var connection = _context.CreateConnection())
            //{
            //    var id = await connection.QuerySingleAsync<Guid>(query, param);

            //    return new PlayerDto(id, playerDto.Name,
            //        playerDto.Age, playerDto.Position);
            //}
        }
    }
}
