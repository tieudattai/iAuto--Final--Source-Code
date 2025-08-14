namespace L
{
	// Token: 0x0200000E RID: 14
	internal partial class m : global::System.Windows.Forms.Form
	{
		// Token: 0x0600008B RID: 139 RVA: 0x000025BC File Offset: 0x000007BC
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.cs != null)
			{
				this.cs.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00004288 File Offset: 0x00002488
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.ex = new System.Windows.Forms.ToolStripMenuItem();
            this.hk = new System.Windows.Forms.NotifyIcon(this.components);
            this.lk = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ot = new System.Windows.Forms.ToolStripMenuItem();
            this.ll = new System.Windows.Forms.Button();
            this.gr = new System.Windows.Forms.Label();
            this.fd = new System.Windows.Forms.Label();
            this.kk = new System.Windows.Forms.CheckBox();
            this.pp = new System.Windows.Forms.Panel();
            this.p = new L.TextBoxEx();
            this.w = new System.Windows.Forms.Button();
            this.sj = new System.Windows.Forms.Panel();
            this.u = new L.TextBoxEx();
            this.pw = new System.Windows.Forms.Panel();
            this.ta = new System.Windows.Forms.TableLayoutPanel();
            this.yd = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnR = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txtPass = new L.TextBoxEx();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtReTypePass = new L.TextBoxEx();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtU = new L.TextBoxEx();
            this.label2 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lk.SuspendLayout();
            this.pp.SuspendLayout();
            this.sj.SuspendLayout();
            this.pw.SuspendLayout();
            this.ta.SuspendLayout();
            this.yd.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ex
            // 
            this.ex.Name = "ex";
            this.ex.Size = new System.Drawing.Size(109, 22);
            this.ex.Text = "Exit";
            this.ex.Click += new System.EventHandler(this.no);
            // 
            // hk
            // 
            this.hk.ContextMenuStrip = this.lk;
            this.hk.Text = "iAuto_DarkMode";
            this.hk.Visible = true;
            // 
            // lk
            // 
            this.lk.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ot,
            this.ex});
            this.lk.Name = "contextMenuStrip";
            this.lk.Size = new System.Drawing.Size(110, 48);
            this.lk.Opening += new System.ComponentModel.CancelEventHandler(this.ti);
            // 
            // ot
            // 
            this.ot.Name = "ot";
            this.ot.Size = new System.Drawing.Size(109, 22);
            this.ot.Text = "OnTop";
            this.ot.Click += new System.EventHandler(this.ls);
            // 
            // ll
            // 
            this.ll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(157)))), ((int)(((byte)(88)))));
            this.ll.Dock = System.Windows.Forms.DockStyle.Top;
            this.ll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ll.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ll.ForeColor = System.Drawing.Color.White;
            this.ll.Location = new System.Drawing.Point(3, 106);
            this.ll.Name = "ll";
            this.ll.Size = new System.Drawing.Size(418, 29);
            this.ll.TabIndex = 3;
            this.ll.TabStop = false;
            this.ll.Text = "Login [Đăng Nhập]";
            this.ll.UseVisualStyleBackColor = false;
            this.ll.Click += new System.EventHandler(this.lu);
            // 
            // gr
            // 
            this.gr.Dock = System.Windows.Forms.DockStyle.Left;
            this.gr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gr.ForeColor = System.Drawing.SystemColors.GrayText;
            this.gr.Location = new System.Drawing.Point(0, 0);
            this.gr.Name = "gr";
            this.gr.Size = new System.Drawing.Size(110, 27);
            this.gr.TabIndex = 24;
            this.gr.Text = "Pass:";
            this.gr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fd
            // 
            this.fd.Dock = System.Windows.Forms.DockStyle.Left;
            this.fd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fd.ForeColor = System.Drawing.SystemColors.GrayText;
            this.fd.Location = new System.Drawing.Point(0, 0);
            this.fd.Name = "fd";
            this.fd.Size = new System.Drawing.Size(110, 27);
            this.fd.TabIndex = 2;
            this.fd.Text = "User:";
            this.fd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // kk
            // 
            this.kk.AutoSize = true;
            this.kk.Dock = System.Windows.Forms.DockStyle.Right;
            this.kk.Location = new System.Drawing.Point(398, 0);
            this.kk.Name = "kk";
            this.kk.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.kk.Size = new System.Drawing.Size(20, 27);
            this.kk.TabIndex = 3;
            this.kk.TabStop = false;
            this.kk.UseVisualStyleBackColor = true;
            this.kk.CheckedChanged += new System.EventHandler(this.gj);
            // 
            // pp
            // 
            this.pp.Controls.Add(this.p);
            this.pp.Controls.Add(this.kk);
            this.pp.Controls.Add(this.gr);
            this.pp.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pp.Location = new System.Drawing.Point(0, 33);
            this.pp.Name = "pp";
            this.pp.Size = new System.Drawing.Size(418, 27);
            this.pp.TabIndex = 0;
            // 
            // p
            // 
            this.p.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.p.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p.Location = new System.Drawing.Point(110, 0);
            this.p.Margin = new System.Windows.Forms.Padding(4);
            this.p.Name = "p";
            this.p.PasswordChar = '*';
            this.p.Size = new System.Drawing.Size(288, 20);
            this.p.TabIndex = 2;
            this.p.WaterMark = "Mật Khẩu";
            this.p.WaterMarkActiveForeColor = System.Drawing.Color.Gray;
            this.p.WaterMarkFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p.WaterMarkForeColor = System.Drawing.Color.LightGray;
            this.p.KeyDown += new System.Windows.Forms.KeyEventHandler(this.np);
            // 
            // w
            // 
            this.w.BackColor = System.Drawing.Color.White;
            this.w.Dock = System.Windows.Forms.DockStyle.Top;
            this.w.FlatAppearance.BorderSize = 0;
            this.w.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.w.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.w.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(157)))), ((int)(((byte)(88)))));
            this.w.Location = new System.Drawing.Point(3, 3);
            this.w.Name = "w";
            this.w.Size = new System.Drawing.Size(418, 27);
            this.w.TabIndex = 4;
            this.w.TabStop = false;
            this.w.Text = "darkauto.org";
            this.w.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.w.UseVisualStyleBackColor = false;
            this.w.Click += new System.EventHandler(this.th);
            // 
            // sj
            // 
            this.sj.Controls.Add(this.u);
            this.sj.Controls.Add(this.fd);
            this.sj.Dock = System.Windows.Forms.DockStyle.Top;
            this.sj.Location = new System.Drawing.Point(0, 0);
            this.sj.Name = "sj";
            this.sj.Size = new System.Drawing.Size(418, 27);
            this.sj.TabIndex = 1;
            // 
            // u
            // 
            this.u.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.u.Dock = System.Windows.Forms.DockStyle.Fill;
            this.u.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.u.Location = new System.Drawing.Point(110, 0);
            this.u.Margin = new System.Windows.Forms.Padding(4);
            this.u.Name = "u";
            this.u.Size = new System.Drawing.Size(308, 20);
            this.u.TabIndex = 1;
            this.u.WaterMark = "Tài Khoản";
            this.u.WaterMarkActiveForeColor = System.Drawing.Color.Gray;
            this.u.WaterMarkFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.u.WaterMarkForeColor = System.Drawing.Color.LightGray;
            this.u.TextChanged += new System.EventHandler(this.u_TextChanged);
            this.u.KeyDown += new System.Windows.Forms.KeyEventHandler(this.yh);
            // 
            // pw
            // 
            this.pw.Controls.Add(this.ta);
            this.pw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pw.Location = new System.Drawing.Point(0, 0);
            this.pw.Name = "pw";
            this.pw.Size = new System.Drawing.Size(424, 140);
            this.pw.TabIndex = 1;
            // 
            // ta
            // 
            this.ta.ColumnCount = 1;
            this.ta.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ta.Controls.Add(this.ll, 0, 2);
            this.ta.Controls.Add(this.w, 0, 0);
            this.ta.Controls.Add(this.yd, 0, 1);
            this.ta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ta.Location = new System.Drawing.Point(0, 0);
            this.ta.Name = "ta";
            this.ta.RowCount = 3;
            this.ta.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ta.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            this.ta.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ta.Size = new System.Drawing.Size(424, 140);
            this.ta.TabIndex = 0;
            // 
            // yd
            // 
            this.yd.Controls.Add(this.pp);
            this.yd.Controls.Add(this.sj);
            this.yd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yd.Location = new System.Drawing.Point(3, 40);
            this.yd.Name = "yd";
            this.yd.Size = new System.Drawing.Size(418, 60);
            this.yd.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(424, 137);
            this.panel1.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.btnR, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 96F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(424, 137);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnR
            // 
            this.btnR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(157)))), ((int)(((byte)(88)))));
            this.btnR.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnR.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnR.ForeColor = System.Drawing.Color.White;
            this.btnR.Location = new System.Drawing.Point(3, 99);
            this.btnR.Name = "btnR";
            this.btnR.Size = new System.Drawing.Size(418, 29);
            this.btnR.TabIndex = 7;
            this.btnR.TabStop = false;
            this.btnR.Text = "Register [Đăng Ký]";
            this.btnR.UseVisualStyleBackColor = false;
            this.btnR.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(418, 90);
            this.panel2.TabIndex = 0;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.txtPass);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 31);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(418, 32);
            this.panel5.TabIndex = 2;
            // 
            // txtPass
            // 
            this.txtPass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPass.Location = new System.Drawing.Point(110, 0);
            this.txtPass.Margin = new System.Windows.Forms.Padding(4);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(308, 20);
            this.txtPass.TabIndex = 10;
            this.txtPass.TabStop = false;
            this.txtPass.WaterMark = "Mật Khẩu";
            this.txtPass.WaterMarkActiveForeColor = System.Drawing.Color.Gray;
            this.txtPass.WaterMarkFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPass.WaterMarkForeColor = System.Drawing.Color.LightGray;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 32);
            this.label3.TabIndex = 2;
            this.label3.Text = "Pass:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtReTypePass);
            this.panel3.Controls.Add(this.checkBox1);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 63);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(418, 27);
            this.panel3.TabIndex = 0;
            // 
            // txtReTypePass
            // 
            this.txtReTypePass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtReTypePass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtReTypePass.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReTypePass.Location = new System.Drawing.Point(110, 0);
            this.txtReTypePass.Margin = new System.Windows.Forms.Padding(4);
            this.txtReTypePass.Name = "txtReTypePass";
            this.txtReTypePass.PasswordChar = '*';
            this.txtReTypePass.Size = new System.Drawing.Size(288, 20);
            this.txtReTypePass.TabIndex = 11;
            this.txtReTypePass.TabStop = false;
            this.txtReTypePass.WaterMark = "Nhập Lại Mật Khẩu";
            this.txtReTypePass.WaterMarkActiveForeColor = System.Drawing.Color.Gray;
            this.txtReTypePass.WaterMarkFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReTypePass.WaterMarkForeColor = System.Drawing.Color.LightGray;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.checkBox1.Location = new System.Drawing.Point(398, 0);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.checkBox1.Size = new System.Drawing.Size(20, 27);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.TabStop = false;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 27);
            this.label1.TabIndex = 24;
            this.label1.Text = "Retype Pass:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txtU);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(418, 27);
            this.panel4.TabIndex = 1;
            // 
            // txtU
            // 
            this.txtU.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtU.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtU.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtU.Location = new System.Drawing.Point(110, 0);
            this.txtU.Margin = new System.Windows.Forms.Padding(4);
            this.txtU.Name = "txtU";
            this.txtU.Size = new System.Drawing.Size(308, 20);
            this.txtU.TabIndex = 9;
            this.txtU.TabStop = false;
            this.txtU.WaterMark = "Tài Khoản";
            this.txtU.WaterMarkActiveForeColor = System.Drawing.Color.Gray;
            this.txtU.WaterMarkFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtU.WaterMarkForeColor = System.Drawing.Color.LightGray;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 27);
            this.label2.TabIndex = 2;
            this.label2.Text = "User:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pw);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(424, 281);
            this.splitContainer1.SplitterDistance = 140;
            this.splitContainer1.TabIndex = 3;
            this.splitContainer1.TabStop = false;
            // 
            // m
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(424, 281);
            this.Controls.Add(this.splitContainer1);
            this.Name = "m";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "iAuto_DarkMode";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fi);
            this.Load += new System.EventHandler(this.m_Load);
            this.lk.ResumeLayout(false);
            this.pp.ResumeLayout(false);
            this.pp.PerformLayout();
            this.sj.ResumeLayout(false);
            this.sj.PerformLayout();
            this.pw.ResumeLayout(false);
            this.ta.ResumeLayout(false);
            this.yd.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		// Token: 0x0400004C RID: 76
		private global::System.ComponentModel.IContainer cs;

		// Token: 0x0400004D RID: 77
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400004E RID: 78
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x0400004F RID: 79
		private global::System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;

		// Token: 0x04000050 RID: 80
		private global::System.Windows.Forms.Button btnR;

		// Token: 0x04000051 RID: 81
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x04000052 RID: 82
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x04000053 RID: 83
		private global::L.TextBoxEx txtReTypePass;

		// Token: 0x04000054 RID: 84
		private global::System.Windows.Forms.CheckBox checkBox1;

		// Token: 0x04000055 RID: 85
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000056 RID: 86
		private global::System.Windows.Forms.Panel panel4;

		// Token: 0x04000057 RID: 87
		private global::L.TextBoxEx txtU;

		// Token: 0x04000058 RID: 88
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000059 RID: 89
		private global::System.Windows.Forms.Panel panel5;

		// Token: 0x0400005A RID: 90
		private global::L.TextBoxEx txtPass;

		// Token: 0x0400005B RID: 91
		private global::System.Windows.Forms.Label label3;

		// Token: 0x0400005C RID: 92
		private global::System.Windows.Forms.SplitContainer splitContainer1;

		// Token: 0x0400005D RID: 93
		private global::L.TextBoxEx u;

		// Token: 0x0400005E RID: 94
		private global::System.Windows.Forms.ToolStripMenuItem ex;

		// Token: 0x0400005F RID: 95
		private global::System.Windows.Forms.NotifyIcon hk;

		// Token: 0x04000060 RID: 96
		private global::System.Windows.Forms.ContextMenuStrip lk;

		// Token: 0x04000061 RID: 97
		private global::System.Windows.Forms.ToolStripMenuItem ot;

		// Token: 0x04000062 RID: 98
		private global::System.Windows.Forms.Button ll;

		// Token: 0x04000063 RID: 99
		private global::System.Windows.Forms.Label gr;

		// Token: 0x04000064 RID: 100
		private global::L.TextBoxEx p;

		// Token: 0x04000065 RID: 101
		private global::System.Windows.Forms.Label fd;

		// Token: 0x04000066 RID: 102
		private global::System.Windows.Forms.CheckBox kk;

		// Token: 0x04000067 RID: 103
		private global::System.Windows.Forms.Panel pp;

		// Token: 0x04000068 RID: 104
		private global::System.Windows.Forms.Button w;

		// Token: 0x04000069 RID: 105
		private global::System.Windows.Forms.Panel sj;

		// Token: 0x0400006A RID: 106
		private global::System.Windows.Forms.Panel pw;

		// Token: 0x0400006B RID: 107
		private global::System.Windows.Forms.TableLayoutPanel ta;

		// Token: 0x0400006C RID: 108
		private global::System.Windows.Forms.Panel yd;
	}
}
