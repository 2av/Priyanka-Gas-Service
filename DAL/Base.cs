using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using System.Configuration;
using System.Web;
namespace DAL
{
    public class Base
    {
        /*Common Variable for All Models*/
        public bool IsActive { get; set; }
        public int? ActionBy { get; set; }


        /*Private Variable*/
        private DataSet dsGetAll { get; set; }
        private SqlConnection con { get; set; }
        private SqlCommand cmd { get; set; }
        private SqlDataAdapter sda { get; set; }
        private SqlDataReader sdr { get; set; }
        private string connectionString { get; set; }
        private string errorMessage { get; set; }
        private string successMessage { get; set; }
        private DataTable EmptyDataTable { get; set; }

        /*Constructor*/
        public Base()
        {
            connectionString = ConfigurationManager.ConnectionStrings["CONS"].ConnectionString;
            con = new SqlConnection(connectionString);
            sda = new SqlDataAdapter();
            dsGetAll = new DataSet();
            EmptyDataTable = new DataTable();
            EmptyDataTable.Columns.Add("Record Not Found");
        }

        public static object GetPropValue(object src, string propName)
        {
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }
        public DataSet _Select(string ProcedureName, string Action = "", object ClassName = null)
        {
            try
            {
                cmd = new SqlCommand(ProcedureName, con);
                cmd.Parameters.AddWithValue("@Action", (Action != "") ? Action : Common.Action_Select);
                cmd.CommandType = CommandType.StoredProcedure;
                if (ClassName != null)
                {
                    var AllVariable = ClassName.GetType().GetProperties();
                    for (int i = 1; i < AllVariable.Length; i++)
                    {
                        string VaribaleName = AllVariable[i - 1].Name; ;
                        cmd.Parameters.AddWithValue("@" + VaribaleName, GetPropValue(ClassName, VaribaleName));

                    }
                }
                sda.SelectCommand = cmd;
                sda.Fill(dsGetAll);
                if (dsGetAll.Tables.Count == 0)
                {
                    dsGetAll.Tables.Add(EmptyDataTable);
                }

            }
            catch (Exception err)
            {
                dsGetAll.Tables.Add(EmptyDataTable);
                errorMessage = err.Message;
            }
            finally
            {
                if (con.State.ToString() == "Open")
                {
                    con.Close();
                    cmd.Dispose();
                    sda.Dispose();
                }
            }

            return dsGetAll;
        }
        public string _Insert(string ProcedureName, object ClassName)
        {
            var AllVariable = ClassName.GetType().GetProperties();
            cmd = new SqlCommand(ProcedureName, con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Action", Common.Action_Insert);
            for (int i = 1; i < AllVariable.Length; i++)
            {
                string VaribaleName = AllVariable[i - 1].Name; ;
                cmd.Parameters.AddWithValue("@" + VaribaleName, GetPropValue(ClassName, VaribaleName));

            }
            con.Open();
            sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                successMessage = Convert.ToString(sdr[0]);
            }
            return successMessage;
        }
        public string _Update(string ProcedureName, object ClassName)
        {
            var AllVariable = ClassName.GetType().GetProperties();
            cmd = new SqlCommand(ProcedureName, con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Action", Common.Action_Update);
            for (int i = 1; i < AllVariable.Length; i++)
            {
                string VaribaleName = AllVariable[i - 1].Name; ;
                cmd.Parameters.AddWithValue("@" + VaribaleName, GetPropValue(ClassName, VaribaleName));

            }
            con.Open();
            sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                successMessage = Convert.ToString(sdr[0]);
            }
            return successMessage;
        }


        public static List<T> BindList<T>(DataTable dt)
        {
            var fields = typeof(T).GetFields();

            List<T> lst = new List<T>();

            foreach (DataRow dr in dt.Rows)
            {
                // Create the object of T
                var ob = Activator.CreateInstance<T>();

                foreach (var fieldInfo in fields)
                {
                    foreach (DataColumn dc in dt.Columns)
                    {
                        // Matching the columns with fields
                        if (fieldInfo.Name == dc.ColumnName)
                        {
                            Type type = fieldInfo.FieldType;

                            // Get the value from the datatable cell
                            object value = GetValue(dr[dc.ColumnName], type);

                            // Set the value into the object
                            fieldInfo.SetValue(ob, value);
                            break;
                        }
                    }
                }

                lst.Add(ob);
            }

            return lst;
        }

        static object GetValue(object ob, Type targetType)
        {
            if (targetType == null)
            {
                return null;
            }
            else if (targetType == typeof(String))
            {
                return ob + "";
            }
            else if (targetType == typeof(int))
            {
                int i = 0;
                int.TryParse(ob + "", out i);
                return i;
            }
            else if (targetType == typeof(short))
            {
                short i = 0;
                short.TryParse(ob + "", out i);
                return i;
            }
            else if (targetType == typeof(long))
            {
                long i = 0;
                long.TryParse(ob + "", out i);
                return i;
            }
            else if (targetType == typeof(ushort))
            {
                ushort i = 0;
                ushort.TryParse(ob + "", out i);
                return i;
            }
            else if (targetType == typeof(uint))
            {
                uint i = 0;
                uint.TryParse(ob + "", out i);
                return i;
            }
            else if (targetType == typeof(ulong))
            {
                ulong i = 0;
                ulong.TryParse(ob + "", out i);
                return i;
            }
            else if (targetType == typeof(double))
            {
                double i = 0;
                double.TryParse(ob + "", out i);
                return i;
            }
            else if (targetType == typeof(DateTime))
            {
                // do the parsing here...
            }
            else if (targetType == typeof(bool))
            {
                // do the parsing here...
            }
            else if (targetType == typeof(decimal))
            {
                // do the parsing here...
            }
            else if (targetType == typeof(float))
            {
                // do the parsing here...
            }
            else if (targetType == typeof(byte))
            {
                // do the parsing here...
            }
            else if (targetType == typeof(sbyte))
            {
                // do the parsing here...
            }

            return ob;
        }
    }
}
