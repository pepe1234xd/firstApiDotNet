namespace Walks.Api.Models.DTO
{
    public class UpdateWalkRequest
    {
        public string FullName { get; set; }
        public double Length { get; set; }
        public Guid RegionID { get; set; }
        public Guid WalkDifficultId { get; set; }
    }
}
