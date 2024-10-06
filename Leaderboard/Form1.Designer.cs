
namespace Leaderboard
{
   partial class Form1
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
         this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
         this.label1 = new System.Windows.Forms.Label();
         this.listView1 = new System.Windows.Forms.ListView();
         this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.trackHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.timeHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.materialHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.widthHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.timestampHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.groupBox2 = new System.Windows.Forms.GroupBox();
         this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
         this.track2Width = new System.Windows.Forms.Label();
         this.track2Material = new System.Windows.Forms.Label();
         this.track2staticwidth = new System.Windows.Forms.Label();
         this.track2staticmaterial = new System.Windows.Forms.Label();
         this.track2Time = new System.Windows.Forms.Label();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
         this.track1Material = new System.Windows.Forms.Label();
         this.track1Width = new System.Windows.Forms.Label();
         this.track1Time = new System.Windows.Forms.Label();
         this.track1staticwidth = new System.Windows.Forms.Label();
         this.track1staticmaterial = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.button1 = new System.Windows.Forms.Button();
         this.tableLayoutPanel1.SuspendLayout();
         this.groupBox2.SuspendLayout();
         this.tableLayoutPanel2.SuspendLayout();
         this.groupBox1.SuspendLayout();
         this.tableLayoutPanel3.SuspendLayout();
         this.SuspendLayout();
         // 
         // tableLayoutPanel1
         // 
         this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.tableLayoutPanel1.ColumnCount = 2;
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tableLayoutPanel1.Controls.Add(this.label1, 0, 3);
         this.tableLayoutPanel1.Controls.Add(this.listView1, 0, 2);
         this.tableLayoutPanel1.Controls.Add(this.groupBox2, 1, 1);
         this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 1);
         this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
         this.tableLayoutPanel1.Controls.Add(this.button1, 1, 3);
         this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
         this.tableLayoutPanel1.Name = "tableLayoutPanel1";
         this.tableLayoutPanel1.RowCount = 4;
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 36.84211F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 63.15789F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
         this.tableLayoutPanel1.Size = new System.Drawing.Size(1350, 912);
         this.tableLayoutPanel1.TabIndex = 4;
         // 
         // label1
         // 
         this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(3, 876);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(164, 36);
         this.label1.TabIndex = 5;
         this.label1.Text = "Arduino messages displayed here";
         this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // listView1
         // 
         this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.trackHeader,
            this.timeHeader,
            this.materialHeader,
            this.widthHeader,
            this.timestampHeader});
         this.tableLayoutPanel1.SetColumnSpan(this.listView1, 2);
         this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.listView1.FullRowSelect = true;
         this.listView1.HideSelection = false;
         this.listView1.Location = new System.Drawing.Point(3, 376);
         this.listView1.Name = "listView1";
         this.listView1.Size = new System.Drawing.Size(1344, 497);
         this.listView1.TabIndex = 4;
         this.listView1.UseCompatibleStateImageBehavior = false;
         this.listView1.View = System.Windows.Forms.View.Details;
         // 
         // columnHeader1
         // 
         this.columnHeader1.Width = 0;
         // 
         // trackHeader
         // 
         this.trackHeader.Text = "Track";
         this.trackHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
         this.trackHeader.Width = 160;
         // 
         // timeHeader
         // 
         this.timeHeader.Text = "Time (seconds)";
         this.timeHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
         this.timeHeader.Width = 200;
         // 
         // materialHeader
         // 
         this.materialHeader.Text = "Material";
         this.materialHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
         this.materialHeader.Width = 300;
         // 
         // widthHeader
         // 
         this.widthHeader.Text = "Width";
         this.widthHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
         this.widthHeader.Width = 300;
         // 
         // timestampHeader
         // 
         this.timestampHeader.Text = "Timestamp";
         this.timestampHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
         this.timestampHeader.Width = 360;
         // 
         // groupBox2
         // 
         this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBox2.Controls.Add(this.tableLayoutPanel2);
         this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.groupBox2.Location = new System.Drawing.Point(678, 83);
         this.groupBox2.Name = "groupBox2";
         this.groupBox2.Size = new System.Drawing.Size(669, 287);
         this.groupBox2.TabIndex = 3;
         this.groupBox2.TabStop = false;
         this.groupBox2.Text = "Track 2 Time";
         // 
         // tableLayoutPanel2
         // 
         this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.tableLayoutPanel2.ColumnCount = 2;
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
         this.tableLayoutPanel2.Controls.Add(this.track2Width, 1, 2);
         this.tableLayoutPanel2.Controls.Add(this.track2Material, 0, 2);
         this.tableLayoutPanel2.Controls.Add(this.track2staticwidth, 1, 1);
         this.tableLayoutPanel2.Controls.Add(this.track2staticmaterial, 0, 1);
         this.tableLayoutPanel2.Controls.Add(this.track2Time, 0, 0);
         this.tableLayoutPanel2.Location = new System.Drawing.Point(6, 35);
         this.tableLayoutPanel2.Name = "tableLayoutPanel2";
         this.tableLayoutPanel2.RowCount = 3;
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55F));
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.5F));
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.5F));
         this.tableLayoutPanel2.Size = new System.Drawing.Size(657, 243);
         this.tableLayoutPanel2.TabIndex = 7;
         // 
         // track2Width
         // 
         this.track2Width.Anchor = System.Windows.Forms.AnchorStyles.None;
         this.track2Width.AutoSize = true;
         this.track2Width.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.track2Width.Location = new System.Drawing.Point(492, 194);
         this.track2Width.Name = "track2Width";
         this.track2Width.Size = new System.Drawing.Size(0, 42);
         this.track2Width.TabIndex = 7;
         this.track2Width.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // track2Material
         // 
         this.track2Material.Anchor = System.Windows.Forms.AnchorStyles.None;
         this.track2Material.AutoSize = true;
         this.track2Material.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.track2Material.Location = new System.Drawing.Point(164, 194);
         this.track2Material.Name = "track2Material";
         this.track2Material.Size = new System.Drawing.Size(0, 42);
         this.track2Material.TabIndex = 6;
         this.track2Material.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // track2staticwidth
         // 
         this.track2staticwidth.Anchor = System.Windows.Forms.AnchorStyles.None;
         this.track2staticwidth.AutoSize = true;
         this.track2staticwidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.track2staticwidth.Location = new System.Drawing.Point(436, 139);
         this.track2staticwidth.Name = "track2staticwidth";
         this.track2staticwidth.Size = new System.Drawing.Size(113, 42);
         this.track2staticwidth.TabIndex = 5;
         this.track2staticwidth.Text = "Width";
         // 
         // track2staticmaterial
         // 
         this.track2staticmaterial.Anchor = System.Windows.Forms.AnchorStyles.None;
         this.track2staticmaterial.AutoSize = true;
         this.track2staticmaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.track2staticmaterial.Location = new System.Drawing.Point(89, 139);
         this.track2staticmaterial.Name = "track2staticmaterial";
         this.track2staticmaterial.Size = new System.Drawing.Size(150, 42);
         this.track2staticmaterial.TabIndex = 4;
         this.track2staticmaterial.Text = "Material";
         // 
         // track2Time
         // 
         this.track2Time.Anchor = System.Windows.Forms.AnchorStyles.None;
         this.track2Time.AutoSize = true;
         this.tableLayoutPanel2.SetColumnSpan(this.track2Time, 2);
         this.track2Time.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.track2Time.Location = new System.Drawing.Point(149, 12);
         this.track2Time.Name = "track2Time";
         this.track2Time.Size = new System.Drawing.Size(358, 108);
         this.track2Time.TabIndex = 2;
         this.track2Time.Text = "0.000 s";
         // 
         // groupBox1
         // 
         this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBox1.Controls.Add(this.tableLayoutPanel3);
         this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.groupBox1.Location = new System.Drawing.Point(3, 83);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(669, 287);
         this.groupBox1.TabIndex = 2;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Track 1 Time";
         // 
         // tableLayoutPanel3
         // 
         this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.tableLayoutPanel3.ColumnCount = 2;
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
         this.tableLayoutPanel3.Controls.Add(this.track1Material, 0, 2);
         this.tableLayoutPanel3.Controls.Add(this.track1Width, 1, 2);
         this.tableLayoutPanel3.Controls.Add(this.track1Time, 0, 0);
         this.tableLayoutPanel3.Controls.Add(this.track1staticwidth, 1, 1);
         this.tableLayoutPanel3.Controls.Add(this.track1staticmaterial, 0, 1);
         this.tableLayoutPanel3.Location = new System.Drawing.Point(6, 35);
         this.tableLayoutPanel3.Name = "tableLayoutPanel3";
         this.tableLayoutPanel3.RowCount = 3;
         this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55F));
         this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.5F));
         this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.5F));
         this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
         this.tableLayoutPanel3.Size = new System.Drawing.Size(657, 243);
         this.tableLayoutPanel3.TabIndex = 8;
         // 
         // track1Material
         // 
         this.track1Material.Anchor = System.Windows.Forms.AnchorStyles.None;
         this.track1Material.AutoSize = true;
         this.track1Material.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.track1Material.Location = new System.Drawing.Point(164, 194);
         this.track1Material.Name = "track1Material";
         this.track1Material.Size = new System.Drawing.Size(0, 42);
         this.track1Material.TabIndex = 11;
         this.track1Material.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // track1Width
         // 
         this.track1Width.Anchor = System.Windows.Forms.AnchorStyles.None;
         this.track1Width.AutoSize = true;
         this.track1Width.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.track1Width.Location = new System.Drawing.Point(492, 194);
         this.track1Width.Name = "track1Width";
         this.track1Width.Size = new System.Drawing.Size(0, 42);
         this.track1Width.TabIndex = 10;
         this.track1Width.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // track1Time
         // 
         this.track1Time.Anchor = System.Windows.Forms.AnchorStyles.None;
         this.track1Time.AutoSize = true;
         this.tableLayoutPanel3.SetColumnSpan(this.track1Time, 2);
         this.track1Time.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.track1Time.Location = new System.Drawing.Point(149, 12);
         this.track1Time.Name = "track1Time";
         this.track1Time.Size = new System.Drawing.Size(358, 108);
         this.track1Time.TabIndex = 8;
         this.track1Time.Text = "0.000 s";
         // 
         // track1staticwidth
         // 
         this.track1staticwidth.Anchor = System.Windows.Forms.AnchorStyles.None;
         this.track1staticwidth.AutoSize = true;
         this.track1staticwidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.track1staticwidth.Location = new System.Drawing.Point(436, 139);
         this.track1staticwidth.Name = "track1staticwidth";
         this.track1staticwidth.Size = new System.Drawing.Size(113, 42);
         this.track1staticwidth.TabIndex = 5;
         this.track1staticwidth.Text = "Width";
         // 
         // track1staticmaterial
         // 
         this.track1staticmaterial.Anchor = System.Windows.Forms.AnchorStyles.None;
         this.track1staticmaterial.AutoSize = true;
         this.track1staticmaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.track1staticmaterial.Location = new System.Drawing.Point(89, 139);
         this.track1staticmaterial.Name = "track1staticmaterial";
         this.track1staticmaterial.Size = new System.Drawing.Size(150, 42);
         this.track1staticmaterial.TabIndex = 4;
         this.track1staticmaterial.Text = "Material";
         // 
         // label2
         // 
         this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
         this.label2.AutoSize = true;
         this.tableLayoutPanel1.SetColumnSpan(this.label2, 2);
         this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label2.Location = new System.Drawing.Point(3, 3);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(1344, 73);
         this.label2.TabIndex = 6;
         this.label2.Text = "What material is fastest?";
         this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // button1
         // 
         this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.button1.Location = new System.Drawing.Point(1179, 879);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(168, 30);
         this.button1.TabIndex = 7;
         this.button1.Text = "Save Leaderboard and Clear";
         this.button1.UseVisualStyleBackColor = true;
         this.button1.Click += new System.EventHandler(this.button1_Click);
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.SystemColors.Window;
         this.ClientSize = new System.Drawing.Size(1374, 936);
         this.Controls.Add(this.tableLayoutPanel1);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.Name = "Form1";
         this.Text = "Leaderboard";
         this.tableLayoutPanel1.ResumeLayout(false);
         this.tableLayoutPanel1.PerformLayout();
         this.groupBox2.ResumeLayout(false);
         this.tableLayoutPanel2.ResumeLayout(false);
         this.tableLayoutPanel2.PerformLayout();
         this.groupBox1.ResumeLayout(false);
         this.tableLayoutPanel3.ResumeLayout(false);
         this.tableLayoutPanel3.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      private System.Windows.Forms.ListView listView1;
      private System.Windows.Forms.ColumnHeader columnHeader1;
      private System.Windows.Forms.ColumnHeader trackHeader;
      private System.Windows.Forms.ColumnHeader timeHeader;
      private System.Windows.Forms.ColumnHeader materialHeader;
      private System.Windows.Forms.ColumnHeader widthHeader;
      private System.Windows.Forms.ColumnHeader timestampHeader;
      private System.Windows.Forms.GroupBox groupBox2;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
      private System.Windows.Forms.Label track2Width;
      private System.Windows.Forms.Label track2Material;
      private System.Windows.Forms.Label track2staticwidth;
      private System.Windows.Forms.Label track2staticmaterial;
      private System.Windows.Forms.Label track2Time;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
      private System.Windows.Forms.Label track1Width;
      private System.Windows.Forms.Label track1Time;
      private System.Windows.Forms.Label track1staticwidth;
      private System.Windows.Forms.Label track1staticmaterial;
      private System.Windows.Forms.Label track1Material;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Button button1;
   }
}

