using System;
using Microsoft.AspNet.Identity;

namespace HxyReport_MVC.Models
{     
    public class ApplicationUser : IUser
    {                   
        public string Id { get; set; }
        public string UserName { get; set; }
        public System.Guid Guid { get; set; }
        public String LoginName { get; set; }
        public String DisplayName { get; set; }
        public String Password { get; set; }
        public String Avatar { get; set; }
        public Int32 UserType { get; set; }
        public Int32 IsLocked { get; set; }
        public Int32 Status { get; set; }
        public Int32 IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public String CreatedByUserName { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public String ModifiedByUserName { get; set; }
        public String Description { get; set; }
        public System.Guid CreatedByUserGuid { get; set; }
        public System.Guid? ModifiedByUserGuid { get; set; }
    }
 
}