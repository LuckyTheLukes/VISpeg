namespace VISpeg
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button_ISStart = new Button();
            tabControl_Main = new TabControl();
            tab_VtoIS = new TabPage();
            label_ISFps = new Label();
            tb_Framerate = new TextBox();
            label_ISFramerate = new Label();
            cb_ISFormat = new ComboBox();
            label_ISFormat = new Label();
            label_ISContainer = new Label();
            label_ISCodec = new Label();
            cb_ISContainer = new ComboBox();
            cb_ISCodec = new ComboBox();
            label_VideoOutput = new Label();
            label_ISInput = new Label();
            btn_OutputVideoFolderPicker = new Button();
            tb_OutputVideoPath = new TextBox();
            rtb_Log = new RichTextBox();
            btn_InputISFolderPicker = new Button();
            tb_InputISPath = new TextBox();
            tab_IStoV = new TabPage();
            tab_Audio = new TabPage();
            tab_Settings = new TabPage();
            tabControl_Main.SuspendLayout();
            tab_VtoIS.SuspendLayout();
            SuspendLayout();
            // 
            // button_ISStart
            // 
            button_ISStart.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_ISStart.Location = new Point(792, 250);
            button_ISStart.Name = "button_ISStart";
            button_ISStart.Size = new Size(143, 47);
            button_ISStart.TabIndex = 0;
            button_ISStart.Text = "Start";
            button_ISStart.UseVisualStyleBackColor = true;
            // 
            // tabControl_Main
            // 
            tabControl_Main.Controls.Add(tab_VtoIS);
            tabControl_Main.Controls.Add(tab_IStoV);
            tabControl_Main.Controls.Add(tab_Audio);
            tabControl_Main.Controls.Add(tab_Settings);
            tabControl_Main.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tabControl_Main.HotTrack = true;
            tabControl_Main.ItemSize = new Size(230, 50);
            tabControl_Main.Location = new Point(12, 12);
            tabControl_Main.Multiline = true;
            tabControl_Main.Name = "tabControl_Main";
            tabControl_Main.Padding = new Point(16, 3);
            tabControl_Main.RightToLeftLayout = true;
            tabControl_Main.SelectedIndex = 0;
            tabControl_Main.Size = new Size(960, 537);
            tabControl_Main.SizeMode = TabSizeMode.Fixed;
            tabControl_Main.TabIndex = 1;
            // 
            // tab_VtoIS
            // 
            tab_VtoIS.Controls.Add(label_ISFps);
            tab_VtoIS.Controls.Add(tb_Framerate);
            tab_VtoIS.Controls.Add(label_ISFramerate);
            tab_VtoIS.Controls.Add(cb_ISFormat);
            tab_VtoIS.Controls.Add(label_ISFormat);
            tab_VtoIS.Controls.Add(label_ISContainer);
            tab_VtoIS.Controls.Add(label_ISCodec);
            tab_VtoIS.Controls.Add(cb_ISContainer);
            tab_VtoIS.Controls.Add(cb_ISCodec);
            tab_VtoIS.Controls.Add(label_VideoOutput);
            tab_VtoIS.Controls.Add(label_ISInput);
            tab_VtoIS.Controls.Add(btn_OutputVideoFolderPicker);
            tab_VtoIS.Controls.Add(tb_OutputVideoPath);
            tab_VtoIS.Controls.Add(rtb_Log);
            tab_VtoIS.Controls.Add(btn_InputISFolderPicker);
            tab_VtoIS.Controls.Add(tb_InputISPath);
            tab_VtoIS.Controls.Add(button_ISStart);
            tab_VtoIS.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tab_VtoIS.Location = new Point(4, 54);
            tab_VtoIS.Name = "tab_VtoIS";
            tab_VtoIS.Padding = new Padding(3);
            tab_VtoIS.Size = new Size(952, 479);
            tab_VtoIS.TabIndex = 0;
            tab_VtoIS.Text = "Image Sequence to Video";
            tab_VtoIS.UseVisualStyleBackColor = true;
            // 
            // label_ISFps
            // 
            label_ISFps.AutoSize = true;
            label_ISFps.Location = new Point(700, 133);
            label_ISFps.Name = "label_ISFps";
            label_ISFps.Size = new Size(26, 17);
            label_ISFps.TabIndex = 16;
            label_ISFps.Text = "fps";
            // 
            // tb_Framerate
            // 
            tb_Framerate.Location = new Point(627, 130);
            tb_Framerate.Name = "tb_Framerate";
            tb_Framerate.Size = new Size(70, 25);
            tb_Framerate.TabIndex = 15;
            // 
            // label_ISFramerate
            // 
            label_ISFramerate.AutoSize = true;
            label_ISFramerate.Location = new Point(627, 110);
            label_ISFramerate.Name = "label_ISFramerate";
            label_ISFramerate.Size = new Size(70, 17);
            label_ISFramerate.TabIndex = 14;
            label_ISFramerate.Text = "Framerate:";
            // 
            // cb_ISFormat
            // 
            cb_ISFormat.FormattingEnabled = true;
            cb_ISFormat.Location = new Point(213, 130);
            cb_ISFormat.Name = "cb_ISFormat";
            cb_ISFormat.Size = new Size(121, 25);
            cb_ISFormat.TabIndex = 13;
            // 
            // label_ISFormat
            // 
            label_ISFormat.AutoSize = true;
            label_ISFormat.Location = new Point(213, 110);
            label_ISFormat.Name = "label_ISFormat";
            label_ISFormat.Size = new Size(52, 17);
            label_ISFormat.TabIndex = 12;
            label_ISFormat.Text = "Format:";
            // 
            // label_ISContainer
            // 
            label_ISContainer.AutoSize = true;
            label_ISContainer.Location = new Point(419, 110);
            label_ISContainer.Name = "label_ISContainer";
            label_ISContainer.Size = new Size(67, 17);
            label_ISContainer.TabIndex = 11;
            label_ISContainer.Text = "Container:";
            // 
            // label_ISCodec
            // 
            label_ISCodec.AutoSize = true;
            label_ISCodec.Location = new Point(17, 110);
            label_ISCodec.Name = "label_ISCodec";
            label_ISCodec.Size = new Size(48, 17);
            label_ISCodec.TabIndex = 10;
            label_ISCodec.Text = "Codec:";
            // 
            // cb_ISContainer
            // 
            cb_ISContainer.FormattingEnabled = true;
            cb_ISContainer.Location = new Point(419, 130);
            cb_ISContainer.Name = "cb_ISContainer";
            cb_ISContainer.Size = new Size(121, 25);
            cb_ISContainer.TabIndex = 9;
            // 
            // cb_ISCodec
            // 
            cb_ISCodec.FormattingEnabled = true;
            cb_ISCodec.Location = new Point(17, 130);
            cb_ISCodec.Name = "cb_ISCodec";
            cb_ISCodec.Size = new Size(121, 25);
            cb_ISCodec.TabIndex = 8;
            // 
            // label_VideoOutput
            // 
            label_VideoOutput.AutoSize = true;
            label_VideoOutput.Location = new Point(17, 181);
            label_VideoOutput.Name = "label_VideoOutput";
            label_VideoOutput.Size = new Size(89, 17);
            label_VideoOutput.TabIndex = 7;
            label_VideoOutput.Text = "Video Output:";
            // 
            // label_ISInput
            // 
            label_ISInput.AutoSize = true;
            label_ISInput.Location = new Point(17, 33);
            label_ISInput.Name = "label_ISInput";
            label_ISInput.Size = new Size(140, 17);
            label_ISInput.TabIndex = 6;
            label_ISInput.Text = "Image Sequence Input:";
            // 
            // btn_OutputVideoFolderPicker
            // 
            btn_OutputVideoFolderPicker.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_OutputVideoFolderPicker.Location = new Point(792, 201);
            btn_OutputVideoFolderPicker.Name = "btn_OutputVideoFolderPicker";
            btn_OutputVideoFolderPicker.Size = new Size(143, 25);
            btn_OutputVideoFolderPicker.TabIndex = 5;
            btn_OutputVideoFolderPicker.Text = "Select a Folder";
            btn_OutputVideoFolderPicker.UseVisualStyleBackColor = true;
            // 
            // tb_OutputVideoPath
            // 
            tb_OutputVideoPath.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tb_OutputVideoPath.Location = new Point(17, 201);
            tb_OutputVideoPath.Name = "tb_OutputVideoPath";
            tb_OutputVideoPath.Size = new Size(769, 25);
            tb_OutputVideoPath.TabIndex = 4;
            // 
            // rtb_Log
            // 
            rtb_Log.Cursor = Cursors.IBeam;
            rtb_Log.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rtb_Log.HideSelection = false;
            rtb_Log.Location = new Point(6, 315);
            rtb_Log.Name = "rtb_Log";
            rtb_Log.ReadOnly = true;
            rtb_Log.ScrollBars = RichTextBoxScrollBars.Vertical;
            rtb_Log.Size = new Size(940, 158);
            rtb_Log.TabIndex = 3;
            rtb_Log.Text = "";
            rtb_Log.WordWrap = false;
            // 
            // btn_InputISFolderPicker
            // 
            btn_InputISFolderPicker.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_InputISFolderPicker.Location = new Point(792, 53);
            btn_InputISFolderPicker.Name = "btn_InputISFolderPicker";
            btn_InputISFolderPicker.Size = new Size(143, 25);
            btn_InputISFolderPicker.TabIndex = 2;
            btn_InputISFolderPicker.Text = "Select a Folder";
            btn_InputISFolderPicker.UseVisualStyleBackColor = true;
            // 
            // tb_InputISPath
            // 
            tb_InputISPath.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tb_InputISPath.Location = new Point(17, 53);
            tb_InputISPath.Name = "tb_InputISPath";
            tb_InputISPath.Size = new Size(769, 25);
            tb_InputISPath.TabIndex = 1;
            // 
            // tab_IStoV
            // 
            tab_IStoV.Location = new Point(4, 54);
            tab_IStoV.Name = "tab_IStoV";
            tab_IStoV.Padding = new Padding(3);
            tab_IStoV.Size = new Size(952, 479);
            tab_IStoV.TabIndex = 1;
            tab_IStoV.Text = "Video to Image Sequence";
            tab_IStoV.UseVisualStyleBackColor = true;
            // 
            // tab_Audio
            // 
            tab_Audio.Location = new Point(4, 54);
            tab_Audio.Name = "tab_Audio";
            tab_Audio.Padding = new Padding(3);
            tab_Audio.Size = new Size(952, 479);
            tab_Audio.TabIndex = 2;
            tab_Audio.Text = "Audio";
            tab_Audio.UseVisualStyleBackColor = true;
            // 
            // tab_Settings
            // 
            tab_Settings.Location = new Point(4, 54);
            tab_Settings.Name = "tab_Settings";
            tab_Settings.Size = new Size(952, 479);
            tab_Settings.TabIndex = 3;
            tab_Settings.Text = "Settings";
            tab_Settings.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 561);
            Controls.Add(tabControl_Main);
            Name = "FormMain";
            Text = "VISpeg";
            tabControl_Main.ResumeLayout(false);
            tab_VtoIS.ResumeLayout(false);
            tab_VtoIS.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button button_ISStart;
        private TabControl tabControl_Main;
        private TabPage tab_VtoIS;
        private TabPage tab_IStoV;
        private TabPage tab_Audio;
        private TabPage tab_Settings;
        private Button btn_InputISFolderPicker;
        private TextBox tb_InputISPath;
        private RichTextBox rtb_Log;
        private Button btn_OutputVideoFolderPicker;
        private TextBox tb_OutputVideoPath;
        private Label label_VideoOutput;
        private Label label_ISInput;
        private Label label_ISContainer;
        private Label label_ISCodec;
        private ComboBox cb_ISContainer;
        private ComboBox cb_ISCodec;
        private ComboBox cb_ISFormat;
        private Label label_ISFormat;
        private Label label_ISFramerate;
        private Label label_ISFps;
        private TextBox tb_Framerate;
    }
}
