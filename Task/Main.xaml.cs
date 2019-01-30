using System;
using System.Windows;
using System.Windows.Input;
using Task.Properties;

/* KEY EVENTS */
using System.Windows.Forms;
using Task.source.ui;
using System.Windows.Threading;
using System.Globalization;
using System.Data.SQLite;

namespace Task {
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class Main: Window {

        /* Inicializar variables globales */
        public static vNotificacion notificar;
        public static vInformacion informar;
        public static vPrincipal principal;
        public static Iconos icono;
        public static Window main;

        public static double ancho, alto;
        public bool mover_ventana = false, window_state = false;
        public static string ico_task = @"source/img/11.png";

        /* Var para hacer girar PIE animacion */
        private static UInt16 gear = 0, gear_outside = 360;
        public bool animation_state;

        /* Menu en notificaciones */
        public static NotifyIcon ico_notify;
        private ContextMenuStrip menu;

        /* Animacion */
        private DispatcherTimer animate;
        private DispatcherTimer verify;

        /* Conexion DB */
        public static SQLiteConnection conn;
        public static string datatime_format = "yyyy-MM-dd";
        private DateTime now;
        private string current_time;

        public static string DOCUM = System.IO.Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents") + @"\TaskManager";
        //public static string DEST = System.IO.Path.GetTempPath() + @"\db.db";
        public static string DEST = DOCUM + @"\db.db";
        public static string CURRENT = Environment.CurrentDirectory + @"\source\db\db.db";
        public static string connection = @"Data Source=" + DEST + ";";

        public Main() {
            InitializeComponent();
            loading_screen();
            cargar_menu_contextual();
            //System.Windows.MessageBox.Show(Convert.ToDateTime(DateTime.Now).ToString(Main.datatime_format).ToString());
            //System.Windows.MessageBox.Show(DateTime.ParseExact("1:52:16 PM", "h:mm:ss tt", CultureInfo.InvariantCulture).ToString("HH:mm:ss"));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            /* 
             * Start timer animation */
            animate = new DispatcherTimer();
            animate.Tick += new EventHandler(animate_Tick);
            animate.Interval = TimeSpan.FromMilliseconds(45);  // the small time step
            animation_state = Settings.Default.ani;
            start_animation();
            /* 
             * Initialize global variavles */
            notificar = new vNotificacion();
            informar = new vInformacion();
            principal = new vPrincipal();
            icono = new Iconos();
            main = Window.GetWindow(this);

            /* 
             * Initialize a SQL Connection */
            conn = new SQLiteConnection(connection);
            /* 
            * Initialize timer VERIFY */
            verify = new DispatcherTimer();
            verify.Tick += new EventHandler(verify_Tick);
            verify.Interval = new TimeSpan(0, 0, 1);
            verify.Start();
            ico_notify.ShowBalloonTip(50);


            this.Topmost = Settings.Default.top;

            try {
                //System.Windows.MessageBox.Show(DEST);
                //System.Windows.MessageBox.Show(CURRENT);
                if(!System.IO.Directory.Exists(DOCUM)) {
                    System.IO.Directory.CreateDirectory(DOCUM);
                }
                if(!System.IO.File.Exists(DEST)) {
                    System.IO.File.Copy(CURRENT, DEST);
                }
            } catch(Exception err) {
                Console.WriteLine(err.ToString());
            }
        }

        private void verify_Tick(object sender, EventArgs e) {
            now = DateTime.Now;
            current_time = now.ToString("H:mm:ss", new CultureInfo("en-US"));
            verify_state();
        }

        private void verify_state() {
            using(SQLiteConnection connect = new SQLiteConnection(connection)) {
                string query = "SELECT strftime('%Y-%m-%d', task) as date, strftime('%H:%M:%S', ini) as ini, strftime('%H:%M:%S', end) as end, name, icon FROM TASK WHERE task = @task";
                SQLiteCommand sql_cmd = new SQLiteCommand(query, connect);
                sql_cmd.Parameters.AddWithValue("@task", DateTime.Now.ToString(datatime_format));
                try {
                    connect.Open();
                    DateTime dateValue = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);
                    using(SQLiteDataReader reader = sql_cmd.ExecuteReader()) {
                        while(reader.Read()) {
                            //System.Windows.MessageBox.Show("Buscando: " + reader["ini"].ToString() +" = " + current_time);
                            if(current_time == reader["ini"].ToString() || current_time == reader["end"].ToString()) {
                                informar.date.Content = dateValue.ToString("D");
                                informar.title.Content = reader["name"].ToString();
                                informar.time.Content = reader["ini"].ToString() + " - " + reader["end"].ToString();
                                System.Windows.Media.ImageBrush my_brush = new System.Windows.Media.ImageBrush();
                                my_brush.ImageSource = new System.Windows.Media.Imaging.BitmapImage(new Uri(@reader["icon"].ToString(), UriKind.Relative));
                                informar.ico.Background = my_brush;
                                notificar.show_window();
                            }
                        }
                        connect.Close();
                    }
                } catch(Exception err) {
                    Main.notify(20, "Err while open DB: " + err.ToString());
                    verify.Stop();
                }
            }
        }

        #region GENERIC

        private void cargar_menu_contextual() {
            menu = new ContextMenuStrip();
            ico_notify = new NotifyIcon();
            ico_notify.BalloonTipText = "Loading App";
            ico_notify.BalloonTipTitle = "Task Manager";
            ico_notify.Text = "Task Manager - silexcorp";
            ico_notify.Tag = "Alexander Mateo";
            ico_notify.Icon = new System.Drawing.Icon(@"source/ico/icon.ico");
            ico_notify.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            ico_notify.Click += ico_notify_Click;
            ico_notify.DoubleClick += Ico_notify_DoubleClick;

            ToolStripMenuItem web = new ToolStripMenuItem();
            web.Text = "About us";                              // Add one right click menu item 
            web.Click += web_Click;                             // Add the clickevent of Help item
            menu.Items.Add(web);                                // Add the item in right click menu

            ToolStripMenuItem info = new ToolStripMenuItem();
            info.Text = "Topmost";
            info.Click += info_Click;
            menu.Items.Add(info);

            ToolStripMenuItem any = new ToolStripMenuItem();
            any.Text = "Animation";
            any.Click += any_Click;
            menu.Items.Add(any);

            ToolStripMenuItem tas = new ToolStripMenuItem();
            tas.Text = "Add task";
            tas.Click += tas_Click;
            menu.Items.Add(tas);

            ToolStripMenuItem salir = new ToolStripMenuItem();
            salir.Text = "Close";
            salir.Click += exit_Click;
            menu.Items.Add(salir);

            ico_notify.ContextMenuStrip = menu;
            ico_notify.Visible = true;
        }

        private void Ico_notify_DoubleClick(object sender, EventArgs e) {
            if(window_state == false) {
                window_state = true;
                ico_notify.BalloonTipText = "Hiding window";
                ico_notify.ShowBalloonTip(100);
                this.Hide();
            } else {
                window_state = false;
                ico_notify.BalloonTipText = "Restoring window";
                ico_notify.ShowBalloonTip(100);
                this.Show();
            }
        }

        private void loading_screen() {
            Main.ancho = System.Windows.SystemParameters.PrimaryScreenWidth;
            Main.alto = System.Windows.SystemParameters.PrimaryScreenHeight;
            Task.Properties.Settings.Default.Save();
        }

        public void start_animation() {
            if(animation_state == true) {
                animate.Start();
            }
        }

        private void animate_Tick(object sender, EventArgs e) {
            /* 
             * Rotate the inside rings  */
            pie.StartAngle = 90 + gear;
            pie.EndAngle = gear + 360;
            gear += 5; if(gear > 360) { gear = 0; }
            /* 
             * Rotate the outside rings  */
            arc_left.StartAngle = gear_outside;
            arc_left.EndAngle = gear_outside + 90;
            arc_right.StartAngle = 180 + gear_outside;
            arc_right.EndAngle = gear_outside + 270;
            gear_outside -= 6; if(gear_outside < 0) { gear_outside = 360; }
        }

        private void restart_app() {
            Task.Properties.Settings.Default.Save();
            System.Windows.Application.Current.Shutdown();
            System.Windows.Forms.Application.Restart();
        }

        private void close_app() {
            /* 
             * Close app */
            Settings.Default.ani = animation_state;
            Settings.Default.Save();
            ico_notify.ContextMenuStrip = null;
            ico_notify.Visible = false;
            App.Current.Shutdown();
        }

        private void info_Click(object sender, EventArgs e) {
            if(Settings.Default.top) {
                Settings.Default.top = false;
            } else {
                Settings.Default.top = true;
            }
            this.Topmost = Settings.Default.top;
            Settings.Default.Save();
        }

        private void web_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start("https://alexandermateo.com/");
        }

        void any_Click(object sender, EventArgs e) {
            System.Media.SystemSounds.Hand.Play();
            if(animation_state == true) {
                animation_state = false;
            } else {
                animation_state = true;
            }
            if(animation_state == false) {
                /* 
                 * Restart the position of inside rings */
                pie.StartAngle = 90;
                pie.EndAngle = 360;
                /* 
                 * Restart the position of outside rings */
                arc_left.StartAngle = 45;
                arc_left.EndAngle = 135;
                arc_right.StartAngle = 225;
                arc_right.EndAngle = 315;
            }
            if(animation_state == true) { animate.Start(); } else { animate.Stop(); }
        }
        void tas_Click(object sender, EventArgs e) {
            principal.Show();
            this.Hide();
        }
        void exit_Click(object sender, EventArgs e) {
            close_app();
        }

        void ico_notify_Click(object sender, EventArgs e) {
            //this.Topmost = true;
        }

        #endregion GENERIC

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            this.DragMove();
        }

        private void Window_MouseRightButtonDown(object sender, MouseButtonEventArgs e) {
            //Main.notificar.show_window();
        }

        private void Window_MouseDoubleClick(object sender, MouseButtonEventArgs e) {
            principal.Show();
            this.Hide();
        }

        public static void notify(int time, string text) {
            System.Media.SystemSounds.Hand.Play();
            ico_notify.BalloonTipText = text;
            ico_notify.BalloonTipTitle = "Task Manager";
            ico_notify.Text = "Task Manager - silexcorp";
            //ico_notify.Icon = new System.Drawing.Icon(@"source/ico/icon.ico");
            ico_notify.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            ico_notify.ShowBalloonTip(time);
        }

    }
}

