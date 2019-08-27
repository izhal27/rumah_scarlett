using MySql.Data.MySqlClient;
using RumahScarlett.CommonComponents;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib;

namespace RumahScarlett.Infrastructure.DataAccess.Repositories
{
   public class DbContext : IDisposable
   {
      private IDbConnection _conn;
      private IDbTransaction _transaction;
      private readonly string _connString;
      private readonly string _providerName;

      public IDbConnection Conn
      {
         get { return _conn ?? (_conn = GetOpenConnection(_connString, _providerName)); }
      }

      public IDbTransaction Transaction
      {
         get { return _transaction; }
      }

      public DbContext()
      {
         _providerName = @"MySql.Data.MySqlClient";
         _connString = @"Server=localhost;Database=rumah_scarlett_dev;Uid=root;Pwd=;";

         if (_conn == null)
         {
            _conn = GetOpenConnection(_connString, _providerName);
         }
      }

      private IDbConnection GetOpenConnection(string connString, string providerName)
      {
         IDbConnection conn = null;
         var dataAccessStatus = new DataAccessStatus();

         try
         {
            var provider = DbProviderFactories.GetFactory(providerName);
            conn = provider.CreateConnection();
            conn.ConnectionString = connString;
            conn.Open();
         }
         catch (MySqlException ex)
         {
            dataAccessStatus.SetValues(status: "Error", operationSucceeded: false, exceptionMessage: ex.Message,
                                       customMessage: "Tidak dapat membuka koneksi ke Database.",
                                       helpLink: ex.HelpLink, errorCode: ex.ErrorCode, stackTrace: ex.StackTrace);
            throw new DataAccessException(message: ex.Message, innerException: ex.InnerException,
                                          dataAccessStatus: dataAccessStatus);
         }

         return conn;
      }

      public void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
      {
         if (_transaction == null)
         {
            _transaction = Conn.BeginTransaction(isolationLevel);
         }
      }

      public void Commit()
      {
         if (_transaction != null)
         {
            _transaction.Commit();
            _transaction = null;
         }
      }

      public void RollBack()
      {
         if (_transaction != null)
         {
            _transaction.Rollback();
            _transaction = null;
         }
      }

      public void Dispose()
      {
         if (_conn != null)
         {
            try
            {
               if (_conn.State == ConnectionState.Open)
               {
                  RollBack();
                  _conn.Close();
               }
            }
            finally
            {
               _conn.Dispose();
            }
         }

         GC.SuppressFinalize(this);
      }
   }
}
