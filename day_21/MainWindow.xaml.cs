using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace day_21
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    /*
     * 실습. 컬러 슬라이더
     * • 슬라이더 3개를 넣고 각각 Label로 Red, Green, Blue 이름을 붙임
     * • 범위는 0~255를 가지고, 5 단위로 움직임
     * • 각 슬라이더의 현재 값을 Label 또는 TextBox로 표현 
     * • 값을 변경할 때마다 지정된 값 대로 Grid의 배경색 변경
     * • Color.FromRgb() 메서드 검색
     * • idColorBrush() 검색
     * • 그룹 박스 안에 일반, 반전, 흑백 라디오 버튼을 각각 만들고 해당 기능에 따라 배경 색상이 바뀌도록 
     * • 흑백은 RGB 값을 평균내서 모든 컬러 채널에 일괄 적용
     * • 반전은 RGB 각각의 컬러 채널에서 최대값인 255에서 현재 값을 뺀 값을 적용
     */

    public enum ColorType
    {
        None = 0,       // 0 : None
        Original = 1,   // 1 : 원본
        GrayTone = 2,   // 2 : 회색조
        Invert = 3      // 3 : 반전
    }

    public partial class MainWindow : Window
    {
        public RGB color = new();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void UpdateBackground(Color color)
        {
            bgResult.Fill = new SolidColorBrush(color);
            
        }

        public class RGB
        {
            public byte Red { get; set; }
            public byte Green { get; set; }
            public byte Blue { get; set; }
            public ColorType cType { get; set; }
            public Color ConvertedColor { get; set; }


            // Class 생성자 (매개변수 없을 시 0,0,0으로 설정)
            public RGB()
            {
                Red = 0;
                Green = 0;
                Blue = 0;
                cType = ColorType.Original;
                ConvertedColor = Color.FromRgb(0, 0, 0);
            }

            // Class 생성자 (R, G, B 값을 매개변수로 설정)
            public RGB(byte red, byte green, byte blue)
            {
                Red = red;
                Green = green;
                Blue = blue;
                cType = ColorType.Original;
                ConvertedColor = Color.FromRgb(red, green, blue);
            }

            // Class의 ColorType 속성에 따라 색상을 변환하는 method
            public void Convert(ColorType cType)
            {
                switch (cType)
                {
                    case ColorType.None:
                        ConvertedColor = this.ToColor();
                        break;
                    case ColorType.Original:
                        ConvertedColor = this.ToColor();
                        break;
                    case ColorType.GrayTone:
                        // 흑백은 RGB 값을 평균내서 모든 컬러 채널에 일괄 적용
                        byte gray = (byte)Math.Round(0.299 * Red + 0.587 * Green + 0.114 * Blue);

                        ConvertedColor = this.ToColor(gray, gray, gray);
                        break;
                    case ColorType.Invert:
                        // 반전은 RGB 각각의 컬러 채널에서 최대값인 255에서 현재 값을 뺀 값을 적용
                        byte r = (byte)(255 - Red);
                        byte g = (byte)(255 - Green);
                        byte b = (byte)(255 - Blue);

                        ConvertedColor = this.ToColor(r, g, b);
                        break;
                }
            }

            // Class의 RGB 값을 Color 개체로 변환하는 method
            public Color ToColor()
            {
                return Color.FromRgb(this.Red, this.Green, this.Blue);
            }

            // 매개변수로 입력된 RGB 값을 Color 개체로 변환하는 method (overload로 구현)
            public Color ToColor(byte r, byte g, byte b)
            {
                return Color.FromRgb(r, g, b);
            }


            // 입력된 색상을 출력하는 Debugging method
            public void PrintColor()
            {
                Console.WriteLine("Color Info");
                Console.WriteLine($"R : {Red}");
                Console.WriteLine($"G : {Green}");
                Console.WriteLine($"B : {Blue}");
            }
        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider slider = (Slider)sender;

            if (slider.Tag is string tag)
            {
                byte value = (byte)slider.Value;

                if (tag == "Red")
                {
                    color.Red = value;
                    textBlockRed.Text = value.ToString();
                }
                else if (tag == "Green")
                {
                    color.Green = value;
                    textBlockGreen.Text = value.ToString();
                }
                else if (tag == "Blue")
                {
                    color.Blue = value;
                    textBlockBlue.Text = value.ToString();
                }
            }

            color.Convert(color.cType);
            UpdateBackground(color.ConvertedColor);
        }

        private void radioColorType_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = (RadioButton)sender;

            if (rb.Tag is string tag)
            {
                if (tag == "Original")
                {
                    color.cType = ColorType.Original;
                }
                else if (tag == "GrayTone")
                {
                    color.cType = ColorType.GrayTone;
                }
                else if (tag == "Invert")
                {
                    color.cType = ColorType.Invert;
                }
            }

            color.Convert(color.cType);
            UpdateBackground(color.ConvertedColor);
        }
    }
}