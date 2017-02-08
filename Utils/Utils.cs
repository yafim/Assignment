using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Utils
{
    public class Utils
    {
        #region singleton

        private static volatile Utils m_Instance;
        private static object m_Locker = new Object();

        private Utils()
        {
        }

        public static Utils Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    lock (m_Locker)
                    {
                        if (m_Instance == null)
                            m_Instance = new Utils();
                    }
                }

                return m_Instance;
            }
        }

        #endregion

        #region SQL Table inforamtion
        private int m_UniqueIdCounter;
        private string m_dbName = "AdventureWorks";
        private string m_DataSource = "local";
        #endregion

        #region Getters And Setters
        private string m_NoDataString = "--No Data--";
        public string NoDataString { get { return m_NoDataString; } }
        #endregion

        /// <summary>
        /// Connect to local SQL with given database name and get its column names
        /// </summary>
        /// <param name="database">Database name</param>
        /// <returns>Column names</returns>
        public LinkedList<string> GetColumnNamesFromDB(string database)
        {
            LinkedList<string> columns = new LinkedList<string>();

            SqlConnection connection = new SqlConnection();
            SqlCommand cmd = new SqlCommand();


            //Open a connection to the SQL Server Northwind database.
            connection.ConnectionString = String.Format(
                "Data Source=({0});Initial Catalog={1};Integrated Security=SSPI", m_DataSource, m_dbName);
            try
            {
                connection.Open();
            }
            catch (Exception e)
            {
                throw new Exception("Database Name Not Found");
            }

            cmd.Connection = connection;
            cmd.CommandText = "SELECT * FROM " + database;
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.KeyInfo);

            //Retrieve column schema into a DataTable.
            var tableSchema = reader.GetSchemaTable();

            foreach (DataRow row in tableSchema.Rows)
            {
                var name = row["ColumnName"].ToString();
                columns.AddLast(new LinkedListNode<string>(name));

            }

            // Close
            reader.Close();
            connection.Close();

            return columns;
        }



        /// <summary>
        /// Get rows from table by columns
        /// </summary>
        /// <param name="columns">Table Columns</param>
        /// <param name="database">Table name</param>
        /// <returns>Dictionary<string, LinkedList<string>> s.t key is the column</returns>
        public Dictionary<string, LinkedList<string>> GetValuesFromTableByColumns(LinkedList<string> columns,
            string database)
        {
            Dictionary<string, LinkedList<string>> dictionary = new Dictionary<string, LinkedList<string>>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = String.Format(
                "Data Source=({0});Initial Catalog={1};Integrated Security=SSPI", m_DataSource, m_dbName);
            connection.Open();


            // get values
            foreach (var col in columns)
            {
                // Create new DataAdapter
                using (SqlDataAdapter adapter = new SqlDataAdapter(
                    "SELECT " + col + " FROM " + database, connection))
                {
                    // fill DataTable
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Render data onto the screen
                    LinkedList<string> list = new LinkedList<string>();

                    foreach (DataRow row in dt.Rows)
                    {
                        string val = row[col].ToString();
                        list.AddFirst(val);
                    }

                    dictionary.Add(col, list);
                }

            }

            connection.Close();

            return dictionary;
        }

        /// <summary>
        /// Generate unique id for nodes without actual value inside.
        /// </summary>
        /// <returns>uniqueid</returns>
        public string GenerateUniqueId()
        {
            m_UniqueIdCounter++;
            return String.Format(@"uniqueId_{0}", m_UniqueIdCounter);
        }

    }
}