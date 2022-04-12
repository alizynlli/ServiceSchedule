using NBA.ServiceSchedule.Core.Abstracts.Repositories;
using NBA.ServiceSchedule.DataAccess.Implementation.Repositories;

namespace NBA.ServiceSchedule.DataAccess.Implementation
{
    public static class RepositoryContainer
    {
        public static readonly IServiceRepository ServiceRepository = new ServiceRepository();
        public static readonly IServiceOperationDocumentRepository ServiceOperationDocumentRepository = new ServiceOperationDocumentRepository();
        public static readonly ClientAccountOperationRepository ClientAccountOperationRepository = new ClientAccountOperationRepository();
        public static readonly ClientRepository ClientRepository = new ClientRepository();
        public static readonly IUserRepository UserRepository = new UserRepository();
        public static readonly PermissionRepository PermissionRepository = new PermissionRepository();
        public static readonly IClientPaymentNoteRepository ClientPaymentNoteRepository = new ClientPaymentNoteRepository();
    }
}
