using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Numerics.Test {
	[TestClass]
	public class TestDecimal {
		/// <summary>
		/// Tests the ToString of various numbers.
		/// 
		/// (All other tests should use ToString as well as it's the easiest way to get an exact value out)
		/// </summary>
		[TestMethod]
		public void TestToString() {
			BigDecimal d;

			// integers
			d = new BigDecimal(0, 0);
			Assert.AreEqual("0.", d.ToString());

			d = new BigDecimal(1, 0);
			Assert.AreEqual("1.", d.ToString());

			// with decimal point inside number
			d = new BigDecimal(1234, 2);
			Assert.AreEqual("12.34", d.ToString());

			// with decimal point before number
			d = new BigDecimal(1, 2);
			Assert.AreEqual("0.01", d.ToString());

			// really big number, with decimal point
			d = new BigDecimal(BigInteger.Parse("12345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890"), 20);
			Assert.AreEqual("123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890.12345678901234567890", d.ToString());
		}

		/// <summary>
		/// Tests the parse methods.
		/// </summary>
		[TestMethod]
		public void TestParse() {
			BigDecimal d;

			d = BigDecimal.Parse("1");
			Assert.AreEqual("1.", d.ToString());

			d = BigDecimal.Parse("2.");
			Assert.AreEqual("2.", d.ToString());

			d = BigDecimal.Parse("3.0");
			// note: trailing zeroes are preserved
			Assert.AreEqual("3.0", d.ToString());

			d = BigDecimal.Parse("004.00");
			Assert.AreEqual("4.00", d.ToString());

			// now for some scientific notations

			d = BigDecimal.Parse("1e2");
			Assert.AreEqual("100.", d.ToString());

			d = BigDecimal.Parse("1e-2");
			Assert.AreEqual("0.01", d.ToString());

			d = BigDecimal.Parse("100e2");
			Assert.AreEqual("10000.", d.ToString());

			d = BigDecimal.Parse("100e-2");
			Assert.AreEqual("1.00", d.ToString());

			d = BigDecimal.Parse("100e-4");
			Assert.AreEqual("0.0100", d.ToString());

			d = BigDecimal.Parse("123e2");
			Assert.AreEqual("12300.", d.ToString());

			d = BigDecimal.Parse("123e-2");
			Assert.AreEqual("1.23", d.ToString());

			d = BigDecimal.Parse("123.45e2");
			Assert.AreEqual("12345.", d.ToString());

			d = BigDecimal.Parse("123.45e-2");
			Assert.AreEqual("1.2345", d.ToString());

			d = BigDecimal.Parse("123.4567e2");
			Assert.AreEqual("12345.67", d.ToString());

			d = BigDecimal.Parse("123.4567e-2");
			Assert.AreEqual("1.234567", d.ToString());

			d = BigDecimal.Parse("123.45e6");
			Assert.AreEqual("123450000.", d.ToString());

			d = BigDecimal.Parse("123.45e-6");
			Assert.AreEqual("0.00012345", d.ToString());
		}
	}
}
