using System;
using System.Collections.Generic;
using System.Text;

namespace Parcelamento
{
    public static class Rateio
    {
        public static SortedDictionary<int, decimal> Ratear(TipoRateio tipoRateio, decimal valor, int quantidadeParcelas)
        {
            SortedDictionary<int, decimal> retorno = new SortedDictionary<int, decimal>();

            switch (tipoRateio)
            {
                case TipoRateio.RestoPrimeiraParcela:
                    retorno = Parcelar.RestoPrimeiraParcela(valor, quantidadeParcelas);
                    break;
                case TipoRateio.RestoUltimaParcela:
                    retorno = Parcelar.RestoUltimaParcela(valor, quantidadeParcelas);
                    break;
                case TipoRateio.RestoRateadoEntreParcelasCrescente:
                    retorno = Parcelar.RestoRateadoEntreParcelasCrescente(valor, quantidadeParcelas);
                    break;
                case TipoRateio.RestoRateadoEntreParcelasDecrescente:
                    retorno = Parcelar.RestoRateadoEntreParcelasDecrescente(valor, quantidadeParcelas);
                    break;
            }

            return retorno;
        }
    }
}
