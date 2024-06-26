﻿/*
 * Created by SharpDevelop.
 * User: 2023575000
 * Date: 2024/05/01
 * Time: 23:31
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Threading.Tasks;

namespace Snake
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class Window1 : Window
	{
		private readonly Dictionary<GridValue, ImageSource> gridValToImage = new Dictionary<GridValue, ImageSource>
		{
		    { GridValue.Empty, Images.Empty },
		    { GridValue.Snake, Images.Body },
		    { GridValue.Food, Images.Food }
		};
		
		private readonly Dictionary<Direction, int> dirToRotation = new Dictionary<Direction, int>()
		{
			{Direction.Up, 0},
			{Direction.Right, 90},
			{Direction.Down, 180},
			{Direction.Left, 270}
		};

		private readonly int rows = 15, cols = 15;
		private readonly Image[,] gridImages;
		private GameState gameState;
		private bool GameRunning;
		
		
		
		public Window1()
		{
			InitializeComponent();
			gridImages = SetupGrid();
			gameState = new GameState(rows,cols);
		}
		private async Task RunGame()
		{
			Draw();
			await ShowCounDown();
			Overlay.Visibility = Visibility.Hidden;
			await GameLoop();
			await ShowGameOver();
			gameState = new GameState(rows,cols);
			
		}
		private async void Window_PreviewKeyDown(object sender, KeyEventArgs e)
		{
			if(Overlay.Visibility == Visibility.Visible)
			{
				e.Handled = true;
			}
			if(!GameRunning)
			{
				GameRunning = true;
				await RunGame();
				GameRunning = false;
			}
		}
		
		void Window_KeyDown(object sender, KeyEventArgs e)
		{
			if(gameState.GameOver)
			{
				return;
			}
			
			switch (e.Key) 
			{
				case Key.Left:
					gameState.ChangeDirection(Direction.Left);
					break;
				case Key.Right:
					gameState.ChangeDirection(Direction.Right);
					break;
				case Key.Down:
					gameState.ChangeDirection(Direction.Down);
					break;
				case Key.Up:
					gameState.ChangeDirection(Direction.Up);
					break;
			}
		}
		private Image[,] SetupGrid()
		{
			Image[,] images = new Image[rows,cols];
			GameGrid.Rows = rows;
			GameGrid.Columns = cols;
			
			for(int r = 0; r < rows; r++)
			{
				for(int c = 0; c < cols; c++)
				{
					Image image = new Image
					{
						Source = Images.Empty,
						RenderTransformOrigin = new Point(0.5, 0.5)
					};
					
					images[r,c] = image;
					GameGrid.Children.Add(image);
				}
			}
			return images;
		}
		private async Task GameLoop()
		{
			while (!gameState.GameOver) 
			{
				await Task.Delay(100);
				gameState.Move();
				Draw();
			}
		}
		private void Draw()
		{
			DrawGrid();
			DrawSnakeHead();
			ScoreText.Text = "SCORE " + gameState.Score;
			
		}
	
		private void DrawGrid()
		{
			for(int r = 0; r < rows; r++)
			{
				for(int c = 0; c < cols; c++)
				{
					GridValue gridVal = gameState.Grid[r, c];
					gridImages[r,c].Source = gridValToImage[gridVal];
					gridImages[r,c].RenderTransform = Transform.Identity;
			
				}
			}
		}
		private void DrawSnakeHead()
		{
			Position HeadPos = gameState.HeadPosition();
			Image image = gridImages[HeadPos.Row, HeadPos.Col];
			image.Source = Images.Head;
			
			int Rotation = dirToRotation[gameState.Dir];
			image.RenderTransform = new RotateTransform(Rotation);
		}
		private async Task DrawDeadSnake()
		{
			List<Position> positions = new List<Position>(gameState.SnakePositions());
			for(int i = 0; i < positions.Count; i++)
			{
				Position pos = positions[i];
				ImageSource source = (i == 0) ? Images.DeadHead : Images.DeadBody;
				gridImages[pos.Row, pos.Col].Source = source;
				await Task.Delay(50);
			}
		}
		private async Task ShowCounDown()
		{
			for(int i=3; i >= 1; i--)
			{
				OverlayText.Text = i.ToString();
				await Task.Delay(500);
			}
		}
		private async Task ShowGameOver()
		{
			await DrawDeadSnake();
			await Task.Delay(1000);
			Overlay.Visibility = Visibility.Visible;
			OverlayText.Text = "PRESS ANY KEY TO START";
			
		}
		
		
			
		
		
	}
}