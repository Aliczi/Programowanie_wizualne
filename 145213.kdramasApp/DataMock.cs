using _145213.kdramasApp.Models;
using System.Diagnostics.Metrics;

namespace _145213.kdramasApp
{
    public class DataMock
    {

        private readonly DataContext dataContext;
        public DataMock(DataContext context)
        {
            this.dataContext = context;
        }

        public void InitDataContext()
        {
            if (!dataContext.KDramaActors.Any())
            {
                var KDramaActors = new List<KDramaActor>()
                {
                     new KDramaActor()
                    {
                        KDrama = new KDrama()
                        {
                            Title = "Something in the Rain",
                            Description = "Slice of live",
                            Statuses = new List<Status>()
                            {
                                new Status { StatusType = StatusType.Finished }
                            }
                        },

                        Actor = new Actor()
                        {
                            FirstName = "Ye Jin",
                            LastName = "Son",
                            Pseudonym = "SonYeJin"
                        },


                    },

                     new KDramaActor()
                    {
                        KDrama = new KDrama()
                        {
                            Title = "Crash Landing On You",
                            Description = "Comedy, Romance",
                            Statuses = new List<Status>()
                            {
                                new Status { StatusType = StatusType.Finished }
                            }
                        },

                        Actor = new Actor()
                        {
                            FirstName = "Hyun",
                            LastName = "Bin",
                            Pseudonym = "BinHyun"
                        },


                    },

                    new KDramaActor()
                    {
                        KDrama = new KDrama()
                        {
                            Title = "Reborn Rich",
                            Description = "Murder, Vengeance",
                            Statuses = new List<Status>()
                            {
                                new Status { StatusType = StatusType.Finished }
                            }
                        },

                        Actor = new Actor()
                        {
                            FirstName = "Joong Ki",
                            LastName = "Song",
                            Pseudonym = "SongJoongKi"
                        },


                    }
                };
                dataContext.KDramaActors.AddRange(KDramaActors);
                dataContext.SaveChanges();
            }
        }
    }
}
