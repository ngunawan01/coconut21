using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ad_sem2_week8_tha_movieInterface.Properties;

namespace ad_sem2_week8_tha_movieInterface
{
    public partial class Form1 : Form
    {
        //Bitmap bmp = new Bitmap(ad_sem2_week8_tha_movieInterface.Properties.Resources.movie_air);
        List<string> listMovie = new List<string>() { "AIR", "Dungeons & Dragon", "John Wick: 4", "Pelet Tali Pocong", "Ride On", "Super Mario Bros", "The Pops Exorcist", "Tulah 613"};
        List<string> listJamTayang = new List<string>() { "12.00", "16.00", "20.00" , "12.00", "16.00", "20.00",  "12.00", "16.00", "20.00", "12.00", "16.00", "20.00", "12.00", "16.00", "20.00", "12.00", "16.00", "20.00", "12.00", "16.00", "20.00", "12.00", "16.00", "20.00" };
        List<DataTable> listDataTableKursiAvailable = new List<DataTable>();
        List<string> listGreenOrRed = new List<string>() {"G", "R"};
        List<string> listChosenSeats = new List<string>();
        //DataTable[] arrayKursiAvailable = new DataTable[18];
        Label labelReservedSeat = new Label();
        private SoundPlayer sound;
        //List<string> list = new List<>string();
        public Form1()
        {
            InitializeComponent();
            sound = new SoundPlayer();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            labelReservedSeat.Text = "";
            labelReservedSeat.Size = new Size(170, 20);
            labelReservedSeat.Location = new Point(125, 445);
            this.Controls.Add(labelReservedSeat);

            Random rnd = new Random();
            for (int i = 0; i < listJamTayang.Count; i++)
            {
                listDataTableKursiAvailable.Add(new DataTable());
                listDataTableKursiAvailable[i].Columns.Add("Color");
                bool isValid = false;
                while (isValid == false)
                {
                    isValid = true;
                    int redCounter = 0;
                    for (int j = 0; j < 100; j++)
                    {
                        int randIndex = rnd.Next(listGreenOrRed.Count);
                        string greenOrRed = listGreenOrRed[randIndex];
                        listDataTableKursiAvailable[i].Rows.Add(greenOrRed);
                        if (greenOrRed == "R")
                        {
                            redCounter++;
                        }
                        if (redCounter >= 70)
                        {
                            isValid = false;
                            listDataTableKursiAvailable[i].Rows.Clear();
                            break;
                        }
                    }
                }
            }

            panel1.Controls.Clear();
            for (int i = 0; i < 8; i++)
            {
                if (i < 4)
                {
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Image = imageListMovies.Images[i];
                    pictureBox.Tag = i;
                    pictureBox.Location = new Point(i * 130 + 50, 50);
                    pictureBox.Size = new Size(100, 110);
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    panel1.Controls.Add(pictureBox);

                    Button button = new Button();
                    button.Text = listMovie[i];
                    button.Tag = i;
                    button.Size = new Size(100, 20);
                    button.Location = new Point(i * 130 + 50, 161);
                    button.Click += Button_Movie_Click;
                    panel1.Controls.Add(button);
                }
                else
                {
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Image = imageListMovies.Images[i];
                    pictureBox.Tag = i;
                    pictureBox.Location = new Point((i-4) * 130 + 50, 220);
                    pictureBox.Size = new Size(100, 110);
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    panel1.Controls.Add(pictureBox);

                    Button button = new Button();
                    button.Text = listMovie[i];
                    button.Tag = i;
                    button.Size = new Size(100, 20);
                    button.Location = new Point((i-4) * 130 + 50, 331);
                    button.Click += Button_Movie_Click;
                    panel1.Controls.Add(button);
                }
            }
        }

        private void Button_Movie_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();

            Button buttonBack = new Button();
            buttonBack.Text = "Back To Main Menu";
            buttonBack.Location = new Point(480, 50);
            buttonBack.Size = new Size(100, 40);
            buttonBack.Click += ButtonBack_Click;
            panel1.Controls.Add(buttonBack);

            Button buttonSender = sender as Button;
            //MessageBox.Show(buttonSender.Tag.ToString());
            PictureBox pictureBox = new PictureBox();
            pictureBox.Image = imageListMovies.Images[Convert.ToInt32(buttonSender.Tag)];
            pictureBox.Size = new Size(120, 150);
            pictureBox.Location = new Point(50,50);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            panel1.Controls.Add(pictureBox);

            Font font = new Font("Microsoft Sans Serif", 30);
            Font font2 = new Font("Microsoft Sans Serif", 20);

            Label label2 = new Label();
            label2.Text = "COCONUT MALL SURABAYA";
            label2.Size = new Size(300, 80);
            label2.Location = new Point(200, 130);
            label2.Font = font2;
            panel1.Controls.Add(label2);

            Label label = new Label();
            label.Text = listMovie[Convert.ToInt32(buttonSender.Tag)];
            label.Size = new Size(300, 80);
            label.Location = new Point(200, 80);
            label.Font = font;
            panel1.Controls.Add(label);

            Label label3 = new Label();
            label3.Text = "Jadwal Tayang";
            label3.Size = new Size(300, 50);
            label3.Location = new Point(50, 225);
            label3.Font = font2;
            panel1.Controls.Add(label3);

            double x = 1;
            for (int i = Convert.ToInt32(buttonSender.Tag) * 3; i < (Convert.ToInt32(buttonSender.Tag) * 3) + 3; i++)
            {
                Button button = new Button();
                button.Text = listJamTayang[i];
                button.Tag = i + "," + buttonSender.Tag.ToString();
                button.Click += Button_Click_JamTayang;
                button.Size = new Size(150, 80);
                button.Location = new Point(Convert.ToInt32(50 * x), 290);
                x += 3.5;
                panel1.Controls.Add(button);
            }

            
        }

        private void Button_Click_JamTayang(object sender, EventArgs e)
        {
            labelReservedSeat.Text = "";
            listChosenSeats.Clear();
            panel1.SendToBack();
            panel1.Controls.Clear();

            Button buttonBack = new Button();
            buttonBack.Text = "Back To Main Menu";
            buttonBack.Location = new Point(295, 340);
            buttonBack.Size = new Size(80, 40);
            buttonBack.Click += ButtonBack_Click;
            panel1.Controls.Add(buttonBack);

            Button buttonSender = sender as Button;
            
            Font font = new Font("Microsoft Sans Serif", 15);

            Label label = new Label();
            label.Text = "COCONUT MALL SURABAYA  -  " + buttonSender.Text;
            label.Location = new Point(120, 25);
            label.Size = new Size(400, 40);
            label.Font = font;
            panel1.Controls.Add(label);

            Label label2 = new Label();
            label2.Text = "Chosen Seats: ";
            label2.Location = new Point(50, 370);
            label2.Size = new Size(80, 20);
            panel1.Controls.Add(label2);


            TextBox textbox = new TextBox();
            textbox.Text = " L A Y A R  B I O S K O P  D I  S I N I ";
            textbox.Location = new Point(50, 390);
            textbox.Size = new Size(500, 20);
            textbox.TextAlign = HorizontalAlignment.Center;
            textbox.Enabled = false;
            panel1.Controls.Add(textbox);
            
            int counterForLoop = 0;
            int x = 50;
            int y = 65;
            int spaceTengahCounter = 5;

            string stringButtonSenderTag = buttonSender.Tag.ToString();
            string[] arrayButtonSenderTag = stringButtonSenderTag.Split(',');
            //foreach(string a in arrayButtonSenderTag)
            //{
            //    MessageBox.Show(a);
            //}

            // stringButtonSenderTag[0].ToString()); adalah index jam tayang atau index data table
            // stringButtonSenderTag[1].ToString()); adalah index film ke berapa

            foreach (DataRow dtrow in listDataTableKursiAvailable[Convert.ToInt32(arrayButtonSenderTag[0])].Rows)
            {
                if (counterForLoop > 0 && counterForLoop % 10 == 0)
                {
                    y += 22;
                    x = 50;
                }
                if (spaceTengahCounter == counterForLoop)
                {
                    x += 45;
                    spaceTengahCounter += 10;
                }

                Button buttonKursi = new Button();
                buttonKursi.Text = counterForLoop.ToString();
                buttonKursi.Tag = stringButtonSenderTag + "," + counterForLoop;
                buttonKursi.Size = new Size(40, 20);
                buttonKursi.Location = new Point(x, y);
                buttonKursi.Click += ButtonKursi_GreenOrRed_Click;

                if (dtrow["Color"].ToString() == "G")
                {
                    buttonKursi.BackColor = Color.Green;
                }
                else
                {
                    buttonKursi.Enabled = false;
                    buttonKursi.BackColor = Color.Red;
                }

                counterForLoop++;
                x += 45;
                panel1.Controls.Add(buttonKursi);
            }

            Button buttonReserve = new Button();
            buttonReserve.Text = "Reserve";
            buttonReserve.Location = new Point(465, 340);
            buttonReserve.Size = new Size(80, 40);
            buttonReserve.Click += Button_Reserve_Click;
            buttonReserve.Tag = stringButtonSenderTag + "," + counterForLoop;
            panel1.Controls.Add(buttonReserve);

            Button buttonReset = new Button();
            buttonReset.Text = "Reset";
            buttonReset.Location = new Point(380, 340);
            buttonReset.Size = new Size(80, 40);
            buttonReset.Click += ButtonReset_Click;
            buttonReset.Tag = stringButtonSenderTag + "," + counterForLoop;
            panel1.Controls.Add(buttonReset);

            
        }

        private void ButtonBack_Click(object sender, EventArgs e)
        {
            labelReservedSeat.Text = "";
            listChosenSeats.Clear();
            panel1.BringToFront();
            panel1.Controls.Clear();


            for (int i = 0; i < 8; i++)
            {
                if (i < 4)
                {
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Image = imageListMovies.Images[i];
                    pictureBox.Tag = i;
                    pictureBox.Location = new Point(i * 130 + 50, 50);
                    pictureBox.Size = new Size(100, 110);
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    panel1.Controls.Add(pictureBox);

                    Button button = new Button();
                    button.Text = listMovie[i];
                    button.Tag = i;
                    button.Size = new Size(100, 20);
                    button.Location = new Point(i * 130 + 50, 161);
                    button.Click += Button_Movie_Click;
                    panel1.Controls.Add(button);
                }
                else
                {
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Image = imageListMovies.Images[i];
                    pictureBox.Tag = i;
                    pictureBox.Location = new Point((i - 4) * 130 + 50, 220);
                    pictureBox.Size = new Size(100, 110);
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    panel1.Controls.Add(pictureBox);

                    Button button = new Button();
                    button.Text = listMovie[i];
                    button.Tag = i;
                    button.Size = new Size(100, 20);
                    button.Location = new Point((i - 4) * 130 + 50, 331);
                    button.Click += Button_Movie_Click;
                    panel1.Controls.Add(button);
                }
            }
        }

        private void ButtonReset_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Button buttonSender = sender as Button;
            string stringButtonSenderTag = buttonSender.Tag.ToString();
            string[] arrayButtonSenderTag = stringButtonSenderTag.Split(',');

            int dtRowCounter = 0;
            foreach (DataRow dtrow in listDataTableKursiAvailable[Convert.ToInt32(arrayButtonSenderTag[0])].Rows)
            {   
                 dtrow["Color"] = "G";                
            }

            MessageBox.Show("Succesfully Reseted All The Seats! Please press OK to go back to the Main Menu");
            labelReservedSeat.Text = "";
            listChosenSeats.Clear();
            panel1.BringToFront();
            panel1.Controls.Clear();


            for (int i = 0; i < 8; i++)
            {
                if (i < 4)
                {
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Image = imageListMovies.Images[i];
                    pictureBox.Tag = i;
                    pictureBox.Location = new Point(i * 130 + 50, 50);
                    pictureBox.Size = new Size(100, 110);
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    panel1.Controls.Add(pictureBox);

                    Button button = new Button();
                    button.Text = listMovie[i];
                    button.Tag = i;
                    button.Size = new Size(100, 20);
                    button.Location = new Point(i * 130 + 50, 161);
                    button.Click += Button_Movie_Click;
                    panel1.Controls.Add(button);
                }
                else
                {
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Image = imageListMovies.Images[i];
                    pictureBox.Tag = i;
                    pictureBox.Location = new Point((i - 4) * 130 + 50, 220);
                    pictureBox.Size = new Size(100, 110);
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    panel1.Controls.Add(pictureBox);

                    Button button = new Button();
                    button.Text = listMovie[i];
                    button.Tag = i;
                    button.Size = new Size(100, 20);
                    button.Location = new Point((i - 4) * 130 + 50, 331);
                    button.Click += Button_Movie_Click;
                    panel1.Controls.Add(button);
                }
            }

            ////Font font = new Font("Microsoft Sans Serif", 15);

            ////Label label = new Label();
            ////label.Text = "COCONUT MALL SURABAYA  -  " + buttonSender.Text;
            ////label.Location = new Point(120, 25);
            ////label.Size = new Size(400, 40);
            ////label.Font = font;
            ////panel1.Controls.Add(label);

            ////Label label2 = new Label();
            ////label2.Text = "Chosen Seats: ";
            ////label2.Location = new Point(50, 370);
            ////label2.Size = new Size(80, 20);
            ////panel1.Controls.Add(label2);


            ////TextBox textbox = new TextBox();
            ////textbox.Text = " L A Y A R  B I O S K O P  D I  S I N I ";
            ////textbox.Location = new Point(50, 390);
            ////textbox.Size = new Size(500, 20);
            ////textbox.TextAlign = HorizontalAlignment.Center;
            ////textbox.Enabled = false;
            ////panel1.Controls.Add(textbox);

            ////int counterForLoop = 0;
            ////int x = 50;
            ////int y = 65;
            ////int spaceTengahCounter = 5;


            ////foreach (DataRow dtrow in listDataTableKursiAvailable[Convert.ToInt32(arrayButtonSenderTag[0])].Rows)
            ////{
            ////    if (counterForLoop > 0 && counterForLoop % 10 == 0)
            ////    {
            ////        y += 22;
            ////        x = 50;
            ////    }
            ////    if (spaceTengahCounter == counterForLoop)
            ////    {
            ////        x += 45;
            ////        spaceTengahCounter += 10;
            ////    }

            ////    Button buttonKursi = new Button();
            ////    buttonKursi.Text = counterForLoop.ToString();
            ////    buttonKursi.Tag = stringButtonSenderTag + "," + counterForLoop;
            ////    buttonKursi.Size = new Size(40, 20);
            ////    buttonKursi.Location = new Point(x, y);
            ////    buttonKursi.Click += ButtonKursi_GreenOrRed_Click;

            ////    if (dtrow["Color"].ToString() == "G")
            ////    {
            ////        buttonKursi.BackColor = Color.Green;
            ////    }
            ////    else
            ////    {
            ////        buttonKursi.Enabled = false;
            ////        buttonKursi.BackColor = Color.Red;
            ////    }

            ////    counterForLoop++;
            ////    x += 45;
            ////    panel1.Controls.Add(buttonKursi);

            ////    //Button buttonReserve = new Button();
            ////    //buttonReserve.Text = "Reserve";
            ////    //buttonReserve.Location = new Point(465, 340);
            ////    //buttonReserve.Size = new Size(80, 40);
            ////    //buttonReserve.Click += Button_Reserve_Click;
            ////    //buttonReserve.Tag = stringButtonSenderTag + "," + counterForLoop;
            ////    //panel1.Controls.Add(buttonReserve);

            ////    //Button buttonReset = new Button();
            ////    //buttonReset.Text = "Reset";
            ////    //buttonReset.Location = new Point(380, 340);
            ////    //buttonReset.Size = new Size(80, 40);
            ////    //buttonReset.Click += ButtonReset_Click;
            ////    //buttonReset.Tag = stringButtonSenderTag + "," + counterForLoop;
            ////    //panel1.Controls.Add(buttonReset);
            //}


        }

        private void Button_Reserve_Click(object sender, EventArgs e)
        {
            Button buttonSender = sender as Button;
            string stringButtonSenderTag = buttonSender.Tag.ToString();
            string[] arrayButtonSenderTag = stringButtonSenderTag.Split(',');

            if (labelReservedSeat.Text != "")
            {
                MessageBox.Show("Succesfully Reserved");
                int dtRowCounter = 0;
                foreach (DataRow dtrow in listDataTableKursiAvailable[Convert.ToInt32(arrayButtonSenderTag[0])].Rows)
                {
                    if (listChosenSeats.Contains(dtRowCounter.ToString()))
                    {
                        dtrow["Color"] = "R";
                    }
                    dtRowCounter++;
                }
                panel1.Controls.Clear();
                panel1.BringToFront();
                // otomatis balik ke main menu

                for (int i = 0; i < 8; i++)
                {
                    if (i < 4)
                    {
                        PictureBox pictureBox = new PictureBox();
                        pictureBox.Image = imageListMovies.Images[i];
                        pictureBox.Tag = i;
                        pictureBox.Location = new Point(i * 130 + 50, 50);
                        pictureBox.Size = new Size(100, 110);
                        pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                        panel1.Controls.Add(pictureBox);

                        Button button = new Button();
                        button.Text = listMovie[i];
                        button.Tag = i;
                        button.Size = new Size(100, 20);
                        button.Location = new Point(i * 130 + 50, 161);
                        button.Click += Button_Movie_Click;
                        panel1.Controls.Add(button);
                    }
                    else
                    {
                        PictureBox pictureBox = new PictureBox();
                        pictureBox.Image = imageListMovies.Images[i];
                        pictureBox.Tag = i;
                        pictureBox.Location = new Point((i - 4) * 130 + 50, 220);
                        pictureBox.Size = new Size(100, 110);
                        pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                        panel1.Controls.Add(pictureBox);

                        Button button = new Button();
                        button.Text = listMovie[i];
                        button.Tag = i;
                        button.Size = new Size(100, 20);
                        button.Location = new Point((i - 4) * 130 + 50, 331);
                        button.Click += Button_Movie_Click;
                        panel1.Controls.Add(button);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please Select the sits you would like to reserve");
            }
        }

        private void ButtonKursi_GreenOrRed_Click(object sender, EventArgs e)
        {
            Button buttonSender = sender as Button;
            string stringButtonSenderTag = buttonSender.Tag.ToString();
            string[] arrayButtonSenderTag = stringButtonSenderTag.Split(',');
            //foreach (string a in arrayButtonSenderTag)
            //{
            //    MessageBox.Show(a);
            //}
            if (buttonSender.BackColor == Color.Green)
            {
                buttonSender.BackColor = Color.Yellow;
                listChosenSeats.Add(arrayButtonSenderTag[2]);
            }
            else if (buttonSender.BackColor == Color.Yellow)
            {
                buttonSender.BackColor = Color.Green;
                listChosenSeats.Remove(arrayButtonSenderTag[2]);
            }
            labelReservedSeat.Text = "";
            foreach (string a in listChosenSeats)
            {
                //MessageBox.Show("aa");
                labelReservedSeat.Text += a + ",";
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
