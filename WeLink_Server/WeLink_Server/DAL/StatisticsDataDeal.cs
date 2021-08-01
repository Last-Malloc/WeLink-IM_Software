using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeLink_Server.BLL;

namespace WeLink_Server.DAL
{
    class StatisticsDataDeal : BaseDataDeal
    {
        /// <summary>
        /// 获取今日登陆人次，今日最高同时登录人次数据：存在返回字符串以空格隔开，不存在返回null
        /// </summary>
        /// <returns></returns>
        public static string getTodayStatisticsData()
        {
            try
            {
                string result = null;
                string sql = $"select * from loginStatisticsData where yearMonthDay = '{ToolUnion.getYearMonthDay()}'";
                MySqlDataReader mySqlDataReader = BaseDataDeal.select(sql);
                if (mySqlDataReader.HasRows)
                {
                    mySqlDataReader.Read();
                    result = mySqlDataReader.GetInt32("todayLoginNum").ToString()
                        + " " + mySqlDataReader.GetInt32("todayMaxNum").ToString();
                }
                mySqlDataReader.Close();
                return result;
            }
            catch (Exception)
            {
            }
            return "";
        }
        /// <summary>
        /// 获取累计登陆人次，累计最高同时登录人次数据：返回字符串以空格隔开
        /// </summary>
        /// <returns></returns>
        public static string getTotalStatisticsData()
        {
            try
            {
                string result = null;
                string sql = $"select * from loginStatisticsData where yearMonthDay = '20200101'";
                MySqlDataReader mySqlDataReader = BaseDataDeal.select(sql);
                if (mySqlDataReader.HasRows)
                {
                    mySqlDataReader.Read();
                    result = mySqlDataReader.GetInt32("todayLoginNum").ToString()
                        + " " + mySqlDataReader.GetInt32("todayMaxNum").ToString();
                }
                mySqlDataReader.Close();
                return result;
            }
            catch (Exception)
            {
            }
            return "";
        }
        /// <summary>
        /// 通过设置今日登陆人次和今日最高登录人次 更新 数据库数据：返回是否执行成功(已设置各种容错处理)
        /// </summary>
        public static bool setTodayAndTotalStatisticsData(int todayLoginNumKey, int todayMaxNumKey)
        {
            try
            {
                if (todayLoginNumKey >= 0 && todayMaxNumKey >= 0)
                {
                    //获得累计登录人次，累计最高同时登录人次
                    string[] temp = getTotalStatisticsData().Split(' ');
                    int totalLoginNum = Int32.Parse(temp[0]);//累计登录人次
                    int totalMaxNum = Int32.Parse(temp[1]);//累计最高同时登录人次
                    bool isExistTodayRecord = false;//数据库中是否已经存在当日的记录
                    int todayLoginNum = 0;//今日登陆人次
                    int todayMaxNum = 0;//今日最高同时登录人次
                    string temp2 = getTodayStatisticsData();
                    if (temp2 != null)//数据库中已经存在当日的记录
                    {
                        string[] temp3 = temp2.Split(' '); 
                        isExistTodayRecord = true;
                        todayLoginNum = Int32.Parse(temp3[0]);
                        todayMaxNum = Int32.Parse(temp3[1]);
                    }
                    if (isExistTodayRecord)
                    {
                        //校正累计同时在线人数
                        if (todayMaxNumKey > totalMaxNum)
                            totalMaxNum = todayMaxNumKey;
                        //校正累计登录人次
                        totalLoginNum += todayLoginNumKey - todayLoginNum;
                        string sqlstr = $"update LoginStatisticsData set todayLoginNum = {totalLoginNum}, todayMaxNum = {totalMaxNum} where yearMonthDay = '20200101';"
                                   + $"update LoginStatisticsData set todayLoginNum = {todayLoginNumKey}, todayMaxNum = {todayMaxNumKey} where yearMonthDay = '{ToolUnion.getYearMonthDay()}';";
                        if (BaseDataDeal.update(sqlstr) > 0)
                            return true;
                    }
                    else
                    {
                        //校正累计同时在线人数
                        if (todayMaxNumKey > totalMaxNum)
                            totalMaxNum = todayMaxNumKey;
                        //校正累计登录人次
                        totalLoginNum += todayLoginNumKey;
                        string sqlstr = $"update LoginStatisticsData set todayLoginNum = {totalLoginNum}, todayMaxNum = {totalMaxNum} where yearMonthDay = '20200101';"
                                    + $"insert into LoginStatisticsData values('{ToolUnion.getYearMonthDay()}', {todayLoginNumKey}, {todayMaxNumKey});";
                        if (BaseDataDeal.update(sqlstr) > 0)
                            return true;
                    }
                }
            }
            catch (Exception)
            {
            }
            return false;
        }
    }
}
