namespace GUICS
{
    partial class Communication
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
            this.components = new System.ComponentModel.Container();
            this.serialCOM = new System.IO.Ports.SerialPort(this.components);
            this.COM_NAME = new System.Windows.Forms.DomainUpDown();
            this.REF_BTN = new System.Windows.Forms.Button();
            this.RUN_BTN = new System.Windows.Forms.Button();
            this.CLOSE_BTN = new System.Windows.Forms.Button();
            this.status_label = new System.Windows.Forms.Label();
            this.STATUS_PANEL = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // serialCOM
            // 
            this.serialCOM.BaudRate = 115200;
            // 
            // COM_NAME
            // 
            this.COM_NAME.Location = new System.Drawing.Point(26, 34);
            this.COM_NAME.Name = "COM_NAME";
            this.COM_NAME.Size = new System.Drawing.Size(120, 22);
            this.COM_NAME.TabIndex = 0;
            this.COM_NAME.Text = "COM0";
            // 
            // REF_BTN
            // 
            this.REF_BTN.Location = new System.Drawing.Point(177, 28);
            this.REF_BTN.Name = "REF_BTN";
            this.REF_BTN.Size = new System.Drawing.Size(75, 32);
            this.REF_BTN.TabIndex = 1;
            this.REF_BTN.Text = "רענון";
            this.REF_BTN.UseVisualStyleBackColor = true;
            this.REF_BTN.Click += new System.EventHandler(this.REF_BTN_Click);
            // 
            // RUN_BTN
            // 
            this.RUN_BTN.Location = new System.Drawing.Point(38, 82);
            this.RUN_BTN.Name = "RUN_BTN";
            this.RUN_BTN.Size = new System.Drawing.Size(62, 32);
            this.RUN_BTN.TabIndex = 2;
            this.RUN_BTN.Text = "RUN";
            this.RUN_BTN.UseVisualStyleBackColor = true;
            this.RUN_BTN.Click += new System.EventHandler(this.RUN_BTN_Click);
            // 
            // CLOSE_BTN
            // 
            this.CLOSE_BTN.Location = new System.Drawing.Point(146, 82);
            this.CLOSE_BTN.Name = "CLOSE_BTN";
            this.CLOSE_BTN.Size = new System.Drawing.Size(62, 32);
            this.CLOSE_BTN.TabIndex = 3;
            this.CLOSE_BTN.Text = "CLOSE";
            this.CLOSE_BTN.UseVisualStyleBackColor = true;
            this.CLOSE_BTN.Click += new System.EventHandler(this.CLOSE_BTN_Click);
            // 
            // status_label
            // 
            this.status_label.AutoSize = true;
            this.status_label.Location = new System.Drawing.Point(237, 90);
            this.status_label.Name = "status_label";
            this.status_label.Size = new System.Drawing.Size(63, 17);
            this.status_label.TabIndex = 4;
            this.status_label.Text = "STATUS";
            // 
            // STATUS_PANEL
            // 
            this.STATUS_PANEL.BackColor = System.Drawing.Color.Red;
            this.STATUS_PANEL.Location = new System.Drawing.Point(306, 90);
            this.STATUS_PANEL.Name = "STATUS_PANEL";
            this.STATUS_PANEL.Size = new System.Drawing.Size(18, 19);
            this.STATUS_PANEL.TabIndex = 5;
            // 
            // Communication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 143);
            this.Controls.Add(this.STATUS_PANEL);
            this.Controls.Add(this.status_label);
            this.Controls.Add(this.CLOSE_BTN);
            this.Controls.Add(this.RUN_BTN);
            this.Controls.Add(this.REF_BTN);
            this.Controls.Add(this.COM_NAME);
            this.Name = "Communication";
            this.Text = "communication";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialCOM;
        private System.Windows.Forms.DomainUpDown COM_NAME;
        private System.Windows.Forms.Button REF_BTN;
        private System.Windows.Forms.Button RUN_BTN;
        private System.Windows.Forms.Button CLOSE_BTN;
        private System.Windows.Forms.Label status_label;
        private System.Windows.Forms.Panel STATUS_PANEL;
    }
}

