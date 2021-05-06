﻿using Molder.Helpers;
using Microsoft.Extensions.Logging;
using System;
using System.Data;
using System.Linq;
using System.Data.SqlClient;

namespace Molder.Database.Helpers
{
    public static class Message
    {
        public static string CreateMessage(IDbCommand command)
        {
            string message = string.Empty;
            try
            {
                message =
                $"{command.CommandText}{Environment.NewLine}-- Params: " +
                $"{string.Join(", ", command.Parameters.Cast<IDbDataParameter>().Select(p => $"{p.ParameterName}='{p.Value?.ToString()}' ({Enum.GetName(typeof(DbType), p.DbType)})"))}";
            }
            catch (Exception)
            {
                Log.Logger().LogWarning("DbCommand is Empty (null).");
                return null;
            }
            return message;
        }
        public static string CreateMessage(string connectionParams)
        {
            return string.Join($"{Environment.NewLine}", connectionParams.Split(';'));
        }

        public static string CreateMessage(SqlConnectionStringBuilder sqlConnectionString)
        {
            var message = string.Empty;
            message =   $@"
                        {Environment.NewLine}
                        Data Source={sqlConnectionString.DataSource}{Environment.NewLine}
                        Initial Catalog={sqlConnectionString.InitialCatalog}{Environment.NewLine}
                        User ID={sqlConnectionString.UserID}{Environment.NewLine}
                        Password={sqlConnectionString.Password}{Environment.NewLine}
                        Connect Timeout={sqlConnectionString.ConnectTimeout}{Environment.NewLine}
                        Load Balance Timeout={sqlConnectionString.LoadBalanceTimeout}.
                        {Environment.NewLine}";
            return message;
        }
    }
}
