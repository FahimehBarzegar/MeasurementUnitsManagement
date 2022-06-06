using Framework.Domain;

namespace MeasurementUnitsManagement.DomainModel.MeasurementUnit.Exception
{
    public class IncorrectTheNumberOfOpenAndCloseParenthesesException : DomainException
    {
        public IncorrectTheNumberOfOpenAndCloseParenthesesException() : base("The number of open and closed parentheses is incorrect")
        {
        }
    }
}
