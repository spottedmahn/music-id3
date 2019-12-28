<Query Kind="Statements">
  <Output>DataGrids</Output>
  <NuGetReference>ID3</NuGetReference>
  <Namespace>Id3</Namespace>
</Query>

var folder = @"C:\Users\mdepouw\OneDrive\Music\DJ Freckles\DJ Freckles\DJ_Freckles_Make_Da_Shit_Crunk_for_September";
//folder = @"C:\Users\mdepouw\OneDrive\Music\DJ Freckles\DJ Freckles\DJ_Freckles_Da_Ultimate_Playlist";
//folder = @"C:\Users\mdepouw\OneDrive\Music\DJ Freckles\DJ Freckles\DJ_Freckles_Da_New_Shit_Vol_10";
//folder = @"C:\Users\mdepouw\OneDrive\Music\DJ Freckles\DJ Freckles\DJ_Freckles_Da_New_Shit_Vol_8";
folder = @"C:\Users\mdepouw\OneDrive\Music\DJ Freckles\DJ Freckles";

string[] musicFiles = Directory.GetFiles(folder, "*.mp3", SearchOption.AllDirectories);
foreach (string musicFile in musicFiles)
{
	using (var mp3 = new Mp3(musicFile, Mp3Permissions.ReadWrite))
	{
		Id3Tag tag = mp3.GetTag(Id3TagFamily.Version2X);
		
		//todo revisit
		//DJ_Freckles_Make_Da_Shit_Crunk_for_September
		if(tag == null)
			continue;
		//tag?.Artists.Dump();
		//take artist and move it to track title
		//example
		//artist: 02_rob_jackson_ft_bun_b_of_ugk
		//title: null
		var artist = tag.Artists.Value.FirstOrDefault();
		if (string.IsNullOrWhiteSpace(tag.Title)
			&& !string.IsNullOrWhiteSpace(artist))
		{
			//todo null
			tag.Title = artist;
			tag.Artists.Value.Clear();
		}
		
		mp3.WriteTag(tag);
	}
}