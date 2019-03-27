using System;
using System.Collections.Generic;

namespace HxyReport.Data.HxyReport
{
    public interface IDncIconDap
    {
        List<DncIcon> GetTop(int count);
        DncIcon GetById(Int32 Id);
        void Insert(DncIcon model);
        void Insert(IEnumerable<DncIcon> models);
        void Delete(Int32 Id);
        void Update(DncIcon model);
        void Update(IEnumerable<DncIcon> models);
    }
}