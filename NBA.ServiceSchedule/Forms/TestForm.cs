using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using NBA.ServiceSchedule.Core.Constants.Enums;
using NBA.ServiceSchedule.Core.Models.DAOs;
using NBA.ServiceSchedule.Core.Models.Entities;
using NBA.ServiceSchedule.DataAccess.Implementation;
using NBA.ServiceSchedule.Forms.Lists;

namespace NBA.ServiceSchedule.Forms
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var clients = (await new ClientListForm().GetClients());
                var services = (await ServiceContainer.ServiceCardService.GetAllAsync()).Data?.ToList() ?? new List<ServiceEntity>();

                var today = DateTime.Today;
                var random = new Random();

                var documents = new List<ServiceOperationDocumentDao>();

                var number = 1;

                foreach (var client in clients)
                {
                    foreach (var service in services)
                    {
                        var document = new ServiceOperationDocumentDao
                        {
                            CreatorUserId = 1,
                            CreateDate = today,
                            Series = "Test",
                            Number = number,
                            Date=today,
                            DocumentNumber = string.Empty,
                            DocumentDate = today,
                            ClientCode = client.ClientCode,
                            ServiceCode = service.Code,
                            ServiceOperationType = ServiceOperationType.Installation,
                            Count = random.Next(1, 5)
                        };

                        documents.Add(document);
                    }

                    number++;
                }

                var result = await RepositoryContainer.ServiceOperationDocumentRepository.SaveDocumentsAsync(documents);
                if (result.IsFailed)
                {
                    MessageBox.Show(result.Exception.Message);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
