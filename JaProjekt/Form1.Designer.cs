
namespace JaProjekt
{
    partial class Form1
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
            this.runC = new System.Windows.Forms.Button();
            this.timerDisplay = new System.Windows.Forms.TextBox();
            this.runAsm = new System.Windows.Forms.Button();
            this.fileName = new System.Windows.Forms.TextBox();
            this.outputName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // runC
            // 
            this.runC.Location = new System.Drawing.Point(12, 134);
            this.runC.Name = "runC";
            this.runC.Size = new System.Drawing.Size(161, 79);
            this.runC.TabIndex = 0;
            this.runC.Text = "Run C# code";
            this.runC.UseVisualStyleBackColor = true;
            this.runC.Click += new System.EventHandler(this.runC_Click);
            // 
            // timerDisplay
            // 
            this.timerDisplay.Location = new System.Drawing.Point(12, 276);
            this.timerDisplay.Name = "timerDisplay";
            this.timerDisplay.ReadOnly = true;
            this.timerDisplay.Size = new System.Drawing.Size(277, 23);
            this.timerDisplay.TabIndex = 1;
            this.timerDisplay.TextChanged += new System.EventHandler(this.timerDisplay_TextChanged);
            // 
            // runAsm
            // 
            this.runAsm.Location = new System.Drawing.Point(179, 134);
            this.runAsm.Name = "runAsm";
            this.runAsm.Size = new System.Drawing.Size(161, 79);
            this.runAsm.TabIndex = 2;
            this.runAsm.Text = "Run ASM code";
            this.runAsm.UseVisualStyleBackColor = true;
            this.runAsm.Click += new System.EventHandler(this.runAsm_Click);
            // 
            // fileName
            // 
            this.fileName.Location = new System.Drawing.Point(12, 12);
            this.fileName.Name = "fileName";
            this.fileName.PlaceholderText = "Enter file name";
            this.fileName.Size = new System.Drawing.Size(190, 23);
            this.fileName.TabIndex = 3;
            this.fileName.TextChanged += new System.EventHandler(this.fileName_TextChanged);
            // 
            // outputName
            // 
            this.outputName.Location = new System.Drawing.Point(12, 42);
            this.outputName.Name = "outputName";
            this.outputName.PlaceholderText = "Enter output file name";
            this.outputName.Size = new System.Drawing.Size(190, 23);
            this.outputName.TabIndex = 4;
            this.outputName.TextChanged += new System.EventHandler(this.outputName_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 344);
            this.Controls.Add(this.outputName);
            this.Controls.Add(this.fileName);
            this.Controls.Add(this.runAsm);
            this.Controls.Add(this.timerDisplay);
            this.Controls.Add(this.runC);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button runC;
        private System.Windows.Forms.TextBox timerDisplay;
        private System.Windows.Forms.Button runAsm;
        private System.Windows.Forms.TextBox fileName;
        private System.Windows.Forms.TextBox outputName;
    }
}

