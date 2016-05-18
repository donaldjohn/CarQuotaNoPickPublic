namespace CarQuotaNoPickPublic
{
    using CarQuotaNoPickPublic.Properties;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;

    public class FrmMainB : Form
    {
        private IContainer components;
        private Button ControlExitButton;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label6;
        private Label label8;
        private Button PickNumberButton;
        private int poolNO;
        private TextBox PoolNOTextBox;
        private int quotaNumber;
        private TextBox QuotaNumberTextBox;
        private TextBox SeedNumericTextBox;
        private Regex sixNumberCodeRegex;
        private int totalNumber;
        private TextBox TotalNumberTextBox;

        public FrmMainB()
        {
            this.InitializeComponent();
            this.sixNumberCodeRegex = new Regex(@"^\d{6}$");
            this.poolNO = 0;
            this.totalNumber = 0;
            this.quotaNumber = 0;
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

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.label3 = new Label();
            this.PoolNOTextBox = new TextBox();
            this.SeedNumericTextBox = new TextBox();
            this.TotalNumberTextBox = new TextBox();
            this.PickNumberButton = new Button();
            this.label2 = new Label();
            this.label4 = new Label();
            this.label8 = new Label();
            this.label6 = new Label();
            this.ControlExitButton = new Button();
            this.label1 = new Label();
            this.QuotaNumberTextBox = new TextBox();
            base.SuspendLayout();
            this.label3.BackColor = Color.Transparent;
            this.label3.Font = new Font("宋体", 12f, FontStyle.Regular, GraphicsUnit.Pixel, 0x86);
            this.label3.ForeColor = Color.FromArgb(0x4b, 0x7d, 0x9e);
            this.label3.Location = new Point(0x92, 0x9e);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x12f, 0x10);
            this.label3.TabIndex = 80;
            this.label3.Text = "版权所有 (C) 北京市小客车指标调控管理办公室 2013";
            this.PoolNOTextBox.BorderStyle = BorderStyle.None;
            this.PoolNOTextBox.Font = new Font("宋体", 14f, FontStyle.Regular, GraphicsUnit.Pixel, 0x86);
            this.PoolNOTextBox.Location = new Point(0x1db, 0x56);
            this.PoolNOTextBox.Name = "PoolNOTextBox";
            this.PoolNOTextBox.Size = new Size(0x5c, 0x10);
            this.PoolNOTextBox.TabIndex = 0x55;
            this.PoolNOTextBox.KeyPress += new KeyPressEventHandler(this.PoolNOTextBox_KeyPress);
            this.SeedNumericTextBox.BackColor = Color.White;
            this.SeedNumericTextBox.BorderStyle = BorderStyle.None;
            this.SeedNumericTextBox.Font = new Font("宋体", 14f, FontStyle.Regular, GraphicsUnit.Pixel, 0x86);
            this.SeedNumericTextBox.Location = new Point(0xdb, 0x55);
            this.SeedNumericTextBox.Margin = new Padding(2);
            this.SeedNumericTextBox.Name = "SeedNumericTextBox";
            this.SeedNumericTextBox.Size = new Size(0x5c, 0x10);
            this.SeedNumericTextBox.TabIndex = 0x53;
            this.SeedNumericTextBox.Leave += new EventHandler(this.SeedNumericTextBox_Leave);
            this.SeedNumericTextBox.KeyPress += new KeyPressEventHandler(this.SeedNumericTextBox_KeyPress);
            this.TotalNumberTextBox.BackColor = Color.White;
            this.TotalNumberTextBox.BorderStyle = BorderStyle.None;
            this.TotalNumberTextBox.Font = new Font("宋体", 14f, FontStyle.Regular, GraphicsUnit.Pixel, 0x86);
            this.TotalNumberTextBox.Location = new Point(0xdb, 0x3a);
            this.TotalNumberTextBox.Margin = new Padding(2);
            this.TotalNumberTextBox.Name = "TotalNumberTextBox";
            this.TotalNumberTextBox.Size = new Size(0x5c, 0x10);
            this.TotalNumberTextBox.TabIndex = 0x51;
            this.TotalNumberTextBox.KeyPress += new KeyPressEventHandler(this.TotalNumberTextBox_KeyPress);
            this.PickNumberButton.BackColor = Color.Transparent;
            this.PickNumberButton.BackgroundImage = Resources.main_btn4;
            this.PickNumberButton.BackgroundImageLayout = ImageLayout.Stretch;
            this.PickNumberButton.FlatAppearance.BorderSize = 0;
            this.PickNumberButton.FlatStyle = FlatStyle.Flat;
            this.PickNumberButton.Font = new Font("宋体", 14f, FontStyle.Bold, GraphicsUnit.Pixel, 0x86);
            this.PickNumberButton.ForeColor = Color.White;
            this.PickNumberButton.Location = new Point(0xf3, 0x76);
            this.PickNumberButton.Name = "PickNumberButton";
            this.PickNumberButton.Size = new Size(0x5d, 0x17);
            this.PickNumberButton.TabIndex = 0x54;
            this.PickNumberButton.Text = "计  算";
            this.PickNumberButton.UseVisualStyleBackColor = false;
            this.PickNumberButton.MouseLeave += new EventHandler(this.PickNumberButton_MouseLeave);
            this.PickNumberButton.Click += new EventHandler(this.PickNumberButton_Click);
            this.PickNumberButton.MouseEnter += new EventHandler(this.PickNumberButton_MouseEnter);
            this.label2.AutoSize = true;
            this.label2.BackColor = Color.Transparent;
            this.label2.Font = new Font("宋体", 14f, FontStyle.Bold, GraphicsUnit.Pixel, 0x86);
            this.label2.ForeColor = Color.FromArgb(0x4b, 0x7d, 0x9e);
            this.label2.Location = new Point(11, 0x57);
            this.label2.Margin = new Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0xe1, 14);
            this.label2.TabIndex = 0x59;
            this.label2.Text = "指标配置初始值（6位种子数）：";
            this.label4.AutoSize = true;
            this.label4.BackColor = Color.Transparent;
            this.label4.Font = new Font("宋体", 14f, FontStyle.Bold, GraphicsUnit.Pixel, 0x86);
            this.label4.ForeColor = Color.FromArgb(0x4b, 0x7d, 0x9e);
            this.label4.Location = new Point(0x151, 0x57);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x8e, 14);
            this.label4.TabIndex = 90;
            this.label4.Text = "我的摇号基数序号：";
            this.label8.AutoSize = true;
            this.label8.BackColor = Color.Transparent;
            this.label8.Font = new Font("宋体", 14f, FontStyle.Bold, GraphicsUnit.Pixel, 0x86);
            this.label8.ForeColor = Color.FromArgb(0x4b, 0x7d, 0x9e);
            this.label8.Location = new Point(12, 0x3b);
            this.label8.Margin = new Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new Size(0x8e, 14);
            this.label8.TabIndex = 0x58;
            this.label8.Text = "有效申请编码总数：";
            this.label6.AutoSize = true;
            this.label6.BackColor = Color.Transparent;
            this.label6.Font = new Font("宋体", 14f, FontStyle.Bold, GraphicsUnit.Pixel, 0x86);
            this.label6.ForeColor = Color.FromArgb(0x4b, 0x7d, 0x9e);
            this.label6.Location = new Point(0x151, 0x39);
            this.label6.Margin = new Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new Size(0x70, 14);
            this.label6.TabIndex = 0x57;
            this.label6.Text = "配置指标个数：";
            this.ControlExitButton.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.ControlExitButton.BackColor = Color.Transparent;
            this.ControlExitButton.BackgroundImage = Resources.main_close;
            this.ControlExitButton.BackgroundImageLayout = ImageLayout.Stretch;
            this.ControlExitButton.FlatAppearance.BorderSize = 0;
            this.ControlExitButton.FlatStyle = FlatStyle.Flat;
            this.ControlExitButton.Location = new Point(0x231, 2);
            this.ControlExitButton.Name = "ControlExitButton";
            this.ControlExitButton.Size = new Size(0x1c, 20);
            this.ControlExitButton.TabIndex = 0x5b;
            this.ControlExitButton.TabStop = false;
            this.ControlExitButton.UseVisualStyleBackColor = false;
            this.ControlExitButton.MouseLeave += new EventHandler(this.ControlExitButton_MouseLeave);
            this.ControlExitButton.Click += new EventHandler(this.ControlExitButton_Click);
            this.ControlExitButton.MouseEnter += new EventHandler(this.ControlExitButton_MouseEnter);
            this.label1.AutoSize = true;
            this.label1.BackColor = Color.Transparent;
            this.label1.Font = new Font("宋体", 16f, FontStyle.Bold, GraphicsUnit.Pixel);
            this.label1.ForeColor = Color.FromArgb(0x4b, 0x7d, 0x9e);
            this.label1.Location = new Point(0x29, 10);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0xe5, 0x10);
            this.label1.TabIndex = 0x5c;
            this.label1.Text = "摇号结果验证程序（个人版）";
            this.QuotaNumberTextBox.BorderStyle = BorderStyle.None;
            this.QuotaNumberTextBox.Font = new Font("宋体", 14f, FontStyle.Regular, GraphicsUnit.Pixel, 0x86);
            this.QuotaNumberTextBox.Location = new Point(0x1db, 0x3a);
            this.QuotaNumberTextBox.Name = "QuotaNumberTextBox";
            this.QuotaNumberTextBox.Size = new Size(0x5c, 0x10);
            this.QuotaNumberTextBox.TabIndex = 0x5d;
            this.QuotaNumberTextBox.KeyPress += new KeyPressEventHandler(this.QuotaNumberComboBox_KeyPress);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackgroundImage = Resources.main_bg_c;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            base.ClientSize = new Size(590, 180);
            base.Controls.Add(this.QuotaNumberTextBox);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.ControlExitButton);
            base.Controls.Add(this.PoolNOTextBox);
            base.Controls.Add(this.SeedNumericTextBox);
            base.Controls.Add(this.TotalNumberTextBox);
            base.Controls.Add(this.PickNumberButton);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.label4);
            base.Controls.Add(this.label8);
            base.Controls.Add(this.label6);
            base.Controls.Add(this.label3);
            this.DoubleBuffered = true;
            base.FormBorderStyle = FormBorderStyle.None;
            base.Name = "FrmMainB";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "北京市小客车指标调控管理信息系统指标配软件公众演算版";
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void PickDataNumber(AllRandomPickData allRandomPickData)
        {
            if (allRandomPickData != null)
            {
                try
                {
                    new AllRandomPick().GetRandomNumber(allRandomPickData);
                    new PersonNumberDataSet();
                    if ((allRandomPickData != null) && (allRandomPickData.PickNumber != null))
                    {
                        int num = 0;
                        num = 0;
                        while (num < allRandomPickData.PickNumber.Count)
                        {
                            if (this.poolNO == allRandomPickData.PickNumber[num])
                            {
                                MessageBox.Show("按输入的参数计算，摇号基数序号" + this.poolNO.ToString() + "摇中！");
                                break;
                            }
                            num++;
                        }
                        if (num >= allRandomPickData.PickNumber.Count)
                        {
                            MessageBox.Show("按输入的参数计算，摇号基数序号" + this.poolNO.ToString() + "没有摇中！");
                        }
                    }
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
                MessageBox.Show("没输入本期有效申请编码总数，请输入正整数！");
                this.TotalNumberTextBox.Focus();
            }
            else if (this.QuotaNumberTextBox.Text == string.Empty)
            {
                MessageBox.Show("没输入本期配置指标总数，请输入正整数！");
                this.QuotaNumberTextBox.Focus();
            }
            else if (this.SeedNumericTextBox.Text == string.Empty)
            {
                MessageBox.Show("没输入种子数，请输入数字！");
                this.SeedNumericTextBox.Focus();
            }
            else if (this.PoolNOTextBox.Text == string.Empty)
            {
                MessageBox.Show("没输入我的摇号基数序号，请输入正整数！");
                this.PoolNOTextBox.Focus();
            }
            else
            {
                this.totalNumber = Convert.ToInt32(this.TotalNumberTextBox.Text);
                this.quotaNumber = Convert.ToInt32(this.QuotaNumberTextBox.Text);
                if (this.totalNumber <= this.quotaNumber)
                {
                    MessageBox.Show("本期有效申请编码总数不大于本期配置指标总数，可以全部配置，不需要摇号！");
                    this.TotalNumberTextBox.Focus();
                }
                else
                {
                    this.poolNO = Convert.ToInt32(this.PoolNOTextBox.Text);
                    if (this.poolNO == 0)
                    {
                        MessageBox.Show("输入摇号基数序号不应该等于零，请重输！");
                        this.PoolNOTextBox.Focus();
                    }
                    else if (this.totalNumber < this.poolNO)
                    {
                        MessageBox.Show("输入摇号基数序号已经大于有效申请编码总数，请重输！");
                        this.PoolNOTextBox.Focus();
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
                if ((e.KeyChar < char.Parse("0")) || (e.KeyChar > char.Parse("9")))
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

        private void QuotaNumberComboBox_KeyPress(object sender, KeyPressEventArgs e)
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

