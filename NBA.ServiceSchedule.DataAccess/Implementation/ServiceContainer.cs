using NBA.ServiceSchedule.Core.Abstracts.Services;
using NBA.ServiceSchedule.DataAccess.Implementation.Services;

namespace NBA.ServiceSchedule.DataAccess.Implementation
{
    public static class ServiceContainer
    {
        public static readonly IServiceCardService ServiceCardService = new ServiceCardService();
        public static readonly IServiceOperationDocumentService ServiceOperationDocumentService = new ServiceOperationDocumentService();
        public static readonly IUserService UserService = new UserService();
        public static readonly IClientPaymentNoteService ClientPaymentNoteService = new ClientPaymentNoteService();
    }
}
