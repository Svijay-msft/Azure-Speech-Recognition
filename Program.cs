using System;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.CognitiveServices.Speech;

namespace Speech.Recognition
{
    class Program
    {
        static async Task Main()
        {
            await RecognizeSpeechAsync();

        }

        static async Task RecognizeSpeechAsync()
        {
         

            var speechconfig = SpeechConfig.FromSubscription("<>",
                    "<>");
            speechconfig.EnableDictation();
            

            using var recognizer = new SpeechRecognizer(speechconfig);
            

          
            recognizer.Recognized += (s, e) =>
            {
                if (e.Result.Reason == ResultReason.RecognizedSpeech)
                {
                    // Do something with the recognized text
                    // e.Result.Text
                    Console.WriteLine(e.Result.Text);
                }
            };

            recognizer.SessionStarted += (s, e) =>
            {
                Console.WriteLine(e.ToString());
            };
            recognizer.SessionStopped += (s, e) =>
            {
                Console.WriteLine(e.ToString());
            };



            await recognizer.StartContinuousRecognitionAsync();
            Thread.Sleep(100000);
            
          }

        private static void Recognizer_SessionStarted(object sender, SessionEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
