using System;
using System.Collections.Generic;

namespace webapi5.Models
{
    public partial class Movies
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int DirectorId { get; set; }
        public int CopyrightYear { get; set; }
        public TimeSpan Length { get; set; }
        public int GenreId { get; set; }
        public int CategoryId { get; set; }
        public decimal Rating { get; set; }
        public string Notes { get; set; }
    }
}
