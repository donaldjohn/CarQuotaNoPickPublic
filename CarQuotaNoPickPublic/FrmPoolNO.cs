namespace CarQuotaNoPickPublic
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class FrmPoolNO : Form
    {
        private int[] _PoolNO;
        private IContainer components;
        private Button ConfirmButton;
        private Label label1;
        private TextBox PoolNOTextBox;
        private Button QuitButton;

        public FrmPoolNO()
        {
            this.InitializeComponent();
            this._PoolNO = new int[1];
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            this.ConfirmFuntion();
        }

        private void ConfirmFuntion()
        {
            if (this.PoolNOTextBox.Text == string.Empty)
            {
                MessageBox.Show("没输入摇号基数序号，请输入正整数！");
                this.PoolNOTextBox.Focus();
            }
            else
            {
                this.PoolNO[0] = Convert.ToInt32(this.PoolNOTextBox.Text);
                base.Close();
            }
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
            this.label1 = new Label();
            this.PoolNOTextBox = new TextBox();
            this.ConfirmButton = new Button();
            this.QuitButton = new Button();
            base.SuspendLayout();
            this.label1.AutoSize = true;
            this.label1.Location = new Point(0x1c, 0x18);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x68, 0x10);
            this.label1.TabIndex = 0;
            this.label1.Text = "摇号基数序号";
            this.PoolNOTextBox.Location = new Point(0x8a, 0x15);
            this.PoolNOTextBox.Name = "PoolNOTextBox";
            this.PoolNOTextBox.Size = new Size(0xb0, 0x1a);
            this.PoolNOTextBox.TabIndex = 0;
            this.PoolNOTextBox.KeyPress += new KeyPressEventHandler(this.PoolNOTextBox_KeyPress);
            this.ConfirmButton.Font = new Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.ConfirmButton.Location = new Point(0x30, 0x43);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new Size(0x6b, 0x1f);
            this.ConfirmButton.TabIndex = 1;
            this.ConfirmButton.Text = "确  认";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            this.ConfirmButton.Click += new EventHandler(this.ConfirmButton_Click);
            this.QuitButton.Font = new Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.QuitButton.Location = new Point(0xb9, 0x43);
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.Size = new Size(0x6b, 0x1f);
            this.QuitButton.TabIndex = 2;
            this.QuitButton.Text = "取  消";
            this.QuitButton.UseVisualStyleBackColor = true;
            this.QuitButton.Click += new EventHandler(this.QuitButton_Click);
            base.AutoScaleDimensions = new SizeF(8f, 16f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.LightSteelBlue;
            base.ClientSize = new Size(0x160, 110);
            base.Controls.Add(this.QuitButton);
            base.Controls.Add(this.ConfirmButton);
            base.Controls.Add(this.PoolNOTextBox);
            base.Controls.Add(this.label1);
            this.Font = new Font("宋体", 12f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            base.FormBorderStyle = FormBorderStyle.None;
            base.Margin = new Padding(4, 4, 4, 4);
            base.Name = "FrmPoolNO";
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "摇号基数序号输入";
            base.ResumeLayout(false);
            base.PerformLayout();
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

        private void QuitButton_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        public int[] PoolNO
        {
            get
            {
                return this._PoolNO;
            }
            set
            {
                this._PoolNO = value;
            }
        }
    }
}

