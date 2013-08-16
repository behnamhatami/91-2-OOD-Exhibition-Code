using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OOD.Model.ExhibitionPackage.ExhibitionProgressPackage.ExhibitionBoothPackage;

namespace OOD.UI.ExhibitionPackage.ExhibitionProgressPackage.ExhibitionBoothPackage
{
    public static class BoothDrawerHelper
    {


        public static void DrawSaloon(Saloon saloon, FlowLayoutPanel panel)
        {
            var width = saloon.Map.Width;
            var height = saloon.Map.Height;
            var buttonWidth = 30 + 6;
            var buttonHeight = 25 + 6;
            var count = width * height;
            panel.Size = new System.Drawing.Size(width * buttonWidth, height * buttonHeight);

            panel.Controls.Clear();
            foreach (var booth in saloon.Map.Booths.OrderBy(booth => booth.Index))
                panel.Controls.Add(CreateButton(booth));
        }


        public static Button CreateButton(Booth booth)
        {
            var button = new Button();
            button.Size = new System.Drawing.Size(30, 25);
            button.TabIndex = booth.Index;
            button.Text = booth.Index + "";
            button.UseVisualStyleBackColor = true;
            ButtonReDraw(booth, button);
            return button;
        }

        public static Booth GetBooth(Button button, Saloon saloon)
        {
            var index = int.Parse(button.Text);
            return saloon.Map.Booths.First(booth1 => booth1.Index == index);
        }

        public static void ButtonReDraw(Booth booth, Button button)
        {
            if (!booth.Enabled)
                button.BackColor = System.Drawing.Color.LightCoral;
            else
            {
                if (booth.Request != null)
                    button.BackColor = System.Drawing.Color.LightGreen;
                else button.BackColor = System.Drawing.Color.LemonChiffon;
            }
        }

    }
}
