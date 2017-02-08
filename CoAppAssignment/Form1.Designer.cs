namespace CoAppAssignment
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
            this.textBoxTableName = new System.Windows.Forms.TextBox();
            this.btnShowTree = new System.Windows.Forms.Button();
            this.errLabel = new System.Windows.Forms.Label();
            this.textBoxNumberOfValuesPerKey = new System.Windows.Forms.TextBox();
            this.labelNumberOfValuesPerKey = new System.Windows.Forms.Label();
            this.labelTableName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxTableName
            // 
            this.textBoxTableName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTableName.Location = new System.Drawing.Point(687, 43);
            this.textBoxTableName.Name = "textBoxTableName";
            this.textBoxTableName.Size = new System.Drawing.Size(100, 20);
            this.textBoxTableName.TabIndex = 0;
            // 
            // btnShowTree
            // 
            this.btnShowTree.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowTree.Location = new System.Drawing.Point(687, 69);
            this.btnShowTree.Name = "btnShowTree";
            this.btnShowTree.Size = new System.Drawing.Size(100, 23);
            this.btnShowTree.TabIndex = 1;
            this.btnShowTree.Text = "Show Tree";
            this.btnShowTree.UseVisualStyleBackColor = true;
            this.btnShowTree.Click += new System.EventHandler(this.btnShowTree_Click);
            // 
            // errLabel
            // 
            this.errLabel.AutoSize = true;
            this.errLabel.Location = new System.Drawing.Point(613, 26);
            this.errLabel.Name = "errLabel";
            this.errLabel.Size = new System.Drawing.Size(0, 13);
            this.errLabel.TabIndex = 2;
            // 
            // textBoxNumberOfValuesPerKey
            // 
            this.textBoxNumberOfValuesPerKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxNumberOfValuesPerKey.Location = new System.Drawing.Point(686, 20);
            this.textBoxNumberOfValuesPerKey.Name = "textBoxNumberOfValuesPerKey";
            this.textBoxNumberOfValuesPerKey.Size = new System.Drawing.Size(100, 20);
            this.textBoxNumberOfValuesPerKey.TabIndex = 3;
            this.textBoxNumberOfValuesPerKey.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNumberOfValuesPerKey_KeyPress);
            // 
            // labelNumberOfValuesPerKey
            // 
            this.labelNumberOfValuesPerKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelNumberOfValuesPerKey.AutoSize = true;
            this.labelNumberOfValuesPerKey.Location = new System.Drawing.Point(492, 23);
            this.labelNumberOfValuesPerKey.Name = "labelNumberOfValuesPerKey";
            this.labelNumberOfValuesPerKey.Size = new System.Drawing.Size(189, 13);
            this.labelNumberOfValuesPerKey.TabIndex = 4;
            this.labelNumberOfValuesPerKey.Text = "Number Of Values Per Key (default 10)";
            // 
            // labelTableName
            // 
            this.labelTableName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTableName.AutoSize = true;
            this.labelTableName.Location = new System.Drawing.Point(613, 46);
            this.labelTableName.Name = "labelTableName";
            this.labelTableName.Size = new System.Drawing.Size(65, 13);
            this.labelTableName.TabIndex = 5;
            this.labelTableName.Text = "Table Name";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 498);
            this.Controls.Add(this.labelTableName);
            this.Controls.Add(this.labelNumberOfValuesPerKey);
            this.Controls.Add(this.textBoxNumberOfValuesPerKey);
            this.Controls.Add(this.errLabel);
            this.Controls.Add(this.btnShowTree);
            this.Controls.Add(this.textBoxTableName);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxTableName;
        private System.Windows.Forms.Button btnShowTree;
        private System.Windows.Forms.Label errLabel;
        private System.Windows.Forms.TextBox textBoxNumberOfValuesPerKey;
        private System.Windows.Forms.Label labelNumberOfValuesPerKey;
        private System.Windows.Forms.Label labelTableName;
    }
}

