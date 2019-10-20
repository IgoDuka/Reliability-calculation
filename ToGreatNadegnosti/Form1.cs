using System;
using System.Windows.Forms;

namespace ToGreatNadegnosti
{
    public partial class Form1 : Form
    {
        public Form1(){
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e) {
            DG1.RowCount = DG2.RowCount = DG3.RowCount = DG4.RowCount = DG5.RowCount = 1;

            DG1.Rows[0].Cells[0].Value = "2,5";
            DG1.Rows[0].Cells[1].Value = "1,5";
            DG1.Rows[0].Cells[2].Value = "1,2";

            DG2.Rows[0].Cells[0].Value = "0,6";
            DG2.Rows[0].Cells[1].Value = "0,6";

            DG3.Rows[0].Cells[0].Value = "2,9";
            DG3.Rows[0].Cells[1].Value = "1,4";
            DG3.Rows[0].Cells[2].Value = "2,4";
            DG3.Rows[0].Cells[3].Value = "1,9";

            DG4.Rows[0].Cells[0].Value = "0,6";
            DG4.Rows[0].Cells[1].Value = "1";

            DG5.Rows[0].Cells[0].Value = "65";
            DG5.Rows[0].Cells[1].Value = "0,5";
            DG5.Rows[0].Cells[2].Value = "2,3";
            DG5.Rows[0].Cells[3].Value = "7";
            DG5.Rows[0].Cells[4].Value = "0,6";
        }
        
        private void Computing_Click(object sender, EventArgs e){
            string choise = "";
            if (radioButton1.Checked)
                choise = "ВБСР и ВС (АС, ПС и ПК)";
            else if (radioButton2.Checked)
                choise = "ВБОР и ВО (АC, ПС и ПК)";
            else if (radioButton3.Checked){
                Graphic_forSaving graphic = new Graphic_forSaving(DG1, DG2, DG3, DG4, DG5);
                graphic.ShowDialog();
                return;
            }
            else if (radioButton4.Checked)
                choise = "ВБШР и ВШ (АС, ПС и ПК)";
            else if (radioButton5.Checked)
                choise = "для циклического функционирования: ВБОР и ВО (АС, ПС и ПК)";
            else if (radioButton6.Checked)
                choise = "для реальных (экстремальных) условий эксплуатаций: ВБОР и ВО (АС, ПС и ПК)";
            Grafics graph = new Grafics(choise, DG1, DG2, DG3, DG4, DG5);
            graph.Show();
        }
    }
}
