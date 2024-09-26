using System.Collections.ObjectModel;

namespace ListViewMAUI
{
    public class AudioInfoRepository
    {
        #region Constructor

        public AudioInfoRepository()
        {

        }

        #endregion

        #region Properties

        internal ObservableCollection<AudioInfo> GetSongs()
        {
            var random = new Random();
            var musiqInfo = new ObservableCollection<AudioInfo>();
            for (int i = 0; i < SongsNames.Count(); i++)
            {
                var info = new AudioInfo()
                {
                    Title = SongsNames[i],
                    Author = SongAuthers[i],
                    Image = SongImages[i],
                    Size = random.Next(50, 600).ToString() + "." + random.Next(1, 10) / 2 + "KB",
                };
                musiqInfo.Add(info);
            }
            return musiqInfo;
        }

        #endregion

        string[] SongsNames = new string[]
       {
           "Adventure of a Lifetime",
"Blue Moon of Kentucky",
"I Don't Care (If Tomorrow Never Comes)",
"You're the First, the Last, My Everything",
"Words (Don’t come easy)",
"Everybody's Free (To Wear Sunscreen)",
"Before the Next Teardrop Falls",
"You've Lost That Lovin' Feelin'",
"Underneath Your Clothes",
"Try to Remember",
"The Hanging Tree (The Hunger Games song)",
"Over the Rainbow/What a Wonderful World",
"Return to Innocence",
"I Say a Little Prayer",
"I Believe I Can Fly",
"House Every Weekend",
"Heal the world",
"Green, Green Grass of Home",
"God Only Knows",
"500 Miles",
"Earth Song",
"Down in the River to Pray",
"Come Away with Me",
"Boulevard of Broken Dreams",
"Heart Is a Drum",
"I'm So Lonesome I Could Cry",
       };

        string[] SongAuthers = new string[]
        {
            "Coldplay",
"Bill Monroe",
"Hank Williams & George Jones",
"Barry White",
"F. R. David",
"Baz Luhrmann",
"Freddy Fender",
"The Righteous Brothers",
"Shakira",
"Andy Williams",
"James Newton Howard ft. Jennifer Lawrence",
"Israel Kamakawiwoʻole",
"Enigma",
"Dionne Warwick",
"R. Kelly",
"David Zowie",
"Michael Jackson",
"Tom Jones",
"the Beach Boys",
"The Brothers Four",
"Michael Jackson",
"Alison Krauss",
"Norah Jones",
"Green Day",
"Beck",
"Hank Williams",

        };
        string[] SongImages = new string[]
       {
            "coldplay.jpg",
"bill_monroe.jpg",
"hank_williams.jpg",
"barry_white.jpg",
"f_r_david.jpg",
"baz_luhrmann.jpg",
"freddy_fender.jpg",
"the_righteous_brothers.jpg",
"shakira.jpg",
"andy_williams.jpg",
"james_newton_howard_ft.jpg",
"israel_kamakawiwoole.jpg",
"enigma.jpg",
"dionne_warwick.jpg",
"r_kelly.jpg",
"david_zowie.jpg",
"michael_jackson.jpg",
"tom_jones.jpg",
"the_beach_boys.jpg",
"the_brothers_four.jpg",
"michael_jackson_heal.jpg",
"alison_krauss.jpg",
"norah_jones.jpg",
"green_day.jpg",
"beck.jpg",
"hank_williams.jpg",
       };
    }
}
