using System;
using System.Collections.Generic;
using System.Text;
using MySQLDriverCS;
using System.Data;

namespace mySql
{
    public class MySqlDde
    {
        private MySQLConnection conn;
        private string _myServerName;
        private string _databaseName;
        private String _user;
        private string _pwd;
        private string _tableName;

        public string myServerName
        {
            get
            {
                return _myServerName;
            }
            set
            {
                _myServerName = value;
            }
        }
        public string databaseName
        {
            get
            {
                return _databaseName;
            }
            set
            {
                _databaseName = value;
            }
        }
        public string tableName
        {
            get
            {
                return _tableName;
            }
            set
            {
                _tableName = value;
            }
        }
        public string user
        {
            get
            {
                return _user;
            }
            set
            {
                _user = value;
            }
        }
        public string pwd
        {
            get
            {
                return _pwd;
            }
            set
            {
                _pwd = value;
            }
        }




        public MySqlDde(string _myservername, string _databasename, string _user, string _pwd)
        {
            this._myServerName = _myservername;
            this._databaseName = _databasename;
            this._user = _user;
            this._pwd = _pwd;
            openCon(myServerName, databaseName, user, pwd);
        }


        private void openCon(string servername1, string databasename1, string user1, string pwd1)
        {
            conn = new MySQLConnection(new MySQLConnectionString(servername1, databasename1, user1, pwd1).AsString);


        }

        public Boolean getconnstate()
        {
            Boolean connstate = false;
            try
            {
                conn.Open();
                connstate = true;
                conn.Close();

            }
            catch
            {


            }

            return connstate;


        }







        public DataTable getRecord(string[] fields, string[] tables)
        {

            conn.Open();
            DataTable dt = new MySQLSelectCommand(conn,
                                         fields,
                                         tables,
                                         null,
                                         null,
                                         null
                                         ).Table;

            conn.Close();

            return dt;


        }
        public DataTable getRecord(string[] fields, string[] tables, string[,] order)
        {

            conn.Open();
            DataTable dt = new MySQLSelectCommand(conn,
                                         fields,
                                         tables,
                                         null,
                                         null,
                                        order
                                         ).Table;

            conn.Close();

            return dt;


        }



        public DataTable getwhereRecord(string[] fields, string[] tables, object[,] wherePara)
        {
            conn.Open();
            DataTable dt = new MySQLSelectCommand(conn,
               fields,
               tables,
               wherePara,
               null,
               null
           ).Table;

            conn.Close();

            return dt;
        }

        public void insertRecord(object[,] insertPara)
        {

            conn.Open();

            MySQLInsertCommand cmd = new MySQLInsertCommand(conn,
              insertPara,
              tableName
              );

            conn.Close();


        }
        //执行存储过程
        public void ExeProcedure(string cmdstring)
        {
            conn.Open();
            MySQLCommand cmd = new MySQLCommand(cmdstring, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            conn.Close();

        }
        //执行事务
        public Boolean ExeTrans(string cmdstring)
        {
            Boolean Ttemp = false;
            conn.Open();
            MySQLTransaction Trans = (MySQLDriverCS.MySQLTransaction)conn.BeginTransaction();
            MySQLCommand cmd = new MySQLCommand(cmdstring, conn);
            try
            {

                cmd.ExecuteNonQuery();
                Trans.Commit();
                Ttemp = true;

            }
            catch
            {
                Trans.Rollback();
                Ttemp = false;
            }


            finally
            {
                conn.Close();

            }
            return Ttemp;


        }

        public void ExecuteProcedurePara(string proceName, MySQLParameter[] paras)
        {
            conn.Open();
            MySQLCommand cmd = new MySQLCommand(proceName, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            foreach (MySQLParameter tmpPara in paras)
            {
                cmd.Parameters.Add(tmpPara);
            }
            cmd.Prepare();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new MySQLException(ex.Message);

            }
            cmd.Parameters.Clear();
            cmd.Dispose();
            conn.Close();

        }

        public void ExeMysql(string mysqlString)
        {
            conn.Open();
            MySQLCommand cmd = new MySQLCommand(mysqlString, conn);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();

        }
        //执行事务
        public void ExeMysqlTrans(string mysqlString)
        {
            conn.Open();
            MySQLTransaction Trans = (MySQLDriverCS.MySQLTransaction)conn.BeginTransaction();
            MySQLCommand cmd = new MySQLCommand(mysqlString, conn);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            try
            {

                Trans.Commit();

            }
            catch
            {
                Trans.Rollback();
            }


            finally
            {
                cmd.Dispose();
                conn.Close();

            }



        }


        public void ExeMysql(string mysqlString, MySQLParameter[] para)
        {
            conn.Open();
            MySQLCommand cmd = new MySQLCommand(mysqlString, conn);
            foreach (MySQLParameter tmpPara in para)
            {
                cmd.Parameters.Add(tmpPara);
            }
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            cmd.Dispose();
            conn.Close();

        }


        public void updateRecord(object[,] updatePara, object[,] wherePara)
        {
            conn.Open();
            IDbTransaction trans = conn.BeginTransaction();
            try
            {
                new MySQLUpdateCommand(conn,
                 updatePara,
                 tableName,
                wherePara,
                 null
                 );
                trans.Commit();
            }
            catch
            {
                trans.Rollback();
            }

            conn.Close();
        }
        public void DeleteRecord(object[,] delPara)
        {
            conn.Open();
            IDbTransaction trans = conn.BeginTransaction();
            try
            {
                new MySQLDeleteCommand(conn, tableName, delPara, null);
                trans.Commit();
            }
            catch
            {
                trans.Rollback();
            }
            conn.Close();
        }


        public DataSet executeCmd(string query)
        {
            DataSet ds = new DataSet();
            MySQLDataAdapter da = new MySQLDataAdapter(query, conn);
            da.Fill(ds);
            return ds;


        }


        public DataTable ExecCmd(string query, string[] Fields)
        {
            int n;
            MySQLCommand command = new MySQLCommand(query, conn);

            command.Prepare();

            DataTable table;
            MySQLDataReader reader = null;
            // Execute query ->
            try
            {
                conn.Open();
                reader = (MySQLDataReader)command.ExecuteReader(/*CommandBehavior.SequentialAccess*/);


                // Get results ->
                table = new DataTable(null);

                for (n = 0; n < Fields.Length; n++)
                {
                    table.Columns.Add(Fields[n].ToString());
                }

                while (reader.Read())
                {
                    if (reader.IsClosed)
                        throw new MySQLException("Reader is closed.");
                    DataRow row = table.NewRow();
                    for (n = 0; n < Fields.Length; n++)
                    {
                        if (n < reader.FieldCount)
                        {
                            if (reader.GetValue(n) == null)
                                row[n] = null;
                            else
                                if (reader.GetFieldType(n) == typeof(string))
                                    row[n] = reader.GetString(n).Clone();
                                else
                                    row[n] = reader.GetValue(n);
                        }
                        else
                        {
                            break;
                        }
                    }
                    table.Rows.Add(row);
                }
                // <- Get results
            }
            catch (Exception e)
            {
                throw new MySQLException(e.Message + " in query '" + query + "'");
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                conn.Close();
                command.Dispose();
            }
            // <- Execute query
            return table;
        }


    }
}
