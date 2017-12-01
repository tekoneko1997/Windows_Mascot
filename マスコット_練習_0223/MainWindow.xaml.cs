using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Drawing;




namespace マスコット_練習_0223
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            //ディスプレイの高さ
            int h = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
            //ディスプレイの幅
            int w = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;

            //フォームを一番左端に寄せる
            this.Left = w - 800;
            //フォームを10ピクセル下に移動させる
            this.Top = h - 600;
            //フォームの横幅を400ピクセルにする
            //this.Width = 400;
            //フォームの高さを50ピクセル小さくする
            //this.Height -= 50;


            //フォームのw位置と大きさを表示する
            Console.WriteLine("フォームX座標 = {0}", this.Left);
            Console.WriteLine("フォームY座標 = {0}", this.Top);
            Console.WriteLine("ディスプレイの幅 = {0}",w);
            Console.WriteLine("ディスプレイの高さ = {0}", h);




            InitializeComponent();

            serihuWindow = new serihuWindow();
            serihuWindow.Show();

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(5.0) ;
            timer.Tick += timer_Tick;
            timer.Start();

          
        }
        //  public new WindowStartupLocation WindowStartupLocation { get; set;}
        //WindowStartupLocation="CenterOwner" 



        DispatcherTimer timer;
        serihuWindow serihuWindow;

        int count = 0;
        


        //タイマーを使った時間によるコメント

        void timer_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;

           
            count++;
            if (count == 1)
            {
                yukari.Source = new BitmapImage(new Uri("MtU_yukari_ver3.0/004笑顔1.png", UriKind.RelativeOrAbsolute));
                if (dt.Hour >= 6 && dt.Hour < 10)
                {
                    serihuWindow.DisplayMessage("おはようございます");
                }
                else if (dt.Hour >= 10 && dt.Hour < 18)
                {
                    serihuWindow.DisplayMessage("こんにちは");
                }else
                {
                    serihuWindow.DisplayMessage("こんばんは");
                }
            }
            /*
            else if(count== 3)
            {
               
                serihuWindow.DisplayMessage("げんききんもー");
                 yukari.Source = new BitmapImage(new Uri("MtU_yukari_ver3.0/020あはははは.png", UriKind.RelativeOrAbsolute));
            }else if(count == 60)
            {
                count = 1;
                serihuWindow.DisplayMessage("五分もむしとは。。。これいかに");
                yukari.Source = new BitmapImage(new Uri("MtU_yukari_ver3.0/018必死.png", UriKind.RelativeOrAbsolute));
            }
            */
            else
            {
                //待機中の状態
                serihuWindow.DisplayMessage("");
                yukari.Source = new BitmapImage(new Uri("MtU_yukari_ver3.0/001通常1.png", UriKind.RelativeOrAbsolute));
            }
            

        }

        //メインウインドウを閉じるとセリフウインドウも閉じる
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            if (serihuWindow != null)
            {
                serihuWindow.Close();
            }
        }
            
        //閉じる
        private void Quit_Clicked(object seder, RoutedEventArgs e)
        {
            Close();
        }

        //ウインドウの移動
        protected override void OnMouseDoubleClick(MouseButtonEventArgs e)
        {
          base.OnMouseLeftButtonDown(e);
          DragMove();
        }


        
        

        


    }



}
