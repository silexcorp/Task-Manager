using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;
namespace Task.source.ui
{
    /// <summary>
    /// Lógica de interacción para vNotificacion.xaml
    /// </summary>
    public partial class vNotificacion : Window
    {
        private Storyboard storyboard;

        public vNotificacion()
        {
            InitializeComponent();
            adjust_screen();
            try
            {
                storyboard = (Storyboard)(this.FindResource("ani_background"));
            }
            catch (Exception e)
            {
                Main.notify(80, "ERR: StoryBoard,  " + e.Message);
            }
        }

        private void adjust_screen()
        {
            /* 
             * Resize window */
            this.Left = 0;
            double alto = Main.alto / 2;
            this.Top = alto;
            this.Width = Main.ancho;
            this.Height = Main.alto / 1.5;
        }

        public void show_window()
        {
            this.Show();
            storyboard.Begin();
            this.WindowState = WindowState.Normal;
            this.Visibility = Visibility.Visible;
            Main.informar.show_window();
        }
        public void hide_window()
        {
            this.Hide();
            this.Visibility = Visibility.Hidden;
            this.WindowState = WindowState.Minimized;
            Main.informar.hide_window();
        }
        
        private void window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            hide_window();
        }

        private void window_MouseLeave(object sender, MouseEventArgs e)
        {
            //MessageBox.Show("Foco mouse leave");
        }
    }
}
