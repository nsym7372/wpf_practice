using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrismSampleTest.Tests
{
    using PrismSample.ViewModels;
    using Prism.Services.Dialogs;
    using PrismSample.Services;
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var dialogmoq = new Moq.Mock<IDialogService>();
            var messagemoq = new Moq.Mock<IMessageService>();
            var vm = new ViewCViewModel(dialogmoq.Object, messagemoq.Object);
            vm.CloseButton.Execute();
        }
    }
}
