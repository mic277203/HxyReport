using System;
using System.Collections.Generic;

namespace HxyReport.Data.HxyReport
{
    public interface IDncRoleDap
    {
        List<DncRole> GetTop(int count);
        DncRole GetByCode(String Code);
        void Insert(DncRole model);
        void Insert(IEnumerable<DncRole> models);
        void Delete(String Code);
        void Update(DncRole model);
        void Update(IEnumerable<DncRole> models);
    }
}