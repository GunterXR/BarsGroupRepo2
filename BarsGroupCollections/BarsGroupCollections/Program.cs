using System;

namespace BarsGroupCollections
{
    public class Program
    {
        static void Main(string[] args)
        {
            Entity entity1 = new Entity { Id = 1, ParentId = 0, Name = "Root entity" };
            Entity entity2 = new Entity { Id = 2, ParentId = 1, Name = "Child of 1 entity" };
            Entity entity3 = new Entity { Id = 3, ParentId = 1, Name = "Child of 1 entity" };
            Entity entity4 = new Entity { Id = 4, ParentId = 2, Name = "Child of 2 entity" };
            Entity entity5 = new Entity { Id = 5, ParentId = 4, Name = "Child of 4 entity" };

            List<Entity> listEntity = new List<Entity> { entity1, entity2, entity3, entity4, entity5 };

            Dictionary<int, List<Entity>> dictConverted = new Dictionary<int, List<Entity>>();
            dictConverted = GetGroupedEntities(listEntity);

            Dictionary<int, List<Entity>> GetGroupedEntities(List<Entity> listEntity)
            {
                return listEntity.GroupBy(p => p.ParentId).ToDictionary(k => k.Key, l => l.ToList());
            }

            foreach (var dictI in dictConverted)
            {
                Console.Write($"Key = {dictI.Key}, Value = List [ ");
                for (int j = 0; j < dictI.Value.Count; j++)
                {
                    Console.Write($"Entity[ Id = {dictI.Value[j].Id} ] ");
                }
                Console.WriteLine("]");
            }
        }
    }
}