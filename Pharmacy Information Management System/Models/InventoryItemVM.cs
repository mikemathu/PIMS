using System.ComponentModel.DataAnnotations;

namespace Pharmacy_Information_Management_System.Models
{
    public class InventoryItemVM
    {
        public int ItemID { get; set; }

        [Display(Name = "Name")]
        [Required]
        public string ItemName { get; set; }

        [Display(Name = "Item Category")]
        [Required]
        public string ItemCategory { get; set; }

        [Display(Name = "Item Class")]
        [Required]
        public string ItemClass { get; set; }

        [Display(Name = "Inventory Sub-Account")]
        [Required]
        public string InventorySubAccount { get; set; }

        [Display(Name = "Cost Of Sale Sub-Account")]
        [Required]
        public string CostOfSaleSubAccount { get; set; }

        [Display(Name = "Income Sub-Account")]
        [Required]
        public string IncomeSubAccount { get; set; }

        [Display(Name = "VAT Type")]
        [Required]
        public string VatType { get; set; }

        [Display(Name = "Other Tax")]
        public string OtherTax { get; set; }

        [Display(Name = "Unit Cost(BP)")]
        [Required]
        public int UnitCost { get; set; }

        [Display(Name = "Unit Price(For cash payers)")]
        [Required]
        public int UnitPrice { get; set; }

        [Display(Name = "Available Quantity")]
        [Required]
        public int AvailableQuantity { get; set; }

        [Display(Name = "Total Quantity")]
        [Required]
        public int TotalQuantity { get; set; }

        [Display(Name = "Unit Of Measute")]
        public string UnitOfMeasure { get; set; }

        [Display(Name = "Batch No")]
        public string BatchNo { get; set; }

        [Display(Name = "Batch Expiry Date")]
        [Required]
        public DateTime ExpiryDate { get; set; }

        [Display(Name = "Item Code")]
        public string ItemCode { get; set; }

        [Display(Name = "Barcode")]
        public string Barcode { get; set; }

        [Display(Name = "Reorder Level")]
        [Required]
        public int ReorderLevel { get; set; }
       /* public string Status { get; set; }*/
    }
}