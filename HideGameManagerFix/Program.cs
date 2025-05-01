class Program
{
    static void Main()
    {
        string defaultpath1 = Path.Combine(
    "D:",
    "SteamL3ibrary",
    "steamapps",
    "common",
    "Gorilla Tag",
    "BepInEx",
    "config",
    "BepInEx.cfg"
);
        string defaultpath2 = Path.Combine(
    "C:",
    "SteamLibrary",
    "steamapps",
    "common",
    "Gorilla Tag",
    "BepInEx",
    "config",
    "BepInEx.cfg"
);
        string defaultpath3 = Path.Combine(
    "C:",
    "Program Files (x86)",
    "Steam",
    "steamapps",
    "common",
    "Gorilla Tag",
    "BepInEx",
    "config",
    "BepInEx.cfg"
);
        string defaultpath4 = Path.Combine(
    "E:",
    "SteamLibrary",
    "steamapps",
    "common",
    "Gorilla Tag",
    "BepInEx",
    "config",
    "BepInEx.cfg"
);

        string gtagFolder;
        string cfgPath;

        if (File.Exists(defaultpath1))
        {
            cfgPath = defaultpath1;
        }
        else if (File.Exists(defaultpath2))
        {
            cfgPath = defaultpath2;
        }
        else if (File.Exists(defaultpath3))
        {
            cfgPath = defaultpath3;
        }
        else if (File.Exists(defaultpath4))
        {
            cfgPath = defaultpath4;
        }
        else
        {
            Console.Write("Enter Gorilla Tag Folder path: ");
            gtagFolder = Console.ReadLine();
            if (gtagFolder != null)
            {
                cfgPath = Path.Combine(gtagFolder, "BepInEx", "config", "BepInEx.cfg");
            }
            else
            {
                cfgPath = "";
            }
            if (!File.Exists(cfgPath))
            {
                Console.WriteLine("Config path is invalid!");
                return;
            }
        }

        string[] lines = File.ReadAllLines(cfgPath);
        bool found = false;
        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i].Trim().StartsWith("HideManagerGameObject =", StringComparison.OrdinalIgnoreCase))
            {
                lines[i] = "HideManagerGameObject = true";
                found = true;
                break;
            }
        }
        if (found)
        {
            File.WriteAllLines(cfgPath, lines);
            Console.WriteLine("Setting updated successfully.");
        }
        else
        {
            Console.WriteLine("Setting not found in the config file.");
        }
    }
}
