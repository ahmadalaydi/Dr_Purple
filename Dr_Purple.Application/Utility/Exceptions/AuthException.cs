using System.Security.Authentication;

namespace Dr_Purple.Application.Utility.Exceptions;
public class AuthException : AuthenticationException
{
    public string MessageId { get; set; }
    public AuthException(string message, string messageId) : base(message)
       => MessageId = messageId;
}
