using Dr_Purple.Domain.Entities.Appointments;
using Dr_Purple.Domain.Entities.Base;
using Dr_Purple.Domain.Entities.Contracts;
using Dr_Purple.Domain.Enums;
using Dr_Purple.Domain.Interfaces;
using System.Text.Json.Serialization;

namespace Dr_Purple.Domain.Entities.Users;
public partial class User : AuditableEntity, IEntity
{
    public long? Id { get; private set; }
    public string? FirstName { get; private set; }
    public string? LastName { get; private set; }
    public string? UserName { get; private set; }
    public string? ContactNumber { get; private set; }
    public long? AddressId { get; private set; }
    [JsonIgnore]
    public byte[]? PasswordSalt { get; private set; }
    [JsonIgnore]
    public byte[]? PasswordHash { get; private set; }
    public Role? Role { get; private set; }
    public Gender? Gender { get; private set; }
    public string? RefreshToken { get; private set; }
    public DateTime? RefreshTokenExpiryTime { get; private set; }
    public virtual ICollection<Appointment>? Appointments { get; private set; }
    public virtual ICollection<Contract>? Contracts { get; private set; }


    public User(string? firstName, string? lastName, string? userName,
    string? contactNumber, long? addressId,
    byte[]? passwordSalt, byte[]? passwordHash,
    Role? role, Gender? gender, string? refreshToken,
    DateTime? refreshTokenExpiryTime)
    {
        FirstName = firstName;
        LastName = lastName;
        UserName = userName;
        ContactNumber = contactNumber;
        AddressId = addressId;
        PasswordSalt = passwordSalt;
        PasswordHash = passwordHash;
        Role = role;
        Gender = gender;
        RefreshToken = refreshToken;
        RefreshTokenExpiryTime = refreshTokenExpiryTime;
    }

    public static User Create(string firstName, string lastName, string userName,
                            string contactNumber, long? addressId,
                            byte[]? passwordSalt, byte[]? passwordHash,
                            Role? role, Gender? gender, string? refreshToken,
                            DateTime? refreshTokenExpiryTime)
                            => new(firstName, lastName, userName,
                                    contactNumber, addressId, passwordSalt, passwordHash,
                                    role, gender, refreshToken, refreshTokenExpiryTime);
}