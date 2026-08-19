using System.Collections.Generic;
using System;
using System.Linq;
using System.Reflection;
using System.Globalization;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;

public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        int[] ans= new int[2]{0,0};
        foreach(int num in nums){
            List<int> nums_list = nums.ToList();
            nums_list.Remove(num);
            int[] nums1 = nums_list.ToArray();
            
            if( Array.IndexOf(nums1,target-num)!=-1){
                
                // for (int i = 0; i < nums.Length; i++)
                // {
                //     Console.WriteLine(nums[i]);
                // }
                
                ans = new int[2] {Array.IndexOf(nums,num),Array.IndexOf(nums,target-num)};
                
                break;
                
            }
            continue;
            
            
        }
        return ans;

    }

    public bool IsPalindrome(int x) {
        bool IsPalindrome=false;
        char[] x_array= x.ToString().ToCharArray();
        
        int lenght=x_array.Length;
        
        int midIndex=(int)lenght/2;
        if (lenght == 1)
        {
            IsPalindrome=true;
        }
        else if (lenght % 2 != 0)
        {
            for(int i = 1; i <= (int)lenght/2; i++)
            {
                if (x_array[midIndex - i] == x_array[midIndex + i])
                {
                    IsPalindrome=true;
                }

                else
                {
                     IsPalindrome=false;
                    break;
                }
                
            }
        }
        else if (lenght % 2 == 0)
        {
            for(int i=1; i <= (int)lenght / 2; i++)
            {
                if (x_array[midIndex+i-1] == x_array[midIndex - i])
                {
                    IsPalindrome=true;
                }
                else
                {
                    IsPalindrome=false;
                    break;
                }
            }
        }
        
        return IsPalindrome;
        
        
        
    }

    public string LongestCommonPrefix(string[] strs) {
        int ansIndex=-1;

        
        
        for(int index=0; index <= strs[0].Length; index++)
        {
            for(int i = 1; i <= strs.Length; i++)
            {
                if ( strs[0].Length>strs[i].Length || strs[i][index] != strs[0][index])
                {
                    break;
                }
            }
            ansIndex=index;
        }
        
        return strs[0].Substring(0,ansIndex);
        
        
        

    }
    public int RemoveDuplicates(int[] nums) {
        
        
        List<int> checkedList= new List<int>();
        int uniqueNumbers=0;
        
        for(int i = 0; i<nums.Length; i++)
        {
            if (!checkedList.Contains(nums[i]))
            {
                uniqueNumbers+=1;
                checkedList.Add(nums[i]);
            }
        }
        for(int j=0; j< checkedList.Count; j++)
        {
            {
                nums[j]=checkedList[j];
            }
        }
        
        return uniqueNumbers;
    }
    public int RemoveDuplicatesGood(int[] nums) {
        
        
        
        int uniqueNumbers=0;
        int currentNumber=int.MinValue;
        
        for(int i = 0; i<nums.Length; i++)
        {
            if (nums[i]!=currentNumber)
            {
                uniqueNumbers++;
                nums[uniqueNumbers-1]=nums[i];
                
            }
            currentNumber=nums[i];
            
        }
        
        
        return uniqueNumbers;
    }

    public int RemoveElement(int[] nums, int val) {
        int k=0;
        for(int i=0; i<nums.Length; i++)
        {
            if (nums[i] != val)
            {
                nums[k]=nums[i];
                k++;

            }
        }
        return k;
    }
    public int SearchInsert(int[] nums, int target) {
        int k=0;
        for(int i=0 ; i < nums.Length; i++)
        {
            
            if (i == nums.Length - 1 && target>nums[i])
            {
                k=nums.Length;
                break;
            }
            if (nums[i] >= target)
            {
                k=i;
                break;
            }
            
            
        }
        return k;
        
    }

    public int[] PlusOne(int[] digits) {
        int[] ansDigits=digits;
        
        for(int i = digits.Length - 1; i >= 0; i--)
        {
            if (ansDigits[i] != 9)
            {
                ansDigits[i]++;
                break;
            }
            else
            {
                ansDigits[i]=0;
                if (i == 0)
                {
                    int[] extendedAnsDigits = new int[digits.Length+1];
                    for (int j=0; j < extendedAnsDigits.Length; j++)
                    {
                        if (j == 0)
                        {
                            extendedAnsDigits[0]=1;
                        }
                        else
                        {
                            extendedAnsDigits[j]=0;
                        }
                    }
                    ansDigits=extendedAnsDigits;
                }
                
            }
        }
            return ansDigits;
    }

    public IList<int> GetRow(int rowIndex)
        {
            var results = new List<IList<int>>();
            if (rowIndex <= 0) return results[rowIndex-1];
            results.Add(new List<int>(1) { 1 });
            if (rowIndex == 1) return results[rowIndex-1];
            results.Add(new List<int>(2) { 1, 1 });
            if (rowIndex == 2) return results[rowIndex-1];

            for (int i = 2; i < rowIndex; i++)
            {
                var result = new List<int>(i + 1);
                result.Add(1);
                for (int j = 1; j < i; j++)
                {
                    result.Add(results[i - 1][j - 1] + results[i - 1][j]);
                }
                result.Add(1);
                results.Add(result);
            }
            return results[rowIndex-1];
        }



    
        
        
    



    
}


