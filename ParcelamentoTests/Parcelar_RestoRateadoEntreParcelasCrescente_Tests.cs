using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Parcelamento.Tests
{
    [TestClass()]
    public class Parcelar_RestoRateadoEntreParcelasCrescente_Tests
    {
        [TestMethod()]
        public void RestoRateadoEntreParcelasCrescente_ComResto_Test()
        {
            var expected = new SortedDictionary<int, decimal>();
            expected.Add(1, 1.67M);
            expected.Add(2, 1.67M);
            expected.Add(3, 1.67M);
            expected.Add(4, 1.67M);
            expected.Add(5, 1.66M);
            expected.Add(6, 1.66M);

            //Action
            var resultado = Parcelar.RestoRateadoEntreParcelasCrescente(10M, 6);

            //Assert
            resultado.Should().BeEquivalentTo(expected);
        }

        [TestMethod()]
        public void RestoRateadoEntreParcelasCrescente_SemResto_Test()
        {
            var expected = new SortedDictionary<int, decimal>();
            expected.Add(1, 2M);
            expected.Add(2, 2M);
            expected.Add(3, 2M);
            expected.Add(4, 2M);
            expected.Add(5, 2M);
            expected.Add(6, 2M);

            //Action
            var resultado = Parcelar.RestoRateadoEntreParcelasCrescente(12M, 6);

            //Assert
            resultado.Should().BeEquivalentTo(expected);
        }
    }
}