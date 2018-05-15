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
using System.Xml.XPath;

namespace LecturerDB {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private Lecturer _lecturer = new Lecturer();

        private void Form1_Load(object sender, EventArgs e) {
            // TODO: This line of code loads data into the 'kafedraDataSet.LectureReading' table. You can move, or remove it, as needed.
            this.lectureReadingTableAdapter.Fill(this.kafedraDataSet.LectureReading);
            // TODO: This line of code loads data into the 'kafedraDataSet.Predmet' table. You can move, or remove it, as needed.
            this.predmetTableAdapter.Fill(this.kafedraDataSet.Predmet);
            // TODO: This line of code loads data into the 'kafedraDataSet.Prepodavatel' table. You can move, or remove it, as needed.
            this.prepodavatelTableAdapter.Fill(this.kafedraDataSet.Prepodavatel);
            // TODO: This line of code loads data into the 'kafedraDataSet.Gruppa' table. You can move, or remove it, as needed.
            this.gruppaTableAdapter.Fill(this.kafedraDataSet.Gruppa);

        }

        private void button1_Click(object sender, EventArgs e) {

        }

        private void button3_Click(object sender, EventArgs e) { // Photo button
            DialogResult result = openFileDialog1.ShowDialog();
            if (result != DialogResult.OK) return;
            string file = openFileDialog1.FileName;
            try {
                _lecturer.Photo = File.ReadAllBytes(file);
                pictureBox1.Image = new Bitmap(new Bitmap(file), new Size(pictureBox1.Width,pictureBox1.Height));
            }catch(IOException) {
                    
            }

        }

        private void button2_Click(object sender, EventArgs e) { //CV button
            DialogResult result = openFileDialog2.ShowDialog();
            if (result == DialogResult.OK)
            {
                string file = openFileDialog2.FileName;
                try
                {
                    _lecturer.CV = File.ReadAllBytes(file);
                } catch (IOException) { }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e) { //LastName
            _lecturer.LastName = textBox2.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e) { //FirstName
            _lecturer.FirstName = textBox1.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e) { //SecondName
            _lecturer.SecondName = textBox3.Text;
        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e) {//PK
            _lecturer.PK = maskedTextBox1.Text;
        }

        private void cathedraTextBox_TextChanged(object sender, EventArgs e)
        {
            _lecturer.Cathedra = cathedraTextBox.Text;
        }

        private void occupationTextBox_TextChanged(object sender, EventArgs e)
        {
            _lecturer.Occupation = occupationTextBox.Text;
        }

        private void birthdayDatePicker_ValueChanged(object sender, EventArgs e)
        {
            _lecturer.Birthday = birthdayDatePicker.Value;
        }

        private void degreeTextBox5_TextChanged(object sender, EventArgs e)
        {
            _lecturer.Degree = degreeTextBox5.Text;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //_lecturer.Publications = new List<Publication>(listBox1.SelectedItems);
            //foreach (var item in listBox1.SelectedItems)
            //{
            //    _lecturer.Publications.Add(listBox1.Items[item]);
            //}
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            _lecturer.Languages = textBox4.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                prepodavatelTableAdapter.Insert(
                    _lecturer.PK,
                    _lecturer.FirstName,
                    _lecturer.LastName,
                    _lecturer.Degree,
                    _lecturer.Occupation,
                    _lecturer.CV,
                    _lecturer.Photo,
                    _lecturer.Birthday,
                    new byte[0],
                    _lecturer.SecondName,
                    _lecturer.Languages,
                    _lecturer.Cathedra);
                
                clearFields();
                prepodavatelBindingSource.DataSource = new List<Lecturer>();
                prepodavatelBindingSource.DataSource = prepodavatelTableAdapter.GetData();
            }
            catch (Exception)
            {
                errorProvider1.SetError(button4,"Персональный код должен быть уникальным!");
            }
        }

        private void clearFields()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            maskedTextBox1.Clear();
            occupationTextBox.Clear();
            cathedraTextBox.Clear();
            degreeTextBox5.Clear();
            birthdayDatePicker.Value=DateTime.Now;
            pictureBox1.Image = BackgroundImage;
            _lecturer = new Lecturer();
        }

        private void button5_Click(object sender, EventArgs e) {
            clearFields();
        }

        private byte[] TematicPlan;

        private void button1_Click_1(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog3.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    string file = openFileDialog3.FileName;
                    TematicPlan = File.ReadAllBytes(file);
                } catch (IOException) { }
            }
        }

        private byte[] SubjectDescription;
        private void button7_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog4.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    string file = openFileDialog4.FileName;
                    SubjectDescription = File.ReadAllBytes(file);
                }
                catch (IOException)
                {
                   
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
            predmetTableAdapter.Insert(
                kodPredmetaTextBox.Text,
                nazvanijePredmeta_rusTextBox.Text,
                (int)kpNumberBox.Value,
                (int)lekcii_VNumberBox.Value,
                (int)lekcii_ZNumberBox.Value,
                (int)praktiki_VNumberBox.Value,
                (int)praktiki_ZNumberBox.Value,
                (int)labor_ZNumberBox.Value,
                (int)labor_VNumberBox.Value,
                (int)lekcii_DNumberBox.Value,
                (int)praktiki_DNumberBox.Value,
                (int)labor_DNumberBox.Value,
                kontrolRabotaCheckBox.Enabled,
                kursovajaCheckBox.Enabled,
                TematicPlan,
                SubjectDescription,
                (int)kontaktchasiNumberBox.Value,
                nazvanijePredmeta_lvTextBox.Text,
                nazvanijePredmeta_enTextBox.Text
                );
            //this.predmetTableAdapter.Update();
        }
    }
}
