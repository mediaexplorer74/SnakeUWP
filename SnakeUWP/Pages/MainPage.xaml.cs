﻿using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Mvvm.Services.Sound;
using SnakeUWP.Core.Models;
using SnakeUWP.Core.ViewModels;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409


namespace SnakeUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private static bool _loadedMusic;
        public MainPage()
        {
            this.InitializeComponent();
            this.Loaded += MainPage_Loaded;
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (!_loadedMusic)
            {
                _loadedMusic = true;
                SoundPlayer.Instance.Initialize();
                PlaySound();
            }
        }

        public async void PlaySound()
        {
            await SoundPlayer.Instance.Play(true);
            SoundPlayer.Instance.IsBackgroundMuted = Singleton.Instance.MusicPlayed;
        }
    }
}
