using HxyReport.Data;
using HxyReport.Data.AppOffice;
using HxyReport.Data.E7HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HxyReport.Services.Users
{
    public interface IUserService
    {
        SysLoginUser GetModel(int Id);
        EmpInfo GetEmpModel(int Id);
    }
}
