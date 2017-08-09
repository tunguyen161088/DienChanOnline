using System;
using System.Collections.Generic;
using DienChanOnline.Models;
using PetaPoco;

namespace DienChanOnline.DAL
{
    public interface ICustomerInfoQuery
    {
        void SaveCustomerInfo(CustomerInfo model);

        void SaveCustomerInfo(CustomerInfoFrance model);

        void SaveCustomerInfo(CustomerInfoVietnam model);

        List<CustomerInfo> GetCustomersByForm(Guid guidInfo);

        CustomerInfo GetCustomerById(int id);

        void DeleteCustomer(CustomerInfo customer);
    }

    public class CustomerInfoQuery : QueryBase, ICustomerInfoQuery
    {
        public void SaveCustomerInfo(CustomerInfo model)
        {
            Db().Save(model);
        }

        public void SaveCustomerInfo(CustomerInfoFrance model)
        {
            Db().Save(model);
        }

        public void SaveCustomerInfo(CustomerInfoVietnam model)
        {
            Db().Save(model);
        }

        public List<CustomerInfo> GetCustomersByForm(Guid guidInfo)
        {
            var query =
                Sql.Builder.Append(@"Select * from DienChanOnline..CustomerInfo (NOLOCK) where FormGuidInfo = @0",
                    guidInfo);

            return Db().Fetch<CustomerInfo>(query);
        }

        public CustomerInfo GetCustomerById(int id)
        {
            var query = Sql.Builder.Append(@"Select Top 1 * From DienChanOnline..CustomerInfo (NOLOCK) where Id = @0",
                id);

            return Db().SingleOrDefault<CustomerInfo>(query);
        }

        public void DeleteCustomer(CustomerInfo customer)
        {
            Db().Delete(customer);
        }
    }
}
