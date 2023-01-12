using Microsoft.EntityFrameworkCore;

namespace _145213.kdramasApp.Models
{

    [Index(nameof(Title), IsUnique = true)]
    public class KDrama
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public DateTime Data { get; set; }


        public StatusType Status { get; set; }

        public int? NetworkId { get; set; }
        public Network? Network { get; set; }

        public List<Actor>? Actors { get; set; } = new();
    }
}
