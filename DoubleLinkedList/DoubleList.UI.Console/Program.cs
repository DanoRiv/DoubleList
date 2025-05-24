using DoubleList;

var list = new DoublyLinkedList<string>();
var opc = "0";

do
{
    opc = Menu();
    switch (opc)
    {
        case "1":
            Console.Write("Enter the data to insert in ascending order: ");
            var data = Console.ReadLine();
            if (data != null)
            {
                list.AddAscending(data);
            }
            break;
        case "2":
            Console.WriteLine(list.GetForward());
            break;

        case "3":
            Console.WriteLine(list.GetBackward());
            break;
        case "4":
            list.OrderDescending();
            break;
        case "5":
            Console.WriteLine(list.GetModes());
            break;
        case "6":
            Console.WriteLine(list.GetFrequencyGraph());
            break;
        case "7":
            Console.Write("Enter the data to search: ");
            var searchData = Console.ReadLine();
            if (searchData != null)
            {
                var found = list.Exists(searchData);
                Console.WriteLine(found ? $"Data: {searchData} exists in the list." : $"Data: {searchData} does not exist in the list.");
            }
            break;
        case "8":
            Console.Write("Enter the data to remove: ");
            var remove = Console.ReadLine();
            if (remove != null)
            {
                list.Remove(remove);
                Console.WriteLine("Item removed.");
            }
            break;
        case "9":
            Console.Write("Enter the data to remove all occurrences: ");
            var toRemove = Console.ReadLine();
            if (toRemove != null)
            {
                list.RemoveAll(toRemove);
                Console.WriteLine($"All {toRemove} occurrences removed.");
            }
            break;
    }
}
while (opc != "0");

string Menu()
{
    Console.WriteLine("1. Insert at beginning");
    Console.WriteLine("2. Show list forward");
    Console.WriteLine("3. Show list backward");
    Console.WriteLine("4. Order list in descending order");
    Console.WriteLine("5. Show modes");
    Console.WriteLine("6. Show frequency graph");
    Console.WriteLine("7. Search for an element");
    Console.WriteLine("8. Remove one occurrence");
    Console.WriteLine("9. Remove all occurrences");
    Console.WriteLine("0. Exit");
    Console.Write("Choose an option: ");
    return Console.ReadLine() ?? "0";
}

