using System.Windows.Forms;

namespace BartenderUI.Util.HelperTypes
{
    class Table : PictureBox
    {
        public int Id { get; set; }
        public SzabadFoglaltEnum State { get; set; }
    }
}
