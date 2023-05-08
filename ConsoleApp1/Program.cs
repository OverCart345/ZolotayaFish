using System.Linq;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "D:\\C#\\ConsoleApp1\\ConsoleApp1\\input.txt";
            
            StreamReader reader = new StreamReader(path);

            int word_Count = int.Parse(reader.ReadLine());
            string[] words = new string[word_Count];

            Dictionary<string, int> start_Overload = new Dictionary<string, int>();
            Dictionary<string, int> end_Overload = new Dictionary<string, int>();

            for (int i = 0;i < word_Count; i++) 
            {
                words[i] = reader.ReadLine();

                string first = words[i][0].ToString();
                string last = words[i][words[i].Length - 1].ToString();

                if (start_Overload.ContainsKey(first))
                {
                    start_Overload[first]++;
                }
                else 
                {
                    start_Overload.Add(first, 1);
                }

                if (end_Overload.ContainsKey(last))
                {
                    end_Overload[last]++;
                }
                else
                {
                    end_Overload.Add(last, 1);
                }
            }

            


            int start_Count = int.Parse(reader.ReadLine());
            Dictionary<string, int> start = new Dictionary<string, int>();

            for (int i = 0; i < start_Count; i++) 
            {
                string[] temp = reader.ReadLine().Split(' ');
                start.Add(temp[0], int.Parse(temp[1]));
            }


            int end_Count = int.Parse(reader.ReadLine());
            Dictionary<string, int> end = new Dictionary<string, int>();

            for (int i = 0; i < end_Count; i++)
            {
                string[] temp = reader.ReadLine().Split(' ');
                end.Add(temp[0], int.Parse(temp[1]));
            }

            List<string> used_Words = new List<string>();


            for (int i = 0; i < word_Count; i++) 
            {
                string first = words[i][0].ToString();
                string last = words[i][words[i].Length - 1].ToString();

                if (start.ContainsKey(first) && end.ContainsKey(last) && start_Overload.ContainsKey(first) && end_Overload.ContainsKey(last) && !used_Words.Contains(words[i]))
                {
                    if (start_Overload[first] > start[first] && end_Overload[last] > end[last]) 
                    {
                        used_Words.Add(words[i]);
                        start_Overload[first]--;
                        end_Overload[last]--;
                    
                    }
                
                }

            }

            bool again;
            int counter = 0;
            int gamma = 1;

            int j = 0;

            do
            {
                again = true;
                bool skip = false;

                for (int i = 0; i < word_Count; i++) 
                {
                    string first = words[i][0].ToString();
                    string last = words[i][words[i].Length - 1].ToString();

                    if (start.ContainsKey(first) && end.ContainsKey(last) && !used_Words.Contains(words[i]))
                    {
                        if (start[first] > gamma && end[last] > gamma)
                        {
                            again = false;
                          // skip = true;
                            counter++;

                            used_Words.Add(words[i]);
                            
                            start[first] -= 1;
                            end[last] -= 1;

                            

                        }
                    }
                   // Console.WriteLine($"{j}||{words[i]} | {start["a"]} {start["b"]} ... {end["a"]} {end["b"]}");
                }

                if (!skip && gamma == 1)
                {
                    again = false;
                    gamma = 0;
                }
                j++;

            } while (!again);

            Console.WriteLine(counter);

            Console.ReadKey();
        }
    }
}