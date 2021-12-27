using ManagmentAppTestOne.Server.Data;
using ManagmentAppTestOne.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;  

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

        /*Newly created*/
        public async Task<CollaborationEntity> GetSingleCollaboration(Guid collaborationId)
        {
            return await _applicationDbContext.Collaborations.FirstOrDefaultAsync(x => x.CollaborationId == collaborationId);
        }

        public async Task<IEnumerable<UserEntity>> GetCollaborationById(Guid projectId)
        {
            /*return await _applicationDbContext.Collaborations.FirstOrDefaultAsync(x => x.ProjectId == projectId);*/
            var users = await (from user in _applicationDbContext.Users
                          join collaboration in _applicationDbContext.Collaborations
                          on user.UserId equals collaboration.UserId
                          where collaboration.ProjectId == projectId
                          select new UserEntity 
                          {
                            UserId = user.UserId,
                            UserName = user.UserName,
                            UserOccupation = user.UserOccupation,
                            UserCapacity = user.UserCapacity,
                            UserEmail = user.UserEmail,
                            UserPassword = user.UserPassword,
                          }).ToListAsync();
            return users;
        }

        public async Task<CollaborationEntity> Post(CollaborationEntity collaboration)
        {
            var chedCollab = await GetCollaborations();
            string userSystem = "not existing";

            foreach(var collab in chedCollab) 
            {
                if(collaboration.UserId == collab.UserId && collaboration.ProjectId == collab.ProjectId) 
                {
                    userSystem = "existing";
                }
            }

            if (userSystem != "existing")
            {
                var result = _applicationDbContext.Collaborations.Add(collaboration);
                await _applicationDbContext.SaveChangesAsync();
                return result.Entity;
            }
            else 
            {
                return null; 
            }
        }

        public async Task<CollaborationEntity> Put(CollaborationEntity collaboration)
        {
            _applicationDbContext.Entry(collaboration).State = EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();
            return collaboration;
        }

        public async Task<CollaborationEntity> Delete(Guid collaborationId)
        {
            var result = await GetSingleCollaboration(collaborationId);
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
