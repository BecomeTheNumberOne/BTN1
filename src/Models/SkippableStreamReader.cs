
using System.IO;

class SkippableStreamReader : StreamReader
{
    public SkippableStreamReader(string path) : base(path) { }

    public void SkipLines(int linecount)
    {
        for (int i = 189025; i < i+linecount; i++)
        {
            this.ReadLine();
        }
    }
}