namespace GraphicEditor.View
{
    partial class MainForm
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
            drawingArea = new PictureBox();
            toolStrip = new ToolStrip();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            saveAsToolStripMenuItem = new ToolStripMenuItem();
            openFileDialog = new OpenFileDialog();
            saveFileDialog = new SaveFileDialog();
            infoPanel = new TableLayoutPanel();
            imageSizeInfoLabel = new Label();
            mousePositionLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)drawingArea).BeginInit();
            menuStrip1.SuspendLayout();
            infoPanel.SuspendLayout();
            SuspendLayout();
            // 
            // drawingArea
            // 
            drawingArea.BackColor = SystemColors.ControlLightLight;
            drawingArea.Location = new Point(0, 52);
            drawingArea.Name = "drawingArea";
            drawingArea.Size = new Size(800, 398);
            drawingArea.TabIndex = 0;
            drawingArea.TabStop = false;
            drawingArea.SizeChanged += drawingArea_SizeChanged;
            drawingArea.MouseDown += drawingArea_MouseDown;
            drawingArea.MouseMove += drawingArea_MouseMove;
            drawingArea.MouseUp += drawingArea_MouseUp;
            // 
            // toolStrip
            // 
            toolStrip.Location = new Point(0, 24);
            toolStrip.Name = "toolStrip";
            toolStrip.Size = new Size(800, 25);
            toolStrip.TabIndex = 1;
            toolStrip.Text = "toolStrip1";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openToolStripMenuItem, saveToolStripMenuItem, saveAsToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.ShortcutKeyDisplayString = "";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            openToolStripMenuItem.Size = new Size(146, 22);
            openToolStripMenuItem.Text = "Open";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            saveToolStripMenuItem.Size = new Size(146, 22);
            saveToolStripMenuItem.Text = "Save";
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.Size = new Size(146, 22);
            saveAsToolStripMenuItem.Text = "Save as";
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "openFileDialog1";
            // 
            // infoPanel
            // 
            infoPanel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            infoPanel.ColumnCount = 3;
            infoPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            infoPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            infoPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 570F));
            infoPanel.Controls.Add(imageSizeInfoLabel, 0, 0);
            infoPanel.Controls.Add(mousePositionLabel, 0, 0);
            infoPanel.Location = new Point(0, 425);
            infoPanel.Name = "infoPanel";
            infoPanel.RowCount = 1;
            infoPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            infoPanel.Size = new Size(800, 25);
            infoPanel.TabIndex = 3;
            // 
            // imageSizeInfoLabel
            // 
            imageSizeInfoLabel.Dock = DockStyle.Left;
            imageSizeInfoLabel.Location = new Point(123, 1);
            imageSizeInfoLabel.Margin = new Padding(3, 1, 3, 1);
            imageSizeInfoLabel.Name = "imageSizeInfoLabel";
            imageSizeInfoLabel.RightToLeft = RightToLeft.No;
            imageSizeInfoLabel.Size = new Size(114, 23);
            imageSizeInfoLabel.TabIndex = 1;
            imageSizeInfoLabel.Text = "Size: ";
            imageSizeInfoLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // mousePositionLabel
            // 
            mousePositionLabel.Dock = DockStyle.Left;
            mousePositionLabel.Location = new Point(3, 1);
            mousePositionLabel.Margin = new Padding(3, 1, 3, 1);
            mousePositionLabel.Name = "mousePositionLabel";
            mousePositionLabel.RightToLeft = RightToLeft.No;
            mousePositionLabel.Size = new Size(114, 23);
            mousePositionLabel.TabIndex = 0;
            mousePositionLabel.Text = "Position: ";
            mousePositionLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(infoPanel);
            Controls.Add(toolStrip);
            Controls.Add(menuStrip1);
            Controls.Add(drawingArea);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "MainForm";
            KeyDown += MainForm_KeyDown;
            ((System.ComponentModel.ISupportInitialize)drawingArea).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            infoPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox drawingArea;
        private ToolStrip toolStrip;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private OpenFileDialog openFileDialog;
        private SaveFileDialog saveFileDialog;
        private TableLayoutPanel infoPanel;
        private Label mousePositionLabel;
        private Label imageSizeInfoLabel;
    }
}