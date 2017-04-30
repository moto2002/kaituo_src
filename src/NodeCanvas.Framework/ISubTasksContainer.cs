using System;

namespace NodeCanvas.Framework
{
	public interface ISubTasksContainer
	{
		Task[] GetTasks();
	}
}
