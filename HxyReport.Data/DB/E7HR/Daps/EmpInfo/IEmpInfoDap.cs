using System.Collections.Generic;

namespace HxyReport.Data.E7HR
{
    public interface IEmpInfoDap
    {
        void Delete(int EmpId);
        void DeleteByGonghao(string Gonghao);
        List<EmpInfo> GetByDeptID(int DeptID);
        EmpInfo GetByEmpId(int EmpId);
        EmpInfo GetByGonghaoIndex(string Gonghao);
        void Insert(EmpInfo model);
        void Insert(IEnumerable<EmpInfo> models);
        void Update(EmpInfo model);
        void Update(IEnumerable<EmpInfo> models);
    }
}