namespace CarQuotaNoPickPublic
{
    using CarQuotaNoPickPublic.Properties;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;

    public class FrmMainC : Form
    {
        private DataGridViewTextBoxColumn ApplyNumber;
        private ApplynumberArray applynumberArray;
        private TextBox ApplyNumberTextBox;
        private IContainer components;
        private Button ConfirmButton;
        private Button ControlExitButton;
        private System.Windows.Forms.DataGridView DataGridView;
        private Button FileLoadButton;
        private TextBox FileMD5TextBox;
        private string filePath;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label labelPrompt;
        private Label lblLoadInfo;
        private DataGridViewTextBoxColumn PickNO;
        private Button PickNumberButton;
        private int quotaNumber;
        private TextBox QuotaNumberTextBox;
        private TextBox SeedNumericTextBox;
        private Regex sixNumberCodeRegex;
        private int totalNumber;
        private TextBox TotalNumberTextBox;
        private Button button1;
        private Button button2;
        private Button UserHelpButton;

        public FrmMainC()
        {
            this.InitializeComponent();
            this.labelPrompt.Left = this.SeedNumericTextBox.Left;
            this.labelPrompt.Top = this.SeedNumericTextBox.Top;
            this.labelPrompt.Width = this.SeedNumericTextBox.Width;
            this.labelPrompt.Height = this.SeedNumericTextBox.Height;  
            this.sixNumberCodeRegex = new Regex(@"^\d{6}$");
            this.totalNumber = 0;
            this.quotaNumber = 0;
            this.filePath = Environment.CurrentDirectory + @"\temp";
            this.applynumberArray = new ApplynumberArray();
        }

        private void ApplyNumberTextBox_Leave(object sender, EventArgs e)
        {
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
            Regex regex = new Regex(@"^\d{13}$");
            if ((this.ApplyNumberTextBox.Text != string.Empty) && !regex.IsMatch(this.ApplyNumberTextBox.Text))
            {
                MessageBox.Show("申请编码不是13位编码，请重输！");
                this.ApplyNumberTextBox.Focus();
            }
            else
            {
                this.ConfirmFuntion();
            }
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
                MessageBox.Show(("请执行正确操作步骤！\r\n" + "    第1步：导入摇号池编码文件；\r\n") + "    第2步：输入6位种子数，点计算；\r\n" + "    第3步：输入我的申请编码，查询结果！\r\n");
            }
            else if (this.ApplyNumberTextBox.Text == string.Empty)
            {
                MessageBox.Show("没输入申请编码，请输入！");
                this.ApplyNumberTextBox.Focus();
            }
            else
            {
                string s = this.ApplyNumberTextBox.Text.Trim();
                if ((s != "") && (this.DataGridView.Rows.Count > 0))
                {
                    int num = 0;
                    num = 0;
                    while (num < this.DataGridView.Rows.Count)
                    {
                        if (this.DataGridView.Rows[num].Cells[1].Value.ToString() == s)
                        {
                            foreach (DataGridViewRow row in this.DataGridView.SelectedRows)
                            {
                                row.Selected = false;
                            }
                            this.DataGridView.Rows[num].Selected = true;
                            this.DataGridView.FirstDisplayedScrollingRowIndex = num;
                            MessageBox.Show("本期摇号，该编码已中签！");
                            break;
                        }
                        num++;
                    }
                    if (num >= this.DataGridView.Rows.Count)
                    {
                        if (this.applynumberArray.IsApplyNumber(Encoding.UTF8.GetBytes(s)))
                        {
                            MessageBox.Show("本期摇号，该编码未中签！");
                        }
                        else
                        {
                            MessageBox.Show("本期摇号，该编码不存在！");
                        }
                    }
                }
            }
        }

        private bool SimulateFuction()
        {
            bool bingo = false;
            if (this.DataGridView.Rows.Count == 0)
            {
                MessageBox.Show(("请执行正确操作步骤！\r\n" + "    第1步：导入摇号池编码文件；\r\n") + "    第2步：输入6位种子数，点计算；\r\n" + "    第3步：输入我的申请编码，查询结果！\r\n");
            }
            else if (this.ApplyNumberTextBox.Text == string.Empty)
            {
                MessageBox.Show("没输入申请编码，请输入！");
                this.ApplyNumberTextBox.Focus();
            }
            else
            {
                string s = this.ApplyNumberTextBox.Text.Trim();
                if ((s != "") && (this.DataGridView.Rows.Count > 0))
                {
                    int num = 0;
                    num = 0;
                    while (num < this.DataGridView.Rows.Count)
                    {
                        if (this.DataGridView.Rows[num].Cells[1].Value.ToString() == s)
                        {
                            foreach (DataGridViewRow row in this.DataGridView.SelectedRows)
                            {
                                row.Selected = false;
                            }
                            this.DataGridView.Rows[num].Selected = true;
                            this.DataGridView.FirstDisplayedScrollingRowIndex = num;
                            MessageBox.Show("本期摇号，该编码已中签！");
                            bingo = true;
                            break;
                        }
                        num++;
                    }
                    if (num >= this.DataGridView.Rows.Count)
                    {
                        if (this.applynumberArray.IsApplyNumber(Encoding.UTF8.GetBytes(s)))
                        {
                            //MessageBox.Show("本期摇号，该编码未中签！");
                        }
                        else
                        {
                            MessageBox.Show("本期摇号，该编码不存在！");
                        }
                    }
                }
            }
            return bingo;
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

        private void FileLoadButton_Click(object sender, EventArgs e)
        {
            if (this.FileMD5TextBox.Text == string.Empty)
            {
                MessageBox.Show("请输入当期文件MD5码！");
                this.FileMD5TextBox.Focus();
            }
            else
            {
                OpenFileDialog dialog = new OpenFileDialog {
                    Filter = "Zip Document(*.zip)|*.zip"
                };
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    this.Cursor = Cursors.WaitCursor;
                    if (this.DataGridView.DataSource != null)
                    {
                        DataSet dataSource = (DataSet) this.DataGridView.DataSource;
                        dataSource.Tables[0].Rows.Clear();
                        this.DataGridView.Refresh();
                        this.SeedNumericTextBox.Text = "";
                    }
                    string fileName = dialog.FileName;
                    if (this.FileMD5TextBox.Text.Trim() != MD5HashCodeHeler.GetFileHashCode(fileName))
                    {
                        MessageBox.Show("MD5码与文件不匹配！");
                    }
                    else
                    {
                        string strPath = Environment.CurrentDirectory + @"\" + Path.GetFileNameWithoutExtension(dialog.FileName);
                        ApplyNumberCheck check = new ApplyNumberCheck();
                        check.DeleteDir(strPath);
                        if (!SharpZipHepler.UnZipTo(fileName, strPath))
                        {
                            MessageBox.Show("文件解压没成功！");
                        }
                        else
                        {
                            this.applynumberArray.Initialize();
                            check.ImportPersonNumberPeriodFromFilePath(this.applynumberArray, strPath);
                            if (this.applynumberArray.Count > 0)
                            {
                                this.TotalNumberTextBox.Text = this.applynumberArray.Count.ToString();
                                this.QuotaNumberTextBox.Text = this.applynumberArray.QuotaNumber.ToString();
                                this.lblLoadInfo.Text = this.applynumberArray.PeriodTitle + "数据导入完成";
                            }
                            check.DeleteDir(strPath);
                            this.Cursor = Cursors.Default;
                        }
                    }
                }
            }
        }

        private void FrmMainC_Resize(object sender, EventArgs e)
        {
            this.SetDataGridViewLength();
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.ControlExitButton = new System.Windows.Forms.Button();
            this.PickNumberButton = new System.Windows.Forms.Button();
            this.TotalNumberTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SeedNumericTextBox = new System.Windows.Forms.TextBox();
            this.DataGridView = new System.Windows.Forms.DataGridView();
            this.PickNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApplyNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserHelpButton = new System.Windows.Forms.Button();
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.ApplyNumberTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.QuotaNumberTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.FileMD5TextBox = new System.Windows.Forms.TextBox();
            this.FileLoadButton = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.lblLoadInfo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelPrompt = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(125)))), ((int)(((byte)(158)))));
            this.label1.Location = new System.Drawing.Point(51, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "北京市小客车指标摇号程序";
            // 
            // ControlExitButton
            // 
            this.ControlExitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ControlExitButton.BackColor = System.Drawing.Color.Transparent;
            this.ControlExitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ControlExitButton.FlatAppearance.BorderSize = 0;
            this.ControlExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ControlExitButton.Location = new System.Drawing.Point(691, 2);
            this.ControlExitButton.Name = "ControlExitButton";
            this.ControlExitButton.Size = new System.Drawing.Size(28, 20);
            this.ControlExitButton.TabIndex = 62;
            this.ControlExitButton.TabStop = false;
            this.ControlExitButton.UseVisualStyleBackColor = false;
            this.ControlExitButton.Click += new System.EventHandler(this.ControlExitButton_Click);
            this.ControlExitButton.MouseEnter += new System.EventHandler(this.ControlExitButton_MouseEnter);
            this.ControlExitButton.MouseLeave += new System.EventHandler(this.ControlExitButton_MouseLeave);
            // 
            // PickNumberButton
            // 
            this.PickNumberButton.BackColor = System.Drawing.Color.Transparent;
            this.PickNumberButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PickNumberButton.FlatAppearance.BorderSize = 0;
            this.PickNumberButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PickNumberButton.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.PickNumberButton.ForeColor = System.Drawing.Color.White;
            this.PickNumberButton.Location = new System.Drawing.Point(301, 107);
            this.PickNumberButton.Name = "PickNumberButton";
            this.PickNumberButton.Size = new System.Drawing.Size(73, 23);
            this.PickNumberButton.TabIndex = 5;
            this.PickNumberButton.Text = "计  算";
            this.PickNumberButton.UseVisualStyleBackColor = false;
            this.PickNumberButton.Click += new System.EventHandler(this.PickNumberButton_Click);
            this.PickNumberButton.MouseEnter += new System.EventHandler(this.PickNumberButton_MouseEnter);
            this.PickNumberButton.MouseLeave += new System.EventHandler(this.PickNumberButton_MouseLeave);
            // 
            // TotalNumberTextBox
            // 
            this.TotalNumberTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.TotalNumberTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TotalNumberTextBox.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.TotalNumberTextBox.Location = new System.Drawing.Point(160, 84);
            this.TotalNumberTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.TotalNumberTextBox.Name = "TotalNumberTextBox";
            this.TotalNumberTextBox.ReadOnly = true;
            this.TotalNumberTextBox.Size = new System.Drawing.Size(131, 16);
            this.TotalNumberTextBox.TabIndex = 2;
            this.TotalNumberTextBox.TabStop = false;
            this.TotalNumberTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TotalNumberTextBox_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(125)))), ((int)(((byte)(158)))));
            this.label6.Location = new System.Drawing.Point(298, 84);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 14);
            this.label6.TabIndex = 67;
            this.label6.Text = "配置指标个数：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(125)))), ((int)(((byte)(158)))));
            this.label8.Location = new System.Drawing.Point(36, 84);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(127, 14);
            this.label8.TabIndex = 68;
            this.label8.Text = "摇号池编码总数：";
            // 
            // SeedNumericTextBox
            // 
            this.SeedNumericTextBox.BackColor = System.Drawing.Color.White;
            this.SeedNumericTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SeedNumericTextBox.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SeedNumericTextBox.Location = new System.Drawing.Point(160, 111);
            this.SeedNumericTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.SeedNumericTextBox.Name = "SeedNumericTextBox";
            this.SeedNumericTextBox.Size = new System.Drawing.Size(126, 14);
            this.SeedNumericTextBox.TabIndex = 4;
            this.SeedNumericTextBox.Enter += new System.EventHandler(this.SeedNumericTextBox_Enter);
            // 
            // DataGridView
            // 
            this.DataGridView.AllowUserToAddRows = false;
            this.DataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(247)))), ((int)(((byte)(253)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Navy;
            this.DataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGridView.BackgroundColor = System.Drawing.Color.White;
            this.DataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(247)))), ((int)(((byte)(253)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(125)))), ((int)(((byte)(158)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridView.ColumnHeadersHeight = 26;
            this.DataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PickNO,
            this.ApplyNumber});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(125)))), ((int)(((byte)(158)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridView.DefaultCellStyle = dataGridViewCellStyle5;
            this.DataGridView.EnableHeadersVisualStyles = false;
            this.DataGridView.Location = new System.Drawing.Point(11, 196);
            this.DataGridView.Margin = new System.Windows.Forms.Padding(2);
            this.DataGridView.Name = "DataGridView";
            this.DataGridView.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(247)))), ((int)(((byte)(253)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(125)))), ((int)(((byte)(158)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.DataGridView.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.DataGridView.RowTemplate.Height = 23;
            this.DataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridView.Size = new System.Drawing.Size(699, 299);
            this.DataGridView.TabIndex = 8;
            // 
            // PickNO
            // 
            this.PickNO.DataPropertyName = "PickNO";
            dataGridViewCellStyle3.Format = "##########";
            dataGridViewCellStyle3.NullValue = null;
            this.PickNO.DefaultCellStyle = dataGridViewCellStyle3;
            this.PickNO.HeaderText = "顺序号";
            this.PickNO.Name = "PickNO";
            this.PickNO.ReadOnly = true;
            this.PickNO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PickNO.Width = 300;
            // 
            // ApplyNumber
            // 
            this.ApplyNumber.DataPropertyName = "ApplyNumber";
            dataGridViewCellStyle4.Format = "##########";
            dataGridViewCellStyle4.NullValue = null;
            this.ApplyNumber.DefaultCellStyle = dataGridViewCellStyle4;
            this.ApplyNumber.HeaderText = "中签编码";
            this.ApplyNumber.Name = "ApplyNumber";
            this.ApplyNumber.ReadOnly = true;
            this.ApplyNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ApplyNumber.Width = 300;
            // 
            // UserHelpButton
            // 
            this.UserHelpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.UserHelpButton.BackColor = System.Drawing.Color.Transparent;
            this.UserHelpButton.FlatAppearance.BorderSize = 0;
            this.UserHelpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UserHelpButton.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.UserHelpButton.ForeColor = System.Drawing.Color.LightSlateGray;
            this.UserHelpButton.Location = new System.Drawing.Point(-233, 532);
            this.UserHelpButton.Name = "UserHelpButton";
            this.UserHelpButton.Size = new System.Drawing.Size(82, 27);
            this.UserHelpButton.TabIndex = 72;
            this.UserHelpButton.Text = "使用说明";
            this.UserHelpButton.UseVisualStyleBackColor = false;
            this.UserHelpButton.Visible = false;
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.BackColor = System.Drawing.Color.Transparent;
            this.ConfirmButton.FlatAppearance.BorderSize = 0;
            this.ConfirmButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConfirmButton.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.ConfirmButton.ForeColor = System.Drawing.Color.White;
            this.ConfirmButton.Location = new System.Drawing.Point(497, 157);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(73, 24);
            this.ConfirmButton.TabIndex = 7;
            this.ConfirmButton.Text = "查  询";
            this.ConfirmButton.UseVisualStyleBackColor = false;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            this.ConfirmButton.MouseEnter += new System.EventHandler(this.ConfirmButton_MouseEnter);
            this.ConfirmButton.MouseLeave += new System.EventHandler(this.ConfirmButton_MouseLeave);
            // 
            // ApplyNumberTextBox
            // 
            this.ApplyNumberTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ApplyNumberTextBox.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.ApplyNumberTextBox.Location = new System.Drawing.Point(160, 159);
            this.ApplyNumberTextBox.Name = "ApplyNumberTextBox";
            this.ApplyNumberTextBox.Size = new System.Drawing.Size(329, 23);
            this.ApplyNumberTextBox.TabIndex = 6;
            this.ApplyNumberTextBox.Leave += new System.EventHandler(this.ApplyNumberTextBox_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(125)))), ((int)(((byte)(158)))));
            this.label4.Location = new System.Drawing.Point(51, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 14);
            this.label4.TabIndex = 78;
            this.label4.Text = "我的申请编码：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(125)))), ((int)(((byte)(158)))));
            this.label5.Location = new System.Drawing.Point(42, 112);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 14);
            this.label5.TabIndex = 90;
            this.label5.Text = "6位随机种子数：";
            // 
            // QuotaNumberTextBox
            // 
            this.QuotaNumberTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.QuotaNumberTextBox.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.QuotaNumberTextBox.Location = new System.Drawing.Point(407, 84);
            this.QuotaNumberTextBox.Name = "QuotaNumberTextBox";
            this.QuotaNumberTextBox.ReadOnly = true;
            this.QuotaNumberTextBox.Size = new System.Drawing.Size(116, 16);
            this.QuotaNumberTextBox.TabIndex = 3;
            this.QuotaNumberTextBox.TabStop = false;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(125)))), ((int)(((byte)(158)))));
            this.label2.Location = new System.Drawing.Point(52, 532);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(596, 19);
            this.label2.TabIndex = 95;
            this.label2.Text = "版权所有 (C) 北京市小客车指标调控管理办公室 2014";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(125)))), ((int)(((byte)(158)))));
            this.label7.Location = new System.Drawing.Point(72, 57);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 14);
            this.label7.TabIndex = 68;
            this.label7.Text = "文件MD5码：";
            // 
            // FileMD5TextBox
            // 
            this.FileMD5TextBox.BackColor = System.Drawing.Color.White;
            this.FileMD5TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.FileMD5TextBox.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.FileMD5TextBox.Location = new System.Drawing.Point(160, 57);
            this.FileMD5TextBox.Margin = new System.Windows.Forms.Padding(2);
            this.FileMD5TextBox.Name = "FileMD5TextBox";
            this.FileMD5TextBox.Size = new System.Drawing.Size(363, 16);
            this.FileMD5TextBox.TabIndex = 0;
            // 
            // FileLoadButton
            // 
            this.FileLoadButton.BackColor = System.Drawing.Color.Transparent;
            this.FileLoadButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.FileLoadButton.FlatAppearance.BorderSize = 0;
            this.FileLoadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FileLoadButton.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.FileLoadButton.ForeColor = System.Drawing.Color.White;
            this.FileLoadButton.Location = new System.Drawing.Point(533, 53);
            this.FileLoadButton.Name = "FileLoadButton";
            this.FileLoadButton.Size = new System.Drawing.Size(73, 23);
            this.FileLoadButton.TabIndex = 1;
            this.FileLoadButton.Text = "导  入";
            this.FileLoadButton.UseVisualStyleBackColor = false;
            this.FileLoadButton.Click += new System.EventHandler(this.FileLoadButton_Click);
            this.FileLoadButton.MouseEnter += new System.EventHandler(this.PickNumberButton_MouseEnter);
            this.FileLoadButton.MouseLeave += new System.EventHandler(this.PickNumberButton_MouseLeave);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(125)))), ((int)(((byte)(158)))));
            this.label9.Location = new System.Drawing.Point(105, 499);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(494, 16);
            this.label9.TabIndex = 95;
            this.label9.Text = "为确保摇号结果验证的真实性，请从北京缓解拥堵网站（http://www.bjhjyd.gov.cn）";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLoadInfo
            // 
            this.lblLoadInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblLoadInfo.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblLoadInfo.ForeColor = System.Drawing.Color.Coral;
            this.lblLoadInfo.Location = new System.Drawing.Point(399, 110);
            this.lblLoadInfo.Name = "lblLoadInfo";
            this.lblLoadInfo.Size = new System.Drawing.Size(113, 19);
            this.lblLoadInfo.TabIndex = 95;
            this.lblLoadInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(125)))), ((int)(((byte)(158)))));
            this.label3.Location = new System.Drawing.Point(105, 515);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(494, 16);
            this.label3.TabIndex = 96;
            this.label3.Text = "下载摇号程序和数据，该程序仅限用于北京市小客车指标摇号结果验证。";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelPrompt
            // 
            this.labelPrompt.BackColor = System.Drawing.Color.White;
            this.labelPrompt.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelPrompt.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.labelPrompt.Location = new System.Drawing.Point(158, 110);
            this.labelPrompt.Name = "labelPrompt";
            this.labelPrompt.Size = new System.Drawing.Size(126, 16);
            this.labelPrompt.TabIndex = 97;
            this.labelPrompt.Text = "请输入当期6位种子数";
            this.labelPrompt.Click += new System.EventHandler(this.labelPrompt_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(402, 106);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 24);
            this.button1.TabIndex = 98;
            this.button1.Text = "全种子分析";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(576, 159);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 99;
            this.button2.Text = "中签仿真";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FrmMainC
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(720, 560);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelPrompt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblLoadInfo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.QuotaNumberTextBox);
            this.Controls.Add(this.ApplyNumberTextBox);
            this.Controls.Add(this.UserHelpButton);
            this.Controls.Add(this.ConfirmButton);
            this.Controls.Add(this.DataGridView);
            this.Controls.Add(this.SeedNumericTextBox);
            this.Controls.Add(this.FileMD5TextBox);
            this.Controls.Add(this.TotalNumberTextBox);
            this.Controls.Add(this.FileLoadButton);
            this.Controls.Add(this.PickNumberButton);
            this.Controls.Add(this.ControlExitButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FrmMainC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "北京市小客车指标调控管理信息系统指标配软件公众演算版";
            this.Resize += new System.EventHandler(this.FrmMainC_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void labelPrompt_Click(object sender, EventArgs e)
        {
            this.labelPrompt.Visible = false;
            this.SeedNumericTextBox.Focus();
        }

        private void PickDataNumber(ApplynumberArray applynumberArray)
        {
            if (applynumberArray != null)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    PersonRandomPick pick = new PersonRandomPick();
                    pick.GetMoreRandomNumber(applynumberArray);
                    PersonNumberDataSet pickNumberDataSet = new PersonNumberDataSet();
                    pick.SetPickNumberDataSet(applynumberArray, pickNumberDataSet);
                    this.ShowDataSet(pickNumberDataSet.DataSet);
                    this.Cursor = Cursors.Default;
                    string str = "00000000000000";
                    string str2 = applynumberArray.Seed.ToString() ?? "";
                    //MessageBox.Show("按照您输入的种子数" + ((str2.Length >= 6) ? str2 : (str.Substring(0, 6 - str2.Length) + str2)) + "，计算完成！");
                }
                catch
                {
                    MessageBox.Show("使用输入的值，运算超时，请选用合适的参数！");
                }
                try
                {
                    // Add Analysis Code Here                    
                    string fileStr = applynumberArray.Seed.ToString() + "_RandomNumber.csv";
                    //CSVFileHelper.WriteCSV(fileStr, applynumberArray.PickNumber);
                    //MessageBox.Show(applynumberArray.Seed.ToString() + "_RandomNumber.csv" + " ：写入成功");
                }
                catch
                {
                    MessageBox.Show("Error!!!"+applynumberArray.Seed.ToString() + "_RandomNumber.csv"+" ：写入失败");
                }
            }
        }

        private void PickNumberButton_Click(object sender, EventArgs e)
        {
            if (this.applynumberArray.Count <= 0)
            {
                MessageBox.Show("没有效申请编码数据，请先导入！");
                this.FileLoadButton.Focus();
            }
            else
            {
                if (this.SeedNumericTextBox.Text != string.Empty)
                {
                    if (!this.sixNumberCodeRegex.IsMatch(this.SeedNumericTextBox.Text))
                    {
                        MessageBox.Show("种子数不是6位数字，请重输！");
                        this.SeedNumericTextBox.Focus();
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("没输入种子数，请重输！");
                    this.SeedNumericTextBox.Focus();
                    return;
                }
                this.totalNumber = Convert.ToInt32(this.TotalNumberTextBox.Text);
                this.quotaNumber = Convert.ToInt32(this.QuotaNumberTextBox.Text);
                this.applynumberArray.Seed = Convert.ToInt32(this.SeedNumericTextBox.Text);
                this.PickDataNumber(this.applynumberArray);
            }
        }

        private void PickNumberButton_MouseEnter(object sender, EventArgs e)
        {
        }

        private void PickNumberButton_MouseLeave(object sender, EventArgs e)
        {
            bool enabled = this.PickNumberButton.Enabled;
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

        private void SeedNumericTextBox_Enter(object sender, EventArgs e)
        {
            this.labelPrompt.Visible = false;
        }

        private void SeedNumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < 100; i ++)
                {
                    Random s = new Random();
                    this.applynumberArray.Seed = s.Next(1000000);
                    this.applynumberArray.PickNumber.Clear();
                    this.PickDataNumber(this.applynumberArray);
                }
            }
            catch
            {
                MessageBox.Show("Error!!! 全种子分析: RandomNumber写入失败");
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"^\d{13}$");
            if ((this.ApplyNumberTextBox.Text != string.Empty) && !regex.IsMatch(this.ApplyNumberTextBox.Text))
            {
                MessageBox.Show("申请编码不是13位编码，请重输！");
                this.ApplyNumberTextBox.Focus();
            }
            else if(this.ApplyNumberTextBox.Text == string.Empty)
            {
                MessageBox.Show("没输入申请编码，请输入！");
                this.ApplyNumberTextBox.Focus();
            }
            else if(!this.applynumberArray.IsApplyNumber(Encoding.UTF8.GetBytes(this.ApplyNumberTextBox.Text.Trim())))
            {
                MessageBox.Show("本期摇号，该编码不存在，请输入有效的编码！");
            }
            else 
            {
                try
                {
                    bool bingo = false;
                    for (int i = 0; i < 600; i++)
                    {
                        Random s = new Random();
                        String str = "";
                        for (int j=0; j<6; j++)
                        {
                            int r = s.Next(10);
                            str = str + r.ToString();
                        }
                        this.SeedNumericTextBox.Text = str;
                        this.SeedNumericTextBox.Show();
                        this.totalNumber = Convert.ToInt32(this.TotalNumberTextBox.Text);
                        this.quotaNumber = Convert.ToInt32(this.QuotaNumberTextBox.Text);
                        this.applynumberArray.Seed = Convert.ToInt32(this.SeedNumericTextBox.Text);
                        this.applynumberArray.PickNumber.Clear();
                        this.PickDataNumber(this.applynumberArray);                        
                        if(this.SimulateFuction())
                        {
                            bingo = true;
                            int year = Convert.ToInt32( Math.Floor(Convert.ToDouble(i) * 2 / 12));
                            int month = (i - year * 6) * 2;
                            MessageBox.Show("已中签！中签仿真分析：共计仿真摇号 " + i.ToString() + " 次；耗时：" + year.ToString() + " 年" + month.ToString() + " 月； 中签随机种子数："+ this.applynumberArray.Seed.ToString() );
                        }
                        if ( (i+1)%6 == 0 )
                        {
                            DialogResult result = MessageBox.Show("未中签，已仿真执行 " + ((i+1)/6).ToString() + " 年, 点击确认继续仿真摇号", "仿真摇号信息",
                                MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                            if (result == DialogResult.Cancel)
                            {
                                bingo = true;
                                break;
                            }
                        }
                    }
                    if(!bingo)
                    {
                        MessageBox.Show("很遗憾！中签仿真分析,已执行仿真至100年后，依旧未中签");
                    }

                }
                catch
                {
                    MessageBox.Show("Error!!! 中签仿真分析失败");
                }
            }
        }
    }
}

