using Framework.Domain;

namespace MeasurementUnitsManagement.DomainModel.MeasurementUnit.Exception
{
    public class MeasurementUnitAlreadyAddedException : DomainException
    {
        public MeasurementUnitAlreadyAddedException() : base("A measurement unit has already been added to it")
        {
        }
    }
}
