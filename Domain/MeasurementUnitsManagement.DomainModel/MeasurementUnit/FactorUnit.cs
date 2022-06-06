using DomainKit.ValueObjects;
using MeasurementUnitsManagement.DomainModel.MeasurementUnit.Exception;

namespace MeasurementUnitsManagement.DomainModel.MeasurementUnit
{
    public class FactorUnit :Unit
    {
		public int Id { get; private set; }
		public int BaseUnitId { get; private set; }
        public BaseUnit BaseUnit { get; private set; }
        public float ConversionFactorToBaseUnit { get; private set; }
		public Title PersianBaseUnitName { get; private set; }
		public Title EnlishBaseUnitName { get; private set; }
		public string Symbol { get; private set; }
		private FactorUnit()
        {
        }

        public FactorUnit(int baseUnitId, string persianBaseUnitName, string enlishBaseUnitName, string symbol, float conversionFactorToBaseUnit)
        {
            BaseUnitId = baseUnitId;
            PersianBaseUnitName = new Title(persianBaseUnitName);
            EnlishBaseUnitName = new Title(enlishBaseUnitName);
            Symbol = symbol;
            ConversionFactorToBaseUnit = conversionFactorToBaseUnit;

            ValidateInvariants();
        }

        public void Update(int baseUnitId, string persianBaseUnitName, string enlishBaseUnitName, string symbol, float conversionFactorToBaseUnit)
        {
            BaseUnitId = baseUnitId;
            PersianBaseUnitName = new Title(persianBaseUnitName);
            EnlishBaseUnitName = new Title(enlishBaseUnitName);
            Symbol = symbol;
            ConversionFactorToBaseUnit = conversionFactorToBaseUnit;

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
        }
    }
}
