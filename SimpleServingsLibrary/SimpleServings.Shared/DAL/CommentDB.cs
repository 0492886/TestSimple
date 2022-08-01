using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using SimpleServingsLibrary.Shared;

namespace SimpleServingsLibrary.Shared
{
    class CommentDB
    {
        internal static SqlDataReader GetCommentByActionCode(int actionCode)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Get_CommentByActionCode");
                db.AddInParameter(cmd, "@ActionCode", System.Data.DbType.Int32, actionCode);
                return (SqlDataReader)db.ExecuteReader(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static SqlDataReader GetAssignedToEmailByContracyID(int contractId)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Get_AssignedToByContractId");
                db.AddInParameter(cmd, "@contractId", System.Data.DbType.Int32, contractId);
                return (SqlDataReader)db.ExecuteReader(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
