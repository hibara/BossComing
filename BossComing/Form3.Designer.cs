namespace BossComing
{
  partial class Form3
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
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
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.checkBoxShift = new System.Windows.Forms.CheckBox();
      this.checkBoxAlt = new System.Windows.Forms.CheckBox();
      this.checkBoxCtrl = new System.Windows.Forms.CheckBox();
      this.listBoxKeyString = new System.Windows.Forms.ListBox();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.labelFadeInSpeed = new System.Windows.Forms.Label();
      this.trackBar1 = new System.Windows.Forms.TrackBar();
      this.groupBox3 = new System.Windows.Forms.GroupBox();
      this.buttonSelectFile = new System.Windows.Forms.Button();
      this.textBoxSpecifyImageFile = new System.Windows.Forms.TextBox();
      this.checkBoxSpecifyImageFile = new System.Windows.Forms.CheckBox();
      this.panel1 = new System.Windows.Forms.Panel();
      this.buttonOK = new System.Windows.Forms.Button();
      this.buttonCancel = new System.Windows.Forms.Button();
      this.buttonApply = new System.Windows.Forms.Button();
      this.checkBoxInTaskbar = new System.Windows.Forms.CheckBox();
      this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
      this.groupBox3.SuspendLayout();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.checkBoxShift);
      this.groupBox1.Controls.Add(this.checkBoxAlt);
      this.groupBox1.Controls.Add(this.checkBoxCtrl);
      this.groupBox1.Controls.Add(this.listBoxKeyString);
      resources.ApplyResources(this.groupBox1, "groupBox1");
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.TabStop = false;
      // 
      // checkBoxShift
      // 
      resources.ApplyResources(this.checkBoxShift, "checkBoxShift");
      this.checkBoxShift.Name = "checkBoxShift";
      this.checkBoxShift.UseVisualStyleBackColor = true;
      this.checkBoxShift.CheckedChanged += new System.EventHandler(this.ChangedValue);
      // 
      // checkBoxAlt
      // 
      resources.ApplyResources(this.checkBoxAlt, "checkBoxAlt");
      this.checkBoxAlt.Name = "checkBoxAlt";
      this.checkBoxAlt.UseVisualStyleBackColor = true;
      this.checkBoxAlt.CheckedChanged += new System.EventHandler(this.ChangedValue);
      // 
      // checkBoxCtrl
      // 
      resources.ApplyResources(this.checkBoxCtrl, "checkBoxCtrl");
      this.checkBoxCtrl.Name = "checkBoxCtrl";
      this.checkBoxCtrl.UseVisualStyleBackColor = true;
      this.checkBoxCtrl.CheckedChanged += new System.EventHandler(this.ChangedValue);
      // 
      // listBoxKeyString
      // 
      this.listBoxKeyString.FormattingEnabled = true;
      resources.ApplyResources(this.listBoxKeyString, "listBoxKeyString");
      this.listBoxKeyString.Items.AddRange(new object[] {
            resources.GetString("listBoxKeyString.Items"),
            resources.GetString("listBoxKeyString.Items1"),
            resources.GetString("listBoxKeyString.Items2"),
            resources.GetString("listBoxKeyString.Items3"),
            resources.GetString("listBoxKeyString.Items4"),
            resources.GetString("listBoxKeyString.Items5"),
            resources.GetString("listBoxKeyString.Items6"),
            resources.GetString("listBoxKeyString.Items7"),
            resources.GetString("listBoxKeyString.Items8"),
            resources.GetString("listBoxKeyString.Items9"),
            resources.GetString("listBoxKeyString.Items10"),
            resources.GetString("listBoxKeyString.Items11"),
            resources.GetString("listBoxKeyString.Items12"),
            resources.GetString("listBoxKeyString.Items13"),
            resources.GetString("listBoxKeyString.Items14"),
            resources.GetString("listBoxKeyString.Items15"),
            resources.GetString("listBoxKeyString.Items16"),
            resources.GetString("listBoxKeyString.Items17"),
            resources.GetString("listBoxKeyString.Items18"),
            resources.GetString("listBoxKeyString.Items19"),
            resources.GetString("listBoxKeyString.Items20"),
            resources.GetString("listBoxKeyString.Items21"),
            resources.GetString("listBoxKeyString.Items22"),
            resources.GetString("listBoxKeyString.Items23"),
            resources.GetString("listBoxKeyString.Items24"),
            resources.GetString("listBoxKeyString.Items25"),
            resources.GetString("listBoxKeyString.Items26"),
            resources.GetString("listBoxKeyString.Items27"),
            resources.GetString("listBoxKeyString.Items28"),
            resources.GetString("listBoxKeyString.Items29"),
            resources.GetString("listBoxKeyString.Items30"),
            resources.GetString("listBoxKeyString.Items31"),
            resources.GetString("listBoxKeyString.Items32"),
            resources.GetString("listBoxKeyString.Items33"),
            resources.GetString("listBoxKeyString.Items34"),
            resources.GetString("listBoxKeyString.Items35"),
            resources.GetString("listBoxKeyString.Items36"),
            resources.GetString("listBoxKeyString.Items37"),
            resources.GetString("listBoxKeyString.Items38"),
            resources.GetString("listBoxKeyString.Items39"),
            resources.GetString("listBoxKeyString.Items40"),
            resources.GetString("listBoxKeyString.Items41"),
            resources.GetString("listBoxKeyString.Items42"),
            resources.GetString("listBoxKeyString.Items43"),
            resources.GetString("listBoxKeyString.Items44"),
            resources.GetString("listBoxKeyString.Items45"),
            resources.GetString("listBoxKeyString.Items46"),
            resources.GetString("listBoxKeyString.Items47")});
      this.listBoxKeyString.Name = "listBoxKeyString";
      this.listBoxKeyString.SelectedIndexChanged += new System.EventHandler(this.ChangedValue);
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.labelFadeInSpeed);
      this.groupBox2.Controls.Add(this.trackBar1);
      resources.ApplyResources(this.groupBox2, "groupBox2");
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.TabStop = false;
      // 
      // labelFadeInSpeed
      // 
      resources.ApplyResources(this.labelFadeInSpeed, "labelFadeInSpeed");
      this.labelFadeInSpeed.Name = "labelFadeInSpeed";
      // 
      // trackBar1
      // 
      resources.ApplyResources(this.trackBar1, "trackBar1");
      this.trackBar1.Maximum = 1000;
      this.trackBar1.Minimum = 1;
      this.trackBar1.Name = "trackBar1";
      this.trackBar1.TickFrequency = 10;
      this.trackBar1.Value = 100;
      this.trackBar1.ValueChanged += new System.EventHandler(this.ChangedValue);
      // 
      // groupBox3
      // 
      this.groupBox3.Controls.Add(this.buttonSelectFile);
      this.groupBox3.Controls.Add(this.textBoxSpecifyImageFile);
      this.groupBox3.Controls.Add(this.checkBoxSpecifyImageFile);
      resources.ApplyResources(this.groupBox3, "groupBox3");
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.TabStop = false;
      // 
      // buttonSelectFile
      // 
      resources.ApplyResources(this.buttonSelectFile, "buttonSelectFile");
      this.buttonSelectFile.Name = "buttonSelectFile";
      this.buttonSelectFile.UseVisualStyleBackColor = true;
      this.buttonSelectFile.Click += new System.EventHandler(this.buttonSelectFile_Click);
      // 
      // textBoxSpecifyImageFile
      // 
      resources.ApplyResources(this.textBoxSpecifyImageFile, "textBoxSpecifyImageFile");
      this.textBoxSpecifyImageFile.Name = "textBoxSpecifyImageFile";
      // 
      // checkBoxSpecifyImageFile
      // 
      resources.ApplyResources(this.checkBoxSpecifyImageFile, "checkBoxSpecifyImageFile");
      this.checkBoxSpecifyImageFile.Name = "checkBoxSpecifyImageFile";
      this.checkBoxSpecifyImageFile.UseVisualStyleBackColor = true;
      this.checkBoxSpecifyImageFile.CheckedChanged += new System.EventHandler(this.checkBoxSpecifyImageFile_CheckedChanged);
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.buttonOK);
      this.panel1.Controls.Add(this.buttonCancel);
      this.panel1.Controls.Add(this.buttonApply);
      resources.ApplyResources(this.panel1, "panel1");
      this.panel1.Name = "panel1";
      // 
      // buttonOK
      // 
      resources.ApplyResources(this.buttonOK, "buttonOK");
      this.buttonOK.Name = "buttonOK";
      this.buttonOK.UseVisualStyleBackColor = true;
      this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
      // 
      // buttonCancel
      // 
      resources.ApplyResources(this.buttonCancel, "buttonCancel");
      this.buttonCancel.Name = "buttonCancel";
      this.buttonCancel.UseVisualStyleBackColor = true;
      this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
      // 
      // buttonApply
      // 
      resources.ApplyResources(this.buttonApply, "buttonApply");
      this.buttonApply.Name = "buttonApply";
      this.buttonApply.UseVisualStyleBackColor = true;
      this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
      // 
      // checkBoxInTaskbar
      // 
      resources.ApplyResources(this.checkBoxInTaskbar, "checkBoxInTaskbar");
      this.checkBoxInTaskbar.Name = "checkBoxInTaskbar";
      this.checkBoxInTaskbar.UseVisualStyleBackColor = true;
      this.checkBoxInTaskbar.CheckedChanged += new System.EventHandler(this.ChangedValue);
      // 
      // Form3
      // 
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.checkBoxInTaskbar);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.groupBox3);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.groupBox1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "Form3";
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form3_FormClosed);
      this.Load += new System.EventHandler(this.Form3_Load);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
      this.groupBox3.ResumeLayout(false);
      this.groupBox3.PerformLayout();
      this.panel1.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.CheckBox checkBoxShift;
    private System.Windows.Forms.CheckBox checkBoxAlt;
    private System.Windows.Forms.CheckBox checkBoxCtrl;
    private System.Windows.Forms.ListBox listBoxKeyString;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.Label labelFadeInSpeed;
    private System.Windows.Forms.TrackBar trackBar1;
    private System.Windows.Forms.GroupBox groupBox3;
    private System.Windows.Forms.Button buttonSelectFile;
    private System.Windows.Forms.TextBox textBoxSpecifyImageFile;
    private System.Windows.Forms.CheckBox checkBoxSpecifyImageFile;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.CheckBox checkBoxInTaskbar;
    private System.Windows.Forms.Button buttonOK;
    private System.Windows.Forms.Button buttonCancel;
    private System.Windows.Forms.Button buttonApply;
    private System.Windows.Forms.OpenFileDialog openFileDialog1;
  }
}