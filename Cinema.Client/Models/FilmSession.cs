using System;

namespace Cinema.Client.Models
{
    class FilmSession
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public int SeatsCount { get; set; }

        public int SeatsCountToBuy { get; set; }
    }
}
