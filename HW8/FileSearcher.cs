namespace HW8;

public class FileSearcher
{
	public event EventHandler<FileArgs>? FileFound;

	protected virtual void OnFileFound(FileArgs args)
	{
		FileFound?.Invoke(this, args);
	}

	public void Search (string folderPath, string pattern)
	{
		string[] files = Directory.GetFiles(folderPath, pattern, SearchOption.AllDirectories);
		foreach (string file in files)
		{
			FileArgs fileArgs = new FileArgs(file);
			OnFileFound(fileArgs);

			if (fileArgs.Cancel)
			{
				Console.WriteLine("search cancelled");
				break;
			}
		}
	}

}
