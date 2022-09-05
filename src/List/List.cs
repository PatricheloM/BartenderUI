using System;
using System.Windows.Forms;
using BartenderUI.Util;

namespace BartenderUI.List
{
    class List : AbstractList
    {
        public List(int id)
        {
            InitializeComponents();
            GridFiller.FillGrid(dataGridView, id);
        }

        protected override void CellEndEditEvent(object sender, DataGridViewCellEventArgs e)
        {
            throw new NotImplementedException();
        }

        protected override void EditingControlShowingEvent(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            throw new NotImplementedException();
        }

        protected override void ListClosingEvent(object sender, FormClosingEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
