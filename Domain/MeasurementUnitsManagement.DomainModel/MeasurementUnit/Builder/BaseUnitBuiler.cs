using DomainKit.ValueObjects;
using MeasurementUnitsManagement.DomainModel.MeasurementUnit.Service;
using System.Reflection;

namespace MeasurementUnitsManagement.DomainModel.MeasurementUnit.Builder
{
	public class BaseUnitBuiler
	{
		public int Id { get; private set; }
		public Title PersianBaseUnitName { get; private set; }
		public Title EnlishBaseUnitName { get; private set; }
		public string Symbol { get; private set; }
		public int MeasurementDimensionId { get; private set; }
		private readonly IMeasurementUnitAlreadyAddedChecker Checker;

		public BaseUnitBuiler(IMeasurementUnitAlreadyAddedChecker checker, int id, string persianBaseUnitName, string enlishBaseUnitName, string symbol, int measurementDimensionId)
		{
			Checker = checker;
			Id = id;
			PersianBaseUnitName = new Title(persianBaseUnitName);
			EnlishBaseUnitName = new Title(enlishBaseUnitName);
			Symbol = symbol;
			MeasurementDimensionId = measurementDimensionId;
		}

		public BaseUnit Build()
		{
			var baseUnit = new BaseUnit(PersianBaseUnitName.Value, EnlishBaseUnitName.Value, Symbol);
			var baseUnitId = typeof(BaseUnit).GetField("<Id>k__BackingField", BindingFlags.Instance | BindingFlags.NonPublic);
 
			baseUnitId.SetValue(baseUnit, 1);
			baseUnit.AddToMeasurementUnit(Checker, MeasurementDimensionId);
			return baseUnit;
		}
	}
}
