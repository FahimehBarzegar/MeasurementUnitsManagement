using System.Threading.Tasks;

namespace MeasurementUnitsManagement.DomainModel.MeasurementDimension.Services
{
    public interface ICommandMeasurementDimensionRepository
    {
        Task<MeasurementDimension> FindAsync(int id);
    }
}
