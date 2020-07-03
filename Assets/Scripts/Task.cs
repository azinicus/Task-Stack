using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Task
{
	public string name;
	public int count;
	public int total;

	/// <summary>
    /// Constructor for the Task class type
    /// </summary>
    /// <param name="newName"></param>
    /// <param name="newTotal"></param>
	public Task(string newName, int newTotal)
	{
		this.name = newName;
		this.total = newTotal;
	}

}