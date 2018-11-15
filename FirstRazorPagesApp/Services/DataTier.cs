using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FirstRazorPagesApp.Services
{
    // your method to pull data from database to datatable   
    public class DataTier
    {
        //private IConfiguration _configuration;
        //private string ConnectionString;

        //public DataTier(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //    ConnectionString = _configuration.GetConnectionString("DefaultConnectionString");
        //}

        private static string ConnectionString
        {
            get
            {
                // Initialize the connection string builder for the underlying provider.
                SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder();

                // Set the properties for the data source.

                sqlBuilder.DataSource = "(localdb)\\MSSQLLocalDB";


                sqlBuilder.InitialCatalog = "FirstRazorPagesApp";
                sqlBuilder.MultipleActiveResultSets = true;
                //sqlBuilder.UserID = "_wsJasonMVC_v1";
                //sqlBuilder.Password = "asjh5ljkeqh4kl3ja";

                // return the connection string.
                return sqlBuilder.ToString();
            }
        }
        /// <summary>
        /// Returns a DataTable, based on the command passed
        /// </summary>
        /// <param name="cmd">
        /// the SqlCommand object we wish to execute
        /// </param>
        /// <returns>
        /// a DataTable populated with the data
        /// specified in the SqlCommand object
        /// </returns>
        /// <remarks></remarks>
        public static DataTable GetDataTable(SqlCommand cmd)
            {
                DataTable dt = new DataTable();

                //init the sql connection
                SqlConnection conn = (cmd.Connection != null && !String.IsNullOrEmpty(cmd.Connection.ConnectionString)) ? cmd.Connection : new SqlConnection(ConnectionString);

                using (conn)
                {
                    try
                    {
                        //set the command connection
                        cmd.Connection = conn;

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            //fill the DataTable
                            da.Fill(dt);
                        }
                    }
                    catch (Exception ex)
                    {
                        // send extra data to error catcher
                        // https://msdn.microsoft.com/en-us/library/system.exception.data%28v=vs.110%29.aspx
                        ex.Data["Sql"] = cmd.CommandText;

                        foreach (SqlParameter param in cmd.Parameters)
                            ex.Data[param.ParameterName] = param.Value;

                        throw ex;
                    }
                }

                return dt;
            }

            /// <summary>
            /// Returns a DataTable, based on the sql string passed
            /// </summary>
            /// <param name="strSQL">
            /// the direct SQL object we wish to execute
            /// </param>
            /// <returns>
            /// a DataTable populated with the data
            /// specified in the sql string
            /// </returns>
            /// <remarks></remarks>
            public static DataTable GetDataTable(string strSQL)
            {
                return GetDataTable(new SqlCommand(strSQL));
            }

            /// <summary>
            /// For those super simple queries, i'll let you pass in your values and i'll tackle for ya...
            /// </summary>
            /// <param name="strSQL"></param>
            /// <param name="args"></param>
            /// <returns></returns>
            public static DataTable GetDataTable(string strSQL, params object[] args)
            {
                // science, bitches
                // https://msdn.microsoft.com/en-us/library/aa287527%28v=vs.71%29.aspx

                SqlCommand cmd = new SqlCommand(strSQL);

                // replace {0} with @param1
                // add parameter to cmd
                int i = 0;
                foreach (object obj in args)
                {
                    cmd.CommandText = cmd.CommandText.Replace("{" + i + "}", "@param" + i);
                    cmd.Parameters.AddWithValue("param" + i, obj);
                    i++;
                }

                return GetDataTable(cmd);
            }

            public static object ExecuteScalar(string strSQL)
            {
                return ExecuteScalar(new SqlCommand(strSQL));
            }

            /// <summary>
            /// For those super simple queries, i'll let you pass in your values and i'll tackle for ya...
            /// </summary>
            /// <param name="strSQL"></param>
            /// <param name="args"></param>
            /// <returns></returns>
            public static object ExecuteScalar(string strSQL, params object[] args)
            {
                // science, bitches
                // https://msdn.microsoft.com/en-us/library/aa287527%28v=vs.71%29.aspx

                SqlCommand cmd = new SqlCommand(strSQL);

                // replace {0} with @param1
                // add parameter to cmd
                int i = 0;
                foreach (object obj in args)
                {
                    cmd.CommandText = cmd.CommandText.Replace("{" + i + "}", "@param" + i);
                    cmd.Parameters.AddWithValue("param" + i, obj);
                    i++;
                }

                return ExecuteScalar(cmd);
            }

            public static object ExecuteScalar(SqlCommand cmd)
            {
                //init the sql connection
                SqlConnection conn = (cmd.Connection != null && !String.IsNullOrEmpty(cmd.Connection.ConnectionString)) ? cmd.Connection : new SqlConnection(ConnectionString);

                using (conn)
                {
                    try
                    {
                        //set the command connection
                        cmd.Connection = conn;

                        cmd.Connection.Open();
                        return cmd.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        // send extra data to error catcher
                        // https://msdn.microsoft.com/en-us/library/system.exception.data%28v=vs.110%29.aspx
                        ex.Data["Sql"] = cmd.CommandText;

                        foreach (SqlParameter param in cmd.Parameters)
                            ex.Data[param.ParameterName] = param.Value;

                        throw ex;
                    }
                    finally
                    {
                        cmd.Connection.Close();
                        cmd.Connection.Dispose();
                        cmd.Dispose();
                    }
                }
            }

            public static int ExecuteNonQuery(string strSQL)
            {
                SqlCommand cmd = new SqlCommand(strSQL);
                cmd.CommandType = CommandType.Text;

                return ExecuteNonQuery(cmd);
            }

            public static int ExecuteNonQuery(SqlCommand cmd)
            {
                //init the sql connection
                SqlConnection conn = (cmd.Connection != null && !String.IsNullOrEmpty(cmd.Connection.ConnectionString)) ? cmd.Connection : new SqlConnection(ConnectionString);

                using (conn)
                {
                    try
                    {
                        //set the command connection
                        cmd.Connection = conn;

                        cmd.Connection.Open();
                        return cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        // send extra data to error catcher
                        // https://msdn.microsoft.com/en-us/library/system.exception.data%28v=vs.110%29.aspx
                        ex.Data["Sql"] = cmd.CommandText;

                        foreach (SqlParameter param in cmd.Parameters)
                            ex.Data[param.ParameterName] = param.Value;

                        throw ex;
                    }
                    finally
                    {
                        cmd.Connection.Close();
                        cmd.Connection.Dispose();
                        cmd.Dispose();
                    }
                }
            }

            /// <summary>
            /// For those super simple queries, i'll let you pass in your values and i'll tackle for ya...
            /// </summary>
            /// <param name="strSQL"></param>
            /// <param name="args"></param>
            /// <returns></returns>
            public static object ExecuteNonQuery(string strSQL, params object[] args)
            {
                // science, bitches
                // https://msdn.microsoft.com/en-us/library/aa287527%28v=vs.71%29.aspx

                SqlCommand cmd = new SqlCommand(strSQL);

                // replace {0} with @param1
                // add parameter to cmd
                int i = 0;
                foreach (object obj in args)
                {
                    cmd.CommandText = cmd.CommandText.Replace("{" + i + "}", "@param" + i);
                    cmd.Parameters.AddWithValue("param" + i, obj);
                    i++;
                }

                return ExecuteNonQuery(cmd);
            }
        }
    }
