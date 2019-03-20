namespace Kino_Pruefungsvorbereitung
{
    partial class SeatControllerUI
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
            this.priceLabel = new System.Windows.Forms.Label();
            this.premiumPriceLabel = new System.Windows.Forms.Label();
            this.costLabel = new System.Windows.Forms.Label();
            this.printButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // priceLabel
            // 
            this.priceLabel.AutoSize = true;
            this.priceLabel.Location = new System.Drawing.Point(12, 9);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(35, 13);
            this.priceLabel.TabIndex = 0;
            this.priceLabel.Text = "label1";
            // 
            // premiumPriceLabel
            // 
            this.premiumPriceLabel.AutoSize = true;
            this.premiumPriceLabel.Location = new System.Drawing.Point(12, 25);
            this.premiumPriceLabel.Name = "premiumPriceLabel";
            this.premiumPriceLabel.Size = new System.Drawing.Size(35, 13);
            this.premiumPriceLabel.TabIndex = 1;
            this.premiumPriceLabel.Text = "label1";
            // 
            // costLabel
            // 
            this.costLabel.AutoSize = true;
            this.costLabel.Location = new System.Drawing.Point(753, 9);
            this.costLabel.Name = "costLabel";
            this.costLabel.Size = new System.Drawing.Size(35, 13);
            this.costLabel.TabIndex = 2;
            this.costLabel.Text = "label1";
            // 
            // printButton
            // 
            this.printButton.Location = new System.Drawing.Point(253, 141);
            this.printButton.Name = "printButton";
            this.printButton.Size = new System.Drawing.Size(75, 23);
            this.printButton.TabIndex = 3;
            this.printButton.Text = "Print";
            this.printButton.UseVisualStyleBackColor = true;
            // 
            // SeatControllerUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.printButton);
            this.Controls.Add(this.costLabel);
            this.Controls.Add(this.premiumPriceLabel);
            this.Controls.Add(this.priceLabel);
            this.Name = "SeatControllerUI";
            this.Text = "SeatControllerUI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label priceLabel;
        private System.Windows.Forms.Label premiumPriceLabel;
        private System.Windows.Forms.Label costLabel;
        private System.Windows.Forms.Button printButton;
    }
}