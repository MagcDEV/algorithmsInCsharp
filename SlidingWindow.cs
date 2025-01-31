namespace algorithmsInCsharp;

public static class SlidingWindow
{
    /*
    121. Best Time to Buy and Sell Stock
    You are given an array prices where prices[i] is the price of a given stock on the ith day.

    You want to maximize your profit by choosing a single day to buy one stock and choosing a 
    different day in the future to sell that stock.

    Return the maximum profit you can achieve from this transaction. If you cannot achieve any profit, return 0.

    Example 1:

    Input: prices = [7,1,5,3,6,4]
    Output: 5
    Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
    Note that buying on day 2 and selling on day 1 is not allowed because you must buy before you sell.
    Example 2:

    Input: prices = [7,6,4,3,1]
    Output: 0
    Explanation: In this case, no transactions are done and the max profit = 0.
    */

    public static int MaxProfit(int[] prices) {
        int l = 0;
        int r = 1;
        int maxProfit = 0;

        while(r < prices.Length)
        {
            int currentProfit = prices[r] - prices[l];

            maxProfit = Math.Max(maxProfit, currentProfit);

            if(prices[r] < prices[l])
            {
                l = r;
                r++;
            }
            else
            {
                r++;
            }
        }

        return maxProfit;
    
    }

    /*
    3. Longest Substring Without Repeating Characters
    Given a string s, find the length of the longest 
    substring without repeating characters.

    Example 1:

    Input: s = "abcabcbb"
    Output: 3
    Explanation: The answer is "abc", with the length of 3.
    Example 2:

    Input: s = "bbbbb"
    Output: 1
    Explanation: The answer is "b", with the length of 1.
    Example 3:

    Input: s = "pwwkew"
    Output: 3
    Explanation: The answer is "wke", with the length of 3.
    Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.
    */
    public static int LengthOfLongestSubstring(string s) {
        var dicInd = new Dictionary<char, int>();
        int maxLength = 0, l = 0;

        for(int r = 0; r < s.Length; r++)
        {
            if(dicInd.ContainsKey(s[r]) && dicInd[s[r]] >= l)
            {
                l = dicInd[s[r]] + 1;
            }

            dicInd[s[r]] = r;

            maxLength = Math.Max(r - l + 1, maxLength);
        }

        return maxLength;
    
    }

    /*
    567. Permutation in String
    Given two strings s1 and s2, return true if s2 contains a 
    permutation
    of s1, or false otherwise.

    In other words, return true if one of s1's permutations 
    is the substring of s2.

    Example 1:

    Input: s1 = "ab", s2 = "eidbaooo"
    Output: true
    Explanation: s2 contains one permutation of s1 ("ba").
    Example 2:

    Input: s1 = "ab", s2 = "eidboaoo"
    Output: false
    */

    public static bool CheckInclusion(string s1, string s2) {
        if(s2.Length < s1.Length) return false;
        var s1Char = new Dictionary<char, int>();
        var s2Char = new Dictionary<char, int>();

        foreach(char c in s1)
        {
            if(!s1Char.ContainsKey(c)) s1Char[c] = 1;
            s1Char[c]++;
        }

        int l = 0, r = 0;

        while(r < s2.Length)
        {
            if(!s2Char.ContainsKey(s2[r])) s2Char[s2[r]] = 1;
            s2Char[s2[r]]++;

            if(r - l + 1 > s1.Length)
            {
                if(s2Char[s2[l]] == 1)
                {
                    s2Char.Remove(s2[l]);
                }
                else
                {
                    s2Char[s2[l]]--;
                }
                l++;
            }

            if(r - l + 1 == s1.Length)
            {
                if(CheckEqual(s1Char, s2Char)) return true;
            }            r++;
        }

        return false;
    }

    public static bool CheckEqual(Dictionary<char, int> a, Dictionary<char, int> b)
    {
        foreach(char c in a.Keys)
        {
            if(!b.ContainsKey(c)) return false;
            if(b[c] !=  a[c]) return false;
        }

        return true;
    }
    
}
