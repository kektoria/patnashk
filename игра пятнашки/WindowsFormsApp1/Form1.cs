using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        Panel panel = new Panel();
        TableLayoutPanel table = new TableLayoutPanel();

        List<Button> listButtons = new List<Button>();

        static int Columns = 0, Rows = 0;

        Button[] buttons;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button btnClicked = (Button)sender;
            int numberButton = Convert.ToInt32(btnClicked.Tag) - 1;

            int y = numberButton / Columns;
            int x = numberButton - y * Columns;

            int yUp = y - 1;
            int yDown = y + 1;

            int xLeft = x - 1;
            int xRight = x + 1;

            if (xRight < Columns)
            {
                int changedButtonRight = y * Columns + xRight;
                if (!buttons[changedButtonRight].Visible)
                {
                    buttons[changedButtonRight].Visible = true;
                    buttons[numberButton].Visible = false;
                    buttons[changedButtonRight].Text = buttons[numberButton].Text;
                    buttons[numberButton].Text = buttons.Length.ToString();
                }
            }
            if (xLeft >= 0)
            {
                int changedButtonLeft = y * Columns + xLeft;
                if (!buttons[changedButtonLeft].Visible)
                {
                    buttons[changedButtonLeft].Visible = true;
                    buttons[numberButton].Visible = false;
                    buttons[changedButtonLeft].Text = buttons[numberButton].Text;
                    buttons[numberButton].Text = buttons.Length.ToString();
                }
            }
            if (yUp >= 0)
            {
                int changedButtonUp = yUp * Columns + x;
                if (!buttons[changedButtonUp].Visible)
                {
                    buttons[changedButtonUp].Visible = true;
                    buttons[numberButton].Visible = false;
                    buttons[changedButtonUp].Text = buttons[numberButton].Text;
                    buttons[numberButton].Text = buttons.Length.ToString();
                }
            }
            if (yDown < Columns)
            {
                int changedButtonDown = yDown * Columns + x;
                if (!buttons[changedButtonDown].Visible)
                {
                    buttons[changedButtonDown].Visible = true;
                    buttons[numberButton].Visible = false;
                    buttons[changedButtonDown].Text = buttons[numberButton].Text;
                    buttons[numberButton].Text = buttons.Length.ToString();
                }
            }

            bool win = checkAllPosition();
            if (win)
            {
                MessageBox.Show("Congratulation!");
            }
        }

        private void CREATE_TABLE()
        {
            panel.Controls.Clear();
            table = new TableLayoutPanel();
            table.Dock = DockStyle.Fill;
            panel.Width = Convert.ToInt32(this.Width * 0.97f);
            panel.Height = Convert.ToInt32(this.Height * 0.93f);
            table.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
            table.Location = new Point(0, 0);
            table.Visible = true;
            table.ColumnCount = Convert.ToInt32(Columns);
            table.RowCount = Convert.ToInt32(Rows);

            int width = 100 / table.ColumnCount;
            int height = 100 / table.RowCount;
            int count = 1;



            for (int row = 0; row < table.RowCount; row++)
            {
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, width));
                for (int col = 0; col < table.ColumnCount; col++)
                {
                    if (col == 0)
                    {
                        table.RowStyles.Add(new RowStyle(SizeType.Percent, height));
                    }

                    var button = new Button();
                    button.Dock = System.Windows.Forms.DockStyle.Fill;
                    button.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                    button.Location = new System.Drawing.Point(11, 11);
                    button.Margin = new System.Windows.Forms.Padding(10);
                    button.Name = ("button" + count).ToString();
                    button.Size = new System.Drawing.Size(112, 100);
                    button.TabIndex = 0;
                    button.Tag = count.ToString();
                    button.Text = count.ToString();
                    button.UseVisualStyleBackColor = true;
                    button.Click += new System.EventHandler(this.button1_Click);
                    table.Controls.Add(button, col, row);
                    buttons[count - 1] = button;
                    count++;
                }
            }
            buttons[count - 2].Visible = false;
            Controls.Add(panel);
            panel.Controls.Add(table);
        }

        private void randomButtons()
        {
            Random rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
                Button currentBtn = buttons[rnd.Next(0, buttons.Length)];
                int numberButton = Convert.ToInt32(currentBtn.Tag) - 1;

                Button currentBtn2 = buttons[rnd.Next(0, buttons.Length)];
                int numberButton2 = Convert.ToInt32(currentBtn2.Tag) - 1;

                if (buttons[numberButton].Text != buttons.Length.ToString() && buttons[numberButton2].Text != buttons.Length.ToString())
                {
                    string text = buttons[numberButton].Text;
                    buttons[numberButton].Text = buttons[numberButton2].Text;
                    currentBtn2.Text = text;
                }
            }
        }

        private bool checkAllPosition()
        {
            for (int i = 0; i < buttons.Length - 1; i++)
            {
                if (buttons[i].Tag.ToString() == buttons[i].Text.ToString())
                {
                    continue;
                }
                return false;
            }
            return true;
        }

        private void x3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Columns = 3;
            Rows = 3;
            buttons = new Button[Columns * Rows];
            CREATE_TABLE();
            //randomButtons();
        }

        private void x4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Columns = 4;
            Rows = 4;
            buttons = new Button[Columns * Rows];
            CREATE_TABLE();
            //randomButtons();
        }

        private void x5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Columns = 5;
            Rows = 5;
            buttons = new Button[Columns * Rows];
            CREATE_TABLE();
            //randomButtons();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // CREATE_TABLE();
        }
    }
}
