using Application.Interfaces;
using Domain.Interfaces;
using Domain.IRepositories;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class DataService : IDataService
    {
        private readonly ICsvRepository _csvRepository;
        private readonly ISqlRepository _sqlRepository;

        public DataService(ICsvRepository csvRepository, ISqlRepository sqlRepository)
        {
            _csvRepository = csvRepository;
            _sqlRepository = sqlRepository;
        }
        public async Task<List<UnifiedDataModel>> GetUnifiedDataAsync(string name = null, string phone = null, string country = null)
        {
            //// Retrieve data from both repositories concurrently
            //var csvTask = _csvRepository.GetCsvDataAsync(); // Task for CSV data
            //var sqlTask = _sqlRepository.GetAllAsync();     // Task for SQL data

            //// Await both tasks to complete
            //await Task.WhenAll(csvTask, sqlTask);

            //// Combine the results from both tasks and apply filters
            //var unifiedData = csvTask.Result.Concat(sqlTask.Result)
            //    .Where(person => FilterByCriteria(person, name, phone, country))
            //    .ToList();

            //return unifiedData;


            // Retrieve data from both repositories concurrently
            var csvTask = _csvRepository.GetCsvDataAsync(); // Task for CSV data

            // Await both tasks to complete
            await Task.WhenAll(csvTask);

            // Combine the results from both tasks and apply filters
            var unifiedData = csvTask.Result
                .Where(person => FilterByCriteria(person, name, phone, country))
                .ToList();

            return unifiedData;
        }

        #region privte
        private bool FilterByCriteria(UnifiedDataModel person, string name, string phone, string country)
        {
            // Only apply filters if they are provided (non-null and non-empty)
            bool isValid = true;

            // Filter by name if 'name' is provided
            if (!string.IsNullOrEmpty(name))
            {
                isValid &= person.FirstName.Contains(name, StringComparison.OrdinalIgnoreCase) ||
                           person.LastName.Contains(name, StringComparison.OrdinalIgnoreCase);
            }

            // Filter by phone if 'phone' is provided
            if (!string.IsNullOrEmpty(phone))
            {
                isValid &= person.TelephoneNumber.Contains(phone);
            }

            // Filter by country if 'country' is provided
            if (!string.IsNullOrEmpty(country))
            {
                isValid &= person.Country.Contains(country, StringComparison.OrdinalIgnoreCase);
            }

            return isValid;
        }
        #endregion
    }
}
