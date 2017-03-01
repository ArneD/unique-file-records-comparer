using FluentAssertions;
using Moq;
using UniqueFileRecordsComparer.App.Messages;
using UniqueFileRecordsComparer.App.SelectFiles;
using UniqueFileRecordsComparer.Core.Readers;
using Xunit;

namespace UniqueFileRecordsComparer.App.Tests.SelectFiles
{
    public class When_validating_view
    {
        private readonly SelectFileViewStub _validView = new SelectFileViewStub
        {
            SourceFilePath = "Test",
            TargetFilePath = "Test",
            SelectedSourceFileTabIndex = 1,
            SelectedTargetFileTabIndex = 0
        };

        private readonly SelectFilesPresenter _presenter;

        public When_validating_view()
        {
            _presenter = new SelectFilesPresenter(_validView, Mock.Of<IOpenFileMessageHandler>(), Mock.Of<IFileReaderFactory>());
        }

        [Fact]
        public void Given_valid_view_Then_returns_true()
        {
            _presenter.IsViewValid.Should().BeTrue();
        }

        [Fact]
        public void Given_null_SourceFilePath_Then_returns_false()
        {
            _validView.SourceFilePath = null;

            _presenter.IsViewValid.Should().BeFalse();
        }

        [Fact]
        public void Given_empty_SourceFilePath_Then_returns_false()
        {
            _validView.SourceFilePath = string.Empty;

            _presenter.IsViewValid.Should().BeFalse();
        }

        [Fact]
        public void Given_whitespace_SourceFilePath_Then_returns_false()
        {
            _validView.SourceFilePath = "   ";

            _presenter.IsViewValid.Should().BeFalse();
        }

        [Fact]
        public void Given_null_TargetFilePath_Then_returns_false()
        {
            _validView.TargetFilePath = null;

            _presenter.IsViewValid.Should().BeFalse();
        }

        [Fact]
        public void Given_empty_TargetFilePath_Then_returns_false()
        {
            _validView.TargetFilePath = string.Empty;

            _presenter.IsViewValid.Should().BeFalse();
        }

        [Fact]
        public void Given_whitespace_TargetFilePath_Then_returns_false()
        {
            _validView.TargetFilePath = "   ";

            _presenter.IsViewValid.Should().BeFalse();
        }

        [Fact]
        public void Given_SelectedSourceFileTabIndex_is_less_than_0_Then_returns_false()
        {
            _validView.SelectedSourceFileTabIndex = -1;

            _presenter.IsViewValid.Should().BeFalse();
        }

        [Fact]
        public void Given_SelectedTargetFileTabIndex_is_less_than_0_Then_returns_false()
        {
            _validView.SelectedTargetFileTabIndex = -100;

            _presenter.IsViewValid.Should().BeFalse();
        }
    }
}
