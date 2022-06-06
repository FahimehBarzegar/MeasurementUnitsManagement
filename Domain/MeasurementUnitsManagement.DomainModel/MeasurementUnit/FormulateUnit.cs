using DomainKit.ValueObjects;
using MeasurementUnitsManagement.DomainModel.MeasurementUnit.Exception;
using System.Collections.Generic;
using System.Linq;

namespace MeasurementUnitsManagement.DomainModel.MeasurementUnit
{
	public class FormulateUnit : Unit
	{
		public int Id { get; private set; }		
		public int BaseUnitId { get; private set; }
		public BaseUnit BaseUnit { get; private set; }
		public Title PersianBaseUnitName { get; private set; }
		public Title EnlishBaseUnitName { get; private set; }
		public string Symbol { get; private set; }
		public string FormulaConversionToBaseUnit { get; private set; }
		public string FormulaConversionFromBaseUnit { get; private set; }
		private FormulateUnit()
		{
		}

		public FormulateUnit(int baseUnitId, string persianBaseUnitName, string enlishBaseUnitName, string symbol, string formulaConversionToBaseUnit, string formulaConversionFromBaseUnit)
		{
			PersianBaseUnitName = new Title(persianBaseUnitName);
			EnlishBaseUnitName = new Title(enlishBaseUnitName);
			Symbol = symbol;
			BaseUnitId = baseUnitId;
			FormulaConversionToBaseUnit = formulaConversionToBaseUnit;
			FormulaConversionFromBaseUnit = formulaConversionFromBaseUnit;

			ValidateInvariants();
		}

		public void UpdateFormulateUnit(int baseUnitId, string persianBaseUnitName, string enlishBaseUnitName, string symbol, string formulaConversionToBaseUnit, string formulaConversionFromBaseUnit)
		{
			PersianBaseUnitName = new Title(persianBaseUnitName);
			EnlishBaseUnitName = new Title(enlishBaseUnitName);
			Symbol = symbol;
			FormulaConversionToBaseUnit = formulaConversionToBaseUnit;
			FormulaConversionFromBaseUnit = formulaConversionFromBaseUnit;
			BaseUnitId = baseUnitId;

			ValidateInvariants();
		}

		public void ValidateInvariants()
		{
			if (BaseUnitId == 0)
				throw new BaseUnitIdNotDefineException();

			if (string.IsNullOrEmpty(Symbol))
				throw new SymbolIsNullOrEmptyException();

			if (string.IsNullOrEmpty(PersianBaseUnitName.Value))
				throw new PersianUnitNameIsNullOrEmptyException();

			if (string.IsNullOrEmpty(EnlishBaseUnitName.Value))
				throw new EnlishUnitNameIsNullOrEmptyException();

			verifyCharacterValidation(FormulaConversionToBaseUnit);
			verifyCharacterValidation(FormulaConversionFromBaseUnit);
			verifyEqualityParenthesis(FormulaConversionToBaseUnit);
			verifyEqualityParenthesis(FormulaConversionFromBaseUnit);
		}

		private void verifyCharacterValidation(string text)
		{
			var validChars = new HashSet<char>("a1234567890.()-+/* ");
			var notValidCharacter = text.Where(c => !validChars.Contains(c)).ToArray();

			if (notValidCharacter.Count() > 0)
				throw new InvalidCharacterInFormulaConversionToBaseUnitException(notValidCharacter);
		}

		private void verifyEqualityParenthesis(string text)
		{
			var openParenthesisCount = text.Count(x => x == '(');
			var closeParenthesisCount = text.Count(x => x == ')');

			if (openParenthesisCount != closeParenthesisCount)
				throw new IncorrectTheNumberOfOpenAndCloseParenthesesException();
		}
	}
}
