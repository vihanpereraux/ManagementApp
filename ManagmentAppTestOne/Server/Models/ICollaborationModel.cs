using ManagmentAppTestOne.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManagmentAppTestOne.Server.Models
{
    public interface ICollaborationModel
    {
        public Task<IEnumerable<CollaborationEntity>> GetCollaborations();

        public Task<CollaborationEntity> GetCollaborationById(Guid collaborationId);

        public Task<CollaborationEntity> Post(CollaborationEntity collaboration);

        public Task<CollaborationEntity> Put(CollaborationEntity collaboration);

        public Task<CollaborationEntity> Delete(Guid collaborationId);
    }
}
