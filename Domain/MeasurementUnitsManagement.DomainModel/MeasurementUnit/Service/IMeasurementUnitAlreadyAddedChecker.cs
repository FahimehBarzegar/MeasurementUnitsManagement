using Framework.Domain;

namespace MeasurementUnitsManagement.DomainModel.MeasurementUnit.Service
{
    public interface IMeasurementUnitAlreadyAddedChecker : IDomainService
    {
        bool IsAddedAlreadyBaseUnit(int measurementDimensionId, BaseUnit BaseUnits);
    }
}
