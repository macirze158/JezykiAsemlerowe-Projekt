using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Diagnostics;
using System.Threading;


namespace JaProjekt
{
    public partial class Form1 : Form
    {
        [DllImport(@"C:\Users\Maciek\source\repos\JaProjekt\x64\Debug\JaAsm.dll")]

        public static extern void MyEchoProc(int numSamples, IntPtr output, IntPtr waveData);
        public Form1()
        {
            InitializeComponent();
        }

        string inputFileName = "";
        string outputFileName = "";
        Stopwatch stopwatch = new Stopwatch();

        private void runC_Click(object sender, EventArgs e)
        {
            
            if (File.Exists(inputFileName))
            {
                // Read the WAVE file into a byte array
                byte[] waveData = File.ReadAllBytes(inputFileName);

                // Get the number of samples in the WAVE file
                int numSamples = waveData.Length / 2;

                // Create a new byte array for the output WAVE file
                byte[] output = new byte[waveData.Length];

                stopwatch.Start();
                // Loop over each sample in the WAVE file
                for (int i = 0; i < numSamples; i++)
                {
                    // Read the current sample
                    short sample = BitConverter.ToInt16(waveData, i * 2);

                    // Apply the echo effect
                    short echoesample;
                    if (i - (int)(0.5 * 44100) >= 0)
                    {

                        echoesample = (short)(sample +
                            0.5 * BitConverter.ToInt16(waveData, (i - (int)(0.1 * 44100)) * 2) +
                            0.1 * BitConverter.ToInt16(waveData, (i - (int)(0.3 * 44100)) * 2) +
                            0.05 * BitConverter.ToInt16(waveData, (i - (int)(0.5 * 44100)) * 2));

                    }
                    else
                    {
                        echoesample = sample;
                    }

                    // Store the modified sample in the output array
                    byte[] sampleBytes = BitConverter.GetBytes(echoesample);
                    output[i * 2] = sampleBytes[0];
                    output[i * 2 + 1] = sampleBytes[1];
                }
                stopwatch.Stop();
                // Write the output WAVE file
                File.WriteAllBytes(outputFileName, output);
                timerDisplay.Text = "Elapsed Time is " + stopwatch.ElapsedMilliseconds + " ms";
                stopwatch.Reset();
            }
            else
            {
                timerDisplay.Text = "Wrong input file name";
            }
            
        }

        private void timerDisplay_TextChanged(object sender, EventArgs e)
        {

        }

        private void fileName_TextChanged(object sender, EventArgs e)
        {
            inputFileName = fileName.Text;
        }

        private void outputName_TextChanged(object sender, EventArgs e)
        {
            outputFileName = outputName.Text;
        }

        private void runAsm_Click(object sender, EventArgs e)
        {
            if (File.Exists(inputFileName))
            {
                // Read the WAVE file into a byte array
                byte[] waveData = File.ReadAllBytes(inputFileName);

                // Get the number of samples in the WAVE file
                int numSamples = waveData.Length / 2;

                // Create a new byte array for the output WAVE file
                byte[] output = new byte[waveData.Length];

                // Loop over each sample in the WAVE file
                IntPtr waveDataPtr = Marshal.AllocHGlobal(waveData.Length);
                Marshal.Copy(waveData, 0, waveDataPtr, waveData.Length);

                IntPtr outputPtr = Marshal.AllocHGlobal(output.Length);

                stopwatch.Start();
                // Call the MyEchoProc function
                MyEchoProc(numSamples, outputPtr, waveDataPtr);
                stopwatch.Stop();

                // Copy the output data back into the output array
                Marshal.Copy(outputPtr, output, 0, output.Length);

                // Write the output WAVE file
                File.WriteAllBytes(outputFileName, output);
                timerDisplay.Text = "Elapsed Time is " + stopwatch.ElapsedMilliseconds + " ms";
                //zmienic na ticki
                stopwatch.Reset();
            }
            else
            {
                timerDisplay.Text = "Wrong input file name";
            }
        }
    }
}
