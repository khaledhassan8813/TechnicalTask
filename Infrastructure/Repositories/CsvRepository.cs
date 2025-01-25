using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using Domain.Models;
using Infrastructure.Enums;

namespace Infrastructure.Repositories
{
    public class CsvRepository : ICsvRepository
    {
        public async Task<List<UnifiedDataModel>> GetCsvDataAsync()
        {
            try
            {

                var path = Path.Combine(Directory.GetCurrentDirectory(), "Resources", "TechnicalTaskData.csv");
                using var reader = new StreamReader(path);
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

                var records = new List<UnifiedDataModel>();
                await foreach (var record in csv.GetRecordsAsync<MyCsvModel>())
                {
                    records.Add(new UnifiedDataModel
                    {
                        FirstName = record.FirstName,
                        LastName = record.LastName,
                        TelephoneCode = record.CountryCode.ToString(),
                        Address = record.FullAddress,
                        TelephoneNumber = record.Number.ToString(),
                        Country = GetCountryName(record.CountryCode),
                    });
                }

                return records;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #region privte
        private string GetCountryName(int countryCode)
        {
            // Map country code to country name
            switch (countryCode)
            {
                case (int)CountryCode.Egypt:
                    return "Egypt";
                case (int)CountryCode.Morocco:
                    return "Morocco";
                case (int)CountryCode.SaudiArabia:
                    return "Saudi Arabia";
                case (int)CountryCode.Palestine:
                    return "Palestine";
                case (int)CountryCode.Lebanon:
                    return "Lebanon";
                default:
                    return "Unknown";
            }
        }
        #endregion
    }

}
