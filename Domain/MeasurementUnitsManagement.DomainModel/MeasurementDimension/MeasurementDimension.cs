using DomainKit.ValueObjects;
using MeasurementUnitsManagement.DomainModel.MeasurementDimension.Exception;
using MeasurementUnitsManagement.DomainModel.MeasurementUnit;

namespace MeasurementUnitsManagement.DomainModel.MeasurementDimension
{
	public class MeasurementDimension
	{
		private MeasurementDimension()
		{
		}
		public int Id { get; private set; }
		public Title EnglishTitle { get; private set; }
		public Title PersianTitle { get; private set; }
		public BaseUnit BaseUnit { get; private set; }

		public MeasurementDimension(string englishTitle, string persianTitle)
		{
			EnglishTitle = new Title(englishTitle);
			PersianTitle = new Title(persianTitle);

			ValidateInvariants();
		}

		public void UpdateMeasurementDimension(string englishTitle, string persianTitle)
		{
			EnglishTitle = new Title(englishTitle);
			PersianTitle = new Title(persianTitle);

			ValidateInvariants();
		}

		private void ValidateInvariants()
		{
			if (string.IsNullOrEmpty(EnglishTitle.Value))
				throw new EnglishTitleIsNullOrEmptyException();

			if (string.IsNullOrEmpty(PersianTitle.Value))
				throw new PersianTitleIsNullOrEmptyException();
		}		 
	}
}
