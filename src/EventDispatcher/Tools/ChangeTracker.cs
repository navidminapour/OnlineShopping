using EventsDispatcher.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace EventsDispatcher.Tools
{
    public class ChangeTracker
    {
        private readonly SqlConnection _connection;
        public ChangeTracker(SqlConnection connection)
        {
            this._connection = connection;
        }

        public List<EventItem> Read()
        {
            var commandText = $"SELECT * FROM Events WHERE [IsProcessed] = 0 ORDER BY CreationDateTime";
            var command = new SqlCommand(commandText, _connection);

            var adapter = new SqlDataAdapter(command);
            var table = new DataTable();
            adapter.Fill(table);

            var rows = table.Rows;

            if(rows.Count > 0)
            {
                return MapToEventItem(rows);
            }
            return new List<EventItem>();
        }

        private List<EventItem> MapToEventItem(DataRowCollection rows)
        {
            var output = new List<EventItem>();
            foreach(DataRow dataRow in rows)
            {
                var item = new EventItem
                {
                    Id = Guid.Parse(dataRow["Id"].ToString()),
                    SerializedContent = dataRow["SerializedContent"].ToString(),
                    CreationDateTime = DateTime.Parse(dataRow["CreationDateTime"].ToString()),
                    EventType = dataRow["EventType"].ToString()
                };
                output.Add(item);
            }
            return output;
        }

        public void MarkAsProcessed(Guid eventItemId)
        {
            var commandText = $"UPDATE Events SET [IsProcessed] = 1 WHERE Id = '{eventItemId}'";
            var command = new SqlCommand(commandText, _connection);
            command.ExecuteNonQuery();
        }
    }
}
