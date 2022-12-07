var input = await File.ReadAllLinesAsync(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Input\Day07.txt"));

var root = new Directory("/");
var cd = root;
for (int i = 1; i < input.Length; i++)
{
    var tokens = input[i].Split(' ');
    if (tokens[0] == "$")
    {
        if (tokens[1] == "cd")
        {
            if (tokens[2] == "..")
            {
                cd = cd.ParentDirectory;
            }
            else if (tokens[2] == "/")
            {
                cd = new Directory(tokens[2]);
            }
            else
            {
                cd = cd.Subdirectories.Single(x => x.Name == tokens[2]);
            }
        }
        else if (tokens[1] == "ls")
        {
            continue;
        }
    } 
    else if (tokens[0] == "dir")
    {
        cd.Subdirectories.Add(new Directory(tokens[1], cd));
    }
    else // a file with size
    {
        
        var size = int.Parse(tokens[0]);
        var temp = cd;
        do
        {
            temp.Size += size;
            temp = temp.ParentDirectory;
        } while (temp != null);
    }
}

// Part 1
//var sum = 0;
//Visit(root);
//Console.WriteLine(sum);

//void Visit(Directory dir)
//{
//    if (dir.Size <= 100000)
//    {
//        sum += dir.Size;
//    }

//    foreach(var subdir in dir.Subdirectories)
//    {
//        Visit(subdir);
//    }
//}

// Part 2
const int diskSize = 70000000;
const int freeSpaceRequired = 30000000;
var freeSpace = diskSize - root.Size;
var minSpaceToFree = freeSpaceRequired - freeSpace;

var deletable = new List<Directory>();
Visit(root);
Console.WriteLine(deletable.Min(x => x.Size));

void Visit(Directory dir)
{
    if (dir.Size >= minSpaceToFree)
    {
        deletable.Add(dir);
    }

    foreach (var subdir in dir.Subdirectories)
    {
        Visit(subdir);
    }
}


class Directory
{
    public Directory(string name, Directory parentDir = null)
    {
        Name = name;
        ParentDirectory = parentDir;
    }

    public Directory ParentDirectory { get; set; }

    public string Name { get; set; }

    public int Size { get; set; }

    public List<Directory> Subdirectories = new List<Directory>();
}
