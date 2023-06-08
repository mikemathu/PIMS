using Npgsql;
using Pharmacy_Information_Management_System.Models;
using Pharmacy_Information_Management_System.Services;

namespace Pharmacy_Information_Management_System.Repositories
{
    public class InventoryItemRepository : IInventoryItemRepository
    {
        private const string _servicePointsTable = "servicepoints";
        private const string _itemsTable = "items";
        private IConfiguration _config;
        private NpgsqlConnection _connection;
        public InventoryItemRepository(IConfiguration config)
        {
            _config = config;
        }
        private void OpenConnection()
        {
            string connectionString = _config.GetConnectionString("DefaultConnection");

            _connection = new NpgsqlConnection(connectionString);
            _connection.Open();
        }
        public async Task AddInventotyItem(InventoryItemVM inventoryItemId)
        {
            OpenConnection();
            string commandText = $"INSERT INTO {_itemsTable} (itemname, itemcategory, itemclass, inventorysubaccount," +
                $"costofsalesubaccount,incomesubaccount,vattype,othertax,unitcost," +
                $"unitprice,quantity,unitofmeasure,batchno,expirydate,itemcode,barcode,reorderlevel)" +
                $" VALUES (@itemname, @itemcategory, @itemclass ,@inventorysubaccount ,@costofsalesubaccount ," +
                $"@incomesubaccount ,@vattype ,@othertax ,@unitcost ,@unitprice, @quantity ,@unitofmeasure ,@batchno ," +
                $"@expirydate ,@itemcode ,@barcode,@reorderlevel)";

            using (NpgsqlCommand command = new NpgsqlCommand(commandText, _connection))
            {
                command.Parameters.AddWithValue("@itemname", inventoryItemId.ItemName);
                command.Parameters.AddWithValue("@itemcategory", inventoryItemId.ItemCategory);
                command.Parameters.AddWithValue("@itemclass", inventoryItemId.ItemClass);
                command.Parameters.AddWithValue("@inventorysubaccount", inventoryItemId.InventorySubAccount);
                command.Parameters.AddWithValue("@costofsalesubaccount", inventoryItemId.CostOfSaleSubAccount);
                command.Parameters.AddWithValue("@incomesubaccount", inventoryItemId.IncomeSubAccount);
                command.Parameters.AddWithValue("@vattype", inventoryItemId.VatType);
                command.Parameters.AddWithValue("@othertax", inventoryItemId.OtherTax);
                command.Parameters.AddWithValue("@unitcost", inventoryItemId.UnitCost);
                command.Parameters.AddWithValue("@unitprice", inventoryItemId.UnitPrice);
                command.Parameters.AddWithValue("@quantity", inventoryItemId.TotalQuantity);
                command.Parameters.AddWithValue("@unitofmeasure", inventoryItemId.UnitOfMeasure);
                command.Parameters.AddWithValue("@batchno", inventoryItemId.BatchNo); 
                command.Parameters.AddWithValue("@expirydate", inventoryItemId.ExpiryDate); 
                command.Parameters.AddWithValue("@itemcode", inventoryItemId.ItemCode);
                command.Parameters.AddWithValue("@barcode", inventoryItemId.Barcode);
                command.Parameters.AddWithValue("@reorderlevel", inventoryItemId.ReorderLevel);

                await command.ExecuteNonQueryAsync();
            }
            _connection.Close();
        }

       /* public Task<IEnumerable<InventoryItemVM>> GetInventoryItems()
        {
            throw new NotImplementedException();
        }*/

        public async Task<IEnumerable<InventoryItemVM>> GetInventoryItems()
        {
            OpenConnection();
            List<InventoryItemVM> InventoryItems = new List<InventoryItemVM>();

            string commandText = $"SELECT itemname, batchno, unitcost, quantity,  expirydate " +
                                 $"FROM {_itemsTable} ORDER BY itemid ASC";
            using (NpgsqlCommand command = new NpgsqlCommand(commandText, _connection))
            {
                using (NpgsqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        InventoryItems.Add(new InventoryItemVM
                        {
                            ItemName = (string)reader["itemname"],
                            BatchNo = (string)reader["batchno"],
                            UnitCost = (int)reader["unitcost"],
                            TotalQuantity = (int)reader["quantity"],
                      /*      AvailableQuantity = (int)reader["availablequantity"],*/
                            ExpiryDate = (DateTime)reader["expirydate"]
                        });
                    }
                    reader.Close();
                }
                _connection.Close();
            }
            if (InventoryItems.Count() == 0)
                return null;
            return InventoryItems;
        }
    }
}
