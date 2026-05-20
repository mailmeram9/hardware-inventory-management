using System.ComponentModel.DataAnnotations;

namespace HardwareInventoryAPI.models
{
    public class Asset
    {
        [Key]
        public int AssetID { get; set; }

        public string AssetName { get; set; }

        public string AssetType { get; set; }

        public string Status { get; set; }
      

    }
}
