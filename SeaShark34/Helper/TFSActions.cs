using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.TestManagement.Client;
using System.Net;
using System.Data;
using System.Xml;
using System.Xml.Serialization;

namespace SimpleCSharpSelenium.Helper
{
    static class TFSActions
    {
        /// <summary>
        /// Get the parameters of the test case
        /// </summary>
        /// <param name="testCaseId">Test case id (work item id#) displayed into TFS</param>
        /// <returns>Returns the test case parameters in datatable format. If there are no parameters then it will return null</returns>
        public static DataTable GetTestCaseParameters(int testCaseId)
        {
            ITestManagementService TestMgrService;
            ITestCase TestCase = null;
            DataTable TestCaseParameters = null;

            NetworkCredential netCred = new NetworkCredential(
              Constants.TFS_USER_NAME,
              Constants.TFS_USER_PASSWORD);
            BasicAuthCredential basicCred = new BasicAuthCredential(netCred);
            TfsClientCredentials tfsCred = new TfsClientCredentials(basicCred);
            tfsCred.AllowInteractive = false;

            TfsTeamProjectCollection teamProjectCollection = new TfsTeamProjectCollection(
                new Uri(Constants.TFS_URL),
                tfsCred);

            teamProjectCollection.Authenticate();

            TestMgrService = teamProjectCollection.GetService<ITestManagementService>();
            TestCase = TestMgrService.GetTeamProject(Constants.TFS_PROJECT_NAME).TestCases.Find(testCaseId);

            if (TestCase != null)
            {
                if (TestCase.Data.Tables.Count > 0)
                {
                    TestCaseParameters = TestCase.Data.Tables[0];
                }
            }

            return TestCaseParameters;
        }
    }
}
