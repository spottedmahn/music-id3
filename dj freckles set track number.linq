<Query Kind="Statements">
  <Output>DataGrids</Output>
  <NuGetReference>ID3</NuGetReference>
  <Namespace>Id3</Namespace>
  <Namespace>Id3.Frames</Namespace>
</Query>

var start = @"C:\Users\mdepouw\OneDrive\Music\DJ Freckles\DJ Freckles\DJ Freckles~Red's Ride Out Songs Vol 1~Rap~2000~1 of 1~Reg";
start = @"C:\Users\mdepouw\OneDrive\Music\DJ Freckles\DJ Freckles\DJ Freckles Edition Of 2Pac R U Still Down";
start = @"C:\Users\mdepouw\OneDrive\Music\DJ Freckles\DJ Freckles\DJ Freckles~Jay-Z Greatest Hits~Rap~2007~1 of 1~Reg";
start = @"C:\Users\mdepouw\OneDrive\Music\DJ Freckles\DJ Freckles\DJ Freckles~Gangsta Love~Rap~2004~1 of 1~Reg";
start = @"C:\Users\mdepouw\OneDrive\Music\DJ Freckles\DJ Freckles\DJ Freckles Eminem's GH";
start = @"C:\Users\mdepouw\OneDrive\Music\DJ Freckles\DJ Freckles\Dj Freckles Dmx'S Gh";
start = @"C:\Users\mdepouw\OneDrive\Music\DJ Freckles\DJ Freckles\DJ Freckles~Dobe R&B Vol 1~R&B~2002~1 of 1~Reg";
start = @"C:\Users\mdepouw\OneDrive\Music\DJ Freckles\DJ Freckles\DJ Freckles~Red's Ride Out Songs Vol II~Rap~2001~1 of 1~Reg";
start = @"C:\Users\mdepouw\OneDrive\Music\DJ Freckles\DJ Freckles\DJ Freckles~Straight Phat Stuff~Rap~2003~1 of 1~Reg";
start = @"C:\Users\mdepouw\OneDrive\Music\DJ Freckles\DJ Freckles\DJ Freckles~Petey Pablo Greatest Hits~Rap~2004~1 of 1~Reg";
start = @"C:\Users\mdepouw\OneDrive\Music\DJ Freckles\DJ Freckles\DJ Freckles~On Da Way 2 Naples Vol 1~Rap~2004~1 of 1~Reg";
start = @"C:\Users\mdepouw\OneDrive\Music\DJ Freckles\DJ Freckles\DJ Freckles~On Da Way From Naples Vol 1~Rap~2004~1 of 1~Reg";
start = @"C:\Users\mdepouw\OneDrive\Music\DJ Freckles\DJ Freckles\DJ Freckles Make Da Shit Crunk for September";
start = @"C:\Users\mdepouw\OneDrive\Music\DJ Freckles\DJ Freckles\DJ Freckles Biggie's GH";
start = @"C:\Users\mdepouw\OneDrive\Music\DJ Freckles\DJ Freckles\DJ Freckles~Bombin~Rap~2004~1 of 1~Reg";
start = @"C:\Users\mdepouw\OneDrive\Music\DJ Freckles\DJ Freckles\DJ Freckles~Bomin~Rap~2004~1 of 1~SD";
start = @"C:\Users\mdepouw\OneDrive\Music\DJ Freckles\DJ Freckles\DJ Freckles~Which Joint Is Hotter - Jay-Z - Blueprint vs. Fabolous - Ghetto Fabolous~Rap~2001~1 of 1~Reg";

string[] musicFiles = Directory.GetFiles(start, "*.mp3", SearchOption.AllDirectories)
	.OrderBy(d => d)
	.ToArray();
var i = 1;
var total = musicFiles.Length;

foreach (string musicFile in musicFiles)
{
	using (var mp3 = new Mp3(musicFile, Mp3Permissions.ReadWrite))
	{
		Id3Tag tag = mp3.GetTag(Id3TagFamily.Version2X);

		//todo revisit
		//DJ_Freckles_Make_Da_Shit_Crunk_for_September
		if (tag == null)
			continue;

		if (tag.Track == null)
		{
			tag.Track = new TrackFrame();
		}
		tag.Track.Value = i;
		tag.Track.TrackCount = total;

		mp3.WriteTag(tag);
	}
	i++;
}