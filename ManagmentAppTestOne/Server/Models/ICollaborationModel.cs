using ManagmentAppTestOne.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManagmentAppTestOne.Server.Models
{
    public interface ICollaborationModel
    {
        public Task<IEnumerable<CollaborationEntity>> GetCollaborations();

        public Task<CollaborationEntity> GetSingleCollaboration(Guid collaborationId);

        public Task<IEnumerable<UserEntity>> GetCollaborationById(Guid projectId);

        public Task<CollaborationEntity> Post(CollaborationEntity collaboration);

        public Task<CollaborationEntity> Put(CollaborationEntity collaboration);

        public Task<CollaborationEntity> Delete(Guid collaborationId);
    }
}
