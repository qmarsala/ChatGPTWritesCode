using ConsoleQuest.Audio;
using NAudio.Wave;
using System.Text;

//sampleRate* durationMs / 1000

double A4 = 440; // frequency of A4
double semitoneRatio = Math.Pow(2, 1.0 / 12); // ratio of frequency between adjacent semitones
double frequency = A4; // start with frequency of A4
double duration = 0.5; // duration in seconds
double amplitude = 0.5; // amplitude between 0 and 1
int numSamples = 22050; // number of samples per second
int sampleRate = 44100; // sample rate in Hz

var octave = new NoteData[12];
for (int i = 0; i < 12; i++)
{
    octave[i] = new NoteData(frequency, (int)(numSamples * duration), sampleRate, amplitude);
    frequency *= semitoneRatio; // multiply by semitone ratio to get frequency of next semitone
}

NoteData[] furEliseMaybe = new NoteData[]
{
    new NoteData(659.25, 22050, 44100, 0.5), // E5
    new NoteData(659.25, 22050, 44100, 0.5), // E5
    new NoteData(0, 22050, 44100, 0), // Rest
    new NoteData(659.25, 22050, 44100, 0.5), // E5
    new NoteData(0, 22050, 44100, 0), // Rest
    new NoteData(587.33, 22050, 44100, 0.5), // D5
    new NoteData(659.25, 22050, 44100, 0.5), // E5
    new NoteData(0, 22050, 44100, 0), // Rest
    new NoteData(587.33, 22050, 44100, 0.5), // D5
    new NoteData(0, 22050, 44100, 0), // Rest
    new NoteData(523.25, 22050, 44100, 0.5), // C5
    new NoteData(587.33, 22050, 44100, 0.5), // D5
    new NoteData(0, 22050, 44100, 0), // Rest
    new NoteData(523.25, 22050, 44100, 0.5), // C5
    new NoteData(0, 22050, 44100, 0), // Rest
    new NoteData(587.33, 22050, 44100, 0.5), // D5
    new NoteData(659.25, 22050, 44100, 0.5), // E5
    new NoteData(698.46, 22050, 44100, 0.5), // F5
    new NoteData(0, 22050, 44100, 0), // Rest
    new NoteData(698.46, 22050, 44100, 0.5), // F5
    new NoteData(0, 22050, 44100, 0), // Rest
    new NoteData(659.25, 22050, 44100, 0.5), // E5
    new NoteData(0, 22050, 44100, 0), // Rest
    new NoteData(587.33, 22050, 44100, 0.5), // D5
    new NoteData(0, 22050, 44100, 0), // Rest
    new NoteData(523.25, 22050, 44100, 0.5), // C5
    new NoteData(587.33, 22050, 44100, 0.5), // D5
    new NoteData(0, 22050, 44100, 0), // Rest
    new NoteData(523.25, 22050, 44100, 0.5)
};

NoteData[] furEliseMaybleButLower = new NoteData[]
{
    new NoteData(329.63, 22050, 44100, 0.5),
    new NoteData(329.63, 22050, 44100, 0.5),
    new NoteData(329.63, 22050, 44100, 0.5),
    new NoteData(261.63, 22050, 44100, 0.5),
    new NoteData(392, 22050, 44100, 0.5),
    new NoteData(329.63, 22050, 44100, 0.5),
    new NoteData(261.63, 22050, 44100, 0.5),
    new NoteData(392, 22050, 44100, 0.5),
    new NoteData(329.63, 22050, 44100, 0.5),
    new NoteData(261.63, 22050, 44100, 0.5),
    new NoteData(329.63, 22050, 44100, 0.5),
    new NoteData(440, 22050, 44100, 0.5),
    new NoteData(392, 22050, 44100, 0.5),
    new NoteData(329.63, 22050, 44100, 0.5),
    new NoteData(261.63, 22050, 44100, 0.5),
    new NoteData(329.63, 22050, 44100, 0.5)
};

var originalTune = new NoteData[]
{
    new NoteData(261.63, 22050, 44100, 0.5), // C4
    new NoteData(293.66, 22050, 44100, 0.5), // D4
    new NoteData(329.63, 22050, 44100, 0.5), // E4
    new NoteData(392.00, 22050, 44100, 0.5), // G4
    new NoteData(329.63, 22050, 44100, 0.5), // E4
    new NoteData(293.66, 22050, 44100, 0.5), // D4
    new NoteData(261.63, 22050, 44100, 0.5), // C4
    new NoteData(392.00, 22050, 44100, 0.5), // G4
    new NoteData(440.00, 22050, 44100, 0.5), // A4
    new NoteData(493.88, 22050, 44100, 0.5), // B4
    new NoteData(523.25, 22050, 44100, 0.5), // C5
    new NoteData(493.88, 22050, 44100, 0.5), // B4
    new NoteData(440.00, 22050, 44100, 0.5), // A4
    new NoteData(392.00, 22050, 44100, 0.5), // G4
    new NoteData(523.25, 22050, 44100, 0.5), // C5
    new NoteData(440.00, 22050, 44100, 0.5) // A4
};


var input = ConsoleKey.Spacebar;
while (input != ConsoleKey.Q)
{
    Console.Clear();
    Console.WriteLine("Select a sample:");
    Console.WriteLine("f) 'fur elise'");
    Console.WriteLine("l) 'fur elise' lower");
    Console.WriteLine("o) 'original'");
    Console.WriteLine("1) a");
    Console.WriteLine("2) b");
    Console.WriteLine("3) c");
    Console.WriteLine("4) d");
    Console.WriteLine("5) e");
    Console.WriteLine("6) f");
    Console.WriteLine("q) quit");
    input = Console.ReadKey(true).Key;
    var noteDatas = input switch
    {
        ConsoleKey.F => furEliseMaybe,
        ConsoleKey.L => furEliseMaybleButLower,
        ConsoleKey.O => originalTune,
        ConsoleKey.D1 => new NoteData[] { octave[0] },
        ConsoleKey.D2 => new NoteData[] { octave[1] },
        ConsoleKey.D3 => new NoteData[] { octave[2] },
        ConsoleKey.D4 => new NoteData[] { octave[3] },
        ConsoleKey.D5 => new NoteData[] { octave[4] },
        ConsoleKey.D6 => new NoteData[] { octave[5] },
        _ => null
    };
    if (noteDatas is null) { continue; }

    var song = noteDatas
        .SelectMany(x => GenerateNote(x))
        .ToArray();
    byte[] wavStream = AddWavHeaders(song, 44100, 2, 16);

    Task.Run(() =>
    {
        using MemoryStream ms = new(wavStream);
        using WaveStream waveStream = new WaveFileReader(ms);
        using WaveOutEvent waveOut = new();
        waveOut.Init(waveStream);
        waveOut.Play();

        while (waveOut.PlaybackState == PlaybackState.Playing)
        {
            Thread.Sleep(100);
        }
    });
}

static byte[] AddWavHeaders(byte[] audioData, int sampleRate, int numChannels, int bitsPerSample)
{
    int dataSize = audioData.Length;
    int headerSize = 44;

    byte[] header = new byte[headerSize];
    Array.Copy(Encoding.ASCII.GetBytes("RIFF"), header, 4);
    Array.Copy(BitConverter.GetBytes(dataSize + headerSize - 8), 0, header, 4, 4);
    Array.Copy(Encoding.ASCII.GetBytes("WAVE"), 0, header, 8, 4);
    Array.Copy(Encoding.ASCII.GetBytes("fmt "), 0, header, 12, 4);
    Array.Copy(BitConverter.GetBytes(16), 0, header, 16, 4);
    Array.Copy(BitConverter.GetBytes((short)1), 0, header, 20, 2);
    Array.Copy(BitConverter.GetBytes((short)numChannels), 0, header, 22, 2);
    Array.Copy(BitConverter.GetBytes(sampleRate), 0, header, 24, 4);
    Array.Copy(BitConverter.GetBytes(sampleRate * numChannels * bitsPerSample / 8), 0, header, 28, 4);
    Array.Copy(BitConverter.GetBytes((short)(numChannels * bitsPerSample / 8)), 0, header, 32, 2);
    Array.Copy(BitConverter.GetBytes((short)bitsPerSample), 0, header, 34, 2);
    Array.Copy(Encoding.ASCII.GetBytes("data"), 0, header, 36, 4);
    Array.Copy(BitConverter.GetBytes(dataSize), 0, header, 40, 4);

    byte[] result = new byte[audioData.Length + headerSize];
    Array.Copy(header, result, headerSize);
    Array.Copy(audioData, 0, result, headerSize, audioData.Length);

    return result;
}


static byte[] GenerateNote(NoteData noteData)
{
    double[] sampleData = new double[noteData.NumSamples];

    double amplitudeScale = 32767 * noteData.Amplitude;
    double increment = 2 * Math.PI * noteData.Frequency / noteData.SampleRate;
    double currentAngle = 0;

    for (int i = 0; i < noteData.NumSamples; i++)
    {
        sampleData[i] = Math.Sin(currentAngle) * amplitudeScale;
        currentAngle += increment;
    }

    byte[] byteData = new byte[noteData.NumSamples * 2];
    int index = 0;

    foreach (double sample in sampleData)
    {
        short convertedSample = (short)sample;
        byteData[index++] = (byte)(convertedSample & 0xff);
        byteData[index++] = (byte)((convertedSample >> 8) & 0xff);
    }

    return byteData;
}

namespace ConsoleQuest.Audio
{
    public record NoteData(double Frequency, int NumSamples, int SampleRate, double Amplitude);
}
