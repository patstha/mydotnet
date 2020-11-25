using System;
using System.Drawing;
using System.Drawing.Imaging;
using hellolib;

class Solution
{
    public static void Main(string[] args)
    {
        if (args.Length > 1)
        {
            Person person = PersonFactory.Create(args[0], args[1]);
            Console.WriteLine($"{person.CreatedBy} created Person with name {person.Name} at {person.CreatedDate}");
        }

        MyCommonImagesLib.MyRenderer myRenderer = new MyCommonImagesLib.MyRenderer();
        Bitmap myBitmap = myRenderer.CreateBitmap();
        var myImageCodecInfo = GetEncoderInfo("image/png");
        var myEncoderParameters = new EncoderParameters(1);
        var myEncoder = Encoder.Quality;
        var myEncoderParameter = new EncoderParameter(myEncoder, 100L);
        myEncoderParameters.Param[0] = myEncoderParameter;
        myBitmap.Save($"slick-{DateTime.Now.Subtract(DateTime.MinValue.AddYears(1969)).TotalMilliseconds}.png", myImageCodecInfo, myEncoderParameters);

    }

    private static ImageCodecInfo GetEncoderInfo(String mimeType)
    {
        int j;
        ImageCodecInfo[] encoders;
        encoders = ImageCodecInfo.GetImageEncoders();
        for (j = 0; j < encoders.Length; ++j)
        {
            if (encoders[j].MimeType == mimeType)
                return encoders[j];
        }
        return null;
    }
}
