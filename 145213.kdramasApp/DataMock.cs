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
            if (!dataContext.Actors.Any())
            {

                var Networks = new List<Network>()
                {

                    new Network()
                    {
                        OfficialName = "tvN",
                        Residence = "South Korea",
                        Owner = "CJ E&M",
                        Broadcast = new DateTime(2006, 10, 9),
                        Language = "Korean",

                        KDramas = new List<KDrama>()
                        {
                            new KDrama()
                            {
                                Title = "Reborn Rich",
                                Description = "Murder, Vengeance",
                                Status = StatusType.Finished,
                                Data = new DateTime(2022, 11, 18),
                                Actors = new List<Actor>()
                                {
                                    new Actor()
                                    {
                                           FirstName = "Joong Ki",
                                           LastName = "Song",
                                           Pseudonym = "SongJoongKi",
                                    },
                                }
                            },
                        }

                    },


                    new Network()
                    {
                        OfficialName = "Netflix",
                        Residence = "USA",
                        Owner = "Public",
                        Broadcast = new DateTime(1997, 08, 29),
                        Language = "Multilingual",

                        KDramas = new List<KDrama>()
                        {
                            
                            new KDrama()
                            {
                                    Title = "Crash Landing On You",
                                    Description = "Comedy, Romance",
                                    Status = StatusType.Finished,
                                    Data = new DateTime(2019, 12, 14),
                                    Actors = new List<Actor>()
                                    {
                                        new Actor()
                                        {
                                               FirstName = "Hyun",
                                               LastName = "Bin",
                                               Pseudonym = "BinHyun",
                                        },
                                        new Actor()
                                        {
                                               FirstName = "Ye Jin",
                                               LastName = "Son",
                                               Pseudonym = "SonYeJin",
                                        }
                                    }
                            },

                            new KDrama()
                            {
                                Title = "The Glory",
                                Description = "Soap Opera",
                                Status= StatusType.Ongoing,
                                Data = new DateTime(2022, 12, 30),
                                Actors = new List<Actor>()
                                {
                                    new Actor()
                                        {
                                               FirstName = "Hye Kyo",
                                               LastName = "Song",
                                               Pseudonym = "SongHyeKyo",
                                        }
                                }
                            }
                        }

                    }


                };


                dataContext.Networks.AddRange(Networks);             
                dataContext.SaveChanges();
            }
        
        }
    }
}
