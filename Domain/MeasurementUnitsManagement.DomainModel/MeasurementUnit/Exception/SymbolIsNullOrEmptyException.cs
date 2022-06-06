using Framework.Domain;

namespace MeasurementUnitsManagement.DomainModel.MeasurementUnit.Exception
{
    public class SymbolIsNullOrEmptyException : DomainException
    {
        public SymbolIsNullOrEmptyException() : base("SymbolIsNullOrEmpty")
        {
        }
    }
}
