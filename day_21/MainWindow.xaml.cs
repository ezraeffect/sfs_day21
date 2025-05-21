using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
     * • SolidColorBrush() 검색
     * • 그룹 박스 안에 일반, 반전, 흑백 라디오 버튼을 각각 만들고 해당 기능에 따라 배경 색상이 바뀌도록 
     * • 흑백은 RGB 값을 평균내서 모든 컬러 채널에 일괄 적용
     * • 반전은 RGB 각각의 컬러 채널에서 최대값인 255에서 현재 값을 뺀 값을 적용
     */
    public partial class MainWindow : Window
    {
        public RGB color = new RGB();

        public MainWindow()
        {
            InitializeComponent();


        }

        private void UpdateBackground()
        {
            bgGrid.Background = new SolidColorBrush(color.ToColor());
        }

        public class RGB
        {
            public int Red { get; set; }
            public int Green { get; set; }
            public int Blue { get; set; }

            public RGB()
            {
                Red = 0;
                Green = 0;
                Blue = 0;
            }
            public RGB(int red, int green, int blue)
            {
                Red = red;
                Green = green;
                Blue = blue;
            }

            public void ConvertOriginal(int r, int g, int b)
            {
                this.Red = r;
                this.Green = g;
                this.Blue = b;
            }

            public void ConvertGrayTone(int r, int g, int b)
            {
                // 흑백은 RGB 값을 평균내서 모든 컬러 채널에 일괄 적용
                int gray = (int)Math.Round(0.299 * r + 0.587 * g + 0.114 * b);
                this.Red = gray;
                this.Green = gray;
                this.Blue = gray;
            }

            public void ConvertInvert(int r, int g, int b)
            {
                // 반전은 RGB 각각의 컬러 채널에서 최대값인 255에서 현재 값을 뺀 값을 적용
                this.Red = 255 - r;
                this.Green = 255 - g;
                this.Blue = 255 - b;
            }

            public Color ToColor()
            {
                return Color.FromRgb((byte)this.Red, (byte)this.Green, (byte)this.Blue);
            }

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
                int value = (int)slider.Value;

                if (tag == "Red")
                {
                    color.Red = value;
                    textBlockRed.Text = color.Red.ToString();
                }
                else if (tag == "Green")
                {
                    color.Green = value;
                    textBlockGreen.Text = color.Green.ToString();
                }
                else if (tag == "Blue")
                {
                    color.Blue = value;
                    textBlockBlue.Text = color.Blue.ToString();
                }
            }

            UpdateBackground();
        }
    }
}