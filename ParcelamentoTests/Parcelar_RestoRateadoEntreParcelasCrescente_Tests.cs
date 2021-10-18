using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Parcelamento.Tests
{
    [TestClass()]
    public class Parcelar_RestoRateadoEntreParcelasCrescente_Tests
    {
        [TestMethod()]
        [DataRow(false)]
        [DataRow(true)]
        public void RestoRateadoEntreParcelasCrescente_ComResto_Test(bool negativo)
        {
            var modulo = negativo ? -1M : 1M;
            var expected = new SortedDictionary<int, decimal>();
            expected.Add(1, 1.67M * modulo);
            expected.Add(2, 1.67M * modulo);
            expected.Add(3, 1.67M * modulo);
            expected.Add(4, 1.67M * modulo);
            expected.Add(5, 1.66M * modulo);
            expected.Add(6, 1.66M * modulo);

            //Action
            var resultado = Parcelar.RestoRateadoEntreParcelasCrescente(10M * modulo, 6);

            //Assert
            resultado.Should().BeEquivalentTo(expected);
        }

        [TestMethod()]
        [DataRow(false)]
        [DataRow(true)]
        public void RestoRateadoEntreParcelasCrescente_SemResto_Test(bool negativo)
        {
            var modulo = negativo ? -1M : 1M;
            var expected = new SortedDictionary<int, decimal>();
            expected.Add(1, 2M * modulo);
            expected.Add(2, 2M * modulo);
            expected.Add(3, 2M * modulo);
            expected.Add(4, 2M * modulo);
            expected.Add(5, 2M * modulo);
            expected.Add(6, 2M * modulo);

            //Action
            var resultado = Parcelar.RestoRateadoEntreParcelasCrescente(12M * modulo, 6);

            //Assert
            resultado.Should().BeEquivalentTo(expected);
        }
    }
}