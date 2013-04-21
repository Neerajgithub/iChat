using System;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
public class Helper
{
	public Helper()
	{
		
	}

    public static string GetUniqueName(string file,string directory)
    {
        try
        {
            string ext = Path.GetExtension(file);
            if(string.IsNullOrEmpty(ext))
            {
                ext = ".jpg";
            }
            Random randObj = new Random();
            string randomNum = randObj.Next(1000).ToString() + randObj.Next(5000).ToString();
            string fileName = "Chatroom" + randomNum + ext;
            string pathToCheck = Path.Combine(directory + fileName);
            if (System.IO.File.Exists(pathToCheck))
            {
                while (System.IO.File.Exists(pathToCheck))
                {
                    randomNum = randObj.Next(1000).ToString() + randObj.Next(5000).ToString();
                    fileName = "Chatroom" + randomNum + ext;
                    pathToCheck = Path.Combine(directory + fileName);
                }
            }
            return pathToCheck;
        }
        catch
        {
            return null;
        }
    }

    public static string GetUniqueNameUser(string file, string directory)
    {
        try
        {
            string ext = Path.GetExtension(file);
            if (string.IsNullOrEmpty(ext))
            {
                ext = ".jpg";
            }
            Random randObj = new Random();
            string randomNum = randObj.Next(1000).ToString() + randObj.Next(5000).ToString();
            string fileName = "User" + randomNum + ext;
            string pathToCheck = Path.Combine(directory + fileName);
            if (System.IO.File.Exists(pathToCheck))
            {
                while (System.IO.File.Exists(pathToCheck))
                {
                    randomNum = randObj.Next(1000).ToString() + randObj.Next(5000).ToString();
                    fileName = "User" + randomNum + ext;
                    pathToCheck = Path.Combine(directory + fileName);
                }
            }
            return pathToCheck;
        }
        catch
        {
            return null;
        }
    }

    public static void ResizeImageFile(string imageFile, int targetSize, string newImagePath)
    {
        using (System.Drawing.Image oldImage = System.Drawing.Image.FromFile(imageFile))
        {
            Size newSize = CalculateDimensions(oldImage.Size, targetSize);
            using (Bitmap newImage = new Bitmap(newSize.Width, newSize.Height, PixelFormat.Alpha))
            {
                using (Graphics canvas = Graphics.FromImage(newImage))
                {
                    canvas.SmoothingMode = SmoothingMode.AntiAlias;
                    canvas.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    canvas.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    canvas.DrawImage(oldImage, new Rectangle(new Point(0, 0), newSize));
                    switch (Path.GetExtension(newImagePath))
                    {
                        case ".jpg":
                        case ".JPG":
                        case ".jpeg":
                        case ".JPEG":
                            newImage.Save(newImagePath, ImageFormat.Jpeg);
                            break;
                        case ".png":
                            newImage.Save(newImagePath, ImageFormat.Png);
                            break;
                        case ".gif":
                            newImage.Save(newImagePath, ImageFormat.Gif);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }

    private static Size CalculateDimensions(Size oldSize, int targetSize)
    {
        Size newSize = new Size();
        if (oldSize.Height > oldSize.Width)
        {
            newSize.Width = (int)(oldSize.Width * ((float)targetSize / (float)oldSize.Height));
            newSize.Height = targetSize;
        }
        else
        {
            newSize.Width = targetSize;
            newSize.Height = (int)(oldSize.Height * ((float)targetSize / (float)oldSize.Width));
        }
        return newSize;
    }
}