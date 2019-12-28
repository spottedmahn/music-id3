<Query Kind="Statements">
  <Output>DataGrids</Output>
  <NuGetReference>ID3</NuGetReference>
  <Namespace>Id3</Namespace>
</Query>

var start = @"C:\Users\mdepouw\OneDrive\Music\_me music attempt 2\Kendrick Lamar\DAMN [Explicit]";

var remove = "Explicit";
remove = ". [Explicit]";

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

		if(string.IsNullOrWhiteSpace(tag.Title.Value)
			|| !tag.Title.Value.Contains(remove))
			continue;

		tag.Title.Value = tag.Title.Value.Replace(remove, "")
			.Trim();

		if (addV2x)
			mp3.WriteTag(tag, Id3Version.V23, WriteConflictAction.Replace);
		else
			mp3.WriteTag(tag);
	}
}