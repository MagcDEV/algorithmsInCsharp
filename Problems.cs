using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorithmsInCsharp
{
    public class Problems
    {

        // https://leetcode.com/problems/two-sum/
        public int[] TwoSum(int[] nums, int target)
        {
            var dic = new Dictionary<int, int> { };
            for (int i = 0; i < nums.Length; i++)
            {
                if (dic.ContainsKey(target - nums[i]))
                {
                    return new int[] { dic[target - nums[i]], i };
                }
                else
                {
                    dic.TryAdd(nums[i], i);
                }
            }

            return new int[] { };

        }

        // https://leetcode.com/problems/top-k-frequent-words/description/
        public IList<string> TopKFrequentWords(string[] words, int k)
        {
            var dic = new Dictionary<string, int> { };

            for (int i = 0; i < words.Length; i++)
            {
                if (dic.ContainsKey(words[i]))
                {
                    dic[words[i]]++;
                }
                else
                {
                    dic.Add(words[i], 1);
                }
            }

            dic = dic.OrderByDescending(x => x.Value)
            .ThenBy(x => x.Key)
            .ToDictionary(x => x.Key, x => x.Value);

            return dic.Keys.Take(k).ToList();

        }

        // https://leetcode.com/problems/top-k-frequent-elements/description/
        public int[] TopKFrequentElements(int[] nums, int k)
        {
            var dic = new Dictionary<int, int> { };

            for (int i = 0; i < nums.Length; i++)
            {
                if (dic.ContainsKey(nums[i]))
                {
                    dic[nums[i]] = dic[nums[i]] + 1;
                }
                else
                {
                    dic.Add(nums[i], 1);
                }
            }

            dic = dic.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            return dic.Keys.Take(k).ToArray();

        }

        // https://leetcode.com/problems/group-anagrams/description/
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            var sortedDic = new Dictionary<string, IList<string>> { };
            for (int i = 0; i < strs.Length; i++)
            {
                var arr = strs[i].ToCharArray();
                Array.Sort(arr);
                var sorted = new string(arr);
                if (sortedDic.ContainsKey(sorted))
                {
                    sortedDic[sorted].Add(strs[i]);

                }
                else
                {
                    sortedDic.Add(sorted, new List<string> { strs[i] });
                }
            }

            return sortedDic.Values.ToList();

        }

    }
}
