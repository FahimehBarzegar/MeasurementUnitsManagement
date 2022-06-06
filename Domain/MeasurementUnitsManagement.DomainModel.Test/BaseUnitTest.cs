using MeasurementUnitsManagement.DomainModel.MeasurementDimension.Builder;
using MeasurementUnitsManagement.DomainModel.MeasurementUnit;
using MeasurementUnitsManagement.DomainModel.MeasurementUnit.Builder;
using MeasurementUnitsManagement.DomainModel.MeasurementUnit.Exception;
using MeasurementUnitsManagement.DomainModel.MeasurementUnit.Service;
using NUnit.Framework;

namespace MeasurementUnitsManagement.DomainModel.Test
{
	public class BaseUnitTest : IMeasurementUnitAlreadyAddedChecker
	{
		private MeasurementDimension.MeasurementDimension measurementDimension;
		private int id = 1;
		private string englishTitle = "Length";
		private string persianTitle = "طول";

		[SetUp]
		public void Setup()
		{
			measurementDimension = new MeasurementDimensionBuilder(id, englishTitle, persianTitle).Build();
		}

		[Test]
		public void Set_English_Name_To_Null_ThrowException()
		{
			Assert.That(() => new BaseUnitBuiler(this, 1, "متر", null, "m", measurementDimension.Id).Build(),
				Throws.TypeOf<EnlishUnitNameIsNullOrEmptyException>());
		}		

		[Test]
		public void Set_English_Name_To_Empty_ThrowException()
		{
			Assert.That(() => new BaseUnitBuiler(this, 1, "متر", "", "m", measurementDimension.Id).Build(),
				Throws.TypeOf<EnlishUnitNameIsNullOrEmptyException>());
		}

		[Test]
		public void Set_Farsi_Name_To_Null_ThrowException()
		{
			Assert.That(() => new BaseUnitBuiler(this, 1, null, "Meter", "m", measurementDimension.Id).Build(),
				Throws.TypeOf<PersianUnitNameIsNullOrEmptyException>());
		}

		[Test]
		public void Set_Farsi_Name_To_Empty_ThrowException()
		{
			Assert.That(() => new BaseUnitBuiler(this, 0, "", "Meter", "m", measurementDimension.Id).Build(),
				Throws.TypeOf<PersianUnitNameIsNullOrEmptyException>());
		}

		[Test]
		public void Add_Another_BaseUnit_To_MeasurementDimension_ThrowException()
		{
			var baseUnitMeter = new BaseUnitBuiler(this, 1, "متر", "Meter", "m", measurementDimension.Id);
			Assert.Throws<MeasurementUnitAlreadyAddedException>(() => baseUnitMeter.Build());
		}

		[Test]
		public void Set_Symbol_To_null_ThrowException()
		{
			Assert.That(() => new BaseUnitBuiler(this, 1, "متر", "Meter", null, measurementDimension.Id).Build(),
				Throws.TypeOf<SymbolIsNullOrEmptyException>());
		}

		[Test]
		public void Set_Symbol_To_Empty_ThrowException()
		{
			Assert.That(() => new BaseUnitBuiler(this, 1, "متر", "Meter", "", measurementDimension.Id).Build(),
				Throws.TypeOf<SymbolIsNullOrEmptyException>());
		}
		public bool IsAddedAlreadyBaseUnit(int measurementDimensionId, BaseUnit BaseUnits)
		{
			return true;
		}
	}
}
