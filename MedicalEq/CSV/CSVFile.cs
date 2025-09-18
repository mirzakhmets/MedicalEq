
using CSVdb;
using CSVdb.CSV;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace CSVdb.CSV
{
  public class CSVFile
  {
    public string name = (string) null;
    public ArrayList names = new ArrayList();
    public Dictionary<string, int> namesIndex = new Dictionary<string, int>();
    public ArrayList lines = new ArrayList();

    public CSVFile() {
    	
    }
    
    public CSVFile(ParsingStream stream, string name)
    {
      this.name = name;
      CSVLine csvLine1 = new CSVLine(stream);
      int num = 0;
      foreach (string key in csvLine1.values)
      {
        this.names.Add((object) key);
        this.namesIndex.Add(key, checked (num++));
      }
      while (!stream.atEnd())
      {
        CSVLine csvLine2 = new CSVLine(stream);
        if (csvLine2.values.Count > 0)
          this.lines.Add((object) csvLine2);
      }
    }
    
    void WriteToStream(Stream stream, string data) {
    	byte[] bytes = System.Text.Encoding.Default.GetBytes(data);
    	
    	stream.Write(bytes, 0, bytes.Length);
    }
    
    public void Save(string filename) {
    	bool f = false;
    	
    	FileStream fs = new FileStream(filename, FileMode.CreateNew);
    	
    	foreach (object _name in names) {
    		if (f) {
    			WriteToStream(fs, ",");
    		}
    		
    		f = true;
    		
    		WriteToStream(fs, (string) _name);
    	}
    	
    	foreach (object _line in lines) {
    		CSVLine csvLine = (CSVLine) _line;
    		
    		WriteToStream(fs, "\r\n");
    		
    		bool ff = false;
    		
    		foreach (object _value in csvLine.values) {
    			if (ff) {
    				WriteToStream(fs, ",");
    			}
    			
    			ff = true;
    			
    			WriteToStream(fs, "\"" + _value.ToString() + "\"");
    		}
    	}

    	WriteToStream(fs, "\r\n");
    	
    	fs.Close();
    }
  }
}
