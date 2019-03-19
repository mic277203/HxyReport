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
        private readonly ISysLoginUserDap _SysLoginUserDap;
        private readonly IEmpInfoDap _EmpInfoDap;
        public UserService(ISysLoginUserDap sysLoginUserDap, IEmpInfoDap empInfoDap)
        {
            _SysLoginUserDap = sysLoginUserDap;
            _EmpInfoDap = empInfoDap;
        }
        public SysLoginUser GetModel(int Id)
        {
            return _SysLoginUserDap.GetByEmpIDIndex(Id);
        }

        public EmpInfo GetEmpModel(int Id)
        {
            return _EmpInfoDap.GetByEmpId(Id);
        }
    }
}
