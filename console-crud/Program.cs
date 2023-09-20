using System;
using System.Collections.Generic;

class Program
{
    class Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    static List<Entity> entities = new List<Entity>();
    static int nextId = 1;

    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the CRUD Console App!");
        Console.WriteLine("---------------------------------");

        while (true)
        {
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("1. Create an Entity");
            Console.WriteLine("2. Read All Entities");
            Console.WriteLine("3. Update an Entity by ID");
            Console.WriteLine("4. Delete an Entity by ID");
            Console.WriteLine("5. Exit");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        CreateEntity();
                        break;
                    case 2:
                        ReadAllEntities();
                        break;
                    case 3:
                        UpdateEntityById();
                        break;
                    case 4:
                        DeleteEntityById();
                        break;
                    case 5:
                        Console.WriteLine("Exiting the application. Goodbye!");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
    }

    static void CreateEntity()
    {
        Console.Write("Enter a name for the entity: ");
        string name = Console.ReadLine();
        Entity entity = new Entity { Id = nextId++, Name = name };
        entities.Add(entity);
        Console.WriteLine("Entity created successfully.");
    }

    static void ReadAllEntities()
    {
        if (entities.Count == 0)
        {
            Console.WriteLine("No entities found.");
        }
        else
        {
            Console.WriteLine("Entities:");
            foreach (var entity in entities)
            {
                Console.WriteLine($"ID: {entity.Id}, Name: {entity.Name}");
            }
        }
    }

    static void UpdateEntityById()
    {
        Console.Write("Enter the ID of the entity to update: ");
        if (int.TryParse(Console.ReadLine(), out int idToUpdate))
        {
            Entity entityToUpdate = entities.Find(e => e.Id == idToUpdate);
            if (entityToUpdate != null)
            {
                Console.Write($"Enter the new name for entity with ID {entityToUpdate.Id}: ");
                string newName = Console.ReadLine();
                entityToUpdate.Name = newName;
                Console.WriteLine("Entity updated successfully.");
            }
            else
            {
                Console.WriteLine("Entity not found with the provided ID.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid ID.");
        }
    }

    static void DeleteEntityById()
    {
        Console.Write("Enter the ID of the entity to delete: ");
        if (int.TryParse(Console.ReadLine(), out int idToDelete))
        {
            Entity entityToDelete = entities.Find(e => e.Id == idToDelete);
            if (entityToDelete != null)
            {
                entities.Remove(entityToDelete);
                Console.WriteLine("Entity deleted successfully.");
            }
            else
            {
                Console.WriteLine("Entity not found with the provided ID.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid ID.");
        }
    }
}
