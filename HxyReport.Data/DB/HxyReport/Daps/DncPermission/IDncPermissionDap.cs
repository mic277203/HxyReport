using System;
using System.Collections.Generic;

namespace HxyReport.Data.HxyReport
{
    public interface IDncPermissionDap
    {
        List<DncPermission> GetTop(int count);
        DncPermission GetByCode(String Code);
        void Insert(DncPermission model);
        void Insert(IEnumerable<DncPermission> models);
        void Delete(String Code);
        void Update(DncPermission model);
        void Update(IEnumerable<DncPermission> models);
        List<DncPermission> GetByMenuGuid(System.Guid MenuGuid);
    }
}