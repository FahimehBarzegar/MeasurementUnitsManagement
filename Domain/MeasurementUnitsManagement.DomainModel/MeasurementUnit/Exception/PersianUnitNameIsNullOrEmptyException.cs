using Framework.Domain;

namespace MeasurementUnitsManagement.DomainModel.MeasurementUnit.Exception
{
    public class PersianUnitNameIsNullOrEmptyException : DomainException
    {
        public PersianUnitNameIsNullOrEmptyException() : base("PersianBaseUnitNameIsNullOrEmpty")
        {
        }
    }
}
