<Query Kind="Statements">
  <Output>DataGrids</Output>
  <NuGetReference>ID3</NuGetReference>
  <Namespace>Id3</Namespace>
  <Namespace>Id3.Frames</Namespace>
</Query>

var start = @"C:\Users\mdepouw\OneDrive\Music\DJ Freckles\DJ Freckles\DJ Freckles 2pac's GH";

string[] musicFiles = Directory.GetFiles(start, "*.mp3", SearchOption.AllDirectories);
foreach (string musicFile in musicFiles)
{
	using (var mp3 = new Mp3(musicFile, Mp3Permissions.ReadWrite))
	{
		Id3Tag tag = mp3.GetTag(Id3TagFamily.Version2X);

		//todo revisit
		//DJ_Freckles_Make_Da_Shit_Crunk_for_September
		if (tag == null)
			continue;

		var badComment = tag.Comments.FirstOrDefault(c => c.Comment == "fake comment");
		
		if (badComment != null)
		{
			tag.Comments.Remove(badComment);
		}
		//tag.Comments.Add(new CommentFrame("fake comment"));

		mp3.WriteTag(tag);
	}
}