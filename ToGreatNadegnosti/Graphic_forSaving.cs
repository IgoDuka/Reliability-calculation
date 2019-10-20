using System;
using System.Windows.Forms;

namespace ToGreatNadegnosti
{
    public partial class Graphic_forSaving : Form
    {
        DataGridView DG1, DG2, DG3, DG4, DG5;
        public Graphic_forSaving(DataGridView DG1, DataGridView DG2, DataGridView DG3, DataGridView DG4, DataGridView DG5){
            InitializeComponent();
            this.DG1 = DG1;
            this.DG2 = DG2;
            this.DG3 = DG3;
            this.DG4 = DG4;
            this.DG5 = DG5;
        }

        private void Graphic_forSaving_Load(object sender, EventArgs e){
            Text += " (Разработал Дука Игорь Александрович, 545и группа)";
            double[] mass = Saving();
            double[] mass1 = ErrorSaving(mass);

            chart1.Series.Add("ПК");
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            chart1.Series[0].BorderWidth = 5;
            chart1.Legends[0].Title = "ВБОX";
            chart1.ChartAreas[0].AxisX.Title = chart2.ChartAreas[0].AxisX.Title = "t";
            chart1.ChartAreas[0].AxisY.Title = "Pкox(t)";
            chart2.ChartAreas[0].AxisY.Title = "Qкox(t)";

            chart2.Series.Add("ПК");
            chart2.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            chart2.Series[0].BorderWidth = 5;
            chart2.Legends[0].Title = "ВОX";
            richTextBox1.Text = richTextBox2.Text = "\t\tПК\n";
            double t = 0;
            for (int i = 0; i < mass.Length; i++, t += (Convert.ToDouble(DG5.Rows[0].Cells[1].Value) * 1000)) { 
                chart1.Series[0].Points.AddXY(t, mass[i]);
                richTextBox1.Text += "P(t) = " + mass[i] + "   t = " + t + "\n";
            }

            t = 0;
            for (int i = 0; i < mass.Length; i++, t += (Convert.ToDouble(DG5.Rows[0].Cells[1].Value) * 1000)) { 
                chart2.Series[0].Points.AddXY(t, mass1[i]);
                richTextBox2.Text += "Q(t) = " + mass1[i] + "   t = " + t + "\n";
            }
        }
        private double[] ErrorSaving(double[] saving){
            int len = Convert.ToInt32((Convert.ToDouble(DG4.Rows[0].Cells[0].Value) * 10000) / (Convert.ToDouble(DG5.Rows[0].Cells[1].Value) * 1000)) + 1;
            double[] mass = new double[len];
            Calculations calc = Logic.FailureRate(DG3, Convert.ToInt32(DG5.Rows[0].Cells[3].Value),
                Convert.ToDouble(DG5.Rows[0].Cells[2].Value));

            double t = 0;
            for (int i = 0; i < mass.Length; i++, t += (Convert.ToDouble(DG5.Rows[0].Cells[1].Value) * 1000))
                mass[i] = Logic.DivideOne(saving[i]);

            return mass;
        }
        private double[] Saving(){
            int len = Convert.ToInt32((Convert.ToDouble(DG4.Rows[0].Cells[0].Value) * 10000) / (Convert.ToDouble(DG5.Rows[0].Cells[1].Value) * 1000)) + 1;
            double[] mass = new double[len];
            Calculations calc = Logic.FailureRate(DG3, Convert.ToInt32(DG5.Rows[0].Cells[3].Value), 
                Convert.ToDouble(DG5.Rows[0].Cells[2].Value));

            double t = 0;
            for (int i = 0; i < mass.Length; i++, t += (Convert.ToDouble(DG5.Rows[0].Cells[1].Value) * 1000))
                mass[i] = Logic.Saving(calc.AO, t, Convert.ToDouble(DG4.Rows[0].Cells[1].Value) * 100);

            return mass;
        }
    }
}
