/*
 Created Date - 16/05/2016
 Purpose - maintains core dataaccess functions.
 */

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common
{
    public class DbAccess
    {
        public static int ExecuteNoneQuary(string procedure, IList<SqlParameter> parms)
        {
            SqlCommand command = GetCommand(procedure);

            try
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = procedure;
                command.Parameters.Clear();
                foreach (var item in parms)
                {
                    command.Parameters.Add(item);
                }
                command.ExecuteNonQuery();
                return GetParameterAsInt32(command, command.Parameters[0].ParameterName.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                command.Connection.Close();
            }
        }

        public static T ExecuteReader<T>(string procedure, IList<SqlParameter> parms, Func<IDataReader, T> entity)
        {
            SqlCommand command = GetCommand(procedure);

            try
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = procedure;
                command.Parameters.Clear();
                if (parms != null)
                {
                    foreach (var item in parms)
                    {
                        command.Parameters.Add(item);
                    }
                }
                IDataReader dr = command.ExecuteReader();

                var items = entity(dr);
                return items;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                command.Connection.Close();
            }
        }

        public static IList<T> ExecuteManyReader<T>(string procedure, IList<SqlParameter> parms, Func<IDataReader, IList<T>> entities)
        {
            SqlCommand command = GetCommand(procedure);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = procedure;
            command.Parameters.Clear();

            foreach (var item in parms)
            {
                command.Parameters.Add(item);
            }

            IDataReader dr = command.ExecuteReader();
            var items = entities(dr);
            command.Connection.Close();
            return items;
        }

        private static SqlCommand GetCommand(string procedure)
        {
            return new SqlCommand(procedure, GetConnection());
        }

        private static SqlConnection GetConnection()
        {
            var connetionkey = "MovieLib";
            var cstring = ConfigurationManager.ConnectionStrings[connetionkey].ConnectionString;
            var connection = new SqlConnection(cstring);
            connection.Open();
            return connection;
        }

        public static int GetParameterAsInt32(System.Data.IDbCommand command, string name)
        {
            if (!command.Parameters.Contains(name)) return -1;

            return (int)(command.Parameters[name] as System.Data.IDataParameter).Value;
        }
    }
}
