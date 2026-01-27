using System.Collections.Generic;
using Terraria.UI;

namespace CombinationsMod.Content.UI.UpgradeStationUI
{
    [Autoload(Side = ModSide.Client)]
    public class UpgradeStationUISystem : ModSystem
    {
        private UserInterface UpgradeInterface;
        internal UpgradeUI UpgradeUI;

        public void ShowMyUI()
        {
            UpgradeInterface?.SetState(UpgradeUI);
        }

        public void HideMyUI()
        {
            UpgradeUI?.CloseUI();
            UpgradeInterface?.SetState(null);
        }
        public bool IsUIOpen()
        {
            return UpgradeInterface.CurrentState != null;
        }

        public override void Load()
        {
            UpgradeInterface = new UserInterface();
            UpgradeUI = new UpgradeUI();
        }

        public override void UpdateUI(GameTime gameTime)
        {
            if (UpgradeInterface?.CurrentState != null)
                UpgradeInterface?.Update(gameTime);
        }

        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int mouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
            if (mouseTextIndex != -1)
            {
                layers.Insert(mouseTextIndex, new LegacyGameInterfaceLayer(
                    "CombinationsMod: Upgrade Station",
                    delegate
                    {
                        if (UpgradeInterface?.CurrentState != null)
                            UpgradeInterface.Draw(Main.spriteBatch, new GameTime());
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
            }
        }
    }
}
