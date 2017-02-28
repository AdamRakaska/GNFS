﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GNFSCore
{
	public class Combinatorics
	{
		/*  n take 2 : Combination with repetition
		 quantity returned = (n + 1)! / 2 * (n - 1)!      */
		public static IEnumerable<int[]> GetCombination(IEnumerable<int> input)
		{
			var listInner = input.Except(new int[] { 0, 1 }).Distinct().OrderBy(i => i).ToList();
			var listOutter = listInner.ToList();

			List<int[]> result = new List<int[]>();

			foreach (int a in listOutter)
			{
				result.AddRange(listInner/*.Except(new int[] { a })*/.Select(b => new int[] { a, b }));
				listInner.Remove(a);
			}

			return result;
		}

		public static IEnumerable<int[]> GetCombinations(int[] array, int take)
		{
			var n = array.Length - 1;
			var result = new int[take];
			var stack = new Stack<int>();
			stack.Push(0);

			while (stack.Count > 0)
			{
				var index = stack.Count - 1;
				var value = stack.Pop();

				while (value < n)
				{
					result[index++] = value++;
					stack.Push(value);
					if (index == take)
					{
						yield return result.Select(i => array[i]).ToArray();
						break;
					}
				}
			}
		}
	}
}
