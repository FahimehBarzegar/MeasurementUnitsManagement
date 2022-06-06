using Framework.Domain;

namespace MeasurementUnitsManagement.DomainModel.MeasurementDimension.Exception
{
    public class EnglishTitleIsNullOrEmptyException : DomainException
    {
        public EnglishTitleIsNullOrEmptyException() : base("EnglishTitleIsNullOrEmpty")
        {
        }
    }
}
