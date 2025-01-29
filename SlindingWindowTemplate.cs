namespace algorithmsInCsharp;

using System;

public static class SlidingWindowTemplates
{
    public static object ShortestWindow(int[] nums, Func<bool> condition)
    {
        int i = 0;
        int minLength = int.MaxValue;
        object result = null;

        for (int j = 0; j < nums.Length; j++)
        {
            // Expand window: Add nums[j] to window logic here

            // Shrink window while condition is met
            while (condition())
            {
                int currentLength = j - i + 1;
                if (currentLength < minLength)
                {
                    minLength = currentLength;
                    // Update result with business logic here
                }

                // Shrink window: Remove nums[i] from window logic here
                i++;
            }
        }

        return result;
    }

    public static object LongestWindow(int[] nums, Func<bool> condition)
    {
        int i = 0;
        int maxLength = 0;
        object result = null;

        for (int j = 0; j < nums.Length; j++)
        {
            // Expand window: Add nums[j] to window logic here for example dic[nums[j]]++;

            // Shrink window until condition is satisfied
            while (!condition())
            {
                // Remove nums[i] from window logic here
                i++;
            }

            int currentLength = j - i + 1;
            if (currentLength > maxLength)
            {
                maxLength = currentLength;
                // Update result with business logic here
            }
        }

        return result;
    }

    public static object WindowFixedSize(int[] nums, int k)
    {
        int i = 0;
        object result = null;

        for (int j = 0; j < nums.Length; j++)
        {
            // Expand window: Add nums[j] to window logic here

            // Skip until window reaches size k
            if (j - i + 1 < k)
                continue;

            // Update result with business logic here

            // Maintain fixed window size
            // Remove nums[i] from window logic here
            i++;
        }

        return result;
    }
}