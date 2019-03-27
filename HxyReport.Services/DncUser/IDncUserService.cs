using System;

namespace HxyReport.Services.DncUser
{
    public interface IDncUserService
    {
        Data.HxyReport.DncUser GetByUserName(string userName);
        Data.HxyReport.DncUser GetByGuid(Guid guid);
    }
}