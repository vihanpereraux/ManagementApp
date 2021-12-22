using ManagmentAppTestOne.Server.Data;
using ManagmentAppTestOne.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManagmentAppTestOne.Server.Models
{
    public class CollaborationModel : ICollaborationModel
    {
        public readonly ApplicationDbContext _applicationDbContext;
        public readonly ILogger<CollaborationModel> _logger;

        public CollaborationModel(ILogger<CollaborationModel> logger, ApplicationDbContext applicationDbContext)
        {
            _logger = logger;
            _applicationDbContext = applicationDbContext;
        }

        public async Task<IEnumerable<CollaborationEntity>> GetCollaborations()
        {
            return await _applicationDbContext.Collaborations.ToListAsync();
        }

        public async Task<CollaborationEntity> GetCollaborationById(Guid collaborationId)
        {
            return await _applicationDbContext.Collaborations.FirstOrDefaultAsync(x => x.CollaborationId == collaborationId);
        }

        public async Task<CollaborationEntity> Post(CollaborationEntity collaboration)
        {
            var result = _applicationDbContext.Collaborations.Add(collaboration);
            await _applicationDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<CollaborationEntity> Put(CollaborationEntity collaboration)
        {
            _applicationDbContext.Entry(collaboration).State = EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();
            return collaboration;
        }

        public async Task<CollaborationEntity> Delete(Guid collaborationId)
        {
            var result = await GetCollaborationById(collaborationId);
            if (result != null)
            {
                _applicationDbContext.Collaborations.Remove(result);
                await _applicationDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
