using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LecturerDB.Entities;
using System.IO;
namespace LecturerDB {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        Lecturer lecturer = new Lecturer();

        private void Form1_Load(object sender, EventArgs e) {
            // TODO: This line of code loads data into the 'kafedraDataSet.Gruppa' table. You can move, or remove it, as needed.
            this.gruppaTableAdapter.Fill(this.kafedraDataSet.Gruppa);

        }

        private void button1_Click(object sender, EventArgs e) {

        }

        private void button3_Click(object sender, EventArgs e) { // CV button
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                try {
                    lecturer.CV = File.ReadAllBytes(file);
                }catch(IOException) {
                    
                }
                
            }

        }
    }
}
