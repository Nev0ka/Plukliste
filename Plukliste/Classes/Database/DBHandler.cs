using System.Data.SqlClient;

namespace Plukliste.Classes.Database
{
    internal class DBHandler
    {
        public List<InventoryContent> GetContent { get { return ContentList.ToList(); } }
        private InventoryContent Content = new();
        List<InventoryContent> ContentList;

        //private static string connectString = "Server=192.168.52.128;" + "Database=InventoryApp;" + "Uid=sa;" + "Pwd=1234";
        private static string connectString = "Server=(localdb)\\mssqllocaldb;Database=InventoryApp;Trusted_Connection=True;MultipleActiveResultSets=true";

        public void updateDB(int id, int stock, string productName, string productId)
        {
            Content.ID = id;
            Content.Stock = stock;
            Content.ProductName = productName;
            Content.ProductId = productId;
        }

        public void WriteToDB()
        {
            using (SqlConnection conn = new(connectString))
            {
                string Query = $"INSERT INTO [dbo].[InventoryContent]([Stock],[ProductName],[ProductID]) VALUES('{Content.Stock}','{Content.ProductName}','{Content.ProductId}')";
                SqlCommand command = new(Query, conn);
                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void UpdateToDB()
        {
            using (SqlConnection conn = new(connectString))
            {
                string Query = $"UPDATE [dbo].[InventoryContent] SET [Stock] = '{Content.Stock}',[ProductName] = '{Content.ProductName}', [ProductID] = '{Content.ProductId}' WHERE [ID] = '{Content.ID}'";
                SqlCommand command = new(Query, conn);
                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void ReadFromDb()
        {
            ContentList = new();
            using (SqlConnection conn = new(connectString))
            {
                string Query = $"SELECT [ID],[Stock],[ProductName],[ProductID] FROM [dbo].[InventoryContent]";
                SqlCommand command = new(Query, conn);
                conn.Open();
                
                SqlDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                    var content = new InventoryContent();
                    content.ID = reader.GetInt32(0);
                    content.Stock = reader.GetInt32(1);
                    content.ProductName = reader.GetString(2);
                    content.ProductId = reader.GetString(3);
                    ContentList.Add(content);
                }
            }
            return;
        }
    }
}
