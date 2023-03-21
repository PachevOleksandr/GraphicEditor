﻿namespace GraphicEditor.View
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
            foregroundColorButton = new ToolStripButton();
            backgroundColorButton = new ToolStripButton();
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
            resizablePanel = new Controls.ResizablePanel();
            colorDialog = new ColorDialog();
            toolStrip.SuspendLayout();
            menuStrip1.SuspendLayout();
            infoPanel.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip
            // 
            toolStrip.Items.AddRange(new ToolStripItem[] { foregroundColorButton, backgroundColorButton });
            toolStrip.Location = new Point(0, 24);
            toolStrip.Name = "toolStrip";
            toolStrip.Size = new Size(800, 25);
            toolStrip.TabIndex = 1;
            toolStrip.Text = "toolStrip1";
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
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "MainForm";
            KeyDown += MainForm_KeyDown;
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            infoPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
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
        private Controls.ResizablePanel resizablePanel;
        private ToolStripButton foregroundColorButton;
        private ToolStripButton backgroundColorButton;
        private ColorDialog colorDialog;
    }
}