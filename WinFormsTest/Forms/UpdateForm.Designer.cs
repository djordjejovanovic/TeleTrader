namespace WinFormsTest.Forms
{
    partial class UpdateForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            nameTb = new TextBox();
            tickerTb = new TextBox();
            isinTb = new TextBox();
            currencyCodeTb = new TextBox();
            priceTb = new TextBox();
            priceDateDp = new DateTimePicker();
            label7 = new Label();
            label8 = new Label();
            typeCb = new ComboBox();
            exchangeCb = new ComboBox();
            saveBtn = new Button();
            cancelBtn = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 24);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 0;
            label1.Text = "Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 64);
            label2.Name = "label2";
            label2.Size = new Size(41, 15);
            label2.TabIndex = 1;
            label2.Text = "Ticker:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(25, 102);
            label3.Name = "label3";
            label3.Size = new Size(28, 15);
            label3.TabIndex = 2;
            label3.Text = "Isin:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(25, 142);
            label4.Name = "label4";
            label4.Size = new Size(86, 15);
            label4.TabIndex = 3;
            label4.Text = "CurrencyCode:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(25, 188);
            label5.Name = "label5";
            label5.Size = new Size(36, 15);
            label5.TabIndex = 4;
            label5.Text = "Price:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(25, 224);
            label6.Name = "label6";
            label6.Size = new Size(60, 15);
            label6.TabIndex = 5;
            label6.Text = "PriceDate:";
            // 
            // nameTb
            // 
            nameTb.Location = new Point(162, 21);
            nameTb.Name = "nameTb";
            nameTb.Size = new Size(199, 23);
            nameTb.TabIndex = 6;
            // 
            // tickerTb
            // 
            tickerTb.Location = new Point(162, 61);
            tickerTb.Name = "tickerTb";
            tickerTb.Size = new Size(199, 23);
            tickerTb.TabIndex = 7;
            // 
            // isinTb
            // 
            isinTb.Location = new Point(162, 99);
            isinTb.Name = "isinTb";
            isinTb.Size = new Size(199, 23);
            isinTb.TabIndex = 8;
            // 
            // currencyCodeTb
            // 
            currencyCodeTb.Location = new Point(162, 142);
            currencyCodeTb.Name = "currencyCodeTb";
            currencyCodeTb.Size = new Size(199, 23);
            currencyCodeTb.TabIndex = 9;
            // 
            // priceTb
            // 
            priceTb.Location = new Point(162, 185);
            priceTb.Name = "priceTb";
            priceTb.Size = new Size(199, 23);
            priceTb.TabIndex = 10;
            // 
            // priceDateDp
            // 
            priceDateDp.Location = new Point(162, 224);
            priceDateDp.Name = "priceDateDp";
            priceDateDp.Size = new Size(199, 23);
            priceDateDp.TabIndex = 11;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(25, 276);
            label7.Name = "label7";
            label7.Size = new Size(34, 15);
            label7.TabIndex = 12;
            label7.Text = "Type:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(25, 317);
            label8.Name = "label8";
            label8.Size = new Size(61, 15);
            label8.TabIndex = 13;
            label8.Text = "Exchange:";
            // 
            // typeCb
            // 
            typeCb.FormattingEnabled = true;
            typeCb.Location = new Point(162, 273);
            typeCb.Name = "typeCb";
            typeCb.Size = new Size(199, 23);
            typeCb.TabIndex = 14;
            // 
            // exchangeCb
            // 
            exchangeCb.FormattingEnabled = true;
            exchangeCb.Location = new Point(162, 314);
            exchangeCb.Name = "exchangeCb";
            exchangeCb.Size = new Size(199, 23);
            exchangeCb.TabIndex = 15;
            // 
            // saveBtn
            // 
            saveBtn.Location = new Point(25, 370);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(86, 36);
            saveBtn.TabIndex = 16;
            saveBtn.Text = "Save";
            saveBtn.UseVisualStyleBackColor = true;
            saveBtn.Click += saveBtn_Click;
            // 
            // cancelBtn
            // 
            cancelBtn.Location = new Point(257, 370);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(104, 36);
            cancelBtn.TabIndex = 17;
            cancelBtn.Text = "Cancel";
            cancelBtn.UseVisualStyleBackColor = true;
            cancelBtn.Click += cancelBtn_Click;
            // 
            // UpdateForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(386, 450);
            Controls.Add(cancelBtn);
            Controls.Add(saveBtn);
            Controls.Add(exchangeCb);
            Controls.Add(typeCb);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(priceDateDp);
            Controls.Add(priceTb);
            Controls.Add(currencyCodeTb);
            Controls.Add(isinTb);
            Controls.Add(tickerTb);
            Controls.Add(nameTb);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "UpdateForm";
            Text = "Update Form";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        public int id;
        public TextBox nameTb;
        public TextBox tickerTb;
        public TextBox isinTb;
        public TextBox currencyCodeTb;
        public TextBox priceTb;
        public DateTimePicker priceDateDp;
        public Label label7;
        public Label label8;
        public ComboBox typeCb;
        public ComboBox exchangeCb;
        private Button saveBtn;
        private Button cancelBtn;
    }
}