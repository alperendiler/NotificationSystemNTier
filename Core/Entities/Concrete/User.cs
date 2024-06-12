namespace Core.Entities.Concrete
{
    public class User<TId> : Entity<TId>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }

        public User()
        {
            Email = string.Empty;
            FirstName = string.Empty;
            LastName = string.Empty;
            UserName = string.Empty;
            PasswordHash = Array.Empty<byte>();
            PasswordSalt = Array.Empty<byte>();
        }

        public User(string email, string userName, string firstName, string lastName, byte[] passwordSalt, byte[] passwordHash)
        {
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Email = email;
            PasswordSalt = passwordSalt;
            PasswordHash = passwordHash;
        }

        public User(TId id, string email, string userName, string firstName, string lastName, byte[] passwordSalt, byte[] passwordHash)
            : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Email = email;
            PasswordSalt = passwordSalt;
            PasswordHash = passwordHash;
        }
    }
}
