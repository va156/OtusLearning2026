using HW8;

List<string> strings = new List<string> { "aaa", "bbbb", "ccc" };
string longest = strings.GetMax<string>(s => s.Length);
Console.WriteLine($"The longest string: {longest}");

FileSearcher searcher = new FileSearcher();
searcher.FileFound += OnFileFound;
searcher.Search(@"C:\Users\strekv01\Desktop\Otus", "*.txt");

static void OnFileFound(object sender, FileArgs e)
{
	Console.WriteLine($"FileName: {e.FileName}");

	if (e.FileName.Contains("stop"))
	{
		e.Cancel = true;
		Console.WriteLine("cancell command sent");
	}
}