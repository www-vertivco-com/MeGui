// ****************************************************************************
// 
// Copyright (C) 2005-2008  Doom9 & al
// 
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
// 
// ****************************************************************************

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using MeGUI.core.util;

namespace MeGUI
{

	/// <summary>
	/// Summary description for Vobinput.
	/// </summary>
	public class VobinputWindow : System.Windows.Forms.Form
	{
		#region variables
        private IndexJob lastJob = null;

        private bool dialogMode = false; // $%�%$^>*"%$%%$#{"!!! Affects the public behaviour!
		private bool configured = false;
		private bool processing = false;
		private MainForm mainForm;
		private VideoUtil vUtil;
		private JobUtil jobUtil;

		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button openButton;
		private System.Windows.Forms.TextBox input;
		private System.Windows.Forms.Label inputLabel;
		private System.Windows.Forms.TextBox projectName;
		private System.Windows.Forms.Label projectNameLabel;
		private System.Windows.Forms.SaveFileDialog saveProjectDialog;
		private System.Windows.Forms.OpenFileDialog openIFODialog;
		private System.Windows.Forms.Button pickOutputButton;
		private System.Windows.Forms.GroupBox inputGroupbox;
        private System.Windows.Forms.RadioButton demuxAllTracks;
        private System.Windows.Forms.RadioButton demuxNoAudiotracks;
		private System.Windows.Forms.Button queueButton;
		private System.Windows.Forms.CheckBox loadOnComplete;
		private System.Windows.Forms.CheckBox closeOnQueue;
        private MeGUI.core.gui.HelpButton helpButton1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion
		#region start / stop
		public void setConfig(string input, string projectName, int demuxType,
            bool showCloseOnQueue, bool closeOnQueue, bool loadOnComplete, bool updateMode)
		{
			openVideo(input);
			this.input.Text = input;
			this.projectName.Text = projectName;
			if (demuxType == 0)
				demuxNoAudiotracks.Checked = true;
			else
				demuxAllTracks.Checked = true;
			this.loadOnComplete.Checked = loadOnComplete;
            if (updateMode)
            {
                this.dialogMode = true;
                queueButton.Text = "Update";
            }
            else
                this.dialogMode = false;
			checkIndexIO();
            if (!showCloseOnQueue)
            {
                this.closeOnQueue.Hide();
                this.Controls.Remove(this.closeOnQueue);
            }
            this.closeOnQueue.Checked = closeOnQueue;

		}
		
		public VobinputWindow(MainForm mainForm)
		{
			InitializeComponent();
			this.mainForm = mainForm;
			this.vUtil = new VideoUtil(mainForm);
			this.jobUtil = new JobUtil(mainForm);
			this.Closing += new CancelEventHandler(VobinputWindow_Closing);
		}

		public VobinputWindow(MainForm mainForm, string fileName): this(mainForm)
		{
			openVideo(fileName);
		}

        public VobinputWindow(MainForm mainForm, string fileName, bool autoReturn) : this(mainForm, fileName)
        {
            openVideo(fileName);
            this.loadOnComplete.Checked = true;
            this.closeOnQueue.Checked = true;
            projectName.Text = Path.ChangeExtension(fileName, ".d2v");
            checkIndexIO();
        }

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		/// <summary>
		///  prevents the form from closing if we're still processing
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void VobinputWindow_Closing(object sender, CancelEventArgs e)
		{
			if (this.processing)
				e.Cancel = true;
		}
		#endregion
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.inputGroupbox = new System.Windows.Forms.GroupBox();
            this.openButton = new System.Windows.Forms.Button();
            this.input = new System.Windows.Forms.TextBox();
            this.inputLabel = new System.Windows.Forms.Label();
            this.queueButton = new System.Windows.Forms.Button();
            this.loadOnComplete = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.demuxNoAudiotracks = new System.Windows.Forms.RadioButton();
            this.demuxAllTracks = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pickOutputButton = new System.Windows.Forms.Button();
            this.projectName = new System.Windows.Forms.TextBox();
            this.projectNameLabel = new System.Windows.Forms.Label();
            this.saveProjectDialog = new System.Windows.Forms.SaveFileDialog();
            this.openIFODialog = new System.Windows.Forms.OpenFileDialog();
            this.closeOnQueue = new System.Windows.Forms.CheckBox();
            this.helpButton1 = new MeGUI.core.gui.HelpButton();
            this.inputGroupbox.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // inputGroupbox
            // 
            this.inputGroupbox.Controls.Add(this.openButton);
            this.inputGroupbox.Controls.Add(this.input);
            this.inputGroupbox.Controls.Add(this.inputLabel);
            this.inputGroupbox.Location = new System.Drawing.Point(10, 8);
            this.inputGroupbox.Name = "inputGroupbox";
            this.inputGroupbox.Size = new System.Drawing.Size(424, 48);
            this.inputGroupbox.TabIndex = 0;
            this.inputGroupbox.TabStop = false;
            this.inputGroupbox.Text = "Video Input";
            // 
            // openButton
            // 
            this.openButton.AllowDrop = true;
            this.openButton.Location = new System.Drawing.Point(382, 16);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(24, 23);
            this.openButton.TabIndex = 2;
            this.openButton.Text = "...";
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // input
            // 
            this.input.AllowDrop = true;
            this.input.Location = new System.Drawing.Point(118, 17);
            this.input.Name = "input";
            this.input.ReadOnly = true;
            this.input.Size = new System.Drawing.Size(256, 21);
            this.input.TabIndex = 1;
            // 
            // inputLabel
            // 
            this.inputLabel.Location = new System.Drawing.Point(16, 20);
            this.inputLabel.Name = "inputLabel";
            this.inputLabel.Size = new System.Drawing.Size(100, 13);
            this.inputLabel.TabIndex = 0;
            this.inputLabel.Text = "Video Input";
            // 
            // queueButton
            // 
            this.queueButton.Location = new System.Drawing.Point(360, 201);
            this.queueButton.Name = "queueButton";
            this.queueButton.Size = new System.Drawing.Size(74, 23);
            this.queueButton.TabIndex = 10;
            this.queueButton.Text = "Queue";
            this.queueButton.Click += new System.EventHandler(this.queueButton_Click);
            // 
            // loadOnComplete
            // 
            this.loadOnComplete.Location = new System.Drawing.Point(59, 200);
            this.loadOnComplete.Name = "loadOnComplete";
            this.loadOnComplete.Size = new System.Drawing.Size(144, 24);
            this.loadOnComplete.TabIndex = 11;
            this.loadOnComplete.Text = "On completion load files";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.demuxNoAudiotracks);
            this.groupBox3.Controls.Add(this.demuxAllTracks);
            this.groupBox3.Location = new System.Drawing.Point(10, 56);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(424, 73);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Audio";
            // 
            // demuxNoAudiotracks
            // 
            this.demuxNoAudiotracks.Checked = true;
            this.demuxNoAudiotracks.Location = new System.Drawing.Point(16, 16);
            this.demuxNoAudiotracks.Name = "demuxNoAudiotracks";
            this.demuxNoAudiotracks.Size = new System.Drawing.Size(120, 24);
            this.demuxNoAudiotracks.TabIndex = 13;
            this.demuxNoAudiotracks.TabStop = true;
            this.demuxNoAudiotracks.Text = "No Audio demux";
            // 
            // demuxAllTracks
            // 
            this.demuxAllTracks.Location = new System.Drawing.Point(16, 40);
            this.demuxAllTracks.Name = "demuxAllTracks";
            this.demuxAllTracks.Size = new System.Drawing.Size(160, 24);
            this.demuxAllTracks.TabIndex = 7;
            this.demuxAllTracks.Text = "Demux all Audio Tracks";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pickOutputButton);
            this.groupBox2.Controls.Add(this.projectName);
            this.groupBox2.Controls.Add(this.projectNameLabel);
            this.groupBox2.Location = new System.Drawing.Point(10, 135);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(424, 49);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Video";
            // 
            // pickOutputButton
            // 
            this.pickOutputButton.Location = new System.Drawing.Point(384, 16);
            this.pickOutputButton.Name = "pickOutputButton";
            this.pickOutputButton.Size = new System.Drawing.Size(24, 23);
            this.pickOutputButton.TabIndex = 5;
            this.pickOutputButton.Text = "...";
            this.pickOutputButton.Click += new System.EventHandler(this.pickOutputButton_Click);
            // 
            // projectName
            // 
            this.projectName.Location = new System.Drawing.Point(120, 17);
            this.projectName.Name = "projectName";
            this.projectName.ReadOnly = true;
            this.projectName.Size = new System.Drawing.Size(256, 21);
            this.projectName.TabIndex = 4;
            // 
            // projectNameLabel
            // 
            this.projectNameLabel.Location = new System.Drawing.Point(16, 20);
            this.projectNameLabel.Name = "projectNameLabel";
            this.projectNameLabel.Size = new System.Drawing.Size(100, 13);
            this.projectNameLabel.TabIndex = 3;
            this.projectNameLabel.Text = "d2v Project Output";
            // 
            // saveProjectDialog
            // 
            this.saveProjectDialog.Filter = "DGIndex project files|*.d2v";
            this.saveProjectDialog.Title = "Pick a name for your DGIndex project";
            // 
            // openIFODialog
            // 
            this.openIFODialog.Filter = "VOB Files (*.vob)|*.vob|MPEG-1/2 Program Streams (*.mpg)|*.mpg|Transport Streams " +
                "(*.m2ts;*.ts)|*.m2ts;*.ts|All DGIndex supported files|*.vob;*.mpg;*.mpeg;*.m2ts;" +
                "*.m2v;*.mpv;*.tp;*.ts;*.trp;*.pva;*.vro";
            this.openIFODialog.FilterIndex = 4;
            // 
            // closeOnQueue
            // 
            this.closeOnQueue.Location = new System.Drawing.Point(280, 201);
            this.closeOnQueue.Name = "closeOnQueue";
            this.closeOnQueue.Size = new System.Drawing.Size(72, 24);
            this.closeOnQueue.TabIndex = 13;
            this.closeOnQueue.Text = "and close";
            // 
            // helpButton1
            // 
            this.helpButton1.ArticleName = "D2v creator window";
            this.helpButton1.AutoSize = true;
            this.helpButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.helpButton1.Location = new System.Drawing.Point(8, 200);
            this.helpButton1.Name = "helpButton1";
            this.helpButton1.Size = new System.Drawing.Size(45, 23);
            this.helpButton1.TabIndex = 14;
            // 
            // VobinputWindow
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
            this.ClientSize = new System.Drawing.Size(444, 232);
            this.Controls.Add(this.helpButton1);
            this.Controls.Add(this.closeOnQueue);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.loadOnComplete);
            this.Controls.Add(this.queueButton);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.inputGroupbox);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "VobinputWindow";
            this.Text = "MeGUI - D2V Project Creator";
            this.inputGroupbox.ResumeLayout(false);
            this.inputGroupbox.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion
		#region buttons
		private void pickOutputButton_Click(object sender, System.EventArgs e)
		{
			if (!processing)
			{
				if (saveProjectDialog.ShowDialog() == DialogResult.OK)
				{
					projectName.Text = saveProjectDialog.FileName;
					checkIndexIO();
				}
			}
		}

		private void openButton_Click(object sender, System.EventArgs e)
		{
			if (!processing)
			{
				if (openIFODialog.ShowDialog() == DialogResult.OK)
				{
					openVideo(openIFODialog.FileName);
					projectName.Text = Path.ChangeExtension(openIFODialog.FileName, ".d2v");
					checkIndexIO();
				}
			}
		}
		private void openVideo(string fileName)
		{
			input.Text = fileName;
		}
		/// <summary>
		/// creates a dgindex project
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void queueButton_Click(object sender, System.EventArgs e)
		{
			if (configured)
			{
				if (!dialogMode)
				{
					IndexJob job = generateIndexJob();
                    lastJob = job;
					mainForm.Jobs.addJobsToQueue(job);
					if (this.closeOnQueue.Checked)
						this.Close();
				}
			}
			else
				MessageBox.Show("You must select a Video Input and DGIndex project file to continue", 
					"Configuration incomplete", MessageBoxButtons.OK);
		}
		#endregion
		#region helper methods
		private void checkIndexIO()
		{
			configured = (!input.Text.Equals("") && !projectName.Text.Equals(""));
			if (configured && dialogMode)
				queueButton.DialogResult = DialogResult.OK;
			else
                queueButton.DialogResult = DialogResult.None;
		}
		private IndexJob generateIndexJob()
		{
			int demuxType = 0;
			if (demuxAllTracks.Checked)
				demuxType = 2;
			return new IndexJob(this.input.Text, this.projectName.Text, demuxType, null, loadOnComplete.Checked);
		}
		#endregion
		#region properties
		/// <summary>
		/// gets the index job created from the current configuration
		/// </summary>
		public IndexJob Job
		{
			get {return generateIndexJob();}
		}
        
        public IndexJob LastJob
        {
            get { return lastJob; }
            set { lastJob = value; }
        }
        public bool JobCreated
        {
            get { return lastJob != null; }
        }
        #endregion

    }

    public class D2VCreatorTool : MeGUI.core.plugins.interfaces.ITool
    {

        #region ITool Members

        public string Name
        {
            get { return "D2V Creator"; }
        }

        public void Run(MainForm info)
        {
            new VobinputWindow(info).Show();

        }

        public Shortcut[] Shortcuts
        {
            get { return new Shortcut[] { Shortcut.Ctrl2 }; }
        }

        #endregion

        #region IIDable Members

        public string ID
        {
            get { return "d2v_creator"; }
        }

        #endregion
    }

    public class IndexJobPostProcessor
    {
        public static JobPostProcessor PostProcessor = new JobPostProcessor(postprocess, "D2V_postprocessor");
        private static LogItem postprocess(MainForm mainForm, Job ajob)
        {
            if (!(ajob is IndexJob)) return null;
            IndexJob job = (IndexJob)ajob;
            if (job.PostprocessingProperties != null) return null;

            StringBuilder logBuilder = new StringBuilder();
            VideoUtil vUtil = new VideoUtil(mainForm);
            Dictionary<int, string> audioFiles = vUtil.getAllDemuxedAudio(job.Output, 8);
            if (job.LoadSources)
            {
                if (job.DemuxMode != 0)
                {
                    string[] files = new string[audioFiles.Values.Count];
                    audioFiles.Values.CopyTo(files, 0);
                    Util.ThreadSafeRun(mainForm, new MethodInvoker(
                        delegate
                        {
                            mainForm.Audio.openAudioFile(files);
                        }));
                }
                AviSynthWindow asw = new AviSynthWindow(mainForm, job.Output);
                asw.OpenScript += new OpenScriptCallback(mainForm.Video.openVideoFile);
                asw.Show();
            }

            return null;
        }
    }

    public delegate void ProjectCreationComplete(); // this event is fired when the dgindex thread finishes
}