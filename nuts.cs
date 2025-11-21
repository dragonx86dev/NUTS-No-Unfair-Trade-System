using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.DI;
using SPTarkov.Server.Core.Models.Spt.Mod;          
using SPTarkov.Server.Core.Models.Utils;             
using SPTarkov.Server.Core.Services;
using SemanticVersioning;

namespace nuts;

/// <summary>
/// This is the replacement for the former package.json data. This is required for all mods.
///
/// This is where we define all the metadata associated with this mod.
/// You don't have to do anything with it, other than fill it out.
/// All properties must be overriden, properties you don't use may be left null.
/// It is read by the mod loader when this mod is loaded.
/// </summary>
public record ModMetadata : AbstractModMetadata
{
    /// <summary>
    /// Any string can be used for a modId, but it should ideally be unique and not easily duplicated
    /// a 'bad' ID would be: "mymod", "mod1", "questmod"
    /// It is recommended (but not mandatory) to use the reverse domain name notation,
    /// see: https://docs.oracle.com/javase/tutorial/java/package/namingpkgs.html
    /// </summary>
    public override string ModGuid { get; init; } = "com.vinihns.nuts"; // ID único para seu mod
    public override string Name { get; init; } = "No Unfair Trade System (NUTS)";
    public override string Author { get; init; } = "ViniHNS";
    public override SemanticVersioning.Version Version { get; init; } = new("1.4.0");
    public override SemanticVersioning.Range SptVersion { get; init; } = new("~4.0.0");
    public override List<string>? Contributors { get; init; }
    public override List<string>? Incompatibilities { get; init; }
    public override Dictionary<string, SemanticVersioning.Range>? ModDependencies { get; init; }
    public override string? Url { get; init; }
    public override bool? IsBundleMod { get; init; }
    public override string? License { get; init; } = "MIT";
}

// We want to load after PostDBModLoader is complete, so we set our type priority to that, plus 1.
[Injectable(TypePriority = OnLoadOrder.PostDBModLoader + 1)]
public class Mod(
    ISptLogger<Mod> logger, 
    DatabaseService databaseService)
    : IOnLoad 
{
    
    public Task OnLoad()
    {
        logger.Info("[ViniHNS] NUTS: Loading...");

        // Get the globals table from the database
        var globals = databaseService.GetGlobals();

        var ragfairConfig = globals.Configuration.RagFair;

        ragfairConfig.MinUserLevel = 999;
        
        foreach (var offerCount in ragfairConfig.MaxActiveOfferCount)
        {
            offerCount.Count = 0;
        }
        
        return Task.CompletedTask;
    }
}
