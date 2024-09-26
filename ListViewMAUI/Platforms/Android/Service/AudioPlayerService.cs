using Android.Content.Res;
using Android.Media;
using System.Reflection;
using Stream = Android.Media.Stream;

namespace ListViewMAUI.Service
{
    public partial class AudioPlayerService : IAudioPlayerService
    {
        #region Fields

        private MediaPlayer mediaPlayer;
        private int currentPositionLength = 0;
        private bool isPrepared;
        private bool isCompleted;
        AssetFileDescriptor fd;

        #endregion

        #region Methods
        public async void PlayAudio(string filePath)
        {
            if (mediaPlayer != null && !mediaPlayer.IsPlaying)
            {
                mediaPlayer.SeekTo(currentPositionLength);
                currentPositionLength = 0;
                mediaPlayer.Start();
            }

            else if (mediaPlayer == null || !mediaPlayer.IsPlaying)
            {
                try
                {
                    isCompleted = false;
                    mediaPlayer = new MediaPlayer();                                  
                    System.IO.Stream fileStream = GetStreamFromFile(filePath);

                    var tempFile = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "tempAudio.mp3");
                    using (var file = System.IO.File.Create(tempFile))
                    {
                        fileStream.CopyTo(file);
                    }   

                     mediaPlayer.SetDataSource(tempFile);

                    mediaPlayer.Prepare();                    
                    mediaPlayer.Prepared += (sender, args) =>
                    {
                        isPrepared = true;
                        mediaPlayer.Start();
                    };
                    mediaPlayer.Completion += (sender, args) =>
                    {
                        isCompleted = true;
                    };
                }
                catch (Exception e)
                {
                    mediaPlayer = null;
                }
            }
        }
        public static System.IO.Stream GetStreamFromFile(string filename)
        {
            Assembly assembly = AppDomain.CurrentDomain.GetAssemblies()
                            .SelectMany(s => s.DefinedTypes
                            .Where(t => t.Name == "App"
                                        && t.BaseType.Equals(typeof(Microsoft.Maui.Controls.Application))
                                )
                            ).FirstOrDefault()?.Assembly
                            ?? throw new Exception("Unable to find the Maui App type. This is required to load embedded resources.");

            // Useful for finding the resource names
            string[] aNames = assembly.GetManifestResourceNames();
            var stream = assembly.GetManifestResourceStream(aNames[0]);
            return stream;
        }

        public void Pause()
        {
            if (mediaPlayer != null && mediaPlayer.IsPlaying)
            {
                mediaPlayer.Pause();
                currentPositionLength = mediaPlayer.CurrentPosition;
            }
        }
        public void Stop()
        {
            if (mediaPlayer != null)
            {
                if (isPrepared)
                {
                    mediaPlayer.Stop();
                    mediaPlayer.Release();
                    isPrepared = false;
                }
                isCompleted = false;
                mediaPlayer = null;
            }
        }
        public string GetCurrentPlayTime()
        {
            if (mediaPlayer != null)
            {
                var positionTimeSeconds = double.Parse(mediaPlayer.CurrentPosition.ToString());
                positionTimeSeconds = positionTimeSeconds / 1000;
                TimeSpan currentTime = TimeSpan.FromSeconds(positionTimeSeconds);
                string currentPlayTime = string.Format("{0:mm\\:ss}", currentTime);
                return currentPlayTime;
            }
            return null;
        }
        public bool CheckFinishedPlayingAudio()
        {
            return isCompleted;
        }
        
        #endregion
    }
}
