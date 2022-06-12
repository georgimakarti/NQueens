namespace Queens
{
    public partial class Form1 : Form
    {
        private int N; // queens' number

        bool IsStrike(int x1, int x2, int y1, int y2)
        {
            if(x1 == x2 || y1 == y2)
            {
                return true;
            }

            // Main Diagonals Check

            int tx, ty;

            tx = x1 - 1;
            ty = y1 - 1;

            // Left - up
            while((tx >= 1) && (ty >= 1))
            {
                if((tx == x2) && (ty == y2))
                    return true;
                    tx--;
                    ty--;
            }

            // Right - down
            tx = x1 + 1; 
            ty = y1 + 1;
            while ((tx <= N) && (ty <= N))
            {
                if((tx == x2) && (ty == y2))
                    return true;
                    tx++; ty++;
            }

            // Right - up

            tx = x1 + 1; ty = y1 - 1;
            while ((tx <= N) && (ty >= 1))
            {
                if ((tx == x2) && (ty == y2)) 
                    return true;
                    tx++; ty--;
            }

            // Left - down
            tx = x1 - 1; ty = y1 + 1;
            while ((tx >= 1) && (ty <= N))
            {
                if ((tx == x2) && (ty == y2)) 
                    return true;
                    tx--; ty++;
            }
            return false;

        }

        bool Strike(int[]M, int p)
        {
            int px, py, x, y;
            px = M[p];py = p;

            for (int i = 1; i <= p - 1; i++)
            {
                x = M[i];
                y = i;
                if (IsStrike(x, y, px, py))
                    return true;
            }
            return false;
        }

        void DataGridViewInit(int N)
        {
            dataGridView1.Columns.Clear();

            for (int i = 1; i <= N; i++)
            {
                dataGridView1.Columns.Add("i" + i.ToString(), i.ToString());

                dataGridView1.Columns[i - 1].Width = 30;
            }

            dataGridView1.Rows.Add(N);

            for(int i = 1; i <= N; i++)
            {
                dataGridView1.Rows[i - 1].HeaderCell.Value = i.ToString();
            }
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        void ShowDataGridView(string s, int N)
        {
            int i;
            int j;
            string xs, ys;
            int x, y;

            // first clear the dataGridView1
            for (i = 0; i < N; i++)
                for (j = 0; j < N; j++)
                    dataGridView1.Rows[i].Cells[j].Value = "";

            j = 0; // offset
            for (i = 0; i < N; i++)
            {
                // form xs
                xs = "";
                while (s[j] != ',')
                {
                    xs = xs + s[j].ToString();
                    j++;
                } // xs - number x as a string

                // scroll offset
                j++;

                // form ys
                ys = "";
                while (s[j] != '-')
                {
                    ys = ys + s[j].ToString();
                    j++;
                }

                // scroll offset
                j++;

                // converting: xs->x, ys->y
                x = Convert.ToInt32(xs);
                y = Convert.ToInt32(ys);

                // designate the position x, y of a queen
                dataGridView1.Rows[y - 1].Cells[x - 1].Value = "X";
            }
        }
        // 3.6  https://www.bestprog.net/en/2019/05/01/the-problem-of-n-queens-solution-using-c/#p03_6



        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}