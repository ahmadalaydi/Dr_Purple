namespace Dr_Purple.Domain.Localization;
public interface IJsonLocalizerFactory
{
    IJsonLocalizer Create(Type resourceSource);
    IJsonLocalizer Create(string baseName, string location);
}