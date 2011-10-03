using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;

namespace SharpShuffle
{
    class XML
    {
        /// <summary>
        /// Get meta and file pathes from iTunes (and Winamp-Export) XML files and store that data as songs and audiofiles in the database.
        /// </summary>
        /// <param name="path">Path to your XML file.</param>
        public static void ReadITunesXML(string path)
        {
            XmlReaderSettings xrs = new XmlReaderSettings();
            xrs.DtdProcessing = DtdProcessing.Parse;
            List<Song> songs = new List<Song>();
            List<string> audiofiles = new List<string>();
            using (XmlReader xr = XmlReader.Create(path, xrs))
            {
                bool inmeta = false;
                ushort level = 0; // for skipping all the shit at the beginning
                Song tempsong = new Song();


                while (xr.Read())
                {
                    if (xr.NodeType == XmlNodeType.Element)
                    {
                        switch (xr.Name)
                        {
                            case "key":
                                if (inmeta)
                                {
                                    // This is actually a line we can use. Format is <key>keyname</key><[datatype]>data</[datatype]>. Yes it's crap.
                                    string keyname = xr.ReadString();
                                    xr.Read(); // throw away the </key>
                                    try { xr.Read(); }
                                    catch (XmlException E) { } // throw away the datatype element
                                    string value = xr.ReadString();
                                    xr.Read(); // throw away the datatype endelement
                                    // Process the read stuff.
                                    switch (keyname)
                                    {
                                        case "Name":
                                            tempsong.Title = value;
                                            break;
                                        case "Artist":
                                            tempsong.Artists = value;
                                            break;
                                        case "Album Artist":
                                            if (tempsong.Album == null) tempsong.Album = new CAlbum();
                                            tempsong.Album.AlbumArtists = value;
                                            break;
                                        case "Album":
                                            if (tempsong.Album == null) tempsong.Album = new CAlbum();
                                            tempsong.Album.Name = value;
                                            break;
                                        case "BPM":
                                            tempsong.BPM = ushort.Parse(value);
                                            break;
                                        case "Genre":
                                            tempsong.Genres = value;
                                            break;
                                        case "Comments":
                                            tempsong.Comment = value;
                                            break;
                                        case "Composer":
                                            tempsong.Composers = value;
                                            break;
                                        case "Total Time":
                                            tempsong.Length = uint.Parse(value);
                                            break;
                                        case "Track Number":
                                            tempsong.TrackNr = ushort.Parse(value);
                                            break;
                                        case "Track Count":
                                            if (tempsong.Album == null) tempsong.Album = new CAlbum();
                                            tempsong.Album.TrackCount = uint.Parse(value);
                                            break;
                                        case "Year":
                                            if (tempsong.Album == null) tempsong.Album = new CAlbum();
                                            tempsong.Album.Year = uint.Parse(value);
                                            break;
                                        case "Location":
                                            //TODO: Import locations for audiofiles or discard them? If using them, how to link to meta?
                                            break;
                                        case "Rating":
                                            tempsong.Rating = (short)((short.Parse(value)) / (short)20);
                                            break;
                                        case "Play Count":
                                            tempsong.PlayCount = uint.Parse(value);
                                            break;
                                        case "Track ID":
                                        case "Disc Number":
                                        case "Disc Count":
                                        case "Kind":
                                        case "Size":
                                        case "Date Modified":
                                        case "Date Added":
                                        case "Bitrate":
                                        case "File Folder Count":
                                        case "Library Folder Count":
                                        case "Publisher":
                                        case "Play Date UTC":
                                        case "Has Video":
                                        case "Video Width":
                                        case "Video Height":
                                            break;
                                        default:
                                            throw new KeyNotFoundException(keyname);
                                    }
                                }
                                break;
                            case "dict":
                                if (level < 2)
                                    level++;
                                else
                                {
                                    inmeta = true;
                                    tempsong = new Song();
                                }
                                break;
                            case "plist":
                                break;
                            default:
                                // This is data.
                                break;
                        }
                    }
                    else if (xr.NodeType == XmlNodeType.EndElement && xr.Name == "dict")
                    {
                        inmeta = false;
                        songs.Add(tempsong);
                    }
                }
            }
            Startup.ActiveDB.InsertSongs(songs);
            string importpool = "iTunes Import " + DateTime.Now.ToString();
            Startup.ActiveDB.CreateSongpool(importpool);
            Startup.ActiveDB.PutSongsInPool(songs, importpool);
        }
    }
}
