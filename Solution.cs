using System.Collections.Generic;
using System;
using System.Text;
using System.Linq;
using System.Reflection;
using System.Globalization;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices.Marshalling;
using System.Runtime.CompilerServices;


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

    public int RomanToInt(string s) {
        int answer=0;
        for(int i=0;i<s.Length;i++)
        {
            if (s[i] == 'M')
            {
                answer+=1000;
                continue;
            }

            if (s[i] == 'D')
            {
                answer+=500;
                continue;
            }
            if (s[i] == 'C')
            {
                if (i != s.Length-1)
                {
                    if (s[i + 1] == 'D')
                    {
                        answer+=400;
                        i++;
                        continue;
                    }
                    if (s[i + 1] == 'M')
                    {
                        answer+=900;
                        i++;
                        continue;
                    }
                }
                
                answer+=100;
                continue;
            }
            if (s[i] == 'L')
            {
                answer+=50;
            }
            if (s[i] == 'X')
            {
                if (i != s.Length-1)
                {
                    if (s[i + 1] == 'L')
                    {
                        answer+=40;
                        i++;
                        continue;
                    }
                    if (s[i + 1] == 'C')
                    {
                        answer+=90;
                        i++;
                        continue;
                    }
                }
                
                answer+=10;
                continue;
            }
            if (s[i] == 'V')
            {
                answer+=5;
            }
            if (s[i] == 'I')
            {
                if (i != s.Length-1)
                {
                    if (s[i + 1] == 'V')
                    {
                        answer+=4;
                        i++;
                        continue;
                    }
                    if (s[i + 1] == 'X')
                    {
                        answer+=9;
                        i++;
                        continue;
                    }
                }
                
                answer+=1;
                continue;
            }
            
        }
        return answer;
    }

    public int LengthOfLastWord(string s) {
        int ans=0;
        bool isCounting=false;
        for(int i=s.Length-1; i >= 0; i--)
        {
            if(s[i]!=' ')
            {
                isCounting=true;
                ans++;
            }
            if(s[i]==' ' && isCounting)
            {
                break;
            }

        }
        return ans;
    }

    
    public string AddBinaryAttempt(string a, string b) {
        return IntToBinary(BinaryToInt(a)+BinaryToInt(b));
    }
    public BigInteger BinaryToInt(string x)
    {
        BigInteger output=0;
        int var=0;
        int posValue=0;
        for(int i=0; i < x.Length; i++)
        {
            var=(int) Math.Pow(2,i);
            posValue=x[x.Length-1-i]-'0';
            output+=posValue*var;
        }
        return output;
        
    }

    public string IntToBinary(BigInteger x)
    {
        if(x==0) return "0";
        List<BigInteger> remainderList=[];
        BigInteger currentQuotient=x;
        while (true)
        {
            if (currentQuotient != 0)
            {
                remainderList.Add(currentQuotient%2);
            } 
            else
            {
                break;
            }
            currentQuotient=currentQuotient/2;
            
        }
        
        remainderList.Reverse();
        return string.Join("", remainderList);
    }
    
    public bool IsPalindrome(string s) {
        List<char> chars = new List<char>();
        bool ans=false;
        foreach(char c in s)
        {
            if((c >= 'a' && c <= 'z')||(c>='0' && c<= '9') )
            {
              chars.Add(c);  
            }
            if (c >= 'A' && c <= 'Z')
            {
                chars.Add( (char)(c + ('a' - 'A')));
            }
    
        }
        
        
        List<char> originalList=new List<char>(chars);
        chars.Reverse();
        for(int i=0; i<originalList.Count;i++)
        {
            if (originalList[i] != chars[i])
            {
                ans = false;
                break;
            }
            else
            {
                ans=true;
            }
        }
        if (chars.Count == 0 || chars.Count == 1)
        {
            ans=true;
        }
        return ans;
        
        
        
        
    }

    public string ConvertToTitle(int columnNumber) {
        StringBuilder sb = new StringBuilder("");
        if (columnNumber <= 26)
        {
            sb.Append((char)('A'+ columnNumber-1));
            return sb.ToString();
        }

        while (true)
        {
            int i=0;
            if(columnNumber  %  (int)Math.Pow(26,i) <= 26)
            {
                
            }
            i++;
            

        }
        
    }

    public int TitleToNumber(string columnTitle) {
        int n=0;
        foreach(char c in columnTitle)
        {
            n*=26;
            n+=c-'A'+1;
            
        }
        return n;
        
    }

    public bool IsIsomorphicAttempt1(string s, string t) {
        Dictionary<char,char> dict= new Dictionary<char, char>();
        
        if (s.Length != t.Length)
        {
            return false;
        }
        for(int i=0; i < s.Length; i++)
        {
            if (dict.ContainsKey(s[i]) || dict.ContainsValue(t[i]))
            {
                if(!dict.ContainsKey(s[i]) || !dict.ContainsValue(t[i]))
                {
                    return false;
                }
                if (dict[s[i]] != t[i])
                {
                    return false;
                }
            }
            dict[s[i]]=t[i];
            
        }
        return true;



    }
    public bool IsIsomorphicAttempt2(string s, string t)
    {
        if (s.Length != t.Length)
            return false;

        Dictionary<char, char> dict = new Dictionary<char, char>();

        for (int i = 0; i < s.Length; i++)
        {
            if (dict.ContainsKey(s[i]))
            {
                if (dict[s[i]] != t[i])
                    return false;
            }
            else
            {
                if (dict.ContainsValue(t[i]))
                    return false;

                dict.Add(s[i], t[i]);
            }
        }

        return true;
    }
    public bool IsIsomorphicSolution(string s, string t)
        {
            if (s.Length != t.Length) return false;

            var map = new Dictionary<char, char>(26);
            var visited = new HashSet<char>(26);
            for (int i = 0; i < s.Length; i++)
            {
                if (map.ContainsKey(s[i]))
                {
                    if (map[s[i]] != t[i]) return false;
                }
                else
                {
                    if (visited.Contains(t[i])) return false;
                    map.Add(s[i], t[i]);
                    visited.Add(t[i]);
                }
            }
            return true;
        }

    public int SingleNumberTry1(int[] nums) {
        int ans=0;
        Dictionary<int,int> dict = new Dictionary<int, int>();
        for(int i = 0; i <= nums.Length-1; i++)
        {
            if (!dict.ContainsKey(nums[i]))
            {
                dict[nums[i]]=1;
            }
            else
            {
                dict[nums[i]]++;
            }
        }
        
        foreach(KeyValuePair<int,int> i in dict)
        {
            if (i.Value == 1)
            {
                ans=i.Key;
            }
            
        }
        return ans;
    }
    public int SingleNumberTry2(int[] nums) {
        
        List<int> list=new List<int>();
        Dictionary<int,int> dict = new Dictionary<int, int>();
        for(int i = 0; i <= nums.Length-1; i++)
        {
            if (!list.Contains(nums[i]))
            {
                list.Add(nums[i]);
            }
            else
            {
                list.Remove(nums[i]);
            }
        }
        
        
        return list[0];
    }
    public int SingleNumberTry3(int[] nums) {
        int ans=0;
        
        Array.Sort(nums);
        for(int i = 0; i < nums.Length; i=i+2)
        {
            if (i == nums.Length - 1)
            {
                ans=nums[i];
                break;
            }
            if (nums[i] != nums[i+1])
            {
                ans=nums[i];
                break;
                
            }
            
        }
        return ans;
    }
    public int SingleNumberSolution(int[] nums) {
        var ans=0;
        foreach(int i in nums)
        {
            ans^=i;
        }
        return ans;
        
    }

    public int MajorityElementTry1(int[] nums) {
        int ans=0;
        Dictionary<int,int> dict = new Dictionary<int, int>();
        foreach(int i in nums)
        {
            if (dict.ContainsKey(i))
            {
                dict[i]++;
            }
            else
            {
                dict[i]=1;
            }
        }
        foreach(KeyValuePair<int,int> j in dict)
        {
            if (j.Value > nums.Length / 2)
            {
                ans=j.Key;
            }
        }
        return ans;

        
    }

    public int MajorityElementTry2(int[] nums)
    {
        
        Array.Sort(nums);
        if (nums.Length % 2 == 0)
        {
            return nums[nums.Length/2+1];
        }
        else
        {
            return nums[nums.Length/2];
        }
    }
    public int MajorityElement(int[] nums) {
        int candidate=0;
        int count=0;
        foreach(int num in nums)
        {
            if (count == 0)
            {
                candidate=num;
            }
            if (num == candidate)
            {
                count++;
            }
            else
            {
                count--;
            }
        }
        return candidate;
        

        
    }
    public bool ContainsDuplicateTry(int[] nums) {
        Dictionary<int,int> dict = new Dictionary<int, int>();
        foreach(int num in nums)
        {
            if (dict.ContainsKey(num))
            {
                dict[num]++;
            }
            else
            {
                dict[num]=1;
            }
        }
        foreach(KeyValuePair<int,int> i in dict)
        {
            if (i.Value>=2) return true;
        }
        return false;
    }
    public bool ContainsDuplicate(int[] nums)
    {
        
        HashSet<int> set = new HashSet<int>();
        foreach(int num in nums)
        {
            if (!set.Add(num))
            {
                return true;
            }
            
        }
        return false;
        

    }

    public bool IsRectangleOverlap(int[] rec1, int[] rec2) {

        if(rec1[0]<=rec2[0] && rec2[0]<rec1[2] && rec1[2]<=rec2[2])
        {

            if(rec1[1]<=rec2[1] && rec2[1]<rec1[3]&& rec1[3] <= rec2[3])
            {
                return true;
            }
            if(rec2[1]<=rec1[1] && rec1[3] <= rec2[3])
            {
                return true;
            }
            if(rec1[1]<=rec2[1] && rec2[3] <= rec1[3])
            {
                return true;
            }
            if(rec2[1]<=rec1[1] && rec1[1]<rec2[3]&& rec2[3] <= rec1[3])
            {
                return true;
            }

        }
        if(rec1[0]<=rec2[0]  && rec2[2]<=rec1[2])
        {

            if(rec1[1]<=rec2[1] && rec2[1]<rec1[3]&& rec1[3] <= rec2[3])
            {
                return true;
            }
            if(rec2[1]<=rec1[1] && rec1[3] <= rec2[3])
            {
                return true;
            }
            if(rec1[1]<=rec2[1] && rec2[3] <= rec1[3])
            {
                return true;
            }
            if(rec2[1]<=rec1[1] && rec1[1]<rec2[3]&& rec2[3] <= rec1[3])
            {
                return true;
            }

        }
        if(rec2[0]<=rec1[0] && rec1[0]<rec2[2] && rec2[2]<=rec1[2])
        {

            if(rec1[1]<=rec2[1] && rec2[1]<rec1[3]&& rec1[3] <= rec2[3])
            {
                return true;
            }
            if(rec2[1]<=rec1[1] && rec1[3] <= rec2[3])
            {
                return true;
            }
            if(rec1[1]<=rec2[1] && rec2[3] <= rec1[3])
            {
                return true;
            }
            if(rec2[1]<=rec1[1] && rec1[1]<rec2[3]&& rec2[3] <= rec1[3])
            {
                return true;
            }

        }
        if(rec2[0]<=rec1[0]  && rec1[2]<=rec2[2])
        {

            if(rec1[1]<=rec2[1] && rec2[1]<rec1[3]&& rec1[3] <= rec2[3])
            {
                return true;
            }
            if(rec2[1]<=rec1[1] && rec1[3] <= rec2[3])
            {
                return true;
            }
            if(rec1[1]<=rec2[1] && rec2[3] <= rec1[3])
            {
                return true;
            }
            if(rec2[1]<=rec1[1] && rec1[1]<rec2[3]&& rec2[3] <= rec1[3])
            {
                return true;
            }

        }
        return false;

        
        
    }






    public int countDigit(int n) {
        int counter=0;
        while(true){
            if(n/10==0){
                counter++;
                break;
            }
            else{
                counter++;
                n/=10;
            }

        }
        return counter;
    }
    public int countDigitOptimal(int n) {
        
        return (int)Math.Log10(n)+1;
    }
    public int Reverse(int n) {
        
        int negativeFactor=1;
        
        if(n<0) negativeFactor=-1;
        int n1=Math.Abs(n);
        var lenght=(int)Math.Log10(n1)+1;
        
        var ans=(long)0;
        for(int i = 0; i < lenght; i++)
        {
            ans+=(long)Math.Pow(10,lenght-i-1)*(n1%10);
            n1/=10;
            
        }
        
        
        
        return (int) ans*negativeFactor;

    }
    public int ReverseOptimal(int x) {
        int reverse = 0;
        
        while (x != 0) {
            int pop = x % 10;
            x /= 10;
            
            if (reverse > int.MaxValue / 10 || (reverse == int.MaxValue / 10 && pop > 7)) 
                return 0;
            if (reverse < int.MinValue / 10 || (reverse == int.MinValue / 10 && pop < -8)) 
                return 0;
                
            reverse = reverse * 10 + pop;
        }
        
        return reverse;
    }

    public int Fib(int n) {
        if(n==0)return 0;
        if(n==1)return 1;
        return Fib(n-1) + Fib(n-2);
        
        
    }


    public bool Check(int[] nums) {
        bool ans=false;
        bool switched=false;

        for (int i=0 ; i < nums.Length; i++)
        {
            
            if(nums.Length==1) 
            {
                ans=true;
                break;
            }
            if(nums.Length==2) 
            {
                ans=true;
                break;
            }
            if(i==nums.Length - 1) break;
            if (i == nums.Length - 2)
                {
                    ans=true;
                    break;
                }

            if (i == 0)
            {
                if (nums[i] <= nums[i + 1])
                {
                    ans=true;
                }
                else
                {
                    ans=false;
                    break;
                }
            }
            else
            {
                if (!switched)
                {
                    if(nums[i]<=nums[i+1])
                    {
                        if(nums[i + 1] <= nums[i + 2])
                        {
                            ans=true;
                        }
                        else
                        {
                            switched=true;
                            continue;
                        }
                        
                    }
                    else
                    {
                        ans=false;
                        break;
                    }
                }
                else
                {
                    if(nums[i + 1] <= nums[i + 2])
                    {
                        ans=true;
                    }
                    else
                    {
                        ans=false;
                        break;
                    }
                }
            
            }
            
            
        }
        return ans;
    }

    public bool Check1(int[] nums)
    {
        bool ans=true;
        for(int i=0; i < nums.Length; i++)
        {
            if (nums[(i + 1)%nums.Length] < nums[i])
            {
                ans=false;
            }
            ans=true;
        }
        return ans;
    }







    





    



    
        
        
    



    
}


