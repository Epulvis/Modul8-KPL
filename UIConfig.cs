using System.Text.Json;

public class UIConfig
{
    public BankTransferConfig config;
    public String filePath = @"bank_transfer_config.json";
    public UIConfig()
    {
        try
        {
            ReadConfigFile();
        }
        catch (Exception)
        {
            SetDefault();
            WriteNewConfigFile();
        }
    }
    public BankTransferConfig ReadConfigFile() {
        var Json = File.ReadAllText(filePath);
        var config = JsonSerializer.Deserialize<BankTransferConfig>(Json);
        return config;
    }
    public void SetDefault() 
    {
        config = new BankTransferConfig();
        config.lang = "en";
        config.transfer = new BankTransferConfig.Transfer();
        config.transfer.threshold = 25000000;
        config.transfer.low_fee = 6500;
        config.transfer.high_fee = 15000;
        config.methods = new List<string> { "RTO (real-time)", "SKN", "RTGS", "BI FAST" };
        config.confirmation = new BankTransferConfig.Confirmation();
        config.confirmation.en = "Please insert the amount of money to transfer:";
        config.confirmation.id = "Masukkan jumlah uang yang akan di-transfer:";
    }
    public void WriteNewConfigFile() {
        JsonSerializerOptions options = new JsonSerializerOptions()
        {
            WriteIndented = true
        };
        String jsonString = JsonSerializer.Serialize(config, options);
        File.WriteAllText(filePath, jsonString);
    }
}
