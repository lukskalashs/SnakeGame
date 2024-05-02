/*
 * Created by SharpDevelop.
 * User: 2023575000
 * Date: 2024/05/02
 * Time: 01:27
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Snake
{
	/// <summary>
	/// Description of Images.
	/// </summary>
	public static class Images
	{
		public readonly static ImageSource Empty = LoadImage("Empty.png");
		public readonly static ImageSource Body = LoadImage("Body.png");
		public readonly static ImageSource Head = LoadImage("Head.png");
		public readonly static ImageSource Food = LoadImage("Food.png");
		public readonly static ImageSource DeadBody = LoadImage("DeadBody.png");
		public readonly static ImageSource DeadHead = LoadImage("DeadHead.png");

		
		private static ImageSource LoadImage(string filename)
		{
   			 return new BitmapImage(new Uri(string.Format("SnakeAssets/{0}", filename), UriKind.Relative));
		}

		
	}
}
