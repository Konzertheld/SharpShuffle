using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Collections.ObjectModel;
using System.Windows.Controls.Primitives;
using System.ComponentModel;

namespace SharpShuffle
{
    delegate void FakeDelegate();

    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CollectionView songs;
        GridViewColumnHeader _lastHeaderClicked = null;
        ListSortDirection _lastDirection = ListSortDirection.Ascending;

        Player player;

        List<String> viewColumns;

        public MainWindow()
        {
            InitializeComponent();
            player = new Player();
            player.PositionChanged += new PlayerPositionChangedHandler(player_PositionChanged);
            player.PlaylistEnded += new PlaylistEndedHandler(player_PlaylistEnded);
            List<Song> fake = Startup.ActiveDB.LoadSongs("__VIEW");

            // TODO: Save the columns, their order and their width
            viewColumns = new List<string>(); // will be filled by the menu

            BuildColumnsMenu();
            BuildViewColumns();
            RefreshView();
            RefreshPools();

            lsvPlaylist.ItemsSource = player.Playlist;

            ((GridView)(lsvPlaylist.View)).Columns.Add(new GridViewColumn());
            ((GridView)(lsvPlaylist.View)).Columns.Add(new GridViewColumn());
            ((GridView)(lsvPlaylist.View)).Columns[0].DisplayMemberBinding = new Binding("Artists");
            ((GridView)(lsvPlaylist.View)).Columns[1].DisplayMemberBinding = new Binding("Title");
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            bf.Serialize(new System.IO.FileStream("c:\\cols.dat", System.IO.FileMode.Create), viewColumns);
        }

        private void RefreshPools()
        {
            lsvFilterPool.ItemsSource = Startup.ActiveDB.PoolList(false);
        }

        private void RefreshView()
        {
            songs = new ListCollectionView(Startup.ActiveDB.LoadSongs("__VIEW"));
            songs.SortDescriptions.Add(new System.ComponentModel.SortDescription("Artists", System.ComponentModel.ListSortDirection.Ascending));
            lstView.ItemsSource = songs;
        }

        #region Player event handlers
        void player_PlaylistEnded()
        {
            MessageBox.Show("Playlist ended");
        }

        void player_PositionChanged(double position)
        {
            prgPosition.Dispatcher.Invoke(new FakeDelegate(delegate
            {
                prgPosition.Value = 100 - position * 100;
            }));
        }
        #endregion

        #region View column control
        void BuildColumnsMenu()
        {
            foreach (string col in Song.Attributes)
            {
                MenuItem item = new MenuItem();
                item.Tag = col;
                item.Header = col;
                item.Click += new RoutedEventHandler(dgrViewColumn_Click);
                item.Checked += new RoutedEventHandler(dgrViewColumn_Checked);
                item.Unchecked += new RoutedEventHandler(dgrViewColumn_Unchecked);
                item.IsChecked = true;
                menSpalten.Items.Add(item);
            }
        }

        void BuildViewColumns()
        {
            ((GridView)lstView.View).Columns.Clear();
            foreach (string col in viewColumns)
            {
                GridViewColumn c = new GridViewColumn();
                c.Header = col;
                c.DisplayMemberBinding = new Binding(col);
                ((GridView)lstView.View).Columns.Add(c);
            }
        }

        void dgrViewColumn_Unchecked(object sender, RoutedEventArgs e)
        {
            MenuItem item = sender as MenuItem;
            viewColumns.Remove(item.Tag as string);
            BuildViewColumns();
        }

        void dgrViewColumn_Checked(object sender, RoutedEventArgs e)
        {
            MenuItem item = sender as MenuItem;
            viewColumns.Add(item.Tag as string);
            BuildViewColumns();
        }

        void dgrViewColumn_Click(object sender, RoutedEventArgs e)
        {
            MenuItem item = sender as MenuItem;
            item.IsChecked = !item.IsChecked;
        }

        void GridViewColumnHeaderClickedHandler(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader headerClicked = e.OriginalSource as GridViewColumnHeader;
            ListSortDirection direction;

            if (headerClicked != null)
            {
                if (headerClicked.Role != GridViewColumnHeaderRole.Padding)
                {
                    if (headerClicked != _lastHeaderClicked)
                    {
                        direction = ListSortDirection.Ascending;
                    }
                    else
                    {
                        if (_lastDirection == ListSortDirection.Ascending)
                        {
                            direction = ListSortDirection.Descending;
                        }
                        else
                        {
                            direction = ListSortDirection.Ascending;
                        }
                    }

                    string header = headerClicked.Column.Header as string;
                    songs.SortDescriptions.Clear();
                    songs.SortDescriptions.Add(new SortDescription(header, direction));
                    lstView.ItemsSource = songs;

                    if (direction == ListSortDirection.Ascending)
                    {
                        headerClicked.Column.HeaderTemplate =
                          Resources["HeaderTemplateArrowUp"] as DataTemplate;
                    }
                    else
                    {
                        headerClicked.Column.HeaderTemplate =
                          Resources["HeaderTemplateArrowDown"] as DataTemplate;
                    }

                    // Remove arrow from previously sorted header
                    if (_lastHeaderClicked != null && _lastHeaderClicked != headerClicked)
                    {
                        _lastHeaderClicked.Column.HeaderTemplate = null;
                    }


                    _lastHeaderClicked = headerClicked;
                    _lastDirection = direction;
                }
            }
        }
        #endregion

        #region Filter
        private void lsvFilterPool_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Songpool view = new Songpool("__VIEW");
            view.Clear();
            foreach (string pool in lsvFilterPool.SelectedItems)
            {
                view.AddSongs(pool);
            }
            RefreshView();
        }
        #endregion

        #region Menu Handlers
        private void menShowHistory_Click(object sender, RoutedEventArgs e)
        {
            lsvFilterPool.SelectedItems.Clear();
            songs = new ListCollectionView(player.PlayedHistory);
        }

        private void ScanFolder_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog fbd = new System.Windows.Forms.FolderBrowserDialog();
            fbd.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
            fbd.ShowDialog();
            wAddPool pool = new wAddPool();
            pool.txtPath.Text = fbd.SelectedPath;
            pool.ShowDialog();
            RefreshPools();
        }

        private void CleanUpFiles_Click(object sender, RoutedEventArgs e)
        {
            Startup.ActiveDB.CleanAudiofiles();
        }
        #endregion

        private void lstView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                SelectSong();
        }

        private void lstView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SelectSong();
        }

        private void SelectSong()
        {
            // Determine what to do with the selected song depending on what special keys are pressed
            PlayActions action = Config.GetPlayAction(ModifierKeys.None);
            if ((Keyboard.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift)
                action = Config.GetPlayAction(ModifierKeys.Shift);
            else if ((Keyboard.Modifiers & ModifierKeys.Alt) == ModifierKeys.Alt)
                action = Config.GetPlayAction(ModifierKeys.Alt);
            else if ((Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
                action = Config.GetPlayAction(ModifierKeys.Control);

            // Do it
            if (action == PlayActions.AddAndPlayNow)
            {
                player.Queue.Insert(0, lstView.SelectedItem as Song);
                player.Playlist.Add(lstView.SelectedItem as Song);
                player.NextSong(); // Is this always correct?
            }
            else if (action == PlayActions.AddAndPlayNext)
            {
                player.Queue.Insert(0, lstView.SelectedItem as Song);
                player.Playlist.Add(lstView.SelectedItem as Song);
            }
            else if (action == PlayActions.Add)
            {
                player.Playlist.Add(lstView.SelectedItem as Song);
                player.PlayPlaylist();
            }
            else if (action == PlayActions.PlayNowUseView)
            {
            }
            else if (action == PlayActions.PlayNowReplacePlaylist)
            {
            }
            if (player.PlaybackState != TP_PLAYBACKSTATE.Playing) player.PlayPause();
        }
    }
}
