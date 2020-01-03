using DynamicSystem.Models;
using System;
using System.Collections.Generic;

namespace DynamicSystem.Services
{
    public class TopologicalSort
    {
        public static List<string> Sort(IEnumerable<Item> source, Func<Item, IEnumerable<Item>> getDependencies)
        {
            var sorted = new List<Item>();
            var vistied = new Dictionary<string, bool>();
            var result = new List<string>();

            foreach (var item in source)
            {
                Visit(item, getDependencies, sorted, vistied);
            }

            foreach (var item in sorted)
            {
                result.Add(item.Name);
            }

            return result;
        }

        public static void Visit(Item item, Func<Item, IEnumerable<Item>> getDependencies, List<Item> sorted, Dictionary<string, bool> visited)
        {
            bool inProcess;
            bool alreadyVisited = visited.TryGetValue(item.Name, out inProcess); //Kiểm tra value key 

            if (alreadyVisited)
            {
                if (inProcess)
                {
                    throw new ArgumentException("Cylic dependency found");
                }
            }
            else
            {
                visited[item.Name] = true; //Đánh dấu value tạm thời bằng true

                var dependencies = getDependencies(item);
                if (dependencies != null)
                {
                    foreach (var dependency in dependencies)
                    {
                        Visit(dependency, getDependencies, sorted, visited);
                    }
                }

                visited[item.Name] = false;
                sorted.Add(item);
            }
        }

    }
}
