string folderPath = @"C:\data";
string fileName = "shoppingList.txt";
string filePath = Path.Combine(folderPath, fileName);
List<string> myShoppingList = new List<string>();

if(File.Exists(filePath))
{
    myShoppingList = GetItemsFromUser();
    //ShowItemsFromList(myShoppingList);
    File.WriteAllLines(filePath, myShoppingList);
}
else
{
    File.Create(filePath).Close(); //NB! fail tuleb kinni panna
    Console.WriteLine($"File {fileName} has been created.");
    myShoppingList = GetItemsFromUser();
    File.WriteAllLines(filePath, myShoppingList);
}



static List<string> GetItemsFromUser()
{
    List<string> userList = new List<string>(); //listid on paindlikumad - saan lisada ja eemaldada sama tüüpi objekte

    while (true)
    {
        Console.WriteLine("Add an item (add)/ Exit (exit)");
        string userCoice = Console.ReadLine();

        if (userCoice == "add")
        {
            Console.WriteLine("Enter an item");
            string userItem = Console.ReadLine();
            userList.Add(userItem);
        }
        else
        {
            Console.WriteLine("Bye!");
            break;
        }
    }
    return userList;
}

static void ShowItemsFromList(List<string> someList)
{
    Console.Clear();
    int listLenght = someList.Count;
    Console.WriteLine($"You have added {listLenght} items to your shopping list.");

    int i = 1;
    foreach (string item in someList)
    {
        Console.WriteLine($"{i}. {item}");
        i++;
    }
}
