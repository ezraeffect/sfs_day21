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

/*
 * TabControl
 * 웹 브라우저 처럼 탭 버튼을 눌러 다른 내용의 화면 전환
 * 
 * 1. TabControl
 * - 전체 탭 컨테이너
 * - 내부의 여러개 TabItem을 가질 ㄹ수 있음
 * 
 * 2. TabItem
 * - 각각의 탭을 나타내는 항목
 * - Header : 탭 제목
 * - Content : 보여줄 컨텐츠 배치
 */

/*
 * StackPanel
 * 자식 요소들을 수직(Vertical) 또는 수평(Horizontal) 방향으로 자동으로 정렬해서 배치하는 Layout Panel
 * - 요소들을 순서대로 쌓음
 * - 마우스 조작으로 요소 이동 불가능
 * 
 * [Attribute]
 * Orientation : 쌓는 방향 지정 - Vertical(수직) : Default, Horizontal(수형)
 */

/*
 * Grid
 * 행과 열을 나눠 UI 요소를 격자 구조로 배치하도록 하는 Layout Panel
 * - 요소들이 표 형태로 정리되어야 할 때
 * - 요소들이 정확한 위치에 있어야 할 때
 * - 반응형 비율 기반 배치가 필요 할 때
 * 
 * [Attribute]
 * RowDefinition : 행(가로줄)
 * ColumnDefinition : 열(세로줄)
 * Height / Width : 
 * - Auto : 내부 요소의 크기에 맞게
 * - * : 나머지 공간을 비율로 자동 분배
 * - 숫자(px) : 고정 크기
 */

/*
 * TextBlock
 * 텍스트를 화면에 출력해주는 WPF에서 가장 기본적인 텍스트 표시용 Control
 * - 화면 읽기 전용 텍스트를 표시할 때 사용
 * - 사용자 직접 입력 X (입력은 TextBox)
 */

/*
 * GroupBox
 * 여러 개의 UI 요소를 한의 그룹으로 묶어주고, 그 그룹에 제목(label)을 붙일 수 있는 컨테이너
 * - 관련된 항목들을 시각적으로 묶어 표현할 때 사용
 */

/*
 * RadioButton
 * 
 * [Attribute]
 * GroupName : 여러 개의 라디오 버튼이 서로 다른 그룹으로 동작하도록 구분하는 속성
 * - 같은 GroupName을 가진 버튼들끼리는 서로 하나만 선택 가능
 * - 다른 GroupName을 부여하면 동시 선택 가능
 * Checked : RadioButton이 선택 될 때 연결되는 이벤트 핸들러
 * IsChecked : 현재 체크 상태를 코드로 확인할 때 사용
 */

/*
 * Slider
 * 사용자가 들래그하거나 클릭해서 숫자 값을 조절 할 수 있도록 해주는 입력 컨트롤
 * 
 * [Attribute]
 * - Minimum : 최소 값 (Default 0)
 * - Maximum : 최대 값 (Default 10)
 * - Value : 현재 값 (Default 0)
 * - Orientation : 방향 설정
 * - TickFrequency : 눈금 간격 설정
 * - IsSnapToTickEnabled : 눈금에 맞춰 조절할지 여부
 * - Ticks : 눈금 위치 설정
 */

/*
 * CheckBox
 * 여러개의 항목을 복수 선택 가능하게 할 때 사용
 * 
 * [Attribute]
 * - IsChecked : 체크 여부를 Boolean Type으로 반환
 * - 
 */
namespace day_21
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // 선택된 RadioButton 확인
            string result = string.Empty;

            if (radioMale.IsChecked == true)
            {
                result = "남성을 선택했습니다.";
            }
            else if (radioFemale.IsChecked == true)
            {
                result = "여성을 선택했습니다.";
            }

            MessageBox.Show(result);
        }

        private void volumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Slider Event
            if (volumeText != null)
            {
                volumeText.Text = $"현재 값 : {volumeSlider.Value}";
            }
        }

        private void checkbox_Checked(object sender, RoutedEventArgs e)
        {
            // 체크된 한목들을 문자열로 조합
            List<string> selectedFruits = new List<string>();
            if (checkboxApple.IsChecked == true)
            {
                selectedFruits.Add("사과");
            }            

            if (checkboxBanana.IsChecked == true)
            {
                selectedFruits.Add("바나나");
            }            

            if (checkboxOrange.IsChecked == true)
            {
                selectedFruits.Add("오렌지");
            }

            textResult.Text = $"{string.Join(",", selectedFruits)}";
        }

        private void checkboxState_Click(object sender, RoutedEventArgs e)
        {
            bool? state = checkboxState.IsChecked;

            if (state == true)
            {
                textState.Text = "Current State : True";
            }
            else if (state == false)
            {
                textState.Text = "Current State : False";
            }
            else
            {
                textState.Text = "Current State : Null";
            }
        }

        /*
        private void radioMale_Checked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("남성을 선택했습니다.");
        }

        private void radioFemale_Checked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("여성을 선택했습니다.");
        }
        */
    }
}