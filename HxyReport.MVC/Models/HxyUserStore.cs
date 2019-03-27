using System;
using System.Threading.Tasks;
using HxyReport.Services.DncUser;
using Microsoft.AspNet.Identity;

namespace HxyReport_MVC.Models
{
    public class HxyUserStore<T> : IUserStore<T> where T : ApplicationUser
    {
        private readonly IDncUserService _dncUserService;
        public HxyUserStore(IDncUserService dncUserService)
        {
            _dncUserService = dncUserService;
        }
        public void Dispose()
        {
          
        }

        public Task CreateAsync(T user)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(T user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(T user)
        {
            throw new NotImplementedException();
        }

        public Task<T> FindByIdAsync(string userId)
        {
            var model =  _dncUserService.GetByGuid(new Guid(userId));

            if (model == null)
            {
                return null;
            }

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

                return Task.FromResult(user as T);
        }

        public Task<T> FindByNameAsync(string userName)
        {
            throw new NotImplementedException();
        }
    }
}