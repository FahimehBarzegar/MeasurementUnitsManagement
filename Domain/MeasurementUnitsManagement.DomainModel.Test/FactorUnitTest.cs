using MeasurementUnitsManagement.DomainModel.MeasurementDimension.Builder;
using MeasurementUnitsManagement.DomainModel.MeasurementUnit;
using MeasurementUnitsManagement.DomainModel.MeasurementUnit.Builder;
using MeasurementUnitsManagement.DomainModel.MeasurementUnit.Exception;
using MeasurementUnitsManagement.DomainModel.MeasurementUnit.Service;
using NUnit.Framework;

namespace MeasurementUnitsManagement.DomainModel.Test
{
    public class FactorUnitTest : IMeasurementUnitAlreadyAddedChecker
    {
        private MeasurementDimension.MeasurementDimension measurementDimension;
        private BaseUnit baseUnitMeter;
        private int id = 1;
        private string englishTitle = "Length";
        private string persianTitle = "طول";


        [SetUp]
        public void Setup()
        {
            measurementDimension = new MeasurementDimensionBuilder(id, englishTitle, persianTitle).Build();
			baseUnitMeter = new BaseUnitBuiler(this, 1, "متر", "Meter", "m", measurementDimension.Id).Build();		 
        }

        [Test]
        public void Set_English_Name_To_Null_ThrowException()
        {
            Assert.That(() => new FactorUnit(baseUnitMeter.Id, "سانتی متر", null, "m", 0.01f), Throws.TypeOf<EnlishUnitNameIsNullOrEmptyException>());
        }

        [Test]
        public void Set_English_Name_To_Empty_ThrowException()
        {
            Assert.That(() => new FactorUnit(baseUnitMeter.Id, "سانتی متر", "", "m", 0.01f), Throws.TypeOf<EnlishUnitNameIsNullOrEmptyException>());
        }

        [Test]
        public void Set_Farsi_Name_To_Null_ThrowException()
        {
            Assert.That(() => new FactorUnit(baseUnitMeter.Id, null, "Centimeter", "m", 0.01f), Throws.TypeOf<PersianUnitNameIsNullOrEmptyException>());
        }

        [Test]
        public void Set_Farsi_Name_To_Empty_ThrowException()
        {
            Assert.That(() => new FactorUnit(baseUnitMeter.Id, "", "Centimeter", "m", 0.01f), Throws.TypeOf<PersianUnitNameIsNullOrEmptyException>());
        }

        [Test]
        public void Set_Symbol_To_null_ThrowException()
        {
            Assert.That(() => new FactorUnit(baseUnitMeter.Id, "سانتی متر", "Centimeter", null, 0.01f), Throws.TypeOf<SymbolIsNullOrEmptyException>());
        }

        [Test]
        public void Set_Symbol_To_Empty_ThrowException()
        {
            Assert.That(() => new FactorUnit(baseUnitMeter.Id, "سانتی متر", "Centimeter", "", 0.01f), Throws.TypeOf<SymbolIsNullOrEmptyException>());
        }

        public bool IsAddedAlreadyBaseUnit(int measurementDimensionId, BaseUnit BaseUnits)
        {
            return false;
        }
    }
}
