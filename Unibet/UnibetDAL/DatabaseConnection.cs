﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace UnibetDAL
{
    public class DatabaseConnection
    {
        public DatabaseConnection(string connectionString)
        {
            SqlConnection = new SqlConnection(connectionString);
        }

        internal SqlConnection SqlConnection { get; }
    }
}