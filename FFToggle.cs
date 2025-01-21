using Exiled.API.Features;
using Exiled.Events.EventArgs.Server;
using MEC;
using System.Collections.Generic;
using System.Linq;



namespace FFToggle
{
    public class FFToggle : Plugin<Config>
    {

        public override void OnEnabled()
        {
            Exiled.Events.Handlers.Server.WaitingForPlayers += WaitingForPlayers;
            Exiled.Events.Handlers.Server.RoundEnded += RoundEndedEvent;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Server.WaitingForPlayers -= WaitingForPlayers;
            Exiled.Events.Handlers.Server.RoundEnded -= RoundEndedEvent;
            base.OnDisabled();
        }
        public void WaitingForPlayers()
        {
            Exiled.API.Features.Server.FriendlyFire = false;
        }
        public void RoundEndedEvent(RoundEndedEventArgs ev)
        {
            Exiled.API.Features.Server.FriendlyFire = true;
            foreach (Player player in Player.List.Where(x => x.IsAlive))
            {
                Log.Warn("Выдан предмет живым игрокам!");
                player.AddItem(ItemType.Jailbird);
            }
        }
    }
}


