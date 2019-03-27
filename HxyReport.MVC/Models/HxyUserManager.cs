using System;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using HxyReport.Services.DncUser;

namespace HxyReport_MVC.Models
{
    public class HxyUserManager : UserManager<ApplicationUser>
    {
        private readonly IDncUserService _IDncUserService;
        public HxyUserManager(IDncUserService dncUserService)
            : base(new HxyUserStore<ApplicationUser>(dncUserService))
        {
            _IDncUserService = dncUserService;
        }

        public override Task<ApplicationUser> FindAsync(string userName, string password)
        {
           var model = _IDncUserService.GetByUserName(userName);

            if (model != null)
            {
                if (String.CompareOrdinal(model.Password, password) == 0)
                {
                    var user = new ApplicationUser
                    {
                        Id = model.Guid.ToString(),
                        UserName = model.LoginName,
                        DisplayName = model.DisplayName,
                        Password = model.Password,
                        Avatar = model.Avatar,
                        UserType = model.UserType,
                        IsLocked = model.IsLocked,
                        Status = model.Status,
                        IsDeleted = model.IsDeleted,
                        CreatedOn = model.CreatedOn,
                        CreatedByUserName = model.CreatedByUserName,
                        ModifiedOn = model.ModifiedOn,
                        ModifiedByUserName = model.ModifiedByUserName,
                        Description = model.Description
                    };

                    return Task.FromResult(user);
                }
            }

            return null;
        }
    }
}