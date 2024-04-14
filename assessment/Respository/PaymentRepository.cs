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

    public class PaymentRepository:IPaymentRepository
    {
        private readonly DapperContext _context;

        public PaymentRepository(DapperContext Context)
        {
            _context = Context;
        }

        public async Task Payout(PayoutRequestDto player)
        {

            //var query = PlayerQuery.InsertPlayerQuery;

            //var param = new DynamicParameters(player);

            //using (var connection = _context.CreateConnection())
            //{
            //    connection.Open();

            //    using (var trans = connection.BeginTransaction())
            //    {
            //        var id = await connection
            //                     .QuerySingleAsync<Guid>(query, param, transaction: trans);

            //        var queryEmp = PaymentQuery.InsertPaymentNoOutputQuery;

            //        var empList = player.Payments
            //            .Select(e => new { e.Name, e.Age, e.Position, id });

            //        await connection.ExecuteAsync(queryEmp, empList, transaction: trans);

            //        trans.Commit();

            //        return new PlayerDto(id, player.Name,
            //            string.Join(", ", player.Address, player.Country));
            //    }
            //}
        }
    }
}
