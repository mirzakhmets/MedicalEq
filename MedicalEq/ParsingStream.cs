
using System.IO;

namespace CSVdb
{
  public class ParsingStream
  {
    public Stream stream;
    public int current = -1;

    public ParsingStream(Stream stream)
    {
      this.stream = stream;
      this.Read();
    }

    public void Read() {
    	/*
    	int b = this.stream.ReadByte();
    	
    	if (b == -1) {
    		this.current = -1;
    	} else {
    		this.current = (int) (System.Text.Encoding.GetEncoding(1251).GetBytes(new char[] {(char) b}))[0];
    	}*/
    	
    	this.current = this.stream.ReadByte();
    }

    public bool atEnd() {
    	return this.current == -1;
    }

    public void parseBlanks()
    {
      while (" \r\t\v".IndexOf(checked ((char) this.current)) >= 0)
        this.Read();
    }
    
    public static string ConvertTo1251 (string text) {
    	return new string(System.Text.Encoding.Default.GetChars(System.Text.Encoding.GetEncoding(1251).GetBytes(text)));
    }
    
    public static string ConvertToDefault (string text) {
    	return new string(System.Text.Encoding.GetEncoding(1251).GetChars(System.Text.Encoding.Default.GetBytes(text)));
    } 
  }
}
