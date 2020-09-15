using System;

namespace Cinema.Server.Models
{
    public class FilmSession
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public int SeatsCount { get; set; } = 30;
    }
}