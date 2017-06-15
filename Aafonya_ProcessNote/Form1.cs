using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Aafonya_ProcessNote
{
    public partial class ProcessNote : Form
    {
        Process[] process;

        System.Windows.Forms.Timer t;

        public ProcessNote()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            t = new System.Windows.Forms.Timer();
            t.Interval = 10000;
            t.Tick += new EventHandler(t_Tick);
            t.Start();

            checkedListBox1.Visible = true;
            process = Process.GetProcesses();

            foreach (Process prs in process)
            {
                checkedListBox1.Items.Add(prs.ProcessName + "         (" + prs.PrivateMemorySize64.ToString() + ")");
            }
        }

        void t_Tick(object sender, EventArgs e)
        {
            const string text = "Process list updated";
            const string caption = "Update message";
            MessageBoxButtons buttonsForMessageBox = MessageBoxButtons.OK;
            MessageBox.Show(text, caption, buttonsForMessageBox);

            foreach (Process prs in process)
            {
                checkedListBox1.Items.Remove(prs);
            }

            process = null;
            process = Process.GetProcesses();

            foreach (Process prs in process)
            {
                checkedListBox1.Items.Add(prs.ProcessName + "         (" + prs.PrivateMemorySize64.ToString() + ")");
            }
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            t.Stop();

            checkedListBox1.Visible = false;
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            const string text = "Process list updated";
            const string caption = "Caption";
            MessageBoxButtons buttonsForMessageBox = MessageBoxButtons.OK;
            MessageBox.Show(text, caption, buttonsForMessageBox);

            foreach (Process prs in process)
            {
                checkedListBox1.Items.Remove(prs);
            }

            process = null;
            process = Process.GetProcesses();

            foreach (Process prs in process)
            {
                checkedListBox1.Items.Add(prs.ProcessName + "         (" + prs.PrivateMemorySize64.ToString() + prs.Id  + ")");
            }
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int index = e.Index;
            listBox1.Items.Add("Valami");
            listBox1.Items.Add(process[index].TotalProcessorTime);
            listBox1.Items.Add(process[index].PagedMemorySize64);
            listBox1.Items.Add("Valami");
            //System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
            //messageBoxCS.AppendFormat("{0} = {1}", "Index", e.Index);
            //messageBoxCS.AppendLine();
            //messageBoxCS.AppendFormat("{0} = {1}", "NewValue", e.NewValue);
            //messageBoxCS.AppendLine();
            //messageBoxCS.AppendFormat("{0} = {1}", "CurrentValue", e.CurrentValue);
            //messageBoxCS.AppendLine();
            //MessageBox.Show(messageBoxCS.ToString(), "ItemCheck Event");
        }

    }
}
