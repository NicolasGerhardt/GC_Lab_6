using System;
using System.Collections.Generic;
using System.Text;
using GC_Lab_6;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;

namespace GC_Lab_6_Test
{
    public class CashRegister_Test
    {
        [Fact]
        public void Till_HasCash_NotEmpty()
        {
            var register = new CashRegister(500.00);

            double expected = 500.0;

            double actual = register.Till;

            Assert.Equal(expected, actual, 2);
        }

        [Fact]
        public void MakeChange_RequestAmountSmallerThanTill_ReturnFullAmount()
        {
            var register = new CashRegister(500.00);
            double requestAmount = 10.0;

            bool actual = register.TryMakeChange(requestAmount);


            Assert.True(actual);
        }

        [Fact]
        public void MakeChange_RequestAmountSmallerThanTill_TillAmountLowered()
        {
            var register = new CashRegister(500.00);
            double requestAmount = 10.0;
            double expected = 500 - requestAmount;

            register.TryMakeChange(requestAmount);
            double actual = register.Till;

            Assert.Equal(expected, actual, 2);
        }

        [Fact]
        public void MakeChange_RequestAmountSmallerThanTill_negitive1()
        {
            var register = new CashRegister(5.00);
            double requestAmount = 10.0;

            bool actual = register.TryMakeChange(requestAmount);


            Assert.False(actual);
        }
        
    }
}
