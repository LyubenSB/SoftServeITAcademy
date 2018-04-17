namespace LMDB.ObjectModels.OperationalObjects
{
    public class Networks
    {
        public string Name { get; set; }

        public string Country { get; set; }

        public override string ToString()
        {
            return $"{this.Name}({this.Country})";
        }
    }
}