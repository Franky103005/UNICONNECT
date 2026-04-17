using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UNICONNECT1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private Panel shadowPanel;
        private readonly string studentPlaceholder = "e.g 2024-2-1234";

        private void Form1_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;

            panel1.Dock = DockStyle.Fill;

            txtPassword.UseSystemPasswordChar = true;

            txtStudentId.Text = studentPlaceholder;
            txtStudentId.ForeColor = Color.DarkGray;
            txtStudentId.Enter += (s, ev) => {
                if (txtStudentId.Text == studentPlaceholder) { txtStudentId.Text = ""; txtStudentId.ForeColor = Color.Black; }
            };

            txtStudentId.KeyPress += TxtStudentId_KeyPress;
            txtStudentId.Leave += (s, ev) => {
                if (string.IsNullOrWhiteSpace(txtStudentId.Text)) { txtStudentId.Text = studentPlaceholder; txtStudentId.ForeColor = Color.DarkGray; }
            };

            pnlCard.BackColor = Color.White;
            pnlCard.Padding = new Padding(30);
            pnlCard.WrapContents = false;
            pnlCard.FlowDirection = FlowDirection.TopDown;
            pnlCard.AutoSize = false;
            pnlCard.Size = new Size(420, 480);


            // Configure existing designer controls instead of creating duplicates
            chkRemember.AutoSize = true;
            chkRemember.ForeColor = Color.DimGray;
            chkRemember.Margin = new Padding(3, 15, 3, 3);

            // draw a round dot inside the existing infoDot panel
            infoDot.Paint += (s, ev) => {
                using (var b = new SolidBrush(Color.DarkRed)) ev.Graphics.FillEllipse(b, 0, 0, infoDot.Width - 1, infoDot.Height - 1);
            };

            infoPanel.FlowDirection = FlowDirection.LeftToRight;
            infoPanel.AutoSize = true;
            infoPanel.Margin = new Padding(3, 10, 3, 3);

            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.BackColor = Color.DarkRed;
            btnLogin.ForeColor = Color.White;
            btnLogin.Width = 338;
            btnLogin.Height = 42;
            btnLogin.Margin = new Padding(3, 20, 3, 3);

            footerLabel.Text = "Forgot password? Contact the ICTD";
            footerLabel.ForeColor = Color.DimGray;
            footerLabel.TextAlign = ContentAlignment.MiddleCenter;

            shadowPanel = new Panel { BackColor = Color.FromArgb(80, 0, 0, 0) };
            panel1.Controls.Add(shadowPanel);

            CenterCardAndShadow();
            this.Resize += (s, ev) => CenterCardAndShadow();
        }

        private void CenterCardAndShadow()
        {
            pnlCard.Location = new Point((panel1.ClientSize.Width - pnlCard.Width) / 2, (panel1.ClientSize.Height - pnlCard.Height) / 2);

            var offset = 10;
            shadowPanel.Bounds = new Rectangle(pnlCard.Left + offset, pnlCard.Top + offset, pnlCard.Width, pnlCard.Height);

            int radius = 12;
            var r = new Rectangle(0, 0, pnlCard.Width, pnlCard.Height);
            using (var gp = CreateRoundRectPath(r, radius))
            {
                pnlCard.Region = new Region(gp);
            }
            var rs = new Rectangle(0, 0, shadowPanel.Width, shadowPanel.Height);
            using (var gp2 = CreateRoundRectPath(rs, radius))
            {
                shadowPanel.Region = new Region(gp2);
            }
        }

        private GraphicsPath CreateRoundRectPath(Rectangle r, int radius)
        {
            var path = new GraphicsPath();
            int d = radius * 2;
            path.StartFigure();
            path.AddArc(r.Left, r.Top, d, d, 180, 90);
            path.AddArc(r.Right - d, r.Top, d, d, 270, 90);
            path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            path.AddArc(r.Left, r.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void TxtStudentId_KeyPress(object sender, KeyPressEventArgs e)
        {
            // if placeholder is showing and user types a printable char, clear placeholder so the typed char appears
            if (txtStudentId.ForeColor == Color.DarkGray && txtStudentId.Text == studentPlaceholder)
            {
                // clear placeholder and set normal color; do not suppress the key so it will be added
                txtStudentId.Text = string.Empty;
                txtStudentId.ForeColor = Color.Black;
                txtStudentId.SelectionStart = 0;
            }
        }

        private void infoPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtStudentId_TextChanged(object sender, EventArgs e)
        {

        }

        private void pbLogo_Click(object sender, EventArgs e)
        {

        }
    }
}
