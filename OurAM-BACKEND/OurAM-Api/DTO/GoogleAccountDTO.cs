namespace OurAM_Api.DTO
{
    public class GoogleAccountDTO
    {
        public string TokenId { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Avatar { get; set; }
        public string Provider { get; set; } = null!;
    }
}
