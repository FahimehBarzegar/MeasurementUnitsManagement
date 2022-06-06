using Framework.Domain;

namespace MeasurementUnitsManagement.DomainModel.MeasurementUnit.Exception
{
    public class MeasurementDimensionNotDefineException : DomainException
    {
        public MeasurementDimensionNotDefineException() : base("MeasurementDimensionNotDefine")
        {
        }
    }
}
