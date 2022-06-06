using Framework.Domain;

namespace MeasurementUnitsManagement.DomainModel.MeasurementUnit.Exception
{
    public class BaseUnitIdNotDefineException : DomainException
    {
        public BaseUnitIdNotDefineException() : base("Base Unit Not Define")
        {
        }
    }
}
