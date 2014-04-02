namespace SimpleWebStats.Core
{
    public class Device
    {
        public string Family { get; set; }
        public bool IsSpider { get; set; }

        public Device() { }

        public Device(string family, bool isSpider)
        {
            Family = family;
            IsSpider = isSpider;
        }

        public override string ToString()
        {
            return Family;
        }
    }
}