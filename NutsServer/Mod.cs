using SPTarkov.Common.Models.Logging;
using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.DI;
using SPTarkov.Server.Core.Models.Spt.Tables;

namespace NutsServer;

[Injectable(TypePriority = OnLoadOrder.PostLoad + 1)]
public class Mod(ISptLogger<Mod> logger, GlobalTable globalTable) : IOnLoad
{
    public Task OnLoadAsync(CancellationToken cancellationToken)
    {
        logger.Info("[NUTS] Loading...");

        var ragFairConfig = globalTable.Configuration.RagFair;
        ragFairConfig.MinUserLevel = 999;
        
        foreach (var offerCount in ragFairConfig.MaxActiveOfferCount)
        {
            offerCount.Count = 0;
        }
        
        return Task.CompletedTask;
    }
}