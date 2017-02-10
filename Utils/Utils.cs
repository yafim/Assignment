using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

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
        /// <summary>
        /// Database name
        /// </summary>
        private string m_dbName = "AdventureWorks";
        
        /// <summary>
        /// Datsource
        /// </summary>
        private string m_DataSource = "local";
        #endregion

        #region Getters And Setters
        /// <summary>
        /// All table names points to their properties
        /// </summary>
        private readonly Dictionary<string, List<string>> m_Tables =
            new Dictionary<string, List<string>>();
        public Dictionary<string, List<string>> Tables { get { return m_Tables; } }

        /// <summary>
        /// All schemas names points to their tables s.t table names points to their properties
        /// </summary>
        private readonly  Dictionary<string, Dictionary<string, List<string>>> m_Schemes =
            new Dictionary<string, Dictionary<string, List<string>>>();
        public Dictionary<string, Dictionary<string, List<string>>> Schemes { get { return m_Schemes; } }

        /// <summary>
        /// Properties points to their tables
        /// </summary>
        private readonly Dictionary<string, List<string>> m_Properties =
            new Dictionary<string, List<string>>();
        public Dictionary<string, List<string>> Properties { get { return m_Properties; } }

        #endregion

        #region Public methods

        /// <summary>
        /// Get table properties
        /// </summary>
        /// <param name="tableName">Table name</param>
        /// <returns>Table's properties</returns>
        public List<string> GetTablePropertiesList(string tableName)
        {
            if (Tables.ContainsKey(tableName))
            {
                return Tables[tableName];
            }
            return null;
        }
        
        /// <summary>
        /// Map database and init data stractures
        /// </summary>
        public void MapDatabase()
        {
            string connectionString = String.Format(
                "Data Source=({0});Initial Catalog={1};Integrated Security=SSPI", m_DataSource, m_dbName);

            string sql = "SELECT SCHEMA_NAME(schema_id) As SchemaName, name As TableName from sys.tables ORDER BY name";
            
            using (SqlDataAdapter adapter = new SqlDataAdapter(
                sql, connectionString))
            {
                // fill DataTable
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    string schemaName = row[0].ToString();
                    string tableName = row[1].ToString();

                    // key exists, just add new value. Otherwise create new dictionary and insert it.
                    if (m_Schemes.ContainsKey(schemaName))
                    {
                        // tableName points to list of its properties
                        List<string> propertiesList = getListOfProperties(schemaName, tableName);

                        m_Schemes[schemaName].Add(tableName, propertiesList);
                    }
                    else
                    {
                        Dictionary<string, List<string>> tableNameDictionary = new Dictionary<string, List<string>>();

                        // fill properties
                        List<string> propertiesList = getListOfProperties(schemaName, tableName);

                        tableNameDictionary.Add(tableName, propertiesList);

                        // creates new dictionary
                        m_Schemes.Add(schemaName, tableNameDictionary);
                    }
                }

            }
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Set properties to their relevant data structures by schema and table names.
        /// </summary>
        /// <param name="schemaName">schema name</param>
        /// <param name="tableName">table name</param>
        /// <returns>list of properties</returns>
        private List<string> getListOfProperties(string schemaName, string tableName)
        {
            List<string> properties = new List<string>();

            SqlConnection connection = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

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
            cmd.CommandText = string.Format("SELECT * FROM {0}.{1}", schemaName, tableName);            
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.KeyInfo);

            //Retrieve column schema into a DataTable.
            var tableSchema = reader.GetSchemaTable();

            foreach (DataRow row in tableSchema.Rows)
            {
                var property = row["ColumnName"].ToString();
                properties.Add(property);

                // fill properties
                fillPropertiesList(property, tableName);

                // fill Tables
                fillTablesList(property, tableName);
            }

            // Close
            reader.Close();
            connection.Close();

            return properties;
        }

        /// <summary>
        /// Set Dictionary of properties
        /// </summary>
        /// <param name="property">Key</param>
        /// <param name="tableName">Value</param>
        private void fillPropertiesList(string property, string tableName)
        {
            if (m_Properties.ContainsKey(property))
            {
                m_Properties[property].Add(tableName);
            }
            else
            {
                List<string> innerPropertyList = new List<string> {tableName};
                m_Properties.Add(property, innerPropertyList);
            }
        }

        /// <summary>
        /// Set Dictionary of tables
        /// </summary>
        /// <param name="tableName">Key</param>
        /// <param name="property">Value</param>
        private void fillTablesList(string property, string tableName)
        {
            if (m_Tables.ContainsKey(tableName))
            {
                m_Tables[tableName].Add(property);
            }
            else
            {
                List<string> innerTableList = new List<string> { property };
                m_Tables.Add(tableName, innerTableList);
            }
        }

        #endregion 
    }
}