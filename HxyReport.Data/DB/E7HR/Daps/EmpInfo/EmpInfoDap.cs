using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using HxyReport.Data;

namespace HxyReport.Data.E7HR
{

	public partial class EmpInfoDap : AppE7HRBaseDap, IEmpInfoDap
    {
		public EmpInfoDap()
		{
		}
		public EmpInfo GetByEmpId(Int32 EmpId)
		{
			return Query<EmpInfo>(SqlSelectCommand + " WHERE EmpId=@EmpId", new { EmpId = EmpId }).FirstOrDefault();
		}

		public void Insert(EmpInfo model)
		{
			Execute(SqlInsertCommand, model);
		}

		public void Insert(IEnumerable<EmpInfo> models)
		{
			Execute(SqlInsertCommand, models);
		}

		public void Delete(Int32 EmpId)
		{
			Execute(SqlDeleteCommand, new { EmpId = EmpId });
		}

		public void Update(EmpInfo model)
		{
			Execute(SqlUpdateCommand, model);
		}

		public void Update(IEnumerable<EmpInfo> models)
		{
			Execute(SqlUpdateCommand, models);
		}



		public List<EmpInfo> GetByDeptID(Int32 DeptID)
		{
			return Query<EmpInfo>(SqlSelectCommand + " WHERE DeptID=@DeptID", new { DeptID = DeptID }).ToList();
		}


		public EmpInfo GetByGonghaoIndex(String Gonghao)
		{
			return Query<EmpInfo>(SqlSelectCommand + " WHERE Gonghao=@Gonghao", new { Gonghao = Gonghao }).FirstOrDefault();
		}

		public void DeleteByGonghao(String Gonghao)
		{
			Execute(SqlDeleteCommand, new { Gonghao = Gonghao });
		}

		public const string SqlTableName = "dbo.EmpInfo";
		public const string SqlSelectCommand = "SELECT * FROM " + SqlTableName;
		public const string SqlInsertCommand = "INSERT INTO " + SqlTableName + " (DeptID , Gonghao , Kaoqinhao , Name , Zhicheng , PostID , Gangwei , Shenfenzheng , ChushengRq , Xingbie , Jiguan , Mingzu , Hunfou , Xueli , Zhuanye , Xuexing , YonggongXz , RuzhiGongling , RuzhiRq , ShiyongDaoqiri , ShiyongDaoqiri_Yidong , ZhuanzhengRq , HetongDaoqiri , HetongQishiri , LiZhiRq , JiuyezhengDq , ShenjianzhengDq , ZanzhuzhengDq , JiankangzhengDQ , Email , LianxiDianHua , ShoujiHaoma , JiatingDz , XianZhuDz , IsBlack , Status , Memo , M1 , M2 , M3 , M4 , M5 , M6 , M7 , M8 , M9 , M10 , M11 , M12 , M13 , M14 , M15 , M16 , M17 , M18 , M19 , M20 , AttCount , JobStatus , Nianling , Gongling , BiyeYuanxiao , BiyeShijian , BiyeZhengshuBianhao , ShenfenzhengDaoqiri , cardnumber , GWID , toOA , toExexm) VALUES (@DeptID , @Gonghao , @Kaoqinhao , @Name , @Zhicheng , @PostID , @Gangwei , @Shenfenzheng , @ChushengRq , @Xingbie , @Jiguan , @Mingzu , @Hunfou , @Xueli , @Zhuanye , @Xuexing , @YonggongXz , @RuzhiGongling , @RuzhiRq , @ShiyongDaoqiri , @ShiyongDaoqiri_Yidong , @ZhuanzhengRq , @HetongDaoqiri , @HetongQishiri , @LiZhiRq , @JiuyezhengDq , @ShenjianzhengDq , @ZanzhuzhengDq , @JiankangzhengDQ , @Email , @LianxiDianHua , @ShoujiHaoma , @JiatingDz , @XianZhuDz , @IsBlack , @Status , @Memo , @M1 , @M2 , @M3 , @M4 , @M5 , @M6 , @M7 , @M8 , @M9 , @M10 , @M11 , @M12 , @M13 , @M14 , @M15 , @M16 , @M17 , @M18 , @M19 , @M20 , @AttCount , @JobStatus , @Nianling , @Gongling , @BiyeYuanxiao , @BiyeShijian , @BiyeZhengshuBianhao , @ShenfenzhengDaoqiri , @cardnumber , @GWID , @toOA , @toExexm) ";
		public const string SqlUpdateCommand = "UPDATE " + SqlTableName + " SET DeptID=@DeptID , Gonghao=@Gonghao , Kaoqinhao=@Kaoqinhao , Name=@Name , Zhicheng=@Zhicheng , PostID=@PostID , Gangwei=@Gangwei , Shenfenzheng=@Shenfenzheng , ChushengRq=@ChushengRq , Xingbie=@Xingbie , Jiguan=@Jiguan , Mingzu=@Mingzu , Hunfou=@Hunfou , Xueli=@Xueli , Zhuanye=@Zhuanye , Xuexing=@Xuexing , YonggongXz=@YonggongXz , RuzhiGongling=@RuzhiGongling , RuzhiRq=@RuzhiRq , ShiyongDaoqiri=@ShiyongDaoqiri , ShiyongDaoqiri_Yidong=@ShiyongDaoqiri_Yidong , ZhuanzhengRq=@ZhuanzhengRq , HetongDaoqiri=@HetongDaoqiri , HetongQishiri=@HetongQishiri , LiZhiRq=@LiZhiRq , JiuyezhengDq=@JiuyezhengDq , ShenjianzhengDq=@ShenjianzhengDq , ZanzhuzhengDq=@ZanzhuzhengDq , JiankangzhengDQ=@JiankangzhengDQ , Email=@Email , LianxiDianHua=@LianxiDianHua , ShoujiHaoma=@ShoujiHaoma , JiatingDz=@JiatingDz , XianZhuDz=@XianZhuDz , IsBlack=@IsBlack , Status=@Status , Memo=@Memo , M1=@M1 , M2=@M2 , M3=@M3 , M4=@M4 , M5=@M5 , M6=@M6 , M7=@M7 , M8=@M8 , M9=@M9 , M10=@M10 , M11=@M11 , M12=@M12 , M13=@M13 , M14=@M14 , M15=@M15 , M16=@M16 , M17=@M17 , M18=@M18 , M19=@M19 , M20=@M20 , AttCount=@AttCount , JobStatus=@JobStatus , Nianling=@Nianling , Gongling=@Gongling , BiyeYuanxiao=@BiyeYuanxiao , BiyeShijian=@BiyeShijian , BiyeZhengshuBianhao=@BiyeZhengshuBianhao , ShenfenzhengDaoqiri=@ShenfenzhengDaoqiri , cardnumber=@cardnumber , GWID=@GWID , toOA=@toOA , toExexm=@toExexm WHERE EmpId=@EmpId";
		public const string SqlDeleteCommand = "DELETE FROM " + SqlTableName + " WHERE EmpId=@EmpId";
		
	}

}
