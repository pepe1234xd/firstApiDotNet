namespace Walks.Api.Models.DTO
{
    public class UpdateRegionRequest
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public double Area { get; set; }
        public double Long { get; set; }
        public double Lat { get; set; }
        public long Population { get; set; }
    }
}
