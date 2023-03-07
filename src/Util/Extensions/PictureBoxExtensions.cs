using System;
using System.Drawing;
using System.Windows.Forms;
using BartenderUI.Util.Structs;

namespace BartenderUI.Util.Extensions
{
    static class PictureBoxExtensions
    {
        private static int Id;
        private static SzabadFoglaltEnum State;

        public static int GetId(this PictureBox o)
        {
            return Id;
        }

        public static PictureBox SetId(this PictureBox o, int value)
        {
            Id = value;
            return o;
        }

        public static SzabadFoglaltEnum GetState(this PictureBox o)
        {
            return State;
        }

        public static PictureBox SetState(this PictureBox o, SzabadFoglaltEnum value)
        { 
            State = value;
            return o;
        }

        public static PictureBox WithName(this PictureBox o, string value)
        {
            o.Name = value;
            return o;
        }

        public static PictureBox AddAll(this PictureBox o, params Control[] values)
        {
            foreach (var control in values)
            {
                o.Controls.Add(control);
            }
            return o;
        }

        private static PictureBox WithImage(this PictureBox o, string value)
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

        public static PictureBox WithSize(this PictureBox o, int value1, int value2)
        {
            o.Size = new Size(value1, value2);
            return o;
        }

        public static PictureBox WithLocation(this PictureBox o, int value1, int value2)
        {
            o.Location = new Point(value1, value2);
            return o;
        }

        public static PictureBox AddDoubleClickEvent(this PictureBox o, EventHandler value)
        {
            o.DoubleClick += value;
            return o;
        }

        public static PictureBox AddMouseDownEvent(this PictureBox o, MouseEventHandler value)
        {
            o.MouseDown += value;
            return o;
        }

        public static PictureBox AddMouseMoveEvent(this PictureBox o, MouseEventHandler value)
        {
            o.MouseMove += value;
            return o;
        }

        public static PictureBox AddMouseUpEvent(this PictureBox o, MouseEventHandler value)
        {
            o.MouseUp += value;
            return o;
        }

        public static PictureBox WithId(this PictureBox o, int value)
        {
            Id = value;
            return o;
        }

        public static PictureBox WithState(this PictureBox o, SzabadFoglaltEnum value)
        {
            State = value;

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

        public static PictureBox WithIdLabel(this PictureBox o)
        {
            o.Paint += new PaintEventHandler((sender, e) =>
            {
                e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

                string text = Id.ToString();

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
