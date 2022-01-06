using ManagmentAppTestOne.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManagmentAppTestOne.Server.Models
{
    public interface IPredictionModel
    {
        public Task<float> GetRelevantAvg(Guid companyId);

        /*public Task<float> GetEmployeeAvg(Guid companyId);*/
    }
}
