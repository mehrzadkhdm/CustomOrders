using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomOrderJson;
using Newtonsoft.Json;
using NanoXLSX;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using RestSharp;
using System.Net.Configuration;
using System.Runtime.CompilerServices;
using RestSharp.Serialization.Json;
using OrderDetail;
using System.Net;
using System.Diagnostics;

namespace CustomOrders
{
    public partial class CustomOrders : Form
    {
        public string iconName = "";
        public string fontFamily;
        public string text = "";
        public string searchFolder = "";
        public List<Config> Configs;
        //public List<OrderDetail> orders = new List<OrderDetail>();
        public string outputFolder = Application.StartupPath + "\\output";
        public IRestResponse responseResult;
        public RestRequest request;
        public RestClient client;
        public OrderDetail.OrderDetail orderDetail;

        public Dictionary<string, string> fontMap = new Dictionary<string, string>();


        public string AuthorizationString = string.Empty;
        public Uri ShipStationAPIAddress = new Uri(ConfigurationManager.AppSettings["ShipStationAPIAddress"]);
        public string ShipStationAPIKey = ConfigurationManager.AppSettings["ShipStationAPIKey"];
        public string ShipStationAPISecret = ConfigurationManager.AppSettings["ShipStationAPISecret"];


        public CustomOrders()
        {
            InitializeComponent();
        }

        private void openOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;
            CustomOrderJson.Main main = new Main();

            ImageCodecInfo myImageCodecInfo;
            myImageCodecInfo = GetEncoderInfo("image/png");
            EncoderParameter myEncoderParameter;
            EncoderParameters myEncoderParameters;
            myEncoderParameters = new EncoderParameters(1);
            myEncoderParameter = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100L);
            myEncoderParameters.Param[0] = myEncoderParameter;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Application.StartupPath;
                openFileDialog.Filter = "Json files (*.json)|*.json|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;


                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        var result = reader.ReadToEnd();
                        Config config = new Config();

                        Main o = JsonConvert.DeserializeObject<Main>(result);
                        string asin = o.Asin;
                        int index = Configs.FindIndex(x => x.SKU == asin);
                        if (index < 0)
                            return;
                        foreach (Area area in o.Version30.CustomizationInfo.Surfaces[0].Areas)
                        {
                            if (area.CustomizationType == "Options")
                            {
                                iconName = area.Label;
                            }
                            if (area.CustomizationType == "TextPrinting")
                            {
                                iconName = area.Label;
                                fontFamily = area.FontFamily.ToLower();
                                //area.FontFamily;
                                //area.Fill;
                                //area.Dimensions.Width;
                                //area.Dimensions.Height;
                                //area.Position.X;
                                //area.Position.Y;
                                text = area.Text;

                            }
                        }
                        config = Configs[index];

                        if (config.ImageType == "IMAGE-ONLY")
                        {

                        }
                        else
                        {

                        }


                        //fileContent = reader.ReadToEnd();

                    }
                }
            }
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

        private void configFileToolStripMenuItem_Click(object sender, EventArgs e)

        {

            string folder = Properties.Settings.Default.configFolder;
            if (folder == string.Empty)
            {
                folder = Application.StartupPath + @"\Config";
            }
            Form form = new folderSelector(this, folder);

            DialogResult result = form.ShowDialog(this);
            if (result == DialogResult.Cancel)
                return;

            string filePath = string.Empty;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {

                openFileDialog.InitialDirectory = searchFolder == "" ? Application.StartupPath : searchFolder;
                openFileDialog.Filter = "CSV files (*.csv)|*.json|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;


                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    int i = filePath.LastIndexOf('\\');
                    string configFolder = filePath.Substring(0, i);

                    Properties.Settings.Default.configFolder = configFolder;
                    Properties.Settings.Default.Save();


                    Configs = new List<Config>();


                    Workbook wb = null;
                    using (FileStream fs = new FileStream(filePath, FileMode.Open))
                    {
                        wb = Workbook.Load(fs);
                        Worksheet ws = wb.CurrentWorksheet;
                        int rows = ws.GetLastRowNumber();

                        for (int row = 1; row <= rows; row++)
                        {
                            Config config = new Config();
                            config.SKU = (string)ws.GetCell(0, row).Value;
                            config.FulfillmentSKU = (string)ws.GetCell(1, row).Value;
                            config.ImageType = (string)ws.GetCell(2, row).Value;
                            if (config.ImageType == "IMAGE-ONLY")
                                config.SourceImage = (string)ws.GetCell(3, row).Value;
                            else
                                config.SourceImage = "";

                            config.Width = int.Parse(ws.GetCell(4, row).Value.ToString());
                            config.Height = int.Parse(ws.GetCell(5, row).Value.ToString());

                            try { config.C1_StartX = int.Parse(ws.GetCell(6, row).Value.ToString()); }
                            catch { config.C1_StartX = null; }

                            try { config.C1_StartY = int.Parse(ws.GetCell(7, row).Value.ToString()); }
                            catch { config.C1_StartY = null; }

                            try { config.C1_Width = int.Parse(ws.GetCell(8, row).Value.ToString()); }
                            catch { config.C1_Width = null; }

                            try { config.C1_Height = int.Parse(ws.GetCell(9, row).Value.ToString()); }
                            catch { config.C1_Height = null; }

                            try { config.C2_StartX = int.Parse(ws.GetCell(10, row).Value.ToString()); }
                            catch { config.C2_StartX = null; }

                            try { config.C2_StartY = int.Parse(ws.GetCell(11, row).Value.ToString()); }
                            catch { config.C2_StartY = null; }

                            try { config.C2_Width = int.Parse(ws.GetCell(12, row).Value.ToString()); }
                            catch { config.C2_Width = null; }

                            try { config.C2_Height = int.Parse(ws.GetCell(13, row).Value.ToString()); }
                            catch { config.C2_Height = null; }

                            Configs.Add(config);
                        }
                    }

                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fontMap.Add("rochester", "Rochester-Regular.otf");
            fontMap.Add("staatliches", "Staatliches-Regular.ttf");
            fontMap.Add("sacramento", "Sacramento-Regular.ttf");
            fontMap.Add("cinzel", "Cinzel-Regular.ttf");
            fontMap.Add("greatVibes", "GreatVibes-Wmr4.ttf");
            fontMap.Add("homemadeapple", "HomemadeApple-Regular.ttf");


            Configs = new List<Config>();


            Workbook wb = null;
            using (FileStream fs = new FileStream(Application.StartupPath + @"\Config\config.xlsx", FileMode.Open))
            {
                wb = Workbook.Load(fs);
                Worksheet ws = wb.CurrentWorksheet;
                int rows = ws.GetLastRowNumber();

                for (int row = 1; row <= rows; row++)
                {
                    Config config = new Config();
                    config.SKU = (string)ws.GetCell(0, row).Value;
                    config.FulfillmentSKU = (string)ws.GetCell(1, row).Value;
                    config.ImageType = (string)ws.GetCell(2, row).Value;
                    if (config.ImageType == "IMAGE-ONLY")
                        config.SourceImage = (string)ws.GetCell(3, row).Value;
                    else
                        config.SourceImage = "";

                    config.Width = int.Parse(ws.GetCell(4, row).Value.ToString());
                    config.Height = int.Parse(ws.GetCell(5, row).Value.ToString());

                    try { config.C1_StartX = int.Parse(ws.GetCell(6, row).Value.ToString()); }
                    catch { config.C1_StartX = null; }

                    try { config.C1_StartY = int.Parse(ws.GetCell(7, row).Value.ToString()); }
                    catch { config.C1_StartY = null; }

                    try { config.C1_Width = int.Parse(ws.GetCell(8, row).Value.ToString()); }
                    catch { config.C1_Width = null; }

                    try { config.C1_Height = int.Parse(ws.GetCell(9, row).Value.ToString()); }
                    catch { config.C1_Height = null; }

                    try { config.C2_StartX = int.Parse(ws.GetCell(10, row).Value.ToString()); }
                    catch { config.C2_StartX = null; }

                    try { config.C2_StartY = int.Parse(ws.GetCell(11, row).Value.ToString()); }
                    catch { config.C2_StartY = null; }

                    try { config.C2_Width = int.Parse(ws.GetCell(12, row).Value.ToString()); }
                    catch { config.C2_Width = null; }

                    try { config.C2_Height = int.Parse(ws.GetCell(13, row).Value.ToString()); }
                    catch { config.C2_Height = null; }

                    Configs.Add(config);
                }
            }

        }
        private async Task processOrder(Order order, Item item)
        {
            char[] seperator = { ';' };
            Config config = new Config();
            int imWidth, imHeight, textWidth, testHeight;
            string text = "";
            PrivateFontCollection myFontCollection = new PrivateFontCollection();

            int index = Configs.FindIndex(x => x.SKU.Trim() == item.sku);
            if (index < 0)
                return;

            config = Configs[index];
            var destImage = new Bitmap(config.Width, config.Height);
            destImage.SetResolution(500.0F, 500.0F);
            if (config.ImageType == "IMAGE-ONLY")
            {
                string imageFile = config.SourceImage;
                Bitmap image = new Bitmap(Application.StartupPath + @"\SourceImages\" + imageFile + ".png");
                var destRect = new Rectangle(0, 0, config.Width, config.Height);

                using (var graphics = Graphics.FromImage(destImage))
                {
                    graphics.CompositingMode = CompositingMode.SourceCopy;
                    graphics.CompositingQuality = CompositingQuality.HighQuality;
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.SmoothingMode = SmoothingMode.HighQuality;
                    graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                    using (var wrapMode = new ImageAttributes())
                    {
                        wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                        graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                    }
                    destImage.Save(String.Format("{0}\\{1}_{2}_{3}.png", outputFolder, order.orderNumber, item.orderItemId, item.sku));

                    //destImage.Save(Application.StartupPath + @"\Output\" + order.OrderId + "-" + item.OrderItemId + ".png");
                }
                //MessageBox.Show("Done");


            }
            else
            {
                string[] jsonURLs = order.internalNotes.Split(seperator);

                foreach (string mixedUrl in jsonURLs)
                {
                    int i = mixedUrl.IndexOf("https");
                    string[] vs = mixedUrl.Split(':');
                    string orderItemId = vs[0];
                    string jsonFile = vs[0];
                    destImage = new Bitmap(config.Width, config.Height);
                    //string jsonFile = mixedUrl.Substring(0, i - 1);
                    //string url = mixedUrl.Substring(i, mixedUrl.Length - i);
                    string url = vs[1] + ":" + vs[2];
                    foreach (string file in Directory.GetFiles(Application.StartupPath + @"\tmp"))
                    {
                        File.Delete(file);
                    }
                    using (WebClient wc = new WebClient())
                    {

                        string tmpFilename = Path.GetTempFileName();
                        await wc.DownloadFileTaskAsync(url, tmpFilename);
                        ZipFile.ExtractToDirectory(tmpFilename, Application.StartupPath + @"\tmp");
                    }

                    using (StreamReader reader = new StreamReader(Application.StartupPath + @"\tmp\" + jsonFile + ".json"))
                    {
                        var result = reader.ReadToEnd();

                        Main o = JsonConvert.DeserializeObject<Main>(result);

                        foreach (Area area in o.Version30.CustomizationInfo.Surfaces[0].Areas)
                        {
                            if (area.CustomizationType == "Options")
                            {
                                iconName = area.OptionValue;
                                if (iconName == string.Empty)
                                {

                                }
                                else
                                {
                                    // 
                                }

                            }
                            if (area.CustomizationType == "TextPrinting")
                            {
                                //iconName = area.Label;
                                fontFamily = area.FontFamily.ToLower();
                                text = area.Text;
                                //area.FontFamily;
                                //area.Fill;
                                imWidth = area.Dimensions.Width;
                                imHeight = area.Dimensions.Height;

                                //area.Position.X;
                                //area.Position.Y;
                                text = area.Text;

                            }
                        }
                        Font myFont;

                        FontFamily myFontFamily = new FontFamily("Arial");
                        bool systemFont = true;
                        string localFont = Application.StartupPath + @"\Fonts\" + fontFamily + ".ttf";
                        if (File.Exists(localFont))
                        {
                            systemFont = false;
                            myFontCollection.AddFontFile(Application.StartupPath + @"\Fonts\" + fontFamily + ".ttf");
                            myFontFamily = myFontCollection.Families[0];
                        }
                        else
                        {
                            if (fontMap.Keys.Contains(fontFamily))
                            {
                                systemFont = false;
                                myFontCollection.AddFontFile(Application.StartupPath + @"\Fonts\" + fontMap[fontFamily]);
                                myFontFamily = myFontCollection.Families[0];

                            }
                        }
                        if (systemFont)
                            myFont = new Font(fontFamily, 72.0F);
                        else
                            myFont = new Font(myFontFamily, 72.0F);
                        SizeF layoutSize = new SizeF((float)config.C2_Width, (float)config.C2_Height);
                        SizeF stringSize = new SizeF();
                        var tempImage = new Bitmap(1, 1);
                        float scaleX, scaleY, scale;

                        using (var g = Graphics.FromImage(destImage))
                        {

                            stringSize = g.MeasureString(text, myFont);
                            scaleX = layoutSize.Width / stringSize.Width;
                            scaleY = layoutSize.Height / stringSize.Height;
                            scale = Math.Min(scaleX, scaleY);
                            float fontSize = 72.0F * scale;
                            if (systemFont)
                                myFont = new Font(fontFamily, fontSize, FontStyle.Regular, GraphicsUnit.Point);
                            else
                                myFont = new Font(myFontFamily, fontSize, FontStyle.Regular, GraphicsUnit.Point);
                            stringSize = g.MeasureString(text, myFont);

                        }
                        if (iconName == string.Empty || iconName == "None")
                            using (var graphics = Graphics.FromImage(destImage))
                            {
                                //graphics.CompositingMode = CompositingMode.SourceCopy;
                                graphics.CompositingQuality = CompositingQuality.HighQuality;
                                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                                graphics.SmoothingMode = SmoothingMode.HighQuality;
                                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                                graphics.FillRectangle(Brushes.White, 0.0F, 0.0F, destImage.Width, destImage.Height);
                                StringFormat stringFormat = new StringFormat();
                                stringFormat.Alignment = StringAlignment.Center;
                                stringFormat.LineAlignment = StringAlignment.Center;

                                graphics.DrawString(text, myFont, Brushes.Black,
                                    new Rectangle(0, 0, destImage.Width, destImage.Height), stringFormat);
                                destImage.Save(String.Format("{0}\\{1}_{2}_{3}.png", outputFolder, order.orderNumber, orderItemId, item.sku));
                                //destImage.Save(Application.StartupPath + @"\Output\" + order.OrderId+ "-" + item.OrderItemId + ".png");
                            }
                        else
                        {
                            string imageFile = config.SourceImage;
                            Bitmap icon = new Bitmap(Application.StartupPath + @"\SourceImages\Icons\" + iconName + ".png");
                            //Bitmap image = new Bitmap(Application.StartupPath + @"\SourceImages\" + imageFile + ".png");
                            float startX = ((float)destImage.Width - (float)config.C1_Width) / 2.0F;

                            var destRect = new Rectangle((int)startX, (int)config.C1_StartY,
                                (int)config.C1_Width, (int)((float)config.C1_Width / (float)icon.Width * (float)icon.Height));

                            using (var graphics = Graphics.FromImage(destImage))
                            {
                                //graphics.CompositingMode = CompositingMode.SourceCopy;
                                graphics.CompositingQuality = CompositingQuality.HighQuality;
                                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                                graphics.SmoothingMode = SmoothingMode.HighQuality;
                                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                                using (var wrapMode = new ImageAttributes())
                                {
                                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                                    graphics.DrawImage(icon, destRect, 0, 0, icon.Width, icon.Height, GraphicsUnit.Pixel, wrapMode);
                                }
                                StringFormat stringFormat = new StringFormat();
                                stringFormat.Alignment = StringAlignment.Center;
                                stringFormat.LineAlignment = StringAlignment.Near;
                                graphics.DrawString(text, myFont, Brushes.Black,
                                    new Rectangle(0, (int)config.C2_StartY, destImage.Width, destImage.Height), stringFormat);
                                destImage.Save(String.Format("{0}\\{1}_{2}_{3}.png", outputFolder, order.orderNumber, orderItemId, item.sku));

                                //destImage.Save(Application.StartupPath + @"\Output\" + order.OrderId + "-" + item.OrderItemId + ".png");
                            }

                        }





                        //fileContent = reader.ReadToEnd();

                    }

                    // get json from URL , local file for testing
                }
            }


        }

        private void processOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //char[] seperator = { ';' };
            //Config config = new Config();
            //int imWidth, imHeight, textWidth, testHeight;
            //string text = "";
            //PrivateFontCollection myFontCollection = new PrivateFontCollection();
            //foreach (OrderDetail order in orders)
            //{
            //    int index = Configs.FindIndex(x => x.SKU.Trim() == order.SKU.Trim());
            //    if (index < 0)
            //        continue;

            //    config = Configs[index];
            //    var destImage = new Bitmap(config.Width, config.Height);
            //    destImage.SetResolution(500.0F, 500.0F);
            //    if (config.ImageType == "IMAGE-ONLY")
            //    {
            //        string imageFile = config.SourceImage;
            //        Bitmap image = new Bitmap(Application.StartupPath + @"\SourceImages\" + imageFile + ".png");
            //        var destRect = new Rectangle(0, 0, config.Width, config.Height);

            //        using (var graphics = Graphics.FromImage(destImage))
            //        {
            //            graphics.CompositingMode = CompositingMode.SourceCopy;
            //            graphics.CompositingQuality = CompositingQuality.HighQuality;
            //            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            //            graphics.SmoothingMode = SmoothingMode.HighQuality;
            //            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

            //            using (var wrapMode = new ImageAttributes())
            //            {
            //                wrapMode.SetWrapMode(WrapMode.TileFlipXY);
            //                graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
            //            }
            //            destImage.Save(Application.StartupPath + @"\Output\" + order.orderId + "-" + order.orderItemID + ".png");
            //        }
            //        MessageBox.Show("Done");


            //    }
            //    else
            //    {
            //        string[] jsonURLs = order.internalNotes.Split(seperator);
            //        foreach (string url in jsonURLs)
            //        {
            //            using (StreamReader reader = new StreamReader(Application.StartupPath + @"\Config\" + url))
            //            {
            //                var result = reader.ReadToEnd();

            //                Main o = JsonConvert.DeserializeObject<Main>(result);

            //                foreach (Area area in o.Version30.CustomizationInfo.Surfaces[0].Areas)
            //                {
            //                    if (area.CustomizationType == "Options")
            //                    {
            //                        iconName = area.OptionValue;
            //                        if (iconName == string.Empty)
            //                        {

            //                        }
            //                        else
            //                        {
            //                            // 
            //                        }

            //                    }
            //                    if (area.CustomizationType == "TextPrinting")
            //                    {
            //                        //iconName = area.Label;
            //                        fontFamily = area.FontFamily;
            //                        text = area.Text;
            //                        //area.FontFamily;
            //                        //area.Fill;
            //                        imWidth = area.Dimensions.Width;
            //                        imHeight = area.Dimensions.Height;

            //                        //area.Position.X;
            //                        //area.Position.Y;
            //                        text = area.Text;

            //                    }
            //                }
            //                Font myFont;

            //                FontFamily myFontFamily = new FontFamily("Arial");
            //                bool systemFont = true;
            //                string localFont = Application.StartupPath + @"\Fonts\" + fontFamily + ".ttf";
            //                if (File.Exists(localFont))
            //                {
            //                    systemFont = false;
            //                    myFontCollection.AddFontFile(Application.StartupPath + @"\Fonts\" + fontFamily + ".ttf");
            //                    myFontFamily = myFontCollection.Families[0];
            //                }
            //                if (systemFont)
            //                    myFont = new Font(fontFamily, 72.0F);
            //                else
            //                    myFont = new Font(myFontFamily, 72.0F);
            //                SizeF layoutSize = new SizeF((float)config.C2_Width, (float)config.C2_Height);
            //                SizeF stringSize = new SizeF();
            //                var tempImage = new Bitmap(1, 1);
            //                float scaleX, scaleY, scale;
            //                using (var g = Graphics.FromImage(destImage))
            //                {

            //                    stringSize = g.MeasureString(text, myFont);
            //                    scaleX = layoutSize.Width / stringSize.Width;
            //                    scaleY = layoutSize.Height / stringSize.Height;
            //                    scale = Math.Min(scaleX, scaleY);
            //                    float fontSize = 72.0F * scale;
            //                    if (systemFont)
            //                        myFont = new Font(fontFamily, fontSize, FontStyle.Regular, GraphicsUnit.Point);
            //                    else
            //                        myFont = new Font(myFontFamily, fontSize, FontStyle.Regular, GraphicsUnit.Point);
            //                    stringSize = g.MeasureString(text, myFont);

            //                }
            //                if (iconName == string.Empty)
            //                    using (var graphics = Graphics.FromImage(destImage))
            //                    {
            //                        //graphics.CompositingMode = CompositingMode.SourceCopy;
            //                        graphics.CompositingQuality = CompositingQuality.HighQuality;
            //                        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            //                        graphics.SmoothingMode = SmoothingMode.HighQuality;
            //                        graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            //                        graphics.FillRectangle(Brushes.White, 0.0F, 0.0F, destImage.Width, destImage.Height);
            //                        StringFormat stringFormat = new StringFormat();
            //                        stringFormat.Alignment = StringAlignment.Center;
            //                        stringFormat.LineAlignment = StringAlignment.Center;

            //                        graphics.DrawString(text, myFont, Brushes.Black,
            //                            new Rectangle(0, 0, destImage.Width, destImage.Height), stringFormat);

            //                        destImage.Save(Application.StartupPath + @"\Output\" + order.orderId + "-" + order.orderItemID + ".png");
            //                    }
            //                else
            //                {
            //                    string imageFile = config.SourceImage;
            //                    Bitmap icon = new Bitmap(Application.StartupPath + @"\SourceImages\Icons\" + iconName + ".png");
            //                    //Bitmap image = new Bitmap(Application.StartupPath + @"\SourceImages\" + imageFile + ".png");
            //                    float startX = ((float)destImage.Width - (float)config.C1_Width) / 2.0F;

            //                    var destRect = new Rectangle((int)startX, (int)config.C1_StartY,
            //                        (int)config.C1_Width, (int)((float)config.C1_Width / (float)icon.Width * (float)icon.Height));

            //                    using (var graphics = Graphics.FromImage(destImage))
            //                    {
            //                        //graphics.CompositingMode = CompositingMode.SourceCopy;
            //                        graphics.CompositingQuality = CompositingQuality.HighQuality;
            //                        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            //                        graphics.SmoothingMode = SmoothingMode.HighQuality;
            //                        graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

            //                        using (var wrapMode = new ImageAttributes())
            //                        {
            //                            wrapMode.SetWrapMode(WrapMode.TileFlipXY);
            //                            graphics.DrawImage(icon, destRect, 0, 0, icon.Width, icon.Height, GraphicsUnit.Pixel, wrapMode);
            //                        }
            //                        StringFormat stringFormat = new StringFormat();
            //                        stringFormat.Alignment = StringAlignment.Center;
            //                        stringFormat.LineAlignment = StringAlignment.Near;
            //                        graphics.DrawString(text, myFont, Brushes.Black,
            //                            new Rectangle(0, (int)config.C2_StartY, destImage.Width, destImage.Height), stringFormat);
            //                        destImage.Save(Application.StartupPath + @"\Output\" + order.orderId + "-" + order.orderItemID + ".png");
            //                    }

            //                }





            //                //fileContent = reader.ReadToEnd();

            //            }

            //            // get json from URL , local file for testing
            //        }
            //    }


            //}
            //MessageBox.Show("Done");
        }

        private async void unshipedOrdersToolStripMenuItem_ClickAsync(object sender, EventArgs e)
        {
            //var msg;
            //113-7186279-3991433
            //113-8686836-7693851
            //PrintingTestOrder001
            //Form form = new Orders();
            //form.ShowDialog();

            var client = new RestClient("https://ssapi.shipstation.com/orders?order=113-7186279-3991433");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Host", "ssapi.shipstation.com");
            request.AddHeader("Authorization", getAuthorizationString());
            IRestResponse response = await client.ExecuteAsync(request);
            //textBox1.Text = response.Content;
            //OrderDetail.OrderDetail orders = JsonConvert.DeserializeObject<OrderDetail.OrderDetail>(response.Content);

        }

        private void AddBasicHeader(HttpClient client)
        {
            string AuthorizationMethod = "Basic";
            AuthorizationString = AuthorizationMethod.Trim() + " "
                                + Convert.ToBase64String(
                                    Encoding.UTF8.GetBytes(ShipStationAPIKey
                                + ":" + ShipStationAPISecret));
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add
                        (new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add
                ("Authorization", AuthorizationString);
            //client.BaseAddress = 
        }
        private string getAuthorizationString()
        {
            return "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(ShipStationAPIKey + ":" + ShipStationAPISecret));
        }

        private void shipStattionOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }





        private async void getOrdersStripMenuItem_Click(object sender, EventArgs e)
        {

            Form form = new getOrders(this);
            DialogResult result = form.ShowDialog(this);
            if (result == DialogResult.Cancel)
                return;
            dataGridView1.Rows.Clear();
            int r = 1;
            IRestResponse response = client.ExecuteAsGet(request, "GET");
            orderDetail = JsonConvert.DeserializeObject<OrderDetail.OrderDetail>(response.Content);

            //OrderDetail.OrderDetail orderDetail = JsonConvert.DeserializeObject<OrderDetail.OrderDetail>(responseResult.Content);

            //if (orderDetail.total == 0)
            //    textBox1.Text = "No order was found";
            //else if (orderDetail.total == 1)
            //    textBox1.Text = string.Format("{0} order was found", orderDetail.total);
            //else
            //    textBox1.Text = string.Format("{0} orders was found", orderDetail.total);

            foreach (Order order in orderDetail.orders)
            {
                //DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                foreach (Item item in order.items)
                {
                    dataGridView1.Rows.Add(r++, true, order.orderNumber, item.sku, order.orderStatus, "", order.orderId);
                    dataGridView1.Rows[r - 2].Cells[1].ReadOnly = false;
                }

                //foreach (Item item in order.items)
                //{
                //    await processOrder(order, item);
                //}
            }
            //MessageBox.Show("Done");


        }

        private async void buttonProcess_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if ((Boolean)row.Cells[1].Value)
                {
                    row.Cells[5].Value = "Waiting...";
                }
            }
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if ((Boolean)row.Cells[1].Value)
                {
                    int id = int.Parse(row.Cells[6].Value.ToString());

                    List<Order> selectedOrders = orderDetail.orders.Select(o => o).Where(o => o.orderId == id).ToList<Order>();
                    foreach (Order order in selectedOrders)
                    {
                        foreach (Item item in order.items)
                        {
                            await processOrder(order, item);
                            row.Cells[5].Value = "Done";
                        }
                    }

                }
            }
            if (orderDetail == null) return;
            foreach (Order order in orderDetail.orders)
            {
                //dataGridView1.Columns[2].
                //DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();

                //foreach (Item item in order.items)
                //{
                //    await processOrder(order, item);
                //}
            }
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == '\u001b')
            {

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Selected = false;
                }

            }
        }

        private void CustomOrders_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\u001b')
            {

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Selected = false;
                }

            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Selected = false;
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                var url = "https://sellercentral.amazon.com/orders-v3/order/" + dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                //var url = e.Row.Columns[1].Value;
                Process.Start(url);
            }
        }

        private void outputFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string folder = Properties.Settings.Default.outputFolder;
            if (folder == string.Empty)
            {
                folder = Application.StartupPath + @"\Output";
            }
            Form form = new folderSelector(this, folder);
            DialogResult result = form.ShowDialog(this);
            if (result == DialogResult.Cancel)
                return;

            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                //folderDialog.SelectedPath = outputFolder;
                folderDialog.SelectedPath = searchFolder;

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    outputFolder = folderDialog.SelectedPath;
                    Properties.Settings.Default.outputFolder = outputFolder;
                    Properties.Settings.Default.Save();


                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells[1].Value = checkBox1.Checked;
            }
        }
    }

}

public class ShipStationOrder
{
    //public AdvancedOptions advancedOptions { get; set; }
    public string amountPaid { get; set; }
    //public BillTo billTo { get; set; }
    public string customerEmail { get; set; }
    public string customerId { get; set; }
    public string customerNotes { get; set; }
    public string customerUsername { get; set; }
    public string internalNotes { get; set; }
    //public List<Item> items { get; set; }
    public string orderDate { get; set; }
    public string orderKey { get; set; }
    public string orderNumber { get; set; }
    public string orderStatus { get; set; }
    public string paymentDate { get; set; }
    public string paymentMethod { get; set; }
    public string requestedShippingService { get; set; }
    public string shipByDate { get; set; }
    //public ShipTo shipTo { get; set; }
    public string shippingAmount { get; set; }
    public string taxAmount { get; set; }
}
