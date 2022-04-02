
namespace OOP_laba_8
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.btnColor = new System.Windows.Forms.Button();
            this.rBtnCircle = new System.Windows.Forms.RadioButton();
            this.rBtnPolygon = new System.Windows.Forms.RadioButton();
            this.rBtnStar = new System.Windows.Forms.RadioButton();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnGroup = new System.Windows.Forms.Button();
            this.btnUngroup = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.checkStick = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(12, 42);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(763, 488);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // btnColor
            // 
            this.btnColor.BackColor = System.Drawing.SystemColors.ControlText;
            this.btnColor.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnColor.Location = new System.Drawing.Point(12, 12);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(75, 23);
            this.btnColor.TabIndex = 1;
            this.btnColor.UseVisualStyleBackColor = false;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // rBtnCircle
            // 
            this.rBtnCircle.AutoSize = true;
            this.rBtnCircle.Checked = true;
            this.rBtnCircle.Location = new System.Drawing.Point(93, 12);
            this.rBtnCircle.Name = "rBtnCircle";
            this.rBtnCircle.Size = new System.Drawing.Size(64, 21);
            this.rBtnCircle.TabIndex = 2;
            this.rBtnCircle.TabStop = true;
            this.rBtnCircle.Text = "Circle";
            this.rBtnCircle.UseVisualStyleBackColor = true;
            // 
            // rBtnPolygon
            // 
            this.rBtnPolygon.AutoSize = true;
            this.rBtnPolygon.Location = new System.Drawing.Point(163, 12);
            this.rBtnPolygon.Name = "rBtnPolygon";
            this.rBtnPolygon.Size = new System.Drawing.Size(80, 21);
            this.rBtnPolygon.TabIndex = 3;
            this.rBtnPolygon.TabStop = true;
            this.rBtnPolygon.Text = "Polygon";
            this.rBtnPolygon.UseVisualStyleBackColor = true;
            // 
            // rBtnStar
            // 
            this.rBtnStar.AutoSize = true;
            this.rBtnStar.Location = new System.Drawing.Point(249, 12);
            this.rBtnStar.Name = "rBtnStar";
            this.rBtnStar.Size = new System.Drawing.Size(55, 21);
            this.rBtnStar.TabIndex = 4;
            this.rBtnStar.TabStop = true;
            this.rBtnStar.Text = "Star";
            this.rBtnStar.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(310, 12);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnGroup
            // 
            this.btnGroup.Location = new System.Drawing.Point(391, 13);
            this.btnGroup.Name = "btnGroup";
            this.btnGroup.Size = new System.Drawing.Size(75, 23);
            this.btnGroup.TabIndex = 6;
            this.btnGroup.Text = "Group";
            this.btnGroup.UseVisualStyleBackColor = true;
            this.btnGroup.Click += new System.EventHandler(this.btnGroup_Click);
            // 
            // btnUngroup
            // 
            this.btnUngroup.Location = new System.Drawing.Point(472, 13);
            this.btnUngroup.Name = "btnUngroup";
            this.btnUngroup.Size = new System.Drawing.Size(75, 23);
            this.btnUngroup.TabIndex = 7;
            this.btnUngroup.Text = "Ungroup";
            this.btnUngroup.UseVisualStyleBackColor = true;
            this.btnUngroup.Click += new System.EventHandler(this.btnUngroup_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(553, 13);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(634, 13);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 9;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "txt";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // treeView1
            // 
            this.treeView1.HideSelection = false;
            this.treeView1.Location = new System.Drawing.Point(781, 13);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(443, 517);
            this.treeView1.TabIndex = 10;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // checkStick
            // 
            this.checkStick.AutoSize = true;
            this.checkStick.Location = new System.Drawing.Point(715, 15);
            this.checkStick.Name = "checkStick";
            this.checkStick.Size = new System.Drawing.Size(60, 21);
            this.checkStick.TabIndex = 11;
            this.checkStick.Text = "Stick";
            this.checkStick.UseMnemonic = false;
            this.checkStick.UseVisualStyleBackColor = true;
            this.checkStick.CheckedChanged += new System.EventHandler(this.checkStick_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1236, 542);
            this.Controls.Add(this.checkStick);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnUngroup);
            this.Controls.Add(this.btnGroup);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.rBtnStar);
            this.Controls.Add(this.rBtnPolygon);
            this.Controls.Add(this.rBtnCircle);
            this.Controls.Add(this.btnColor);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.RadioButton rBtnCircle;
        private System.Windows.Forms.RadioButton rBtnPolygon;
        private System.Windows.Forms.RadioButton rBtnStar;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnGroup;
        private System.Windows.Forms.Button btnUngroup;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.CheckBox checkStick;
    }
}

