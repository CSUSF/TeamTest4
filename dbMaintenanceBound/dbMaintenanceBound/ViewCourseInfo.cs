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
    public partial class ViewCourseInfo : Form
    {
        public ViewCourseInfo()
        {
            InitializeComponent();
        }

        private void courseInfoBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.courseInfoBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.attendanceDataSet);

        }

        private void ViewCourseInfo_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'attendanceDataSet.courseInfo' table. You can move, or remove it, as needed.
            this.courseInfoTableAdapter.Fill(this.attendanceDataSet.courseInfo);

        }
    }
}
