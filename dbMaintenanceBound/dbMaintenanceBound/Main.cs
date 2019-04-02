using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// NOTE: the common library for SQL database access needs to be added to the class.
using System.Data.SqlClient;

namespace dbMaintenanceBound
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void LoadTablesNames()
        {
            /* SqlConnection:
             * 
             *   This approach to using the database starts by opening a connection to the database that can be used to 
             *   extract information about the system until the connection is closed.
             *   
             *   In the tutorial example you used SqlAdapter to open a connection, query the db, extract results and then close the db.
             *   
             */

            // The SqlConnection needs the connection string to access the database.  In the program the Data Source wizard was used 
            //   to establish the initial connection.  So we access that string from the Properties section of the project.
            SqlConnection connection = new SqlConnection(Properties.Settings.Default.AttendanceConnectionString);

            // Open a connection to the database
            connection.Open();

            // Using the DataTable class extract the tables for the database using the .GetSchema property.
            //   Remember from CSCI 102 the schema for a database is the metadata bout the database that describes how it works.
            DataTable schema = connection.GetSchema("Tables");

            // Using the data loaded into the schema variable, extract a List of strings which have the names for each table.
            List<string> TableNames = new List<string>();

            // Use the foreach structure to walk through the table row by row.  NOTE: each row is of type DataRow
            foreach (DataRow row in schema.Rows)
            {
                // The actual name of the Table is in the third column (row[2]) in the row.
                TableNames.Add(row[2].ToString());
            }

            // Set the Datasource property of the comboBox control to be the list of strings (TableNames)
            cmbTables.DataSource = TableNames;

            // Close the connection to the database.
            connection.Close();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            LoadTablesNames();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
         
            // Based on the users choice from the dropdown box, open a Form to show the content from that table.
            
            // NOTE: In this example, we are only able to open backOutDates and courseInfo.  This example assumes we will have a
            //       seperate form for each table.   This is a great example of opportunity for efficiency.  There has got to be a
            //       way to have one form to show the data in any table selected.  We will see how to do that in the next program.
            switch (cmbTables.SelectedItem.ToString())
            {
                case "blackOutDates":
                    ViewBlackOutDates blackOutView = new ViewBlackOutDates();
                    blackOutView.Show();
                    break;
                case "courseInfo":
                    ViewCourseInfo courseView = new ViewCourseInfo();
                    courseView.Show();
                    break;
            }

        }
    }
}
