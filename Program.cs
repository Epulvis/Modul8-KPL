using static BankTransferConfig;

internal class Program
{
    private static void Main(string[] args)
    {
        BankTransferConfig Bank = new BankTransferConfig();
        UIConfig uIConfig = new UIConfig();
        uIConfig.ReadConfigFile();


        if (uIConfig.ReadConfigFile().lang.Equals("en"))
        {
            Console.WriteLine("Please insert the amount of money to transfer: ");
        }
        else
        {
            Console.WriteLine("Masukkan jumlah uang yang akan di-transfer: ");
        }

        int money = int.Parse(Console.ReadLine());
        if (money <= uIConfig.ReadConfigFile().transfer.threshold)
        {
            money = uIConfig.ReadConfigFile().transfer.low_fee;

            if (uIConfig.ReadConfigFile().lang.Equals("en"))
            {
                Console.WriteLine($"Transfer fee = {uIConfig.ReadConfigFile().transfer.low_fee} and Total amount = {money}");
            }
            else
            {
                Console.WriteLine($"Biaya transfer = {uIConfig.ReadConfigFile().transfer.low_fee} and Total biaya = {money}");
            }
        }
        else
        {
            money = uIConfig.ReadConfigFile().transfer.high_fee;
            if (uIConfig.ReadConfigFile().lang.Equals("en"))
            {
                Console.WriteLine($"Transfer fee = {uIConfig.ReadConfigFile().transfer.low_fee} and Total amount = {money}");
            }
            else
            {
                Console.WriteLine($"Biaya transfer = {uIConfig.ReadConfigFile().transfer.low_fee} and Total biaya = {money}");
            }
        }

        if (uIConfig.ReadConfigFile().lang.Equals("en"))
        {
            Console.WriteLine("Select transfer method: ");
        }
        else
        {
            Console.WriteLine("Pilih metode transfer: ");
        }

        for (int i = 0; i < uIConfig.ReadConfigFile().methods.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {uIConfig.ReadConfigFile().methods[i]}");
        }
        int select = int.Parse(Console.ReadLine());

        if (uIConfig.ReadConfigFile().lang.Equals("en"))
        {
            Console.WriteLine($"Please type {uIConfig.ReadConfigFile().confirmation.en} to confirm the transaction: ");
        }
        else
        {
            Console.WriteLine($"Ketik {uIConfig.ReadConfigFile().confirmation.en} untuk mengkonfirmasi transaksi: ");
        }

        string confirm = Console.ReadLine();

        if (confirm.Equals(uIConfig.ReadConfigFile().confirmation.en))
        {
            if (uIConfig.ReadConfigFile().lang.Equals("en"))
            {
                Console.WriteLine("Transaction successful");
            }
            else
            {
                Console.WriteLine("Transaksi berhasil");
            }
        }
        else
        {
            if (uIConfig.ReadConfigFile().lang.Equals("en"))
            {
                Console.WriteLine("Transaction failed");
            }
            else
            {
                Console.WriteLine("Transaksi gagal");
            }
        }
    }
}