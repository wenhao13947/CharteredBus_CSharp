using CharteredBus.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebApi.DAL;

namespace CharteredBus.Controllers
{
    public class GetIndexController : ApiController
    {
        public string GetIndex()
        {
            //string sqlStr = "select top 20 (select enterprise from tenterprise where id=enterpriseID) as '企业名称', carcode as '车牌号码', jobid as '申请编号', countyType as '区域类型', [status] as '审核状态', startDate as '有效期起', endDate as '有效期止', startzone as '起点', endzone as '终点', passLine as '途经线路', carCountyType as '经营范围', mileage as '往返里程数', jobdate as '上报日期', attachCounty as '管理单位', decide as '审核人员', printNumber as '牌证编号' from tjobs_travel order by jobdate desc";
            string sqlStr = @"select top 20 (select enterprise from tenterprise where id=enterpriseID) as 'enterprise', carcode as 'carCode', jobid as 'jobId', countyType as 'countryType', [status] as 'status', cast(datepart(yy, startDate)as nvarchar)+'年'+cast(datepart(mm,startDate) as nvarchar)+ '月'+cast(datepart(dd,startDate) as nvarchar)+'日' as 'startDate', cast(datepart(yy, endDate)as nvarchar)+'年'+cast(datepart(mm,endDate) as nvarchar)+ '月'+cast(datepart(dd,endDate) as nvarchar)+'日' as 'endDate', startzone as 'startZone', endzone as 'endZone', passLine as 'passLine', carCountyType as 'carCountryType', mileage as 'mileage', jobdate as 'jobDate', attachCounty as 'attachCounty', decide as 'decide', printNumber as 'printNumber',driver1Name as 'driver1Name',driver2Name as 'driver2Name' from tjobs_travel order by jobdate desc";
            //SqlHelper.GetCommand(SqlHelper.SqlConnString(), null, sqlStr, null);
            DataTable dt = SqlHelper.GetDataTable(sqlStr, null);
            return DataTableConvertJson.DataTableToJson1(dt);
        }

        public string GetTableById(int id)
        {
            //            string sqlStr = @"select top 1 (select enterprise from tenterprise where id=enterpriseID) as 'enterprise', (select enterprise from tenterprise where id=enterpriseID) as 'businessArea', carcode as 'carCode', carCountyType as 'carCountryType',
            //startzone as 'startZone', endzone as 'endZone', vehicletype as 'vehicleType', vehicleseates as 'vehicleSeat', 
            //passLine as 'passLine', mileage as 'mileage', passengers as 'passengers', cast(datepart(yy, startDate)as nvarchar)+'年'+cast(datepart(mm,startDate) as nvarchar)+ '月'+cast(datepart(dd,startDate) as nvarchar)+'日' as 'startDate', 
            //cast(datepart(yy, endDate)as nvarchar)+'年'+cast(datepart(mm,endDate) as nvarchar)+ '月'+cast(datepart(dd,endDate) as nvarchar)+'日' as 'endDate',
            //carDegree as 'carDegree', cast(datepart(yy, joinDate)as nvarchar)+'年'+cast(datepart(mm,joinDate) as nvarchar)+ '月'+cast(datepart(dd,joinDate) as nvarchar)+'日' as 'joinDate', license as 'carLicence', cast(datepart(yy, bxDate)as nvarchar)+'年'+cast(datepart(mm,bxDate) as nvarchar)+ '月'+cast(datepart(dd,bxDate) as nvarchar)+'日' as 'insDate', cast(datepart(yy, djpdDate)as nvarchar)+'年'+cast(datepart(mm,djpdDate) as nvarchar)+ '月'+cast(datepart(dd,djpdDate) as nvarchar)+'日' as 'degreeDate',
            //ifBack as 'gbPsg', cast(datepart(yy, xszDate)as nvarchar)+'年'+cast(datepart(mm,xszDate) as nvarchar)+ '月'+cast(datepart(dd,xszDate) as nvarchar)+'日' as 'dlvDate', nightRun as 'drAir',
            //driver1Name as 'driver1Name', driver1J as 'drver1Type', driver1C as 'driver1Num', cast(datepart(yy, driver1CDate)as nvarchar)+'年'+cast(datepart(mm,driver1CDate) as nvarchar)+ '月'+cast(datepart(dd,driver1CDate) as nvarchar)+'日' as 'endDate',
            //driver2Name as 'driver1Name', driver2J as 'drver1Type', driver2C as 'driver1Num', driver2CDate as 'driver1Date'
            //from tjobs_travel where carcode='贵GT0588' order by jobdate desc";
            string sqlStr = @"select (select enterprise from tenterprise where id=enterpriseID) as 'enterprise', (select businessArea from tenterprise where id=enterpriseID) as 'businessArea', carcode as 'carCode', countyType as 'countryType',
startzone as 'startZone', endzone as 'endZone', vehicletype as 'vehicleType', vehicleseates as 'vehicleSeat', attachCounty as 'attachCountry',
passLine as 'passLine', mileage as 'mileage', passengers as 'passengers', cast(datepart(yy, startDate)as nvarchar)+'年'+cast(datepart(mm,startDate) as nvarchar)+ '月'+cast(datepart(dd,startDate) as nvarchar)+'日' as 'startDate', 
cast(datepart(yy, endDate)as nvarchar)+'年'+cast(datepart(mm,endDate) as nvarchar)+ '月'+cast(datepart(dd,endDate) as nvarchar)+'日' as 'endDate',
carDegree as 'carDegree', cast(datepart(yy, joinDate)as nvarchar)+'年'+cast(datepart(mm,joinDate) as nvarchar)+ '月'+cast(datepart(dd,joinDate) as nvarchar)+'日' as 'joinDate', license as 'carLicence', cast(datepart(yy, bxDate)as nvarchar)+'年'+cast(datepart(mm,bxDate) as nvarchar)+ '月'+cast(datepart(dd,bxDate) as nvarchar)+'日' as 'insDate', cast(datepart(yy, djpdDate)as nvarchar)+'年'+cast(datepart(mm,djpdDate) as nvarchar)+ '月'+cast(datepart(dd,djpdDate) as nvarchar)+'日' as 'degreeDate',
ifBack as 'gbPsg', cast(datepart(yy, xszDate)as nvarchar)+'年'+cast(datepart(mm,xszDate) as nvarchar)+ '月'+cast(datepart(dd,xszDate) as nvarchar)+'日' as 'dlvDate', nightRun as 'drAir',
driver1Name as 'driver1Name', driver1J as 'drver1Type', driver1C as 'driver1Num', cast(datepart(yy, driver1CDate)as nvarchar)+'年'+cast(datepart(mm,driver1CDate) as nvarchar)+ '月'+cast(datepart(dd,driver1CDate) as nvarchar)+'日' as 'endDate',
driver2Name as 'driver2Name', driver2J as 'drver2Type', driver2C as 'driver2Num', cast(datepart(yy, driver2CDate)as nvarchar)+'年'+cast(datepart(mm,driver2CDate) as nvarchar)+ '月'+cast(datepart(dd,driver2CDate) as nvarchar)+'日' as 'driver2Date'
from tjobs_travel where jobid=" + id;
            DataTable dt = SqlHelper.GetDataTable(sqlStr, null);
            return DataTableConvertJson.DataTableToJson1(dt);
        }

        public string BtnSearch(string carCode)
        {
            string sqlStr = @"select (select enterprise from tenterprise where id=enterpriseID) as 'enterprise', carcode as 'carCode', jobid as 'jobId', cast(datepart(yy, startDate)as nvarchar)+'年'+cast(datepart(mm,startDate) as nvarchar)+ '月'+cast(datepart(dd,startDate) as nvarchar)+'日' as 'startDate', cast(datepart(yy, endDate)as nvarchar)+'年'+cast(datepart(mm,endDate) as nvarchar)+ '月'+cast(datepart(dd,endDate) as nvarchar)+'日' as 'endDate', startzone as 'startZone', endzone as 'endZone', jobdate as 'jobDate', printNumber as 'printNumber',driver1Name as 'driver1Name',driver2Name as 'driver2Name' from tjobs_travel where carcode like '%"+ carCode + "%' order by jobdate desc";
            DataTable dt = SqlHelper.GetDataTable(sqlStr, null);
            return DataTableConvertJson.DataTableToJson1(dt);
        }
    }
}