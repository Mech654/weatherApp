﻿using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;

namespace Vejr_app3
{
    public static class SQlite
    {
        public static void RefreshFile()
        {
            string dbFilePath = "SEARCH_HISTORY.db";
            connectionString = @"Data Source=SEARCH_HISTORY.db;Version=3;";

            // Check if the .db file exists, if not, initialize the database
            if (!File.Exists(dbFilePath))
            {
                InitializeDatabase();
            }
        }
        private static string connectionString = @"Data Source=SEARCH_HISTORY.db;Version=3;";
      

        public static void InitializeDatabase()
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // Create the history table
                using (var command = new SQLiteCommand(@"
                    CREATE TABLE IF NOT EXISTS history (
                        order_id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Search_history TEXT NOT NULL
                    )", connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void InsertSearchHistory(string searched_city)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (var command = new SQLiteCommand("INSERT INTO history (Search_history) VALUES (@name)", connection))
                {
                    command.Parameters.AddWithValue("@name", searched_city);
                    command.ExecuteNonQuery();
                }
            }
        }

        public static List<string> data = new List<string>();

        public static void getData()
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                
                using (var command = new SQLiteCommand("SELECT Search_history FROM history", connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        data.Clear();  
                        while (reader.Read())
                        {
                            data.Add(reader.GetString(0));  
                        }
                        data.Reverse();
                    }
                }
            }
        }
    }
}
