
namespace Awari
{
    partial class GameForm
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
            this._menuStrip = new System.Windows.Forms.MenuStrip();
            this._menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this._menuFileNewGame = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this._menuFileLoadGame = new System.Windows.Forms.ToolStripMenuItem();
            this._menuFileSaveGame = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this._menuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this._menuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this._menuGameFour = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._menuGameEight = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this._menuGameTwelve = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this._openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this._saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this._menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _menuStrip
            // 
            this._menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuFile,
            this._menuSettings});
            this._menuStrip.Location = new System.Drawing.Point(0, 0);
            this._menuStrip.Name = "_menuStrip";
            this._menuStrip.Size = new System.Drawing.Size(984, 24);
            this._menuStrip.TabIndex = 0;
            this._menuStrip.Text = "menuStrip1";
            // 
            // _menuFile
            // 
            this._menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuFileNewGame,
            this.toolStripMenuItem1,
            this._menuFileLoadGame,
            this._menuFileSaveGame,
            this.toolStripMenuItem2,
            this._menuFileExit});
            this._menuFile.Name = "_menuFile";
            this._menuFile.Size = new System.Drawing.Size(37, 20);
            this._menuFile.Text = "File";
            // 
            // _menuFileNewGame
            // 
            this._menuFileNewGame.Name = "_menuFileNewGame";
            this._menuFileNewGame.Size = new System.Drawing.Size(160, 22);
            this._menuFileNewGame.Text = "Új játék";
            this._menuFileNewGame.Click += new System.EventHandler(this.MenuFileNewGame_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(157, 6);
            // 
            // _menuFileLoadGame
            // 
            this._menuFileLoadGame.Name = "_menuFileLoadGame";
            this._menuFileLoadGame.Size = new System.Drawing.Size(160, 22);
            this._menuFileLoadGame.Text = "Játék betöltése...";
            this._menuFileLoadGame.Click += new System.EventHandler(this.MenuFileLoadGame_Click);
            // 
            // _menuFileSaveGame
            // 
            this._menuFileSaveGame.Name = "_menuFileSaveGame";
            this._menuFileSaveGame.Size = new System.Drawing.Size(160, 22);
            this._menuFileSaveGame.Text = "Játék mentése";
            this._menuFileSaveGame.Click += new System.EventHandler(this.MenuFileSaveGame_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(157, 6);
            // 
            // _menuFileExit
            // 
            this._menuFileExit.Name = "_menuFileExit";
            this._menuFileExit.Size = new System.Drawing.Size(160, 22);
            this._menuFileExit.Text = "Kilépés";
            this._menuFileExit.Click += new System.EventHandler(this.MenuFileExit_Click);
            // 
            // _menuSettings
            // 
            this._menuSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuGameFour,
            this.toolStripSeparator1,
            this._menuGameEight,
            this.toolStripSeparator2,
            this._menuGameTwelve,
            this.toolStripSeparator3});
            this._menuSettings.Name = "_menuSettings";
            this._menuSettings.Size = new System.Drawing.Size(75, 20);
            this._menuSettings.Text = "Beállítások";
            // 
            // _menuGameFour
            // 
            this._menuGameFour.Name = "_menuGameFour";
            this._menuGameFour.Size = new System.Drawing.Size(183, 22);
            this._menuGameFour.Text = "Négyes játék (4)";
            this._menuGameFour.Click += new System.EventHandler(this.MenuGameFour_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(180, 6);
            // 
            // _menuGameEight
            // 
            this._menuGameEight.Name = "_menuGameEight";
            this._menuGameEight.Size = new System.Drawing.Size(183, 22);
            this._menuGameEight.Text = "Nyolcas játék (8)";
            this._menuGameEight.Click += new System.EventHandler(this.MenuGameEight_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(180, 6);
            // 
            // _menuGameTwelve
            // 
            this._menuGameTwelve.Name = "_menuGameTwelve";
            this._menuGameTwelve.Size = new System.Drawing.Size(183, 22);
            this._menuGameTwelve.Text = "Tizenkettes játék (12)";
            this._menuGameTwelve.Click += new System.EventHandler(this.MenuGameTwelve_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(180, 6);
            // 
            // _openFileDialog
            // 
            this._openFileDialog.Filter = "Awari tábla (*.awt)|*.awt";
            // 
            // _saveFileDialog
            // 
            this._saveFileDialog.Filter = "Awari table (*.awt)|*.awt";
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this._menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this._menuStrip;
            this.Name = "GameForm";
            this.Text = "Awari játék";
            this.Load += new System.EventHandler(this.GameForm_Load);
            this._menuStrip.ResumeLayout(false);
            this._menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip _menuStrip;
        private System.Windows.Forms.ToolStripMenuItem _menuFile;
        private System.Windows.Forms.ToolStripMenuItem _menuFileNewGame;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem _menuFileLoadGame;
        private System.Windows.Forms.ToolStripMenuItem _menuFileSaveGame;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem _menuFileExit;
        private System.Windows.Forms.ToolStripMenuItem _menuSettings;
        private System.Windows.Forms.ToolStripMenuItem _menuGameFour;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem _menuGameEight;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem _menuGameTwelve;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.OpenFileDialog _openFileDialog;
        private System.Windows.Forms.SaveFileDialog _saveFileDialog;
    }
}

