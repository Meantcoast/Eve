using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis; //Built in Windows Voice 
using System.Speech.Recognition; //Built in Windows Speech Recognition
using System.Diagnostics;

namespace WindowsFormsApplication5
{
    public partial class Eve : Form
    {

        SpeechSynthesizer s = new SpeechSynthesizer();
        Boolean wake = true;

        Choices list = new Choices();
        public Eve()
        {

            SpeechRecognitionEngine rec = new SpeechRecognitionEngine();

            list.Add(new string[] { "hello", "how are you", "what is your purpose", "what is the date and time", "what is today", "what time is it", "open google", "wake", "sleep", "restart", "update", "open League"
                });

            Grammar gr = new Grammar(new GrammarBuilder(list));


            try
            {
                rec.RequestRecognizerUpdate();
                rec.LoadGrammar(gr);
                rec.SpeechRecognized += rec_SpeechRecognized;   // Recognizes Speech
                rec.SetInputToDefaultAudioDevice();     // Directs which Mic to use
                rec.RecognizeAsync(RecognizeMode.Multiple);     // Let's you say more than one thing.
            }
            catch (Exception)
            {

                
            }




            s.SelectVoiceByHints(VoiceGender.Female);

            s.Speak("My name is Eve. Nice to meet you");


            InitializeComponent();
        }


        public void say(String h)
        {
            s.Speak(h);
        }
        private void rec_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            String r = e.Result.Text;

            if(r == "wake") wake = true;
            if(r == "sleep") wake = false;


            if (wake == true)

            {


                if (r == "hello")
                {
                    say("hi");
                }

                if (r == "how are you")
                {
                    say("great, and you?");
                }

                if (r == "what is your purpose")
                {
                    say("i pass the butter");
                }

                if (r == "what is the date and time")
                {
                    say(DateTime.Now.ToString("M/d/yyyy h:mm tt"));
                }

                if (r == "what time is it")
                {
                    say(DateTime.Now.ToString("h:mm tt"));
                }

                if (r == "what is today")
                {
                    say("today is");
                    say(DateTime.Now.ToString("M/d/yyyy"));
                }

                if (r == "open google")
                {
                    Process.Start("http://google.com");
                }

            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
