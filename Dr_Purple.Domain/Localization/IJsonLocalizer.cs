using Microsoft.Extensions.Localization;

namespace Dr_Purple.Domain.Localization;
public interface IJsonLocalizer
{
    LocalizedString this[string name] { get; }
    IAsyncEnumerable<LocalizedString> GetAllStrings();
}