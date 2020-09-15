using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Server.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int SeatsCount { get; set; }
        public DateTime Time { get; set; }
        [ForeignKey(nameof(FilmSession))]
        public int FilmSessionId { get; set; }

        public FilmSession FilmSession { get; set; }
    }
}