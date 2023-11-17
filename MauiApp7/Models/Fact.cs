namespace MauiApp7.Models
{
    public enum FactItemType
    {
        Video = 1,
        Image = 2
    }

    public class Fact
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Data { get; set; }
        public List<FactItem> FactItems { get; set; } = new List<FactItem>();
    }

    public class FactItem
    {
        public Guid Id { get; set; }
        public string Caption { get; set; }
        public FactItemType FactItemType { get; set; }
        public string UriStoragePath { get; set; }

    }

}
