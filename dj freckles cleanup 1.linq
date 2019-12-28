<Query Kind="Statements">
  <Output>DataGrids</Output>
  <NuGetReference>ID3</NuGetReference>
  <Namespace>Id3</Namespace>
  <Namespace>Id3.Frames</Namespace>
</Query>

var start = @"C:\Users\mdepouw\OneDrive\Music\DJ Freckles\DJ Freckles\DJ Freckles 2pac's GH";
start = @"C:\Users\mdepouw\OneDrive\Music\DJ Freckles\DJ Freckles\DJ Freckles For The Mutha Fuckas That Think Rap Is";
start = @"C:\Users\mdepouw\OneDrive\Music\DJ Freckles\DJ Freckles\DJ Freckles Vol 09";
start = @"C:\Users\mdepouw\OneDrive\Music\DJ Freckles\DJ Freckles\DJ Freckles Vol 05 THEY JUST KEEP COM'N";
start = @"C:\Users\mdepouw\OneDrive\Music\DJ Freckles\DJ Freckles\DJ Freckles Vol 04 RED'S RIDE OUT SONGS III";
start = @"C:\Users\mdepouw\OneDrive\Music\DJ Freckles\DJ Freckles\DJ Freckles SD ONLY Vol 1 SD";
start = @"C:\Users\mdepouw\OneDrive\Music\DJ Freckles\DJ Freckles\DJ Freckles Eminem's GH";
start = @"C:\Users\mdepouw\OneDrive\Music\DJ Freckles\DJ Freckles\Dj Freckles Dmx'S Gh";
start = @"C:\Users\mdepouw\OneDrive\Music\DJ Freckles\DJ Freckles\DJ Freckles Make Da Shit Crunk for September";
start = @"C:\Users\mdepouw\OneDrive\Music\DJ Freckles\DJ Freckles\DJ Freckles Biggie's GH";
start = @"C:\Users\mdepouw\OneDrive\Music\DJ Freckles\DJ Freckles\DJ Freckles~Gangsta Love~Rap~2004~1 of 1~Reg";
start = @"C:\Users\mdepouw\OneDrive\Music\DJ Freckles\DJ Freckles\DJ Freckles~Field Mob Greatest Hits~Rap";
start = @"C:\Users\mdepouw\Desktop\rating debug";

string[] musicFiles = Directory.GetFiles(start, "*.mp3", SearchOption.AllDirectories);
foreach (string musicFile in musicFiles)
{
	using (var mp3 = new Mp3(musicFile, Mp3Permissions.ReadWrite))
	{
		Id3Tag tag = mp3.GetTag(Id3TagFamily.Version2X);

		var addV2x = false;

		//todo revisit
		//DJ_Freckles_Make_Da_Shit_Crunk_for_September
		if (tag == null)
		{
			tag = mp3.GetTag(Id3TagFamily.Version1X);
			addV2x = true;

			if (tag == null)
				continue;
		}

		//if album title exists move to comment
		if (!string.IsNullOrWhiteSpace(tag.Album))
		{
			tag.Comments.Add(new CommentFrame(tag.Album));
		}

		//set new album title
		var newAlbumTitle = "2Pac's GH";
		newAlbumTitle = "For The Mutha Fuckas That Think Rap Is";
		newAlbumTitle = "Vol 09";
		newAlbumTitle = "Vol 05 THEY JUST KEEP COM'N";
		newAlbumTitle = "Vol 04 RED'S RIDE OUT SONGS III";
		newAlbumTitle = "SD ONLY Vol 1";
		newAlbumTitle = "Eminem's GH";
		newAlbumTitle = "DMX's GH";
		newAlbumTitle = "Make Da Shit Crunk for September";
		newAlbumTitle = "Biggie's GH";
		newAlbumTitle = "Gangsta Love";
		newAlbumTitle = "Field Mob's GH";
		
		tag.Album = newAlbumTitle;

		tag.Band = "DJ Freckles";

		if (addV2x)
			mp3.WriteTag(tag, Id3Version.V23, WriteConflictAction.Replace);
		else
			mp3.WriteTag(tag);
	}
}