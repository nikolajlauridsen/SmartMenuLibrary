using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMenuLibrary
{
    public class SmartMenu
    {
        private String MenuTitle;
        private String InputDescription;
        private string[,] menuPoints;

        public void LoadMenu(string path) {
            // Read the text file
            String line;
            // String list for each line (works like array but with arbitrary size;
            List<String> lines = new List<string>();

            using (System.IO.StreamReader textFile = new System.IO.StreamReader(path)) {
                while ((line = textFile.ReadLine()) != null) {
                    lines.Add(line);
                }
            }

            // Set title and description
            MenuTitle = lines[0];
            InputDescription = lines[1];

            // Read in menu points.
            menuPoints = new string[lines.Count - 2, 2];
            for (int i = 2; i < lines.Count; i++) {
                string[] split = lines[i].Split(';');
                // Point title
                menuPoints[i - 2, 0] = split[0];
                // Point ID
                menuPoints[i - 2, 1] = split[1];
            }
        }

        public void Activate() {
            int selection = 0;
            bool RunMenu = true;

            while (RunMenu) {
                // Clear screen and print menu
                Console.Clear();
                Console.WriteLine("---------------------");
                Console.WriteLine(MenuTitle);
                Console.WriteLine("---------------------");

                // Print all menu titles.
                for (int i = 0; i < menuPoints.GetLength(0); i++) {
                    Console.WriteLine("\t" + (i + 1) + ". " + menuPoints[i, 0]);
                }
                // Print description and recieve input
                Console.Write("\n" + InputDescription);
                String cmd = Console.ReadLine();
                // Test input and call binding
                if (cmd.ToLower() == "0") {
                    RunMenu = false;
                } else if (int.TryParse(cmd, out selection)) {
                    selection -= 1;
                    if (selection < menuPoints.GetLength(0)) {
                        // Call binding here
                        // Bindings.Call(menuPoints[selection, 1]);
                    } else {
                        Console.WriteLine("Selection too high, choose number in list");
                    }
                } else if (cmd.Length <= 0) {
                    Console.WriteLine("Please ENTER something!");

                } else {
                    Console.WriteLine("Invalid selection, please choose a number");
                }

                if (RunMenu) {
                    Console.ReadLine();
                }
            }
        }

        // Methods to facilitate tests
        public String GetTitle() {
            return MenuTitle;
        }

        public String GetDesc() {
            return InputDescription;
        }

        public String[,] GetPoints() {
            return menuPoints;
        }
    }
}
