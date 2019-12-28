<Query Kind="Statements">
  <Output>DataGrids</Output>
</Query>

var start = @"C:\Users\mdepouw\OneDrive\Music\DJ Freckles\DJ Freckles";

var folders = Directory.GetDirectories(start);

foreach (var folder in folders)
{
	if (folder.Contains("_"))
	{
		var newName = folder.Replace("_", " ");
		Directory.Move(folder, newName);
	}
}