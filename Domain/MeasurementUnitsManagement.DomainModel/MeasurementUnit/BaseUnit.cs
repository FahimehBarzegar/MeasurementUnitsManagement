using DomainKit.ValueObjects;
using MeasurementUnitsManagement.DomainModel.MeasurementUnit.Exception;
using MeasurementUnitsManagement.DomainModel.MeasurementUnit.Service;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MeasurementUnitsManagement.DomainModel.MeasurementUnit
{
	public class BaseUnit : Unit
	{
		private readonly List<FactorUnit> factorUnit;
		private readonly List<FormulateUnit> formulateUnits;
		private BaseUnit()
		{
			factorUnit = new List<FactorUnit>();
			formulateUnits = new List<FormulateUnit>();
		}

		public int Id { get; private set; }
		public Title PersianBaseUnitName { get; private set; }
		public Title EnlishBaseUnitName { get; private set; }
		public string Symbol { get; private set; }
		public int MeasurementDimensionId { get; private set; }
		public MeasurementDimension.MeasurementDimension MeasurementDimension { get; private set; }
		public IReadOnlyCollection<FactorUnit> FactorUnits => new ReadOnlyCollection<FactorUnit>(factorUnit);
		public IReadOnlyCollection<FormulateUnit> FormulateUnits => new ReadOnlyCollection<FormulateUnit>(formulateUnits);


		public BaseUnit(string persianBaseUnitName, string enlishBaseUnitName, string symbol)
		{
			PersianBaseUnitName = new Title(persianBaseUnitName);
			EnlishBaseUnitName = new Title(enlishBaseUnitName);
			Symbol = symbol;
			ValidateInvariants();
		}
		public void Update(string persianBaseUnitName, string enlishBaseUnitName, string symbol)
		{
			PersianBaseUnitName = new Title(persianBaseUnitName);
			EnlishBaseUnitName = new Title(enlishBaseUnitName);
			Symbol = symbol;

			ValidateInvariants();
		}

		public void AddToMeasurementUnit(IMeasurementUnitAlreadyAddedChecker checker, int measurementDimensionId)
		{
			if (checker.IsAddedAlreadyBaseUnit(measurementDimensionId, this))
			{
				throw new MeasurementUnitAlreadyAddedException();
			}

			MeasurementDimensionId = measurementDimensionId;

			ValidateInvariants();
		}
		public void ValidateInvariants()
		{
			if (string.IsNullOrEmpty(Symbol))
				throw new SymbolIsNullOrEmptyException();

			if (string.IsNullOrEmpty(PersianBaseUnitName.Value))
				throw new PersianUnitNameIsNullOrEmptyException();

			if (string.IsNullOrEmpty(EnlishBaseUnitName.Value))
				throw new EnlishUnitNameIsNullOrEmptyException();
		}
	}
}
