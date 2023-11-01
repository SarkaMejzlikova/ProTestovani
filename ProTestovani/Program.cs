using System.Collections;
using System.IO;


internal class Program
{
    private static void Main(string[] args)
    {
        string cesta = @"C:\Users\sarka\OneDrive\Dokumenty\C#\Czechitas\text.txt";

        Console.WriteLine("Chcete do souboru přidávat řádky nebo vypsat soubor?\nOdpovězte zadáním čísla: 1 - přidat řádky / 2 - vypsat soubor");

        string answFile = Console.ReadLine();
        bool tryAgainFile = true;

        while (tryAgainFile)
        {
            try
            {
                switch (Int32.Parse(answFile))
                {
                    case (int)FileOperation.addInfo:

                        Console.WriteLine("Má se soubor přepsat nebo se mají řádky přidat na konec?\nOdpovězte zadáním čísla: 3 - přepsat / 4 - přidat");
                        
                        string answWork = Console.ReadLine();
                        bool tryAgainWork = true;

                        while (tryAgainWork)
                        {
                            try
                            {
                                switch (Int32.Parse(answWork))
                                {
                                    case (int)FileOperation.overwrite:

                                        string[] poleProPrepsani = PridavaniTextu();
                                        File.WriteAllLines(cesta, poleProPrepsani);
                                    break;

                                    case (int)FileOperation.addRow:

                                        string[] poleProPridani = PridavaniTextu();
                                        File.AppendAllLines(cesta, poleProPridani);
                                    break;

                                    default:
                                        Console.WriteLine("Zřejmě jste jako odpověď nezadali 3 nebo 4, zkuste to znovu:");
                                        answWork = Console.ReadLine();
                                    break;
                                }
                                tryAgainWork = false;
                                
                            }
                            catch (FormatException e)
                            {
                                Console.WriteLine("Zřejmě jste jako odpověď nezadali 3 nebo 4, zkuste to znovu:");
                                answWork = Console.ReadLine();
                            }
                        }
                    break;

                    case (int)FileOperation.readFile:

                        string vypisSouboru = File.ReadAllText(cesta);
                        Console.WriteLine(vypisSouboru);
                        break;

                    default:
                        Console.WriteLine("Zřejmě jste jako odpověď nezadali 1 nebo 2, zkuste to znovu:");
                        answFile = Console.ReadLine();
                        break;

                }
                tryAgainFile = false;
            }
            catch (FormatException e)
            {
                Console.WriteLine("Zřejmě jste jako odpověď nezadali 1 nebo 2, zkuste to znovu:");
                answFile = Console.ReadLine();
            }
        }

    }

    enum Cesta
    {
        ano = 1,
        ne = 2
    }

    enum FileOperation
    {
        addInfo = 1,
        readFile = 2,
        overwrite = 3,
        addRow = 4
    }

    public static string[] PridavaniTextu()
    {
        Console.WriteLine("Přidávejte řádky jak dlouho chcete. Pro ukončení zmáčkněte ENTER. ");
        string input = Console.ReadLine();
        List<string> listTextu = new List<string>();

        while (!string.IsNullOrEmpty(input))
        {
            listTextu.Add(input);
            input = Console.ReadLine();
        }

        string[] poleTextu = listTextu.ToArray();
        return poleTextu;
    }

}