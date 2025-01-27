namespace algorithmsInCsharp;

public class TwoPointers
{
    public static int[] TwoSum(int[] numbers, int target) {
        int l = 0;
        int r = numbers.Length - 1;

        foreach(var n in numbers)
        {
            int sum = numbers[l] + numbers[r];

            if(sum == target) return new int[]{l + 1, r + 1};

            if(sum < target)
            {
                l++;
            }
            else
            {
                r--;
            }           
        }
        
        return new int[]{};
        
    }

    public static IList<IList<int>> TreeSum(int[] nums)
    {
        IList<IList<int>> res = new List<IList<int>>();
        Array.Sort(nums);

        for(int i = 0; i < nums.Length; i++)
        {
            if(i > 0 && nums[i] == nums[i - 1]) continue;
            int l = i + 1;
            int r = nums.Length - 1;

            while(l < r)
            {
                int sum = nums[i] + nums[l] + nums[r];

                if(sum == 0)
                {
                    res.Add(new int[]{nums[i], nums[l], nums[r]});
                    l++;
                    while(l < r && nums[l] == nums[l - 1])
                    {
                        l++;
                    }

                }
                else if(sum < 0)
                {
                    l++;
                }
                else
                {
                    r--;
                }
            }
        }

        return res; 
    }

    public static int ThreeSumClosest(int[] nums, int target) {
    Array.Sort(nums);
    int closestSum = nums[0] + nums[1] + nums[2];

    for(int i = 0; i < nums.Length; i++)
    {
        if(i > 0 && nums[i] == nums[i - 1]) continue;

        int l = i + 1;
        int r = nums.Length - 1;

        while(l < r)
        {
            int sum = nums[i] + nums[l] + nums[r]; 

            if(sum == target) return sum;

            if(Math.Abs(sum - target) < Math.Abs(closestSum - target))
            {
                closestSum = sum;
            }

            if(sum < target)
            {
                l++;
            }
            else
            {
                r--;
            }

        }
    }

    return closestSum;

    }

    public static int MaxArea(int[] height) {
    int maxArea = 0;
    int l = 0;
    int r = height.Length - 1;

    while(l < r)
    {
        int currentArea = (r - l) * Math.Min(height[l], height[r]); 
        if(maxArea < currentArea)
        {
            maxArea = currentArea;
        }

        if(height[l] < height[r])
        {
            l++;
        }
        else
        {
            r--;
        }

    }

    return maxArea;
        
    }
}