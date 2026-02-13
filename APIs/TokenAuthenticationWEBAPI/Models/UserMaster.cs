namespace TokenAuthenticationWEBAPI.Models
{
    public class UserMaster
    {
        public int UserID { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string UserPassword { get; set; } = string.Empty;
        public string UserRoles { get; set; } = string.Empty;
        public string UserEmailID { get; set; } = string.Empty;
    }
}
