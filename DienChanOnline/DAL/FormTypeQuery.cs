using System;
using System.Collections.Generic;
using DienChanOnline.Models;
using PetaPoco;

namespace DienChanOnline.DAL
{
    public interface IFormTypeQuery
    {
        List<FormType> GetFormTypes();

        FormType GetFormTypeByGuid(string id);

        void InsertFormType(FormType type);

        void RemoveFormType(FormType type);
    }

    public class FormTypeQuery: QueryBase, IFormTypeQuery
    {
        public List<FormType> GetFormTypes()
        {
            var query = Sql.Builder.Append(@"Select * from dienchanonline..FormType (NOLOCK)");

            return Db().Fetch<FormType>(query);
        }

        public FormType GetFormTypeByGuid(string id)
        {
            var query = Sql.Builder.Append(@"Select Top 1 * from dienchanonline..FormType (NOLOCK) where GuidInfo = @0", id);

            return Db().SingleOrDefault<FormType>(query);
        }

        public void InsertFormType(FormType type)
        {
            Db().Save(type);
        }

        public void RemoveFormType(FormType type)
        {
            Db().Delete(type);
        }
    }
}