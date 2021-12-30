using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Udaan_Product.Models;

namespace Udaan_Product.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        public IDbConnection Connection
        {
            get
            {
                string Connection = "Data Source=DESKTOP-NR5KSM5\\SQLEXPRESS; Initial Catalog=Udaan_Product; User Id=DESKTOP-NR5KSM5\\Dinkar;Trusted_Connection=True";
                return new SqlConnection(Connection);
            }
        }
        [HttpGet]
        [Route("api/GetProductDetails")]
        public ActionResult Get()
        {
            IEnumerable<dynamic> data = null;
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@error", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);
                data = dbConnection.Query<dynamic>("select * from Udaan_Product",param, commandType:CommandType.Text);
                string error = param.Get<string>("@error");
                dbConnection.Close();
            }
            return Ok(data);
        }

        [HttpPost]
        [Route("api/InsertProductDeals")]
        public ActionResult InsertProductDeal(UdaanProduct productDeals)
        {
            using(IDbConnection dbConnection = Connection)
            {
                
                try
                {
                    IEnumerable<dynamic> data;
                    dbConnection.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Product_Name", productDeals.Product_Name);
                    param.Add("@Product_Type", productDeals.Product_Type);
                    param.Add("@Product_Price", productDeals.Product_Price);
                    param.Add("@No_of_Quantity", productDeals.No_of_Quantity);
                    param.Add("@Deal_Time_From", productDeals.Deal_Time_From);
                    param.Add("@Deal_Time_To", productDeals.Deal_Time_To);
                    param.Add("@Is_Active_Deal", productDeals.Is_Active_Deal);
                    param.Add("@CreatedBy", productDeals.CreatedBy);
                    param.Add("@UpdatedBy", productDeals.UpdatedBy);
                    param.Add("@error", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);
                    data = dbConnection.Query<dynamic>("[dbo].[InsProductDetails_Udaan]", param, commandType: CommandType.StoredProcedure);
                    string error = param.Get<string>("@error");
                    dbConnection.Close();
                    return Ok(data);
                    
                }
                catch(SqlException exception)
                {
                    throw exception;
                }
                finally
                {
                    dbConnection.Close();
                }
            }
        }

    }
}
