using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dbMaintenanceBound
{
    public partial class ViewBlackOutDates : Form
    {
        public ViewBlackOutDates()
        {
            InitializeComponent();
        }

        private void blackOutDatesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.blackOutDatesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.attendanceDataSet);

        }

        private void ViewBlackOutDates_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'attendanceDataSet.blackOutDates' table. You can move, or remove it, as needed.
            this.blackOutDatesTableAdapter.Fill(this.attendanceDataSet.blackOutDates);

        }
    }
}
