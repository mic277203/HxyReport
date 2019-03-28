using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using HxyReport.Core;
using System.Linq;

namespace HxyReport.Data
{
    public partial class HxyReportBaseDap : IDisposable
    {
        private IDbConnection _connection;
        private IDbTransaction _transaction;

        protected HxyReportBaseDap()
        {
            Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["HxyReport"].ConnectionString);
        }

        protected IDbConnection Connection
        {
            get { return _connection; }
            set { _connection = value; }
        }

        protected IDbTransaction Transaction
        {
            get { return _transaction; }
            set
            {
                _transaction = value;
                if (_transaction != null)
                    _connection = _transaction.Connection;
            }
        }
        /// <summary>
        /// 单表分页查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="p"></param>
        /// <returns></returns>
        protected PageList<T> GetPager<T>(MsSqlPaginParam p) where T : class
        {
            PageList<T> result = new PageList<T>();

            OpenConnection();
            try
            {
                var param = ObjectHelper.DynamicExtend(p.WhereParam,
                    new { PageIndex = p.PageIndex, PageSize = p.PageSize });

                var multi = SqlMapper.QueryMultiple(_connection, p.ToSingleString(), (object)param);

                result.Results = multi.Read<T>().ToList();
                result.TotalCount = multi.Read<int>().FirstOrDefault();
            }
            finally
            {
                CloseConnection();
            }

            return result;
        }

        /// <summary>
        /// 多表关联分页查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="p"></param>
        /// <returns></returns>
        protected PageList<T> GetJoinPager<T>(MsSqlPaginParam p) where T : class
        {
            PageList<T> result = new PageList<T>();

            OpenConnection();
            try
            {
                var param = ObjectHelper.DynamicExtend(p.WhereParam,
                    new { PageIndex = p.PageIndex, PageSize = p.PageSize });

                var multi = SqlMapper.QueryMultiple(_connection, p.ToJoinString(), (object)param);

                result.Results = multi.Read<T>().ToList();
                result.TotalCount = multi.Read<int>().FirstOrDefault();
            }
            finally
            {
                CloseConnection();
            }

            return result;
        }
        protected IDbTransaction BeginTransaction()
        {
            OpenConnection();
            _transaction = _connection.BeginTransaction();
            return _transaction;
        }

        protected IDbTransaction BeginTransaction(IsolationLevel isolationLevel)
        {
            OpenConnection();
            _transaction = _connection.BeginTransaction(isolationLevel);
            return _transaction;
        }

        /// <summary>
        /// Execute parameterized SQL  
        /// </summary>
        /// <returns>Number of rows affected</returns>
        protected int Execute(string sql, dynamic param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            if (transaction == null)
                transaction = _transaction;

            OpenConnection();
            try
            {
                return SqlMapper.Execute(_connection, sql, param, transaction, commandTimeout, commandType);
            }
            finally
            {
                CloseConnection();
            }
        }

        /// <summary>
        /// Return a list of dynamic objects, reader is closed after the call
        /// </summary>
        protected IEnumerable<dynamic> Query(string sql, dynamic param = null, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
        {
            if (transaction == null)
                transaction = _transaction;

            OpenConnection();
            try
            {
                return SqlMapper.Query(_connection, sql, param, transaction, buffered, commandTimeout, commandType);
            }
            finally
            {
                if (buffered)
                    CloseConnection();
            }
        }

        /// <summary>
        /// Executes a query, returning the data typed as per T
        /// </summary>
        /// <remarks>the dynamic param may seem a bit odd, but this works around a major usability issue in vs, if it is Object vs completion gets annoying. Eg type new [space] get new object</remarks>
        /// <returns>A sequence of data of the supplied type; if a basic type (int, string, etc) is queried then the data from the first column in assumed, otherwise an instance is
        /// created per row, and a direct column-name===member-name mapping is assumed (case insensitive).
        /// </returns>
        protected IEnumerable<T> Query<T>(string sql, dynamic param = null, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
        {
            if (transaction == null)
                transaction = _transaction;

            OpenConnection();
            try
            {
                return SqlMapper.Query<T>(_connection, sql, param, transaction, buffered, commandTimeout, commandType);
            }
            finally
            {
                if (buffered)
                    CloseConnection();
            }
        }

        /// <summary>
        /// Maps a query to objects
        /// </summary>
        protected IEnumerable<TReturn> Query<TFirst, TSecond, TReturn>(string sql, Func<TFirst, TSecond, TReturn> map, dynamic param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            if (transaction == null)
                transaction = _transaction;

            OpenConnection();
            try
            {
                return SqlMapper.Query<TFirst, TSecond, TReturn>(_connection, sql, map, param, transaction, buffered, splitOn,
                                                                 commandTimeout, commandType);
            }
            finally
            {
                if (buffered)
                    CloseConnection();
            }
        }

        /// <summary>
        /// Perform a multi mapping query with 5 input parameters
        /// </summary>
        protected IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TReturn> map, dynamic param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            if (transaction == null)
                transaction = _transaction;

            OpenConnection();
            try
            {
                return SqlMapper.Query<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(_connection, sql, map, param, transaction, buffered, splitOn,
                                                                 commandTimeout, commandType);
            }
            finally
            {
                if (buffered)
                    CloseConnection();
            }
        }

        /// <summary>
        /// Perform a multi mapping query with 4 input parameters
        /// </summary>
        protected IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TReturn>(string sql, Func<TFirst, TSecond, TThird, TFourth, TReturn> map, dynamic param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            if (transaction == null)
                transaction = _transaction;

            OpenConnection();
            try
            {
                return SqlMapper.Query<TFirst, TSecond, TThird, TFourth, TReturn>(_connection, sql, map, param, transaction, buffered, splitOn,
                                                                 commandTimeout, commandType);
            }
            finally
            {
                if (buffered)
                    CloseConnection();
            }
        }

        /// <summary>
        /// Maps a query to objects
        /// </summary>
        protected IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TReturn>(string sql, Func<TFirst, TSecond, TThird, TReturn> map, dynamic param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            if (transaction == null)
                transaction = _transaction;

            OpenConnection();
            try
            {
                return SqlMapper.Query<TFirst, TSecond, TThird, TReturn>(_connection, sql, map, param, transaction, buffered, splitOn,
                                                                 commandTimeout, commandType);
            }
            finally
            {
                if (buffered)
                    CloseConnection();
            }
        }

        /// <summary>
        /// Execute a command that returns multiple result sets, and access each in turn
        /// </summary>
        protected SqlMapper.GridReader QueryMultiple(string sql, dynamic param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            if (transaction == null)
                transaction = _transaction;

            OpenConnection();

            return SqlMapper.QueryMultiple(_connection, sql, param, transaction, commandTimeout, commandType);
        }

        protected void OpenConnection()
        {
            if (_connection != null && _connection.State != ConnectionState.Open)
                _connection.Open();
        }

        protected void CloseConnection()
        {
            if (_connection != null)
                _connection.Close();
        }

        public void Dispose()
        {
            if (_transaction != null)
                _transaction.Dispose();

            if (_connection != null)
                _connection.Dispose();

            _transaction = null;
            _connection = null;
        }
    }
}
