using Framework.Domain;

namespace MeasurementUnitsManagement.DomainModel.MeasurementUnit.Exception
{
    public class InvalidCharacterInFormulaConversionToBaseUnitException : DomainException
    {
        //public InvalidCharacterInFormulaConversionToBaseUnitException() : base(@"The entered formula must not contain Invalid characters")
        //{
        //}
        //public InvalidCharacterInFormulaConversionToBaseUnitException() : base("The entered formula must not contain invalid characters")
        //{

        //}
        public InvalidCharacterInFormulaConversionToBaseUnitException(char[] charlist) : base(@"The entered formula must not contain {{charlist.ToString()}} characters")
        {
        }
    }
}
