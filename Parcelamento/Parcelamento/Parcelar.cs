using System;
using System.Collections.Generic;

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
            var parcelamento = Simples(valor, quantidadeParcelas);
            if (parcelamento.resto > 0)
            {
                parcelamento.parcelas[1] = parcelamento.parcelas[1] + parcelamento.resto;
            }

            return parcelamento.parcelas;
        }

        /// <summary>
        /// Gerar lista de parcelas com o valor maior na ultima parcela
        /// </summary>
        /// <param name="valor"></param>
        /// <param name="quantidadeParcelas"></param>
        /// <returns>SortedDictionary<int, decimal> id parcela / valor parcela</returns>
        public static SortedDictionary<int, decimal> RestoUltimaParcela(decimal valor, int quantidadeParcelas)
        {
            var parcelamento = Simples(valor, quantidadeParcelas);

            if (parcelamento.resto > 0)
            {
                var idParcela = parcelamento.parcelas.Count;
                parcelamento.parcelas[idParcela] = parcelamento.parcelas[idParcela] + parcelamento.resto;
            }

            return parcelamento.parcelas;
        }

        /// <summary>
        /// Gerar lista de parcelas com o valor dividido igualmente partindo da primeira parcela
        /// </summary>
        /// <param name="valor"></param>
        /// <param name="quantidadeParcelas"></param>
        /// <returns>SortedDictionary<int, decimal> id parcela / valor parcela</returns>
        public static SortedDictionary<int, decimal> RestoRateadoEntreParcelasCrescente(decimal valor, int quantidadeParcelas)
        {
            var parcelamento = Simples(valor, quantidadeParcelas);

            if (parcelamento.resto > 0)
            {
                var ultimaParcela = parcelamento.parcelas.Count;
                var idParcela = 0;
                for (int i = (int)Math.Truncate(parcelamento.resto * 100); i > 0; i--)
                {
                    idParcela++;

                    parcelamento.parcelas[idParcela] = parcelamento.parcelas[idParcela] + 0.01M;
                    if (idParcela == ultimaParcela)
                        idParcela = 0;
                }
            }

            return parcelamento.parcelas;
        }

        /// <summary>
        /// Gerar lista de parcelas com o valor dividido igualmente partindo da ultima parcela
        /// </summary>
        /// <param name="valor"></param>
        /// <param name="quantidadeParcelas"></param>
        /// <returns>SortedDictionary<int, decimal> id parcela / valor parcela</returns>
        public static SortedDictionary<int, decimal> RestoRateadoEntreParcelasDecrescente(decimal valor, int quantidadeParcelas)
        {
            var parcelamento = Simples(valor, quantidadeParcelas);

            if (parcelamento.resto > 0)
            {
                var ultimaParcela = parcelamento.parcelas.Count;
                var idParcela = ultimaParcela;
                for (int i = (int)Math.Truncate(parcelamento.resto * 100); i > 0; i--)
                {
                    parcelamento.parcelas[idParcela] = parcelamento.parcelas[idParcela] + 0.01M;

                    idParcela--;

                    if (idParcela == 1)
                        idParcela = ultimaParcela + 1;
                }
            }

            return parcelamento.parcelas;
        }

        private static (SortedDictionary<int, decimal> parcelas, decimal resto) Simples(decimal valor, int quantidadeParcelas)
        {
            var parcelas = new SortedDictionary<int, decimal>();
            decimal valorTotal = 0;
            if (quantidadeParcelas <= 1)
            {
                parcelas.Add(1, valor);
                valorTotal = valor;
            }
            else
            {
                decimal valorParcela = Math.Truncate((valor / (decimal)quantidadeParcelas) * 100) / 100;

                for (var i = 1; i <= quantidadeParcelas; i++)
                {
                    parcelas.Add(i, valorParcela);
                    valorTotal += valorParcela;
                }
            }

            decimal resto = valor - valorTotal;

            return (parcelas, resto);
        }
    }
}
