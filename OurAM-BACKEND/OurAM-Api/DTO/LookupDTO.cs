using OurAM_Api.Models;

namespace OurAM_Api.DTO
{
    public class LookupDTO
    {
        public IEnumerable<AnimeStatus>? AnimeStatuses { get; set; } = null!;
        public IEnumerable<AnimeType>? AnimeTypes { get; set; } = null!;
        public IEnumerable<Genre>? Genres { get; set; } = null!;
        public IEnumerable<Studio>? Studios { get; set; } = null!;
    }
}
