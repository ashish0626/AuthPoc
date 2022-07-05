using JWTAuth_Validation.Controllers;
using JWTAuth_Validation.Model;
using System.Data;
using System.Data.SqlClient;

namespace JWTAuth_Validation.Services
{
    public class UserService : IUserService
    {
        public string sConStr = "Data Source=PEFLBELH3T;Initial Catalog=EmployeesDB;Integrated Security=True";
        //public string sConStr = "Data Source=DiseaseClass;Initial Catalog=EmployeeDB;Integrated Security=True";
        //public string sConStr = "Data Source=DiseaseClass;Initial Catalog=EmployeeDB;Persist Security Info=False;User ID=ashish;Password=sa@0786;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
        public bool IsValidUserInformation(LoginModel model)
        {
            if (model.UserName.Equals("hpe") && model.Password.Equals("hpe")) return true;
            else return false;
        }

        public LoginModel GetUserDetails()
        {
            return new LoginModel { UserName = "hpe", Password = "hpe" };
        }

        public EmployeeModel Find(string userName, string password)
        {
            EmployeeModel employeeinfo = null;
            //string sQry = "select * from [EmployeeProfile] where [EmailID]" + userName ;
            string sQry = "select * from EmployeeProfile where EmailID = '" + userName + "' and EmployeePassword = '" + password + "'";
            DataTable dtemployeeinfo = ExecuteQuery(sQry);
            if (dtemployeeinfo != null)
            {
                DataRow dr = dtemployeeinfo.Rows[0];
                employeeinfo = GetemployeeinfoByRow(dr);
            }
            return employeeinfo;
        }
        private DataTable ExecuteQuery(string strSql)
        {
            SqlConnection conn = null;
            DataTable dt = null;
            try
            {
                
                conn = new SqlConnection(sConStr);
                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                conn.Open();
                dt = new DataTable();
                //Fill the dataset
                da.Fill(dt);
                if (!(dt.Rows.Count > 0)) dt = null;
            }
            catch { dt = null; }
            finally { if (conn.State != 0) conn.Close(); }
            
            return dt;
        }

        private EmployeeModel GetemployeeinfoByRow(DataRow dr)
        {
            EmployeeModel employeeinfo = new EmployeeModel();
           
            //employeeinfo.UserName = dr["EmailID"].ToString();
            //employeeinfo.Password = dr["EmployeePassword"].ToString();
            employeeinfo.LastName = dr["LastName"].ToString();
            employeeinfo.FirstName = dr["FirstName"].ToString();

            return employeeinfo;
        }
    }
}
