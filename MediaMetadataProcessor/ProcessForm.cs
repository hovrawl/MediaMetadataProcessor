using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using TagLib;
using TagLib.Image;

namespace MediaMetadataProcessor
{
    public enum FileTypes {
        Unknown = 0,
        Music = 1,
        Image = 2,
        Video = 3
    }

    public partial class ProcessForm : Form
    {
        private readonly List<TagLib.File> _selectedFiles;

        public bool _processed = false;

        public ProcessForm(List<TagLib.File> files)
        {
            InitializeComponent();

            _selectedFiles = files;

            Initialize();
        }

        private void Initialize()
        {
            var tags = new List<TagLib.Tag>();
            var fileTypes = FileTypes.Unknown;

            // Interrogate selected files to figure out which metadata columns to process
            foreach (var file in _selectedFiles)
            {
                if (file.Tag is CombinedTag || file.Tag is TagLib.NonContainer.Tag)
                {
                    fileTypes = FileTypes.Music;
                }
                if (file.Tag is CombinedImageTag)
                {
                    fileTypes = FileTypes.Image;
                }

                //if (file.Tag is )
                //{
                //    fileTypes = FileTypes.Video;
                //}
            }

            var metadataStrings = new List<string>();
            var destStrings = new List<string>();
            switch (fileTypes)
            {
                
                case FileTypes.Music:
                {
                    metadataStrings.Add("Track Number");
                    metadataStrings.Add("Title");
                    metadataStrings.Add("Album");
                    metadataStrings.Add("Artist");
                    metadataStrings.Add("Album Artist");

                    break;
                }
                case FileTypes.Image:
                {
                    metadataStrings.Add("Title");
                    break;
                }
                case FileTypes.Video:
                {
                    metadataStrings.Add("Title");
                    break;
                }

                case FileTypes.Unknown:
                default:
                {
                    // Unsupported type
                    break;
                }
                //throw new ArgumentOutOfRangeException();
            }

            listBoxMetadata.DataSource = metadataStrings;

            destStrings.AddRange(metadataStrings);
            listBoxDest.DataSource = destStrings;
            listBoxDest.Enabled = true;
        }


        private void ProcessMetadata()
        {
            var selectedMetadata = listBoxMetadata.SelectedItem as string;
            var selectedDestinationMetadata = listBoxDest.SelectedItem as string;
            var newValue = txtBoxNew.Text;

            var doCopy = radioBtnCopy.Checked;
            var doMove = radioBtnMove.Checked;
            var doDelete = radioBtnDelete.Checked;
            var doNew = radioBtnNew.Checked;

            if (string.IsNullOrEmpty(selectedMetadata) || string.IsNullOrEmpty(selectedDestinationMetadata))
            {
                return;
            }

            if (!doCopy && !doMove && !doDelete && !doNew)
            {
                return;
            }

            foreach (var file in _selectedFiles)
            {
                if (doCopy)
                {
                    CopyMetadata(file, selectedMetadata, selectedDestinationMetadata);
                }
                if (doMove)
                {
                    MoveMetadata(file, selectedMetadata, selectedDestinationMetadata);
                }
                if (doDelete)
                {
                    DeleteMetadata(file, selectedMetadata);
                }
                if (doNew)
                {
                    NewMetadata(file, selectedMetadata, newValue);
                }
            }

            _processed = true;
            this.Close();
        }

        private void CopyMetadata(TagLib.File file, string sourceMeta, string destMeta)
        {
            if (string.IsNullOrEmpty(destMeta))
            {
                return;
            }

            if (!file.Writeable)
            {
                return;
            }

            dynamic sourceValue = "";
            switch (sourceMeta.ToLower())
            {
                case "title":
                {
                    sourceValue = file.Tag.Title;
                    break;
                }
                case "album":
                {
                    sourceValue = file.Tag.Album;
                    break;
                }
                case "artist":
                {
                    sourceValue = file.Tag.Performers;
                    break;
                }
                case "album artist":
                {
                    sourceValue = file.Tag.AlbumArtists;
                    break;
                }
                case "track number":
                {
                    sourceValue = file.Tag.Track;
                    break;
                }
            }

            switch (destMeta.ToLower())
            {
                case "title":
                {
                    file.Tag.Title = sourceValue;
                    break;
                }
                case "album":
                {
                    file.Tag.Album = sourceValue;
                    break;
                }
                case "artist":
                {
                    if (sourceValue is string[] artists)
                    {
                        file.Tag.Performers = artists;

                    }
                    else if (sourceValue is string artist)
                    {
                        file.Tag.Performers = new string[] { artist };
                    }
                    break;
                }
                case "album artist":
                {
                    if (sourceValue is string[] albumArtists)
                    {
                        file.Tag.AlbumArtists = albumArtists;

                    }
                    else if (sourceValue is string albumArtist)
                    {
                        file.Tag.AlbumArtists = new string[]{ albumArtist };
                    }
                    break;
                }
                case "track number":
                {
                    if (sourceValue is uint sourceUInt)
                    {
                        file.Tag.Track = sourceUInt;
                    }
                    break;
                }
            }

            // Save file
            file.Save();
        }

        private void MoveMetadata(TagLib.File file, string sourceMeta, string destMeta)
        {
            if (!file.Writeable)
            {
                return;
            }

            dynamic sourceValue = "";
            switch (sourceMeta.ToLower())
            {
                case "title":
                    {
                        sourceValue = file.Tag.Title;
                        file.Tag.Title = null;
                        break;
                    }
                case "album":
                    {
                        sourceValue = file.Tag.Album;
                        file.Tag.Album = null;
                        break;
                    }
                case "artist":
                    {
                        sourceValue = file.Tag.Performers;
                        file.Tag.Performers = null;
                        break;
                    }
                case "album artist":
                    {
                        sourceValue = file.Tag.AlbumArtists;
                        file.Tag.AlbumArtists = null;
                        break;
                    }
                case "track number":
                    {
                        sourceValue = file.Tag.Track;
                        file.Tag.Track = 0;
                        break;
                    }
            }

            switch (destMeta.ToLower())
            {
                case "title":
                    {
                        file.Tag.Title = sourceValue;
                        break;
                    }
                case "album":
                    {
                        file.Tag.Album = sourceValue;
                        break;
                    }
                case "artist":
                    {
                        if (sourceValue is string[] artists)
                        {
                            file.Tag.Performers = artists;

                        }
                        else if (sourceValue is string artist)
                        {
                            file.Tag.Performers = new string[] { artist };
                        }
                        break;
                    }
                case "album artist":
                    {
                        if (sourceValue is string[] albumArtists)
                        {
                            file.Tag.AlbumArtists = albumArtists;

                        }
                        else if (sourceValue is string albumArtist)
                        {
                            file.Tag.AlbumArtists = new string[] { albumArtist };
                        }
                        break;
                    }
                case "track number":
                    {
                        if (sourceValue is uint sourceUInt)
                        {
                            file.Tag.Track = sourceUInt;
                        }
                        break;
                    }
            }

            // Save file
            file.Save();
        }

        private void DeleteMetadata(TagLib.File file, string sourceMeta)
        {
            if (!file.Writeable)
            {
                return;
            }

            switch (sourceMeta.ToLower())
            {
                case "title":
                    {
                        file.Tag.Title = null;
                        break;
                    }
                case "album":
                    {
                        file.Tag.Album = null;
                        break;
                    }
                case "artist":
                    {
                        file.Tag.Performers = null;
                        break;
                    }
                case "album artist":
                    {
                        file.Tag.AlbumArtists = null;
                        break;
                    }
                case "track number":
                    {
                        file.Tag.Track = 0;
                        break;
                    }
            }

            // Save file
            file.Save();
        }

        private void NewMetadata(TagLib.File file, string destMeta, dynamic newValue)
        {
            if (!file.Writeable)
            {
                return;
            }

            if (string.IsNullOrEmpty(destMeta))
            {
                return;
            }

            switch (destMeta.ToLower())
            {
                case "title":
                    {
                        file.Tag.Title = newValue;
                        break;
                    }
                case "album":
                    {
                        file.Tag.Album = newValue;
                        break;
                    }
                case "artist":
                    {
                        if (newValue is string[] artists)
                        {
                            file.Tag.Performers = artists;

                        }
                        else if (newValue is string artist)
                        {
                            file.Tag.Performers = new string[] { artist };
                        }
                        break;
                    }
                case "album artist":
                    {
                        if (newValue is string[] albumArtists)
                        {
                            file.Tag.AlbumArtists = albumArtists;

                        }
                        else if (newValue is string albumArtist)
                        {
                            file.Tag.AlbumArtists = new string[] { albumArtist };
                        }
                        break;
                    }
                case "track number":
                    {
                        if (newValue is uint sourceUInt)
                        {
                            file.Tag.Track = sourceUInt;
                        }
                        break;
                    }
            }

            // Save file
            file.Save();
        }


        private void btnProcess_Click(object sender, EventArgs e)
        {
            ProcessMetadata();
        }
    }
}
