/*
 * Created by SharpDevelop.
 * User: 2023575000
 * Date: 2024/05/02
 * Time: 00:19
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
	/// <summary>
	/// Description of GameState.
	/// </summary>
	public class GameState
	{
		public int Rows {get; private set;}
		public int Cols {get; private set;}
		
		public GridValue[,] Grid {get; private set;}
		public Direction Dir {get; private set;}
		public int Score {get; private set;}
		public bool GameOver {get; private set;}
		
		private readonly LinkedList<Direction> dirChanges = new LinkedList<Direction>();
		private readonly LinkedList<Position> SnakePosition = new LinkedList<Position>();
		private Random random = new Random();
		
		public GameState(int Rows, int Cols)
		{
			this.Rows = Rows;
			this.Cols = Cols;
			Grid = new GridValue[Rows, Cols];
			Dir = Direction.Right;
			AddSnake();
			AddFood();
			
		}
		private void AddSnake()
		{
			int r = Rows / 2;
			
			for(int c = 1; c <= 3; c++)
			{
				Grid[r, c] = GridValue.Snake;
				SnakePosition.AddFirst(new Position(r, c));
			}
		}
		private IEnumerable<Position> EmptyPositions()
		{
			for(int r = 0; r < Rows; r++)
			{
				for(int c = 0; c < Cols; c++)
				{
					if(Grid[r, c] == GridValue.Empty)
					{
						yield return new Position(r, c);
					}
				}
				
			}
		}
		private void AddFood()
		{
			List<Position> Empty = new List<Position>(EmptyPositions());
			if(Empty.Count == 0)
			{
				return;
			}
			Position pos = Empty[random.Next(Empty.Count)];
			Grid[pos.Row, pos.Col] = GridValue.Food;
			
				
		}
		
		public Position HeadPosition()
		{
			return SnakePosition.First.Value;
		}
		public Position TailPosition()
		{
			return SnakePosition.Last.Value;
		}
		public IEnumerable<Position> SnakePositions()
		{
			return SnakePosition;
		}
		private void AddHead(Position pos)
		{
			SnakePosition.AddFirst(pos);
			Grid[pos.Row, pos.Col] = GridValue.Snake;
		}
		private void RemoveTail()
		{
			Position tail = SnakePosition.Last.Value;
			Grid[tail.Row, tail.Col] = GridValue.Empty;
			SnakePosition.RemoveLast();
		}
		private Direction GetLastDirection()
		{
			if(dirChanges.Count == 0)
			{
				return Dir;
			}
			return dirChanges.Last.Value;
		}
		private bool CanChangeDirection(Direction newDir)
		{
			if(dirChanges.Count == 2)
			{
				return false;
			}
			
			Direction LastDir = GetLastDirection();
			return newDir != LastDir && newDir != LastDir.Opposite();
		}
		public void ChangeDirection(Direction dir)
		{
			if(CanChangeDirection(dir))
			{
				dirChanges.AddLast(dir);
			}
			//I change can be made if so add it to the buffer
			
		}
		private bool OutsideGrid(Position pos)
		{
			return pos.Row < 0 || pos.Row > Rows || pos.Col < 0 || pos.Col >= Cols;
		}
		private GridValue WillHit(Position newHeadPos)
		{
			if(OutsideGrid(new Position(newHeadPos.Row, newHeadPos.Col)))
			{
				return GridValue.Outside;
			}
			if(newHeadPos == TailPosition())
			{
				return GridValue.Empty;
			}
			return Grid[newHeadPos.Row, newHeadPos.Col];
		}
		public void Move()
		{
			if(dirChanges.Count > 0)
			{
				Dir = dirChanges.First.Value;
				dirChanges.RemoveFirst();
			}
			Position newHeadPos = HeadPosition().Translate(Dir);
			GridValue hit = WillHit(newHeadPos);
			
			if(hit == GridValue.Outside || hit == GridValue.Snake)
			{
				GameOver = true;
				
			}
			else if(hit == GridValue.Empty)
			{
			      RemoveTail();
			      AddHead(newHeadPos);
			}
			else if(hit == GridValue.Food)
			{
				AddHead(newHeadPos);
				Score++;
				AddFood();
			}
		
		}
		
	}
}
