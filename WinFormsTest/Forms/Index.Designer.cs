namespace WinFormsTest
{
    partial class Index
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
            dataGridView1 = new DataGridView();
            filterBtn = new Button();
            typeLbl = new Label();
            cbType = new ComboBox();
            openFileDialog1 = new OpenFileDialog();
            selectPathBtn = new Button();
            exchangeLbl = new Label();
            cbExchange = new ComboBox();
            addSymbolBtn = new Button();
            editSymbolBtn = new Button();
            deleteSymbolBtn = new Button();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 49);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(569, 324);
            dataGridView1.TabIndex = 0;
            // 
            // pretraziBtn
            // 
            filterBtn.Location = new Point(422, 3);
            filterBtn.Name = "FilterBtn";
            filterBtn.Size = new Size(121, 33);
            filterBtn.TabIndex = 1;
            filterBtn.Text = "Filter";
            filterBtn.UseVisualStyleBackColor = true;
            filterBtn.Visible = false;
            filterBtn.Click += filterButton_Click;
            // 
            // typeLbl
            // 
            typeLbl.AutoSize = true;
            typeLbl.Location = new Point(12, 12);
            typeLbl.Name = "typeLbl";
            typeLbl.Size = new Size(34, 15);
            typeLbl.TabIndex = 2;
            typeLbl.Text = "Type:";
            typeLbl.Visible = false;
            // 
            // cbType
            // 
            cbType.FormattingEnabled = true;
            cbType.Location = new Point(49, 9);
            cbType.Name = "cbType";
            cbType.Size = new Size(121, 23);
            cbType.TabIndex = 3;
            cbType.Visible = false;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog";
            // 
            // selectPathBtn
            // 
            selectPathBtn.Location = new Point(642, 49);
            selectPathBtn.Name = "selectPathBtn";
            selectPathBtn.Size = new Size(137, 44);
            selectPathBtn.TabIndex = 4;
            selectPathBtn.Text = "Izaberi DB";
            selectPathBtn.UseVisualStyleBackColor = true;
            selectPathBtn.Click += selectPathBtn_Click;
            // 
            // exchangeLbl
            // 
            exchangeLbl.AutoSize = true;
            exchangeLbl.Location = new Point(198, 12);
            exchangeLbl.Name = "exchangeLbl";
            exchangeLbl.Size = new Size(61, 15);
            exchangeLbl.TabIndex = 6;
            exchangeLbl.Text = "Exchange:";
            exchangeLbl.Visible = false;
            // 
            // cbExchange
            // 
            cbExchange.FormattingEnabled = true;
            cbExchange.Location = new Point(262, 9);
            cbExchange.Name = "cbExchange";
            cbExchange.Size = new Size(121, 23);
            cbExchange.TabIndex = 7;
            cbExchange.Visible = false;
            // 
            // addSymbolBtn
            // 
            addSymbolBtn.Location = new Point(12, 390);
            addSymbolBtn.Name = "addSymbolBtn";
            addSymbolBtn.Size = new Size(121, 39);
            addSymbolBtn.TabIndex = 9;
            addSymbolBtn.Text = "Add symbol";
            addSymbolBtn.UseVisualStyleBackColor = true;
            addSymbolBtn.Visible = false;
            addSymbolBtn.Click += addSymbol_Click;
            // 
            // editSymbolBtn
            // 
            editSymbolBtn.Location = new Point(215, 390);
            editSymbolBtn.Name = "editSymbolBtn";
            editSymbolBtn.Size = new Size(131, 39);
            editSymbolBtn.TabIndex = 10;
            editSymbolBtn.Text = "View/Edit symbol";
            editSymbolBtn.UseVisualStyleBackColor = true;
            editSymbolBtn.Visible = false;
            editSymbolBtn.Click += editSymbolBtn_Click;
            // 
            // deleteSymbolBtn
            // 
            deleteSymbolBtn.Location = new Point(448, 390);
            deleteSymbolBtn.Name = "deleteSymbolBtn";
            deleteSymbolBtn.Size = new Size(133, 39);
            deleteSymbolBtn.TabIndex = 11;
            deleteSymbolBtn.Text = "Delete symbol";
            deleteSymbolBtn.UseVisualStyleBackColor = true;
            deleteSymbolBtn.Visible = false;
            deleteSymbolBtn.Click += deleteButton_Click;
            // 
            // button1
            // 
            button1.Location = new Point(658, 390);
            button1.Name = "button1";
            button1.Size = new Size(121, 39);
            button1.TabIndex = 12;
            button1.Text = "Form Close";
            button1.UseVisualStyleBackColor = true;
            button1.Click += closeApplication_Click;
            // 
            // Index
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(deleteSymbolBtn);
            Controls.Add(editSymbolBtn);
            Controls.Add(addSymbolBtn);
            Controls.Add(cbExchange);
            Controls.Add(exchangeLbl);
            Controls.Add(selectPathBtn);
            Controls.Add(cbType);
            Controls.Add(typeLbl);
            Controls.Add(filterBtn);
            Controls.Add(dataGridView1);
            Name = "Index";
            Text = "Index";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button filterBtn;
        private Label typeLbl;
        private ComboBox cbType;
        private OpenFileDialog openFileDialog1;
        private Button selectPathBtn;
        private Label exchangeLbl;
        private ComboBox cbExchange;
        private Button addSymbolBtn;
        private Button editSymbolBtn;
        private Button deleteSymbolBtn;
        private Button button1;
    }
}