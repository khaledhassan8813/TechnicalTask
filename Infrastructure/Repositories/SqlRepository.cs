using Domain.Context;
using Domain.IRepositories;
using Domain.Models;
using Microsoft.Data.SqlClient.Server;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using ZstdSharp.Unsafe;
using Infrastructure.Enums;

namespace Infrastructure.Repositories
{
    public class SqlRepository : ISqlRepository
    {
        private readonly AppDbContext _context;

        public SqlRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<UnifiedDataModel>> GetAllAsync()
        {
            // Retrieve all PersonDetail records from the database
            var personDetails = await _context.Person_Details.ToListAsync();

            // Map PersonDetail to UnifiedDataModel
            var unifiedData = personDetails.Select(person => new UnifiedDataModel
            {
                FirstName = GetFirstName(person.name),
                LastName = GetLastName(person.name),
                Country = GetCountryName(int.Parse(GetCountryCode(person.telephoneNumber))),
                TelephoneNumber = GetPhoneNumber(person.telephoneNumber),
                Address = person.address,
                TelephoneCode = GetCountryCode(person.telephoneNumber)
            }).ToList();

            return unifiedData;
        }

        // Get a person by ID
        public async Task<PersonDetail> GetByIdAsync(int id)
        {
            return await _context.Person_Details.FindAsync(id);
        }

        #region Privte
        private string GetFirstName(string fullName)
        {
            return fullName?.Split(' ').FirstOrDefault() ?? string.Empty;
        }

        private string GetLastName(string fullName)
        {
            var names = fullName?.Split(' ');
            return names != null && names.Length > 1 ? names.Last() : string.Empty;
        }

        private string GetCountryCode(string telephoneNumber)
        {
            if (string.IsNullOrEmpty(telephoneNumber)) return "";

            var parts = telephoneNumber.Split('-'); // Split by the dash
            return parts.Length > 0 ? parts[0] : "";
        }

        private string GetPhoneNumber(string telephoneNumber)
        {
            if (string.IsNullOrEmpty(telephoneNumber)) return "";

            var parts = telephoneNumber.Split('-'); // Split by the dash
            return parts.Length > 1  ? parts[1] : "";
        }

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
