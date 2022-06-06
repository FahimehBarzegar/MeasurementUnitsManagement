using MeasurementUnitsManagement.DomainModel.MeasurementDimension.Builder;
using MeasurementUnitsManagement.DomainModel.MeasurementUnit;
using MeasurementUnitsManagement.DomainModel.MeasurementUnit.Builder;
using MeasurementUnitsManagement.DomainModel.MeasurementUnit.Exception;
using MeasurementUnitsManagement.DomainModel.MeasurementUnit.Service;
using NUnit.Framework;

namespace MeasurementUnitsManagement.DomainModel.Test
{
	public class FormulateUnitTest : IMeasurementUnitAlreadyAddedChecker
	{
		private MeasurementDimension.MeasurementDimension measurementDimension;
		private BaseUnit baseUnitCelsius;
		private int id = 1;
		private string englishTitle = "Temperature";
		private string persianTitle = "دما";

		[SetUp]
		public void Setup()
		{
			measurementDimension = new MeasurementDimensionBuilder(id, englishTitle, persianTitle).Build();
			baseUnitCelsius = new BaseUnitBuiler(this, 1, "سلسیوس", "Celsius", "c", measurementDimension.Id).Build();
		}

		[Test]
		public void Set_English_Name_To_Null_ThrowException()
		{
			Assert.That(() => new FormulateUnit(baseUnitCelsius.Id, "کلوین", null, "k", "a - 273.15", "a + 273.15"), Throws.TypeOf<EnlishUnitNameIsNullOrEmptyException>());
		}

		[Test]
		public void Set_English_Name_To_Empty_ThrowException()
		{
			Assert.That(() => new FormulateUnit(baseUnitCelsius.Id, "کلوین", "", "k", "a - 273.15", "a + 273.15"), Throws.TypeOf<EnlishUnitNameIsNullOrEmptyException>());
		}

		[Test]
		public void Set_Farsi_Name_To_Null_ThrowException()
		{
			Assert.That(() => new FormulateUnit(baseUnitCelsius.Id, null, "Kelvin", "k", "a - 273.15", "a + 273.15"), Throws.TypeOf<PersianUnitNameIsNullOrEmptyException>());
		}

		[Test]
		public void Set_Farsi_Name_To_Empty_ThrowException()
		{
			Assert.That(() => new FormulateUnit(baseUnitCelsius.Id, "", "Kelvin", "k", "a - 273.15", "a + 273.15"), Throws.TypeOf<PersianUnitNameIsNullOrEmptyException>());
		}

		[Test]
		public void Set_Symbol_To_null_ThrowException()
		{
			Assert.That(() => new FormulateUnit(baseUnitCelsius.Id, "کلوین", "Kelvin", "", "a - 273.15", "a + 273.15"), Throws.TypeOf<SymbolIsNullOrEmptyException>());
		}

		[Test]
		public void Set_Not_Valid_Character_To_FormulaConversionToBaseUnit_ThrowException()
		{
			Assert.That(() => new FormulateUnit(1, "کلوین", "Kelvin", "k", "m - 273.15", "a + 273.15"), Throws.TypeOf<InvalidCharacterInFormulaConversionToBaseUnitException>());
		}

		[Test]
		public void Set_Not_Valid_Character_To_FormulaConversionFromBaseUnit_ThrowException()
		{
			Assert.That(() => new FormulateUnit(1, "کلوین", "Kelvin", "k", "a - 273.15", "m + 273.15"), Throws.TypeOf<InvalidCharacterInFormulaConversionToBaseUnitException>());
		}

		[Test]
		public void Set_Not_Equal_Parenthesis_To_FormulaConversionToBaseUnit_ThrowException()
		{
			Assert.That(() => new FormulateUnit(1, "کلوین", "Kelvin", "k", "((a) - 273.15", "a + 273.15"), Throws.TypeOf<IncorrectTheNumberOfOpenAndCloseParenthesesException>());
		}

		[Test]
		public void Set_Not_Equal_Parenthesis_To_FormulaConversionFromBaseUnit_ThrowException()
		{
			Assert.That(() => new FormulateUnit(1, "کلوین", "Kelvin", "k", "(a - 273.15", "((a) + 273.15"), Throws.TypeOf<IncorrectTheNumberOfOpenAndCloseParenthesesException>());
		}

		public bool IsAddedAlreadyBaseUnit(int measurementDimensionId, BaseUnit BaseUnits)
		{
			return false;
		}
	}
}
