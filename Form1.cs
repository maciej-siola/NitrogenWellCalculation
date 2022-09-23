using static System.Net.Mime.MediaTypeNames;

namespace GlowicaCisnieniowaAzot
{
    public partial class BaseForm : Form
    {
        private NitrogenCalculationWorker worker;
        private delegate void SafeCallTextDelegate(string text, TextBox box);
        private delegate void DisplayActualPositionSafeDelegate(string depth, string pressure, string density, decimal relativePosition);
        private delegate void HideActualPositionSafeDelegate();
        private delegate void SetMiddleDepthAlertDelegate(bool setAlert);
        public BaseForm()
        {
            InitializeComponent();
            worker = new NitrogenCalculationWorker(this);
            TopDepth.Text  = "0";
            MiddleDepth.Text  = "0";
            BottomDepth.Text  = "0";
            TopPressure.Text  = "0.101325";
            MiddlePressure.Text  = "0.101325";
            BottomPressure.Text  = "0.101325";
            worker.StartCalculateDownThread(worker.TopDepthValue, worker.TopPressureValue);
        }

        private void TopTemperature_TextChanged(object sender, EventArgs e)
        {
            Decimal.TryParse(TopTemperature.Text.Replace(",", "."), out worker.TopTemperatureValue);
            worker.TopTemperatureValue += 273.15M;
            if (TopTemperature.Focused)
                (new Thread(() => worker.StartCalculateDownThread(worker.TopDepthValue, worker.TopPressureValue))).Start();
        }

        private void BottomTemperature_TextChanged(object sender, EventArgs e)
        {
            Decimal.TryParse(BottomTemperature.Text.Replace(",", "."), out worker.BottomTemperatureValue);
            worker.BottomTemperatureValue += 273.15M;
            if (BottomTemperature.Focused)
                (new Thread(() => worker.StartCalculateUpThread(worker.BottomDepthValue, worker.BottomPressureValue))).Start();
        }

        private void TopDepth_TextChanged(object sender, EventArgs e)
        {
            Decimal.TryParse(TopDepth.Text.Replace(",", "."), out worker.TopDepthValue);
            if (TopDepth.Focused)
                (new Thread(() => worker.StartCalculateDownThread(worker.TopDepthValue, worker.TopPressureValue))).Start();
        }

        private void MiddleDepth_TextChanged(object sender, EventArgs e)
        {
            Decimal.TryParse(MiddleDepth.Text.Replace(",", "."), out worker.MiddleDepthValue);
            if (MiddleDepth.Focused)
                (new Thread(() => worker.StartCalculateUpDownThread(worker.MiddleDepthValue, worker.MiddlePressureValue))).Start();
        }

        private void BottomDepth_TextChanged(object sender, EventArgs e)
        {
            Decimal.TryParse(BottomDepth.Text.Replace(",", "."), out worker.BottomDepthValue);
            if (BottomDepth.Focused)
                (new Thread(() => worker.StartCalculateUpThread(worker.BottomDepthValue, worker.BottomPressureValue))).Start();
        }

        private void TopPressure_TextChanged(object sender, EventArgs e)
        {
            Decimal.TryParse(TopPressure.Text.Replace(",", "."), out worker.TopPressureValue);
            if (TopPressure.Focused)
                (new Thread(() => worker.StartCalculateDownThread(worker.TopDepthValue, worker.TopPressureValue))).Start();
        }

        private void MiddlePressure_TextChanged(object sender, EventArgs e)
        {
            Decimal.TryParse(MiddlePressure.Text.Replace(",", "."), out worker.MiddlePressureValue);
            if (MiddlePressure.Focused)
                (new Thread(() => worker.StartCalculateUpDownThread(worker.MiddleDepthValue, worker.MiddlePressureValue))).Start();
        }

        private void BottomPressure_TextChanged(object sender, EventArgs e)
        {
            Decimal.TryParse(BottomPressure.Text.Replace(",", "."), out worker.BottomPressureValue);
            if (BottomPressure.Focused)
                (new Thread(() => worker.StartCalculateUpThread(worker.BottomDepthValue, worker.BottomPressureValue))).Start();
        }

        private void WriteTextSafe(string text, TextBox box)
        {
            if (box.InvokeRequired)
            {
                var d = new SafeCallTextDelegate(WriteTextSafe);
                box.Invoke(d, new object[] { text, box });
            }
            else
            {
                box.Text = text;
            }
        }

        private void DisplayActualPositionSafe(string depth, string pressure, string density, decimal relativePosition)
        {
            if (ActualTemperature.InvokeRequired)
            {
                var d = new DisplayActualPositionSafeDelegate(DisplayActualPositionSafe);
                ActualTemperature.Invoke(d, new object[] { depth, pressure, density, relativePosition });
            }
            else
            {
                int absolutePosition = Decimal.ToInt32(relativePosition * (BottomTemperature.Location.Y - TopTemperature.Location.Y)) + TopTemperature.Location.Y;

                ActualTemperature.Location = new Point(ActualTemperature.Location.X, absolutePosition);
                ActualTemperature.Text = Math.Round((worker.BottomTemperatureValue - worker.TopTemperatureValue) * relativePosition + worker.TopTemperatureValue - 273.15M, 2).ToString();
                ActualTemperature.Visible = true;

                ActualDepth.Location = new Point(ActualDepth.Location.X, absolutePosition);
                ActualDepth.Text = depth;
                ActualDepth.Visible = true;

                ActualPressure.Location = new Point(ActualPressure.Location.X, absolutePosition);
                ActualPressure.Text = pressure;
                ActualPressure.Visible = true;
                

                ActualDensity.Location = new Point(ActualDensity.Location.X, absolutePosition);
                ActualDensity.Text = density;
                ActualDensity.Visible = true;
            }
        }

        private void HideActualPositionSafe()
        {
            if (ActualTemperature.InvokeRequired)
            {
                var d = new HideActualPositionSafeDelegate(HideActualPositionSafe);
                ActualTemperature.Invoke(d, new object[] {});
            }
            else
            {
                ActualTemperature.Visible = false;
                ActualDepth.Visible = false;
                ActualPressure.Visible = false;
                ActualDensity.Visible = false;
            }
        }

        private void SetMiddleDepthAlert(bool setAlert)
        {
            if (ActualTemperature.InvokeRequired)
            {
                var d = new SetMiddleDepthAlertDelegate(SetMiddleDepthAlert);
                ActualTemperature.Invoke(d, new object[] { setAlert });
            }
            else
            {
                if (setAlert) MiddleDepth.BackColor = Color.Red;
                else MiddleDepth.BackColor = MiddlePressure.BackColor;
            }
        }
    }
}