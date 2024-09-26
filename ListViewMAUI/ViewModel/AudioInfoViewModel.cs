using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Input;

namespace ListViewMAUI
{
    public class AudioInfoViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<AudioInfo> audioCollection;
        private AudioInfo audioFile;
        IAudioPlayerService audioPlayerService;
        IDispatcherTimer playTimer;
        public AudioInfoViewModel(IAudioPlayerService audioPlayerService)
        {
            GenerateSource();
            this.audioPlayerService = audioPlayerService;
            PauseAudioCommand = new Command(PauseAudio);
            PlayAudioCommand = new Command(StartPlayingAudio);
        }

        #region Generate Source

        private void GenerateSource()
        {
            AudioInfoRepository audioInfoRepository = new AudioInfoRepository();
            audioCollection = audioInfoRepository.GetSongs();
        }

        #endregion

        #region Properties

        public ObservableCollection<AudioInfo> AudioCollection
        {
            get { return audioCollection; }
            set { this.audioCollection = value; }
        }

        public AudioInfo AudioFile
        {
            get { return audioFile; }
            set 
            {
                audioFile = value; 
                OnPropertyChanged("AudioFile"); 
            }
        }
        public ICommand PauseAudioCommand { get; set; }
        public ICommand PlayAudioCommand { get; set; }


        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #endregion

        #region Player command

        private void StartPlayingAudio(object obj)
        {
            if (audioFile != null && audioFile != (AudioInfo)obj)
            {
                AudioFile.IsPlayVisible = true;
                StopAudio();
            }
            if (obj is AudioInfo)
            {
                audioFile = (AudioInfo)obj;
                audioFile.IsPlayVisible = false;
                string audioFilePath = AudioFile.AudioURL;
                audioPlayerService.PlayAudio(audioFilePath);
                SetCurrentAudioPosition();
            }
        }
        private void PauseAudio(object obj)
        {
            if (obj is AudioInfo)
            {
                var audioFile = (AudioInfo)obj;
                audioFile.IsPlayVisible = true;
                audioPlayerService.Pause();
            }
        }
        private void SetCurrentAudioPosition()
        {
            if (playTimer == null)
                playTimer = Application.Current.Dispatcher.CreateTimer();
            playTimer.Interval = new TimeSpan(0, 0, 0, 0, 250);
            playTimer.Tick += (s, e) =>
            {
                if (AudioFile != null)
                {
                    AudioFile.CurrentAudioPosition = audioPlayerService.GetCurrentPlayTime();
                    bool isAudioCompleted = audioPlayerService.CheckFinishedPlayingAudio();
                    if (isAudioCompleted)
                    {
                        AudioFile.IsPlayVisible = true;
                        audioPlayerService.Stop();
                        playTimer.Stop();
                    }
                }
            };
            playTimer.Start();
        }

        public void StopAudio()
        {
            if (AudioFile != null)
            {
                audioPlayerService.Stop();
                playTimer.Stop();
            }
        }
        #endregion
    }
}
