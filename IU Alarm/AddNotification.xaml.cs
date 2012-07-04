using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

using Microsoft.Phone.Scheduler;
//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Audio;

namespace IU_Alarm
{
    public partial class AddNotification : PhoneApplicationPage
    {
        public AddNotification()
        {
            InitializeComponent();
        }
        private void ApplicationBarSaveButton_Click(object sender, EventArgs e)
        {
            // The code in the following steps goes here.
            // Generate a unique name for the new notification. You can choose a
            // name that is meaningful for your app, or just use a GUID.
            String name = System.Guid.NewGuid().ToString();
            // Get the begin time for the notification by combining the DatePicker
            // value and the TimePicker value.
            DateTime time = (DateTime)beginTimePicker.Value;
            DateTime beginTime = time;
            if (beginTime < DateTime.Now)
            {
                beginTime=beginTime.AddDays(1.0);
            }

            RecurrenceInterval recurrence = RecurrenceInterval.None;
            recurrence = RecurrenceInterval.Daily;
            
            
            // Create a URI for the page that will be launched if the user
            // taps on the reminder. Use query string parameters to pass 
            // content to the page that is launched.
            
            
            
            
            Uri navigationUri = new Uri("/ShowParams.xaml", UriKind.Relative);
            
                Alarm alarm = new Alarm(name);
                alarm.Content = "";
           if (oneRadioButton.IsChecked == true)
                alarm.Sound = new Uri("/01.mp3", UriKind.Relative);
            if (twoRadioButton.IsChecked == true)
                alarm.Sound = new Uri("/02.mp3", UriKind.Relative);
            if (threeRadioButton.IsChecked==true)
                alarm.Sound = new Uri("/03.mp3", UriKind.Relative);


                alarm.BeginTime = beginTime;
                alarm.ExpirationTime = beginTime;
                alarm.RecurrenceType = recurrence;

            ScheduledActionService.Add(alarm);
            
            // Navigate back to the main reminder list page.
            NavigationService.GoBack();
        }
/*
        private void button1_Click(object sender, RoutedEventArgs e)
        {
           // Stream stream = TitleContainer.OpenStream("/01.mp3");
           // SoundEffect effect = SoundEffect.FromStream(stream);
           // FrameworkDispatcher.Update();
           // effect.Play();
//            sound2.Stop();
  //          sound3.Stop();
            sound1.Play();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
    //        sound1.Stop();
      //      sound3.Stop();
            sound2.Play();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
        //    sound1.Stop();
          //  sound2.Stop();
            sound3.Play();
        }*/
    }
}