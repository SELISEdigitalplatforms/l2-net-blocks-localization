

namespace DomainService.Services
{
    public class Key
    {
        public string Name { get; set; }
        public string Module { get; set; }
        public string Value { get; set; }
        public Dictionary<string, string> Translations { get; set; }
        public List<string> Routes { get; set; }

    }
}
