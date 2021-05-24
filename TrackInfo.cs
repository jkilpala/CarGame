using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarGame
{
    [Serializable]
    public class TrackInfo
    {
        public string TrackName = "muu";
        public int NumOfCheckpoints = 1;
        public List<String> slist = new List<string>();
        public TrackInfo()
        {
            slist.Add("Madasd");
            slist.Add("Madasd");
            slist.Add("Madasd");
            slist.Add("Madasd");
            slist.Add("Madasd");
        }


    }
}
