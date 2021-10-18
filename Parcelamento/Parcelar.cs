using System;
using System.Collections.Generic;
using System.Linq;

namespace Parcelamento
{
    public static class Parcelar
    {
        /// <summary>
        /// Gerar lista de parcelas com o valor maior na primeira parcela
        /// </summary>
        /// <param name="valor"></param>
        /// <param name="quantidadeParcelas"></param>
        /// <returns>SortedDictionary<int, decimal> id parcela / valor parcela</returns>
        public static SortedDictionary<int, decimal> RestoPrimeiraParcela(decimal valor, int quantidadeParcelas)
        {
            return Simples(valor, quantidadeParcelas, 
                (parcelas, resto) =>
                {
                    if (resto > 0)
                    {
                        parcelas[1] = parcelas[1] + resto;
                    }
                    return parcelas;
                }
            );

        }

        /// <summary>
        /// Gerar lista de parcelas com o valor maior na ultima parcela
        /// </summary>
        /// <param name="valor"></param>
        /// <param name="quantidadeParcelas"></param>
        /// <returns>SortedDictionary<int, decimal> id parcela / valor parcela</returns>
        public static SortedDictionary<int, decimal> RestoUltimaParcela(decimal valor, int quantidadeParcelas)
        {
            return Simples(valor, quantidadeParcelas,
                (parcelas, resto) =>
                {

                    if (resto > 0)
                    {
                        var idParcela = parcelas.Count;
                        parcelas[idParcela] = parcelas[idParcela] + resto;
                    }

                    return parcelas;
                });
        }

        /// <summary>
        /// Gerar lista de parcelas com o valor dividido igualmente partindo da primeira parcela
        /// </summary>
        /// <param name="valor"></param>
        /// <param name="quantidadeParcelas"></param>
        /// <returns>SortedDictionary<int, decimal> id parcela / valor parcela</returns>
        public static SortedDictionary<int, decimal> RestoRateadoEntreParcelasCrescente(decimal valor, int quantidadeParcelas)
        {
            return Simples(valor, quantidadeParcelas,
                (parcelas, resto) =>
                {

                    if (resto > 0)
                    {
                        var ultimaParcela = parcelas.Count;
                        var idParcela = 0;
                        for (int i = (int)Math.Truncate(resto * 100); i > 0; i--)
                        {
                            idParcela++;

                            parcelas[idParcela] = parcelas[idParcela] + 0.01M;
                            if (idParcela == ultimaParcela)
                                idParcela = 1;
                        }
                    }

                    return parcelas;
                });
        }

        /// <summary>
        /// Gerar lista de parcelas com o valor dividido igualmente partindo da ultima parcela
        /// </summary>
        /// <param name="valor"></param>
        /// <param name="quantidadeParcelas"></param>
        /// <returns>SortedDictionary<int, decimal> id parcela / valor parcela</returns>
        public static SortedDictionary<int, decimal> RestoRateadoEntreParcelasDecrescente(decimal valor, int quantidadeParcelas)
        {
            return Simples(valor, quantidadeParcelas, (parcelas, resto) =>
            {
                if (resto > 0)
                {
                    var ultimaParcela = parcelas.Count;
                    var idParcela = ultimaParcela;
                    for (int i = (int)Math.Truncate(resto * 100); i > 0; i--)
                    {
                        parcelas[idParcela] = parcelas[idParcela] + 0.01M;

                        idParcela--;

                        if (idParcela == 0)
                            idParcela = ultimaParcela;
                    }
                }
                return parcelas;
            });
        }

        private static SortedDictionary<int, decimal> Simples(decimal valor, int quantidadeParcelas, Func<SortedDictionary<int, decimal>, decimal, SortedDictionary<int, decimal>> rateio)
        {
            var valorModulo = Math.Abs(valor);

            var parcelas = new SortedDictionary<int, decimal>();
            decimal valorTotal = 0;
            if (quantidadeParcelas <= 1)
            {
                parcelas.Add(1, valorModulo);
                valorTotal = valorModulo;
            }
            else
            {
                decimal valorParcela = Math.Truncate((valorModulo / (decimal)quantidadeParcelas) * 100) / 100;

                for (var i = 1; i <= quantidadeParcelas; i++)
                {
                    parcelas.Add(i, valorParcela);
                    valorTotal += valorParcela;
                }
            }

            decimal resto = valorModulo - valorTotal;

            parcelas = rateio(parcelas, resto);

            if (valor < 0)
            {
                parcelas.Keys.ToList().ForEach(key =>
                {
                    parcelas[key] = parcelas[key] * -1;
                });
            }

            return parcelas;
        }
    }
}
