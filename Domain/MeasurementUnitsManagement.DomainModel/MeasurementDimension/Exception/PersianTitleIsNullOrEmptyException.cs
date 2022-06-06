using Framework.Domain;

namespace MeasurementUnitsManagement.DomainModel.MeasurementDimension.Exception
{
    public class PersianTitleIsNullOrEmptyException : DomainException
    {
        public PersianTitleIsNullOrEmptyException() : base("PersianTitleIsNullOrEmpty")
        {
        }
    }
}
