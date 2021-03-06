﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Audecyzje.WebQuickDemo.Helpers
{
    public static class StringExtensions
	{
		public static string Left(this string @this, int count)
		{
			if (@this.Length <= count)
			{
				return @this;
			}
			else
			{
				return @this.Substring(0, count);
			}
		}

		public static string Right(this string @this, int count)
		{
			@this = @this.Reverse();
			if (@this.Length <= count)
			{
				return @this;
			}
			else
			{
				return @this.Substring(0, count);
			}
		}

		public static string Reverse(this string text)
		{
			char[] cArray = text.ToCharArray();
			string reverse = String.Empty;
			for (int i = cArray.Length - 1; i > -1; i--)
			{
				reverse += cArray[i];
			}
			return reverse;
		}

		public static int IndexOfFirstLetter(this string text)
		{
			var pos = -1;
			var i = 0;
			while (pos == -1)
			{
				if (!Char.IsDigit(text[i]))
				{
					pos = i;
				}
				i++;
			}
			return pos;
		}
	}
}
