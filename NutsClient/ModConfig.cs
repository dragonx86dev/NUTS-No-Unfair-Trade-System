using BepInEx.Configuration;

namespace NutsClient;

public static class ModConfig
{
    public static ConfigEntry<bool> DisableFleaWarning;
    public static ConfigEntry<bool> DisableFleaButtons;
    public static ConfigEntry<bool> DisableContextMenuAddOffer;
    public static ConfigEntry<bool> DisableMyOffersToggle;
    public static ConfigEntry<bool> DisableLockedIcon;
    public static ConfigEntry<bool> DisableFleaMarketTab; 
    public static ConfigEntry<bool> EnableDebugLogging;
}