using System;
using System.Collections.Generic;

namespace HxyReport.Data.HxyReport
{
    public interface IDncRolePermissionMappingDap
    {
        List<DncRolePermissionMapping> GetTop(int count);
        DncRolePermissionMapping GetByRoleCode(String RoleCode);
        DncRolePermissionMapping GetByPermissionCode(String PermissionCode);
        void Insert(DncRolePermissionMapping model);
        void Insert(IEnumerable<DncRolePermissionMapping> models);
        void Delete(String RoleCode, String PermissionCode);
        void Update(DncRolePermissionMapping model);
        void Update(IEnumerable<DncRolePermissionMapping> models);
    }
}