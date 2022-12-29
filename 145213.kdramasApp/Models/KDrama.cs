using Microsoft.EntityFrameworkCore;

namespace _145213.kdramasApp.Models
{

    [Index(nameof(Title), IsUnique = true)]
    public class KDrama
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }


        //połączenia
        public List<Status> Statuses { get; set; } = new();
        public List<Actor> Actors { get; set; } = new();
    }
}
