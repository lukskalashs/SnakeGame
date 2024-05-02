

namespace Snake
{
	/// <summary>
	/// Description of Position.
	/// </summary>
	public class Position
	{
		public int Row {get; private set;}
		public int Col {get; private set;}
		
		public Position(int Row, int Col)
		{
			this.Row = Row;
			this.Col = Col;
		}
		public Position Translate(Direction dir)
		{
			return new Position(Row + dir.RowOffset, Col + dir.ColOffset);
		}
		
		#region Equals and GetHashCode implementation
		public override bool Equals(object obj)
		{
			Position other = obj as Position;
			if (other == null)
				return false;
			return this.Row == other.Row && this.Col == other.Col;
		}
		
		public override int GetHashCode()
		{
			int hashCode = 0;
			unchecked {
				hashCode += 1000000007 * Row.GetHashCode();
				hashCode += 1000000009 * Col.GetHashCode();
			}
			return hashCode;
		}
		
		public static bool operator ==(Position lhs, Position rhs)
		{
			if (ReferenceEquals(lhs, rhs))
				return true;
			if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
				return false;
			return lhs.Equals(rhs);
		}
		
		public static bool operator !=(Position lhs, Position rhs)
		{
			return !(lhs == rhs);
		}
		#endregion

	}
	
}
