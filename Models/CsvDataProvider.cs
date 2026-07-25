using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;

namespace BirthdayReminder.Models
{
    public class CsvDataProvider : IDataProvider
    {
        private string _csvPath;
        private CsvConfiguration _config;

        public CsvDataProvider()
        {
            var appRoot = Directory.GetCurrentDirectory();
            _csvPath = Path.Combine(appRoot, "data.csv");
            _config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ",",
                HasHeaderRecord = true,
                MemberTypes = MemberTypes.Fields
            };
        }

        public BirthdayRecord[] Load()
        {
            if (File.Exists(_csvPath))
            {
                using var reader = new StreamReader(_csvPath);
                using var csvReader = new CsvReader(reader, _config);
                return csvReader.GetRecords<BirthdayRecord>().ToArray();
            }

            return [];
        }

        public void Save(BirthdayRecord[] records)
        {
            using var writer = new StreamWriter(_csvPath);
            using var csv = new CsvWriter(writer, _config);
            csv.WriteRecords(records);
        }
    }
}