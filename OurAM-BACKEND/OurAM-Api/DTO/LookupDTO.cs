using OurAM_Api.Models;

namespace OurAM_Api.DTO
{
    public class LookupDTO
    {
        public IEnumerable<GenericLookupDTO>? AnimeStatuses { get; set; } = null!;
        public IEnumerable<GenericLookupDTO>? AnimeTypes { get; set; } = null!;
        public IEnumerable<GenericLookupDTO>? Genres { get; set; } = null!;
        public IEnumerable<GenericLookupDTO>? Studios { get; set; } = null!;
    }
}
