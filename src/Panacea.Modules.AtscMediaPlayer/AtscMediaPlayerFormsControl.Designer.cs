using MSVidCtlLib;

namespace Panacea.Modules.AtscMediaPlayer
{
    partial class AtscMediaPlayerFormsControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AtscMediaPlayerFormsControl));
            this.axMSVidCtl1 = new AxMSVidCtlLib.AxMSVidCtl();
            ((System.ComponentModel.ISupportInitialize)(this.axMSVidCtl1)).BeginInit();
            this.SuspendLayout();
            // 
            // axMSVidCtl1
            // 
            this.axMSVidCtl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axMSVidCtl1.Location = new System.Drawing.Point(0, 0);
            this.axMSVidCtl1.Name = "axMSVidCtl1";
            this.axMSVidCtl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMSVidCtl1.OcxState")));
            this.axMSVidCtl1.Size = new System.Drawing.Size(150, 150);
            this.axMSVidCtl1.TabIndex = 0;
            // 
            // AtscMediaPlayerFormsControl
            // 
            this.Controls.Add(this.axMSVidCtl1);
            this.Name = "AtscMediaPlayerFormsControl";
            ((System.ComponentModel.ISupportInitialize)(this.axMSVidCtl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public AxMSVidCtlLib.AxMSVidCtl axMSVidCtl1;
    }
}
