namespace CarQuotaNoPickPublic
{
    using CarQuotaNoPickPublic.Properties;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;

    public class FrmMain : Form
    {
        private IContainer components;
        private Button ConfirmButton;
        private Button ControlExitButton;
        private System.Windows.Forms.DataGridView DataGridView;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label8;
        private DataGridViewTextBoxColumn PickNO;
        private Button PickNumberButton;
        private int[] poolNO;
        private DataGridViewTextBoxColumn PoolNO;
        private TextBox PoolNOTextBox;
        private int quotaNumber;
        private TextBox QuotaNumberTextBox;
        private TextBox SeedNumericTextBox;
        private Regex sixNumberCodeRegex;
        private int totalNumber;
        private TextBox TotalNumberTextBox;
        private Button UserHelpButton;

        public FrmMain()
        {
            this.InitializeComponent();
            this.sixNumberCodeRegex = new Regex(@"^\d{6}$");
            this.poolNO = new int[1];
            this.totalNumber = 0;
            this.quotaNumber = 0;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void CloseButton_MouseEnter(object sender, EventArgs e)
        {
        }

        private void CloseButton_MouseLeave(object sender, EventArgs e)
        {
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            this.ConfirmFuntion();
        }

        private void ConfirmButton_MouseEnter(object sender, EventArgs e)
        {
        }

        private void ConfirmButton_MouseLeave(object sender, EventArgs e)
        {
            bool enabled = this.ConfirmButton.Enabled;
        }

        private void ConfirmFuntion()
        {
            if (this.DataGridView.Rows.Count == 0)
            {
                MessageBox.Show("没指标配置演算数据，请先演算！");
            }
            else if (this.PoolNOTextBox.Text == string.Empty)
            {
                MessageBox.Show("没输入摇号基数序号，请输入正整数！");
                this.PoolNOTextBox.Focus();
            }
            else
            {
                this.poolNO[0] = Convert.ToInt32(this.PoolNOTextBox.Text);
                if (this.poolNO[0] == 0)
                {
                    MessageBox.Show("输入摇号基数序号不应该等于零，请重输！");
                    this.PoolNOTextBox.Focus();
                }
                else if (this.totalNumber < this.poolNO[0])
                {
                    MessageBox.Show("输入摇号基数序号已经大于有效申请编码总数，请重输！");
                    this.PoolNOTextBox.Focus();
                }
                else if ((this.poolNO[0] != 0) && (this.DataGridView.Rows.Count > 0))
                {
                    int num = 0;
                    num = 0;
                    while (num < this.DataGridView.Rows.Count)
                    {
                        if (this.DataGridView.Rows[num].Cells[1].Value.ToString() == this.poolNO[0].ToString())
                        {
                            foreach (DataGridViewRow row in this.DataGridView.SelectedRows)
                            {
                                row.Selected = false;
                            }
                            this.DataGridView.Rows[num].Selected = true;
                            this.DataGridView.FirstDisplayedScrollingRowIndex = num;
                            break;
                        }
                        num++;
                    }
                    if (num >= this.DataGridView.Rows.Count)
                    {
                        MessageBox.Show("摇号基数序号" + this.poolNO[0].ToString() + "没有找到！");
                    }
                }
            }
        }

        private void ControlExitButton_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void ControlExitButton_MouseEnter(object sender, EventArgs e)
        {
            this.ControlExitButton.BackgroundImage = Resources.main_close2;
        }

        private void ControlExitButton_MouseLeave(object sender, EventArgs e)
        {
            this.ControlExitButton.BackgroundImage = Resources.main_close;
        }

        private void DataGridView_MouseClick(object sender, MouseEventArgs e)
        {
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void FrmMain_Resize(object sender, EventArgs e)
        {
            this.SetDataGridViewLength();
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            DataGridViewCellStyle style2 = new DataGridViewCellStyle();
            DataGridViewCellStyle style3 = new DataGridViewCellStyle();
            DataGridViewCellStyle style4 = new DataGridViewCellStyle();
            DataGridViewCellStyle style5 = new DataGridViewCellStyle();
            DataGridViewCellStyle style6 = new DataGridViewCellStyle();
            this.label1 = new Label();
            this.ControlExitButton = new Button();
            this.PickNumberButton = new Button();
            this.TotalNumberTextBox = new TextBox();
            this.label6 = new Label();
            this.label8 = new Label();
            this.SeedNumericTextBox = new TextBox();
            this.DataGridView = new System.Windows.Forms.DataGridView();
            this.PickNO = new DataGridViewTextBoxColumn();
            this.PoolNO = new DataGridViewTextBoxColumn();
            this.UserHelpButton = new Button();
            this.ConfirmButton = new Button();
            this.PoolNOTextBox = new TextBox();
            this.label4 = new Label();
            this.label3 = new Label();
            this.label5 = new Label();
            this.QuotaNumberTextBox = new TextBox();
            this.label2 = new Label();
            ((ISupportInitialize) this.DataGridView).BeginInit();
            base.SuspendLayout();
            this.label1.AutoSize = true;
            this.label1.BackColor = Color.Transparent;
            this.label1.Font = new Font("宋体", 16f, FontStyle.Bold, GraphicsUnit.Pixel);
            this.label1.ForeColor = Color.FromArgb(0x4b, 0x7d, 0x9e);
            this.label1.Location = new Point(0x29, 11);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x7f, 0x10);
            this.label1.TabIndex = 0;
            this.label1.Text = "无阶梯摇号程序";
            this.ControlExitButton.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.ControlExitButton.BackColor = Color.Transparent;
            this.ControlExitButton.BackgroundImage = Resources.main_close;
            this.ControlExitButton.BackgroundImageLayout = ImageLayout.Stretch;
            this.ControlExitButton.FlatAppearance.BorderSize = 0;
            this.ControlExitButton.FlatStyle = FlatStyle.Flat;
            this.ControlExitButton.Location = new Point(0x3e3, 2);
            this.ControlExitButton.Name = "ControlExitButton";
            this.ControlExitButton.Size = new Size(0x1c, 20);
            this.ControlExitButton.TabIndex = 0x3e;
            this.ControlExitButton.TabStop = false;
            this.ControlExitButton.UseVisualStyleBackColor = false;
            this.ControlExitButton.MouseLeave += new EventHandler(this.ControlExitButton_MouseLeave);
            this.ControlExitButton.Click += new EventHandler(this.ControlExitButton_Click);
            this.ControlExitButton.MouseEnter += new EventHandler(this.ControlExitButton_MouseEnter);
            this.PickNumberButton.BackColor = Color.Transparent;
            this.PickNumberButton.BackgroundImage = Resources.main_btn4;
            this.PickNumberButton.BackgroundImageLayout = ImageLayout.Stretch;
            this.PickNumberButton.FlatAppearance.BorderSize = 0;
            this.PickNumberButton.FlatStyle = FlatStyle.Flat;
            this.PickNumberButton.Font = new Font("宋体", 14f, FontStyle.Bold, GraphicsUnit.Pixel, 0x86);
            this.PickNumberButton.ForeColor = Color.White;
            this.PickNumberButton.Location = new Point(0x305, 0x39);
            this.PickNumberButton.Name = "PickNumberButton";
            this.PickNumberButton.Size = new Size(0x49, 0x17);
            this.PickNumberButton.TabIndex = 3;
            this.PickNumberButton.Text = "计  算";
            this.PickNumberButton.UseVisualStyleBackColor = false;
            this.PickNumberButton.MouseLeave += new EventHandler(this.PickNumberButton_MouseLeave);
            this.PickNumberButton.Click += new EventHandler(this.PickNumberButton_Click);
            this.PickNumberButton.MouseEnter += new EventHandler(this.PickNumberButton_MouseEnter);
            this.TotalNumberTextBox.BackColor = Color.White;
            this.TotalNumberTextBox.BorderStyle = BorderStyle.None;
            this.TotalNumberTextBox.Font = new Font("宋体", 14f, FontStyle.Regular, GraphicsUnit.Pixel, 0x86);
            this.TotalNumberTextBox.Location = new Point(160, 0x3d);
            this.TotalNumberTextBox.Margin = new Padding(2);
            this.TotalNumberTextBox.Name = "TotalNumberTextBox";
            this.TotalNumberTextBox.Size = new Size(0x83, 0x10);
            this.TotalNumberTextBox.TabIndex = 0;
            this.TotalNumberTextBox.KeyPress += new KeyPressEventHandler(this.TotalNumberTextBox_KeyPress);
            this.label6.AutoSize = true;
            this.label6.BackColor = Color.Transparent;
            this.label6.Font = new Font("宋体", 14f, FontStyle.Bold, GraphicsUnit.Pixel, 0x86);
            this.label6.ForeColor = Color.FromArgb(0x4b, 0x7d, 0x9e);
            this.label6.Location = new Point(0x12a, 0x3d);
            this.label6.Margin = new Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new Size(0x70, 14);
            this.label6.TabIndex = 0x43;
            this.label6.Text = "配置指标个数：";
            this.label8.AutoSize = true;
            this.label8.BackColor = Color.Transparent;
            this.label8.Font = new Font("宋体", 14f, FontStyle.Bold, GraphicsUnit.Pixel, 0x86);
            this.label8.ForeColor = Color.FromArgb(0x4b, 0x7d, 0x9e);
            this.label8.Location = new Point(0x23, 0x3d);
            this.label8.Margin = new Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new Size(0x7f, 14);
            this.label8.TabIndex = 0x44;
            this.label8.Text = "摇号池编码总数：";
            this.SeedNumericTextBox.BackColor = Color.White;
            this.SeedNumericTextBox.BorderStyle = BorderStyle.None;
            this.SeedNumericTextBox.Font = new Font("宋体", 14f, FontStyle.Regular, GraphicsUnit.Pixel, 0x86);
            this.SeedNumericTextBox.Location = new Point(0x289, 0x3d);
            this.SeedNumericTextBox.Margin = new Padding(2);
            this.SeedNumericTextBox.Name = "SeedNumericTextBox";
            this.SeedNumericTextBox.Size = new Size(0x6c, 0x10);
            this.SeedNumericTextBox.TabIndex = 2;
            this.SeedNumericTextBox.Leave += new EventHandler(this.SeedNumericTextBox_Leave);
            this.SeedNumericTextBox.KeyPress += new KeyPressEventHandler(this.SeedNumericTextBox_KeyPress);
            this.DataGridView.AllowUserToAddRows = false;
            this.DataGridView.AllowUserToDeleteRows = false;
            style.BackColor = Color.FromArgb(0xe7, 0xf7, 0xfd);
            style.Font = new Font("宋体", 14f, FontStyle.Regular, GraphicsUnit.Pixel, 0x86);
            style.ForeColor = Color.Navy;
            this.DataGridView.AlternatingRowsDefaultCellStyle = style;
            this.DataGridView.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.DataGridView.BackgroundColor = Color.White;
            style2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            style2.BackColor = Color.FromArgb(0xe7, 0xf7, 0xfd);
            style2.Font = new Font("宋体", 14f, FontStyle.Regular, GraphicsUnit.Pixel, 0x86);
            style2.ForeColor = Color.Navy;
            style2.SelectionBackColor = Color.FromArgb(0x4c, 0x7d, 0x9e);
            style2.SelectionForeColor = SystemColors.HighlightText;
            style2.WrapMode = DataGridViewTriState.True;
            this.DataGridView.ColumnHeadersDefaultCellStyle = style2;
            this.DataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView.Columns.AddRange(new DataGridViewColumn[] { this.PickNO, this.PoolNO });
            style3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            style3.BackColor = Color.White;
            style3.Font = new Font("宋体", 14f, FontStyle.Regular, GraphicsUnit.Pixel, 0x86);
            style3.ForeColor = Color.Navy;
            style3.SelectionBackColor = Color.FromArgb(0x4c, 0x7d, 0x9e);
            style3.SelectionForeColor = SystemColors.HighlightText;
            style3.WrapMode = DataGridViewTriState.False;
            this.DataGridView.DefaultCellStyle = style3;
            this.DataGridView.EnableHeadersVisualStyles = false;
            this.DataGridView.Location = new Point(0x15, 0x97);
            this.DataGridView.Margin = new Padding(2);
            this.DataGridView.Name = "DataGridView";
            this.DataGridView.ReadOnly = true;
            style4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            style4.BackColor = Color.FromArgb(0xe7, 0xf7, 0xfd);
            style4.Font = new Font("宋体", 14f, FontStyle.Regular, GraphicsUnit.Pixel, 0x86);
            style4.ForeColor = SystemColors.WindowText;
            style4.SelectionBackColor = Color.FromArgb(0x4c, 0x7d, 0x9e);
            style4.SelectionForeColor = SystemColors.HighlightText;
            style4.WrapMode = DataGridViewTriState.True;
            this.DataGridView.RowHeadersDefaultCellStyle = style4;
            this.DataGridView.RowTemplate.DefaultCellStyle.Font = new Font("宋体", 14f, FontStyle.Regular, GraphicsUnit.Pixel, 0x86);
            this.DataGridView.RowTemplate.Height = 0x17;
            this.DataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DataGridView.Size = new Size(0x3d5, 0x194);
            this.DataGridView.TabIndex = 70;
            this.DataGridView.MouseClick += new MouseEventHandler(this.DataGridView_MouseClick);
            this.PickNO.DataPropertyName = "PickNO";
            style5.Format = "##########";
            style5.NullValue = null;
            this.PickNO.DefaultCellStyle = style5;
            this.PickNO.HeaderText = "序号";
            this.PickNO.Name = "PickNO";
            this.PickNO.ReadOnly = true;
            this.PickNO.SortMode = DataGridViewColumnSortMode.NotSortable;
            this.PickNO.Width = 300;
            this.PoolNO.DataPropertyName = "PoolNO";
            style6.Format = "##########";
            style6.NullValue = null;
            this.PoolNO.DefaultCellStyle = style6;
            this.PoolNO.HeaderText = "摇号基数序号";
            this.PoolNO.Name = "PoolNO";
            this.PoolNO.ReadOnly = true;
            this.PoolNO.SortMode = DataGridViewColumnSortMode.NotSortable;
            this.PoolNO.Width = 300;
            this.UserHelpButton.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.UserHelpButton.BackColor = Color.Transparent;
            this.UserHelpButton.FlatAppearance.BorderSize = 0;
            this.UserHelpButton.FlatStyle = FlatStyle.Flat;
            this.UserHelpButton.Font = new Font("宋体", 14f, FontStyle.Underline, GraphicsUnit.Pixel, 0x86);
            this.UserHelpButton.ForeColor = Color.LightSlateGray;
            this.UserHelpButton.Location = new Point(0x47, 0x23c);
            this.UserHelpButton.Name = "UserHelpButton";
            this.UserHelpButton.Size = new Size(0x52, 0x1b);
            this.UserHelpButton.TabIndex = 0x48;
            this.UserHelpButton.Text = "使用说明";
            this.UserHelpButton.UseVisualStyleBackColor = false;
            this.UserHelpButton.Visible = false;
            this.ConfirmButton.BackColor = Color.Transparent;
            this.ConfirmButton.BackgroundImage = Resources.main_btn2;
            this.ConfirmButton.FlatAppearance.BorderSize = 0;
            this.ConfirmButton.FlatStyle = FlatStyle.Flat;
            this.ConfirmButton.Font = new Font("宋体", 14f, FontStyle.Bold, GraphicsUnit.Pixel, 0x86);
            this.ConfirmButton.ForeColor = Color.White;
            this.ConfirmButton.Location = new Point(0x1f1, 0x71);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new Size(0x49, 0x18);
            this.ConfirmButton.TabIndex = 5;
            this.ConfirmButton.Text = "查  询";
            this.ConfirmButton.UseVisualStyleBackColor = false;
            this.ConfirmButton.MouseLeave += new EventHandler(this.ConfirmButton_MouseLeave);
            this.ConfirmButton.Click += new EventHandler(this.ConfirmButton_Click);
            this.ConfirmButton.MouseEnter += new EventHandler(this.ConfirmButton_MouseEnter);
            this.PoolNOTextBox.BorderStyle = BorderStyle.FixedSingle;
            this.PoolNOTextBox.Font = new Font("宋体", 14f, FontStyle.Regular, GraphicsUnit.Pixel, 0x86);
            this.PoolNOTextBox.Location = new Point(160, 0x73);
            this.PoolNOTextBox.Name = "PoolNOTextBox";
            this.PoolNOTextBox.Size = new Size(0x149, 0x17);
            this.PoolNOTextBox.TabIndex = 4;
            this.PoolNOTextBox.KeyPress += new KeyPressEventHandler(this.PoolNOTextBox_KeyPress);
            this.label4.AutoSize = true;
            this.label4.BackColor = Color.Transparent;
            this.label4.Font = new Font("宋体", 14f, FontStyle.Bold, GraphicsUnit.Pixel, 0x86);
            this.label4.ForeColor = Color.FromArgb(0x4b, 0x7d, 0x9e);
            this.label4.Location = new Point(0x16, 0x77);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x8e, 14);
            this.label4.TabIndex = 0x4e;
            this.label4.Text = "我的摇号基数序号：";
            this.label3.BackColor = Color.Transparent;
            this.label3.Font = new Font("宋体", 12f, FontStyle.Regular, GraphicsUnit.Pixel, 0x86);
            this.label3.ForeColor = Color.FromArgb(0x4b, 0x7d, 0x9e);
            this.label3.Location = new Point(0x2bb, 0x2c1);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x12f, 0x10);
            this.label3.TabIndex = 0x4f;
            this.label3.Text = "版权所有 (C) 北京市小客车指标调控管理办公室 2011";
            this.label5.AutoSize = true;
            this.label5.BackColor = Color.Transparent;
            this.label5.Font = new Font("宋体", 14f, FontStyle.Bold, GraphicsUnit.Pixel, 0x86);
            this.label5.ForeColor = Color.FromArgb(0x4b, 0x7d, 0x9e);
            this.label5.Location = new Point(0x214, 0x3d);
            this.label5.Margin = new Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new Size(120, 14);
            this.label5.TabIndex = 90;
            this.label5.Text = "6位随机种子数：";
            this.QuotaNumberTextBox.BorderStyle = BorderStyle.None;
            this.QuotaNumberTextBox.Font = new Font("宋体", 14f, FontStyle.Regular, GraphicsUnit.Pixel, 0x86);
            this.QuotaNumberTextBox.Location = new Point(0x197, 0x3d);
            this.QuotaNumberTextBox.Name = "QuotaNumberTextBox";
            this.QuotaNumberTextBox.Size = new Size(0x74, 0x10);
            this.QuotaNumberTextBox.TabIndex = 0x5e;
            this.label2.BackColor = Color.Transparent;
            this.label2.Font = new Font("宋体", 12f, FontStyle.Regular, GraphicsUnit.Pixel, 0x86);
            this.label2.ForeColor = Color.FromArgb(0x4b, 0x7d, 0x9e);
            this.label2.Location = new Point(0x16d, 0x243);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x12f, 0x10);
            this.label2.TabIndex = 0x5f;
            this.label2.Text = "版权所有 (C) 北京市小客车指标调控管理办公室 2013";
            base.AutoScaleDimensions = new SizeF(7f, 14f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackgroundImage = Resources.main_bg;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            base.ClientSize = new Size(0x400, 600);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.QuotaNumberTextBox);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.PoolNOTextBox);
            base.Controls.Add(this.UserHelpButton);
            base.Controls.Add(this.ConfirmButton);
            base.Controls.Add(this.DataGridView);
            base.Controls.Add(this.SeedNumericTextBox);
            base.Controls.Add(this.TotalNumberTextBox);
            base.Controls.Add(this.PickNumberButton);
            base.Controls.Add(this.ControlExitButton);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.label4);
            base.Controls.Add(this.label8);
            base.Controls.Add(this.label6);
            base.Controls.Add(this.label5);
            this.DoubleBuffered = true;
            this.Font = new Font("宋体", 14f, FontStyle.Regular, GraphicsUnit.Pixel, 0x86);
            base.FormBorderStyle = FormBorderStyle.None;
            base.Margin = new Padding(5);
            base.Name = "FrmMain";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "北京市小客车指标调控管理信息系统指标配软件公众演算版";
            base.Resize += new EventHandler(this.FrmMain_Resize);
            ((ISupportInitialize) this.DataGridView).EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void PickDataNumber(AllRandomPickData allRandomPickData)
        {
            if (allRandomPickData != null)
            {
                try
                {
                    AllRandomPick pick = new AllRandomPick();
                    pick.GetRandomNumber(allRandomPickData);
                    PickNumberDataSet pickNumberDataSet = new PickNumberDataSet();
                    pick.SetPickNumberDataSet(allRandomPickData.PickNumber, pickNumberDataSet);
                    this.ShowDataSet(pickNumberDataSet.DataSet);
                }
                catch
                {
                    MessageBox.Show("使用输入的值，运算超时，请选用合适的参数！");
                }
            }
        }

        private void PickNumberButton_Click(object sender, EventArgs e)
        {
            if (this.TotalNumberTextBox.Text == string.Empty)
            {
                MessageBox.Show("没输入有效申请编码总数，请输入正整数！");
                this.TotalNumberTextBox.Focus();
            }
            else if (this.QuotaNumberTextBox.Text == string.Empty)
            {
                MessageBox.Show("没输入本期配置指标总数，请输入数字！");
                this.QuotaNumberTextBox.Focus();
            }
            else if (this.SeedNumericTextBox.Text == string.Empty)
            {
                MessageBox.Show("没输入初始值，请输入数字！");
                this.SeedNumericTextBox.Focus();
            }
            else
            {
                this.totalNumber = Convert.ToInt32(this.TotalNumberTextBox.Text);
                this.quotaNumber = Convert.ToInt32(this.QuotaNumberTextBox.Text);
                if (this.totalNumber <= this.quotaNumber)
                {
                    MessageBox.Show("有效申请编码总数不大于本期配置指标总数，可以全部配置，不需要摇号！");
                    this.TotalNumberTextBox.Focus();
                }
                else
                {
                    AllRandomPickData allRandomPickData = new AllRandomPickData {
                        TotalNumber = this.totalNumber,
                        QuotaNumber = this.quotaNumber,
                        Seed = Convert.ToInt32(this.SeedNumericTextBox.Text)
                    };
                    this.PickDataNumber(allRandomPickData);
                }
            }
        }

        private void PickNumberButton_MouseEnter(object sender, EventArgs e)
        {
        }

        private void PickNumberButton_MouseLeave(object sender, EventArgs e)
        {
            bool enabled = this.PickNumberButton.Enabled;
        }

        private void PoolNOTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar != '\b') && (e.KeyChar != '\t')) && (e.KeyChar != '.'))
            {
                if (e.KeyChar == char.Parse("\r"))
                {
                    this.ConfirmFuntion();
                }
                else if ((e.KeyChar < char.Parse("0")) || (e.KeyChar > char.Parse("9")))
                {
                    e.KeyChar = char.Parse("\r");
                }
                else if (this.PoolNOTextBox.Text.Length >= 9)
                {
                    e.KeyChar = char.Parse("\r");
                    MessageBox.Show("已经超过9位数字！");
                }
            }
        }

        private void QuotaNumberTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar != '\b') && (e.KeyChar != '\t')) && (e.KeyChar != '.'))
            {
                if ((e.KeyChar < char.Parse("0")) || (e.KeyChar > char.Parse("9")))
                {
                    e.KeyChar = char.Parse("\r");
                }
                else if (this.QuotaNumberTextBox.Text.Length >= 9)
                {
                    e.KeyChar = char.Parse("\r");
                    MessageBox.Show("已经超过9位数字！");
                }
            }
        }

        private void SeedNumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar != '\b') && (e.KeyChar != '\t')) && (e.KeyChar != '.'))
            {
                if ((e.KeyChar < char.Parse("0")) || (e.KeyChar > char.Parse("9")))
                {
                    e.KeyChar = char.Parse("\r");
                }
                else if (this.SeedNumericTextBox.Text.Length >= 6)
                {
                    e.KeyChar = char.Parse("\r");
                    MessageBox.Show("已经超过6位数字！");
                }
            }
        }

        private void SeedNumericTextBox_Leave(object sender, EventArgs e)
        {
            if ((this.SeedNumericTextBox.Text != string.Empty) && !this.sixNumberCodeRegex.IsMatch(this.SeedNumericTextBox.Text))
            {
                MessageBox.Show("不是6位数字，请重输！");
                this.SeedNumericTextBox.Focus();
            }
        }

        private void SetDataGridViewLength()
        {
            int num = (this.DataGridView.Width - this.DataGridView.RowHeadersWidth) - 20;
            if (this.DataGridView.Columns[0].Visible)
            {
                num -= this.DataGridView.Columns[0].Width;
            }
            this.DataGridView.Columns[1].Width = num;
        }

        private void ShowDataSet(DataSet dataSet)
        {
            if (dataSet != null)
            {
                this.DataGridView.DataMember = "Table1";
                this.DataGridView.DataSource = dataSet;
                if (this.DataGridView.Rows.Count > 0)
                {
                    this.DataGridView.FirstDisplayedScrollingRowIndex = this.DataGridView.Rows.Count - 1;
                }
            }
        }

        private void TotalNumberTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar != '\b') && (e.KeyChar != '\t')) && (e.KeyChar != '.'))
            {
                if ((e.KeyChar < char.Parse("0")) || (e.KeyChar > char.Parse("9")))
                {
                    e.KeyChar = char.Parse("\r");
                }
                else if (this.TotalNumberTextBox.Text.Length >= 9)
                {
                    e.KeyChar = char.Parse("\r");
                    MessageBox.Show("已经超过9位数字！");
                }
            }
        }
    }
}

