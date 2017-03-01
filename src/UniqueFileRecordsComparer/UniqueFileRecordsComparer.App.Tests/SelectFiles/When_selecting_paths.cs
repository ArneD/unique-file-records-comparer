using System.Collections.Generic;
using System.IO.Abstractions;
using FluentAssertions;
using Moq;
using UniqueFileRecordsComparer.App.Messages;
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

        private readonly SelectFileViewStub _view = new SelectFileViewStub();
        private readonly SelectFilesPresenter _presenter;

        public When_selecting_paths()
        {
            var openFileMessageMock = new Mock<IOpenFileMessageHandler>();
            openFileMessageMock.Setup(handler => handler.Handle(It.IsAny<OpenFileMessage>())).Returns(_expectedFilePath);

            var fileReaderMock = new Mock<IFileReader>();
            fileReaderMock.Setup(reader => reader.GetTabNamesByIndex())
                .Returns(_expectedTabs);

            var fileReaderFactoryMock = new Mock<IFileReaderFactory>();
            fileReaderFactoryMock.Setup(factory => factory.CreateFromFileName(It.IsAny<FileInfoBase>())).Returns(fileReaderMock.Object);

            _presenter = new SelectFilesPresenter(_view, openFileMessageMock.Object, fileReaderFactoryMock.Object);
        }

        [Fact]
        public void Given_source_path_Then_selected_path_and_tabs_are_set_on_the_view()
        {
            _presenter.SelectSourcePath();

            _view.SourceFilePath.Should().Be(_expectedFilePath);
            _view.SourceFileTabs.ShouldAllBeEquivalentTo(_expectedTabs.Values);
        }

        [Fact]
        public void Given_target_path_Then_selected_path_and_tabs_are_set_on_the_view()
        {
            _presenter.SelectTargetPath();

            _view.TargetFilePath.Should().Be(_expectedFilePath);
            _view.TargetFileTabs.ShouldAllBeEquivalentTo(_expectedTabs.Values);
        }
    }
}
