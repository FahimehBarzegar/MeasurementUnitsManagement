using Framework.Domain;

namespace MeasurementUnitsManagement.DomainModel.MeasurementUnit.Service
{
    public interface IConvertUnits : IDomainService
    {
        bool IsSameDimension(Unit leftunit, Unit rightUnit);
        void ConvertFactorUnitToBaseUnit(decimal value, int factorUnitId, int baseUnitId);
        void ConvertToBaseUnitToFactorUnit(decimal value, int baseUnitId, int factorUnitId);
        void ConvertTBaseUnitToFormulateUnit(decimal value, int baseUnitId, int formulateUnitId);
        void ConvertTFormulateUnitToBaseUnit(decimal value, int formulateUnitId, int baseUnitId);
    }
}
