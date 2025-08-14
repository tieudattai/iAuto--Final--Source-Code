using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace L
{
	// Token: 0x02000002 RID: 2
	internal class TextBoxEx : TextBox
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public TextBoxEx()
		{
			this.Initialize();
			base.KeyDown += this.TextBoxEx_KeyDown;
		}

		// Token: 0x06000002 RID: 2 RVA: 0x000029F8 File Offset: 0x00000BF8
		public void Search(string text)
		{
			text = text.VietLen();
			base.SelectionStart = 0;
			int num = 0;
			foreach (string text2 in base.Lines)
			{
				if (text2.VietLen().Contains(text))
				{
					base.SelectionStart = num;
					this.SelectionLength = text2.Length;
					base.ScrollToCaret();
					return;
				}
				num += text2.Length;
			}
			base.ScrollToCaret();
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002A68 File Offset: 0x00000C68
		private void TextBoxEx_KeyDown(object sender, KeyEventArgs e)
		{
			TextBox textBox = sender as TextBox;
			if (e.Control && e.KeyCode == Keys.A)
			{
				textBox.SelectAll();
			}
		}

		// Token: 0x06000004 RID: 4 RVA: 0x0000207B File Offset: 0x0000027B
		public void ScrollToEnd()
		{
			base.SelectionStart = this.TextLength;
			base.ScrollToCaret();
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00002A94 File Offset: 0x00000C94
		private void Initialize()
		{
			this._waterMarkColor = Color.LightGray;
			this._waterMarkActiveColor = Color.Gray;
			this.waterMarkFont = this.Font;
			this.waterMarkBrush = new SolidBrush(this._waterMarkActiveColor);
			this.waterMarkContainer = null;
			this.DrawWaterMark();
			base.Enter += this.ThisHasFocus;
			base.Leave += this.ThisWasLeaved;
			base.TextChanged += this.ThisTextChanged;
		}

		// Token: 0x06000006 RID: 6 RVA: 0x0000208F File Offset: 0x0000028F
		private void RemoveWaterMark()
		{
			if (this.waterMarkContainer != null)
			{
				base.Controls.Remove(this.waterMarkContainer);
				this.waterMarkContainer = null;
			}
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00002B18 File Offset: 0x00000D18
		private void DrawWaterMark()
		{
			if (this.waterMarkContainer == null && this.TextLength <= 0)
			{
				this.waterMarkContainer = new Panel();
				this.waterMarkContainer.Paint += this.waterMarkContainer_Paint;
				this.waterMarkContainer.Invalidate();
				this.waterMarkContainer.Click += this.waterMarkContainer_Click;
				base.Controls.Add(this.waterMarkContainer);
			}
		}

		// Token: 0x06000008 RID: 8 RVA: 0x000020B1 File Offset: 0x000002B1
		private void waterMarkContainer_Click(object sender, EventArgs e)
		{
			base.Focus();
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00002B8C File Offset: 0x00000D8C
		private void waterMarkContainer_Paint(object sender, PaintEventArgs e)
		{
			this.waterMarkContainer.Location = new Point(2, 0);
			this.waterMarkContainer.Height = base.Height;
			this.waterMarkContainer.Width = base.Width;
			this.waterMarkContainer.Anchor = (AnchorStyles.Left | AnchorStyles.Right);
			if (base.ContainsFocus)
			{
				this.waterMarkBrush = new SolidBrush(this._waterMarkActiveColor);
			}
			else
			{
				this.waterMarkBrush = new SolidBrush(this._waterMarkColor);
			}
			e.Graphics.DrawString(this._waterMarkText, this.waterMarkFont, this.waterMarkBrush, new PointF(-2f, 1f));
		}

		// Token: 0x0600000A RID: 10 RVA: 0x000020BA File Offset: 0x000002BA
		private void ThisHasFocus(object sender, EventArgs e)
		{
			this.waterMarkBrush = new SolidBrush(this._waterMarkActiveColor);
			if (this.TextLength <= 0)
			{
				this.RemoveWaterMark();
				this.DrawWaterMark();
			}
		}

		// Token: 0x0600000B RID: 11 RVA: 0x000020E2 File Offset: 0x000002E2
		private void ThisWasLeaved(object sender, EventArgs e)
		{
			if (this.TextLength > 0)
			{
				this.RemoveWaterMark();
				return;
			}
			base.Invalidate();
		}

		// Token: 0x0600000C RID: 12 RVA: 0x000020FA File Offset: 0x000002FA
		private void ThisTextChanged(object sender, EventArgs e)
		{
			if (this.TextLength > 0)
			{
				this.RemoveWaterMark();
				return;
			}
			this.DrawWaterMark();
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00002112 File Offset: 0x00000312
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			this.DrawWaterMark();
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00002121 File Offset: 0x00000321
		protected override void OnInvalidated(InvalidateEventArgs e)
		{
			base.OnInvalidated(e);
			if (this.waterMarkContainer != null)
			{
				this.waterMarkContainer.Invalidate();
			}
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x0600000F RID: 15 RVA: 0x0000213D File Offset: 0x0000033D
		// (set) Token: 0x06000010 RID: 16 RVA: 0x00002145 File Offset: 0x00000345
		[Category("Watermark attribtues")]
		[Description("Sets the text of the watermark")]
		public string WaterMark
		{
			get
			{
				return this._waterMarkText;
			}
			set
			{
				this._waterMarkText = value;
				base.Invalidate();
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000011 RID: 17 RVA: 0x00002154 File Offset: 0x00000354
		// (set) Token: 0x06000012 RID: 18 RVA: 0x0000215C File Offset: 0x0000035C
		[Description("When the control gaines focus, this color will be used as the watermark's forecolor")]
		[Category("Watermark attribtues")]
		public Color WaterMarkActiveForeColor
		{
			get
			{
				return this._waterMarkActiveColor;
			}
			set
			{
				this._waterMarkActiveColor = value;
				base.Invalidate();
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000013 RID: 19 RVA: 0x0000216B File Offset: 0x0000036B
		// (set) Token: 0x06000014 RID: 20 RVA: 0x00002173 File Offset: 0x00000373
		[Description("When the control looses focus, this color will be used as the watermark's forecolor")]
		[Category("Watermark attribtues")]
		public Color WaterMarkForeColor
		{
			get
			{
				return this._waterMarkColor;
			}
			set
			{
				this._waterMarkColor = value;
				base.Invalidate();
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000015 RID: 21 RVA: 0x00002182 File Offset: 0x00000382
		// (set) Token: 0x06000016 RID: 22 RVA: 0x0000218A File Offset: 0x0000038A
		[Description("The font used on the watermark. Default is the same as the control")]
		[Category("Watermark attribtues")]
		public Font WaterMarkFont
		{
			get
			{
				return this.waterMarkFont;
			}
			set
			{
				this.waterMarkFont = value;
				base.Invalidate();
			}
		}

		// Token: 0x04000001 RID: 1
		protected string _waterMarkText = "Default Watermark...";

		// Token: 0x04000002 RID: 2
		protected Color _waterMarkColor;

		// Token: 0x04000003 RID: 3
		protected Color _waterMarkActiveColor;

		// Token: 0x04000004 RID: 4
		private Panel waterMarkContainer;

		// Token: 0x04000005 RID: 5
		private Font waterMarkFont;

		// Token: 0x04000006 RID: 6
		private SolidBrush waterMarkBrush;
	}
}
