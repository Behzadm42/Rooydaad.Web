using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace Rooydaad.Web.Models
{
    public interface IDatabase
    {
        public List<EventViewModel> getallevents();
    }
    public class Database:IDatabase
    {

        private List<EventViewModel> _lists;
        private readonly IMapper mapper;
        public Database(IMapper mapper)
        {
            this.mapper = mapper;
        }
        public List<EventViewModel> getallevents()
        {
            List<Event> list = new List<Event>();
            if (_lists != null)
                return _lists;
            for (int i = 0; i < 15; i++)
            {
                list.Add(new Event()
                {
                    name = "event" + i.ToString(),
                    image = "https://photokade.com/wp-content/uploads/bamdad-photokade-cars-s1-" + (i + 1).ToString() + ".jpg",
                    description = "wow ..! \n thats amazing car"
                });
            }
            return list.Select(a => mapper.Map<Event, EventViewModel>(a)).ToList();
        }
    }
}
