﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DETRAF.DAL
{
    public class DbManagerPortabilidade
    {
        public DbManagerPortabilidade() { }

        public int ExecuteNonQuery(string sql, SqlParameter[] p)
        {
            int retval;
            using (SqlConnection cnn = SqlServerPortabilidade.getInstance().getConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cnn.Open();
                cmd.CommandText = sql;
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnn;
                if (p != null)
                {
                    for (int i = 0; i < p.Length; i++)
                    {
                        cmd.Parameters.Add(p[i]);
                    }
                }
                retval = cmd.ExecuteNonQuery();
                cmd.Dispose();
                cnn.Close();
                cnn.Dispose();
            }
            return retval;
        }

        public DataSet ExecuteDataSet(string sql, SqlParameter[] p)
        {
            DataSet ds;
            using (SqlConnection cnn = SqlServerPortabilidade.getInstance().getConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cnn.Open();
                cmd.CommandText = sql;
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnn;
                if (p != null)
                {
                    for (int i = 0; i < p.Length; i++)
                    {
                        cmd.Parameters.Add(p[i]);
                    }
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds, sql);
                cmd.Dispose();
                cnn.Close();
                cnn.Dispose();
            }
            return ds;
        }

        public SqlDataReader ExecuteReader(string sql, SqlParameter[] p)
        {
            SqlDataReader reader;
            using (SqlConnection cnn = SqlServerPortabilidade.getInstance().getConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cnn.Open();
                cmd.CommandText = sql;
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnn;
                if (p != null)
                {
                    for (int i = 0; i < p.Length; i++)
                    {
                        cmd.Parameters.Add(p[i]);
                    }
                }
                reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Dispose();
                cnn.Close();
                cnn.Dispose();
            }
            return reader;
        }


    }
}