using System;
using System.ComponentModel.DataAnnotations;

namespace HxyReport.Data.AppOffice
{

    public partial class SysLoginUser : BaseModel
    {
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        public Int32 ID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        public Int32 EmpID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        public String LoginName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        public String Password { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        public Int32 RoleID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        public String DeptLimit { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        public String Cookie { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        public Boolean CanUseZizhu { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        public Boolean UseFP { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        public Boolean EnableApp { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        public String MobileSN { get; set; }

    }

}
