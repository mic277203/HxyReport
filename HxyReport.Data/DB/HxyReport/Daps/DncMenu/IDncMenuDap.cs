using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HxyReport.Data.HxyReport
{
    public interface IDncMenuDap
    {
        List<DncMenu> GetTop(int count);
        DncMenu GetByGuid(System.Guid Guid);
        void Insert(DncMenu model);
        void Insert(IEnumerable<DncMenu> models);
        void Delete(System.Guid Guid);
        void Update(DncMenu model);
        void Update(IEnumerable<DncMenu> models);
    }
}
