using NitrogenState;

namespace GlowicaCisnieniowaAzot
{
    public partial class BaseForm : Form
    {
        internal class NitrogenCalculationWorker
        {
            public decimal TopTemperatureValue = 8 + 273.15M;
            public decimal BottomTemperatureValue = 8 + 273.15M;
            public decimal TopDepthValue = 0;
            public decimal MiddleDepthValue = 0;
            public decimal BottomDepthValue = 0;
            public decimal TopPressureValue = 0;
            public decimal MiddlePressureValue = 0;
            public decimal BottomPressureValue = 0;
            public decimal StepSize = 0.1M;
            private Thread CalculateUpThread;
            private Thread CalculateDownThread;
            private decimal FromDepthUp;
            private decimal FromPressureUp;
            private decimal FromDepthDown;
            private decimal FromPressureDown;
            BaseForm Window;
            private bool UpThreadStop = false;
            private bool DownThreadStop = false;

            public NitrogenCalculationWorker(BaseForm window)
            {
                Window = window;
                CalculateUpThread = new Thread(CalculateUp);
                CalculateDownThread = new Thread(CalculateDown);
            }

            private void CalculateDown()
            {
                decimal Depth = FromDepthDown;
                decimal PressureAtDepth = FromPressureDown;
                decimal TemperatureAtDepth;
                NitrogenStateEquation Nitrogen = new NitrogenStateEquation();

                while (Depth <= BottomDepthValue && !DownThreadStop)
                {
                    if (BottomDepthValue <= TopDepthValue) break;
                    decimal relativePosition = (Depth - TopDepthValue)  / (BottomDepthValue - TopDepthValue);
                    TemperatureAtDepth = (Depth - TopDepthValue) * ((BottomTemperatureValue - TopTemperatureValue) / (BottomDepthValue - TopDepthValue)) + TopTemperatureValue;
                    Nitrogen.CalculateZ(TemperatureAtDepth, PressureAtDepth);
                    PressureAtDepth += StepSize * Nitrogen.Density * 9.8123M / 1000000;

                    Window.DisplayActualPositionSafe(Math.Round(Depth, 5).ToString(), Math.Round(PressureAtDepth, 5).ToString(), Math.Round(Nitrogen.Density, 5).ToString(), relativePosition);

                    if (Depth == TopDepthValue)
                    {
                        Window.WriteTextSafe(Math.Round(Nitrogen.Density, 5).ToString(), Window.TopDensity);
                    }
                    if (Depth <= MiddleDepthValue && (Depth + StepSize) > MiddleDepthValue)
                    {
                        Window.WriteTextSafe(Math.Round(Nitrogen.Density, 5).ToString(), Window.MiddleDensity);
                        if (FromDepthUp != MiddleDepthValue)
                            Window.WriteTextSafe(Math.Round(PressureAtDepth, 5).ToString(), Window.MiddlePressure);
                    }
                    if (Depth <= BottomDepthValue && (Depth + StepSize) > BottomDepthValue)
                    {
                        Window.WriteTextSafe(Math.Round(PressureAtDepth, 5).ToString(), Window.BottomPressure);
                        Window.WriteTextSafe(Math.Round(Nitrogen.Density, 5).ToString(), Window.BottomDensity);
                    }

                    Depth += StepSize;
                }
                Window.HideActualPositionSafe();
            }

            private void CalculateUp()
            {
                decimal Depth = FromDepthUp;
                decimal PressureAtDepth = FromPressureUp;
                decimal TemperatureAtDepth;
                NitrogenStateEquation Nitrogen = new NitrogenStateEquation();

                while (Depth >= TopDepthValue && !UpThreadStop)
                {
                    if (BottomDepthValue <= TopDepthValue) break;
                    decimal relativePosition = (Depth - TopDepthValue)  / (BottomDepthValue - TopDepthValue);
                    TemperatureAtDepth = (Depth - TopDepthValue) * ((BottomTemperatureValue - TopTemperatureValue) / (BottomDepthValue - TopDepthValue)) + TopTemperatureValue;
                    Nitrogen.CalculateZ(TemperatureAtDepth, PressureAtDepth);
                    PressureAtDepth -= StepSize * Nitrogen.Density * 9.8123M / 1000000;
                    
                    Window.DisplayActualPositionSafe(Math.Round(Depth, 5).ToString(), Math.Round(PressureAtDepth, 5).ToString(), Math.Round(Nitrogen.Density, 5).ToString(), relativePosition);

                    if(Depth == BottomDepthValue)
                    {
                        Window.WriteTextSafe(Math.Round(Nitrogen.Density, 5).ToString(), Window.BottomDensity);
                    }
                    if (Depth >= TopDepthValue && (Depth - StepSize) < TopDepthValue)
                    {
                        Window.WriteTextSafe(Math.Round(Nitrogen.Density, 5).ToString(), Window.TopDensity);
                        Window.WriteTextSafe(Math.Round(PressureAtDepth, 5).ToString(), Window.TopPressure);
                    }
                    if (Depth >= MiddleDepthValue && (Depth - StepSize) < MiddleDepthValue)
                    {
                        if(FromDepthUp != MiddleDepthValue)
                            Window.WriteTextSafe(Math.Round(PressureAtDepth, 5).ToString(), Window.MiddlePressure);
                        Window.WriteTextSafe(Math.Round(Nitrogen.Density, 5).ToString(), Window.MiddleDensity);
                    }
                    

                    Depth -= StepSize;
                }
                Window.HideActualPositionSafe();
            }

            public void StartCalculateUpThread(decimal FromDepth, decimal FromPressure)
            {
                StopCalculation();

                if (MiddleDepthValue > BottomDepthValue || MiddleDepthValue < TopDepthValue)
                {
                    Window.SetMiddleDepthAlert(true);
                    return;
                }
                else Window.SetMiddleDepthAlert(false);                

                FromDepthUp = FromDepth;
                FromPressureUp = FromPressure;
                
                CalculateUpThread = new Thread(CalculateUp);
                UpThreadStop = false;
                CalculateUpThread.Start();
            }

            public void StartCalculateDownThread(decimal FromDepth, decimal FromPressure)
            {
                StopCalculation();
                
                if (MiddleDepthValue > BottomDepthValue || MiddleDepthValue < TopDepthValue)
                {
                    Window.SetMiddleDepthAlert(true);                    
                    return;
                }
                else Window.SetMiddleDepthAlert(false);

                FromDepthDown = FromDepth;
                FromPressureDown = FromPressure;
                
                CalculateDownThread = new Thread(CalculateDown);
                DownThreadStop = false;
                CalculateDownThread.Start();
            }

            public void StartCalculateUpDownThread(decimal FromDepth, decimal FromPressure)
            {
                StopCalculation();

                if (MiddleDepthValue > BottomDepthValue || MiddleDepthValue < TopDepthValue)
                {
                    Window.SetMiddleDepthAlert(true);
                    return;
                }
                else Window.SetMiddleDepthAlert(false);

                FromDepthDown = FromDepth;
                FromPressureDown = FromPressure;
                FromDepthUp = FromDepth;
                FromPressureUp = FromPressure;

                CalculateDownThread = new Thread(CalculateDown);
                DownThreadStop = false;
                CalculateDownThread.Start();

                Thread.Sleep(20);
                while (CalculateDownThread.IsAlive)
                {
                    if (DownThreadStop) return;
                }

                CalculateUpThread = new Thread(CalculateUp);
                UpThreadStop = false;
                CalculateUpThread.Start();
            }

            private void StopCalculation()
            {
                if (CalculateDownThread.IsAlive || CalculateUpThread.IsAlive)
                {
                    DownThreadStop = true;
                    UpThreadStop = true;
                    while (CalculateDownThread.IsAlive || CalculateUpThread.IsAlive) ;
                }
            }
        }
    }
    
}
