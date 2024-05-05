using Dr_Purple.Domain.Attributes;
using Dr_Purple.Domain.Entities.Appointments;
using Dr_Purple.Domain.Entities.Contracts;
using Dr_Purple.Domain.Enums;
using Dr_Purple.Domain.Interfaces;
using System.Text.Json.Serialization;

namespace Dr_Purple.Domain.Entities.Users;
[NotAuditable]
public partial class User : IEntity
{
    public long Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string UserName { get; private set; }
    public string Email { get; private set; }
    public string ContactNumber { get; private set; }
    public string? Address { get; private set; }

    [JsonIgnore]
    public byte[] PasswordSalt { get; private set; }

    [JsonIgnore]
    public byte[] PasswordHash { get; private set; }

    [JsonIgnore]
    public string FCM_Key { get; private set; }
    public bool IsVerified { get; private set; }
    public Role Role { get; private set; }
    public Gender Gender { get; private set; }
    [JsonIgnore]
    public string RefreshToken { get; private set; }
    public DateTime RefreshTokenExpiryTime { get; private set; }

    public string ProfilePicPath { get; private set; } = string.Empty;

    [JsonIgnore]
    public byte[]? RowVersion { get; set; }

    [JsonIgnore]
    public virtual ICollection<Appointment> Appointments { get; private set; } = new HashSet<Appointment>();

    [JsonIgnore]
    public virtual ICollection<Contract> Contracts { get; private set; } = new HashSet<Contract>();

    protected User(string firstName, string lastName, string userName,
    string email, string contactNumber,
    byte[] passwordSalt, byte[] passwordHash,
    Role role, Gender gender, string refreshToken,
    DateTime refreshTokenExpiryTime)
    {
        FirstName = firstName;
        LastName = lastName;
        UserName = userName;
        Email = email;
        ContactNumber = contactNumber;
        PasswordSalt = passwordSalt;
        PasswordHash = passwordHash;
        Role = role;
        Gender = gender;
        RefreshToken = refreshToken;
        RefreshTokenExpiryTime = refreshTokenExpiryTime;
        IsVerified = false;
        FCM_Key = string.Empty;
    }

    public static User Create(string firstName, string lastName, string userName,
                            string email, string contactNumber,
                            byte[] passwordSalt, byte[] passwordHash,
                            Role role, Gender gender, string refreshToken,
                            DateTime refreshTokenExpiryTime)
                            => new(firstName, lastName, userName, email,
                                    contactNumber, passwordSalt, passwordHash,
                                    role, gender, refreshToken, refreshTokenExpiryTime);

    public void Update(string firstName, string lastName, string userName, string email,
                        string contactNumber, string? address, Gender gender)
    {
        FirstName = firstName;
        LastName = lastName;
        UserName = userName;
        Email = email;
        ContactNumber = contactNumber;
        Address = address;
        Gender = gender;
    }
    public void Update(string profilePicPath)
        => ProfilePicPath = profilePicPath;
    public void UpdateRefreshToken(string refreshToken)
        => RefreshToken = refreshToken;

    public void Logout()
    {
        RefreshToken = string.Empty;
        RefreshTokenExpiryTime = DateTime.UtcNow;
    }

    public void Verify()
    => IsVerified = true;

    public void UpdateFCM_Key(string fcm_Key)
        => FCM_Key = fcm_Key;
}