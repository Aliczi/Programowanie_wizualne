using Microsoft.EntityFrameworkCore;

namespace _145213.kdramasApp.Models
{

    [Index(nameof(Pseudonym), IsUnique = true)]
    public class Actor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Pseudonym { get; set; }


        //połączenia
        //public List<KDrama> KDramas { get; set; } = new();

        public ICollection<KDramaActor> KDramaActors { get; set; }
    }
}
