﻿using System;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace GNFSCore.IntegerMath.Internal
{
	public static class Eratosthenes
	{
		public static List<int> Sieve(int ceiling)
		{
			if (ceiling < 10)
			{
				if (ceiling == 9 || ceiling == 8 || ceiling == 7)
				{
					return new List<int>() { 2, 3, 5, 7 };
				}
				else if (ceiling == 6 || ceiling == 5)
				{
					return new List<int>() { 2, 3, 5 };
				}
				else if (ceiling == 4 || ceiling == 3)
				{
					return new List<int>() { 2, 3 };
				}
				else
				{
					return new List<int>() { 2 };
				}
			}

			int counter = 0;
			int counterStart = 3;
			int inc;
			int sqrt = 3;

			int ceil = ceiling > Int32.MaxValue ? Int32.MaxValue - 2 : (int)ceiling;
			bool[] primeMembershipArray = new bool[ceil + 1];

			primeMembershipArray[2] = true;

			// Set all odds as true
			for (counter = counterStart; counter <= ceiling; counter += 2)
			{
				if ((counter & 1) == 1) // Check if odd. &1 is the same as: %2
				{
					primeMembershipArray[counter] = true;
				}
			}

			while (sqrt * sqrt <= ceiling)
			{
				counter = sqrt * sqrt;
				inc = sqrt + sqrt;

				while (counter <= ceiling)
				{
					primeMembershipArray[counter] = false;
					counter += inc;
				}

				sqrt += 2;

				while (!primeMembershipArray[sqrt])
				{
					sqrt++;
				}
			}

			List<int> result = Enumerable.Range(2, (int)ceiling - 2).Where(l => primeMembershipArray[l]).ToList();

			return result;
		}
	}
}
