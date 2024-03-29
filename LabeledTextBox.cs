﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace TenAndLitvinovWFControlLibrary
{
    [Designer(typeof(ControlDesignerEx))]
    public partial class LabeledTextBox : Control
    {
        //-------------------------------------------------------------
        private string _labelText = "LabelText";
        public string LabelText
        {
            get { return _labelText; }
            set{
                _labelText = value;
                Invalidate();
            }
        }
        //------------------------------------------------------------
        public Color LabelColor { get; set; } = Color.Black;
        //----------------------------------------------------------
        protected override Size DefaultSize
        {
            get { return new Size(125, 15+26); }
        }
        //----------------------------------------------------------------------
        private TextBox tb;
        public TextBox TextBox
        {
            get { return tb; }
        }
        //---------------------------------------------------------------------------------
        public LabeledTextBox()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            InitializeComponent();
            Height = 15 + 26;
            Width = 125;
            
            tb = new TextBox();
            Controls.Add(tb);
            tb.TextChanged += Tb_TextChanged;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graph = e.Graphics;
            graph.SmoothingMode = SmoothingMode.HighQuality;
            graph.Clear(Parent.BackColor);
            graph.DrawString(LabelText, Font, new SolidBrush(LabelColor), new Point(0, 0));
            
            Height = 15 + 26;
            tb.Location = new Point(0, 15);
            tb.Text = this.Text;
            tb.Width = this.Width;
        }
        protected override void OnTextChanged(EventArgs e)
        {
            tb.Text = this.Text;
        }
        private void Tb_TextChanged(object sender, EventArgs e)
        {
            this.Text = tb.Text;
        }
    }//c
    //----------------------------------------------------------------------------------
    class ControlDesignerEx : ControlDesigner
    {
        public override SelectionRules SelectionRules
        {
            get
            {
                SelectionRules sr = SelectionRules.LeftSizeable | SelectionRules.RightSizeable | SelectionRules.Moveable | SelectionRules.Visible;
                return sr;
            }
        }
    }
    //----------------------------------------------------------------------------------
}
