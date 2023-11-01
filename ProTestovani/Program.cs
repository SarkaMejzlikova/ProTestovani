using System.Collections;
using System.IO;


internal class Program
{
    private static void Main(string[] args)
    {
        string cesta = "";

        Console.WriteLine("Dobrý den,\nchcete zadat cestu k souboru ručně?\nOdpovězte zadáním čísla: 1 - ano / 2 - ne");

        string answPath = Console.ReadLine();
        bool tryAgainPath = true;

        while (tryAgainPath)
        {
            try
            {
                switch (Int32.Parse(answPath))
                {
                    case (int)FileOperation.yes:
                        Console.WriteLine("Zadejte cestu:");
                        cesta = Console.ReadLine();
                        break;

                    case (int)FileOperation.no:
                        cesta = @"C:\text.txt";
                        break;
                    default:
                        Console.WriteLine("Zřejmě jste jako odpověď nezadali 1 nebo 2, zkuste to znovu:");
                        answPath = Console.ReadLine();
                        break;
                }
                tryAgainPath = false;
            }
            catch (FormatException e)
            {
                Console.WriteLine("Zřejmě jste jako odpověď nezadali 1 nebo 2, zkuste to znovu:");
                answPath = Console.ReadLine();
            }
        }
        Console.WriteLine("Chcete do souboru přidávat řádky nebo vypsat soubor?\nOdpovězte zadáním čísla: 3 - přidat řádky / 4 - vypsat soubor");

        string answFile = Console.ReadLine();
        bool tryAgainFile = true;

        while (tryAgainFile)
        {
            try
            {
                switch (Int32.Parse(answFile))
                {
                    case (int)FileOperation.addInfo:

                        Console.WriteLine("Má se soubor přepsat nebo se mají řádky přidat na konec?\nOdpovězte zadáním čísla: 5 - přepsat / 6 - přidat");
                        
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

                                    default: // nedojde ke znovunačtení odpovědi
                                        Console.WriteLine("Zřejmě jste jako odpověď nezadali 5 nebo 6, zkuste to znovu:");
                                        answWork = Console.ReadLine();
                                    break;
                                }
                                tryAgainWork = false;
                                
                            }
                            catch (FormatException e)
                            {
                                Console.WriteLine("Zřejmě jste jako odpověď nezadali 5 nebo 6, zkuste to znovu:");
                                answWork = Console.ReadLine();
                            }
                        }
                    break;

                    case (int)FileOperation.readFile:

                        string vypisSouboru = File.ReadAllText(cesta);
                        Console.WriteLine(vypisSouboru);
                        break;

                    default: // nedojde ke znovunačtení odpovědi
                        Console.WriteLine("Zřejmě jste jako odpověď nezadali 3 nebo 4, zkuste to znovu:");
                        answFile = Console.ReadLine();
                        break;

                }
                tryAgainFile = false;
            }
            catch (FormatException e)
            {
                Console.WriteLine("Zřejmě jste jako odpověď nezadali 3 nebo 4, zkuste to znovu:");
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
        yes = 1,
        no = 2,
        addInfo = 3,
        readFile = 4,
        overwrite = 5,
        addRow = 6
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