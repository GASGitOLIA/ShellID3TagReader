using System;
namespace ShellID3Reader
{
	public struct ShellID3TagReader
	{
		public static MP3File ReadID3Tags(string FileFullPath){
			MP3File mp3File = new MP3File();

            //string artistFileParse;
            //string songFileParse;
            int extEnd;
            int artistEnd;
            string[] words = new string[] {"",""};

			//parse file name
			string fileName = FileFullPath.Substring(FileFullPath.LastIndexOf("\\")+1);
            //parse file path
			string filePath = FileFullPath.Substring(0,FileFullPath.LastIndexOf("\\"));
			//create shell instance
			Shell32.Shell shell  = new Shell32.ShellClass();
			//set the namespace to file path
			Shell32.Folder folder = shell.NameSpace(filePath);
			//get ahandle to the file
			Shell32.FolderItem folderItem = folder.ParseName(fileName);
			//did we get a handle ?
			if (folderItem !=null){
				mp3File.FileName = fileName;
                mp3File.FilePath = filePath;
				//query information from shell regarding file
				mp3File.ArtistName = folder.GetDetailsOf(folderItem,9); // contributing artist XP, 9, 17 / win7 13
				mp3File.AlbumName = folder.GetDetailsOf(folderItem,17);  //AlbumName XP, 17 / win7 14
				mp3File.SongTitle = folder.GetDetailsOf(folderItem,10);  //Song Titke XP, 10 / win7 21

              
                //to do: need to checked for Missing field info before casting
                if (Convert.ToString(folder.GetDetailsOf(folderItem, 19)) != "")
                    mp3File.TrackNumber = Convert.ToInt32(folder.GetDetailsOf(folderItem, 19)); //Track XP, 20 / win7 26
                //done

                //to do: change to handle hyphens  in filenames that aren't artist / name delimiters, eg "bron-yr-aur stomp", "54-40"
                //string[] words = fileName.Split('-');
                //to do: catch errors where the artist delimiter doesn;t exist
                
                artistEnd = fileName.LastIndexOf(" - ");

                if (artistEnd > 0)
                {
                    words[0] = fileName.Substring(0, artistEnd);
                    words[1] = fileName.Substring(artistEnd + 3, (fileName.Length - 3 - artistEnd));
                    //done

                    mp3File.ArtistNameFromFile = words[0].Trim();
                    mp3File.SongNameFromFile = words[1].Trim();

                    extEnd = mp3File.SongNameFromFile.LastIndexOf('.');
                    mp3File.SongNameFromFile = mp3File.SongNameFromFile.Substring(0, extEnd);
                }
                else
                {

                    mp3File.ArtistNameFromFile = "Artist - Bad File name format";
                    mp3File.SongNameFromFile = "Title - Bad File name format";
                }

                if ((mp3File.ArtistName.ToLower() != mp3File.ArtistNameFromFile.ToLower()) || (mp3File.SongTitle.ToLower() != mp3File.SongNameFromFile.ToLower()))
                    mp3File.DataMismatch = true;
                else
                    mp3File.DataMismatch = false;

            }   			
			//clean ip
			folderItem = null;
			folder = null;
			shell = null;
			//return mp3File instance
			return mp3File;
		}
	}
}
