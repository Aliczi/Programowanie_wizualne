namespace _145213.kdramasApp.Models
{
    public class Status
    {
        public int Id { get; set; }
        public StatusType StatusType { get; set; }

        public KDrama? KDrama { get; set; }


        //połączenia
        //public ICollection<KDrama> KDramas { get; set; } = new List<KDrama>();
    }

}
