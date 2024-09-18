using System.Collections.Generic;
using System.Threading.Tasks;
using VCQRU.Models;

namespace VCQRU.Services
{
    public interface ICodeService
    {
        Task<List<UniqueCode>> GenerateUniqueCodesAsync(int count, int batchNo, int? companyId);
        Task<List<UniqueCode>> GetGeneratedCodesAsync(int batchNo); // Add this method
    }
}
