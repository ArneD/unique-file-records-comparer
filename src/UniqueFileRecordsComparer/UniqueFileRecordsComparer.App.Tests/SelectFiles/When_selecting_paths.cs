using System.Collections.Generic;
using System.IO.Abstractions;
using System.Linq;
using System.Windows.Forms;
using Moq;
using UniqueFileRecordsComparer.App.MessageHandlers;
using UniqueFileRecordsComparer.App.SelectFiles;
using UniqueFileRecordsComparer.Core.Readers;
using Xunit;

namespace UniqueFileRecordsComparer.App.Tests.SelectFiles
{
    public class When_selecting_paths
    {
        private string _expectedFilePath = "filePath";
        private readonly Dictionary<int, string> _expectedTabs = new Dictionary<int, string>
            {
                {0, "test" }
            };

        private readonly Mock<ISelectFilesView> _viewMock = new Mock<ISelectFilesView>();
        private readonly SelectFilesPresenter _presenter;

        public When_selecting_paths()
        {
            var openFileMessageMock = new Mock<IOpenFileMessageHandler>();
            openFileMessageMock
                .Setup(handler => handler.Handle(It.IsAny<OpenFileDialog>()))
                .Callback<OpenFileDialog>(x =>
                {
                    x.FileName = _expectedFilePath;
                })
                .Returns(DialogResult.OK);
                

            var fileReaderMock = new Mock<IFileReader>();
            fileReaderMock.Setup(reader => reader.GetTabNamesByIndex())
                .Returns(_expectedTabs);

            var fileReaderFactoryMock = new Mock<IFileReaderFactory>();
            fileReaderFactoryMock.Setup(factory => factory.CreateFromFileName(It.IsAny<FileInfoBase>())).Returns(fileReaderMock.Object);

            _presenter = new SelectFilesPresenter(_viewMock.Object, openFileMessageMock.Object, fileReaderFactoryMock.Object);
        }

        [Fact]
        public void Given_source_path_Then_selected_path_and_tabs_are_set_on_the_view()
        {
            _presenter.SelectSourcePath();

            _viewMock.VerifySet(x => x.SourceFilePath = _expectedFilePath);
            _viewMock.VerifySet(x => x.SourceFileTabs = _expectedTabs.Values.ToList());
        }

        [Fact]
        public void Given_target_path_Then_selected_path_and_tabs_are_set_on_the_view()
        {
            _presenter.SelectTargetPath();

            _viewMock.VerifySet(x => x.TargetFilePath = _expectedFilePath);
            _viewMock.VerifySet(x => x.TargetFileTabs = _expectedTabs.Values.ToList());
        }
    }
}
