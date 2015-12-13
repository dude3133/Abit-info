using DbLayer.Models;

namespace LogicLayer.Models
{
    public class TruncatedSpeciality
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StateOrder { get; set; }
        public int LicencedVolume { get; set; }
        public SpecialityType Type { get; set; }
    }
}
