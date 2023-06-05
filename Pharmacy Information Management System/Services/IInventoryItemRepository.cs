using Pharmacy_Information_Management_System.Models;

namespace Pharmacy_Information_Management_System.Services
{
    public interface IInventoryItemRepository
    {
        Task AddInventotyItem(InventoryItemVM inventoryItemId);
    }
}
