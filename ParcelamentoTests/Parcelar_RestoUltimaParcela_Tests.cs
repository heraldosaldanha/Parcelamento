using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Parcelamento.Tests
{
    [TestClass()]
    public class Parcelar_RestoUltimaParcela_Tests
    {
        [TestMethod()]
        [DataRow(false)]
        [DataRow(true)]
        public void RestoUltimaParcela_ComResto_Test(bool negativo)
        {
            var modulo = negativo ? -1M: 1M;
            var expected = new SortedDictionary<int, decimal>();
            expected.Add(1, 1.66M * modulo);
            expected.Add(2, 1.66M * modulo);
            expected.Add(3, 1.66M * modulo);
            expected.Add(4, 1.66M * modulo);
            expected.Add(5, 1.66M * modulo);
            expected.Add(6, 1.70M * modulo);

            //Action
            var resultado = Parcelar.RestoUltimaParcela(10M * modulo, 6);

            //Assert
            resultado.Should().BeEquivalentTo(expected);
        }

        [TestMethod()]
        [DataRow(false)]
        [DataRow(true)]
        public void RestoUltimaParcela_SemResto_Test(bool negativo)
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
            var resultado = Parcelar.RestoPrimeiraParcela(12M * modulo, 6);

            //Assert
            resultado.Should().BeEquivalentTo(expected);
        }
    }
}