using AVFoundation;
using Foundation;

namespace ListViewMAUI.Service
{
    public partial class AudioPlayerService : IAudioPlayerService
    {
        #region Fields
        AVPlayer player;
        NSObject notificationHandle;
        NSUrl url;
        private bool isFinishedPlaying;
        private bool isPlaying;
        #endregion

        #region Properties
        public bool IsPlaying
        {
            get { return isPlaying; }
            set
            {
                if (player.Rate == 1 && player.Error == null)
                    isPlaying = true;
                else
                    isPlaying = false;
            }
        }
        #endregion

        #region Constructor
        public AudioPlayerService()
        {
            RegisterNotification();
        }
        #endregion

        #region Destrcutor
        ~AudioPlayerService()
        {
            UnregisterNotification();
        }
        #endregion

        #region Methods

        /// <summary>
        /// This method is used to play the recorder audio.
        /// </summary>
        public void PlayAudio(string filePath)
        {
            isFinishedPlaying = false;
            if (player == null)
            {
                AVAsset asset = AVAsset.FromUrl(NSUrl.CreateFileUrl(new[] { filePath }));
                AVPlayerItem avPlayerItem = new AVPlayerItem(asset);
                player = new AVPlayer(avPlayerItem);
                player.AutomaticallyWaitsToMinimizeStalling = false;
                player.Volume = 1;

                player.Play();
                IsPlaying = true;
                isFinishedPlaying = false;
            }
            else if (player != null && !IsPlaying)
            {
                player.Play();
                IsPlaying = true;
                isFinishedPlaying = false;
            }
        }

        /// <summary>
        /// Using this metod to pause the audio.
        /// </summary>
        public void Pause()
        {
            if (player != null && IsPlaying)
            {
                player.Pause();
                IsPlaying = false;
            }
        }

        /// <summary>
        /// This method is used to stop the audio.
        /// </summary>
        public void Stop()
        {
            if (player != null)
            {
                player.Dispose();
                IsPlaying = false;
                player = null;
            }
        }

        /// <summary>
        /// This method is used to get the current time of the audio.
        /// </summary>
        public string GetCurrentPlayTime()
        {
            if (player != null)
            {
                var positionTimeSeconds = player.CurrentTime.Seconds;
                TimeSpan currentTime = TimeSpan.FromSeconds(positionTimeSeconds);
                string currentPlayTime = string.Format("{0:mm\\:ss}", currentTime);
                return currentPlayTime;
            }
            return null;
        }

        public bool CheckFinishedPlayingAudio()
        {
            return isFinishedPlaying;
        }

        /// <summary>
        /// This method used to register notification for recieve the alert when complete the audio playing.
        /// </summary>
        private void RegisterNotification()
        {
            notificationHandle = NSNotificationCenter.DefaultCenter.AddObserver(AVPlayerItem.DidPlayToEndTimeNotification, HandleNotification);
        }

        private void UnregisterNotification()
        {
            NSNotificationCenter.DefaultCenter.RemoveObserver(notificationHandle);
        }

        /// <summary>
        /// Invoked when audio playing completed.
        /// </summary>
        private void HandleNotification(NSNotification notification)
        {
            isFinishedPlaying = true;
            Stop();
        }

        #endregion
    }
}
