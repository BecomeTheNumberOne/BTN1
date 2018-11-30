using System;
using System.Linq;


public struct Data
{
    public Data(String _name, string _genre, string _URL )
    {
        Name = _name;
        genre = _genre;
        URL = _URL;
    }

    public String Name { get;  set; }
    public string genre { get;  set; }
    public string URL { get;  set; }
}