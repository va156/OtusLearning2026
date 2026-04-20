namespace HW8;

public class FileArgs : EventArgs
{
	public string FileName { get; }
	public bool Cancel { get; set; }
	public FileArgs(string fileName)
	{
		FileName = fileName;
		Cancel = false;
	}
}
