using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace HxyReport.Data.E7HR
{
    /// <summary>
    /// Unit Of Work 实现
    /// </summary>
    public class E7HRUnitOfWork : IE7HRUnitOfWork, IDisposable
    {
        private IDbConnection _connection;
        private IDbTransaction _transaction;
        private bool _disposed;
        public E7HRUnitOfWork()
        {
            //用什么数据库，在这里调整
            _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["E7HR"].ConnectionString);
            OpenConnection();
            BeginTransaction();
        }
        public E7HRUnitOfWork(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
            OpenConnection();
            BeginTransaction();
        }
        #region Repository

        private EmpInfoDap _EmpInfoDap;

        public EmpInfoDap EmpInfoDap
        {
            get { return _EmpInfoDap ?? (_EmpInfoDap = new EmpInfoDap(_transaction)); }
        }

        #endregion
        private void ResetRepositories()
        {
            _EmpInfoDap = null;
        }
        protected void OpenConnection()
        {
            if (_connection != null && _connection.State != ConnectionState.Open)
                _connection.Open();
        }
        protected IDbTransaction BeginTransaction()
        {
            _transaction = _connection.BeginTransaction();
            return _transaction;
        }
        public void Commit()
        {
            try
            {
                _transaction.Commit();
            }
            catch
            {
                _transaction.Rollback();
                throw;
            }
            finally
            {
                _transaction.Dispose();
                _transaction = _connection.BeginTransaction();
                ResetRepositories();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_transaction != null)
                    {
                        _transaction.Dispose();
                        _transaction = null;
                    }
                    if (_connection != null)
                    {
                        _connection.Dispose();
                        _connection = null;
                    }
                }
                _disposed = true;
            }
        }

        ~E7HRUnitOfWork()
        {
            Dispose(false);
        }
    }
}
