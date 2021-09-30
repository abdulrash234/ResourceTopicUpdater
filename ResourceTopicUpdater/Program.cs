using System;
using System.Collections.Generic;
using System.IO;

namespace ResourceTopicUpdater
{
    class Program
    {
        static void Main(string[] args)
        {
            MakeListOfResources();
        }

        public static List<Resource> MakeListOfResources()
        {
          var reader = new StreamReader(File.OpenRead(@"C:\equipment-numbers.csv"));
          var listOfResources = new List<Resource>();
          reader.ReadLine();
          while (!reader.EndOfStream)
          {
              
              var line = reader.ReadLine();
                if (!String.IsNullOrWhiteSpace(line))
                {
                    var values = line.Split(';');
                    var resource = new Resource() {DeviceUrn = values[0], ResourceUrn = values[1]};
                        listOfResources.Add(resource);
                    
                }
          }
          return listOfResources;
        }
    }
    public class Resource
    {
        public string DeviceUrn { get; set; }

        public string ResourceUrn { get; set; }
    }
}
