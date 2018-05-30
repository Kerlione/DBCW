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

        private void button4_Click(object sender, EventArgs e) //prepodavatel save
        {
            try
            {
                prepodavatelTableAdapter.Insert(
                    persKodTeacherMaskedTextBox.Text,
                    imjaTextBox.Text,
                    familijaTextBox.Text,
                    nauchnajaStepenTextBox.Text,
                    dolzhnostTextBox.Text,
                    _lecturer.CV,
                    _lecturer.Photo,
                    dataRozhdenijaDateTimePicker.Value,
                    new byte[0], 
                    otchestvoTextBox.Text,
                    jazikiTextBox.Text,
                    iD_KafTextBox.Text);
                
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
            persKodTeacherMaskedTextBox.Clear();
            imjaTextBox.Clear();
            familijaTextBox.Clear();
            nauchnajaStepenTextBox.Clear();
            dolzhnostTextBox.Clear();
            otchestvoTextBox.Clear();
            jazikiTextBox.Clear();
            dataRozhdenijaDateTimePicker.Value=DateTime.Now;
            pictureBox1.Image = BackgroundImage;
            iD_KafTextBox.Clear();
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

        private void button8_Click(object sender, EventArgs e) //predmet save
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
            clearPredmet();
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

        private void button23_Click(object sender, EventArgs e) //plan accomplishment save
        {
            try
            {
                vipolnenijePlanaTableAdapter.Insert(personKodPrepodavatelComboBox.SelectedText,
                    kodPredmetaComboBox.SelectedText,
                    numGruppaComboBox.SelectedText,
                    dataProvZanjatijaDateTimePicker.Value,
                    tipZanjatijaListBox.SelectedItem.ToString(), // TODO - fix not converting 
                    temaZanjatijaPlanTextBox.Text,
                    temaZanjatijaFactTextBox.Text,
                    (int)chasiNumericUpDown.Value);

            }
            catch (Exception)
            {

            }
            this.vipolnenijePlanaTableAdapter.Update(this.kafedraDataSet.VipolnenijePlana);
            vipolnenijePlanaBindingSource.DataSource = vipolnenijePlanaTableAdapter.GetData();
        }

        private void button24_Click(object sender, EventArgs e) //plan accomplishment delete
        {
            try
            {
                vipolnenijePlanaTableAdapter.Delete(personKodPrepodavatelComboBox.SelectedText,
                    kodPredmetaComboBox.SelectedText,
                    numGruppaComboBox.SelectedText,
                    dataProvZanjatijaDateTimePicker.Value,
                    tipZanjatijaListBox.SelectedItem.ToString(), // TODO - fix not converting 
                    temaZanjatijaPlanTextBox.Text,
                    (int)iDNumericUpDown.Value,
                    temaZanjatijaFactTextBox.Text,
                    (int)chasiNumericUpDown.Value);
            }
            catch (Exception)
            {

            }
            this.vipolnenijePlanaTableAdapter.Update(this.kafedraDataSet.VipolnenijePlana);
            vipolnenijePlanaBindingSource.DataSource = vipolnenijePlanaTableAdapter.GetData();
        }

        private void button25_Click(object sender, EventArgs e) //vipolnenije plana clear
        {
            try
            {
                temaZanjatijaPlanTextBox.Clear();
                temaZanjatijaFactTextBox.Clear();
                chasiNumericUpDown.Value = 0;
            }
            catch (Exception)
            {

            }
        }

        private void button14_Click(object sender, EventArgs e) //zashita save
        {
            try
            {
                zaschitaDiplomaTableAdapter.Insert(temaRabotiTextBox.Text,
                    rukovoditelTextBox.Text,
                    dataZaschitiDateTimePicker.Value,
                    (int)ocenkaNumericUpDown.Value,
                    typeRabotiTextBox.Text);
            }
            catch (Exception)
            {

            }
            this.zaschitaDiplomaTableAdapter.Update(this.kafedraDataSet.ZaschitaDiploma);
            zaschitaDiplomaBindingSource.DataSource = zaschitaDiplomaTableAdapter.GetData();
        }

        private void button15_Click(object sender, EventArgs e) //zaschita clear
        {
            temaRabotiTextBox.Clear();
            rukovoditelTextBox.Clear();
            ocenkaNumericUpDown.Value = 0;
            typeRabotiTextBox.Clear();
        }

        private void button16_Click(object sender, EventArgs e) //zaschita delete
        {
            try
            {
                zaschitaDiplomaTableAdapter.Delete(temaRabotiTextBox.Text,
                    rukovoditelTextBox.Text,
                    dataZaschitiDateTimePicker.Value,
                    (int) ocenkaNumericUpDown.Value,
                    typeRabotiTextBox.Text);
            }
            catch (Exception)
            {

            }
            this.zaschitaDiplomaTableAdapter.Update(this.kafedraDataSet.ZaschitaDiploma);
            zaschitaDiplomaBindingSource.DataSource = zaschitaDiplomaTableAdapter.GetData();
        }

        private void button17_Click(object sender, EventArgs e) //nagruzka save
        {
            try
            {
                nagruzkaPlanTableAdapter.Insert(gruppaComboBox.SelectedText,
                    kodPredmetaComboBox.SelectedText,
                    uchebGodTextBox.Text,
                    semestrListBox.SelectedItem.ToString(),
                    (int?) lekciiNumericUpDown.Value,
                    (int?) praktikiNumericUpDown.Value,
                    (int?) laborNumericUpDown.Value,
                    kursovajaCheckBox.Checked?1:0,
                    persKodPrepodComboBox.SelectedValue.ToString(),
                    jazikListBox.SelectedItem.ToString(),
                    (int?) koef_nagruzNumericUpDown.Value,
                    (int?) totalChasiNumericUpDown.Value,
                    (int?) kontaktChasiNumericUpDown.Value);
            }
            catch (Exception)
            {

            }
            this.nagruzkaPlanTableAdapter.Update(this.kafedraDataSet.NagruzkaPlan);
            nagruzkaPlanBindingSource.DataSource = nagruzkaPlanTableAdapter.GetData();
        }

        private void button18_Click(object sender, EventArgs e) //delete nagruzka
        {
            try
            {
                nagruzkaPlanTableAdapter.Delete(gruppaComboBox.SelectedText,
                    kodPredmetaComboBox.SelectedText,
                    uchebGodTextBox.Text,
                    semestrListBox.SelectedItem.ToString(),
                    (int?)lekciiNumericUpDown.Value,
                    (int?)praktikiNumericUpDown.Value,
                    (int?)laborNumericUpDown.Value,
                    (int?)kursovajaNumericUpDown.Value,
                    persKodPrepodComboBox.SelectedValue.ToString(),
                    jazikListBox.SelectedItem.ToString(),
                    (int?)koef_nagruzNumericUpDown.Value,
                    (int?)totalChasiNumericUpDown.Value,
                    (int?)kontaktChasiNumericUpDown.Value);
            }
            catch (Exception )
            {
                
            }
            this.nagruzkaPlanTableAdapter.Update(this.kafedraDataSet.NagruzkaPlan);
            nagruzkaPlanBindingSource.DataSource = nagruzkaPlanTableAdapter.GetData();
        }

        private void button19_Click(object sender, EventArgs e) //clear nagruzka
        {
            uchebGodTextBox.Clear();
            lekciiNumericUpDown.Value = 0;
            praktikiNumericUpDown.Value = 0;
            laborNumericUpDown.Value = 0;
            kursovajaNumericUpDown.Value = 0;
            koef_nagruzNumericUpDown.Value = 0;
            totalChasiNumericUpDown.Value = 0;
            kontaktChasiNumericUpDown.Value = 0;
        }

        private void button28_Click(object sender, EventArgs e) //objazannosti save
        {
            try
            {
                obazanostTableAdapter.Insert(objazanostTextBox.Text,
                    dataStartDateTimePicker.Value.ToString(),
                    dataEndDateTimePicker.Value.ToString(),
                    persKodPrepodComboBox1.SelectedItem.ToString());
            }
            catch (Exception )
            {
                
            }
            this.obazanostTableAdapter.Update(this.kafedraDataSet.Obazanost);
            obazanostBindingSource.DataSource = obazanostTableAdapter.GetData();
        }

        private void button27_Click(object sender, EventArgs e) //objazannost delete
        {
            try
            {
                obazanostTableAdapter.Delete((int)obazanostDataGridView.SelectedRows[0].Cells[0].Value,
                    objazanostTextBox.Text,
                    dataStartDateTimePicker.Value.ToString(),
                    dataEndDateTimePicker.Value.ToString(),
                    persKodPrepodComboBox1.SelectedItem.ToString());
            }
            catch (Exception)
            {

            }
            this.obazanostTableAdapter.Update(this.kafedraDataSet.Obazanost);
            obazanostBindingSource.DataSource = obazanostTableAdapter.GetData();
        }

        private void clearResponsibility()
        {
            objazanostTextBox.Clear();
        }

        private void button26_Click(object sender, EventArgs e)//objazannost clear
        {
            clearResponsibility();
        }

        private void button20_Click(object sender, EventArgs e)//move student add
        {
            try
            {
                moveStudentTableAdapter.Insert(numGroupComboBox.Text,
                    Convert.ToInt16(godUchebnijTextBox.Text),
                    (int) semestrListBox1.SelectedItem,
                    (int)kolichestvoStartSemNumericUpDown.Value,
                    (int)kolichestvoEndSemNumericUpDown.Value,
                    (int)otchislenoNumericUpDown.Value,
                    prichinaTextBox.Text);
            }
            catch (Exception )
            {

            }
            clearMoveStudent();
            this.moveStudentTableAdapter.Update(this.kafedraDataSet.MoveStudent);
            moveStudentBindingSource.DataSource = moveStudentTableAdapter.GetData();
        }

        private void button21_Click(object sender, EventArgs e) //delete movestudent
        {
            try
            {
                moveStudentTableAdapter.Delete(numGroupComboBox.Text,
                    Convert.ToInt16(godUchebnijTextBox.Text),
                    (int)semestrListBox1.SelectedItem,
                    (int)kolichestvoStartSemNumericUpDown.Value,
                    (int)kolichestvoEndSemNumericUpDown.Value,
                    (int)otchislenoNumericUpDown.Value);
            }
            catch (Exception)
            {

            }
            clearMoveStudent();
            this.moveStudentTableAdapter.Update(this.kafedraDataSet.MoveStudent);
            moveStudentBindingSource.DataSource = moveStudentTableAdapter.GetData();
        }

        private void button22_Click(object sender, EventArgs e) //clear move student
        {
            clearMoveStudent();
        }

        private void clearMoveStudent()
        {
            godUchebnijTextBox.Clear();
            kolichestvoStartSemNumericUpDown.Value = 0;
            kolichestvoStartSemNumericUpDown.Value = 0;
        }

        private void button9_Click(object sender, EventArgs e) //clear predmet
        {
            clearPredmet();
        }

        private void clearPredmet()
        {
            kodPredmetaTextBox.Clear();
            nazvanijePredmeta_rusTextBox.Clear();
            nazvanijePredmeta_enTextBox.Clear();
            nazvanijePredmeta_lvTextBox.Clear();
            kpNumberBox.Value = 0;
            kontaktChasiNumericUpDown.Value = 0;
            lekcii_DNumberBox.Value = 0;
            lekcii_VNumberBox.Value = 0;
            lekcii_ZNumberBox.Value = 0;
            praktiki_DNumberBox.Value = 0;
            praktiki_VNumberBox.Value = 0;
            praktiki_ZNumberBox.Value = 0;
            labor_DNumberBox.Value = 0;
            labor_VNumberBox.Value = 0;
            labor_ZNumberBox.Value = 0;
        }

        private void button6_Click(object sender, EventArgs e) //delete prepodavatel
        {
            try
            {
                prepodavatelTableAdapter.Delete(persKodTeacherMaskedTextBox.Text,
                    imjaTextBox.Text,
                    familijaTextBox.Text,
                    nauchnajaStepenTextBox.Text,
                    dolzhnostTextBox.Text,
                    dataRozhdenijaDateTimePicker.Value,
                    otchestvoTextBox.Text,
                    jazikiTextBox.Text,
                    iD_KafTextBox.Text);
            }
            catch (Exception)
            {

            }
            clearFields();
            this.prepodavatelTableAdapter.Update(this.kafedraDataSet.Prepodavatel);
            prepodavatelBindingSource.DataSource = prepodavatelTableAdapter.GetData();
        }

        private void button10_Click(object sender, EventArgs e)//predmet delete
        {
            try
            {
                predmetTableAdapter.Delete(kodPredmetaTextBox.Text,
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
                    (int) kontaktchasiNumberBox.Value,
                    nazvanijePredmeta_lvTextBox.Text,
                    nazvanijePredmeta_enTextBox.Text);
            }
            catch (Exception)
            {

            }
            clearPredmet();
            this.predmetTableAdapter.Update(this.kafedraDataSet.Predmet);
            predmetBindingSource.DataSource = predmetTableAdapter.GetData();
        }

        private void button31_Click(object sender, EventArgs e) //projekt save
        {
            try
            {
                projectTableAdapter.Insert(numProjectTextBox.Text,
                    nazvanijeTextBox.Text,
                    typeTextBox.Text,
                    dataStartDateTimePicker1.Value,
                    dataEndDateTimePicker1.Value);
            }
            catch (Exception)
            {

            }
            clearProject();
            this.projectTableAdapter.Update(this.kafedraDataSet.Project);
            projectBindingSource.DataSource = projectTableAdapter.GetData();
        }

        private void clearProject()
        {
            numProjectTextBox.Clear();
            nazvanijeTextBox.Clear();
            typeTextBox.Clear();
        }

        private void button30_Click(object sender, EventArgs e) //project remove
        {
            try
            {
                projectTableAdapter.Delete(numProjectTextBox.Text,
                    nazvanijeTextBox.Text,
                    typeTextBox.Text,
                    dataStartDateTimePicker1.Value,
                    dataEndDateTimePicker1.Value);
            }
            catch (Exception)
            {

            }
            clearProject();
            this.projectTableAdapter.Update(this.kafedraDataSet.Project);
            projectBindingSource.DataSource = projectTableAdapter.GetData();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            clearProject();
        }

        private void button34_Click(object sender, EventArgs e) //publikacija save
        {
            try
            {
                publikacijaTableAdapter.Insert(nazvanijeTextBox1.Text,
                    godTextBox.Text,
                    placeTextBox.Text,
                    reitingTextBox.Text);
            }
            catch (Exception)
            {

            }
            clearPublication();
            this.publikacijaTableAdapter.Update(this.kafedraDataSet.Publikacija);
            publikacijaBindingSource.DataSource = publikacijaTableAdapter.GetData();
        }

        private void clearPublication()
        {
            nazvanijeTextBox1.Clear();
            godTextBox.Clear();
            placeTextBox.Clear();
            reitingTextBox.Clear();
            iD_publikaciiTextBox.Clear();
        }

        private void button32_Click(object sender, EventArgs e) //clear publication
        {
            clearPublication();
        }

        private void button33_Click(object sender, EventArgs e) //delete publication
        {
            try
            {
                publikacijaTableAdapter.Delete(Convert.ToInt32(iD_publikaciiTextBox.Text),
                    godTextBox.Text,
                    reitingTextBox.Text);
            }
            catch (Exception)
            {

            }
            clearPublication();
            this.publikacijaTableAdapter.Update(this.kafedraDataSet.Publikacija);
            publikacijaBindingSource.DataSource = publikacijaTableAdapter.GetData();
        }

        private void button37_Click(object sender, EventArgs e) //save learning results
        {
            try
            {
                rezultatiObuchenijaTableAdapter.Insert(numGroupComboBox1.SelectedValue.ToString(),
                    id_PredmetComboBox.SelectedText,
                    Convert.ToInt16(uchebGodTextBox1.Text),
                    (int?) semestrListBox2.SelectedValue,
                    (int?) srednijBallNumericUpDown.Value,
                    (int?) kolichestvoNeudovNumericUpDown.Value);
            }
            catch (Exception)
            {

            }
            clearLearning();
            this.rezultatiObuchenijaTableAdapter.Update(this.kafedraDataSet.RezultatiObuchenija);
            rezultatiObuchenijaBindingSource.DataSource = rezultatiObuchenijaTableAdapter.GetData();
        }

        private void clearLearning()
        {
            uchebGodTextBox1.Clear();
            srednijBallNumericUpDown.Value = 0;
            kolichestvoNeudovNumericUpDown.Value = 0;
        }

        private void button36_Click(object sender, EventArgs e) //delete learning result
        {
            try
            {
                rezultatiObuchenijaTableAdapter.Delete(numGroupComboBox1.SelectedValue.ToString(),
                    id_PredmetComboBox.SelectedText,
                    Convert.ToInt16(uchebGodTextBox1.Text),
                    (int?)semestrListBox2.SelectedValue,
                    (int?)srednijBallNumericUpDown.Value,
                    (int?)kolichestvoNeudovNumericUpDown.Value);
            }
            catch (Exception)
            {

            }
            clearLearning();
            this.rezultatiObuchenijaTableAdapter.Update(this.kafedraDataSet.RezultatiObuchenija);
            rezultatiObuchenijaBindingSource.DataSource = rezultatiObuchenijaTableAdapter.GetData();
        }

        private void button35_Click(object sender, EventArgs e) 
        {
            clearLearning();
        }

        private void button40_Click(object sender, EventArgs e) //lecture reading save
        {
            try
            {
                lectureReadingTableAdapter.Insert(Convert.ToInt16(iD_languageComboBox.SelectedValue),
                    iD_subjectComboBox.SelectedValue.ToString(),
                    pK_lecturerComboBox.SelectedValue.ToString(),
                    Convert.ToInt16(readYearTextBox.Text),
                    Convert.ToInt16(readSemesterTextBox.Text));
            }
            catch (Exception)
            {

            }

            clearReading();
            this.lectureReadingTableAdapter.Update(this.kafedraDataSet.LectureReading);
            lectureReadingBindingSource.DataSource = lectureReadingTableAdapter.GetData();
        }

        private void clearReading()
        {
            readYearTextBox.Clear();
            readSemesterTextBox.Clear();
        }

        private void button39_Click(object sender, EventArgs e)//lecture reading remove
        {
            try
            {
                lectureReadingTableAdapter.Delete(Convert.ToInt16(iD_languageComboBox.SelectedValue),
                    iD_subjectComboBox.SelectedValue.ToString(),
                    pK_lecturerComboBox.SelectedValue.ToString(),
                    Convert.ToInt16(readYearTextBox.Text),
                    Convert.ToInt16(readSemesterTextBox.Text));
            }
            catch (Exception)
            {

            }

            clearReading();
            this.lectureReadingTableAdapter.Update(this.kafedraDataSet.LectureReading);
            lectureReadingBindingSource.DataSource = lectureReadingTableAdapter.GetData();
        }

        private void button38_Click(object sender, EventArgs e)
        {
            clearReading();
        }

        private void button43_Click(object sender, EventArgs e) // language save
        {
            try
            {
                languageTableAdapter.Insert(languageTextBox.Text);
            }
            catch (Exception)
            {

            }
            clearLanguage();
            this.languageTableAdapter.Update(this.kafedraDataSet.Language);
            languageBindingSource.DataSource = languageTableAdapter.GetData();
        }

        private void clearLanguage()
        {
            languageTextBox.Clear();
            iD_langTextBox.Clear();
        }

        private void button41_Click(object sender, EventArgs e) // language delete
        {
            try
            {
                languageTableAdapter.Delete(Convert.ToInt16(iD_langTextBox.Text),
                    languageTextBox.Text);
            }
            catch (Exception)
            {

            }
            clearLanguage();
            this.languageTableAdapter.Update(this.kafedraDataSet.Language);
            languageBindingSource.DataSource = languageTableAdapter.GetData();
        }

        private void button42_Click(object sender, EventArgs e)
        {
            clearLanguage();
        }
    }
}
