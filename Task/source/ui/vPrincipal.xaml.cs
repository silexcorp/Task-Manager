using System;
using System.Windows;
using System.Windows.Input;
using System.Data;
using System.Data.SQLite;
using System.Threading;

namespace Task.source.ui
{
    /// <summary>
    /// Lógica de interacción para vPrincipal.xaml
    /// </summary>
    public partial class vPrincipal : Window
    {
        private bool was_pressed_finish, was_pressed_delete;

        public vPrincipal()
        {
            InitializeComponent();
            /* Initialize varialbes */
            grid_right.Visibility = Visibility.Hidden;
            grid_left.Visibility = Visibility.Hidden;
            date.Text = DateTime.Now.ToString(Main.datatime_format);
            initialize_variables();

        }


        #region EVENTOS

        private void Arc_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            Main.main.Show();
            this.Hide();
        }

        private void Arc_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            show_right();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                this.DragMove();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            
        }

        private void initialize_variables()
        {
            for (int i = 1; i < 13; i++){a_hora.Items.Add(i);}
            for (int i = 1; i < 13; i++){b_hora.Items.Add(i);}
            for (int i = 0; i < 10; i++){a_minuto.Items.Add("0" + i);}
            for (int i = 10; i < 60; i++){a_minuto.Items.Add(i);}
            for (int i = 0; i < 10; i++){b_minuto.Items.Add("0" + i);}
            for (int i = 10; i < 60; i++){b_minuto.Items.Add(i); }
            a_am.Items.Add("AM"); a_am.Items.Add("PM");
            b_am.Items.Add("AM"); b_am.Items.Add("PM");
        }


        #endregion EVENTOS
        

        private void fill_table()
        {
            try
            {
                Main.conn.Open();
                SQLiteCommand command = Main.conn.CreateCommand();
                //command.CommandText = "SELECT strftime('%Y-%m-%d', task) as date, strftime('%H:%M:%S', ini) as start, strftime('%H:%M:%S', end) as finish, name as activity FROM task";
                command.CommandText = "SELECT id, strftime('%Y-%m-%d', task) as date, strftime('%H:%M', ini) as start, strftime('%H:%M', end) as finish, name as activity FROM task";
                command.CommandType = CommandType.Text;
                SQLiteDataAdapter data = new SQLiteDataAdapter(command);
                DataTable dt = new DataTable("info");
                data.Fill(dt);

                Dispatcher.BeginInvoke(new ThreadStart(() => Main.principal.datagird_task.ItemsSource = dt.DefaultView));
               
                data.Update(dt);
                Main.conn.Close();                

            }
            catch (Exception e)
            {
                Main.notify(20, "Err while fill DB: " + e.Message.ToString());
                Main.conn.Close();
            }
        }             

        private void task_add() {

            if(tarea.Text.Length > 0) {
                string d = Convert.ToDateTime(date.Text).ToString(Main.datatime_format);
                string a = DateTime.ParseExact(a_hora.Text.ToString() + ":" + a_minuto.Text.ToString() + ":00 " + a_am.Text.ToString(), "h:mm:ss tt", System.Globalization.CultureInfo.InvariantCulture).ToString("HH:mm:ss");
                string b = DateTime.ParseExact(b_hora.Text.ToString() + ":" + b_minuto.Text.ToString() + ":00 " + b_am.Text.ToString(), "h:mm:ss tt", System.Globalization.CultureInfo.InvariantCulture).ToString("HH:mm:ss");
                //System.Windows.MessageBox.Show("FINAL: " + d + a + " _ " + b);

                // Creates new sqlite database if it is not found
                using(var conn = new SQLiteConnection(Main.connection)) {
                    // Be sure you already created the Person Table!

                    conn.Open();
                    using(var command = new SQLiteCommand(conn)) {
                        command.CommandType = CommandType.Text;
                        command.CommandText = "INSERT INTO TASK (task, ini, end, name, icon) VALUES(@task, @ini, @end, @name, @icon);";
                        command.Prepare();
                        command.Parameters.AddWithValue("@task", d);
                        command.Parameters.AddWithValue("@ini", a);
                        command.Parameters.AddWithValue("@end", b);
                        command.Parameters.AddWithValue("@name", tarea.Text.ToString());
                        command.Parameters.AddWithValue("@icon", Main.ico_task);
                        try {
                            command.ExecuteNonQuery();
                            Main.notify(20, "Adding: " + tarea.Text.ToString());
                            this.tarea.Text = "";
                        } catch(SQLiteException e) {
                            Main.notify(20, "Err while insert: " + e.Message.ToString());
                            Main.conn.Close();
                        }
                    }

                    //Console.WriteLine("{0} seconds with one transaction.", "ASD");

                    conn.Close();
                }
           }else{
                Main.notify(50, "Please type an activity");
           }
        }
        
        private void btn_add_PreviewMouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            task_add(); 
            fill_table();
        }
        
        
        private void btn_add_img_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Main.icono.Show();
            this.Hide();
        }

        private void btn_llenar_tabla_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            show_left();
        }

        private void show_left()
        {
            fill_table();
            if (grid_left.Visibility == Visibility.Hidden)
            {
                grid_left.Visibility = Visibility.Visible;
            }
            else
            {
                grid_left.Visibility = Visibility.Hidden;
            }
        }

        private void show_right()
        {
            //Info
            if (grid_right.Visibility == Visibility.Hidden)
            {
                grid_right.Visibility = Visibility.Visible;
            }
            else
            {
                grid_right.Visibility = Visibility.Hidden;
            }
        }
        
        private void btn_clean_list_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                SQLiteCommand command = new SQLiteCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "DELETE FROM TASK";
                command.Connection = Main.conn;
                Main.conn.Open();
                command.ExecuteNonQuery();
                Main.conn.Close();
                System.Media.SystemSounds.Hand.Play();
                Main.ico_notify.BalloonTipText = "Cleaning up the activities list";
                Main.ico_notify.ShowBalloonTip(100);
                fill_table();
            }
            catch (Exception el)
            {
                Main.notify(20, "Err to clean... " + el.Message.ToString());
                Main.conn.Close();
            }
        }
        
        private void btn_close_right_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            show_right();
        }

        private void btn_close_leftt_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
             show_left();
        }

        private void btn_link_web_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            System.Diagnostics.Process.Start("https://alexandermateo.com/");
        }

        private void btn_link_web_app_MouseLeftButtonUp(object sender, MouseButtonEventArgs e) {
            System.Diagnostics.Process.Start("https://alexandermateo.com/");
        }


        //

        #region ACTION DATA TABLE

        private void button_data_finished_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            was_pressed_finish = true;
        }

        private void button_data_delete_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {            
            was_pressed_delete = true;
        }

        private void datagird_task_MouseLeftButtonUp(object sender, MouseButtonEventArgs e) {
            //MessageBox.Show("UP");
            System.Windows.Controls.DataGrid date = sender as System.Windows.Controls.DataGrid;
            DataRowView row = date.SelectedItem as DataRowView;
            if(row != null) {

                if(was_pressed_delete) {
                    //MessageBox.Show("DELETE");
                    deleteTaskByID(Convert.ToInt32(row[0]), row[4].ToString());
                } else if(was_pressed_finish) {
                    //MessageBox.Show("FINISH");
                }

                was_pressed_finish = false;
                was_pressed_delete = false;
            }
        }

        private void lbl_url_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            //MessageBox.Show("Down");
            System.Diagnostics.Process.Start("https://alexandermateo.com/");
        }
        
        private async void deleteTaskByID(int id, String task) {
            using(var conn = new SQLiteConnection(Main.connection)) {
                // Be sure you already created the Person Table!

                conn.Open();
                using(var command = new SQLiteCommand(conn)) {
                    command.CommandType = CommandType.Text;
                    command.CommandText = "DELETE FROM task WHERE id = @id;"; command.Prepare();
                    command.Parameters.AddWithValue("@id", id);

                    try {
                        int rowCount = await command.ExecuteNonQueryAsync();
                        Console.WriteLine(String.Format("Number of rows deleted={0}", rowCount));

                        if(rowCount > 0) {
                            Main.notify(20, "Task deleted: " + task);
                            fill_table();
                        } else {
                            System.Windows.MessageBox.Show("Err while delete task");
                        }
                    } catch(SQLiteException e) {
                        Main.notify(20, "Err while delete: " + e.Message.ToString());
                        Main.conn.Close();
                    }
                }

                //Console.WriteLine("{0} seconds with one transaction.", "ASD");

                conn.Close();
            }
        }



        #endregion

    }
}
