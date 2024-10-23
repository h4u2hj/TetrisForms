using System.Windows.Forms;

namespace TetrisView
{
    partial class TetrisDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TetrisDialog));
            tableLayoutPanel = new TableLayoutPanel();
            canvasPanel = new Panel();
            leftPanel = new Panel();
            pinkButton = new Button();
            saveButton = new Button();
            loadButton = new Button();
            TetrisLabel = new Label();
            holdImage = new PictureBox();
            rightPanel = new Panel();
            newHardGameButton = new Button();
            newMediumGameButton = new Button();
            newEasyGameButton = new Button();
            pauseButton = new Button();
            newGameButton = new Button();
            nextLabel = new Label();
            nextImage = new PictureBox();
            scoreLabel = new Label();
            _openFileDialog = new OpenFileDialog();
            _saveFileDialog = new SaveFileDialog();
            tableLayoutPanel.SuspendLayout();
            leftPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)holdImage).BeginInit();
            rightPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nextImage).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 3;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel.Controls.Add(canvasPanel, 1, 0);
            tableLayoutPanel.Controls.Add(leftPanel, 0, 0);
            tableLayoutPanel.Controls.Add(rightPanel, 2, 0);
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.Location = new Point(0, 0);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 1;
            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel.Size = new Size(784, 591);
            tableLayoutPanel.TabIndex = 0;
            // 
            // canvasPanel
            // 
            canvasPanel.BackColor = Color.Gray;
            canvasPanel.Dock = DockStyle.Top;
            canvasPanel.Location = new Point(212, 19);
            canvasPanel.Margin = new Padding(3, 19, 3, 2);
            canvasPanel.Name = "canvasPanel";
            canvasPanel.Size = new Size(360, 490);
            canvasPanel.TabIndex = 3;
            // 
            // leftPanel
            // 
            leftPanel.Controls.Add(pinkButton);
            leftPanel.Controls.Add(saveButton);
            leftPanel.Controls.Add(loadButton);
            leftPanel.Controls.Add(TetrisLabel);
            leftPanel.Controls.Add(holdImage);
            leftPanel.Dock = DockStyle.Fill;
            leftPanel.Location = new Point(3, 3);
            leftPanel.Name = "leftPanel";
            leftPanel.Size = new Size(203, 595);
            leftPanel.TabIndex = 1;
            // 
            // pinkButton
            // 
            pinkButton.Anchor = AnchorStyles.None;
            pinkButton.BackColor = Color.FromArgb(255, 90, 170);
            pinkButton.Font = new Font("Times New Roman", 18.75F);
            pinkButton.ForeColor = SystemColors.ControlText;
            pinkButton.Location = new Point(22, 492);
            pinkButton.Name = "pinkButton";
            pinkButton.Size = new Size(159, 38);
            pinkButton.TabIndex = 7;
            pinkButton.Text = "Pink Mode<3";
            pinkButton.UseVisualStyleBackColor = false;
            pinkButton.Visible = false;
            pinkButton.Click += pinkButton_Click;
            // 
            // saveButton
            // 
            saveButton.Anchor = AnchorStyles.None;
            saveButton.BackColor = Color.FromArgb(255, 100, 150);
            saveButton.Font = new Font("Times New Roman", 18.75F);
            saveButton.ForeColor = SystemColors.ControlText;
            saveButton.Location = new Point(48, 343);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(101, 38);
            saveButton.TabIndex = 5;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = false;
            saveButton.Visible = false;
            saveButton.Click += saveButton_Click;
            saveButton.PreviewKeyDown += Button_PreviewKeyDown;
            // 
            // loadButton
            // 
            loadButton.Anchor = AnchorStyles.None;
            loadButton.BackColor = Color.FromArgb(255, 100, 150);
            loadButton.Font = new Font("Times New Roman", 18.75F);
            loadButton.Location = new Point(48, 404);
            loadButton.Name = "loadButton";
            loadButton.Size = new Size(101, 38);
            loadButton.TabIndex = 6;
            loadButton.Text = "Load";
            loadButton.UseVisualStyleBackColor = false;
            loadButton.Click += loadButton_Click;
            loadButton.PreviewKeyDown += Button_PreviewKeyDown;
            // 
            // TetrisLabel
            // 
            TetrisLabel.Anchor = AnchorStyles.None;
            TetrisLabel.AutoSize = true;
            TetrisLabel.Font = new Font("Times New Roman", 28F, FontStyle.Bold, GraphicsUnit.Point, 238);
            TetrisLabel.ForeColor = Color.Gold;
            TetrisLabel.Location = new Point(48, 35);
            TetrisLabel.Name = "TetrisLabel";
            TetrisLabel.Size = new Size(114, 43);
            TetrisLabel.TabIndex = 2;
            TetrisLabel.Text = "Tetris";
            TetrisLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // holdImage
            // 
            holdImage.Anchor = AnchorStyles.None;
            holdImage.BackColor = Color.Transparent;
            holdImage.Image = (Image)resources.GetObject("holdImage.Image");
            holdImage.Location = new Point(37, 176);
            holdImage.Name = "holdImage";
            holdImage.Size = new Size(125, 125);
            holdImage.SizeMode = PictureBoxSizeMode.Zoom;
            holdImage.TabIndex = 1;
            holdImage.TabStop = false;
            // 
            // rightPanel
            // 
            rightPanel.Controls.Add(newHardGameButton);
            rightPanel.Controls.Add(newMediumGameButton);
            rightPanel.Controls.Add(newEasyGameButton);
            rightPanel.Controls.Add(pauseButton);
            rightPanel.Controls.Add(newGameButton);
            rightPanel.Controls.Add(nextLabel);
            rightPanel.Controls.Add(nextImage);
            rightPanel.Controls.Add(scoreLabel);
            rightPanel.Dock = DockStyle.Fill;
            rightPanel.Location = new Point(578, 3);
            rightPanel.Name = "rightPanel";
            rightPanel.Size = new Size(203, 595);
            rightPanel.TabIndex = 2;
            // 
            // newHardGameButton
            // 
            newHardGameButton.Anchor = AnchorStyles.None;
            newHardGameButton.BackColor = Color.FromArgb(255, 100, 150);
            newHardGameButton.Font = new Font("Times New Roman", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            newHardGameButton.Location = new Point(61, 495);
            newHardGameButton.Name = "newHardGameButton";
            newHardGameButton.Size = new Size(71, 37);
            newHardGameButton.TabIndex = 11;
            newHardGameButton.Text = "Hard";
            newHardGameButton.UseVisualStyleBackColor = false;
            newHardGameButton.Click += newHardGameButton_Click;
            newHardGameButton.PreviewKeyDown += Button_PreviewKeyDown;
            // 
            // newMediumGameButton
            // 
            newMediumGameButton.Anchor = AnchorStyles.None;
            newMediumGameButton.BackColor = Color.FromArgb(255, 100, 150);
            newMediumGameButton.Font = new Font("Times New Roman", 15F);
            newMediumGameButton.Location = new Point(51, 439);
            newMediumGameButton.Name = "newMediumGameButton";
            newMediumGameButton.Size = new Size(98, 37);
            newMediumGameButton.TabIndex = 10;
            newMediumGameButton.Text = "Medium";
            newMediumGameButton.UseVisualStyleBackColor = false;
            newMediumGameButton.Click += newMediumGameButton_Click;
            newMediumGameButton.PreviewKeyDown += Button_PreviewKeyDown;
            // 
            // newEasyGameButton
            // 
            newEasyGameButton.Anchor = AnchorStyles.None;
            newEasyGameButton.BackColor = Color.FromArgb(255, 100, 150);
            newEasyGameButton.Font = new Font("Times New Roman", 15F);
            newEasyGameButton.Location = new Point(64, 382);
            newEasyGameButton.Name = "newEasyGameButton";
            newEasyGameButton.Size = new Size(65, 37);
            newEasyGameButton.TabIndex = 9;
            newEasyGameButton.Text = "Easy";
            newEasyGameButton.UseVisualStyleBackColor = false;
            newEasyGameButton.Click += newEasyGameButton_Click;
            newEasyGameButton.PreviewKeyDown += Button_PreviewKeyDown;
            // 
            // pauseButton
            // 
            pauseButton.Anchor = AnchorStyles.None;
            pauseButton.BackColor = Color.FromArgb(255, 100, 150);
            pauseButton.Font = new Font("Times New Roman", 18.75F);
            pauseButton.Location = new Point(47, 343);
            pauseButton.Name = "pauseButton";
            pauseButton.Size = new Size(101, 38);
            pauseButton.TabIndex = 7;
            pauseButton.Text = "Pause";
            pauseButton.UseVisualStyleBackColor = false;
            pauseButton.Visible = false;
            pauseButton.Click += PauseButton_Click;
            pauseButton.PreviewKeyDown += Button_PreviewKeyDown;
            // 
            // newGameButton
            // 
            newGameButton.Anchor = AnchorStyles.None;
            newGameButton.BackColor = Color.FromArgb(255, 100, 150);
            newGameButton.Font = new Font("Times New Roman", 18.75F);
            newGameButton.Location = new Point(35, 404);
            newGameButton.Name = "newGameButton";
            newGameButton.Size = new Size(135, 38);
            newGameButton.TabIndex = 8;
            newGameButton.Text = "New Game";
            newGameButton.UseVisualStyleBackColor = false;
            newGameButton.Visible = false;
            newGameButton.Click += NewGame_Click;
            newGameButton.PreviewKeyDown += Button_PreviewKeyDown;
            // 
            // nextLabel
            // 
            nextLabel.Anchor = AnchorStyles.None;
            nextLabel.AutoSize = true;
            nextLabel.Font = new Font("Times New Roman", 20F, FontStyle.Bold, GraphicsUnit.Point, 238);
            nextLabel.Location = new Point(64, 184);
            nextLabel.Name = "nextLabel";
            nextLabel.Size = new Size(68, 31);
            nextLabel.TabIndex = 4;
            nextLabel.Text = "Next";
            nextLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // nextImage
            // 
            nextImage.Anchor = AnchorStyles.None;
            nextImage.BackColor = Color.Gray;
            nextImage.BackgroundImageLayout = ImageLayout.None;
            nextImage.BorderStyle = BorderStyle.FixedSingle;
            nextImage.Location = new Point(48, 228);
            nextImage.Name = "nextImage";
            nextImage.Size = new Size(100, 100);
            nextImage.SizeMode = PictureBoxSizeMode.Zoom;
            nextImage.TabIndex = 3;
            nextImage.TabStop = false;
            // 
            // scoreLabel
            // 
            scoreLabel.Anchor = AnchorStyles.None;
            scoreLabel.AutoSize = true;
            scoreLabel.Font = new Font("Times New Roman", 20F, FontStyle.Bold, GraphicsUnit.Point, 238);
            scoreLabel.Location = new Point(16, 47);
            scoreLabel.Name = "scoreLabel";
            scoreLabel.Size = new Size(165, 31);
            scoreLabel.TabIndex = 0;
            scoreLabel.Text = "Start Game! ";
            scoreLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // _openFileDialog
            // 
            _openFileDialog.Filter = "Text files (*.txt)|*.txt";
            _openFileDialog.Title = "Load game";
            // 
            // _saveFileDialog
            // 
            _saveFileDialog.Filter = "Text files (*.txt)|*.txt";
            _saveFileDialog.Title = "Save game";
            // 
            // TetrisDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 160, 200);
            ClientSize = new Size(784, 591);
            Controls.Add(tableLayoutPanel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MaximumSize = new Size(1000, 700);
            MinimumSize = new Size(700, 600);
            Name = "TetrisDialog";
            Text = "Tetris";
            Resize += TetrisDialog_Resize;
            tableLayoutPanel.ResumeLayout(false);
            leftPanel.ResumeLayout(false);
            leftPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)holdImage).EndInit();
            rightPanel.ResumeLayout(false);
            rightPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nextImage).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel;
        private Panel rightPanel;
        private Label scoreLabel;
        private Panel leftPanel;
        private PictureBox holdImage;
        private Label TetrisLabel;
        private Label nextLabel;
        private PictureBox nextImage;
        private Button saveButton;
        private Button loadButton;
        private Button pauseButton;
        private Panel canvasPanel;
        private Button newGameButton;
        private Button newMediumGameButton;
        private Button newEasyGameButton;
        private Button newHardGameButton;
        private OpenFileDialog _openFileDialog;
        private SaveFileDialog _saveFileDialog;
        private Button pinkButton;
    }
}
