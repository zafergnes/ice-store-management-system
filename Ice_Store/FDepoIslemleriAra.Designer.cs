
namespace Ice_Store
{
    partial class FDepoIslemleriAra
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
            this.dvgUrunHareket = new System.Windows.Forms.DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            this.cbLoca = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbUrun = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbUrunSahibi = new System.Windows.Forms.ComboBox();
            this.btnSec = new System.Windows.Forms.Button();
            this.btnAra = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dvgUrunHareket)).BeginInit();
            this.SuspendLayout();
            // 
            // dvgUrunHareket
            // 
            this.dvgUrunHareket.AllowUserToAddRows = false;
            this.dvgUrunHareket.AllowUserToDeleteRows = false;
            this.dvgUrunHareket.AllowUserToResizeColumns = false;
            this.dvgUrunHareket.AllowUserToResizeRows = false;
            this.dvgUrunHareket.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgUrunHareket.Location = new System.Drawing.Point(17, 75);
            this.dvgUrunHareket.Margin = new System.Windows.Forms.Padding(2);
            this.dvgUrunHareket.Name = "dvgUrunHareket";
            this.dvgUrunHareket.ReadOnly = true;
            this.dvgUrunHareket.RowHeadersWidth = 51;
            this.dvgUrunHareket.RowTemplate.Height = 24;
            this.dvgUrunHareket.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dvgUrunHareket.Size = new System.Drawing.Size(831, 373);
            this.dvgUrunHareket.TabIndex = 99;
            this.dvgUrunHareket.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvgUrunHareket_CellClick);
            this.dvgUrunHareket.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvgUrunHareket_CellDoubleClick);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.Location = new System.Drawing.Point(529, 21);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 20);
            this.label10.TabIndex = 93;
            this.label10.Text = "Loca";
            // 
            // cbLoca
            // 
            this.cbLoca.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cbLoca.FormattingEnabled = true;
            this.cbLoca.Location = new System.Drawing.Point(578, 18);
            this.cbLoca.Name = "cbLoca";
            this.cbLoca.Size = new System.Drawing.Size(141, 28);
            this.cbLoca.TabIndex = 92;
            this.cbLoca.SelectedIndexChanged += new System.EventHandler(this.cbUrunSahibi_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(289, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 20);
            this.label1.TabIndex = 80;
            this.label1.Text = "Ürün";
            // 
            // cbUrun
            // 
            this.cbUrun.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cbUrun.FormattingEnabled = true;
            this.cbUrun.Location = new System.Drawing.Point(346, 18);
            this.cbUrun.Name = "cbUrun";
            this.cbUrun.Size = new System.Drawing.Size(141, 28);
            this.cbUrun.TabIndex = 79;
            this.cbUrun.SelectedIndexChanged += new System.EventHandler(this.cbUrunSahibi_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(16, 21);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 20);
            this.label5.TabIndex = 76;
            this.label5.Text = "Ürün Satan";
            // 
            // cbUrunSahibi
            // 
            this.cbUrunSahibi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cbUrunSahibi.FormattingEnabled = true;
            this.cbUrunSahibi.Location = new System.Drawing.Point(121, 18);
            this.cbUrunSahibi.Name = "cbUrunSahibi";
            this.cbUrunSahibi.Size = new System.Drawing.Size(141, 28);
            this.cbUrunSahibi.TabIndex = 75;
            this.cbUrunSahibi.SelectedIndexChanged += new System.EventHandler(this.cbUrunSahibi_SelectedIndexChanged);
            // 
            // btnSec
            // 
            this.btnSec.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSec.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSec.Location = new System.Drawing.Point(736, 452);
            this.btnSec.Margin = new System.Windows.Forms.Padding(2);
            this.btnSec.Name = "btnSec";
            this.btnSec.Padding = new System.Windows.Forms.Padding(11, 12, 11, 12);
            this.btnSec.Size = new System.Drawing.Size(112, 56);
            this.btnSec.TabIndex = 101;
            this.btnSec.Text = "Seç";
            this.btnSec.UseVisualStyleBackColor = true;
            this.btnSec.Click += new System.EventHandler(this.btnSec_Click);
            // 
            // btnAra
            // 
            this.btnAra.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAra.Image = global::Ice_Store.Properties.Resources._4213417_explore_find_glass_magnifier_search_icon;
            this.btnAra.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAra.Location = new System.Drawing.Point(765, 9);
            this.btnAra.Margin = new System.Windows.Forms.Padding(2);
            this.btnAra.Name = "btnAra";
            this.btnAra.Padding = new System.Windows.Forms.Padding(11, 12, 11, 12);
            this.btnAra.Size = new System.Drawing.Size(83, 57);
            this.btnAra.TabIndex = 100;
            this.btnAra.Text = "Ara";
            this.btnAra.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAra.UseVisualStyleBackColor = true;
            this.btnAra.Click += new System.EventHandler(this.cbUrunSahibi_SelectedIndexChanged);
            // 
            // FDepoIslemleriAra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 516);
            this.Controls.Add(this.btnSec);
            this.Controls.Add(this.btnAra);
            this.Controls.Add(this.dvgUrunHareket);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cbLoca);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbUrun);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbUrunSahibi);
            this.Name = "FDepoIslemleriAra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FDepoIslemleriAra";
            this.Load += new System.EventHandler(this.FDepoIslemleriAra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvgUrunHareket)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dvgUrunHareket;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbLoca;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbUrun;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbUrunSahibi;
        private System.Windows.Forms.Button btnSec;
        private System.Windows.Forms.Button btnAra;
    }
}