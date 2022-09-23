namespace NitrogenState
{
    internal class NitrogenStateEquation
    {
        //calculation starts from both compressibility factor and density set to 1
        public decimal ZIndex = 1;
        public decimal Density = 1; 
        
        //nitrogen state equation constants
        const decimal GasCriticalTemperatureValue = 126.192M;
        const decimal GasMolarMassValue = 28.01348M;
        const decimal GasCriticalDensity = 313.299959M;


        decimal[] Nk = {0,
                            0.924803575275M, -0.492448489428M, 0.661883336938M, -1.92902649201M, -0.0622469309629M, 0.349943957581M, 0.564857472498M, -1.61720005987M, -0.481395031883M, 0.421150636384M,
                            -0.0161962230825M, 0.172100994165M, 0.00735448924933M, 0.0168077305479M, -0.00107626664179M, -0.0137318088513M, 0.000635466899859M, 0.00304432279419M, -0.0435762336045M, -0.0723174889316M,
                            0.0389644315272M, -0.0212201363910M, 0.00408822981509M, -0.0000551990017984M, -0.0462016716479M, -0.00300311716011M, 0.0368825891208M, -0.00255856846220M, 0.00896915264558M, -0.00441513370350M,
                            0.00133722924858M, 0.000264832491957M, 19.6688194015M, -20.9115600730M, 0.0167788306989M, 2627.67566274M};

        decimal[] ik = {0,
                            1, 1, 2, 2, 3, 3, 1, 1, 1, 3,
                            3, 4, 6, 6, 7, 7, 8, 8, 1, 2,
                            3, 4, 5, 8, 4, 5, 5, 8, 3, 5,
                            6, 9, 1, 1, 3, 2};

        decimal[] jk = {0,
                            0.25M, 0.875M, 0.5M, 0.875M, 0.375M, 0.75M, 0.5M, 0.75M, 2, 1.25M,
                            3.5M, 1, 0.5M, 3, 0, 2.75M, 0.75M, 2.5M, 4, 6,
                            6, 3, 3, 6, 16, 11, 15, 12, 12, 7,
                            4, 16, 0, 1, 2, 3};

        decimal[] lk = {0,
                            0, 0, 0, 0, 0, 0, 1, 1, 1, 1,
                            1, 1, 1, 1, 1, 1, 1, 1, 2, 2,
                            2, 2, 2, 2, 3, 3, 3, 3, 4, 4,
                            4, 4, 2, 2, 2, 2};

        decimal[] ok = {0,
                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                            0, 0, 20, 20, 15, 25};

        decimal[] Bk = {0,
                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                            0, 0, 325, 325, 300, 275};

        decimal[] yk = {0,
                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                            0, 0, 1.16M, 1.16M, 1.13M, 1.25M};

        public void CalculateZ(decimal Temperature, decimal Pressure)
        {
            decimal tau = GasCriticalTemperatureValue / Temperature;
            decimal oRatio;
            decimal oDerivate;
            decimal previousDensity;

            decimal newDensity = (GasMolarMassValue * Pressure * 1000000) / (ZIndex * 8314.4598M * Temperature);

                if (newDensity > (2 * Density))
                {
                    Density = 2 * Density;
                }
                else
                {
                    Density = newDensity;
                }

            while (true)
            {
                oDerivate = 0;
                oRatio = Density / GasCriticalDensity;
                previousDensity = Density;

                for (int k = 1; k < 7; k++)
                {
                    double componentA = Math.Pow((double)oRatio, (double)ik[k]);
                    double componentB = Math.Pow((double)tau, (double)jk[k]);
                    oDerivate += ik[k] * Nk[k] * (decimal)componentA * (decimal)componentB;
                }

                for (int k = 7; k < 33; k++)
                {
                    double componentA = Math.Pow((double)oRatio, (double)ik[k]);
                    double componentB = Math.Pow((double)tau, (double)jk[k]);
                    double componentCA = 0 - Math.Pow((double)oRatio, (double)lk[k]);
                    double componentC = Math.Exp(componentCA);
                    decimal componentD = ik[k] - lk[k] * (decimal)Math.Pow((double)oRatio, (double)lk[k]);
                    oDerivate += Nk[k] *
                                    (decimal)componentA *
                                    (decimal)componentB *
                                    (decimal)componentC *
                                    componentD;
                }

                for (int k = 33; k < 37; k++)
                {
                    oDerivate += Nk[k] *
                                    (decimal)Math.Pow((double)oRatio, (double)ik[k]) *
                                    (decimal)Math.Pow((double)tau, (double)jk[k]) *
                                    (decimal)Math.Exp(
                                        (
                                            (double)(-ok[k]) *
                                            Math.Pow((double)(oRatio - 1), 2)
                                        ) -
                                        (
                                            (double)Bk[k] *
                                            Math.Pow((double)(tau - yk[k]), 2)
                                        )
                                    ) *
                                    (ik[k] - 2 * oRatio * ok[k] * (oRatio - 1));
                }

                ZIndex = 1 + oDerivate;

                newDensity = (GasMolarMassValue * Pressure * 1000000) / (ZIndex * 8314.4598M * Temperature);

                if (newDensity > (Density + 2))
                {
                    Density++;
                }
                else
                {
                    Density = newDensity;
                }

                if (Math.Abs(Density - previousDensity) < 0.1M) break;
            }

            
        }
    }
}
