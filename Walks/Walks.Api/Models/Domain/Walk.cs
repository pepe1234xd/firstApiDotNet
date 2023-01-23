namespace Walks.Api.Models.Domain
{
    public class Walk
    {
        public Guid ID { get; set; }
        public string FullName { get; set; }
        public double Length { get; set; }
        public Guid RegionID { get; set; }
        public Guid WalkDifficultId { get; set; }

        //navigation properties
        public Region Region { get; set; }
        public WalkDifficult WalkDifficult { get; set; }
    }
}
