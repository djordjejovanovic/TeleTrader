namespace WinFormsTest.Forms
{
    partial class AddSymbolForm
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
            addNameTb = new TextBox();
            addNameLbl = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            tickerTb = new TextBox();
            isinTb = new TextBox();
            currencyCodeTb = new TextBox();
            priceTb = new TextBox();
            typeCb = new ComboBox();
            exchangeCb = new ComboBox();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // addNameTb
            // 
            addNameTb.Location = new Point(174, 23);
            addNameTb.Name = "addNameTb";
            addNameTb.Size = new Size(121, 23);
            addNameTb.TabIndex = 0;
            // 
            // addNameLbl
            // 
            addNameLbl.AutoSize = true;
            addNameLbl.Location = new Point(29, 26);
            addNameLbl.Name = "addNameLbl";
            addNameLbl.Size = new Size(42, 15);
            addNameLbl.TabIndex = 1;
            addNameLbl.Text = "Name:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 70);
            label1.Name = "label1";
            label1.Size = new Size(41, 15);
            label1.TabIndex = 2;
            label1.Text = "Ticker:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(29, 114);
            label2.Name = "label2";
            label2.Size = new Size(28, 15);
            label2.TabIndex = 3;
            label2.Text = "Isin:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(29, 165);
            label3.Name = "label3";
            label3.Size = new Size(86, 15);
            label3.TabIndex = 4;
            label3.Text = "CurrencyCode:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(29, 214);
            label4.Name = "label4";
            label4.Size = new Size(36, 15);
            label4.TabIndex = 5;
            label4.Text = "Price:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(29, 260);
            label5.Name = "label5";
            label5.Size = new Size(34, 15);
            label5.TabIndex = 6;
            label5.Text = "Type:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(29, 311);
            label6.Name = "label6";
            label6.Size = new Size(61, 15);
            label6.TabIndex = 7;
            label6.Text = "Exchange:";
            // 
            // tickerTb
            // 
            tickerTb.Location = new Point(174, 62);
            tickerTb.Name = "tickerTb";
            tickerTb.Size = new Size(121, 23);
            tickerTb.TabIndex = 8;
            // 
            // isinTb
            // 
            isinTb.Location = new Point(174, 111);
            isinTb.Name = "isinTb";
            isinTb.Size = new Size(121, 23);
            isinTb.TabIndex = 9;
            // 
            // currencyCodeTb
            // 
            currencyCodeTb.Location = new Point(174, 162);
            currencyCodeTb.Name = "currencyCodeTb";
            currencyCodeTb.Size = new Size(121, 23);
            currencyCodeTb.TabIndex = 10;
            // 
            // priceTb
            // 
            priceTb.Location = new Point(174, 206);
            priceTb.Name = "priceTb";
            priceTb.Size = new Size(121, 23);
            priceTb.TabIndex = 11;
            // 
            // typeCb
            // 
            typeCb.FormattingEnabled = true;
            typeCb.Location = new Point(174, 257);
            typeCb.Name = "typeCb";
            typeCb.Size = new Size(121, 23);
            typeCb.TabIndex = 12;
            // 
            // exchangeCb
            // 
            exchangeCb.FormattingEnabled = true;
            exchangeCb.Location = new Point(174, 303);
            exchangeCb.Name = "exchangeCb";
            exchangeCb.Size = new Size(121, 23);
            exchangeCb.TabIndex = 13;
            // 
            // button1
            // 
            button1.Location = new Point(29, 369);
            button1.Name = "button1";
            button1.Size = new Size(86, 32);
            button1.TabIndex = 14;
            button1.Text = "Save";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(204, 369);
            button2.Name = "button2";
            button2.Size = new Size(91, 32);
            button2.TabIndex = 15;
            button2.Text = "Cancel";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // AddSymbolForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(365, 427);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(exchangeCb);
            Controls.Add(typeCb);
            Controls.Add(priceTb);
            Controls.Add(currencyCodeTb);
            Controls.Add(isinTb);
            Controls.Add(tickerTb);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(addNameLbl);
            Controls.Add(addNameTb);
            Name = "AddSymbolForm";
            Text = "AddSymbolForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox addNameTb;
        private Label addNameLbl;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox tickerTb;
        private TextBox isinTb;
        private TextBox currencyCodeTb;
        private TextBox priceTb;
        public ComboBox typeCb;
        public ComboBox exchangeCb;
        private Button button1;
        private Button button2;
    }
}