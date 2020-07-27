using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.UI.Elements;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;
using MagicAndAlchemy;
using static Terraria.ModLoader.ModContent;

namespace MagicAndAlchemy.UI
{
    class AlchemicalCraftingUI : UIState
    {
        public UIImageButton craftButton;
        public ItemSlotWrapper[] ingredientSlots;
        public int maxIngredientCount = 5;
        public DragableUIPanel mainPanel;
        public UIImage cauldronImage;
        public Vector2 size;
        public Vector2 pos;

        public override void OnInitialize()
        {
            size = new Vector2(400f, 150f);
            pos = new Vector2(250f, 200f);

            float itemSlotHeight = Main.inventoryBack9Texture.Height;
            float offsetY = 20f;

            float itemSlotWidth = Main.inventoryBack9Texture.Width;
            float offsetX = (size.X - maxIngredientCount * itemSlotWidth) / (maxIngredientCount + 1);

            mainPanel = new DragableUIPanel();
            mainPanel.Left.Set(pos.X, 0f);
            mainPanel.Top.Set(pos.Y, 0f);
            mainPanel.Width.Set(size.X, 0f);
            mainPanel.Height.Set(size.Y, 0f);
            mainPanel.PaddingLeft = 0;
            mainPanel.PaddingRight = 0;
            mainPanel.PaddingBottom = 1;
            mainPanel.PaddingTop = 0;
            int darkColor = 40;
            mainPanel.BackgroundColor = new Color(darkColor + 15, darkColor, darkColor + 15, 180);
            
            Texture2D CauldronImageTexture = GetTexture("MagicAndAlchemy/UI/CauldronImage");
            cauldronImage = new UIImage(CauldronImageTexture);
            cauldronImage.Left.Set((size.X - CauldronImageTexture.Width) / 2, 0f);
            cauldronImage.Top.Set(size.Y - CauldronImageTexture.Height, 0f);
            mainPanel.Append(cauldronImage);

            ingredientSlots = new ItemSlotWrapper[maxIngredientCount];
            int i = 0;
            for (i = 0; i < maxIngredientCount; i++) {
                float x = (offsetX + itemSlotWidth) * i + offsetX;
                ItemSlotWrapper ingredientSlot = new ItemSlotWrapper(ItemSlot.Context.ChestItem, 1f);
                ingredientSlot.Left.Set(x, 0f);
                ingredientSlot.Top.Set(offsetY, 0f);
                ingredientSlot.ValidItemFunc = item => true;
                ingredientSlots[i] = ingredientSlot;
                mainPanel.Append(ingredientSlot);
            }

            Texture2D craftButtonTexture = GetTexture("MagicAndAlchemy/UI/ButtonCraftPotion");
            craftButton = new UIImageButton(craftButtonTexture);
            craftButton.Left.Set(size.X - 74, 0f);
            craftButton.Top.Set(size.Y - 65, 0f);
            mainPanel.Append(craftButton);

            Append(mainPanel);
        }
    }
}