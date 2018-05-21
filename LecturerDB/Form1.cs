using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
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
            // TODO: This line of code loads data into the 'kafedraDataSet.Language' table. You can move, or remove it, as needed.
            this.languageTableAdapter.Fill(this.kafedraDataSet.Language);
            // TODO: This line of code loads data into the 'kafedraDataSet.RezultatiObuchenija' table. You can move, or remove it, as needed.
            this.rezultatiObuchenijaTableAdapter.Fill(this.kafedraDataSet.RezultatiObuchenija);
            // TODO: This line of code loads data into the 'kafedraDataSet._Publikacija_Teacher' table. You can move, or remove it, as needed.
            this.publikacija_TeacherTableAdapter.Fill(this.kafedraDataSet._Publikacija_Teacher);
            // TODO: This line of code loads data into the 'kafedraDataSet.Publikacija' table. You can move, or remove it, as needed.
            this.publikacijaTableAdapter.Fill(this.kafedraDataSet.Publikacija);
            // TODO: This line of code loads data into the 'kafedraDataSet.TeacherProject' table. You can move, or remove it, as needed.
            this.teacherProjectTableAdapter.Fill(this.kafedraDataSet.TeacherProject);
            // TODO: This line of code loads data into the 'kafedraDataSet.Project' table. You can move, or remove it, as needed.
            this.projectTableAdapter.Fill(this.kafedraDataSet.Project);
            // TODO: This line of code loads data into the 'kafedraDataSet.MoveStudent' table. You can move, or remove it, as needed.
            this.moveStudentTableAdapter.Fill(this.kafedraDataSet.MoveStudent);
            // TODO: This line of code loads data into the 'kafedraDataSet.Obazanost' table. You can move, or remove it, as needed.
            this.obazanostTableAdapter.Fill(this.kafedraDataSet.Obazanost);
            // TODO: This line of code loads data into the 'kafedraDataSet.NagruzkaPlan' table. You can move, or remove it, as needed.
            this.nagruzkaPlanTableAdapter.Fill(this.kafedraDataSet.NagruzkaPlan);
            // TODO: This line of code loads data into the 'kafedraDataSet.ZaschitaDiploma' table. You can move, or remove it, as needed.
            this.zaschitaDiplomaTableAdapter.Fill(this.kafedraDataSet.ZaschitaDiploma);
            // TODO: This line of code loads data into the 'kafedraDataSet.VipolnenijePlana' table. You can move, or remove it, as needed.
            this.vipolnenijePlanaTableAdapter.Fill(this.kafedraDataSet.VipolnenijePlana);
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

        private void refreshGruppaGrid()
        {
            gruppaTableAdapter.Update(kafedraDataSet.Gruppa);
            gruppaBindingSource.DataSource = gruppaTableAdapter.GetData();
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
            try
            {
                predmetTableAdapter.Insert(
                    kodPredmetaTextBox.Text,
                    nazvanijePredmeta_rusTextBox.Text,
                    (int) kpNumberBox.Value,
                    (int) lekcii_VNumberBox.Value,
                    (int) lekcii_ZNumberBox.Value,
                    (int) praktiki_VNumberBox.Value,
                    (int) praktiki_ZNumberBox.Value,
                    (int) labor_ZNumberBox.Value,
                    (int) labor_VNumberBox.Value,
                    (int) lekcii_DNumberBox.Value,
                    (int) praktiki_DNumberBox.Value,
                    (int) labor_DNumberBox.Value,
                    kontrolRabotaCheckBox.Enabled,
                    kursovajaCheckBox.Enabled,
                    TematicPlan,
                    SubjectDescription,
                    (int) kontaktchasiNumberBox.Value,
                    nazvanijePredmeta_lvTextBox.Text,
                    nazvanijePredmeta_enTextBox.Text
                );
            }
            catch (SqlException)
            {
                
            }
            
            this.predmetTableAdapter.Update(this.kafedraDataSet.Predmet);
            predmetBindingSource.DataSource = predmetTableAdapter.GetData();
        }

        private void button11_Click(object sender, EventArgs e) //save group
        {
            try
            {
                
                    gruppaTableAdapter.Insert(nomerGruppiTextBox.Text,
                        kolichestvoStudentovNumericUpDown.Value.ToString(),
                        starostaTextBox.Text,
                        kontaktInfoTextBox.Text,
                        fakultetTextBox.Text,
                        formaObuchenijaTextBox.Text,
                        programmaTextBox.Text,
                        (int)godNaboraNumericUpDown.Value);
                
            }
            catch (Exception)
            {
                string pk = "NomerGruppi=" + nomerGruppiTextBox.Text;
                DataRow dr = kafedraDataSet.Gruppa.Select(pk).FirstOrDefault(); //fix exception with missing operand DB(from group num)
                if (dr != null)
                {
                    dr["KolichestvoStudentov"] = kolichestvoEndSemNumericUpDown.Value.ToString();
                    dr["Starosta"] = starostaTextBox.Text;
                    dr["KontaktInfo"] = kontaktInfoTextBox.Text;
                    dr["Fakultet"] = fakultetTextBox.Text;
                    dr["FormaObuchenija"] = formaObuchenijaTextBox.Text;
                    dr["Programma"] = programmaTextBox.Text;
                    dr["GodNabora"] = (int)godNaboraNumericUpDown.Value;
                }

            }

            refreshGruppaGrid();
        }

        private void button13_Click(object sender, EventArgs e) //gruppa delete
        {
            try
            {
                gruppaTableAdapter.Delete(nomerGruppiTextBox.Text,
                    kolichestvoStudentovNumericUpDown.Value.ToString(),
                    starostaTextBox.Text,
                    kontaktInfoTextBox.Text,
                    fakultetTextBox.Text,
                    formaObuchenijaTextBox.Text,
                    programmaTextBox.Text,
                    (int) godNaboraNumericUpDown.Value);
            }
            catch (Exception)
            {

            }
            refreshGruppaGrid();
        }

        private void button12_Click(object sender, EventArgs e) //gruppa clear
        {
            nomerGruppiTextBox.Clear();
            kolichestvoStudentovNumericUpDown.Value = 0;
            starostaTextBox.Clear();
            kontaktInfoTextBox.Clear();
            fakultetTextBox.Clear();
            formaObuchenijaTextBox.Clear();
            programmaTextBox.Clear();
            godNaboraNumericUpDown.Value = 1970;
        }

        private void lekciiNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            //totalChasiNumericUpDown.Value = 0;
            totalChasiNumericUpDown.Value = lekciiNumericUpDown.Value + praktikiNumericUpDown.Value + laborNumericUpDown.Value;
        }

        private void praktikiNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            //totalChasiNumericUpDown.Value = 0;
            totalChasiNumericUpDown.Value = lekciiNumericUpDown.Value + praktikiNumericUpDown.Value + laborNumericUpDown.Value;
        }

        private void laborNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            //totalChasiNumericUpDown.Value = 0;
            totalChasiNumericUpDown.Value = lekciiNumericUpDown.Value + praktikiNumericUpDown.Value + laborNumericUpDown.Value;
        }

        private void jazikListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if ((string)jazikListBox.SelectedItem == "Eng")
            {
                koef_nagruzNumericUpDown.Value = Convert.ToDecimal(1.5);
            }
            else
            {
                koef_nagruzNumericUpDown.Value = 1;
            }
        }

        private void kolichestvoStartSemNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            otchislenoNumericUpDown.Value =
                kolichestvoStartSemNumericUpDown.Value - kolichestvoEndSemNumericUpDown.Value;
        }

        private void kolichestvoEndSemNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            otchislenoNumericUpDown.Value =
                kolichestvoStartSemNumericUpDown.Value - otchislenoNumericUpDown.Value;
        }

        private void button23_Click(object sender, EventArgs e)
        {
            try
            {
                vipolnenijePlanaTableAdapter.Insert(personKodPrepodavatelComboBox.SelectedText,
                    kodPredmetaComboBox.SelectedText,
                    numGruppaComboBox.SelectedText,
                    dataProvZanjatijaDateTimePicker.Value,
                    tipZanjatijaListBox.DisplayMember, // TODO - fix not converting 
                    temaZanjatijaPlanTextBox.Text,
                    temaZanjatijaFactTextBox.Text,
                    (int)chasiNumericUpDown.Value);

            }
            catch (Exception)
            {

            }
        }
    }
}
