using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorithmsInCsharp
{
    public class Problems
    {
        public static int[] BruteForceTwoSum(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1 ; j < nums.Length; j++)
                {
                    if((nums[i] + nums[j]) == target)
                    {
                        return [i, j];
                    }
                }
            }

            return [];

        }

        public static int[] TwoSum(int[] nums, int target)
        {
            var pairDic = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (pairDic.ContainsKey(target - nums[i]))
                {
                    return new int[] { pairDic[target - nums[i]], i };
                }
                pairDic.TryAdd(nums[i], i);
            }
            return new int[] { };
        }
    }
}
