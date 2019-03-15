using System;
using System.Data;

namespace HxyReport.Data.E7HR
{
      /// <summary>
      /// Unit of Work 接口
      /// </summary>
    public interface IE7HRUnitOfWork : IDisposable
    {
        void Commit();
	  	EmpInfoDap EmpInfoDap { get;}
    }
}
