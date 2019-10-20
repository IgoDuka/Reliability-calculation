using System;
using System.Windows.Forms;
using System.Collections;

namespace ToGreatNadegnosti
{
    public class Calculations{
        public double MH_AO;
        public double PR_AO;
        public double PM_AO;
        public double BP_AO;

        public double MH_PO;
        public double PR_PO;
        public double PM_PO;
        public double BP_PO;

        public double MH_AC;
        public double PR_AC;
        public double PM_AC;
        public double BP_AC;

        public double MH_PC;
        public double PR_PC;
        public double PM_PC;
        public double BP_PC;

        public double PO;
        public double PC;
        public double A;
        public double P;
        public double KC;
        public double KO;
        public double K;
        public double AO;
        public double AC;
        public IEnumerator GetEnumerator() { return (IEnumerator)this; }
    }

    class Logic
    {
        /// <summary>
        /// Вероятности безошибочной, безотказной и бессбойной работы (ВБШР, ВБОР, ВБСР)
        /// </summary>
        public static double My_1(double Pindex_t_1, double Pindex_t_2)
        {
            return Pindex_t_1 * Pindex_t_2;
        }

        /// <summary>
        /// Вероятности ошибочной работы (отказа, сбоя) (ВШ, ВО, ВС) ПК и всех компонент 
        /// рассчитываются как дополнение до единицы вероятности безошибочной (безотказной, бессбойной) работы
        /// </summary>
        public static double My_2(double Pindex_t_){
            return 1 - Pindex_t_;
        }

        /// <summary>
        /// Add four operators
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private static double Add4(double Operator1, double Operator2, double Operator3, double Operator4){
            return Operator1 + Operator2 + Operator3 + Operator4;
        }
        /// <summary>
        /// Add two operators
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static double Add2(double Operator1, double Operator2){
            return Operator1 + Operator2;
        }
        public static Calculations FailureRate(DataGridView DG, int Beta, double Alpha){
            Calculations failureRate = new Calculations();

            failureRate.MH_AO = Convert.ToDouble(DG.Rows[0].Cells[0].Value) * 0.00000001;
            failureRate.PR_AO = Convert.ToDouble(DG.Rows[0].Cells[1].Value) * 0.00000001;
            failureRate.PM_AO = Convert.ToDouble(DG.Rows[0].Cells[2].Value) * 0.00000001;
            failureRate.BP_AO = Convert.ToDouble(DG.Rows[0].Cells[3].Value) * 0.00000001;

            failureRate.MH_PO = Convert.ToDouble(DG.Rows[0].Cells[0].Value) * Alpha * 0.00000001;
            failureRate.PR_PO = Convert.ToDouble(DG.Rows[0].Cells[1].Value) * Alpha * 0.00000001;
            failureRate.PM_PO = Convert.ToDouble(DG.Rows[0].Cells[2].Value) * Alpha * 0.00000001;
            failureRate.BP_PO = Convert.ToDouble(DG.Rows[0].Cells[3].Value) * Alpha * 0.00000001;

            failureRate.AO = Add4(failureRate.MH_AO, failureRate.PR_AO, failureRate.PM_AO, failureRate.BP_AO);
            failureRate.AC = failureRate.AO * Beta * 10;
            failureRate.PO = Add4(failureRate.MH_PO, failureRate.PR_PO, failureRate.PM_PO, failureRate.BP_PO);
            failureRate.PC = failureRate.PO * Beta * 10;
            failureRate.A = Add2(failureRate.AO, failureRate.AC);
            failureRate.P = Add2(failureRate.PO, failureRate.PC);
            failureRate.KC = Add2(failureRate.AC, failureRate.PC);
            failureRate.KO = Add2(failureRate.AO, failureRate.PO);
            failureRate.K = Add2(failureRate.A, failureRate.P);
            return failureRate;
        }

        /// <summary>
        /// exp[-(1+(G-1)r)*(ΛКО*t)/G] 
        /// </summary>
        /// <param name="pO"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static double VBORforCyclicFunctioning(double G, double r, double Lyambda, double t){
            double result = Math.Pow((Math.E), ((1 + (G - 1) * r) * (Lyambda * t) / G));
            return 1 / result;
        }

        /// <summary>
        /// ВБШР (ВШ), ВБОР (ВО), ВБСР (ВС) для заданных моментов времени t
        /// </summary>
        /// <returns></returns>
        public static double VB_R(double Lyambda, double t){
            double result = Math.Pow((Math.E), t * Lyambda);
            return 1 / result;
        }
        /// <summary>
        /// ВБШР (ВШ), ВБОР (ВО), ВБСР (ВС) для заданных моментов времени t
        /// </summary>
        /// <returns></returns>
        public static double VB_R(double Lyambda, double t, double Ktemp, double Kvib, double Kper){
            double result = Math.Pow((Math.E), Kper * Ktemp * Kvib * t * Lyambda);
            return 1 / result;
        }

        /// <summary>
        /// ВБОХ
        /// </summary>
        /// <param name="Lyambda"></param>
        /// <param name="t"></param>
        /// <param name="G"></param>
        /// <returns></returns>
        public static double Saving(double Lyambda, double t, double G){
            return Math.Pow(Math.E, ((-Lyambda) * (t / G)));
        }

        /// <summary>
        /// 1 - P(t)
        /// </summary>
        /// <returns></returns>
        public static double DivideOne(double P){
            return 1 - P;
        }
    }
}
