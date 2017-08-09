using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DienChanOnline.Models;
using PetaPoco;

namespace DienChanOnline.DAL
{
    public interface ICustomerAccountQuery
    {
        bool CheckLoginInfo(string email, string password);
    }

    public class CustomerAccountQuery:QueryBase, ICustomerAccountQuery
    {
        public bool CheckLoginInfo(string email, string password)
        {
            var query =
                Sql.Builder.Append(
                    @"Select Count(*) from DienChanOnline..CustomerAccount (NOLOCK) where Email = @0 and Password = @1",
                    email, password);

            return Db().ExecuteScalar<int>(query) > 0;
        }
    }
}
