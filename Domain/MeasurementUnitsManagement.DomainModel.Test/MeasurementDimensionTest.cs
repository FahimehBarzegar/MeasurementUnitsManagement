using MeasurementUnitsManagement.DomainModel.MeasurementDimension.Builder;
using MeasurementUnitsManagement.DomainModel.MeasurementDimension.Exception;
using NUnit.Framework;

namespace MeasurementUnitsManagement.DomainModel.Test
{
    public class MeasurementDimensionTest 
    {
        private int id = 1;
        private string englishTitle = "Length";
        private string persianTitle = "طول";
        private MeasurementDimension.MeasurementDimension measurementDimension; 

        [SetUp]
        public void Setup()
        {
            measurementDimension = new MeasurementDimensionBuilder(id, englishTitle, persianTitle).Build();
        }

        [Test]
        public void Set_English_Name_To_Null_ThrowException()
        {
            Assert.That(() => new MeasurementDimension.MeasurementDimension(null, "طول"), Throws.TypeOf<EnglishTitleIsNullOrEmptyException>());
        }

        [Test]
        public void Set_English_Name_To_Empty_ThrowException()
        {
            Assert.That(() => new MeasurementDimension.MeasurementDimension("", "طول"), Throws.TypeOf<EnglishTitleIsNullOrEmptyException>());
        }

        [Test]
        public void Set_Farsi_Name_To_Null_ThrowException()
        {
            Assert.That(() => new MeasurementDimension.MeasurementDimension("Length", null), Throws.TypeOf<PersianTitleIsNullOrEmptyException>());
        }

        [Test]
        public void Set_Farsi_Name_To_Empty_ThrowException()
        {
            Assert.That(() => new MeasurementDimension.MeasurementDimension("Length", ""), Throws.TypeOf<PersianTitleIsNullOrEmptyException>());
        }
    }
}
