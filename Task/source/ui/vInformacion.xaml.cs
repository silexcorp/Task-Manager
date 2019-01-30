using System;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media.Animation;

namespace Task.source.ui
{
    /// <summary>
    /// Lógica de interacción para vInformacion.xaml
    /// </summary>
    public partial class vInformacion : Window
    {
        /* Declare global variables */
        private TimeSpan now;
        private System.Windows.Forms.Timer timer;
        private bool estado = false;
        private Storyboard storyboard;

        public vInformacion()
        {
            InitializeComponent();
            adjust_screen();            
            try
            {
                storyboard = (Storyboard)(this.FindResource("ani_information"));
            }
            catch (Exception e)
            {
                Main.notify(80, "ERR: StoryBoard,  " + e.Message);
            }

            timer = new Timer();
            now = TimeSpan.FromSeconds(220); 
            timer.Tick += Timer_Tick;
            timer.Interval = 900;
        }

        public void show_window()
        {
            this.Show();
            storyboard.Begin();
            this.WindowState = WindowState.Normal;
            this.Visibility = Visibility.Visible;
            iniciar_animacion();
        }
        public void hide_window()
        {
            this.Hide();
            this.Visibility = Visibility.Hidden;
            this.WindowState = WindowState.Minimized;
            terminar_animacion();
        }
        private void adjust_screen()
        {
            /* 
             * Resize window */
            double alto = Main.alto / 2;
            this.Width = Main.ancho / 2 + 20;
            this.Height = Main.alto / 4 + 20;
            this.Left = Main.ancho/2 - this.Width/2;
            this.Top = alto + this.Height/1.4;
        }

        public void terminar_animacion()
        {
            timer.Stop();
        }

        public void iniciar_animacion()
        {
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (sender == timer)
            {
                if (now.TotalMinutes > 0)
                {
                    now = now.Subtract(TimeSpan.FromSeconds(1));
                    if(estado == true)
                    {
                        /*ImageBrush myBrush = new ImageBrush();
                        myBrush.ImageSource = new BitmapImage(new Uri(@"source/ico/logo.png", UriKind.Relative));
                        ico.Background = myBrush;*/
                        ico.Visibility = Visibility.Hidden;
                        estado = false;
                    }
                    else
                    {
                        ico.Visibility = Visibility.Visible;
                        estado = true;
                    }
                }
                else
                {
                    hide_window();
                }
            }
        }

        private void window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            Main.notificar.hide_window();
        }
    }
}
