using System;
using System.Collections.Generic;

namespace HxyReport.Data.HxyReport
{
    public interface IDncUserRoleMappingDap
    {
        List<DncUserRoleMapping> GetTop(int count);
        DncUserRoleMapping GetByUserGuid(System.Guid UserGuid);
        DncUserRoleMapping GetByRoleCode(String RoleCode);
        void Insert(DncUserRoleMapping model);
        void Insert(IEnumerable<DncUserRoleMapping> models);
        void Delete(System.Guid UserGuid, String RoleCode);
        void Update(DncUserRoleMapping model);
        void Update(IEnumerable<DncUserRoleMapping> models);
    }
}