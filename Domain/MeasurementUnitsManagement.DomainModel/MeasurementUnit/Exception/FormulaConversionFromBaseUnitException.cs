using Framework.Domain;

namespace MeasurementUnitsManagement.DomainModel.MeasurementUnit.Exception
{
    public class FormulaConversionFromBaseUnitException : DomainException
    {
        public FormulaConversionFromBaseUnitException() : base("Formula Conversion From Base Unit Is not Correct")
        {
        }
    }
}
