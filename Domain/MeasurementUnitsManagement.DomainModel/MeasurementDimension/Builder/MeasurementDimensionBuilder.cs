using System.Reflection;

namespace MeasurementUnitsManagement.DomainModel.MeasurementDimension.Builder
{
	public class MeasurementDimensionBuilder
	{
		public int Id { get; set; }
		public string EnglishTitle { get; set; }
		public string PersianTitle { get; set; }

		public MeasurementDimensionBuilder(int id, string englishTitle, string persianTitle)
		{
			Id = id;
			EnglishTitle = englishTitle;
			PersianTitle = persianTitle;
		}
		public MeasurementDimension Build()
		{
			var measurementDimension = new MeasurementDimension(EnglishTitle, PersianTitle);
			var field = typeof(MeasurementDimension).GetField("<Id>k__BackingField", BindingFlags.Instance | BindingFlags.NonPublic);
			field.SetValue(measurementDimension, 1);
			return measurementDimension;
		}
	}
}
