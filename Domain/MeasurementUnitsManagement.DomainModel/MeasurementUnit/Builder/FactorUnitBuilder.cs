using DomainKit.ValueObjects;
using System.Collections.Generic;

namespace MeasurementUnitsManagement.DomainModel.MeasurementUnit.Builder
{
    public class FactorUnitBuilder
    {
        public int BaseUnitId { get; set; }
        public float ConversionFactorToBaseUnit { get; set; }
        public Title PersianBaseUnitName { get; set; }
        public Title EnlishBaseUnitName { get; set; }
        public string Symbol { get; set; }

        public FactorUnitBuilder()
        {
        }

        public FactorUnit Build()
        {
            var factorUnit = new FactorUnit(BaseUnitId, PersianBaseUnitName.Value, EnlishBaseUnitName.Value, Symbol, ConversionFactorToBaseUnit);
            return factorUnit;
        }
    }
}
