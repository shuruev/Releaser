using System.Collections.Generic;

namespace Releaser.CommandManager
{
	public class LimitedRevertedList<T> : LinkedList<T>
	{
		private readonly int m_maxItems;

		public LimitedRevertedList(int maxCount)
		{
			m_maxItems = maxCount;
		}

		public void Add(T value)
		{
			var node = new LinkedListNode<T>(value);
			AddFirst(node);

			if (Count > m_maxItems)
			{
				RemoveLast();
			}
		}
	}
}
