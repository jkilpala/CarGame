using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.IO;
using System.Xml;
using System.Xml.Serialization;


namespace CarGame
{
    class LoadSaveTrackInfo
    {
        public void Save(TrackInfo trackinfo)
        {
            if (Directory.Exists(@"trackdata") == false)
            {

                Directory.CreateDirectory(@"trackdata");

            }
            FileStream file = File.Open(@"trackdata/testi.xml", FileMode.OpenOrCreate);
            XmlSerializer serialize = new XmlSerializer(typeof(TrackInfo));
            serialize.Serialize(file, trackinfo);
            file.Close();
        }
        public Track Load()
        {
            Track track;

            FileStream file = new FileStream(@"trackdata/testi.xml", FileMode.Open);
            XmlSerializer serialize = new XmlSerializer(typeof(TrackInfo));
            track = (Track)serialize.Deserialize(file);
            file.Close();
            return track;
        }

    }
}
