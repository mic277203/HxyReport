using System;
using System.ComponentModel.DataAnnotations;

namespace HxyReport.Data.HxyReport
{

	public partial class DncMenu : BaseModel
	{

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public System.Guid Guid { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public String Name { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public String Url { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public String Alias { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public String Icon { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public System.Guid? ParentGuid { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public String ParentName { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public Int32 Level { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public String Description { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public Int32 Sort { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public Int32 Status { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public Int32 IsDeleted { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public Int32 IsDefaultRouter { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public DateTime CreatedOn { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public String CreatedByUserName { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public DateTime? ModifiedOn { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public String ModifiedByUserName { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public System.Guid CreatedByUserGuid { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public System.Guid? ModifiedByUserGuid { get; set; }

	}

	public partial class DncPermission : BaseModel
	{

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public String Code { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public System.Guid MenuGuid { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public String Name { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public String ActionCode { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public String Icon { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public String Description { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public Int32 Status { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public Int32 IsDeleted { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public Int32 Type { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public DateTime CreatedOn { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public String CreatedByUserName { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public DateTime? ModifiedOn { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public String ModifiedByUserName { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public System.Guid CreatedByUserGuid { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public System.Guid? ModifiedByUserGuid { get; set; }

	}

	public partial class DncRole : BaseModel
	{

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public String Code { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public String Name { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public String Description { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public Int32 Status { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public Int32 IsDeleted { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public DateTime CreatedOn { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public String CreatedByUserName { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public DateTime? ModifiedOn { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public String ModifiedByUserName { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public Boolean IsSuperAdministrator { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public Boolean IsBuiltin { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public System.Guid CreatedByUserGuid { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public System.Guid? ModifiedByUserGuid { get; set; }

	}

	public partial class DncRolePermissionMapping : BaseModel
	{

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public String RoleCode { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public String PermissionCode { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public DateTime CreatedOn { get; set; }

	}

	public partial class DncUser : BaseModel
	{

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public System.Guid Guid { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public String LoginName { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public String DisplayName { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public String Password { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public String Avatar { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public Int32 UserType { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public Int32 IsLocked { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public Int32 Status { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public Int32 IsDeleted { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public DateTime CreatedOn { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public String CreatedByUserName { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public DateTime? ModifiedOn { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public String ModifiedByUserName { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public String Description { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public System.Guid CreatedByUserGuid { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public System.Guid? ModifiedByUserGuid { get; set; }

	}

	public partial class DncUserRoleMapping : BaseModel
	{

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public System.Guid UserGuid { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public String RoleCode { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public DateTime CreatedOn { get; set; }

	}

	public partial class DncIcon : BaseModel
	{

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public Int32 Id { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public String Code { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public String Size { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public String Color { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public String Custom { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public String Description { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public Int32 Status { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public Int32 IsDeleted { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public DateTime CreatedOn { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public String CreatedByUserName { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public DateTime? ModifiedOn { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public String ModifiedByUserName { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public System.Guid CreatedByUserGuid { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Display(Name = "")]
		public System.Guid? ModifiedByUserGuid { get; set; }

	}

}
