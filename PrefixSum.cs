namespace algorithmsInCsharp;

public class PrefixSum
{
    /*
     *
         sum(l, r) = prefix[r] - prefix[l-1]
     * 
     */

    // 1. TwoSums
    // 128. Longest Consecutive Sequence
    // 525. Contiguous Array
    // 560. Subarray Sum Equals K
    // 974. Subarray Sums Divisible by K
    // 303. Range Sum Query - Immutable

    /*
     1. TwoSums
    Given an array of integers nums and an integer target, 
    return indices of the two numbers such that they add up to target.

    You may assume that each input would have exactly one solution, 
    and you may not use the same element twice.

    You can return the answer in any order.
    
    Example 1:
    Input: nums = [2,7,11,15], target = 9
    Output: [0,1]
    Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].
    Example 2:

    Input: nums = [3,2,4], target = 6
    Output: [1,2]
    Example 3:

    Input: nums = [3,3], target = 6
    Output: [0,1]
     */
    public static int[] TwoSum(int[] nums, int target)
    {
        var dic = new Dictionary<int, int> { };

        for (int i = 0; i < nums.Length; i++)
        {
            int temp = target - nums[i];
            if (dic.TryGetValue(temp, out int value))
            {
                return [value, i];

            }
            else
            {
                dic.TryAdd(nums[i], i);
            }

        }

        return [];
    }

    /*
    128. Longest Consecutive Sequence
    Given an unsorted array of integers nums, 
    return the length of the longest consecutive elements sequence.

    You must write an algorithm that runs in O(n) time.

    Example 1:

    Input: nums = [100,4,200,1,3,2]
    Output: 4
    Explanation: The longest consecutive elements sequence is [1, 2, 3, 4]. Therefore its length is 4.
    Example 2:

    Input: nums = [0,3,7,2,5,8,4,6,0,1]
    Output: 9
     */
    public static int LongestConsecutive(int[] nums)
    {
        HashSet<int> set = new(nums);
        int max = 0;

        foreach (int s in set)
        {
            if (set.Contains(s - 1)) continue;

            int length = 0;
            while (set.Contains(s + length))
            {
                length++;
            }

            max = Math.Max(max, length);
        }

        return max;
    }

    /*
    // 525. Contiguous Array
    Given a binary array nums, return the maximum 
    length of a contiguous subarray with an equal number of 0 and 1.

    Example 1:

    Input: nums = [0,1]
    Output: 2
    Explanation: [0, 1] is the longest contiguous subarray with an equal number of 0 and 1.
    Example 2:

    Input: nums = [0,1,0]
    Output: 2
    Explanation: [0, 1] (or [1, 0]) is a longest contiguous subarray with equal number of 0 and 1.
     */
    public static int FindMaxLength(int[] nums)
    {
        Dictionary<int, int> dic = new();
        dic[0] = -1;
        int ones = 0, zeroes = 0, max = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 0) zeroes++; else ones++;
            int diff = zeroes - ones;

            if (dic.ContainsKey(diff))
            {
                max = Math.Max(max, i - dic[diff]);

            }
            else
            {
                dic.Add(diff, i);
            }
        }

        return max;
    }

    /*
    // 560. Subarray Sum Equals K
    Given an array of integers nums and an integer k, 
    return the total number of subarrays whose sum equals to k.

    A subarray is a contiguous non-empty sequence of elements within an array.

    Example 1:

    Input: nums = [1,1,1], k = 2
    Output: 2
    Example 2:

    Input: nums = [1,2,3], k = 3
    Output: 2
     */
    public static int SubarraySum(int[] nums, int k)
    {
        Dictionary<int, int> prefixSumCount = new Dictionary<int, int>();
        prefixSumCount[0] = 1; // To handle the case when subarray starts from index 0

        int currentPrefixSum = 0;
        int count = 0;

        foreach (int num in nums)
        {
            currentPrefixSum += num;

            if (prefixSumCount.ContainsKey(currentPrefixSum - k))
            {
                count += prefixSumCount[currentPrefixSum - k];
            }

            if (prefixSumCount.ContainsKey(currentPrefixSum))
            {
                prefixSumCount[currentPrefixSum]++;
            }
            else
            {
                prefixSumCount[currentPrefixSum] = 1;
            }
        }

        return count;

    }

    /*
    // 974. Subarray Sums Divisible by K
    Given an integer array nums and an integer k, 
    return the number of non-empty subarrays that have a sum divisible by k.

    A subarray is a contiguous part of an array.
    Input: nums = [4,5,0,-2,-3,1], k = 5
    Output: 7
    Explanation: There are 7 subarrays with a sum divisible by k = 5:
    [4, 5, 0, -2, -3, 1], [5], [5, 0], [5, 0, -2, -3], [0], [0, -2, -3], [-2, -3]
    Example 2:

    Input: nums = [5], k = 9
    Output: 0
     */

    public int SubarraysDivByK(int[] nums, int k)
    {
        int prefixSum = 0;
        int counter = 0;
        Dictionary<int, int> dic = new();
        dic[0] = 1;

        for (int i = 0; i < nums.Length; i++)
        {
            prefixSum += nums[i];
            int remainder = prefixSum % k;

            if (remainder < 0)
            {
                remainder += k;
            }

            if (dic.ContainsKey(remainder))
            {
                counter += dic[remainder];
                dic[remainder]++;
            }
            else
            {
                dic[remainder] = 1;
            }
        }

        return counter;

    }

    /*
    //  303. Range Sum Query - Immutable
    Given an integer array nums, handle multiple queries of the following type:

    Calculate the sum of the elements of nums between indices left and right inclusive where left <= right.
    Implement the NumArray class:

    NumArray(int[] nums) Initializes the object with the integer array nums.
    int sumRange(int left, int right) Returns the sum of the elements of nums between 
    indices left and right inclusive (i.e. nums[left] + nums[left + 1] + ... + nums[right]).
    */
    public class NumArray
    {
        private int[] prefixSum;

        public NumArray(int[] nums)
        {
            int sum = 0;
            prefixSum = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                prefixSum[i] = sum;
            }

        }

        public int SumRange(int left, int right)
        {
            if (left == 0) return prefixSum[right];
            return prefixSum[right] - prefixSum[left - 1];

        }
    }

}

