using System.Runtime.Intrinsics.Arm;
using System.Windows.Forms;

namespace StudentActivities
{
    public partial class Form1 : Form
    {
        public string mIdUser;
        public string mFioUser;
        public int access;
        public Form1()
        {
            InitializeComponent();
        }

        private void ïîëüçîâàòåëèToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Users frm = new Users();
            frm.ShowDialog();
        }


        private void ó÷åíèêèToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ó÷åíèêèToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Students frm = new Students();
            frm.ShowDialog();
        }

        private void äèïëîìûÈÑåğòèôèêàòûToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Certificates frm = new Certificates();
            frm.ShowDialog();
        }

        private void ïğîåêòûToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Projects frm = new Projects();
            frm.ShowDialog();
        }

        private void îëèìïèàäûToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Olympiada frm = new Olympiada();
            frm.ShowDialog();
        }

        private void îò÷åòûToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ïğîåêòûToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Report1 frm = new Report1();
            frm.ShowDialog();
        }

        private void ğåçóëüòàòûÎëèìïèàäûToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Report2 frm = new Report2();
            frm.ShowDialog();
        }

        private void âûõîäToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ñïğàâî÷íèêèToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Login login = new Login();
            login.ShowDialog();
            if (!login.Ok)
            {
                this.Close(); ;
            }
            mIdUser = login.mIdUser;
            mFioUser = login.mFioUser;
            access = login.access;

            //Äîñòóï äî ìåíş

            ïîëüçîâàòåëèToolStripMenuItem.Enabled = (access > 3);
            îò÷åòûToolStripMenuItem.Enabled = (access > 3);
            ñïğàâî÷íèêèToolStripMenuItem.Enabled = (access > 3);
            ó÷åíèêèToolStripMenuItem.Enabled = (access > 2);


            toolStripStatusLabel1.Text = Convert.ToString(DateTime.Now).Substring(0, 10);
            toolStripStatusLabel2.Text = mFioUser;
        }


        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ChatGPT frm = new ChatGPT();
            frm.ShowDialog();
        }


        private void çàäà÷èÏîÎëèìïèàäàìToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Guide frm = new Guide();
            frm.ShowDialog();
        }
    }
}