using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using TwoTrails.Utilities;

namespace TwoTrails.BusinessObjects
{
    public enum PictureType
    {
        Normal,
        Spherical,
        Panorama,
        NoPicture
    }

    public enum PicFileType
    {
        Jpg,
        Bmp,
        Png,
        Gif,
        Tiff,
        Nef,
        Cr2,
        NoFile
    }

    public class TtPicture : IDisposable
    {
        public string CN;

        public Bitmap _Picture = null;
        public Bitmap Picture
        {
            get { return _Picture; }
            set
            {
                _Picture = value;
                _PictureData = GetPictureBytes();
            }
        }

        public byte[] _PictureData = null;
        public byte[] PictureData
        {
            get { return _PictureData; }
            set
            {
                _PictureData = value;

                if (FileType != PicFileType.Cr2 && FileType != PicFileType.Nef && FileType != PicFileType.NoFile)
                {
                    _Picture = new Bitmap(new System.IO.MemoryStream(_PictureData));
                }
                else
                {
                    _Picture = null;
                }
            }
        }

        public bool HasData { get { return Picture != null ||
            PictureData != null && PictureData.Length > 0; } }

        public bool IsValid { get { return HasData && !FileName.IsEmpty(); } }


        public string FileName;

        public DateTime Time;

        public PicFileType FileType;
        public PictureType Type;

        public double UtmX = 0, UtmY = 0, Elevation = 0;

        public string Comment;

        public double? Azimuth = null, Accuracy = null;


        public TtPicture()
        {
            FileType = PicFileType.NoFile;
            Type = PictureType.NoPicture;
        }

        public TtPicture(string filename)
        {
            try
            {
                string ext = Path.GetExtension(filename).Substring(1);
                FileType = (PicFileType)Enum.Parse(typeof(PicFileType), ext, true);

                if (FileType == PicFileType.Cr2 || FileType == PicFileType.Nef)
                    PictureData = File.ReadAllBytes(filename);
                else
                    Picture = new Bitmap(Bitmap.FromFile(filename));
            }
            catch
            {
                throw new Exception("Bad File Path or File Type");
            }
        }


        public byte[] GetPictureBytes()
        {
            if (PictureData != null)
                return PictureData;

            byte[] byteArray = new byte[0];
            using (MemoryStream stream = new MemoryStream())
            {
                Picture.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
                stream.Close();

                byteArray = stream.ToArray();
            }

            return byteArray;
        }

        public void LoadPictureFromData(byte[] data, PicFileType type)
        {
            if (type == PicFileType.Cr2 || type == PicFileType.Nef || type == PicFileType.NoFile)
                PictureData = data;
            else
                Picture = new Bitmap(new MemoryStream(data));

            FileType = type;
        }

        public void Dispose()
        {
            if (Picture != null)
                Picture.Dispose();
            PictureData = null;
        }


        public void SaveTo(string path)
        {
            if (Picture != null)
            {
                Picture.Save(Path.Combine(path, FileName), FileTypeToImageFormat(FileType));
            }
            else if (PictureData != null && PictureData.Length > 0)
            {
                using (FileStream fs = new FileStream(Path.Combine(path, FileName), FileMode.Create))
                {
                    fs.Write(PictureData, 0, PictureData.Length);
                }
            }
        }

        private ImageFormat FileTypeToImageFormat(PicFileType ft)
        {
            switch (ft)
            {
                case PicFileType.Bmp:
                    return ImageFormat.Bmp;
                case PicFileType.Gif:
                    return ImageFormat.Gif;
                case PicFileType.Png:
                    return ImageFormat.Png;
                case PicFileType.Tiff:
                    return ImageFormat.Tiff;
                case PicFileType.Jpg:
                default:
                    return ImageFormat.Jpeg;
            }
        }
    }
}
