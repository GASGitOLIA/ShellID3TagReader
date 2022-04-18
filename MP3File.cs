using System;
namespace ShellID3Reader {
	public class MP3File {
		private string fileName;
        private string filePath;
		private string artistName;
		private string albumName;
		private int trackNumber;
		private string songTitle;
        private string artistNameFromFile;
        private string songNameFromFile;
        private bool mismatch;

		public string FileName {
		 	get{return this.fileName;}
			set{this.fileName = value;}
		}
        public string FilePath
        {
            get { return this.filePath; }
            set { this.filePath = value; }
        }
		public string ArtistName {
			get{return this.artistName;}
			set{this.artistName = value;}
		}
		public string AlbumName {
			get{return this.albumName;}
			set{this.albumName = value;}
		}
		public int TrackNumber {
		 	get{return this.trackNumber;}
			set{this.trackNumber = value;}
		}
		public string SongTitle {
		 	get{return this.songTitle;}
			set{this.songTitle = value;}
		}
        public string SongNameFromFile
        {
            get { return this.songNameFromFile; }
            set { this.songNameFromFile = value; }
        }
        public string ArtistNameFromFile
        {
            get { return this.artistNameFromFile; }
            set { this.artistNameFromFile = value; }
        }
        public bool DataMismatch
        {
            get { return this.mismatch; }
            set { this.mismatch = value; }
        }
		public MP3File(){
		}
	}
}