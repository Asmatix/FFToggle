using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Exiled.API.Features;
using Exiled.API.Features.Core.Generic;
using Exiled.API.Features.Items;
using Exiled.API.Interfaces;
using Exiled.Events.EventArgs.Server;
using PluginAPI.Events;



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
                Log.Warn("Видано предмет живим гравцям!");
                player.AddItem(ItemType.Jailbird);
            }
        }
    }
}


