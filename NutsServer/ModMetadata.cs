using SPTarkov.Server.Core.Models.Spt.Mod;

namespace NutsServer;

public record ModMetadata : IModMetadata
{
    public string ModGuid { get; init; } = "com.dragonx86.nuts";
    public string Name { get; init; } = "No Unfair Trade System (NUTS)";
    public string Author { get; init; } = "ViniHNS, DragonX86-dev";
    public SemanticVersioning.Version Version { get; init; } = new("1.5.0");
    public SemanticVersioning.Range SptVersion { get; init; } = new("~4.1.0");
    public bool HasPrepatcher { get; init; }
    public List<string>? Contributors { get; init; }
    public List<string>? Incompatibilities { get; init; }
    public Dictionary<string, SemanticVersioning.Range>? ModDependencies { get; init; }
    public string? Url { get; init; }
    public bool? IsBundleMod { get; init; }
    public string License { get; init; } = "MIT";
}