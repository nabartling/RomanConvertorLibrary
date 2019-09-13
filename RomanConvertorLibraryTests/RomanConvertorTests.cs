using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanConvertorLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// DO NOT CHANGE ANYTHING IN THIS FILE!
/// </summary>

namespace RomanConvertorLibrary.Tests
{
	[TestClass()]
	public class RomanConvertorTests
	{
		Dictionary<string, int> sampleRandomNumbers = new Dictionary<string, int>()
			{
				{ "XV", 15 },
				{ "VI", 6 },
				{ "LXXVIII", 78 },
				{ "CIII", 103 }
			};

		Dictionary<string, int> specialNumbers = new Dictionary<string, int>()
			{
				{ "I", 1 },
				{ "V", 5 },
				{ "X", 10 },
				{ "L", 50 },
				{ "C", 100 },
				{ "D", 500 },
				{ "M", 1000 }
			};

		[TestMethod()]
		public void ToRomanTest_RepeatingSingleDigits()
		{
			Assert.AreEqual("I", RomanConvertor.ToRoman(1));
			Assert.AreEqual("III", RomanConvertor.ToRoman(3));
		}

		[TestMethod()]
		public void ToRomanTest_RandomSuccessfulValues()
		{
			foreach (var number in sampleRandomNumbers)
			{
				Assert.AreEqual(number.Key, RomanConvertor.ToRoman(number.Value));
			}
		}

		[TestMethod()]
		public void ToArabicTest_RandomSuccessfulValues()
		{
			foreach (var number in sampleRandomNumbers)
			{
				Assert.AreEqual(number.Value, RomanConvertor.ToArabic(number.Key));
			}
		}

		[TestMethod()]
		public void ToRomanTest_SpecialNumbers()
		{
			foreach (var number in specialNumbers)
			{
				Assert.AreEqual(number.Key, RomanConvertor.ToRoman(number.Value));
			}
		}

		[TestMethod()]
		public void ToArabicTest_SpecialNumbers()
		{
			foreach (var number in specialNumbers)
			{
				Assert.AreEqual(number.Value, RomanConvertor.ToArabic(number.Key));
			}
		}

		[TestMethod()]
		public void Test_Sanity()
		{
			var originalRomanNumber = "MCDXCVIII";
			var convertedArabic = RomanConvertor.ToArabic(originalRomanNumber);
			var convertedRoman = RomanConvertor.ToRoman(convertedArabic);

			Assert.AreEqual(originalRomanNumber, convertedRoman);
		}

		[TestMethod()]
		public void ToRomanTest_TestNegative()
		{
			Assert.ThrowsException<InvalidOperationException>(() =>
			{
				var result = RomanConvertor.ToRoman(-1);
			}
			);
		}

		[TestMethod()]
		public void ToRomanTest_Test0()
		{
			Assert.ThrowsException<InvalidOperationException>(() =>
			{
				var result = RomanConvertor.ToRoman(0);
			}
			);
		}

		[TestMethod()]
		public void ToRomanTest_Test4000()
		{
			Assert.ThrowsException<InvalidOperationException>(() =>
			{
				var result = RomanConvertor.ToRoman(4000);
			}
			);
		}

		[TestMethod()]
		public void ToRomanTest_TestMoreThan4000()
		{
			Assert.ThrowsException<InvalidOperationException>(() =>
			{
				var result = RomanConvertor.ToRoman(4001);
			}
			);
		}


		[TestMethod()]
		public void ToArabicTest_InvalidChars()
		{
			Assert.ThrowsException<FormatException>(() =>
			{
				var result = RomanConvertor.ToArabic("XXBBIIOO");
			}
			);
		}

	}
}