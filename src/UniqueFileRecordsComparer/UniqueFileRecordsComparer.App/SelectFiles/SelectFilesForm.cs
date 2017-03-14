using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DryIoc;
using UniqueFileRecordsComparer.App.SelectColumns;
using UniqueFileRecordsComparer.Core;
using UniqueFileRecordsComparer.Core.Readers;

namespace UniqueFileRecordsComparer.App.SelectFiles
{
    public partial class SelectFilesForm : Form, ISelectFilesView
    {
        private readonly IContainer _container;

        public SelectFilesForm(SelectFilesPresenter presenter, IContainer container)
        {
            _container = container;
            Presenter = presenter;
            presenter.View = this;
            InitializeComponent();
        }

        private void ChooseSourceFileButton_Click(object sender, EventArgs e)
        {
            Presenter.SelectSourcePath();
        }

        private void ChooseTargetFileButton_Click(object sender, EventArgs e)
        {
            Presenter.SelectTargetPath();
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            if (Presenter.IsViewValid)
            {
                var presenter = _container.Resolve<SelectColumnsPresenter>();
                presenter.Load(new ComparerArguments
                {
                    SourceFilePath = SourceFilePath,
                    TargetFilePath = TargetFilePath,
                    SourceFileTabIndex = SelectedSourceFileTabIndex,
                    TargetFileTabIndex = SelectedTargetFileTabIndex
                });
                Hide();
            }
            else
            {
                MessageBox.Show("Please select a source and a target file", "Select a file", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public string SourceFilePath
        {
            get { return SourceFilePathLabel.Text; }
            set { SourceFilePathLabel.Text = value; }
        }

        public string TargetFilePath
        {
            get { return TargetFilePathLabel.Text; }
            set { TargetFilePathLabel.Text = value; }
        }

        public IList<string> SourceFileTabs
        {
            get { return SourceFileTabsDropDown.DataSource as IList<string>; }
            set
            {
                SourceFileTabsDropDown.DataSource = value;
                SourceFileTabsDropDown.Enabled = value.Count > 1;
                SelectedSourceFileTabIndex = value.Count > 0 ? 0 : -1;
            }
        }

        public IList<string> TargetFileTabs
        {
            get { return TargetFileTabsDropDown.DataSource as IList<string>; }
            set
            {
                TargetFileTabsDropDown.DataSource = value;
                TargetFileTabsDropDown.Enabled = value.Count > 1;
                SelectedTargetFileTabIndex = value.Count > 0 ? 0 : -1;
            }
        }

        public int SelectedSourceFileTabIndex
        {
            get { return SourceFileTabsDropDown.SelectedIndex; }
            set { SourceFileTabsDropDown.SelectedIndex = value; }
        }

        public int SelectedTargetFileTabIndex
        {
            get { return TargetFileTabsDropDown.SelectedIndex; }
            set { TargetFileTabsDropDown.SelectedIndex = value; }
        }

        public SelectFilesPresenter Presenter { private get; set; }
    }
}
