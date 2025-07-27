using System.Collections;
using System.Collections.Generic;
using System.Linq;

public static class Recursion
{
    /// <summary>
    /// #############
    /// # Problem 1 #
    /// #############
    /// Using recursion, find the sum of 1^2 + 2^2 + 3^2 + ... + n^2
    /// and return it. If the value of n <= 0, just return 0.
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        if (n <= 0)
            return 0;

        return n * n + SumSquaresRecursive(n - 1);
    }

    /// <summary>
    /// #############
    /// # Problem 2 #
    /// #############
    /// Recursively insert permutations of length 'size' from 'letters' into results.
    /// Assume letters are unique.
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        if (size == 0)
        {
            results.Add(word);
            return;
        }

        for (int i = 0; i < letters.Length; i++)
        {
            // Choose letter at i
            char chosen = letters[i];
            // Remove chosen letter and recurse
            string remaining = letters.Remove(i, 1);
            PermutationsChoose(results, remaining, size - 1, word + chosen);
        }
    }

    /// <summary>
    /// #############
    /// # Problem 3 #
    /// #############
    /// Count ways to climb s stairs with steps 1, 2, or 3.
    /// Uses memoization dictionary 'remember' to store results.
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        if (remember == null)
            remember = new Dictionary<int, decimal>();

        if (s < 0)
            return 0;

        if (s == 0)
            return 1;

        if (remember.ContainsKey(s))
            return remember[s];

        decimal ways = CountWaysToClimb(s - 1, remember)
                     + CountWaysToClimb(s - 2, remember)
                     + CountWaysToClimb(s - 3, remember);

        remember[s] = ways;
        return ways;
    }

    /// <summary>
    /// #############
    /// # Problem 4 #
    /// #############
    /// Generate all binary strings from a pattern containing '0', '1', and '*'.
    /// Replace '*' recursively with '0' and '1'.
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results)
    {
        int index = pattern.IndexOf('*');
        if (index == -1)
        {
            results.Add(pattern);
            return;
        }

        string prefix = pattern.Substring(0, index);
        string suffix = pattern.Substring(index + 1);

        WildcardBinary(prefix + "0" + suffix, results);
        WildcardBinary(prefix + "1" + suffix, results);
    }

    /// <summary>
    /// #############
    /// # Problem 5 #
    /// #############
    /// Solve maze recursively, finding all paths from (x,y) to end.
    /// Use maze.IsValidMove and maze.IsEnd helper methods.
    /// Add each successful path to results as string.
    /// </summary>
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<(int, int)>? currPath = null)
    {
        if (currPath == null)
            currPath = new List<(int, int)>();

        if (!maze.IsValidMove(currPath, x, y))
            return;

        currPath.Add((x, y));

        if (maze.IsEnd(x, y))
        {
            results.Add(PathToString(currPath));
        }
        else
        {
            // Explore neighbors: right, left, down, up
            SolveMaze(results, maze, x + 1, y, currPath);
            SolveMaze(results, maze, x - 1, y, currPath);
            SolveMaze(results, maze, x, y + 1, currPath);
            SolveMaze(results, maze, x, y - 1, currPath);
        }

        // Backtrack
        currPath.RemoveAt(currPath.Count - 1);
    }

    /// <summary>
    /// Helper: Convert list of (x,y) tuples to string for maze path representation
    /// Example: "(0,0)->(1,0)->(1,1)"
    /// </summary>
    private static string PathToString(List<(int, int)> path)
    {
        return string.Join("->", path.Select(p => $"({p.Item1},{p.Item2})"));
    }
}
