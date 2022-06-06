using Framework.Domain;

namespace MeasurementUnitsManagement.DomainModel.MeasurementUnit.Exception
{
    public class EnlishUnitNameIsNullOrEmptyException : DomainException
    {
        public EnlishUnitNameIsNullOrEmptyException() : base("EnlishBaseUnitNameIsNullOrEmpty")
        {
        }
    }
}
