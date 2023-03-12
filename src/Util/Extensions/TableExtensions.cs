using System;
using System.Drawing;
using System.Windows.Forms;
using BartenderUI.Util.HelperTypes;
using BartenderUI.Util.Structs;

namespace BartenderUI.Util.Extensions
{
    static class TableExtensions
    {
        public static Table WithName(this Table o, string value)
        {
            o.Name = value;
            return o;
        }

        public static Table AddAll(this Table o, params Control[] values)
        {
            foreach (var control in values)
            {
                o.Controls.Add(control);
            }
            return o;
        }

        private static Table WithImage(this Table o, string value)
        {
            try
            {
                o.Image = Image.FromFile(value);
            }
            catch (Exception)
            {
                o.Image = o.ErrorImage;
            }
            return o;
        }

        public static Table WithSize(this Table o, int value1, int value2)
        {
            o.Size = new Size(value1, value2);
            return o;
        }

        public static Table WithLocation(this Table o, int value1, int value2)
        {
            o.Location = new Point(value1, value2);
            return o;
        }

        public static Table AddDoubleClickEvent(this Table o, EventHandler value)
        {
            o.DoubleClick += value;
            return o;
        }

        public static Table AddMouseDownEvent(this Table o, MouseEventHandler value)
        {
            o.MouseDown += value;
            return o;
        }

        public static Table AddMouseMoveEvent(this Table o, MouseEventHandler value)
        {
            o.MouseMove += value;
            return o;
        }

        public static Table AddMouseUpEvent(this Table o, MouseEventHandler value)
        {
            o.MouseUp += value;
            return o;
        }

        public static Table WithId(this Table o, int value)
        {
            o.Id = value;
            return o;
        }

        public static Table WithState(this Table o, SzabadFoglaltEnum value)
        {
            o.State = value;

            switch (value)
            {
                case SzabadFoglaltEnum.Szabad:
                    return o.WithImage(FilePathStruct.Szabad);
                case SzabadFoglaltEnum.Foglalt:
                    return o.WithImage(FilePathStruct.Foglalt);
                default:
                    return o; // Should not happen
            }
        }

        public static Table WithIdLabel(this Table o)
        {
            o.Paint += new PaintEventHandler((sender, e) =>
            {
                e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

                string text = o.Id.ToString();

                SizeF textSize = e.Graphics.MeasureString(text, new Font(FontFamily.GenericSerif, 60));
                PointF locationToDraw = new PointF();
                locationToDraw.X = (o.Width / 2) - (textSize.Width / 2);
                locationToDraw.Y = (o.Height / 2) - (textSize.Height / 2);

                e.Graphics.DrawString(text, new Font(FontFamily.GenericSerif, 60), Brushes.Black, locationToDraw);
            });
            return o;
        }
    }
}
