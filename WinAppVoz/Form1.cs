using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;

namespace WinAppVoz
{
    public partial class Form1 : Form
    {
        SpeechRecognitionEngine objVoz = new SpeechRecognitionEngine();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonIniciar_Click(object sender, EventArgs e)
        {
            objVoz.SetInputToDefaultAudioDevice();
            objVoz.LoadGrammar(new DictationGrammar());
            objVoz.SpeechRecognized += enlazar;
            objVoz.RecognizeAsync(RecognizeMode.Multiple);
        }

        void enlazar(object sender, SpeechRecognizedEventArgs e) {
            textBoxVoz.Text = e.Result.Text;
        }

        private void buttonPausar_Click(object sender, EventArgs e)
        {
            objVoz.RecognizeAsyncStop();
        }
    }
}
