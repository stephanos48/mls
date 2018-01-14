using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Script.Serialization;
using mls.Models;

namespace mls
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public void LoadData(int iDisplayLength, int iDisplayStart, int iSortCol_0, string sSortDir_0, string sSearch)
        {
            int displayLength = iDisplayLength;
            int displayStart = iDisplayStart;
            int sortCol = iSortCol_0;
            string sortDir = sSortDir_0;
            string search = sSearch;

            string cs = ConfigurationManager.ConnectionStrings["mls_dataConnectionString"].ConnectionString;
            List<MasterPartList> listMasterPartLists = new List<MasterPartList>();
            int filteredCount = 0;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spLoadData", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramDisplayLength = new SqlParameter()
                {
                    ParameterName = "@DisplayLength",
                    Value = displayLength
                };
                cmd.Parameters.Add(paramDisplayLength);

                SqlParameter paramDisplayStart = new SqlParameter()
                {
                    ParameterName = "@DisplayStart",
                    Value = displayStart
                };
                cmd.Parameters.Add(paramDisplayStart);

                SqlParameter paramSortCol = new SqlParameter()
                {
                    ParameterName = "@SortCol",
                    Value = sortCol
                };
                cmd.Parameters.Add(paramSortCol);

                SqlParameter paramSorDir = new SqlParameter()
                {
                    ParameterName = "@SortDir",
                    Value = sortDir
                };
                cmd.Parameters.Add(paramSorDir);

                SqlParameter paramSearchString = new SqlParameter()
                {
                    ParameterName = "@Search",
                    Value = string.IsNullOrEmpty(search) ? null : search
                };
                cmd.Parameters.Add(paramSearchString);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    filteredCount = Convert.ToInt32(rdr["TotalCount"]);
                    MasterPartList masterpartlist = new MasterPartList();
                    masterpartlist.CustomerPn = rdr["CustomerPn"].ToString();
                    masterpartlist.PartDescription = rdr["PartDescription"].ToString();
                    masterpartlist.PartPrice = Convert.ToDecimal(rdr["PartPrice"]);
                    masterpartlist.PartCost = Convert.ToDecimal(rdr["PartCost"]);
                    masterpartlist.Weight = Convert.ToDecimal(rdr["Weight"]);
                    masterpartlist.StdPack = Convert.ToInt32(rdr["StdPack"]);
                    masterpartlist.Location = rdr["Location"].ToString();
                    masterpartlist.HtsCode = rdr["HtsCode"].ToString();
                    masterpartlist.Notes = rdr["Notes"].ToString();
                    listMasterPartLists.Add(masterpartlist);
                }
            }
            var result = new
            {
                iTotalRecords = LoadDataTotalCount(),
                iTotalDisplayRecords = filteredCount,
                aaData = listMasterPartLists
            };

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(result));
        }

        private int LoadDataTotalCount()
        {
            int totalLoadDataCount = 0;
            string cs = ConfigurationManager.ConnectionStrings["mls_dataConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new 
                    SqlCommand("select * from MasterPartLists", con);
                con.Open();
                totalLoadDataCount = (int) cmd.ExecuteScalar();
            }
            return totalLoadDataCount;
        }
    }
}
