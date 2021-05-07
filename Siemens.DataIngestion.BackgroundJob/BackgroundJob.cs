using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Siemens.DataIngestion.BackgroundJob.Helper;
using Siemens.Domain.Service.DTO;
using Siemens.Domain.Service.Interface.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Siemens.DataIngestion.BackgroundJob
{
    public class BackgroundJob : BackgroundService
    {
        private readonly ITestDataIngestionService _testDataIngestionService;
        private readonly ILogger<BackgroundJob> _logger;

        public readonly string CustomertDataPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"TestData\Customer.json");
        public readonly string MetalDataPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"TestData\Metal.json");
        public BackgroundJob(ITestDataIngestionService testDataIngestionService, ILogger<BackgroundJob> logger)
        {
            _testDataIngestionService = testDataIngestionService;
            _logger = logger;
        }

        /// <summary>
        /// Ingests the test data by overriding the abstract method from BackgroundService
        /// </summary>
        /// <param name="stoppingToken">will be called from Kestrel</param>
        /// <returns></returns>
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("setting up prerequisite data");
            await _testDataIngestionService.InserCustomerDataAsync(Deserialize<List<CustomerDto>>.ToModel(CustomertDataPath));
            await _testDataIngestionService.InsertMetalDataAsync(Deserialize<List<MetalDto>>.ToModel(MetalDataPath));
        }
    }
}
