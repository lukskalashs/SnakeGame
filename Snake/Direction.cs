/*
 * Created by SharpDevelop.
 * User: 2023575000
 * Date: 2024/05/02
 * Time: 00:00
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Snake
{
	/// <summary>
	/// Description of Direction.
	/// </summary>
	public class Direction
	{
		public readonly static Direction Left = new Direction(0, -1);
		public readonly static Direction Right = new Direction(0, 1);
		public readonly static Direction Up = new  Direction(-1, 0);
		public readonly static Direction Down = new Direction(1, 0);
		
		public int RowOffset {get; private set;}
		public int ColOffset {get; private set;}
		
		private Direction(int RowOffset, int ColOffset)
		{
			this.RowOffset = RowOffset;
			this.ColOffset = ColOffset;
		}
		
		public Direction Opposite()
		{
			return new Direction(-RowOffset, -ColOffset);
		}
		
		#region Equals and GetHashCode implementation
		public override bool Equals(object obj)
		{
			Direction other = obj as Direction;
			if (other == null)
				return false;
			return this.RowOffset == other.RowOffset && this.ColOffset == other.ColOffset;
		}
		
		public override int GetHashCode()
		{
			int hashCode = 0;
			unchecked {
				hashCode += 1000000007 * RowOffset.GetHashCode();
				hashCode += 1000000009 * ColOffset.GetHashCode();
			}
			return hashCode;
		}
		
		public static bool operator ==(Direction lhs, Direction rhs)
		{
			if (ReferenceEquals(lhs, rhs))
				return true;
			if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
				return false;
			return lhs.Equals(rhs);
		}
		
		public static bool operator !=(Direction lhs, Direction rhs)
		{
			return !(lhs == rhs);
		}
		#endregion

	}
}
