using System.Collections.Generic;
using FluentAssertions;
using Moq;
using UniqueFileRecordsComparer.App.MessageHandlers;
using UniqueFileRecordsComparer.App.SelectFiles;
using UniqueFileRecordsComparer.Core.Readers;
using Xunit;

namespace UniqueFileRecordsComparer.App.Tests.SelectFiles
{
    public class When_validating_view
    {
        private readonly Mock<ISelectFilesView> _validView = new Mock<ISelectFilesView>();
        

        private readonly SelectFilesPresenter _presenter;

        public When_validating_view()
        {
            _validView.SetupGet(x => x.SourceFilePath).Returns("Test");
            _validView.SetupGet(x => x.TargetFilePath).Returns("Test");
            _validView.SetupGet(x => x.SelectedSourceFileTabIndex).Returns(1);
            _validView.SetupGet(x => x.SourceFileTabs).Returns(new List<string> {"A"});
            _validView.SetupGet(x => x.SelectedTargetFileTabIndex).Returns(0);
            _validView.SetupGet(x => x.TargetFileTabs).Returns(new List<string> { "A" });

            _presenter = new SelectFilesPresenter(_validView.Object, Mock.Of<IOpenFileMessageHandler>(), Mock.Of<IFileReaderFactory>());
        }

        [Fact]
        public void Given_valid_view_Then_returns_true()
        {
            _presenter.IsViewValid.Should().BeTrue();
        }

        [Fact]
        public void Given_null_SourceFilePath_Then_returns_false()
        {
            _validView.SetupGet(x => x.SourceFilePath).Returns(() => null);

            _presenter.IsViewValid.Should().BeFalse();
        }

        [Fact]
        public void Given_empty_SourceFilePath_Then_returns_false()
        {
            _validView.SetupGet(x => x.SourceFilePath).Returns(string.Empty);

            _presenter.IsViewValid.Should().BeFalse();
        }

        [Fact]
        public void Given_whitespace_SourceFilePath_Then_returns_false()
        {
            _validView.SetupGet(x => x.SourceFilePath).Returns("    ");

            _presenter.IsViewValid.Should().BeFalse();
        }

        [Fact]
        public void Given_null_TargetFilePath_Then_returns_false()
        {
            _validView.SetupGet(x => x.TargetFilePath).Returns(() => null);

            _presenter.IsViewValid.Should().BeFalse();
        }

        [Fact]
        public void Given_empty_TargetFilePath_Then_returns_false()
        {
            _validView.SetupGet(x => x.TargetFilePath).Returns(string.Empty);

            _presenter.IsViewValid.Should().BeFalse();
        }

        [Fact]
        public void Given_whitespace_TargetFilePath_Then_returns_false()
        {
            _validView.SetupGet(x => x.TargetFilePath).Returns("    ");

            _presenter.IsViewValid.Should().BeFalse();
        }

        [Fact]
        public void Given_SelectedSourceFileTabIndex_is_less_than_0_Then_returns_false()
        {
            _validView.SetupGet(x => x.SelectedSourceFileTabIndex).Returns(-1);

            _presenter.IsViewValid.Should().BeFalse();
        }

        [Fact]
        public void Given_SelectedTargetFileTabIndex_is_less_than_0_Then_returns_false()
        {
            _validView.SetupGet(x => x.SelectedTargetFileTabIndex).Returns(-100);

            _presenter.IsViewValid.Should().BeFalse();
        }
    }
}
