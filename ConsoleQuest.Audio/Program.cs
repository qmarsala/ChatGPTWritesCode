using ConsoleQuest.Audio;
using NAudio.Wave;
using System.Text;

//sampleRate* durationMs / 1000

NoteData[] tune = new NoteData[]
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

NoteData[] otherNoteData = new NoteData[]
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
    Console.WriteLine("Select a sample:");
    Console.WriteLine("1) 'fur elise'");
    Console.WriteLine("2) 'fur elise' lower");
    Console.WriteLine("3) 'original'");
    Console.WriteLine("q) quit");
    input = Console.ReadKey(true).Key;
    var noteDatas = input switch
    {
        ConsoleKey.D1 => tune,
        ConsoleKey.D2 => otherNoteData,
        ConsoleKey.D3 => originalTune,
        _ => null
    };
    if (noteDatas is null) { continue; }

    var song = noteDatas
        .SelectMany(x => GenerateNote(x.Frequency, x.NumSamples, x.SampleRate, x.Amplitude))
        .ToArray();
    byte[] wavStream = AddWavHeaders(song, 44100, 2, 16);

    using MemoryStream ms = new(wavStream);
    using WaveStream waveStream = new WaveFileReader(ms);
    using WaveOutEvent waveOut = new();
    waveOut.Init(waveStream);
    waveOut.Play();

    while (waveOut.PlaybackState == PlaybackState.Playing)
    {
        Thread.Sleep(100);
    }
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


static byte[] GenerateNote(double frequency, int numSamples, int sampleRate, double amplitude)
{
    double[] sampleData = new double[numSamples];

    double amplitudeScale = 32767 * amplitude;
    double increment = 2 * Math.PI * frequency / sampleRate;
    double currentAngle = 0;

    for (int i = 0; i < numSamples; i++)
    {
        sampleData[i] = Math.Sin(currentAngle) * amplitudeScale;
        currentAngle += increment;
    }

    byte[] byteData = new byte[numSamples * 2];
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
