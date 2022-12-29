namespace _145213.kdramasApp.Models
{
    public class KDramaActor
    {
        public int ActorId { get; set; }    
        public int KDramaId { get; set; }

        public Actor? Actor { get; set; }
        
        public KDrama? KDrama { get; set; }

    }
}
