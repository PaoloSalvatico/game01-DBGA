
namespace TheFirstGame.InventorySystem
{
    /// <summary>
    ///  Permete di gestire i proiettili e il loro numero all'interno dell'inventario
    /// </summary>
    [System.Serializable]
    public class BulletItem
    {
        public string name;
        public string weaponName;
        public int count;


        public BulletItem Clone()
        {
            BulletItem bi = new BulletItem();
            bi.name = this.name;
            bi.weaponName = this.weaponName;
            bi.count = this.count;

            return bi;
        }
    }
}

