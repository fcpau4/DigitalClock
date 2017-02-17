


using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.Windows.Controls;

namespace DigitalClock
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<TimeDifference> listCountry = new List<TimeDifference>();

        private Alarm alarm;
        private String timeAlarm;
        private bool active;

        private DateTime dateTime;
        private DateTime secondaryClock;

        private TimeDifference timeDiffCurrentCountry;

        const string FileName = @"SavedAlarm.bin";
        const string Countries = @"SavedCountries.bin";
        private string currentTime;

        public MainWindow()
        {
            InitializeComponent();
            startClock();
        }




        private void startClock()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += tickevent;
            timer.Start();

        }




        private void tickevent(object sender, EventArgs e)
        {
            dateTime = DateTime.Now;
            datLbl.Text = dateTime.ToString(@"hh\:mm");

            if (timeDiffCurrentCountry != null)
            {
                secondaryClock = dateTime.AddHours(timeDiffCurrentCountry.timeDifference);
                countryClock.Text = secondaryClock.ToString(@"hh\:mm");
            }

            currentTime = datLbl.Text;

            if (activeRB.IsChecked.Value)
            {
                ring();
            }

        }


        private void ring()
        {
            if (currentTime.Equals(hoursTb.Text))
            {

                MediaPlayer mediaPlayer = new MediaPlayer();
                mediaPlayer.Open(new Uri("C:\\Users\\47276138y\\Desktop\\mood.mp3", UriKind.Absolute));
                mediaPlayer.Play();

                MessageBox.Show("És l'hora!", "Alarm");

            }
        }



        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

           MenuItem item =  ((MenuItem)sender);

            if (item.Header.Equals("Add"))
            {
                Dialog dialog = new Dialog("Canada", "-6");
                
                if (dialog.ShowDialog() == true)
                { 
                 listCountry.Add(new TimeDifference(dialog.countryAnswer, int.Parse(dialog.timeDiffAnswer)));
                 comboxCountry.Items.Add(dialog.countryAnswer);
                }
            }

            else if (item.Name.Equals("About")){
                String mssgBody = "Clock@ is a registered digital watch programme part of Interface Development Course at Institute of Polytechnical Studies.";
                String header = "About Clock";
                MessageBox.Show(mssgBody, header);
            }

            else if (item.Name.Equals("Exit"))
            {
                this.Close();
            }

        }





        private void form_closing(object sender, CancelEventArgs e)
        {
            timeAlarm = hoursTb.Text;
            active = activeRB.IsChecked.Value;

            alarm = new Alarm(timeAlarm, active);
            Stream TestFileStream = File.Create(FileName);
            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(TestFileStream, alarm);
            TestFileStream.Close();
        }




        private void Window_Initialized(object sender, EventArgs e)
        {
            if (File.Exists(FileName))
            {
                Stream TestFileStream = File.OpenRead(FileName);
                BinaryFormatter deserializer = new BinaryFormatter();
                alarm = (Alarm) deserializer.Deserialize(TestFileStream);
                TestFileStream.Close();

                hoursTb.Text = alarm.currentTime.ToString();

                if (alarm.activate)
                {
                    //Implementar un mètode que permeti prémer el butó "Activar Alarma" sense necessitat de clicar-hi.
                }
                
            }

        }

        private void comboxCountry_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            ComboBox combobox = (ComboBox)sender;
            
            foreach(TimeDifference obj in listCountry)
            {
                if (obj.countryName.Equals(combobox.SelectedItem.ToString()))
                {
                    timeDiffCurrentCountry = obj;
                    break;
                }
                

            }
        }
    }
}

