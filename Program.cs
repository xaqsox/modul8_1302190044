using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace modul8_1302190044
{
    class BankTransferConfig
    {
        public string Bhsa { get; set; }
        public int JmlUang { get; set; }
        public int treshold { get; set; }
        public int low_fee { get; set; }
        public int high_fee { get; set; }
        public string accepted { get; set; }
        public string canseled { get; set; }

        public BankTransferConfig()
        {
            Bhsa = "en";
            JmlUang = 25000000;
            treshold = 6500;
            low_fee = 15000;

        }
        public static BankTransferConfig BacaConfig(string path)
        {
            BankTransferConfig config = new BankTransferConfig();

           // if (File.Exists(path))
            {
             //   string json = File.ReadAllText(path);
              //  config = JsonConvert.DeserializeObject<CovidConfig>(json);
            }

            return config;
        }

        
        public void TulisConfig(string path)
        {
             //string json = JsonConvert.SerializeObject(this);
            //File.WriteAllText(path, json);
        }
        public void AlihBahasa()
       {
            if (Bhsa == "en")
            {
                Bhsa = "id";
            }
            else
            {
                Bhsa = "en";
           }
        }
    }
}
    class Program
    {
      static void Main(string[] args)
      {

        string json = System.IO.File.ReadAllText("bank_tranfer_config.json");
        BankTransferConfig config = JsonConvert.DeserializeObject<BankTransferConfig>(json);

        if (config.Lang == "en")
        {
            Console.WriteLine("Please insert the amount of money to transfer:");
        }
        else if (config.Lang == "id")
        {
            Console.WriteLine("Masukkan jumlah uang yang akan di-transfer:");
        }
        else
        {
            
            return;
        }

        int transferAmount;
        if (!int.TryParse(Console.ReadLine(), out transferAmount))
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
            return;
        }

  
        int tfee = (transferAmount <= config.treshold) ? config.low_fee : config.high_fee;
        int ttlfee = transferAmount + tfee;

        if (config.Lang == "en")
        {
            Console.WriteLine("Transfer fee = " + tfee);
            Console.WriteLine("Total amount = " + ttlfee);
        }
        else if (config.Lang == "id")
        {
            Console.WriteLine("Biaya transfer = " + tfee);
            Console.WriteLine("Total biaya = " + ttlfee);
        }
    }
}
    }

