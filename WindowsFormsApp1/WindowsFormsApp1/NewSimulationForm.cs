using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class NewSimulationForm : Form
    {
        ViewReportForm repForm;
        List<Stock> stockList = new List<Stock>();
        private double[] shortTerm;
        private double[] longTerm;

        

        private StreamReader fileReader;
        string filename;

        public NewSimulationForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //create dialog bo enabling user to oepn file
                DialogResult result;

                using (OpenFileDialog fileChooser = new OpenFileDialog())
                {
                    result = fileChooser.ShowDialog();
                    filename = fileChooser.FileName;
                }

                //exit event handler if user clicked OK
                if (result == DialogResult.OK)
                {
                    //show error if user specified invalid file
                    if (string.IsNullOrEmpty(filename))
                    {
                        MessageBox.Show("Invalid File name");
                    }
                    else
                    {
                        //create FileStream to obtain read access 
                        FileStream input = new FileStream(filename, FileMode.Open, FileAccess.Read);
                        //set file from where data is read
                        fileReader = new StreamReader(input);

                        //place the file pointer to the beginning of the file
                        input.Seek(0, SeekOrigin.Begin);
                        textBox1.AppendText(filename);

                        button2.Enabled = true;
                        fileReader.Close();
                    }
                }
               
            }
            catch (IOException)
            {
                MessageBox.Show("Cannot open file");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.AppendText("Date\t\tOpen\t\tHigh\t\tLow\t\tClose\t\tAdjusted\t\tVolume\n");

            if (File.Exists(filename))
            {
                //open file
                StreamReader inputFile = new StreamReader(filename);

                if (inputFile != null)
                {
                    inputFile.ReadLine();
                    String line;
                    //read file into stockList
                    while ((line = inputFile.ReadLine()) != null)
                    {

                        string[] values = line.Split(',');

                        Date dtObject = new Date(values[0]);
                        double open = Double.Parse(values[1]);
                        double high = Double.Parse(values[2]);
                        double low = Double.Parse(values[3]);
                        double close = Double.Parse(values[4]);
                        double adjClose = Double.Parse(values[5]);
                        double volume = Double.Parse(values[6]);

                        Stock stock = new Stock();
                        stock.Date = dtObject;
                        stock.Open = open;
                        stock.High = high;
                        stock.Low = low;
                        stock.Close = close;
                        stock.AdjClose = adjClose;
                        stock.Volume = volume;

                        stockList.Add(stock);


                    }
                    //for loop to print stock data
                    for (int i = 0; i < stockList.Count; i++)
                    {
                        textBox2.AppendText(stockList[i].Date.getDate() + "\t" + stockList[i].Open.ToString("0.00") + "\t\t" + stockList[i].High.ToString("0.00") + "\t\t" + stockList[i].Low.ToString("0.00")
                           + "\t\t" + stockList[i].Close.ToString("0.00") + "\t\t" + stockList[i].AdjClose.ToString("0.00") + "\t\t" + stockList[i].Volume.ToString() + "\n");
                    }

                    button3.Enabled = true;
                    inputFile.Close();
                }
            }
            else
            {
                MessageBox.Show("File does not exist");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            shortTerm = new Double[stockList.Count];
            longTerm = new Double[stockList.Count];

            for(int i = 0; i < stockList.Count - 20; i++)
            {
                shortTerm[i+20] = MovingAvg(i, 20, stockList);
               
            }
            for (int i = 0; i < stockList.Count - 50; i++)
            {
                longTerm[i + 50] = MovingAvg(i, 50, stockList);

            }

            
            button4.Enabled = true;
            
        }

        private double MovingAvg(int index, int term, List<Stock> list)
        {
            double sum = 0;
            double avg = 0;
            
            if(index < list.Count - term)
            {
                for (int i = index; i < index + term; i++)
                {
                    sum += list[i].AdjClose;
                }
            }
            

            avg = sum / term;
            return avg;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            repForm = new ViewReportForm(shortTerm, longTerm, stockList);
            repForm.MdiParent = this.MdiParent;
            repForm.Show();
        }
    }
}
