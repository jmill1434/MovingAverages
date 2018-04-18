using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class ViewReportForm : Form
    {
        List<Record> arrayList = new List<Record>();
        List<Record> arrayList2 = new List<Record>();
        BinaryFormatter formatter = new BinaryFormatter();
        private StreamWriter fileWriter;
        private FileStream output;

        double[] array_;
        double[] array2_;
        public ViewReportForm()
        {
            InitializeComponent();
        }
        public ViewReportForm(double[] array, double[] array2, List<Stock> list)
        {
            InitializeComponent();
            array_ = array;
            array2_ = array2;

            textBox1.AppendText("Ticker\tDate\t\tShortterm\tLongterm\n");

            for(int i = 20; i < array.Length; i++)
            {
                textBox1.AppendText("FB" + "\t" + list[i-1].Date.getDate() + "\t" + array[i].ToString("0.00") + "\t" + array2[i].ToString("0.00") + "\n");
            }

        }

        private void button_s_Click(object sender, EventArgs e)
        {
            DialogResult result;
            string filename;
            SaveFileDialog filechooser = new SaveFileDialog();
            filechooser.CheckFileExists = false;
            result = filechooser.ShowDialog();
            filename = filechooser.FileName;

            if (result == DialogResult.OK)
            {
                MessageBox.Show("File is Created");
                if (string.IsNullOrEmpty(filename))
                {
                    MessageBox.Show("File is invalid.");
                }
                else
                {




                    try
                    {
                        //open file with wrtie access
                        output = new FileStream(filename,
                                                           FileMode.OpenOrCreate,
                                                           FileAccess.Write);

                        //sets file to where data is written
                        fileWriter = new StreamWriter(output);

                    }
                    catch (IOException)
                    {
                        MessageBox.Show("Error Opening File");
                    }
                    try
                    {
                        for (int i = 0; i < array_.Length; i++)
                        {
                            Record record = new Record(array_[i], array2_[i]);
                            arrayList.Add(record);
                        }

                        //write record to FileStream (serialize object)
                        formatter.Serialize(output, arrayList);
                    }
                    catch (SerializationException)
                    {
                        MessageBox.Show("Error in writing to File with serialization");
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Invalid Format");
                    }

                    output.Close();
                }
            }

        }

        private void button_d_Click(object sender, EventArgs e)
        {
            string filename = "";
            try
            {
                DialogResult result;
                using (OpenFileDialog filechooser = new OpenFileDialog())
                {
                    result = filechooser.ShowDialog();
                    filename = filechooser.FileName;
                }

                if (string.IsNullOrEmpty(filename))
                {
                    MessageBox.Show("Invalid file name");
                }
                else
                {
                    //create FileStream to obtain read access 
                    FileStream input = new FileStream("stockMovingAvg.ser", FileMode.Open, FileAccess.Read);
                    //read data from the file
                    while (input.Length != input.Position)
                    {
                        arrayList2 = (List<Record>)formatter.Deserialize(input);
                        for (int i = 20; i < arrayList2.Count; i++)
                        {
                            textBox1.AppendText(arrayList2[i].Shortterm.ToString() + "\t" + arrayList2[i].Longterm.ToString() + "\n");
                        }

                    }

                    input.Close();
                }
            }

            catch (IOException)
            {
                MessageBox.Show("Cannot open file");
            }
            catch (SerializationException em)
            {
                MessageBox.Show("No more records in file: " + em.ToString());
            }
        }
    }
}
