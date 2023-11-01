using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ColorChecker {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {

        MyColor selectColor;

        public MainWindow() {
            InitializeComponent();
            DataContext = GetColorList();
        }

        //ComboBoxに入れる色集を取得
        private MyColor[] GetColorList() {
            return typeof(Colors).GetProperties(BindingFlags.Public | BindingFlags.Static)
                .Select(i => new MyColor() { Color = (Color)i.GetValue(null), Name = i.Name }).ToArray();
        }

        private void GetSetColor(MyColor selectColor) {
            var color = selectColor.Color;
            var name = selectColor.Name;
            rValue.Text = color.R.ToString();
            gValue.Text = color.G.ToString();
            bValue.Text = color.B.ToString();
            colorArea.Background = new SolidColorBrush(color);
        }

        //ColorSliderにあわせて、LabelのBackgroundの色を変える
        private void colorSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            colorArea.Background = new SolidColorBrush(
                Color.FromRgb(byte.Parse(rValue.Text), byte.Parse(gValue.Text), byte.Parse(bValue.Text)));
        }

        //ComboBoxとSliderを連携させる

        //Stockボタンが押された時の動作 MyColorインスタンスを作成し、stockListの一番初めに挿入する
        private void stockButton_Click(object sender, RoutedEventArgs e) {
            var colors = GetColorList();
            var color = Color.FromRgb(byte.Parse(rValue.Text), byte.Parse(gValue.Text), byte.Parse(bValue.Text));
            var item = colors.FirstOrDefault(x => Color.Equals(x.Color, color));
            
            MyColor c = new MyColor {
                Color = color,
                Name = item == null ? color.ToString() : item.Name
            };
            stockList.Items.Insert(0, c);
        }

        //stockList(ListBox)から色が選択された時の動作
        private void stockList_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            selectColor = (MyColor)((ListBox)sender).SelectedItem;
            GetSetColor(selectColor);
        }

        //ComboBox(ListBox)から色が選択された時の動作
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            selectColor = (MyColor)((ComboBox)sender).SelectedItem;
            GetSetColor(selectColor);
        }
    }

    //MyColorクラス Color構造体型、付随するColorNameを保存する
    public class MyColor {
        public Color Color { get; set; }
        public string Name { get; set; }

        public override string ToString() {
            if (!Regex.IsMatch(Name, "[0-9]")) {
                return Name;
            }
            return "R:" + Color.R.ToString() + " G:" + Color.G.ToString() + " B:" + Color.B.ToString();
        }
    }
}
