using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using VCQRU.Models;
using VCQRU.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace VCQRU.Services
{
    public class CodeService : ICodeService
    {
        private readonly ApplicationDbContext _context;
        private readonly Random _random;

        public CodeService(ApplicationDbContext context)
        {
            _context = context;
            _random = new Random();
        }

        public async Task<List<UniqueCode>> GenerateUniqueCodesAsync(int count, int batchNo, int? companyId)
        {
            var uniqueCodes = new List<UniqueCode>();

            while (uniqueCodes.Count < count)
            {
                int fiveDigitNumber = _random.Next(10000, 99999);
                long eightDigitNumber = _random.Next(10000000, 99999999);
                string code1 = fiveDigitNumber.ToString();
                string code2 = eightDigitNumber.ToString();

                bool isUnique = !await _context.UniqueCodes.AnyAsync(c => c.Code1 == code1 && c.Code2 == code2);
                if (isUnique)
                {
                    var uniqueCode = new UniqueCode
                    {
                        Code1 = code1,
                        Code2 = code2,
                        GeneratedDate = DateTime.UtcNow,
                        BatchNumber = batchNo,
                        CompanyId = companyId ?? 0 // Set default if companyId is null
                    };
                    uniqueCodes.Add(uniqueCode);
                    _context.UniqueCodes.Add(uniqueCode);
                }
            }

            await _context.SaveChangesAsync();
            return uniqueCodes;
        }

        public async Task<List<UniqueCode>> GetGeneratedCodesAsync(int batchNo)
        {
            return await _context.UniqueCodes
                .Where(c => c.BatchNumber == batchNo)
                .OrderBy(c => c.GeneratedDate)
                .ToListAsync();
        }
    }
}
