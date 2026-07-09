using System.Collections.Generic;
using CombinationsMod.Content.Global_Classes;
using Humanizer;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.GameInput;
using Terraria.UI;
using static System.Net.Mime.MediaTypeNames;

namespace CombinationsMod.Content.UI.UpgradeStationUI
{
    public class UpgradeUI : UIState
    {
        public DraggableUIPanel UpgradePanel;
        public UpgradeItemSlot slot;
        public UpgradeItemSlot[] upgradeSlots;
        private string localText = "Mods.CombinationsMod.LocalizedText.UpgradeUI.";
        private string itemText = "Mods.CombinationsMod.Items.";
        public UITextBox textBox;
        public string UpgradeInfo = "";
        public UIText DescriptionText;
        public UIPanel SlotsPanel;


        public Color panelColor = new Color(18, 18, 18) * 0.8f;

        public override void OnInitialize()
        {
            UpgradePanel = new DraggableUIPanel();
            UpgradePanel.SetPadding(0);
            UpgradePanel.HAlign = 0.5f;
            UpgradePanel.VAlign = 0.5f;
            UpgradePanel.Width.Set(800f, 0f);
            UpgradePanel.Height.Set(475f, 0f);
            UpgradePanel.BackgroundColor = panelColor;
            Append(UpgradePanel);

            UIImage panelBG = new UIImage(ModContent.Request<Texture2D>("CombinationsMod/Content/UI/UpgradeStationUI/Assets/slot").Value);
            panelBG.ScaleToFit = true;
            UpgradePanel.Append(panelBG);

            SlotsPanel = new UIPanel();
            SlotsPanel.SetPadding(0);
            SlotsPanel.HAlign = 0.05f;
            SlotsPanel.VAlign = 0.5f;
            SlotsPanel.Width.Set(250f, 0);
            SlotsPanel.Height.Set(250f, 0);
            SlotsPanel.BackgroundColor = Color.Transparent;
            SlotsPanel.BorderColor = Color.Transparent;
            UpgradePanel.Append(SlotsPanel);

            slot = new UpgradeItemSlot(upgradeSlots);
            slot.SetPadding(0);
            slot.HAlign = 0.5f;
            slot.VAlign = 0.5f;
            slot.Width.Set(70f, 0f);
            slot.Height.Set(70f, 0f);
            slot.scale = 1.3f;
            SlotsPanel.Append(slot);

            upgradeSlots = new UpgradeItemSlot[4];
            upgradeSlots[0] = new UpgradeItemSlot(slot, 0);
            upgradeSlots[0].SetPadding(0);
            upgradeSlots[0].HAlign = 0.1f;
            upgradeSlots[0].VAlign = 0.5f;
            upgradeSlots[0].Width.Set(52f, 0f);
            upgradeSlots[0].Height.Set(52f, 0f);
            UIText SideSlot = new UIText(Language.GetTextValue(localText + "WeightMods"), 0.8f);
            SideSlot.SetPadding(0);
            SideSlot.HAlign = 0.5f;
            SideSlot.VAlign = 1.4f;
            upgradeSlots[0].Append(SideSlot);

            upgradeSlots[1] = new UpgradeItemSlot(slot, 1);
            upgradeSlots[1].SetPadding(0);
            upgradeSlots[1].HAlign = 0.9f;
            upgradeSlots[1].VAlign = 0.5f;
            upgradeSlots[1].Width.Set(52f, 0f);
            upgradeSlots[1].Height.Set(52f, 0f);
            UIText AxleSlot = new UIText(Language.GetTextValue(localText + "Axles"), 0.8f);
            AxleSlot.SetPadding(0);
            AxleSlot.HAlign = 0.5f;
            AxleSlot.VAlign = 1.4f;
            upgradeSlots[1].Append(AxleSlot);

            upgradeSlots[2] = new UpgradeItemSlot(slot, 2);
            upgradeSlots[2].SetPadding(0);
            upgradeSlots[2].HAlign = 0.5f;
            upgradeSlots[2].VAlign = 0.1f;
            upgradeSlots[2].Width.Set(52f, 0f);
            upgradeSlots[2].Height.Set(52f, 0f);
            UIText BearingSlot = new UIText(Language.GetTextValue(localText + "BallBearings"), 0.8f);
            BearingSlot.SetPadding(0);
            BearingSlot.HAlign = 0.5f;
            BearingSlot.VAlign = -0.4f;
            upgradeSlots[2].Append(BearingSlot);

            upgradeSlots[3] = new UpgradeItemSlot(slot, 3);
            upgradeSlots[3].SetPadding(0);
            upgradeSlots[3].HAlign = 0.5f;
            upgradeSlots[3].VAlign = 0.9f;
            upgradeSlots[3].Width.Set(52f, 0f);
            upgradeSlots[3].Height.Set(52f, 0f);
            upgradeSlots[3].BackgroundColor = Color.White;
            UIText LEDText = new UIText(Language.GetTextValue(localText + "ResponsePad"), 0.8f);
            LEDText.SetPadding(0);
            LEDText.HAlign = 0.5f;
            LEDText.VAlign = 1.4f;
            upgradeSlots[3].Append(LEDText);

            foreach (var val in upgradeSlots)
                SlotsPanel.Append(val);

            UIText DescriptionTitle = new UIText(Language.GetTextValue(localText + "DescriptionTitle"), 1.2f);
            DescriptionTitle.SetPadding(0);
            DescriptionTitle.HAlign = 0.7f;
            DescriptionTitle.VAlign = 0.07f;
            UpgradePanel.Append(DescriptionTitle);

            DescriptionText = new UIText(UpgradeInfo, 0.9f);
            DescriptionText.SetPadding(0);
            DescriptionText.Left.Set(UpgradePanel.Width.Pixels * 0.4f, 0);
            DescriptionText.Top.Set(UpgradePanel.Height.Pixels * 0.2f, 0);
            DescriptionText.Width.Set(450, 0);
            DescriptionText.Height.Set(500, 0);
            DescriptionText.TextOriginX = 0f;
            DescriptionText.TextOriginY = 0f;
            DescriptionText.IsWrapped = true;
            UpgradePanel.Append(DescriptionText);

            Asset<Texture2D> closeAsset = ModContent.Request<Texture2D>("CombinationsMod/Content/UI/UpgradeStationUI/Assets/SearchCancel", AssetRequestMode.ImmediateLoad);
            CloseButton closeButton = new CloseButton(closeAsset, "close")
            {
                HAlign = 0.99f,
                VAlign = 0.02f
            };
            UpgradePanel.Append(closeButton);
        }

        public void CloseUI()
        {
            if (slot?.item.type != ItemID.None)
            slot?.ReturnHeldItemToPlayer(); // Prevents UI from spamming pickup sounds, due to trying to give the player "nothing" every frame

            if (upgradeSlots is not null)
            foreach(var item in upgradeSlots)
            {
                item.item.TurnToAir();
            }

            DescriptionText?.SetText("");
            UpgradeInfo = "";
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            UpgradeInfo = "";

            if (!slot.item.IsAir)
            {
                LocalizedText text = Language.GetText(localText + "Titles");
                string[] arr = new string[4];

                for (int i = 0; i < upgradeSlots.Length; i++)
                {
                    // axle

                    bool noAxle = false;
                    bool noBearing = false;
                    if (i == 1)
                    {
                        if (upgradeSlots[i].item.IsAir)
                        {
                            arr[i] = Language.GetTextValue(localText + "NoAxle") + "\n";
                            continue;
                        }
                    }
                    else if (i == 2)
                    {
                        if (upgradeSlots[i].item.IsAir)
                        {
                            arr[i] = Language.GetTextValue(localText + "NoBearing") + "\n";
                            continue;
                        }
                    }

                    if (upgradeSlots[i].item.ModItem is IYoyoUpgrade upgrade)
                    {
                        var lines = Lang.GetTooltip(upgradeSlots[i].item.ModItem.Type);
                        string result = string.Empty;
                        for (int e = 0; e < lines.Lines; e++)
                        {
                            result += lines.GetLine(e).ToString();
                            if (e != lines.Lines) // stopping the last line from having a newline
                                result += "\n";
                        }
                        arr[i] = result;
                    }
                    else if (upgradeSlots[i].item.IsAir)
                    {
                        arr[i] = Language.GetTextValue(localText + "None");
                        arr[i] += "\n";
                    }
                    else if (upgradeSlots[i].item.IsAir)
                    {
                        arr[i] = Language.GetTextValue(localText + "None");
                        arr[i] += "\n";
                    }

                }

                UpgradeInfo += text.Format(arr);
              
            }
            else
            {
                UpgradeInfo += Language.GetTextValue(localText + "InsertYoyo") + "\n";
                DescriptionText.SetText(UpgradeInfo);
                DescriptionText.Recalculate();
            }

            DescriptionText.SetText(UpgradeInfo);
            DescriptionText.Recalculate();
        }
    }

    public class UpgradeItemSlot : UITextButton
    {
        public Item item = new(ItemID.None);
        private bool _accessoriesOnly = false;
        private int _index = -1;
        private UpgradeItemSlot _mainSlot;
        private UpgradeItemSlot[] _slots;
        public float scale = 1f;

        public UpgradeItemSlot(UpgradeItemSlot[] slots)
        {
            _slots = slots;
            OnLeftClick += (a, b) => ClickHandler();
            item.TurnToAir();
        }

        public UpgradeItemSlot(UpgradeItemSlot mainSlot, int idx)
        {
            _accessoriesOnly = true;
            _index = idx;
            _mainSlot = mainSlot;

            OnLeftClick += (a, b) => ClickHandler();
        }

        public void ReturnHeldItemToPlayer()
        {
            Main.LocalPlayer.GetItem(Main.myPlayer, item.Clone(), GetItemSettings.InventoryUIToInventorySettings);
            item.TurnToAir();
        }

        public override void Update(GameTime gameTime)
        {
            if(_accessoriesOnly)
            {
                if (!_mainSlot.item.IsAir)
                {
                    item = _mainSlot.item.GetGlobalItem<GlobalYoyoUpgrade>().yoyoUpgrades[_index];
                }
                else
                    item.TurnToAir();
            }
        }

        //called when UI slot is left clicked
        public void ClickHandler()
        {
            if ((_accessoriesOnly && _mainSlot.item.IsAir))
                return;

            Item deposit = Main.mouseItem;
            Player player = Main.LocalPlayer;

            // Prevents the player from duplicating the yoyo, by dropping it in the slot when using the yoyo
            for (int i = 0; i < Main.maxProjectiles; i++)
            {
                Projectile p = Main.projectile[i];

                if (p.active && p.owner == player.whoAmI)
                {
                    if (p.aiStyle == ProjAIStyleID.Yoyo)
                        return;
                }
            }

            if (PlayerInput.Triggers.Current.SmartSelect)
            {
                int invSlot = getFreeInventorySlot(Main.LocalPlayer);

                if (!item.IsAir && invSlot != -1)
                {
                    Main.LocalPlayer.GetItem(Main.myPlayer, item.Clone(), GetItemSettings.InventoryUIToInventorySettings);

                    item.TurnToAir();

                    if (_accessoriesOnly && !_mainSlot.item.IsAir)
                    {
                        _mainSlot.item.GetGlobalItem<GlobalYoyoUpgrade>().yoyoUpgrades[_index].TurnToAir();
                    }
                }

                return;
            }

            if (Main.mouseItem.IsAir && !item.IsAir) // no item in hand and item in slot
            {
                Player owner = Main.LocalPlayer;
                Main.mouseItem = item.Clone();
                item.TurnToAir();

                // removing the upgrade from the yoyo
                if (_accessoriesOnly && !_mainSlot.item.IsAir)
                {
                    _mainSlot.item.GetGlobalItem<GlobalYoyoUpgrade>().yoyoUpgrades[_index].TurnToAir();
                }

                Terraria.Audio.SoundEngine.PlaySound(SoundID.Grab);

                return;
            }

            if ((ItemID.Sets.Yoyo[deposit.type] && _index == -1) || (ItemSets.YoyoWeightMod[deposit.type] && _index == 0) || (ItemSets.YoyoAxle[deposit.type] && _index == 1) ||
                (ItemSets.YoyoBearing[deposit.type] && _index == 2) || (ItemSets.YoyoResponsePad[deposit.type] && _index == 3))
            {
                if (item.IsAir) // item in hand and no item in slot
                {
                    Item temp = item;
                    item = Main.mouseItem;
                    Main.mouseItem = temp;
                    Terraria.Audio.SoundEngine.PlaySound(SoundID.Grab);

                    // updating the yoyo upgrade list to contain the new item
                    if (_accessoriesOnly && !_mainSlot.item.IsAir)
                    {
                        _mainSlot.item.GetGlobalItem<GlobalYoyoUpgrade>().yoyoUpgrades[_index] = item.Clone();
                    }

                    return;
                }

                // updating the yoyo upgrade list to contain the new item
                if (!item.IsAir) // swap
                {
                    Item temp = item;
                    item = Main.mouseItem;
                    Main.mouseItem = temp;


                    if (_accessoriesOnly && !_mainSlot.item.IsAir)
                    {
                        _mainSlot.item.GetGlobalItem<GlobalYoyoUpgrade>().yoyoUpgrades[_index] = item.Clone();
                    }

                    Terraria.Audio.SoundEngine.PlaySound(SoundID.Grab);
                }
            }
        }

        public static int getFreeInventorySlot(Player Player)
        {
            for (int k = 0; k < 49; k++)
            {
                Item Item = Player.inventory[k];

                if (Item is null || Item.IsAir)
                    return k;
            }

            return -1;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            //base.Draw(spriteBatch);

            foreach(var child in Children)
            {
                child.Draw(spriteBatch);
            }

            Texture2D tex = ModContent.Request<Texture2D>("CombinationsMod/Content/UI/UpgradeStationUI/Assets/slot").Value;
            spriteBatch.Draw(tex, GetDimensions().Center(), null, Color.White * 0.8f, 0, tex.Size() / 2, scale, 0, 0);

            if (item == null)
                return;

            if (!item.IsAir)
            {
                Texture2D tex2 = TextureAssets.Item[item.type].Value;
                spriteBatch.Draw(tex2, GetDimensions().Center(), null, Color.White, 0, tex2.Size() / 2, scale, 0, 0);
            }

            if (IsMouseHovering && !item.IsAir)
            {
                Main.HoverItem = item.Clone();
                Main.hoverItemName = item.Name;
            }
            
        }
    }
}
