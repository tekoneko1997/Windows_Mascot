using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace マスコット_練習_0223
{
    /// <summary>
    /// serihuWindow.xaml の相互作用ロジック
    /// </summary>
    /// 



    public partial class serihuWindow : Window
    {

        public serihuWindow()
        {

            //ディスプレイの高さ
            int h = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
            //ディスプレイの幅
            int w = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;

            //フォームの位置と大きさを表示する
            //   Console.WriteLine("フォームX座標 = {0}", this.Left);
            // Console.WriteLine("フォームY座標 = {0}", this.Top);
            //Console.WriteLine("フォームの横幅 = {0}", this.Width);
            //Console.WriteLine("フォームの高さ = {0}", this.Height);

            //フォームを一番左端に寄せる
            this.Left = w-930;
            //フォームを10ピクセル下に移動させる.
            this.Top = h-650;
            //フォームの横幅を400ピクセルにする
           // this.Width = 400;
            //フォームの高さを50ピクセル小さくする
           // this.Height -= 50;

            InitializeComponent();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += OnTimerTick;
            timer.Start();
        }


        void OnTimerTick(object sender, object e)
        {
            txtblk.Text = DateTime.Now.ToString("h:mm:ss tt");

            
        }


        //セリフを表示する
        public void DisplayMessage(string message)
        {

           // serihu.Foreground = new SolidColorBrush(Colors.Red );
            Dispatcher.Invoke(() => this.serihu.Text = message);
        }

        //セリフを消去する
        public void clearMessage()
        {
            DisplayMessage(string.Empty);
        }

        protected override void OnMouseDoubleClick(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var win = new Window1();
            win.Show();
        }
    }
}
