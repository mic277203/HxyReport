using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HxyReport.Data.HxyReport;

namespace HxyReport.Services.DncUser
{
    public class DncUserService : IDncUserService
    {
        private readonly IDncUserDap _IDncUserDap;

        public DncUserService(IDncUserDap dncUserDap )
        {
            _IDncUserDap = dncUserDap;
        }

        public Data.HxyReport.DncUser GetByUserName(string userName)
        {
            return _IDncUserDap.GetByUserName(userName);
        }

        public Data.HxyReport.DncUser GetByGuid(Guid guid)
        {
            return _IDncUserDap.GetByGuid(guid);
        }
    }
}
