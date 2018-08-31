using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xrm.Client;
using Microsoft.Xrm.Client.Services;
using adesso_XTB_Plugins.DocumentTemplateExport;

using XrmToolBox.Extensibility;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var con = CrmConnection.Parse(@"Url=http://win-n7ssp4uv9uj:5555/StandardOrg; authtype=AD");

            var service = new OrganizationService(con); 

            var myservice = new DocumentTemplateService(service, "", "", "");

            var documents = myservice.QueryDocuments();

            Assert.IsNotNull(documents);



        }
    }
}
