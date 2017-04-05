using System;
using Windows.ApplicationModel.Resources;
using Windows.UI.Xaml.Media.Imaging;
using BlameGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.AppContainer;

namespace BlameGame.Tests
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TestDirectoryAssign()
        {
            //test if directories holding the images can be found
            var images = AssetAssigner.ImageDir;

            Assert.IsInstanceOfType(images, typeof(String));
        }

        //[UITestMethod]
        public void TestResourceAssign()
        {
            //test the resource assignment method
            var res = AssetAssigner.ResourceFile;

            Assert.IsInstanceOfType(res, typeof(ResourceLoader));
            //throws exception, dunno how to fix: System.Exception: Resource Contexts may not be created on threads that do not have a CoreWindow. 
        }

        [TestMethod]
        public void TestGuiltyCheck()
        {
            //test the information retrieval methods
            var testSuspect = new SuspectModel(null, null, null, 0, true);
            var result = SuspectInteractions.CheckIfSuspectIsCriminal(testSuspect);

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void TestSuspectAnswers()
        {
            Suspects constructSuspect = new Suspects();
            var suspects = constructSuspect.SuspectList;
            var answer = SuspectInteractions.ShowAnswerToAskedQuestion("btnQ1", suspects[0]);

            Assert.IsInstanceOfType(answer, typeof(string));
            //System.Exception: The application called an interface that was marshalled for a different thread. (Exception from HRESULT: 0x8001010E (RPC_E_WRONG_THREAD)). 
            //If you are using UI objects in test consider using [UITestMethod] attribute instead of [TestMethod] to execute test in UI thread.

        }
    }
}
