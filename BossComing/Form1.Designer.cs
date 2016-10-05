namespace BossComing
{
  partial class Form1
  {
    /// <summary>
    /// 必要なデザイナー変数です。
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// 使用中のリソースをすべてクリーンアップします。
    /// </summary>
    /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows フォーム デザイナーで生成されたコード

    /// <summary>
    /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
    /// コード エディターで変更しないでください。
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
      this.statusStrip1 = new System.Windows.Forms.StatusStrip();
      this.toolStripStatusLabelKeyString = new System.Windows.Forms.ToolStripStatusLabel();
      this.toolStripStatusLabelCaptureDateTime = new System.Windows.Forms.ToolStripStatusLabel();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.ToolStripMenuItemFile = new System.Windows.Forms.ToolStripMenuItem();
      this.ToolStripMenuItemOpenImageFile = new System.Windows.Forms.ToolStripMenuItem();
      this.ToolStripMenuItemPasteImageFromClipboard = new System.Windows.Forms.ToolStripMenuItem();
      this.ToolStripMenuItemSaveImageFile = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
      this.ToolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
      this.ToolStripMenuItemView = new System.Windows.Forms.ToolStripMenuItem();
      this.ToolStripMenuItemOption = new System.Windows.Forms.ToolStripMenuItem();
      this.ToolStripMenuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
      this.ToolStripMenuItemOnlineHelp = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
      this.ToolStripMenuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
      this.panel1 = new System.Windows.Forms.Panel();
      this.buttonMinimize = new System.Windows.Forms.Button();
      this.buttonExit = new System.Windows.Forms.Button();
      this.buttonExecute = new System.Windows.Forms.Button();
      this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
      this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.ToolStripMenuItemDisplayForm = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
      this.ToolStripMenuItemApplicationExit = new System.Windows.Forms.ToolStripMenuItem();
      this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
      this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
      this.statusStrip1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.menuStrip1.SuspendLayout();
      this.panel1.SuspendLayout();
      this.contextMenuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // statusStrip1
      // 
      this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelKeyString,
            this.toolStripStatusLabelCaptureDateTime});
      resources.ApplyResources(this.statusStrip1, "statusStrip1");
      this.statusStrip1.Name = "statusStrip1";
      // 
      // toolStripStatusLabelKeyString
      // 
      this.toolStripStatusLabelKeyString.Name = "toolStripStatusLabelKeyString";
      resources.ApplyResources(this.toolStripStatusLabelKeyString, "toolStripStatusLabelKeyString");
      // 
      // toolStripStatusLabelCaptureDateTime
      // 
      this.toolStripStatusLabelCaptureDateTime.Name = "toolStripStatusLabelCaptureDateTime";
      this.toolStripStatusLabelCaptureDateTime.Padding = new System.Windows.Forms.Padding(32, 0, 0, 0);
      resources.ApplyResources(this.toolStripStatusLabelCaptureDateTime, "toolStripStatusLabelCaptureDateTime");
      // 
      // pictureBox1
      // 
      resources.ApplyResources(this.pictureBox1, "pictureBox1");
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.TabStop = false;
      // 
      // menuStrip1
      // 
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemFile,
            this.ToolStripMenuItemView,
            this.ToolStripMenuItemHelp});
      resources.ApplyResources(this.menuStrip1, "menuStrip1");
      this.menuStrip1.Name = "menuStrip1";
      // 
      // ToolStripMenuItemFile
      // 
      this.ToolStripMenuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemOpenImageFile,
            this.ToolStripMenuItemPasteImageFromClipboard,
            this.ToolStripMenuItemSaveImageFile,
            this.toolStripMenuItem1,
            this.ToolStripMenuItemExit});
      this.ToolStripMenuItemFile.Name = "ToolStripMenuItemFile";
      resources.ApplyResources(this.ToolStripMenuItemFile, "ToolStripMenuItemFile");
      this.ToolStripMenuItemFile.Click += new System.EventHandler(this.ToolStripMenuItemFile_Click);
      // 
      // ToolStripMenuItemOpenImageFile
      // 
      this.ToolStripMenuItemOpenImageFile.Name = "ToolStripMenuItemOpenImageFile";
      resources.ApplyResources(this.ToolStripMenuItemOpenImageFile, "ToolStripMenuItemOpenImageFile");
      this.ToolStripMenuItemOpenImageFile.Click += new System.EventHandler(this.ToolStripMenuItemOpenImageFile_Click);
      // 
      // ToolStripMenuItemPasteImageFromClipboard
      // 
      this.ToolStripMenuItemPasteImageFromClipboard.Name = "ToolStripMenuItemPasteImageFromClipboard";
      resources.ApplyResources(this.ToolStripMenuItemPasteImageFromClipboard, "ToolStripMenuItemPasteImageFromClipboard");
      this.ToolStripMenuItemPasteImageFromClipboard.Click += new System.EventHandler(this.ToolStripMenuItemOpenImageFromClipboard_Click_1);
      // 
      // ToolStripMenuItemSaveImageFile
      // 
      this.ToolStripMenuItemSaveImageFile.Name = "ToolStripMenuItemSaveImageFile";
      resources.ApplyResources(this.ToolStripMenuItemSaveImageFile, "ToolStripMenuItemSaveImageFile");
      this.ToolStripMenuItemSaveImageFile.Click += new System.EventHandler(this.ToolStripMenuItemSaveImageFile_Click);
      // 
      // toolStripMenuItem1
      // 
      this.toolStripMenuItem1.Name = "toolStripMenuItem1";
      resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
      // 
      // ToolStripMenuItemExit
      // 
      this.ToolStripMenuItemExit.Name = "ToolStripMenuItemExit";
      resources.ApplyResources(this.ToolStripMenuItemExit, "ToolStripMenuItemExit");
      this.ToolStripMenuItemExit.Click += new System.EventHandler(this.ToolStripMenuItemExit_Click);
      // 
      // ToolStripMenuItemView
      // 
      this.ToolStripMenuItemView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemOption});
      this.ToolStripMenuItemView.Name = "ToolStripMenuItemView";
      resources.ApplyResources(this.ToolStripMenuItemView, "ToolStripMenuItemView");
      // 
      // ToolStripMenuItemOption
      // 
      this.ToolStripMenuItemOption.Name = "ToolStripMenuItemOption";
      resources.ApplyResources(this.ToolStripMenuItemOption, "ToolStripMenuItemOption");
      this.ToolStripMenuItemOption.Click += new System.EventHandler(this.ToolStripMenuItemOption_Click);
      // 
      // ToolStripMenuItemHelp
      // 
      this.ToolStripMenuItemHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemOnlineHelp,
            this.toolStripMenuItem2,
            this.ToolStripMenuItemAbout});
      this.ToolStripMenuItemHelp.Name = "ToolStripMenuItemHelp";
      resources.ApplyResources(this.ToolStripMenuItemHelp, "ToolStripMenuItemHelp");
      // 
      // ToolStripMenuItemOnlineHelp
      // 
      this.ToolStripMenuItemOnlineHelp.Name = "ToolStripMenuItemOnlineHelp";
      resources.ApplyResources(this.ToolStripMenuItemOnlineHelp, "ToolStripMenuItemOnlineHelp");
      this.ToolStripMenuItemOnlineHelp.Click += new System.EventHandler(this.ToolStripMenuItemOnlineHelp_Click);
      // 
      // toolStripMenuItem2
      // 
      this.toolStripMenuItem2.Name = "toolStripMenuItem2";
      resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
      // 
      // ToolStripMenuItemAbout
      // 
      this.ToolStripMenuItemAbout.Name = "ToolStripMenuItemAbout";
      resources.ApplyResources(this.ToolStripMenuItemAbout, "ToolStripMenuItemAbout");
      this.ToolStripMenuItemAbout.Click += new System.EventHandler(this.ToolStripMenuItemAbout_Click);
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.buttonMinimize);
      this.panel1.Controls.Add(this.buttonExit);
      this.panel1.Controls.Add(this.buttonExecute);
      resources.ApplyResources(this.panel1, "panel1");
      this.panel1.Name = "panel1";
      // 
      // buttonMinimize
      // 
      resources.ApplyResources(this.buttonMinimize, "buttonMinimize");
      this.buttonMinimize.Name = "buttonMinimize";
      this.buttonMinimize.UseVisualStyleBackColor = true;
      this.buttonMinimize.Click += new System.EventHandler(this.buttonMinimize_Click);
      // 
      // buttonExit
      // 
      resources.ApplyResources(this.buttonExit, "buttonExit");
      this.buttonExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.buttonExit.Name = "buttonExit";
      this.buttonExit.UseVisualStyleBackColor = true;
      this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
      // 
      // buttonExecute
      // 
      resources.ApplyResources(this.buttonExecute, "buttonExecute");
      this.buttonExecute.Name = "buttonExecute";
      this.buttonExecute.UseVisualStyleBackColor = true;
      this.buttonExecute.Click += new System.EventHandler(this.buttonExecute_Click);
      // 
      // notifyIcon1
      // 
      this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
      resources.ApplyResources(this.notifyIcon1, "notifyIcon1");
      this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
      // 
      // contextMenuStrip1
      // 
      this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemDisplayForm,
            this.toolStripMenuItem3,
            this.ToolStripMenuItemApplicationExit});
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
      // 
      // ToolStripMenuItemDisplayForm
      // 
      this.ToolStripMenuItemDisplayForm.Name = "ToolStripMenuItemDisplayForm";
      resources.ApplyResources(this.ToolStripMenuItemDisplayForm, "ToolStripMenuItemDisplayForm");
      this.ToolStripMenuItemDisplayForm.Click += new System.EventHandler(this.ToolStripMenuItemDisplayForm_Click);
      // 
      // toolStripMenuItem3
      // 
      this.toolStripMenuItem3.Name = "toolStripMenuItem3";
      resources.ApplyResources(this.toolStripMenuItem3, "toolStripMenuItem3");
      // 
      // ToolStripMenuItemApplicationExit
      // 
      this.ToolStripMenuItemApplicationExit.Name = "ToolStripMenuItemApplicationExit";
      resources.ApplyResources(this.ToolStripMenuItemApplicationExit, "ToolStripMenuItemApplicationExit");
      this.ToolStripMenuItemApplicationExit.Click += new System.EventHandler(this.buttonExit_Click);
      // 
      // openFileDialog1
      // 
      resources.ApplyResources(this.openFileDialog1, "openFileDialog1");
      // 
      // saveFileDialog1
      // 
      resources.ApplyResources(this.saveFileDialog1, "saveFileDialog1");
      // 
      // Form1
      // 
      this.AcceptButton = this.buttonExecute;
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.buttonExit;
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.pictureBox1);
      this.Controls.Add(this.statusStrip1);
      this.Controls.Add(this.menuStrip1);
      this.MainMenuStrip = this.menuStrip1;
      this.Name = "Form1";
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
      this.Load += new System.EventHandler(this.Form1_Load);
      this.ClientSizeChanged += new System.EventHandler(this.Form1_ClientSizeChanged);
      this.statusStrip1.ResumeLayout(false);
      this.statusStrip1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.panel1.ResumeLayout(false);
      this.contextMenuStrip1.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.StatusStrip statusStrip1;
    private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelCaptureDateTime;
    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemFile;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemOpenImageFile;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemSaveImageFile;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemExit;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Button buttonExit;
    private System.Windows.Forms.Button buttonExecute;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemPasteImageFromClipboard;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemView;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemOption;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemHelp;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemOnlineHelp;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAbout;
    private System.Windows.Forms.NotifyIcon notifyIcon1;
    private System.Windows.Forms.OpenFileDialog openFileDialog1;
    private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelKeyString;
    private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemDisplayForm;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemApplicationExit;
    private System.Windows.Forms.Button buttonMinimize;
  }
}

