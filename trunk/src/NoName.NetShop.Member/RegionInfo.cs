using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using NoName.NetShop.Common;
using System.IO;
using Newtonsoft.Json;

namespace NoName.NetShop.Member
{
    public class RegionInfo
    {
        public int _regionId;
        public int _fatherId;
        public string _regionName;
        public string _regionPath;
        public string _regionNamePath;
        public string _country;
        public string _province;
        public string _city;
        public string _county;

        public int RegionId { get { return _regionId; } }
        public string RegionName { get { return _regionName; } }
        public string RegionPath { get { return _regionPath; } }
        public string RegionNamePath { get { return _regionNamePath; } }
        public int FatherId { get { return _fatherId; } }

        public string Country { get { return _country; } }
        public string Province { get { return _province; } }
        public string City { get{return _city;} }
        public string County { get { return _county; } }

        public RegionInfo(int regionId)
        {
            string sql = "SELECT RegionId,FatherId,RegionPath,RegionName,regionnamepath FROM unRegion where regionid="+regionId;
            using (IDataReader reader = CommDataAccess.DbReader.ExecuteReader(CommandType.Text, sql))
            {
                if (reader.Read())
                {
                    this._regionId = Convert.ToInt32(reader["regionId"]);
                    this._regionName = reader["regionName"].ToString();
                    this._regionPath = reader["RegionPath"].ToString();
                    this._regionNamePath = reader["regionnamepath"].ToString();
                    this._fatherId = Convert.ToInt32(reader["FatherId"]);

                    string[] regions = this.RegionNamePath.TrimEnd('/').Split('/');
                    //string[] regionIds = this.RegionPath.TrimEnd('/').Split('/');
                    if (regions.Length >= 1)
                    {
                        this._country = regions[0];
                    }
                    if (regions.Length >= 2)
                        this._province = regions[1];
                    if (regions.Length >= 3)
                        this._city = regions[2];
                    if (regions.Length >= 4)
                        this._county = regions[3];
                }
                else
                {
                    throw new ShopException("不存在的地址信息", false);
                }
            }        
        }

        public static string GetRegionPathByName(string RegionName)
        {
            string sql = "select regionpath from unRegion where regionname = '"+RegionName+"'";
            return Convert.ToString(CommDataAccess.DbReader.ExecuteScalar(CommandType.Text,sql));
        }

        public static string GetSubRegionByJson(int regionId)
        {
            string sql = "select regionname,regionid from unRegion where fatherid=" + regionId;

            StringBuilder sb = new StringBuilder(200);
            StringWriter sw = new StringWriter(sb);
            JsonWriter jw = new JsonWriter(sw);
            using (IDataReader reader = CommDataAccess.DbReader.ExecuteReader(CommandType.Text, sql))
            {
                jw.WriteStartArray();
                while (reader.Read())
                {
                    jw.WriteStartObject();
                    jw.WritePropertyName("id");
                    jw.WriteValue(reader["regionid"].ToString());
                    jw.WritePropertyName("name");
                    jw.WriteValue(reader["regionname"].ToString());
                    jw.WriteEndObject();
                }
                jw.WriteEndArray();
            }
            jw.Close();
            return sb.ToString();
        }


    }
}
