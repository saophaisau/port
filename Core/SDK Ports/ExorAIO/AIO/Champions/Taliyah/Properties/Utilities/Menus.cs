
#pragma warning disable 1587

using EloBuddy; 
using LeagueSharp.SDK; 
namespace ExorAIO.Champions.Taliyah
{
    using ExorAIO.Utilities;

    using LeagueSharp.SDK;
    using LeagueSharp.SDK.UI;

    /// <summary>
    ///     The menu class.
    /// </summary>
    internal class Menus
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Initializes the menus.
        /// </summary>
        public static void Initialize()
        {
            /// <summary>
            ///     Sets the menu for the spells.
            /// </summary>
            Vars.SpellsMenu = new Menu("spells", "Spells");
            {
                /// <summary>
                ///     Sets the menu for the Q.
                /// </summary>
                Vars.QMenu = new Menu("q", "Use Q to:");
                {
                    Vars.QMenu.Add(new MenuBool("combo", "Combo", true));
                    Vars.QMenu.Add(new MenuBool("killsteal", "KillSteal", true));
                    Vars.QMenu.Add(new MenuSliderButton("harass", "Harass / if Mana >= x%", 50, 0, 99, true));
                    Vars.QMenu.Add(new MenuSliderButton("laneclear", "LaneClear / if Mana >= x%", 75, 0, 99, true));
                    Vars.QMenu.Add(new MenuSliderButton("jungleclear", "JungleClear / if Mana >= x%", 50, 0, 99, true));
                    Vars.QMenu.Add(new MenuSeparator("separator", "Threaded Volley Options:"));
                    Vars.QMenu.Add(new MenuBool("combofull", "Combo: Only with full Q.", true));
                    Vars.QMenu.Add(new MenuBool("harassfull", "Harass: Only with full Q."));
                    Vars.QMenu.Add(new MenuBool("laneclearfull", "LaneClear: Only with full Q.", true));
                    Vars.QMenu.Add(new MenuBool("jungleclearfull", "JungleClear: Only with full Q.", true));
                }
                Vars.SpellsMenu.Add(Vars.QMenu);

                /// <summary>
                ///     Sets the menu for the W.
                /// </summary>
                Vars.WMenu = new Menu("w", "Use W to:");
                {
                    Vars.WMenu.Add(new MenuBool("combo", "Combo", true));
                    Vars.WMenu.Add(new MenuBool("logical", "Logical", true));
                    Vars.WMenu.Add(new MenuSliderButton("laneclear", "LaneClear / if Mana >= x%", 75, 0, 99, true));
                    Vars.WMenu.Add(new MenuSliderButton("jungleclear", "JungleClear / if Mana >= x%", 50, 0, 99, true));
                    Vars.WMenu.Add(new MenuBool("gapcloser", "Anti-Gapcloser", true));
                    Vars.WMenu.Add(new MenuBool("interrupter", "Interrupt Enemy Channels", true));
                    Vars.WMenu.Add(new MenuSeparator("separator1", "Seismic Shove Options:"));
                    Vars.WMenu.Add(new MenuBool("combofull", "Combo: Don't Cast if E not Ready", true));
                    {
                        /// <summary>
                        ///     Sets the menu for the selection.
                        /// </summary>
                        Vars.W2Menu = new Menu("selection", "Combo: Pull / Push Selection");
                        {
                            foreach (var enemy in GameObjects.EnemyHeroes)
                            {
                                Vars.W2Menu.Add(
                                    new MenuList<string>(
                                        enemy.ChampionName.ToLower(),
                                        enemy.ChampionName,
                                        new[] { "Always Pull", "Always Push", "Only Pull if Killable else Push" }));
                            }
                        }

                        Vars.WMenu.Add(Vars.W2Menu);
                    }
                }

                Vars.SpellsMenu.Add(Vars.WMenu);

                /// <summary>
                ///     Sets the menu for the E.
                /// </summary>
                Vars.EMenu = new Menu("e", "Use E to:");
                {
                    Vars.EMenu.Add(new MenuBool("combo", "Combo", true));
                    Vars.EMenu.Add(new MenuBool("gapcloser", "Anti-Gapcloser", true));
                    Vars.EMenu.Add(new MenuSliderButton("laneclear", "LaneClear / if Mana >= x%", 50, 0, 99, true));
                    Vars.EMenu.Add(new MenuSliderButton("jungleclear", "JungleClear / if Mana >= x%", 50, 0, 99, true));
                }
                Vars.SpellsMenu.Add(Vars.EMenu);
            }

            Vars.Menu.Add(Vars.SpellsMenu);

            /// <summary>
            ///     Sets the miscellaneous menu.
            /// </summary>
            Vars.MiscMenu = new Menu("miscellaneous", "Miscellaneous");
            {
                Vars.MiscMenu.Add(new MenuBool("mountr", "Automatically Mount on R", true));
            }
            Vars.Menu.Add(Vars.MiscMenu);

            /// <summary>
            ///     Sets the menu for the drawings.
            /// </summary>
            Vars.DrawingsMenu = new Menu("drawings", "Drawings");
            {
                Vars.DrawingsMenu.Add(new MenuBool("q", "Q Range"));
                Vars.DrawingsMenu.Add(new MenuBool("w", "W Range"));
                Vars.DrawingsMenu.Add(new MenuBool("e", "E Range"));
                Vars.DrawingsMenu.Add(new MenuBool("r", "R Range"));
            }
            Vars.Menu.Add(Vars.DrawingsMenu);
        }

        #endregion
    }
}