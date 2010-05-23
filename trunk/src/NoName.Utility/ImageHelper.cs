using System;
using System.Collections.Generic;
using System.Web;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace NoName.Utility
{
    public class ImageHelper : IDisposable
    {
        private Bitmap bmpTemp;	// 用于保存处理中的图像的对象
        private Image imgSource;// 图象源

        #region 类属性
        /// <summary>
        /// 获取图像
        /// </summary>
        public Image ImageSource
        {
            get { return imgSource; }
        }

        /// <summary>
        /// 三维字体或阴影方向枚举
        /// </summary>
        public enum Direction : byte
        {
            /// <summary>
            /// 右上角
            /// </summary>
            RightUp,
            /// <summary>
            /// 右下角
            /// </summary>
            RightDown,
            /// <summary>
            /// 左上角
            /// </summary>
            LeftUp,
            /// <summary>
            /// 左下角
            /// </summary>
            LeftDown
        }

        /// <summary>
        /// 横向对齐位置枚举
        /// </summary>
        public enum Alignment : byte
        {
            /// <summary>
            /// 居中
            /// </summary>
            Center,
            /// <summary>
            /// 靠右
            /// </summary>
            Right,
            /// <summary>
            /// 靠左
            /// </summary>
            Left
        }
        #endregion


        #region 加载图象 LoadImage

        /// <summary>
        /// 从文件中加载图象
        /// </summary>
        /// <param name="imageFile">要加载的图像文件名(包括完整路径)</param>
        #region LoadImage
        public void LoadImage(string imageFile)
        {
            string strExtend = Path.GetExtension(imageFile).Trim().ToLower();
            if (strExtend != ".gif" && strExtend != ".jpg" && strExtend != ".jpe" && strExtend != ".bmp" && strExtend != ".jpeg" && strExtend != ".png" && strExtend != ".bmp")
            {
                throw new Exception("不支持此图像文件格式！");
            }
            imgSource = Image.FromFile(imageFile);
        }
        #endregion

        /// <summary>
        /// 从流中加载图象
        /// </summary>
        /// <param name="stream">各种形式的流</param>
        #region LoadImage
        public void LoadImage(Stream stream)
        {
            imgSource = System.Drawing.Image.FromStream(stream);
        }
        #endregion

        #endregion

        /// <summary>
        /// 创建一个指定长宽的空图，并以指定颜色填充
        /// </summary>
        /// <param name="intWidth">宽度</param>
        /// <param name="intHeight">高度</param>
        /// <param name="objBgColor">填充色</param>
        #region CreateImage
        public void CreateImage(int intWidth, int intHeight, Color objBgColor)
        {
            imgSource = new Bitmap(intWidth, intHeight);
            Graphics g = Graphics.FromImage(imgSource);
            try
            {
                g.Clear(objBgColor);
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                g.Dispose();
            }
        }
        #endregion

        /// <summary>
        /// 清除Image上的所有图象，并用指定颜色填充
        /// </summary>
        /// <param name="objBgColor">填充色</param>
        #region ClearBackColor
        public void ClearBackColor(Color objBgColor)
        {
            Graphics g = Graphics.FromImage(imgSource);
            try
            {
                g.Clear(objBgColor);
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                g.Dispose();
            }
        }
        #endregion

        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="strPath">保存路径（完整绝对路径）</param>
        #region SaveImage
        public void SaveImage(string strPath)
        {
            string strExt = Path.GetExtension(strPath).ToLower();
            if (strExt == ".jpeg" || strExt == ".jpg")
            {
                ImageCodecInfo myImageCodecInfo;

                Encoder myEncoder;
                EncoderParameter myEncoderParameter;
                EncoderParameters myEncoderParameters;

                myImageCodecInfo = GetImageEncoder("image/jpeg");
                myEncoder = Encoder.Quality;

                myEncoderParameters = new EncoderParameters(1);
                myEncoderParameter = new EncoderParameter(myEncoder, (long)75);
                myEncoderParameters.Param[0] = myEncoderParameter;

                imgSource.Save(strPath, myImageCodecInfo, myEncoderParameters);
            }
            else
            {
                imgSource.Save(strPath, GetImageFormat(strPath));
            }
        }
        #endregion

        /// <summary>
        /// 释放占用的资源
        /// </summary>
        #region Dispose
        public void Dispose()
        {
            if (bmpTemp != null)
            {
                bmpTemp.Dispose();
            }
            if (imgSource != null)
            {
                imgSource.Dispose();
            }
        }
        #endregion

        /// <summary>
        /// 返回图象编码信息
        /// </summary>
        /// <param name="MYmimeType"></param>
        /// <returns></returns>
        #region GetImageEncoder
        private ImageCodecInfo GetImageEncoder(string MYmimeType)
        {
            int i;
            ImageCodecInfo objReturn = null;
            ImageCodecInfo[] encoders = ImageCodecInfo.GetImageEncoders();
            for (i = 0; i < encoders.Length; i++)
            {
                if (encoders[i].MimeType == MYmimeType)
                    objReturn = encoders[i];
            }
            return objReturn;
        }
        #endregion

        /// <summary>
        /// 根据文件名获取图像保存格式
        /// </summary>
        /// <param name="imageFile">文件名</param>
        /// <returns>图像格式</returns>
        #region GetImageFormat
        private ImageFormat GetImageFormat(string imageFile)
        {
            ImageFormat imgFormat;
            string strExt = Path.GetExtension(imageFile).ToLower();
            switch (strExt)
            {
                case ".jpg":
                    imgFormat = ImageFormat.Jpeg;
                    break;
                case ".jpeg":
                    imgFormat = ImageFormat.Jpeg;
                    break;
                case ".gif":
                    imgFormat = ImageFormat.Gif;
                    break;
                case ".png":
                    imgFormat = ImageFormat.Png;
                    break;
                case ".bmp":
                    imgFormat = ImageFormat.Bmp;
                    break;
                default:
                    throw new Exception("目标文件名请选择jpg或者gif格式的扩展名。");
            }
            return imgFormat;
        }
        #endregion

        /// <summary>
        /// 将符合尺寸大小的图片直接加背景图片
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="picType"></param>
        /// <param name="destLength">系统规定的长度</param>
        /// <param name="backPicURl"></param>
        #region AddBackGroundToPic
        public void AddBackGroundToPic(int width, int height, string picType, int destLength, string backPicURl)
        {
            bmpTemp = new Bitmap(destLength, destLength, PixelFormat.Format32bppArgb);

            bmpTemp.SetResolution(imgSource.HorizontalResolution, imgSource.VerticalResolution);
            bmpTemp.MakeTransparent(Color.White);

            // 建立Graphics对象，并设置主要属性
            Graphics g = Graphics.FromImage(bmpTemp);
            try
            {
                g.Clear(Color.White);
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.CompositingQuality = CompositingQuality.GammaCorrected;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.SmoothingMode = SmoothingMode.HighQuality;

                // 在画布上画图
                //设置背景图片			
                g.DrawImage(Image.FromFile(backPicURl + picType + ".png"), 0, 0);
                g.DrawImage(imgSource, (destLength - Convert.ToSingle(width)) / 2, (destLength - Convert.ToSingle(height)) / 2, Convert.ToSingle(width), Convert.ToSingle(height));
                imgSource.Dispose();
                imgSource = (Image)bmpTemp.Clone();
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                g.Dispose();
                bmpTemp.Dispose();
            }
        }
        #endregion

        #region 缩放图片 ScaleImageByPercent

        /// <summary>
        /// 按指定比例缩放。
        /// </summary>
        /// <param name="percent">缩放比例，如1.3</param>
        #region ScaleImageByPercent
        public void ScaleImageByPercent(float percent)
        {
            // 新尺寸
            int newWidth = Convert.ToInt32(imgSource.Width * percent);
            int newHeight = Convert.ToInt32(imgSource.Height * percent);
            // 新建BitMap对象，并设置主要属性
            bmpTemp = new Bitmap(newWidth, newHeight, PixelFormat.Format32bppArgb);
            bmpTemp.SetResolution(imgSource.HorizontalResolution, imgSource.VerticalResolution);
            bmpTemp.MakeTransparent(Color.White);

            // 建立Graphics对象，并设置主要属性
            Graphics g = Graphics.FromImage(bmpTemp);
            try
            {
                g.Clear(Color.White);
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.CompositingQuality = CompositingQuality.GammaCorrected;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.SmoothingMode = SmoothingMode.HighQuality;

                // 在画布上画图
                g.DrawImage(imgSource, 0, 0, Convert.ToSingle(newWidth), Convert.ToSingle(newHeight));

                imgSource.Dispose();
                imgSource = (Image)bmpTemp.Clone();
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                g.Dispose();
                bmpTemp.Dispose();
            }
        }
        #endregion

        /// <summary>
        /// 按指定比例和缩放后的图片大小类型缩放。
        /// </summary>
        /// <param name="percent">缩放比例，如1.3</param>
        /// <param name="picType">缩放后的图片大小类型,如"big""middle""small"</param>
        /// <param name="destLength">系统规定的长度</param>
        #region ScaleImageByPercent
        public void ScaleImageByPercent(float percent, string picType, int destLength)
        {
            // 新尺寸
            int newWidth = Convert.ToInt32(imgSource.Width * percent);
            int newHeight = Convert.ToInt32(imgSource.Height * percent);

            // 新建BitMap对象，并设置主要属性
            //设置图片大小			
            bmpTemp = new Bitmap(destLength, destLength, PixelFormat.Format32bppArgb);

            bmpTemp.SetResolution(imgSource.HorizontalResolution, imgSource.VerticalResolution);
            bmpTemp.MakeTransparent(Color.White);

            // 建立Graphics对象，并设置主要属性
            Graphics g = Graphics.FromImage(bmpTemp);
            try
            {
                g.Clear(Color.White);
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.CompositingQuality = CompositingQuality.GammaCorrected;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.SmoothingMode = SmoothingMode.HighQuality;

                //设置背景图片		
                //g.DrawImage(Image.FromFile(ConfigurationSettings.AppSettings["AdminUrl"]+"/images/"+sPicType+".png"),0,0);
                // 在画布上画图		
                g.DrawImage(imgSource, (destLength - Convert.ToSingle(newWidth)) / 2, (destLength - Convert.ToSingle(newHeight)) / 2, Convert.ToSingle(newWidth), Convert.ToSingle(newHeight));
                imgSource.Dispose();
                imgSource = (Image)bmpTemp.Clone();
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                g.Dispose();
                bmpTemp.Dispose();
            }
        }
        #endregion

        /// <summary>
        ///  根据指定的尺寸缩放图象
        /// </summary>
        /// <param name="destWidth">缩放后的宽度</param> 
        /// <param name="destHeight">缩放后的高度</param> 
        /// <param name="isScratch">如果指定高宽比与源图的比例不同，是否拉伸图象</param>
        #region ScaleImageByFixSize
        public void ScaleImageByFixSize(int destWidth, int destHeight, bool isScratch)
        {
            if (!isScratch)
            {
                // 如果不拉伸，则按比例缩放到最合适的大小。
                // 判断高宽比
                float heightScale = Convert.ToSingle(destHeight) / Convert.ToSingle(imgSource.Height);
                float widthScale = Convert.ToSingle(destWidth) / Convert.ToSingle(imgSource.Width);

                if (heightScale <= widthScale)
                {
                    ScaleImageByPercent(heightScale);
                }
                else
                {
                    ScaleImageByPercent(widthScale);
                }
            }
            else
            {
                // 新建BitMap对象，并设置主要属性
                bmpTemp = new Bitmap(destWidth, destHeight, PixelFormat.Format32bppArgb);
                bmpTemp.SetResolution(imgSource.HorizontalResolution, imgSource.VerticalResolution);

                // 建立Graphics对象，并设置主要属性
                Graphics g = Graphics.FromImage(bmpTemp);
                try
                {
                    g.Clear(Color.White);
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.CompositingQuality = CompositingQuality.GammaCorrected;
                    g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    g.SmoothingMode = SmoothingMode.HighQuality;

                    // 在画布上画图
                    g.DrawImage(imgSource, 0, 0, Convert.ToSingle(destWidth), Convert.ToSingle(destHeight));

                    // 释放资源
                    imgSource.Dispose();
                    imgSource = (Image)bmpTemp.Clone();
                }
                catch (Exception exp)
                {
                    throw exp;
                }
                finally
                {
                    g.Dispose();
                    bmpTemp.Dispose();
                }
            }
        }
        #endregion

        /// <summary>
        /// 根据指定的尺寸和缩放后的大小类型缩放图象
        /// </summary>
        /// <param name="destWidth">缩放后的宽度</param> 
        /// <param name="destHeight">缩放后的高度</param> 
        /// <param name="isScratch">如果指定高宽比与源图的比例不同，是否拉伸图象</param>
        /// <param name="picType">生成图片的大小类型 small middle big</param>
        #region ScaleImageByFixSize
        public void ScaleImageByFixSize(int destWidth, int destHeight, bool isScratch, string picType)
        {
            if (!isScratch)
            {
                // 如果不拉伸，则按比例缩放到最合适的大小。
                // 判断高宽比
                float heightScale = Convert.ToSingle(destHeight) / Convert.ToSingle(imgSource.Height);
                float widthScale = Convert.ToSingle(destWidth) / Convert.ToSingle(imgSource.Width);

                if (heightScale <= widthScale)
                {
                    ScaleImageByPercent(heightScale, picType, destHeight);
                }
                else
                {
                    ScaleImageByPercent(widthScale, picType, destHeight);
                }
            }
            else
            {
                // 新建BitMap对象，并设置主要属性
                bmpTemp = new Bitmap(destWidth, destHeight, PixelFormat.Format32bppArgb);
                bmpTemp.SetResolution(imgSource.HorizontalResolution, imgSource.VerticalResolution);

                // 建立Graphics对象，并设置主要属性
                Graphics g = Graphics.FromImage(bmpTemp);
                try
                {
                    g.Clear(Color.White);
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.CompositingQuality = CompositingQuality.GammaCorrected;
                    g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    g.SmoothingMode = SmoothingMode.HighQuality;

                    // 在画布上画图
                    g.DrawImage(imgSource, 0, 0, Convert.ToSingle(destWidth), Convert.ToSingle(destHeight));

                    // 释放资源
                    imgSource.Dispose();
                    imgSource = (Image)bmpTemp.Clone();
                }
                catch (Exception exp)
                {
                    throw exp;

                }
                finally
                {
                    g.Dispose();
                    bmpTemp.Dispose();
                }
            }
        }
        #endregion

        #endregion

        #region 在图上写3D字 Write3DText

        /// <summary>
        /// 在图片的指定位置上写3D字。
        /// </summary>
        /// <param name="textContent">文本内容</param>
        /// <param name="fontName">字体名称</param>
        /// <param name="fontStyle">风格</param>
        /// <param name="color">颜色</param>
        /// <param name="x1">左上角x坐标</param>
        /// <param name="y1">左上角y坐标</param>
        /// <param name="x2">右上角x坐标</param>
        /// <param name="y2">右上角y坐标</param>
        public void Write3DText(string textContent, string fontName, FontStyle fontStyle, Color color, int x1, int y1, int x2, int y2)
        {
            Write3DText(textContent, fontName, fontStyle, color, x1, y1, x2, y2, Alignment.Left);
        }


        /// <summary>
        /// 在图片的指定位置上写3D字。
        /// </summary>
        /// <param name="textContent">文本内容</param>
        /// <param name="fontName">字体名称</param>
        /// <param name="fontStyle">风格</param>
        /// <param name="color">颜色</param>
        /// <param name="x1">左上角x坐标</param>
        /// <param name="y1">左上角y坐标</param>
        /// <param name="x2">右上角x坐标</param>
        /// <param name="y2">右上角y坐标</param>
        /// <param name="alignment">对齐方式</param>
        public void Write3DText(string textContent, string fontName, FontStyle fontStyle, Color color, int x1, int y1, int x2, int y2, Alignment alignment)
        {
            Write3DText(textContent, fontName, fontStyle, color, x1, y1, x2, y2, 0, Direction.LeftDown, alignment);
        }

        /// <summary>
        /// 在图片的指定位置上写3D字。
        /// </summary>
        /// <param name="textContent">文本内容</param>
        /// <param name="fontName">字体名称</param>
        /// <param name="fontStyle">风格</param>
        /// <param name="color">颜色</param>
        /// <param name="x1">左上角x坐标</param>
        /// <param name="y1">左上角y坐标</param>
        /// <param name="x2">右上角x坐标</param>
        /// <param name="y2">右上角y坐标</param>
        /// <param name="depth">3D字体宽度，以像素点为单位</param>
        /// <param name="direction">三维字体方向</param>
        public void Write3DText(string textContent, string fontName, FontStyle fontStyle, Color color, int x1, int y1, int x2, int y2, int depth, Direction direction)
        {
            Write3DText(textContent, fontName, fontStyle, color, x1, y1, x2, y2, depth, direction, Alignment.Left);
        }

        /// <summary>
        /// 在图片的指定位置上写3D字。
        /// </summary>
        /// <param name="textContent">文本内容</param>
        /// <param name="fontName">字体名称</param>
        /// <param name="fontStyle">风格</param>
        /// <param name="color">颜色</param>
        /// <param name="x1">左上角x坐标</param>
        /// <param name="y1">左上角y坐标</param>
        /// <param name="x2">右上角x坐标</param>
        /// <param name="y2">右上角y坐标</param>
        /// <param name="depth">3D字体宽度，以像素点为单位</param>
        /// <param name="direction">三维字体方向</param>
        /// <param name="alignment">文本对齐方式</param>
        public void Write3DText(string textContent, string fontName, FontStyle fontStyle, Color color, int x1, int y1, int x2, int y2, int depth, Direction direction, Alignment alignment)
        {
            if (textContent == "" || textContent == null)
                return;

            // 格式化文本
            StringFormat format = new StringFormat();
            switch (alignment)
            {
                case Alignment.Center:
                    format.LineAlignment = StringAlignment.Center;
                    break;
                case Alignment.Left:
                    format.LineAlignment = StringAlignment.Near;
                    break;
                case Alignment.Right:
                    format.LineAlignment = StringAlignment.Far;
                    break;
            }
            bmpTemp = new Bitmap(imgSource.Width, imgSource.Height, PixelFormat.Format32bppArgb);
            bmpTemp.SetResolution(imgSource.HorizontalResolution, imgSource.VerticalResolution);

            // 建立Graphics对象，并设置主要属性
            Graphics g = Graphics.FromImage(bmpTemp);
            SolidBrush sb = new SolidBrush(Color.Black); ;

            Font font = new Font(fontName, (float)16, fontStyle, GraphicsUnit.Pixel);
            try
            {
                g.Clear(Color.White);
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.CompositingQuality = CompositingQuality.GammaCorrected;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.SmoothingMode = SmoothingMode.HighQuality;

                // 在画布上画图
                g.DrawImage(imgSource, 0, 0);

                // 定义画刷		
                // 创建所需对象
                #region 调整字体大小以适应指定区域

                float height = (float)y2 - (float)y1;
                float width = (float)x2 - (float)x1;
                SizeF sf;			// 当前大小
                int intStep = 5;		// 增加或者减少的步长，以象素为单位

                font.Dispose();
                font = new Font(font.FontFamily.Name, height, font.Style, GraphicsUnit.Pixel);
                sf = g.MeasureString(textContent, font);
                if (sf.Width > width || sf.Height > height)
                {
                    // 如果字太大了，就循环缩小，直到刚好符合为止
                    while (sf.Width > width || sf.Height > height)
                    {
                        // 将字体变小一点
                        font.Dispose();
                        font = new Font(font.FontFamily.Name, font.Size - intStep, font.Style, GraphicsUnit.Pixel);
                        sf = g.MeasureString(textContent, font);
                    }
                }
                else if (sf.Width < width && sf.Height < height)
                {
                    // 如果字太小了（高和宽都达不到指定的区域）
                    while (sf.Width < width && sf.Height < height)
                    {
                        // 将字体变大一点
                        font.Dispose();
                        font = new Font(font.FontFamily.Name, font.Size + intStep, font.Style, GraphicsUnit.Pixel);
                        sf = g.MeasureString(textContent, font);
                    }
                }
                #endregion

                // 设置反锯齿
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                g.SmoothingMode = SmoothingMode.AntiAlias;

                #region 根据深度值循环写3D字

                // 初始化灰度，下面将设置渐变色，使三维字能渐变
                /*byte red = 0;
                byte green = 0;
                byte blue = 0;
                byte alpha = 255;*/
                //sb						=	new SolidBrush(Color.Black);//(Color.FromArgb(alpha,(int)red,(int)green,(int)blue));
                // 获取灰度增长阶级
                // byte step				=	(byte)(255 / depth);

                int x = x1;
                int y = y1;
                for (int i = 0; i < depth; i++)
                {
                    // 设置写字的坐标
                    if (direction == Direction.LeftDown || direction == Direction.LeftUp)
                        x--;
                    else
                        x++;
                    if (direction == Direction.LeftDown || direction == Direction.RightDown)
                        y++;
                    else
                        y--;
                    // 设置灰度
                    /*red += step;
                    green += step;
                    blue += step;

                    sb.Color = Color.FromArgb(alpha,(int)red,(int)green,(int)blue);*/
                    g.DrawString(textContent, font, sb, x, y, format);
                }
                #endregion

                sb.Color = color;
                g.DrawString(textContent, font, sb, x1, y1, format);

                // 释放资源
                imgSource.Dispose();
                imgSource = (Image)bmpTemp.Clone();
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                g.Dispose();
                bmpTemp.Dispose();
                font.Dispose();
                sb.Dispose();
                font.Dispose();
            }
        }
        #endregion

        #region 在图上写镂空字 WriteOutLineText

        /// <summary>
        /// 在图上写镂空字
        /// </summary>
        /// <param name="textContent">要写的文字</param>
        /// <param name="fontName">字体名称</param>
        /// <param name="fontStyle">字体样式</param>
        /// <param name="objBorderColor">边沿颜色</param>
        /// <param name="fillColor">填充色</param>
        /// <param name="x1">左上角x坐标</param>
        /// <param name="y1">左上角y坐标</param>
        /// <param name="x2">右上角x坐标</param>
        /// <param name="y2">右上角y坐标</param>
        /// <param name="width">镂空宽度</param>
        public void WriteOutLineText(string textContent, string fontName, FontStyle fontStyle, Color objBorderColor, Color fillColor, int x1, int y1, int x2, int y2, int width)
        {
            WriteOutLineText(textContent, fontName, fontStyle, objBorderColor, fillColor, x1, y1, x2, y2, width, Alignment.Left);
        }

        /// <summary>
        /// 在图上写镂空字
        /// </summary>
        /// <param name="textContent">要写的文字</param>
        /// <param name="fontName">字体名称</param>
        /// <param name="fontStyle">字体样式</param>
        /// <param name="objBorderColor">边沿颜色</param>
        /// <param name="fillColor">填充色</param>
        /// <param name="x1">左上角x坐标</param>
        /// <param name="y1">左上角y坐标</param>
        /// <param name="x2">右上角x坐标</param>
        /// <param name="y2">右上角y坐标</param>
        /// <param name="outLineWidth">镂空宽度</param>
        /// <param name="alignment">对齐方式</param>
        public void WriteOutLineText(string textContent, string fontName, FontStyle fontStyle, Color objBorderColor, Color fillColor, int x1, int y1, int x2, int y2, int outLineWidth, Alignment alignment)
        {
            if (textContent == "" || textContent == null)
                return;

            // 格式化文本
            StringFormat format = new StringFormat();

            switch (alignment)
            {
                case Alignment.Center:
                    format.LineAlignment = StringAlignment.Center;
                    break;
                case Alignment.Left:
                    format.LineAlignment = StringAlignment.Near;
                    break;
                case Alignment.Right:
                    format.LineAlignment = StringAlignment.Far;
                    break;
            }

            bmpTemp = new Bitmap(imgSource.Width, imgSource.Height, PixelFormat.Format32bppArgb);
            bmpTemp.SetResolution(imgSource.HorizontalResolution, imgSource.VerticalResolution);

            // 建立Graphics对象，并设置主要属性
            Graphics g = Graphics.FromImage(bmpTemp);
            SolidBrush sb = new SolidBrush(Color.White);
            Font font = new Font(fontName, (float)16, fontStyle, GraphicsUnit.Pixel);

            try
            {
                g.Clear(Color.White);
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.CompositingQuality = CompositingQuality.GammaCorrected;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.SmoothingMode = SmoothingMode.HighQuality;

                // 在画布上画图
                g.DrawImage(imgSource, 0, 0);

                // 定义画刷			
                // 创建所需对象
                #region 调整字体大小以适应指定区域
                float height = (float)y2 - (float)y1;
                float width = (float)x2 - (float)x1;
                SizeF sf;			// 当前大小
                int intStep = 5;		// 增加或者减少的步长，以象素为单位
                font.Dispose();
                font = new Font(font.FontFamily.Name, height, font.Style, GraphicsUnit.Pixel);
                sf = g.MeasureString(textContent, font);
                if (sf.Width > width || sf.Height > height)
                {
                    // 如果字太大了，就循环缩小，直到刚好符合为止
                    while (sf.Width > width || sf.Height > height)
                    {
                        // 将字体变小一点
                        font.Dispose();
                        font = new Font(font.FontFamily.Name, font.Size - intStep, font.Style, GraphicsUnit.Pixel);
                        sf = g.MeasureString(textContent, font);
                    }
                }
                else if (sf.Width < width && sf.Height < height)
                {
                    // 如果字太小了（高和宽都达不到指定的区域）
                    while (sf.Width < width && sf.Height < height)
                    {
                        // 将字体变大一点
                        font.Dispose();
                        font = new Font(font.FontFamily.Name, font.Size + intStep, font.Style, GraphicsUnit.Pixel);
                        sf = g.MeasureString(textContent, font);
                    }
                }
                #endregion

                // 设置反锯齿
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                g.SmoothingMode = SmoothingMode.AntiAlias;

                #region 根据深度值循环写镂空字
                sb.Color = fillColor;//(Color.FromArgb(alpha,(int)red,(int)green,(int)blue));
                for (int x = 0; x < outLineWidth - 1; x++)
                {
                    for (int y = 0; y < outLineWidth - 1; y++)
                    {
                        g.DrawString(textContent, font, sb, new Point(x1 + x, y1 + y));
                        g.DrawString(textContent, font, sb, new Point(x1 - x, y1 - y));
                    }
                }

                sb.Color = objBorderColor;
                g.DrawString(textContent, font, sb, new Point(x1, y1), format);
                #endregion

                // 释放资源
                imgSource.Dispose();
                imgSource = (Image)bmpTemp.Clone();
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                g.Dispose();
                bmpTemp.Dispose();
                font.Dispose();
                sb.Dispose();
            }
        }
        #endregion

        #region 在图上写阴影字 WriteShadowText

        /// <summary>
        /// 在图上写阴影字
        /// </summary>
        /// <param name="textContent">要写的字</param>
        /// <param name="fontName">字体名称</param>
        /// <param name="fontStyle">字体样式</param>
        /// <param name="fontColor">字体颜色</param>
        /// <param name="x1">左上角x坐标</param>
        /// <param name="y1">左上角y坐标</param>
        /// <param name="x2">右上角x坐标</param>
        /// <param name="y2">右上角y坐标</param>
        /// <param name="distance">阴影距离</param>
        /// <param name="direction">阴影方向</param>
        public void WriteShadowText(string textContent, string fontName, FontStyle fontStyle, Color fontColor, int x1, int y1, int x2, int y2, int distance, Direction direction)
        {
            WriteShadowText(textContent, fontName, fontStyle, fontColor, x1, y1, x2, y2, distance, direction, Alignment.Left);
        }

        /// <summary>
        /// 在图上写阴影字
        /// </summary>
        /// <param name="textContent">要写的字</param>
        /// <param name="fontName">字体名称</param>
        /// <param name="fontStyle">字体样式</param>
        /// <param name="fontColor">字体颜色</param>
        /// <param name="x1">左上角x坐标</param>
        /// <param name="y1">左上角y坐标</param>
        /// <param name="x2">右上角x坐标</param>
        /// <param name="y2">右上角y坐标</param>
        /// <param name="distance">阴影距离</param>
        /// <param name="direction">阴影方向</param>
        /// <param name="alignment">对齐方式</param>
        public void WriteShadowText(string textContent, string fontName, FontStyle fontStyle, Color fontColor, int x1, int y1, int x2, int y2, int distance, Direction direction, Alignment alignment)
        {
            if (textContent == "" || textContent == null)
                return;

            // 格式化文本
            StringFormat format = new StringFormat();

            switch (alignment)
            {
                case Alignment.Center:
                    format.LineAlignment = StringAlignment.Center;
                    break;
                case Alignment.Left:
                    format.LineAlignment = StringAlignment.Near;
                    break;
                case Alignment.Right:
                    format.LineAlignment = StringAlignment.Far;
                    break;
            }

            bmpTemp = new Bitmap(imgSource.Width, imgSource.Height, PixelFormat.Format32bppArgb);
            bmpTemp.SetResolution(imgSource.HorizontalResolution, imgSource.VerticalResolution);

            // 建立Graphics对象，并设置主要属性
            Graphics g = Graphics.FromImage(bmpTemp);
            Font font = new Font(fontName, (float)16, fontStyle, GraphicsUnit.Pixel);
            SolidBrush sb = new SolidBrush(Color.White);
            try
            {
                g.Clear(Color.White);
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.CompositingQuality = CompositingQuality.GammaCorrected;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.SmoothingMode = SmoothingMode.HighQuality;

                // 在画布上画图
                g.DrawImage(imgSource, 0, 0);

                // 定义画刷		
                // 创建所需对象
                #region 调整字体大小以适应指定区域

                float height = (float)y2 - (float)y1;
                float width = (float)x2 - (float)x1;
                SizeF sf;			// 当前大小
                int intStep = 5;		// 增加或者减少的步长，以象素为单位
                font.Dispose();
                font = new Font(font.FontFamily.Name, height, font.Style, GraphicsUnit.Pixel);
                sf = g.MeasureString(textContent, font);
                if (sf.Width > width || sf.Height > height)
                {
                    // 如果字太大了，就循环缩小，直到刚好符合为止
                    while (sf.Width > width || sf.Height > height)
                    {
                        // 将字体变小一点
                        font.Dispose();
                        font = new Font(font.FontFamily.Name, font.Size - intStep, font.Style, GraphicsUnit.Pixel);
                        sf = g.MeasureString(textContent, font);
                    }
                }
                else if (sf.Width < width && sf.Height < height)
                {
                    // 如果字太小了（高和宽都达不到指定的区域）
                    while (sf.Width < width && sf.Height < height)
                    {
                        // 将字体变大一点
                        font.Dispose();
                        font = new Font(font.FontFamily.Name, font.Size + intStep, font.Style, GraphicsUnit.Pixel);
                        sf = g.MeasureString(textContent, font);
                    }
                }
                #endregion

                // 设置反锯齿
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                g.SmoothingMode = SmoothingMode.AntiAlias;

                #region 根据方向写阴影字
                sb.Color = Color.FromArgb(100, Color.Black);
                // 设置写字的坐标
                int x = x1;
                int y = y1;
                if (direction == Direction.LeftDown || direction == Direction.LeftUp)
                    x = x1 - distance;
                else
                    x = x1 + distance;
                if (direction == Direction.LeftDown || direction == Direction.RightDown)
                    y = y1 + distance;
                else
                    y = y1 - distance;
                g.DrawString(textContent, font, sb, new Point(x, y), format);

                sb.Color = fontColor;
                g.DrawString(textContent, font, sb, new Point(x1, y1), format);
                #endregion

                // 释放资源
                imgSource.Dispose();
                imgSource = (Image)bmpTemp.Clone();
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                g.Dispose();
                bmpTemp.Dispose();
                font.Dispose();
                sb.Dispose();
            }

        }
        #endregion

        #region 贴图贴在源图上 PasteImage

        /// <summary>
        /// 根据指定左上角坐标，在指定的图像上贴图,不改变尺寸将贴图贴在源图上
        /// </summary>
        /// <param name="imageFile">要贴的图像文件路径</param>
        /// <param name="x">左上角x坐标</param>
        /// <param name="y">左上角y坐标</param>
        #region PasteImage
        public void PasteImage(string imageFile, int x, int y)
        {
            PasteImage(imageFile, x, y, Color.Empty);
        }
        #endregion

        /// <summary>
        /// 根据指定左上角坐标，在指定的图像上贴图,不改变尺寸将贴图贴在源图上
        /// </summary>
        /// <param name="imageFile">要贴的图像文件路径</param>
        /// <param name="x">左上角x坐标</param>
        /// <param name="y">左上角y坐标</param>
        /// <param name="transparentColor">透明色</param>
        #region PasteImage
        public void PasteImage(string imageFile, int x, int y, Color transparentColor)
        {
            // 读取图像文件
            System.Drawing.Bitmap imgToBePasted = new Bitmap(Image.FromFile(imageFile));

            // 设置透明色
            if (!transparentColor.IsEmpty)
            {
                imgToBePasted.MakeTransparent(transparentColor);
            }
            bmpTemp = new Bitmap(imgSource.Width, imgSource.Height, PixelFormat.Format32bppArgb);
            bmpTemp.SetResolution(imgSource.HorizontalResolution, imgSource.VerticalResolution);

            // 建立Graphics对象，并设置主要属性
            Graphics g = Graphics.FromImage(bmpTemp);
            try
            {
                g.Clear(Color.White);
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.CompositingQuality = CompositingQuality.GammaCorrected;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.SmoothingMode = SmoothingMode.HighQuality;

                // 在画布上画图
                g.DrawImage(imgSource, 0, 0);
                g.DrawImage(imgToBePasted, x, y);

                // 释放资源
                imgSource.Dispose();
                imgSource = (Image)bmpTemp.Clone();
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                imgToBePasted.Dispose();
                g.Dispose();
                bmpTemp.Dispose();
            }
        }
        #endregion

        /// <summary>
        /// 将高宽不一致的图片，重新绘制成一致的图片，以防止一些变形情况的发生
        /// </summary>
        /// <param name="filledColor">添充的背景颜色</param>
        public void FillImageBackColor(Color filledColor)
        {
            int length = 0, x = 0, y = 0;
            if (imgSource.Width > imgSource.Height)
            {
                length = imgSource.Width;
                y = (imgSource.Width - imgSource.Height) / 2;
            }
            else
            {
                length = imgSource.Height;
                x = (imgSource.Height - imgSource.Width) / 2;
            }

            bmpTemp = new Bitmap(length, length, PixelFormat.Format32bppArgb);
            bmpTemp.SetResolution(imgSource.HorizontalResolution, imgSource.VerticalResolution);

            // 建立Graphics对象，并设置主要属性
            Graphics g = Graphics.FromImage(bmpTemp);
            try
            {
                g.Clear(filledColor);
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.CompositingQuality = CompositingQuality.GammaCorrected;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.SmoothingMode = SmoothingMode.HighQuality;

                // 在画布上画图
                //HatchBrush b = new HatchBrush(HatchStyle.Cross, Color.LightGray, filledColor);

                g.DrawImage(imgSource, x, y);

                // 释放资源
                imgSource.Dispose();
                imgSource = (Image)bmpTemp.Clone();
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                g.Dispose();
                bmpTemp.Dispose();
            }
        }
        #endregion

    }
}