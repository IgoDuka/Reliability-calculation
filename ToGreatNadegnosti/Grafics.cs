using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ToGreatNadegnosti
{
    public partial class Grafics : Form
    {
        public string Grafic;
        public double DoubleClickValue = 1;
        DataGridView DG1, DG2, DG3, DG4, DG5;
        public Grafics(string Grafic, DataGridView DG1, DataGridView DG2, DataGridView DG3, DataGridView DG4, DataGridView DG5){
            InitializeComponent();
            this.Grafic = Grafic;
            this.DG1 = DG1;
            this.DG2 = DG2;
            this.DG3 = DG3;
            this.DG4 = DG4;
            this.DG5 = DG5;
        }

        private void Grafics_Load(object sender, EventArgs e){
            Text = Grafic + " (Разработал Дука Игорь Александрович, 545и группа)";
            List<double[]> list = new List<double[]>();

            chart1.Series.Add("AC"); chart2.Series.Add("AС"); 
            chart1.Series.Add("ПС"); chart2.Series.Add("ПС"); chart1.Series[1].BorderDashStyle = chart2.Series[1].BorderDashStyle = ChartDashStyle.Dash;
            chart1.Series.Add("ПК"); chart2.Series.Add("ПК"); chart1.Series[2].BorderDashStyle = chart2.Series[2].BorderDashStyle = ChartDashStyle.Dot;

            chart2.Series[0].ChartType = chart2.Series[1].ChartType = chart2.Series[2].ChartType = chart1.Series[0].ChartType = 
            chart1.Series[1].ChartType = chart1.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;

            chart1.Series[0].BorderWidth = chart1.Series[1].BorderWidth = chart1.Series[2].BorderWidth = chart2.Series[0].BorderWidth =
                chart2.Series[1].BorderWidth = chart2.Series[2].BorderWidth = 5;

            chart1.ChartAreas[0].AxisX.Title = chart2.ChartAreas[0].AxisX.Title = "t";
            chart1.ChartAreas[0].AxisY.Title = "P(t)";
            chart2.ChartAreas[0].AxisY.Title = "Q(t)";

            int line = 0;
            switch (Grafic){
                case "ВБСР и ВС (АС, ПС и ПК)":
                    {
                        chart1.Legends[0].Title = "ВБCР"; chart2.Legends[0].Title = "ВC";
                        list = VBCR();
                        line = 0;
                        foreach (var mass in list){
                            richTextBox1.Text += "\n\t\t" + chart1.Series[line].Name.ToString() + "\n";
                            double t = 0;
                            for (int i = 0; i < mass.Length; i++, t += (Convert.ToDouble(DG5.Rows[0].Cells[1].Value) * 1000)* DoubleClickValue) { 
                                chart1.Series[line].Points.AddXY(t, mass[i]);
                                richTextBox1.Text += "P(t) = " + mass[i] + "   t = " + t + "\n";
                            }
                            line++;
                        }

                        list = VO_VC(list);
                        line = 0;
                        foreach (var mass in list){
                            richTextBox2.Text += "\n\t\t" + chart2.Series[line].Name.ToString() + "\n";
                            double t = 0;
                            for (int i = 0; i < mass.Length; i++, t += (Convert.ToDouble(DG5.Rows[0].Cells[1].Value) * 1000)* DoubleClickValue) { 
                                chart2.Series[line].Points.AddXY(t, mass[i]);
                                richTextBox2.Text += "Q(t) = " + mass[i] + "   t = " + t + "\n";
                            }
                            line++;
                        }
                    }
                    break;
                case "ВБОР и ВО (АC, ПС и ПК)":
                    {
                        chart1.Legends[0].Title = "ВБОР"; chart2.Legends[0].Title = "ВО";
                        list = VBOR();
                        line = 0;
                        foreach (var mass in list){
                            richTextBox1.Text += "\n\t\t" + chart1.Series[line].Name.ToString() + "\n";
                            double t = 0;
                            for (int i = 0; i < mass.Length; i++, t += (Convert.ToDouble(DG5.Rows[0].Cells[1].Value) * 1000)* DoubleClickValue) { 
                                chart1.Series[line].Points.AddXY(t, mass[i]);
                                richTextBox1.Text += "P(t) = " + mass[i] + "   t = " + t + "\n";
                            }
                            line++;
                        }

                        list = VO_VC(list);
                        line = 0;
                        foreach (var mass in list){
                            richTextBox2.Text += "\n\t\t" + chart2.Series[line].Name.ToString() + "\n";
                            double t = 0;
                            for (int i = 0; i < mass.Length; i++, t += (Convert.ToDouble(DG5.Rows[0].Cells[1].Value) * 1000)* DoubleClickValue) { 
                                chart2.Series[line].Points.AddXY(t, mass[i]);
                                richTextBox2.Text += "Q(t) = " + mass[i] + "   t = " + t + "\n";
                            }
                            line++;
                        }
                    }
                    break;
                case "ВБШР и ВШ (АС, ПС и ПК)":
                    {
                        chart1.Legends[0].Title = "ВБШР"; chart2.Legends[0].Title = "ВШ";
                        list = VBShR();
                        line = 0;
                        foreach (var mass in list)
                        {
                            richTextBox1.Text += "\n\t\t" + chart1.Series[line].Name.ToString() + "\n";
                            double t = 0;
                            for (int i = 0; i < mass.Length; i++, t += (Convert.ToDouble(DG5.Rows[0].Cells[1].Value) * 1000) * DoubleClickValue)
                            {
                                chart1.Series[line].Points.AddXY(t, mass[i]);
                                richTextBox1.Text += "P(t) = " + mass[i] + "   t = " + t + "\n";
                            }
                            line++;
                        }

                        list = VO_VC(list);
                        line = 0;
                        foreach (var mass in list)
                        {
                            richTextBox2.Text += "\n\t\t" + chart2.Series[line].Name.ToString() + "\n";
                            double t = 0;
                            for (int i = 0; i < mass.Length; i++, t += (Convert.ToDouble(DG5.Rows[0].Cells[1].Value) * 1000) * DoubleClickValue)
                            {
                                chart2.Series[line].Points.AddXY(t, mass[i]);
                                richTextBox2.Text += "Q(t) = " + mass[i] + "   t = " + t + "\n";
                            }
                            line++;
                        }
                    }
                    break;
                case "для реальных (экстремальных) условий эксплуатаций: ВБОР и ВО (АС, ПС и ПК)":
                    {
                        chart1.Legends[0].Title = "для реальных\n (экстремальных) условий\n эксплуатаций ВБOР"; chart2.Legends[0].Title = "для реальных\n (экстремальных) условий\n эксплуатаций ВO";
                        list = VBORforRealOperatingConditions();
                        line = 0;
                        foreach (var mass in list){
                            richTextBox1.Text += "\n\t\t" + chart1.Series[line].Name.ToString() + "\n";
                            double t = 0;
                            for (int i = 0; i < mass.Length; i++, t += (Convert.ToDouble(DG5.Rows[0].Cells[1].Value) * 1000) * DoubleClickValue) { 
                                chart1.Series[line].Points.AddXY(t, mass[i]);
                                richTextBox1.Text += "P(t) = " + mass[i] + "   t = " + t + "\n";
                            }
                            line++;
                        }

                        list = VO_VC(list);
                        line = 0;
                        foreach (var mass in list){
                            richTextBox2.Text += "\n\t\t" + chart2.Series[line].Name.ToString() + "\n";
                            double t = 0;
                            for (int i = 0; i < mass.Length; i++, t += (Convert.ToDouble(DG5.Rows[0].Cells[1].Value) * 1000)* DoubleClickValue) { 
                                chart2.Series[line].Points.AddXY(t, mass[i]);
                                richTextBox2.Text += "Q(t) = " + mass[i] + "   t = " + t + "\n";
                            }
                            line++;
                        }
                    }
                    break;
                case "для циклического функционирования: ВБОР и ВО (АС, ПС и ПК)":
                    {
                        chart1.Legends[0].Title = "для циклического\n функционирования\n ВБOР"; chart2.Legends[0].Title = "для циклического\n функционирования\n ВO";
                        list = VBORforCyclicFunctioning();
                        line = 0;
                        foreach (var mass in list){
                            richTextBox1.Text += "\n\t\t" + chart1.Series[line].Name.ToString() + "\n";
                            double t = 0;
                            for (int i = 0; i < mass.Length; i++, t += (Convert.ToDouble(DG5.Rows[0].Cells[1].Value) * 1000) * DoubleClickValue) { 
                                chart1.Series[line].Points.AddXY(t, mass[i]);
                                richTextBox1.Text += "P(t) = " + mass[i] + "   t = " + t + "\n";
                            }
                            line++;
                        }

                        list = VO_VC(list);
                        line = 0;
                        foreach (var mass in list){
                            richTextBox2.Text += "\n\t\t" + chart2.Series[line].Name.ToString() + "\n";
                            double t = 0;
                            for (int i = 0; i < mass.Length; i++, t += (Convert.ToDouble(DG5.Rows[0].Cells[1].Value) * 1000) * DoubleClickValue) { 
                                chart2.Series[line].Points.AddXY(t, mass[i]);
                                richTextBox2.Text += "Q(t) = " + mass[i] + "   t = " + t + "\n";
                            }
                            line++;
                        }
                    }
                    break;
            }
        }

        private List<double[]> VBORforCyclicFunctioning(){
            int len = Convert.ToInt32((Convert.ToDouble(DG2.Rows[0].Cells[0].Value) * 10000) / (Convert.ToDouble(DG5.Rows[0].Cells[1].Value) * 1000)) + 1;
            double[] mass1 = new double[len];
            double[] mass2 = new double[len];
            double[] mass3 = new double[len];
            List<double[]> list = new List<double[]>();
            Calculations calc = Logic.FailureRate(DG3, Convert.ToInt32(DG5.Rows[0].Cells[3].Value), Convert.ToDouble(DG5.Rows[0].Cells[2].Value));
            double t = 0;
            for (int i = 0; i < mass1.Length; i++, t += (Convert.ToDouble(DG2.Rows[0].Cells[1].Value) * 1000) * DoubleClickValue)
            {
                mass1[i] = Logic.VBORforCyclicFunctioning(Convert.ToDouble(DG4.Rows[0].Cells[1].Value) * 100, Convert.ToDouble(DG2.Rows[0].Cells[1].Value), calc.AO, t);
                mass2[i] = Logic.VBORforCyclicFunctioning(Convert.ToDouble(DG4.Rows[0].Cells[1].Value) * 100, Convert.ToDouble(DG2.Rows[0].Cells[1].Value), calc.PO, t);
                mass3[i] = Logic.VBORforCyclicFunctioning(Convert.ToDouble(DG4.Rows[0].Cells[1].Value) * 100, Convert.ToDouble(DG2.Rows[0].Cells[1].Value), calc.KO, t);
            }
            list.Add(mass1);
            list.Add(mass2);
            list.Add(mass3);
            return list;
        }
        private List<double[]> VBOR(){
            int len = Convert.ToInt32((Convert.ToDouble(DG5.Rows[0].Cells[4].Value) * 10000) / (Convert.ToDouble(DG5.Rows[0].Cells[1].Value) * 1000)) + 1;
            double[] mass1 = new double[len];
            double[] mass2 = new double[len];
            double[] mass3 = new double[len];
            List<double[]> list =new List<double[]>();
            Calculations calc = Logic.FailureRate(DG3, Convert.ToInt32(DG5.Rows[0].Cells[3].Value), Convert.ToDouble(DG5.Rows[0].Cells[2].Value));
            double t = 0;
            for (int i = 0; i < mass1.Length; i++, t += (Convert.ToDouble(DG5.Rows[0].Cells[1].Value) * 1000) * DoubleClickValue)
            { 
                mass1[i] = Logic.VB_R(calc.AO, t);//выр без отк раб для АС
                mass2[i] = Logic.VB_R(calc.PO, t);//выр без отк раб для ПС
                mass3[i] = Logic.VB_R(calc.KO, t);//выр без отк раб для ПК
            }
            list.Add(mass1);
            list.Add(mass2);
            list.Add(mass3);
            return list;
        }

        private void chart1_DoubleClick(object sender, EventArgs e){
            if (DoubleClickValue == 0)
                DoubleClickValue = 1;
            DoubleClickValue *= 10;

            richTextBox1.Clear();
            richTextBox2.Clear();
            chart1.Series.Clear();
            chart2.Series.Clear();

            Grafics_Load(sender, e);
        }

        private List<double[]> VO_VC(List<double[]> List){
            double[] mass1 = List[0];
            double[] mass2 = List[1];
            double[] mass3 = List[2];
            List<double[]> list = new List<double[]>();

            for (int i = 0; i < mass1.Length; i++){
                mass1[i] = 1 - mass1[i];//выр отк раб для АС
                mass2[i] = 1 - mass2[i];//выр отк раб для ПС
                mass3[i] = 1 - mass3[i];//выр отк раб для ПК
            }

            list.Add(mass1);
            list.Add(mass2);
            list.Add(mass3);
            return list;
        }
        private List<double[]> VBCR(){
            int len = Convert.ToInt32((Convert.ToDouble(DG5.Rows[0].Cells[4].Value) * 10000) / (Convert.ToDouble(DG5.Rows[0].Cells[1].Value) * 1000)) + 1;
            double[] mass1 = new double[len];
            double[] mass2 = new double[len];
            double[] mass3 = new double[len];
            List<double[]> list = new List<double[]>();
            Calculations calc = Logic.FailureRate(DG3, Convert.ToInt32(DG5.Rows[0].Cells[3].Value), Convert.ToDouble(DG5.Rows[0].Cells[2].Value));
            double t = 0;
            for (int i = 0; i < mass1.Length; i++, t += (Convert.ToDouble(DG5.Rows[0].Cells[1].Value) * 1000) * DoubleClickValue)
            {
                mass1[i] = Logic.VB_R(calc.AC, t);//выр без отк раб для АС
                mass2[i] = Logic.VB_R(calc.PC, t);//выр без отк раб для ПС
                mass3[i] = Logic.VB_R(calc.KC, t);//выр без отк раб для ПК
            }
            list.Add(mass1);
            list.Add(mass2);
            list.Add(mass3);
            return list;
        }       
        private List<double[]> VBORforRealOperatingConditions(){
            Calculations calc = Logic.FailureRate(DG3, Convert.ToInt32(DG5.Rows[0].Cells[3].Value), Convert.ToDouble(DG5.Rows[0].Cells[2].Value));
            int len = Convert.ToInt32((Convert.ToDouble(DG5.Rows[0].Cells[4].Value) * 10000) / (Convert.ToDouble(DG5.Rows[0].Cells[1].Value) * 1000)) + 1;
            double[] mass1 = new double[len];
            double[] mass2 = new double[len];
            double[] mass3 = new double[len];
            List<double[]> list = new List<double[]>();
            double t = 0;
            for (int i = 0; i < mass1.Length; i++, t += (Convert.ToDouble(DG5.Rows[0].Cells[1].Value) * 1000) * DoubleClickValue)
            {
                mass1[i] = Logic.VB_R(calc.AO, t, Convert.ToDouble(DG1.Rows[0].Cells[0].Value), Convert.ToDouble(DG1.Rows[0].Cells[1].Value), Convert.ToDouble(DG1.Rows[0].Cells[2].Value));//выр без отк раб для АС
                mass2[i] = Logic.VB_R(calc.PO, t, Convert.ToDouble(DG1.Rows[0].Cells[0].Value), Convert.ToDouble(DG1.Rows[0].Cells[1].Value), Convert.ToDouble(DG1.Rows[0].Cells[2].Value));//выр без отк раб для ПС
                mass3[i] = Logic.VB_R(calc.KO, t, Convert.ToDouble(DG1.Rows[0].Cells[0].Value), Convert.ToDouble(DG1.Rows[0].Cells[1].Value), Convert.ToDouble(DG1.Rows[0].Cells[2].Value));//выр без отк раб для ПК
            }
            list.Add(mass1);
            list.Add(mass2);
            list.Add(mass3);
            return list;
        }
        private List<double[]> VBShR(){
            Calculations calc = Logic.FailureRate(DG3, Convert.ToInt32(DG5.Rows[0].Cells[3].Value), Convert.ToDouble(DG5.Rows[0].Cells[2].Value));
            int len = Convert.ToInt32((Convert.ToDouble(DG5.Rows[0].Cells[4].Value) * 10000) / (Convert.ToDouble(DG5.Rows[0].Cells[1].Value) * 1000)) + 1;
            double[] mass1 = new double[len];
            double[] mass2 = new double[len];
            double[] mass3 = new double[len];
            List<double[]> list = new List<double[]>();
            double t = 0;
            for (int i = 0; i < mass1.Length; i++, t += (Convert.ToDouble(DG5.Rows[0].Cells[1].Value) * 1000) * DoubleClickValue){
                mass1[i] = Logic.VB_R(calc.A, t);// для АС
                mass2[i] = Logic.VB_R(calc.PO, t) * Logic.VB_R(calc.PC, t);// для ПС
                mass3[i] = Logic.VB_R(calc.A, t) * Logic.VB_R(calc.P, t);// для ПК
            }
            list.Add(mass1);
            list.Add(mass2);
            list.Add(mass3);
            return list;
        }
    }
}
