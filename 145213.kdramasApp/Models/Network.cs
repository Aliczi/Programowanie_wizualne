using Microsoft.EntityFrameworkCore;

namespace _145213.kdramasApp.Models
{
    [Index(nameof(OfficialName), IsUnique = true)]
    public class Network
    {
        public int Id { get; set; }
        public string OfficialName { get; set; }

        public string  Residence { get; set; }

        public string Owner { get; set; }

        public DateTime Broadcast { get; set; }

        public string Language { get; set; }


        public List<KDrama>? KDramas { get; set; } = new();

    }
}
