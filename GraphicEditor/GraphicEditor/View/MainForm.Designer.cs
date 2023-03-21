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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            toolStrip = new ToolStrip();
            undoToolStripButton = new ToolStripButton();
            redoToolStripButton = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            pencilToolStripButton = new ToolStripButton();
            figuresToolStripDropDownButton = new ToolStripDropDownButton();
            lineToolStripMenuItem = new ToolStripMenuItem();
            rectangleToolStripMenuItem = new ToolStripMenuItem();
            ellipseToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            foregroundColorButton = new ToolStripButton();
            backgroundColorButton = new ToolStripButton();
            menuStrip = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            saveAsToolStripMenuItem = new ToolStripMenuItem();
            openFileDialog = new OpenFileDialog();
            saveFileDialog = new SaveFileDialog();
            infoPanel = new TableLayoutPanel();
            imageSizeInfoLabel = new Label();
            mousePositionLabel = new Label();
            resizablePanel = new Controls.ResizablePanel();
            colorDialog = new ColorDialog();
            toolStrip.SuspendLayout();
            menuStrip.SuspendLayout();
            infoPanel.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip
            // 
            toolStrip.Items.AddRange(new ToolStripItem[] { undoToolStripButton, redoToolStripButton, toolStripSeparator2, pencilToolStripButton, figuresToolStripDropDownButton, toolStripSeparator1, foregroundColorButton, backgroundColorButton });
            toolStrip.Location = new Point(0, 24);
            toolStrip.Name = "toolStrip";
            toolStrip.Size = new Size(800, 25);
            toolStrip.TabIndex = 1;
            toolStrip.Text = "toolStrip1";
            // 
            // undoToolStripButton
            // 
            undoToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            undoToolStripButton.Image = (Image)resources.GetObject("undoToolStripButton.Image");
            undoToolStripButton.ImageTransparentColor = Color.Magenta;
            undoToolStripButton.Name = "undoToolStripButton";
            undoToolStripButton.Size = new Size(23, 22);
            undoToolStripButton.Text = "toolStripButton1";
            undoToolStripButton.ToolTipText = "Undo";
            undoToolStripButton.Click += undoToolStripButton_Click;
            // 
            // redoToolStripButton
            // 
            redoToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            redoToolStripButton.Image = (Image)resources.GetObject("redoToolStripButton.Image");
            redoToolStripButton.ImageTransparentColor = Color.Magenta;
            redoToolStripButton.Name = "redoToolStripButton";
            redoToolStripButton.Size = new Size(23, 22);
            redoToolStripButton.Text = "toolStripButton1";
            redoToolStripButton.ToolTipText = "Redo";
            redoToolStripButton.Click += redoToolStripButton_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 25);
            // 
            // pencilToolStripButton
            // 
            pencilToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            pencilToolStripButton.Image = (Image)resources.GetObject("pencilToolStripButton.Image");
            pencilToolStripButton.ImageTransparentColor = Color.Magenta;
            pencilToolStripButton.Name = "pencilToolStripButton";
            pencilToolStripButton.Size = new Size(23, 22);
            pencilToolStripButton.Text = "toolStripButton1";
            // 
            // figuresToolStripDropDownButton
            // 
            figuresToolStripDropDownButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            figuresToolStripDropDownButton.DropDownItems.AddRange(new ToolStripItem[] { lineToolStripMenuItem, rectangleToolStripMenuItem, ellipseToolStripMenuItem });
            figuresToolStripDropDownButton.Image = (Image)resources.GetObject("figuresToolStripDropDownButton.Image");
            figuresToolStripDropDownButton.ImageTransparentColor = Color.Magenta;
            figuresToolStripDropDownButton.Name = "figuresToolStripDropDownButton";
            figuresToolStripDropDownButton.Size = new Size(29, 22);
            figuresToolStripDropDownButton.Text = "toolStripDropDownButton1";
            // 
            // lineToolStripMenuItem
            // 
            lineToolStripMenuItem.Name = "lineToolStripMenuItem";
            lineToolStripMenuItem.Size = new Size(126, 22);
            lineToolStripMenuItem.Text = "Line";
            // 
            // rectangleToolStripMenuItem
            // 
            rectangleToolStripMenuItem.Name = "rectangleToolStripMenuItem";
            rectangleToolStripMenuItem.Size = new Size(126, 22);
            rectangleToolStripMenuItem.Text = "Rectangle";
            // 
            // ellipseToolStripMenuItem
            // 
            ellipseToolStripMenuItem.Name = "ellipseToolStripMenuItem";
            ellipseToolStripMenuItem.Size = new Size(126, 22);
            ellipseToolStripMenuItem.Text = "Ellipse";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 25);
            // 
            // foregroundColorButton
            // 
            foregroundColorButton.BackColor = SystemColors.Control;
            foregroundColorButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            foregroundColorButton.Image = (Image)resources.GetObject("foregroundColorButton.Image");
            foregroundColorButton.ImageTransparentColor = Color.Magenta;
            foregroundColorButton.Name = "foregroundColorButton";
            foregroundColorButton.Size = new Size(23, 22);
            foregroundColorButton.Text = "toolStripButton1";
            foregroundColorButton.ToolTipText = "Foreground color";
            foregroundColorButton.Click += foregroundColorButton_Click;
            // 
            // backgroundColorButton
            // 
            backgroundColorButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            backgroundColorButton.Image = (Image)resources.GetObject("backgroundColorButton.Image");
            backgroundColorButton.ImageTransparentColor = Color.Magenta;
            backgroundColorButton.Name = "backgroundColorButton";
            backgroundColorButton.Size = new Size(23, 22);
            backgroundColorButton.Text = "toolStripButton2";
            backgroundColorButton.ToolTipText = "Background color";
            backgroundColorButton.Click += backgroundColorButton_Click;
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(800, 24);
            menuStrip.TabIndex = 2;
            menuStrip.Text = "menuStrip1";
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
            // resizablePanel
            // 
            resizablePanel.BackColor = SystemColors.ActiveCaption;
            resizablePanel.Location = new Point(0, 52);
            resizablePanel.Name = "resizablePanel";
            resizablePanel.Padding = new Padding(2);
            resizablePanel.Size = new Size(800, 370);
            resizablePanel.TabIndex = 5;
            resizablePanel.Text = "resizableControl1";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(resizablePanel);
            Controls.Add(infoPanel);
            Controls.Add(toolStrip);
            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
            Name = "MainForm";
            Text = "MainForm";
            KeyDown += MainForm_KeyDown;
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            infoPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ToolStrip toolStrip;
        private MenuStrip menuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private OpenFileDialog openFileDialog;
        private SaveFileDialog saveFileDialog;
        private TableLayoutPanel infoPanel;
        private Label mousePositionLabel;
        private Label imageSizeInfoLabel;
        private Controls.ResizablePanel resizablePanel;
        private ToolStripButton foregroundColorButton;
        private ToolStripButton backgroundColorButton;
        private ColorDialog colorDialog;
        private ToolStripDropDownButton figuresToolStripDropDownButton;
        private ToolStripMenuItem lineToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton pencilToolStripButton;
        private ToolStripMenuItem rectangleToolStripMenuItem;
        private ToolStripMenuItem ellipseToolStripMenuItem;
        private ToolStripButton undoToolStripButton;
        private ToolStripButton redoToolStripButton;
        private ToolStripSeparator toolStripSeparator2;
    }
}