#region

using System;
using Infected_Twitch.Menus;
using LeagueSharp;
using LeagueSharp.SDK;

#endregion

using EloBuddy; 
 using LeagueSharp.SDK; 
 namespace Infected_Twitch.Event
{
    internal class Trinkets
    {
        public static void Update(EventArgs args)
        {
            if(GameObjects.Player.Level < 9 || !GameObjects.Player.InShop() || !MenuConfig.BuyTrinket) return;
            if(Items.HasItem(3363) || Items.HasItem(3364)) return;
            
            switch (MenuConfig.TrinketList.Index)
            {
                case 0:
                    Shop.BuyItem(ItemId.Oracle_Alteration);
                    break;
                case 1:
                    Shop.BuyItem(ItemId.Farsight_Alteration);
                    break;
            }
        }
    }
}
