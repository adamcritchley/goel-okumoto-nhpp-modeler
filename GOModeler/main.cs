using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class main : Form
    {
        public List<CsvEntry> entries = new List<CsvEntry>();
        public double mlA;
        public double mlB;

        public class CsvEntry
        {
            public int id;
            public double failure;
            public double predicted;
        }

        public main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.Text = "Goel-Okumoto NHPP Modeling - [" + openFileDialog1.SafeFileName +"]";

                mlA = mlB = 0.0;
                entries.Clear();
                listView1.Items.Clear();

                StreamReader fd = new StreamReader(openFileDialog1.OpenFile());

                try
                {
                    double last_error = 0.0;

                    if (skipHeader.Checked == true)
                    {
                        fd.ReadLine(); // skip header
                    }

                    while (!fd.EndOfStream)
                    {
                        String line = fd.ReadLine();
                        String[] fields = line.Split('\t');
                        if (fields.Length <= 1)
                        {
                            fields = line.Split(' ');
                        }
                        
                        if (fields.Length <= 1)
                        {
                            fields = line.Split(',');
                        }

                        if( fields.Length > 1 )
                        {
                            CsvEntry entry = new CsvEntry();
                            int fail_id = Convert.ToInt32(fields[0]);
                            double fail_time = Convert.ToDouble(fields[1]);

                            if (inCum.Checked == true)
                            {
                                double cum_error = fail_time;
                                fail_time = fail_time - last_error;
                                last_error = cum_error;
                            }

                            entry.id = fail_id;
                            entry.failure = fail_time;
                            entries.Add(entry);
                        }
                    }

                    if (skipLastItem.Checked == true)
                    {
                        entries.RemoveAt( entries.Count - 1 );
                    }
                }
                catch (Exception except)
                {
                    throw except;
                }

                fd.Close();

                // Calculate A and B from maximum likelyhood
                calcAB(entries, ref mlA, ref mlB);

                // Model the data against Goel-Okumoto
                calcGO(entries, mlA, mlB);

                maxPrediction.Text = entries.Count.ToString();

                foreach (CsvEntry entry in entries)
                {
                    ListViewItem i = new ListViewItem();
                    ListViewItem.ListViewSubItem failure_i = new ListViewItem.ListViewSubItem();
                    ListViewItem.ListViewSubItem predicted_i = new ListViewItem.ListViewSubItem();
                    i.Text = entry.id.ToString();
                    failure_i.Text = entry.failure.ToString();
                    predicted_i.Text = entry.predicted.ToString();
                    i.SubItems.Add(failure_i);
                    i.SubItems.Add(predicted_i);
                    listView1.Items.Add(i);
                }

                textBox1.Text = "a = " + mlA.ToString();
                textBox2.Text = "b = " + mlB.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter fd = new StreamWriter(saveFileDialog1.OpenFile());

                fd.WriteLine("Failure Number,Failure Interval Length");
                foreach (ListViewItem item in listView1.Items)
                {
                    fd.WriteLine(item.Text + "," + item.SubItems[2].Text);
                }
                fd.Close();
            }
        }

        private void calcAB(List<CsvEntry> entries, ref double a, ref double b )
        {
            double k=entries.Count;
            double l = 0;
            double u = 3;
            
            double n = 0;
            foreach( CsvEntry entry in entries )
            {
                n += entry.failure;
            }

            while ((u - l) > 0.001)
            {
                b = (l + u) / 2.0;
                double summa = 0;
                for (int i = 1; i < k; i++)
                {
                    double namn = Math.Exp(-b * (i - 1.0)) - Math.Exp(-b * i);
                    summa = summa + entries[i].failure * 
                        (i * Math.Exp(-b * i) - (i - 1.0) * 
                        Math.Exp(-b * (i - 1.0))) / namn;
                }
                summa = summa + entries[0].failure *
                    (1.0 * Math.Exp(-b)) / (1.0 - Math.Exp(-b * 1));
                summa = summa - n * k *
                    Math.Exp(-b * k) / (1.0 - Math.Exp(-b * k));

                if (summa < 0)
                    u = b;
                else
                    l = b;
            }

            a = n / (1.0 - Math.Exp(-b * k));
        }

        private void calcGO(List<CsvEntry> entries, double a, double b)
        {
            double last_errors = 0.0;
            for (int y = 0; y < entries.Count; y++)
            {
                double t = (y + 1);
                double m_t = a * (1.0 - Math.Exp(-b * t));

                if (outCum.Checked == false)
                {
                    double cum_errors = m_t;
                    m_t = m_t - last_errors;
                    last_errors = cum_errors;
                }

                entries[y].predicted = m_t;
            }
        }

        private double Factorial(double x)
        {
            double a = 1.0;

            for (int i = 2; i <= x; i++)
            {
                a *= i;
            }

            return a;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int max = Convert.ToInt32( maxPrediction.Text );

            listView1.Items.Clear();
            double last_errors = 0.0;
            for (int y = 0; y < max; y++)
            {
                ListViewItem i = new ListViewItem();
                ListViewItem.ListViewSubItem failure_i = new ListViewItem.ListViewSubItem();
                ListViewItem.ListViewSubItem predicted_i = new ListViewItem.ListViewSubItem();

                if (y < entries.Count)
                {
                    CsvEntry entry = entries[y];
                    failure_i.Text = entry.failure.ToString();
                }
                else
                {
                    failure_i.Text = "N/A";
                }

                double t = (y + 1);
                i.Text = t.ToString();
                double m_t = mlA * (1.0 - Math.Exp(-mlB * t));

                if (outCum.Checked == false)
                {
                    double cum_errors = m_t;
                    m_t = m_t - last_errors;
                    last_errors = cum_errors;
                }

                predicted_i.Text = m_t.ToString();

                i.SubItems.Add(failure_i);
                i.SubItems.Add(predicted_i);
                listView1.Items.Add(i);
            }
        }
    }
}
