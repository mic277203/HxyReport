using System;
using System.Data;

namespace HxyReport.Data.AppOffice
{
    /// <summary>
    /// Unit of Work 接口
    /// </summary>
    public interface IAppOfficeUnitOfWork : IDisposable
    {
        void Commit();
        SysLoginUserDap SysLoginUserDap { get; }
    }
}
