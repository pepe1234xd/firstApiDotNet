using Walks.Api.Models.DTO;

namespace Walks.Api.Models.DTO
{
    public class Walk
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public double Length { get; set; }
        public Guid RegionID { get; set; }
        public Guid WalkDifficultId { get; set; }

        //navigation properties
        public Region Region { get; set; }
        public WalkDificulty WalkDifficult { get; set; }
    }
}
