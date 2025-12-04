namespace vConMpeg
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
            button1 = new Button();
            tabControl_Main = new TabControl();
            tab_VtoIS = new TabPage();
            btn_ISPicker = new Button();
            tb_ISPath = new TextBox();
            tab_IStoV = new TabPage();
            tab_Audio = new TabPage();
            tab_Settings = new TabPage();
            tabControl_Main.SuspendLayout();
            tab_VtoIS.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(749, 230);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "Test";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
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
            tab_VtoIS.Controls.Add(btn_ISPicker);
            tab_VtoIS.Controls.Add(tb_ISPath);
            tab_VtoIS.Controls.Add(button1);
            tab_VtoIS.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tab_VtoIS.Location = new Point(4, 54);
            tab_VtoIS.Name = "tab_VtoIS";
            tab_VtoIS.Padding = new Padding(3);
            tab_VtoIS.Size = new Size(952, 479);
            tab_VtoIS.TabIndex = 0;
            tab_VtoIS.Text = "Image Sequence to Video";
            tab_VtoIS.UseVisualStyleBackColor = true;
            // 
            // btn_ISPicker
            // 
            btn_ISPicker.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_ISPicker.Location = new Point(793, 30);
            btn_ISPicker.Name = "btn_ISPicker";
            btn_ISPicker.Size = new Size(143, 29);
            btn_ISPicker.TabIndex = 2;
            btn_ISPicker.Text = "Select a Folder";
            btn_ISPicker.UseVisualStyleBackColor = true;
            // 
            // tb_ISPath
            // 
            tb_ISPath.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tb_ISPath.Location = new Point(18, 30);
            tb_ISPath.Name = "tb_ISPath";
            tb_ISPath.Size = new Size(769, 25);
            tb_ISPath.TabIndex = 1;
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
            Text = "Form1";
            tabControl_Main.ResumeLayout(false);
            tab_VtoIS.ResumeLayout(false);
            tab_VtoIS.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private TabControl tabControl_Main;
        private TabPage tab_VtoIS;
        private TabPage tab_IStoV;
        private TabPage tab_Audio;
        private TabPage tab_Settings;
        private Button btn_ISPicker;
        private TextBox tb_ISPath;
    }
}
