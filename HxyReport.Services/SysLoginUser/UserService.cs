using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HxyReport.Data;
using HxyReport.Data.AppOffice;
using HxyReport.Data.E7HR;

namespace HxyReport.Services.Users
{
    public class UserService : IUserService
    {
        private readonly Func<IAppOfficeUnitOfWork> _AppOfficeUnitOfwork;
        private readonly Func<IE7HRUnitOfWork> _E7HRUnitOfWork;
        public UserService(Func<IAppOfficeUnitOfWork> appOfficeUnitOfwork, Func<IE7HRUnitOfWork> e7HRUnitOfWork)
        {
            _AppOfficeUnitOfwork = appOfficeUnitOfwork;
            _E7HRUnitOfWork = e7HRUnitOfWork;
        }
        public SysLoginUser GetModel(int Id)
        {
            var user = new SysLoginUser();

            using (var app = _AppOfficeUnitOfwork())
            {
                user = app.SysLoginUserDap.GetByEmpIDIndex(Id);
                app.Commit();
            }

            return user;
        }

        public EmpInfo GetEmpModel(int Id)
        {
            var empInfo = new EmpInfo();

            using (var app = _E7HRUnitOfWork())
            {
                empInfo = app.EmpInfoDap.GetByEmpId(Id);
                app.Commit();
            }

            return empInfo;
        }
    }
}
