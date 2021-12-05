namespace TheDayAfter.InventorySystem
{
    /// <summary>
    /// Permette di gestire i proiettili e il loro numero all'interno dell'inventario.
    /// </summary>
    [System.Serializable]
    public class BulletItem
    {
        public string name;
        public string weaponName;
        public int count;
        public string description;

        public BulletItem Clone()
        {
            BulletItem bi = new BulletItem();
            bi.name = name;
            bi.weaponName = weaponName;
            bi.count = count;
            bi.description = description;

            return bi;
        }
    }
}
