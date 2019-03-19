using System.Collections.Generic;

namespace HxyReport.Data.AppOffice
{
    public interface ISysLoginUserDap
    {
        void Delete(string LoginName);
        void DeleteByEmpID(int EmpID);
        SysLoginUser GetByEmpIDIndex(int EmpID);
        SysLoginUser GetByLoginName(string LoginName);
        void Insert(IEnumerable<SysLoginUser> models);
        void Insert(SysLoginUser model);
        void Update(IEnumerable<SysLoginUser> models);
        void Update(SysLoginUser model);
    }
}