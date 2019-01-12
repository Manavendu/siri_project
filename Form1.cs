using System;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Speech.Recognition;

namespace WindowsFormsApp2
{
    public partial class txtContents : Form
    {
        SpeechSynthesizer ss = new SpeechSynthesizer();
        SpeechRecognitionEngine sre = new SpeechRecognitionEngine();
        public txtContents()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Start (button_click)
            try
            {
                //neerajsimha95@gmail.com
                button1.Enabled = false;
                Choices clist = new Choices();

                clist.Add(new string[] { "hello", "how are you", "What is current time", "thank you", "close" });
                Grammar gr = new Grammar(new GrammarBuilder(clist));
                sre.RequestRecognizerUpdate();
                sre.LoadGrammar(gr);
                sre.SpeechRecognized += sre_SpeechRecognized;
                sre.SetInputToDefaultAudioDevice();
                sre.RecognizeAsync(RecognizeMode.Multiple);    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            

        }

        private void txtContents_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            sre.RecognizeAsyncStop();
            button1.Enabled = true;
            button2.Enabled = false;


        }
        protected void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            switch (e.Result.Text.ToString())
            {
                case "hello":
                    ss.SpeakAsync("hello Manav");
                    siri.Text += "hello Manav";
                    break;
                case "thank you":
                    ss.SpeakAsync("Pleasure Mr Manav");
                    siri.Text += "Pleasure Mr Manav";
                    break;
                case "close":
                    Application.Exit();
                    break;

                default:
                    ss.SpeakAsync("Invalid");
                    siri.Text += "Invalid";
                    break;

            }
            //txtContents.Text += e.Results.Text.Tostring() + Environment.NewLine;
            textBox1.Text += e.Result.Text.ToString() + Environment.NewLine;
        }
    }

        
}
     