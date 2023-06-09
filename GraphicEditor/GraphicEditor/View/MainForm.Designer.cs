﻿using GraphicEditor.View.Controls;
using GraphicEditor.View.Drawing.Tools;

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
            invertToolStripButton = new ToolStripButton();
            clearToolStripButton = new ToolStripButton();
            toolStripSeparator5 = new ToolStripSeparator();
            undoToolStripButton = new ToolStripButton();
            redoToolStripButton = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            textToolStripToolButton = new ToolStripToolButton();
            pencilToolStripButton = new ToolStripToolButton();
            toolStripSeparator3 = new ToolStripSeparator();
            lineToolStripToolButton = new ToolStripToolButton();
            rectangleToolStripToolButton = new ToolStripToolButton();
            ellipseToolStripToolButton = new ToolStripToolButton();
            fillFigureToolStripButton = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            thicknessToolStripComboBox = new ToolStripComboBox();
            toolStripSeparator4 = new ToolStripSeparator();
            foregroundColorButton = new ToolStripButton();
            backgroundColorButton = new ToolStripButton();
            menuStrip = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            openFileDialog = new OpenFileDialog();
            saveFileDialog = new SaveFileDialog();
            infoPanel = new TableLayoutPanel();
            imageSizeInfoLabel = new Label();
            mousePositionLabel = new Label();
            resizablePanel = new ResizablePanel();
            disableDrawingPanel = new Panel();
            inversionLabel = new Label();
            invertionProgressBar = new ProgressBar();
            foregroundColorDialog = new ColorDialog();
            backgroundColorDialog = new ColorDialog();
            inversionBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            toolStrip.SuspendLayout();
            menuStrip.SuspendLayout();
            infoPanel.SuspendLayout();
            resizablePanel.SuspendLayout();
            disableDrawingPanel.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip
            // 
            toolStrip.Items.AddRange(new ToolStripItem[] { invertToolStripButton, clearToolStripButton, toolStripSeparator5, undoToolStripButton, redoToolStripButton, toolStripSeparator2, textToolStripToolButton, pencilToolStripButton, toolStripSeparator3, lineToolStripToolButton, rectangleToolStripToolButton, ellipseToolStripToolButton, fillFigureToolStripButton, toolStripSeparator1, thicknessToolStripComboBox, toolStripSeparator4, foregroundColorButton, backgroundColorButton });
            toolStrip.Location = new Point(0, 24);
            toolStrip.Name = "toolStrip";
            toolStrip.Size = new Size(800, 25);
            toolStrip.TabIndex = 1;
            toolStrip.Text = "toolStrip1";
            // 
            // invertToolStripButton
            // 
            invertToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            invertToolStripButton.Image = (Image)resources.GetObject("invertToolStripButton.Image");
            invertToolStripButton.ImageTransparentColor = Color.Magenta;
            invertToolStripButton.Name = "invertToolStripButton";
            invertToolStripButton.Size = new Size(23, 22);
            invertToolStripButton.Text = "toolStripButton1";
            invertToolStripButton.ToolTipText = "Invert";
            invertToolStripButton.Click += invertToolStripButton_Click;
            // 
            // clearToolStripButton
            // 
            clearToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            clearToolStripButton.Image = (Image)resources.GetObject("clearToolStripButton.Image");
            clearToolStripButton.ImageTransparentColor = Color.Magenta;
            clearToolStripButton.Name = "clearToolStripButton";
            clearToolStripButton.Size = new Size(23, 22);
            clearToolStripButton.Text = "toolStripButton1";
            clearToolStripButton.ToolTipText = "Clear";
            clearToolStripButton.Click += clearToolStripButton_Click;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(6, 25);
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
            // textToolStripToolButton
            // 
            textToolStripToolButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            textToolStripToolButton.GroupIndex = 1;
            textToolStripToolButton.Image = (Image)resources.GetObject("textToolStripToolButton.Image");
            textToolStripToolButton.ImageTransparentColor = Color.Magenta;
            textToolStripToolButton.Name = "textToolStripToolButton";
            textToolStripToolButton.Size = new Size(23, 22);
            textToolStripToolButton.Text = "toolStripButton1";
            textToolStripToolButton.Tool = DrawingToolType.TextInput;
            textToolStripToolButton.ToolTipText = "Text";
            textToolStripToolButton.Click += drawingTool_ToolStripButton_Click;
            // 
            // pencilToolStripButton
            // 
            pencilToolStripButton.Checked = true;
            pencilToolStripButton.CheckState = CheckState.Checked;
            pencilToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            pencilToolStripButton.GroupIndex = 1;
            pencilToolStripButton.Image = (Image)resources.GetObject("pencilToolStripButton.Image");
            pencilToolStripButton.ImageTransparentColor = Color.Magenta;
            pencilToolStripButton.Name = "pencilToolStripButton";
            pencilToolStripButton.Size = new Size(23, 22);
            pencilToolStripButton.Text = "toolStripButton1";
            pencilToolStripButton.ToolTipText = "Pencil";
            pencilToolStripButton.Click += drawingTool_ToolStripButton_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 25);
            // 
            // lineToolStripToolButton
            // 
            lineToolStripToolButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            lineToolStripToolButton.GroupIndex = 1;
            lineToolStripToolButton.Image = (Image)resources.GetObject("lineToolStripToolButton.Image");
            lineToolStripToolButton.ImageTransparentColor = Color.Magenta;
            lineToolStripToolButton.Name = "lineToolStripToolButton";
            lineToolStripToolButton.Size = new Size(23, 22);
            lineToolStripToolButton.Text = "toolStripButton1";
            lineToolStripToolButton.Tool = DrawingToolType.Line;
            lineToolStripToolButton.ToolTipText = "Line";
            lineToolStripToolButton.Click += drawingTool_ToolStripButton_Click;
            // 
            // rectangleToolStripToolButton
            // 
            rectangleToolStripToolButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            rectangleToolStripToolButton.GroupIndex = 1;
            rectangleToolStripToolButton.Image = (Image)resources.GetObject("rectangleToolStripToolButton.Image");
            rectangleToolStripToolButton.ImageTransparentColor = Color.Magenta;
            rectangleToolStripToolButton.Name = "rectangleToolStripToolButton";
            rectangleToolStripToolButton.Size = new Size(23, 22);
            rectangleToolStripToolButton.Text = "toolStripButton1";
            rectangleToolStripToolButton.Tool = DrawingToolType.Rectangle;
            rectangleToolStripToolButton.ToolTipText = "Rectangle";
            rectangleToolStripToolButton.Click += drawingTool_ToolStripButton_Click;
            // 
            // ellipseToolStripToolButton
            // 
            ellipseToolStripToolButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            ellipseToolStripToolButton.GroupIndex = 1;
            ellipseToolStripToolButton.Image = (Image)resources.GetObject("ellipseToolStripToolButton.Image");
            ellipseToolStripToolButton.ImageTransparentColor = Color.Magenta;
            ellipseToolStripToolButton.Name = "ellipseToolStripToolButton";
            ellipseToolStripToolButton.Size = new Size(23, 22);
            ellipseToolStripToolButton.Text = "toolStripButton1";
            ellipseToolStripToolButton.Tool = DrawingToolType.Ellipse;
            ellipseToolStripToolButton.ToolTipText = "Ellipse";
            ellipseToolStripToolButton.Click += drawingTool_ToolStripButton_Click;
            // 
            // fillFigureToolStripButton
            // 
            fillFigureToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            fillFigureToolStripButton.Image = (Image)resources.GetObject("fillFigureToolStripButton.Image");
            fillFigureToolStripButton.ImageTransparentColor = Color.Magenta;
            fillFigureToolStripButton.Name = "fillFigureToolStripButton";
            fillFigureToolStripButton.Size = new Size(23, 22);
            fillFigureToolStripButton.Text = "toolStripButton1";
            fillFigureToolStripButton.ToolTipText = "Figure filling";
            fillFigureToolStripButton.Click += fillFigureToolStripButton_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 25);
            // 
            // thicknessToolStripComboBox
            // 
            thicknessToolStripComboBox.CausesValidation = false;
            thicknessToolStripComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            thicknessToolStripComboBox.Name = "thicknessToolStripComboBox";
            thicknessToolStripComboBox.Size = new Size(75, 25);
            thicknessToolStripComboBox.ToolTipText = "Thickness";
            thicknessToolStripComboBox.SelectedIndexChanged += thicknessToolStripCombobox_SelectedIndexChanged;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(6, 25);
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
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openToolStripMenuItem, saveToolStripMenuItem });
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
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
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
            resizablePanel.BackColor = SystemColors.AppWorkspace;
            resizablePanel.BorderColor = Color.Gray;
            resizablePanel.BorderThickness = 3;
            resizablePanel.Controls.Add(disableDrawingPanel);
            resizablePanel.Cursor = Cursors.Cross;
            resizablePanel.Location = new Point(0, 52);
            resizablePanel.MinimumSize = new Size(6, 6);
            resizablePanel.Name = "resizablePanel";
            resizablePanel.Padding = new Padding(0, 0, 3, 3);
            resizablePanel.ResizeDirections = ResizablePanel.ResizeDirection.Right | ResizablePanel.ResizeDirection.Bottom;
            resizablePanel.Size = new Size(800, 370);
            resizablePanel.TabIndex = 5;
            resizablePanel.Text = "resizableControl1";
            // 
            // disableDrawingPanel
            // 
            disableDrawingPanel.Controls.Add(inversionLabel);
            disableDrawingPanel.Controls.Add(invertionProgressBar);
            disableDrawingPanel.Dock = DockStyle.Fill;
            disableDrawingPanel.Location = new Point(0, 0);
            disableDrawingPanel.Name = "disableDrawingPanel";
            disableDrawingPanel.Size = new Size(797, 367);
            disableDrawingPanel.TabIndex = 0;
            disableDrawingPanel.Visible = false;
            // 
            // inversionLabel
            // 
            inversionLabel.AutoSize = true;
            inversionLabel.Location = new Point(3, 3);
            inversionLabel.Name = "inversionLabel";
            inversionLabel.Size = new Size(93, 15);
            inversionLabel.TabIndex = 1;
            inversionLabel.Text = "Color inversion..";
            // 
            // invertionProgressBar
            // 
            invertionProgressBar.Location = new Point(3, 21);
            invertionProgressBar.Name = "invertionProgressBar";
            invertionProgressBar.Size = new Size(791, 23);
            invertionProgressBar.TabIndex = 0;
            // 
            // foregroundColorDialog
            // 
            foregroundColorDialog.AnyColor = true;
            foregroundColorDialog.FullOpen = true;
            // 
            // backgroundColorDialog
            // 
            backgroundColorDialog.Color = Color.White;
            backgroundColorDialog.FullOpen = true;
            // 
            // inversionBackgroundWorker
            // 
            inversionBackgroundWorker.WorkerReportsProgress = true;
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
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            infoPanel.ResumeLayout(false);
            resizablePanel.ResumeLayout(false);
            disableDrawingPanel.ResumeLayout(false);
            disableDrawingPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ToolStrip toolStrip;
        private MenuStrip menuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private OpenFileDialog openFileDialog;
        private SaveFileDialog saveFileDialog;
        private TableLayoutPanel infoPanel;
        private Label mousePositionLabel;
        private Label imageSizeInfoLabel;
        private Controls.ResizablePanel resizablePanel;
        private ToolStripButton foregroundColorButton;
        private ToolStripButton backgroundColorButton;
        private ColorDialog foregroundColorDialog;
        private ToolStripDropDownButton figuresToolStripDropDownButton;
        private ToolStripToolButton lineToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripToolButton pencilToolStripButton;
        private ToolStripToolButton rectangleToolStripMenuItem;
        private ToolStripToolButton ellipseToolStripMenuItem;
        private ToolStripButton undoToolStripButton;
        private ToolStripButton redoToolStripButton;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripToolButton lineToolStripToolButton;
        private ToolStripToolButton rectangleToolStripToolButton;
        private ToolStripToolButton ellipseToolStripToolButton;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripComboBox thicknessToolStripComboBox;
        private ToolStripSeparator toolStripSeparator4;
        private ColorDialog backgroundColorDialog;
        private ToolStripToolButton textToolStripToolButton;
        private ToolStripButton clearToolStripButton;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripButton fillFigureToolStripButton;
        private ToolStripButton invertToolStripButton;
        private Panel disableDrawingPanel;
        private Label inversionLabel;
        private ProgressBar invertionProgressBar;
        private System.ComponentModel.BackgroundWorker inversionBackgroundWorker;
    }
}