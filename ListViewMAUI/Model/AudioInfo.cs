using System.ComponentModel;

namespace ListViewMAUI
{ 
    public class AudioInfo : INotifyPropertyChanged
    {
        #region Fields

        private string title;
        private string author;
        private string? image;
        private string size;

        private bool isPlayVisible;
        private bool isPauseVisible;
        private string currentAudioPostion;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets a value that indicates song title. 
        /// </summary>
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
                this.RaisePropertyChanged("Title");
            }
        }

        /// <summary>
        /// Gets or sets the value that indicates the song auther.
        /// </summary>
        public string Author
        {
            get
            {
                return author;
            }
            set
            {
                author = value;
                this.RaisePropertyChanged("Author");
            }
        }

        /// <summary>
        /// Gets or sets the value that indicates the song auther.
        /// </summary>
        public string Image
        {
            get
            {
                return image;
            }
            set
            {
                image = value;
                this.RaisePropertyChanged("Image");
            }
        }

        /// <summary>
        /// Gets or sets a value that indicates song size. 
        /// </summary>
        public string Size
        {
            get
            {
                return size;
            }
            set
            {
                size = value;
                this.RaisePropertyChanged("Size");
            }
        }

        public bool IsPlayVisible
        {
            get { return isPlayVisible; }
            set
            {
                isPlayVisible = value;
                this.RaisePropertyChanged("IsPlayVisible");
                IsPauseVisble = !value;
            }
        }
        public bool IsPauseVisble
        {
            get { return isPauseVisible; }
            set 
            {
                isPauseVisible = value;
                this.RaisePropertyChanged("IsPauseVisble") ; 
            }
        }
        public string CurrentAudioPosition
        {
            get { return currentAudioPostion; }
            set
            {
                if (string.IsNullOrEmpty(currentAudioPostion))
                {
                    currentAudioPostion = string.Format("{0:mm\\:ss}", new TimeSpan());
                }
                else
                {
                    currentAudioPostion = value;
                }
                this.RaisePropertyChanged("CurrentAudioPosition");
            }
        }
        public string AudioURL { get; set; }


        #endregion

        public AudioInfo()
        {
            IsPlayVisible = true;
            string fileName = $"MusicFiles/MusicInfo.mp3";
            AudioURL = fileName;
        }

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(String name)
        {
            if (PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #endregion
    }
}
