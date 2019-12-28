<Query Kind="Statements">
  <Output>DataGrids</Output>
  <Reference Relative="..\..\source\repos\GitHub\spottedmahn\Id3\src\Id3.Net\bin\Debug\netstandard2.0\Id3.Net.dll">C:\Users\mdepouw\source\repos\GitHub\spottedmahn\Id3\src\Id3.Net\bin\Debug\netstandard2.0\Id3.Net.dll</Reference>
  <Namespace>Id3</Namespace>
  <Namespace>Id3.Frames</Namespace>
</Query>

var start = @"C:\Users\mdepouw\Desktop\recording date debug";

string[] musicFiles = Directory.GetFiles(start, "*.mp3", SearchOption.AllDirectories);
foreach (string musicFile in musicFiles)
{
	using (var mp3 = new Mp3(musicFile, Mp3Permissions.ReadWrite))
	{
		Id3Tag tag = mp3.GetTag(Id3TagFamily.Version2X);

		tag.RecordingDate = new DateTime(2002, 4, 22);

		mp3.WriteTag(tag);
	}
}