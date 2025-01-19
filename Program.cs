// See https://aka.ms/new-console-template for more information

using algorithmsInCsharp;

Console.WriteLine("Hello, World!");

var nums = new int[] {1,1,1, 3,3, 4 };
var target = 6;

var result = Problems.TopKFrequent(nums, 2);

foreach (var item in result)
{
    Console.WriteLine(item);
};
