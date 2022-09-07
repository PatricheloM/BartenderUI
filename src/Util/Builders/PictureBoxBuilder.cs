using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using BartenderUI.Util.Structs;

namespace BartenderUI.Util.Builders
{
    class PictureBoxBuilder : PictureBox, IBuilder<PictureBoxBuilder>
    {
        public int Id { get; set; }
        public SzabadFoglaltEnum State { get; set; }

        public PictureBoxBuilder GetInstance()
        {
            return this;
        }

        public PictureBoxBuilder WithName(string value)
        {
            Name = value;
            return this;
        }

        public PictureBoxBuilder AddAll(params Control[] values)
        {
            foreach (var control in values)
            {
                Controls.Add(control);
            }
            return this;
        }

        private PictureBoxBuilder WithImage(string value)
        {
            try
            {
                Image = Image.FromFile(value);
            }
            catch (Exception)
            {
                Image = ErrorImage;
            }
            return this;
        }

        public PictureBoxBuilder WithSize(int value1, int value2)
        {
            Size = new Size(value1, value2);
            return this;
        }

        public PictureBoxBuilder WithLocation(int value1, int value2)
        {
            Location = new Point(value1, value2);
            return this;
        }

        public PictureBoxBuilder AddDoubleClickEvent(EventHandler value)
        {
            DoubleClick += value;
            return this;
        }

        public PictureBoxBuilder AddMouseDownEvent(MouseEventHandler value)
        {
            MouseDown += value;
            return this;
        }

        public PictureBoxBuilder AddMouseMoveEvent(MouseEventHandler value)
        {
            MouseMove += value;
            return this;
        }

        public PictureBoxBuilder AddMouseUpEvent(MouseEventHandler value)
        {
            MouseUp += value;
            return this;
        }

        public PictureBoxBuilder WithId(int value)
        {
            Id = value;
            return this;
        }

        public PictureBoxBuilder WithState(SzabadFoglaltEnum value)
        {
            State = value;

            switch (value)
            {
                case SzabadFoglaltEnum.Szabad:
                    return WithImage(FilePathStruct.Szabad);
                case SzabadFoglaltEnum.Foglalt:
                    return WithImage(FilePathStruct.Foglalt);
                default:
                    return this; // Should not happen
            }
        }
    }
}
