using System.Threading.Tasks;

namespace MeasurementUnitsManagement.DomainModel.MeasurementDimension.Services
{
    public interface IQueryMeasurementDimensionRepository
    {
        Task<MeasurementDimension> FindAsync(int id);
    }
}
