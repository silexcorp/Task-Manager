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

namespace Task.source.ui
{
    /// <summary>
    /// Lógica de interacción para Iconos.xaml
    /// </summary>
    public partial class Iconos : Window
    {
        //https://brsev.deviantart.com/art/Token-128429570
        public Iconos()
        {
            InitializeComponent();
        }

        private void Arc_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            Main.principal.Show();
            this.Hide();
        }

        private void asignar_var(string img)
        {
            ImageBrush myBrush = new ImageBrush();
            myBrush.ImageSource = new BitmapImage(new Uri(img, UriKind.Relative));
            Main.principal.ico_btn.Background = myBrush;
            Main.principal.ico_btn.Visibility = Visibility.Visible;
            Main.principal.ico_btn.UpdateLayout();
            Main.principal.Show();
            this.Hide();
        }

        #region ANIMATION


        //#0
        private void ico__MouseLeave(object sender, MouseEventArgs e)
        {
            ico_.Opacity = 0.2;
        }
        
        private void ico__MouseEnter(object sender, MouseEventArgs e)
        {
            ico_.Opacity = 0.5;
        }
        //#1
        private void ico_1_MouseEnter(object sender, MouseEventArgs e)
        {
            ico_1.Opacity = 0.5;
        }
        private void ico_1_MouseLeave(object sender, MouseEventArgs e)
        {
            ico_1.Opacity = 0.2;
        }
        //#2
        private void ico_2_MouseEnter(object sender, MouseEventArgs e)
        {
            ico_2.Opacity = 0.5;
        }

        private void ico_2_MouseLeave(object sender, MouseEventArgs e)
        {
            ico_2.Opacity = 0.1;
        }

        //#3
        private void ico_3_MouseEnter(object sender, MouseEventArgs e)
        {
            ico_3.Opacity = 0.5;
        }

        private void ico_3_MouseLeave(object sender, MouseEventArgs e)
        {
            ico_3.Opacity = 0.2;
        }

        private void ico_4_MouseEnter(object sender, MouseEventArgs e)
        {
            ico_4.Opacity = 0.5;
        }

        private void ico_4_MouseLeave(object sender, MouseEventArgs e)
        {
            ico_4.Opacity = 0.2;
        }

        private void ico_5_MouseEnter(object sender, MouseEventArgs e)
        {
            ico_5.Opacity = 0.5;
        }

        private void ico_5_MouseLeave(object sender, MouseEventArgs e)
        {
            ico_5.Opacity = 0.2;
        }

        private void ico_6_MouseEnter(object sender, MouseEventArgs e)
        {
            ico_6.Opacity = 0.5;
        }

        private void ico_6_MouseLeave(object sender, MouseEventArgs e)
        {
            ico_6.Opacity = 0.2;
        }

        private void ico_7_MouseEnter(object sender, MouseEventArgs e)
        {
            ico_7.Opacity = 0.5;
        }

        private void ico_7_MouseLeave(object sender, MouseEventArgs e)
        {
            ico_7.Opacity = 0.2;
        }

        private void ico_8_MouseEnter(object sender, MouseEventArgs e)
        {
            ico_8.Opacity = 0.5;
        }

        private void ico_8_MouseLeave(object sender, MouseEventArgs e)
        {
            ico_8.Opacity = 0.2;
        }

        private void ico_9_MouseEnter(object sender, MouseEventArgs e)
        {
            ico_9.Opacity = 0.5;
        }

        private void ico_9_MouseLeave(object sender, MouseEventArgs e)
        {
            ico_9.Opacity = 0.2;
        }

        private void ico_10_MouseEnter(object sender, MouseEventArgs e)
        {
            ico_10.Opacity = 0.5;
        }

        private void ico_10_MouseLeave(object sender, MouseEventArgs e)
        {
            ico_10.Opacity = 0.2;
        }
        private void ico_11_MouseEnter(object sender, MouseEventArgs e)
        {
            ico_11.Opacity = 0.5;
        }

        private void ico_11_MouseLeave(object sender, MouseEventArgs e)
        {
            ico_11.Opacity = 0.2;
        }

        private void ico_12_MouseEnter(object sender, MouseEventArgs e)
        {
            ico_12.Opacity = 0.5;
        }

        private void ico_12_MouseLeave(object sender, MouseEventArgs e)
        {
            ico_12.Opacity = 0.2;
        }

        private void ico_13_MouseEnter(object sender, MouseEventArgs e)
        {
            ico_13.Opacity = 0.5;
        }

        private void ico_13_MouseLeave(object sender, MouseEventArgs e)
        {
            ico_13.Opacity = 0.2;
        }

        private void ico_14_MouseEnter(object sender, MouseEventArgs e)
        {
            ico_14.Opacity = 0.5;
        }

        private void ico_14_MouseLeave(object sender, MouseEventArgs e)
        {
            ico_14.Opacity = 0.2;
        }

        private void ico_15_MouseEnter(object sender, MouseEventArgs e)
        {
            ico_15.Opacity = 0.5;
        }

        private void ico_15_MouseLeave(object sender, MouseEventArgs e)
        {
            ico_15.Opacity = 0.2;
        }

        private void ico_16_MouseEnter(object sender, MouseEventArgs e)
        {
            ico_16.Opacity = 0.5;
        }

        private void ico_16_MouseLeave(object sender, MouseEventArgs e)
        {
            ico_16.Opacity = 0.2;
        }

        private void ico_17_MouseEnter(object sender, MouseEventArgs e)
        {
            ico_17.Opacity = 0.5;
        }

        private void ico_17_MouseLeave(object sender, MouseEventArgs e)
        {
            ico_17.Opacity = 0.2;
        }

        private void ico_18_MouseEnter(object sender, MouseEventArgs e)
        {
            ico_18.Opacity = 0.5;
        }

        private void ico_18_MouseLeave(object sender, MouseEventArgs e)
        {
            ico_18.Opacity = 0.2;
        }

        private void ico_19_MouseEnter(object sender, MouseEventArgs e)
        {
            ico_19.Opacity = 0.5;
        }

        private void ico_19_MouseLeave(object sender, MouseEventArgs e)
        {
            ico_19.Opacity = 0.2;
        }

        private void ico_20_MouseEnter(object sender, MouseEventArgs e)
        {
            ico_20.Opacity = 0.5;
        }

        private void ico_20_MouseLeave(object sender, MouseEventArgs e)
        {
            ico_20.Opacity = 0.2;
        }

        private void ico_21_MouseEnter(object sender, MouseEventArgs e)
        {
            ico_21.Opacity = 0.5;
        }

        private void ico_21_MouseLeave(object sender, MouseEventArgs e)
        {
            ico_21.Opacity = 0.2;
        }

        private void ico_22_MouseEnter(object sender, MouseEventArgs e)
        {
            ico_22.Opacity = 0.5;
        }

        private void ico_22_MouseLeave(object sender, MouseEventArgs e)
        {
            ico_22.Opacity = 0.2;
        }

        private void ico_23_MouseEnter(object sender, MouseEventArgs e)
        {
            ico_23.Opacity = 0.5;
        }

        private void ico_23_MouseLeave(object sender, MouseEventArgs e)
        {
            ico_23.Opacity = 0.2;
        }

        private void ico_24_MouseEnter(object sender, MouseEventArgs e)
        {
            ico_24.Opacity = 0.5;
        }

        private void ico_24_MouseLeave(object sender, MouseEventArgs e)
        {
            ico_24.Opacity = 0.2;
        }

        #endregion ANIMA

        private void ico__MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Main.ico_task = @"source/img/1.png"; 
            asignar_var(Main.ico_task);
        }

        private void ico_1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Main.ico_task = @"source/img/2.png";
            asignar_var(Main.ico_task);
        }

        private void ico_2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Main.ico_task = @"source/img/3.png";
            asignar_var(Main.ico_task);
        }

        private void ico_3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Main.ico_task = @"source/img/4.png";
            asignar_var(Main.ico_task);
        }

        private void ico_4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Main.ico_task = @"source/img/5.png";
            asignar_var(Main.ico_task);
        }

        private void ico_5_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Main.ico_task = @"source/img/6.png";
            asignar_var(Main.ico_task);
        }

        private void ico_6_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Main.ico_task = @"source/img/7.png";
            asignar_var(Main.ico_task);
        }

        private void ico_7_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Main.ico_task = @"source/img/8.png";
            asignar_var(Main.ico_task);
        }

        private void ico_8_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Main.ico_task = @"source/img/9.png";
            asignar_var(Main.ico_task);
        }

        private void ico_9_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Main.ico_task = @"source/img/10.png";
            asignar_var(Main.ico_task);
        }

        private void ico_10_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Main.ico_task = @"source/img/11.png";
            asignar_var(Main.ico_task);
        }

        private void ico_11_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Main.ico_task = @"source/img/12.png";
            asignar_var(Main.ico_task);
        }

        private void ico_12_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Main.ico_task = @"source/img/13.png";
            asignar_var(Main.ico_task);
        }

        private void ico_13_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Main.ico_task = @"source/img/14.png";
            asignar_var(Main.ico_task);
        }

        private void ico_14_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Main.ico_task = @"source/img/15.png";
            asignar_var(Main.ico_task);
        }

        private void ico_15_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Main.ico_task = @"source/img/16.png";
            asignar_var(Main.ico_task);
        }

        private void ico_16_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Main.ico_task = @"source/img/17.png";
            asignar_var(Main.ico_task);
        }

        private void ico_17_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Main.ico_task = @"source/img/18.png";
            asignar_var(Main.ico_task);
        }

        private void ico_18_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Main.ico_task = @"source/img/19.png";
            asignar_var(Main.ico_task);
        }

        private void ico_19_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Main.ico_task = @"source/img/20.png";
            asignar_var(Main.ico_task);
        }

        private void ico_20_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Main.ico_task = @"source/img/21.png";
            asignar_var(Main.ico_task);
        }

        private void ico_21_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Main.ico_task = @"source/img/22.png";
            asignar_var(Main.ico_task);
        }

        private void ico_22_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Main.ico_task = @"source/img/23.png";
            asignar_var(Main.ico_task);
        }

        private void ico_23_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Main.ico_task = @"source/img/24.png";
            asignar_var(Main.ico_task);
        }

        private void ico_24_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Main.ico_task = @"source/img/25.png";
            asignar_var(Main.ico_task);
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
