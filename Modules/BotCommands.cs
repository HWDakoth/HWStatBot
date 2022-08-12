using Discord;
using Discord.Interactions;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;

namespace HWStatBot.Services
{
    public class Schema
    {
        public string schema_name { get; set; }
        public string assets { get; set; }
    }

    public class Template
    {
        public string template_id { get; set; }
        public string assets { get; set; }
    }

    public class Data
    {
        public List<Schema> schemas { get; set; }
        public List<Template> templates { get; set; }
    }

    public class Root
    {
        public bool success { get; set; }
        public Data data { get; set; }
        public long query_time { get; set; }
    }


    public class Datum
    {
        public string account { get; set; }
        public string assets { get; set; }
    }

    public class PacksRoot
    {
        public bool success { get; set; }
        public List<Datum> data { get; set; }
        public long query_time { get; set; }
    }


    public class AccountData
    {
        public string account { get; set; }
        public string assets { get; set; }
    }

    public class AccountsRoot
    {
        public bool success { get; set; }
        public List<AccountData> data { get; set; }
        public long query_time { get; set; }
    }



    // interation modules must be public and inherit from an IInterationModuleBase
    public class BotCommands : InteractionModuleBase<SocketInteractionContext>
    {
        // dependencies can be accessed through Property injection, public properties with public setters will be set by the service provider
        public InteractionService Commands { get; set; }
        private CommandHandler _handler;

        // constructor injection is also a valid way to access the dependecies
        public BotCommands(CommandHandler handler)
        {
            _handler = handler;
        }

        [SlashCommand("s1stats", "Final Stats for Season 1")]
        public async Task S1Stats()
        {
            string body;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://wax.api.atomicassets.io/atomicassets/v1/burns?collection_name=hotwheels&schema_name=coin&template_id=451849&page=1&limit=100&order=desc");
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                string text = reader.ReadToEnd();

                PacksRoot packs = JsonConvert.DeserializeObject<PacksRoot>(text);

                int sum = 0;

                foreach (var data in packs.data)
                {
                    sum += int.Parse(data.assets);
                }


                string remaining = "\r\nTwin Mill Coins Burned: " + sum + " or ";
                double value = sum / 964.0;
                remaining += value.ToString("#0.##%");


                int remain = 964 - sum;
                remaining += "\r\nNot Redeemed Twin Mill Coins: " + remain + " or ";
                value = remain / 964.0;
                remaining += value.ToString("#0.##%");


                string tokensGivenout = "964 of 1200";
                remaining += "\r\nTwin Mill Coins Distributed against Max Possible: " + tokensGivenout + " or ";
                value = 964.0 / 1200.0;
                remaining += value.ToString("#0.##%");



                string tokensRedeemed = sum + " of 1200";
                remaining += "\r\nTwin Mill Coins Redeemed against Max Possible: " + tokensRedeemed + " or ";
                value = sum / 1200.0;
                remaining += value.ToString("#0.##%");

                body = remaining;

            }

            request = (HttpWebRequest)WebRequest.Create("https://wax.api.atomicassets.io/atomicassets/v1/burns?collection_name=hotwheels&schema_name=coin&template_id=451848&page=1&limit=100&order=desc");
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))

            {
                string text = reader.ReadToEnd();

                PacksRoot packs = JsonConvert.DeserializeObject<PacksRoot>(text);

                int sum = 0;

                foreach (var data in packs.data)
                {
                    sum += int.Parse(data.assets);
                }


                string remaining = "\r\n\r\nRoger Dodger Coins Burned: " + sum + " or ";
                double value = sum / 976.0;
                remaining += value.ToString("#0.##%");




                int remain = 976 - sum;
                remaining += "\r\nNot Redeemed Roger Dodger Coins: " + remain + " or ";
                value = remain / 976.0;
                remaining += value.ToString("#0.##%");


                string tokensGivenout = "976 of 1200";
                remaining += "\r\nRoger Dodger Coins Distributed against Max Possible: " + tokensGivenout + " or ";
                value = 976.0 / 1200.0;
                remaining += value.ToString("#0.##%");



                string tokensRedeemed = sum + " of 1200";
                remaining += "\r\nRoger Dodger Coins Redeemed against Max Possible: " + tokensRedeemed + " or ";
                value = sum / 1200.0;
                remaining += value.ToString("#0.##%");

                body += remaining;
            }

            request = (HttpWebRequest)WebRequest.Create("https://wax.api.atomicassets.io/atomicassets/v1/burns?collection_name=hotwheels&schema_name=coin&template_id=451847&page=1&limit=100&order=desc");
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))

            {
                string text = reader.ReadToEnd();

                PacksRoot packs = JsonConvert.DeserializeObject<PacksRoot>(text);

                int sum = 0;

                foreach (var data in packs.data)
                {
                    sum += int.Parse(data.assets);
                }


                string remaining = "\r\n\r\nMach Speeder Coins Burned: " + sum + " or ";
                double value = sum / 987.0;
                remaining += value.ToString("#0.##%");




                int remain = 987 - sum;
                remaining += "\r\nNot Redeemed Mach Speeder Coins: " + remain + " or ";
                value = remain / 987.0;
                remaining += value.ToString("#0.##%");


                string tokensGivenout = "987 of 1200";
                remaining += "\r\nMach Speeder Coins Distributed against Max Possible: " + tokensGivenout + " or ";
                value = 987.0 / 1200.0;
                remaining += value.ToString("#0.##%");



                string tokensRedeemed = sum + " of 1200";
                remaining += "\r\nMach Speeder Coins Redeemed against Max Possible: " + tokensRedeemed + " or ";
                value = sum / 1200.0;
                remaining += value.ToString("#0.##%");

                body += remaining;
            }

            request = (HttpWebRequest)WebRequest.Create("https://wax.api.atomicassets.io/atomicassets/v1/burns?collection_name=hotwheels&schema_name=coin&template_id=451846&page=1&limit=100&order=desc");
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                string text = reader.ReadToEnd();

                PacksRoot packs = JsonConvert.DeserializeObject<PacksRoot>(text);

                int sum = 0;

                foreach (var data in packs.data)
                {
                    sum += int.Parse(data.assets);
                }


                string remaining = "\r\n\r\nCamaro Coins Burned: " + sum + " or ";
                double value = sum / 1018.0;
                remaining += value.ToString("#0.##%");




                int remain = 1018 - sum;
                remaining += "\r\nNot Redeemed Camaro Coins: " + remain + " or ";
                value = remain / 1018.0;
                remaining += value.ToString("#0.##%");



                string tokensGivenout = "1018 of 1200";
                remaining += "\r\nCamaro Coins Distributed against Max Possible: " + tokensGivenout + " or ";
                value = 1018.0 / 1200.0;
                remaining += value.ToString("#0.##%");


                string tokensRedeemed = sum + " of 1200";
                remaining += "\r\nCamaro Coins Redeemed against Max Possible: " + tokensRedeemed + " or ";
                value = sum / 1200.0;
                remaining += value.ToString("#0.##%");

                body += remaining;

            }

            request = (HttpWebRequest)WebRequest.Create("https://wax.api.atomicassets.io/atomicassets/v1/burns?collection_name=hotwheels&schema_name=coin&template_id=451845&page=1&limit=100&order=desc");
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                string text = reader.ReadToEnd();

                PacksRoot packs = JsonConvert.DeserializeObject<PacksRoot>(text);

                int sum = 0;

                foreach (var data in packs.data)
                {
                    sum += int.Parse(data.assets);
                }


                string remaining = "\r\n\r\nBoneshaker Coins Burned: " + sum + " or ";
                double value = sum / 470.0;
                remaining += value.ToString("#0.##%");

                int remain = 470 - sum;
                remaining += "\r\nNot Redeemed Boneshaker Coins: " + remain + " or ";
                value = remain / 470.0;
                remaining += value.ToString("#0.##%");

                string tokensGivenout = "470 of 600";
                remaining += "\r\nBoneshaker Coins Distributed against Max Possible: " + tokensGivenout + " or ";
                value = 470.0 / 600.0;
                remaining += value.ToString("#0.##%");


                string tokensRedeemed = sum + " of 600";
                remaining += "\r\nBoneshaker Coins Redeemed against Max Possible: " + tokensRedeemed + " or ";
                value = sum / 600.0;
                remaining += value.ToString("#0.##%");

                body += remaining;
            }

            await RespondAsync($"**{body}**");
        }


        [SlashCommand("s2stats", "Current Pack and Premium+ Stats for S2")]
        public async Task S2Stats()
        {

            string body;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://wax.api.atomicassets.io/atomicassets/v1/burns?collection_name=hotwheels&schema_name=packs&template_id=477399&page=1&limit=10&order=desc");
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                string text = reader.ReadToEnd();

                PacksRoot packs = JsonConvert.DeserializeObject<PacksRoot>(text);

                int sum = 0;

                foreach (var data in packs.data)
                {
                    sum += int.Parse(data.assets);
                }


                string remaining = "\r\nPacks Opened: " + sum + " or ";
                double value = sum / 26321.0;
                remaining += value.ToString("#0.##%");


                int remain = 26321 - sum;
                remaining += "\r\nPacks Remaining: " + remain + " or ";
                value = remain / 26321.0;
                remaining += value.ToString("#0.##%");


                body = remaining;
            }


            request = (HttpWebRequest)WebRequest.Create("https://wax.api.atomicassets.io/atomicassets/v1/accounts/premint.nft/hotwheels");
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                string text = reader.ReadToEnd();

                Root HW = JsonConvert.DeserializeObject<Root>(text);

                var showRoom = HW.data.templates.Find(id => id.template_id == "473732");
                var nfth = HW.data.templates.Find(id => id.template_id == "476736");
                var s2000 = HW.data.templates.Find(id => id.template_id == "476739");
                var corvette = HW.data.templates.Find(id => id.template_id == "476740");
                var otto = HW.data.templates.Find(id => id.template_id == "476738");
                var rat = HW.data.templates.Find(id => id.template_id == "476737");

                string remaining = "\r\nShowroom: " + 0 + " or ";
                double value = 0.0;
                remaining += value.ToString("#0.##%");
                remaining += " remain";

                remaining += "\r\nNFTH: " + nfth.assets + " or ";
                value = Double.Parse(nfth.assets) / 1000.0;
                remaining += value.ToString("#0.##%");
                remaining += " remain";

                remaining += "\r\nS2000: " + s2000.assets + " or ";
                value = Double.Parse(s2000.assets) / 1500.0;
                remaining += value.ToString("#0.##%");
                remaining += " remain";

                remaining += "\r\nCorvette: " + corvette.assets + " or ";
                value = Double.Parse(corvette.assets) / 1500.0;
                remaining += value.ToString("#0.##%");
                remaining += " remain";

                remaining += "\r\nOtto: " + otto.assets + " or ";
                value = Double.Parse(otto.assets) / 1500.0;
                remaining += value.ToString("#0.##%");
                remaining += " remain";

                remaining += "\r\nAristo Rat: " + rat.assets + " or ";
                value = Double.Parse(rat.assets) / 1500.0;
                remaining += value.ToString("#0.##%");
                remaining += " remain";

                body += remaining;

            }
            await RespondAsync($"**{body}**");
        }


        // our first /command!
        [SlashCommand("s3stats", "Stats For Season 3 Premium and Above Cars")]
        public async Task S3Stats()
        {

            string body;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://wax.api.atomicassets.io/atomicassets/v1/burns?collection_name=hotwheels&schema_name=packs&template_id=542277&page=1&limit=10&order=desc");
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            //string logFile = DateTime.Now.ToString("yyyyMMdd") + ".txt";
            // if (!File.Exists(logFile))
            // {
            //     File.Create(logFile).Close();
            // }

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            // using (StreamWriter writetext = new StreamWriter(logFile, true))
            {
                string text = reader.ReadToEnd();

                PacksRoot packs = JsonConvert.DeserializeObject<PacksRoot>(text);

                int sum = 0;

                foreach (var data in packs.data)
                {
                    sum += int.Parse(data.assets);
                }


                string remaining = "\r\nPacks Opened + Burned: " + sum + " or ";
                double value = sum / 31929.0;
                remaining += value.ToString("#0.##%");

                int remain = 31929 - sum;
                remaining += "\r\nPacks Remaining: " + remain + " or ";
                value = remain / 31929.0;
                remaining += value.ToString("#0.##%");


                //writetext.WriteLine(remaining);

                body = remaining;
            }


            request = (HttpWebRequest)WebRequest.Create("https://wax.api.atomicassets.io/atomicassets/v1/accounts/premint.nft/hotwheels");
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            //using (StreamWriter writetext = new StreamWriter(logFile, true))
            {
                string text = reader.ReadToEnd();

                Root HW = JsonConvert.DeserializeObject<Root>(text);

                var showRoom = HW.data.templates.Find(id => id.template_id == "543001");
                var nfth = HW.data.templates.Find(id => id.template_id == "542222");
                var nsx = HW.data.templates.Find(id => id.template_id == "542260");
                var firebird = HW.data.templates.Find(id => id.template_id == "542272");
                var jetz = HW.data.templates.Find(id => id.template_id == "542247");
                var blade = HW.data.templates.Find(id => id.template_id == "542234");

                string remaining = "\r\nShowroom: " + showRoom.assets + " or ";
                double value = Double.Parse(showRoom.assets) / 250.0;
                remaining += value.ToString("#0.##%");
                remaining += " remain";

                remaining += "\r\nNFTH: " + nfth.assets + " or ";
                value = Double.Parse(nfth.assets) / 1250.0;
                remaining += value.ToString("#0.##%");
                remaining += " remain";

                remaining += "\r\nNSX: " + nsx.assets + " or ";
                value = Double.Parse(nsx.assets) / 2000.0;
                remaining += value.ToString("#0.##%");
                remaining += " remain";

                remaining += "\r\nFirebird: " + firebird.assets + " or ";
                value = Double.Parse(firebird.assets) / 2000.0;
                remaining += value.ToString("#0.##%");
                remaining += " remain";

                remaining += "\r\n2 Jet Z: " + jetz.assets + " or ";
                value = Double.Parse(jetz.assets) / 2000.0;
                remaining += value.ToString("#0.##%");
                remaining += " remain";

                remaining += "\r\nBad To The Blade: " + blade.assets + " or ";
                value = Double.Parse(blade.assets) / 2000.0;
                remaining += value.ToString("#0.##%");
                remaining += " remain";


                // writetext.WriteLine(remaining);

                body += remaining;

            }

            // reply with the answer
            await RespondAsync($"**{body}**");
        }

        [SlashCommand("s2redeem", "Stats For Season 2 Redeem")]
        public async Task S2Redeem()
        {

            string body;

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://wax.api.atomicassets.io/atomicassets/v1/burns?collection_name=hotwheels&schema_name=coin&template_id=564478&page=1&limit=100&order=desc");
                request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

                // string logFile = DateTime.Now.ToString("yyyyMMdd") + ".txt";
                // if (!File.Exists(logFile))
                // {
                //     File.Create(logFile);
                // }

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    string text = reader.ReadToEnd();

                    PacksRoot packs = JsonConvert.DeserializeObject<PacksRoot>(text);

                    int sum = 0;

                    foreach (var data in packs.data)
                    {
                        sum += int.Parse(data.assets);
                    }


                    string remaining = "\r\nCustom Otto Coins Burned: " + sum + " or ";
                    double value = sum / 1410.0;
                    remaining += value.ToString("#0.##%");
                    
                    int remain = 1410 - sum;
                    remaining += "\r\nNot Redeemed Custom Otto Coins: " + remain + " or ";
                    value = remain / 1410.0;
                    remaining += value.ToString("#0.##%");
                    
                    string tokensGivenout = "1410 of 1500";
                    remaining += "\r\nCustom Otto Coins Distributed against Max Possible: " + tokensGivenout + " or ";
                    value = 1410.0 / 1500.0;
                    remaining += value.ToString("#0.##%");
                    
                    string tokensRedeemed = sum + " of 1500";
                    remaining += "\r\nCustom Otto Coins Redeemed against Max Possible: " + tokensRedeemed + " or ";
                    value = sum / 1500.0;
                    remaining += value.ToString("#0.##%");
                    
                    body = remaining;
                    
                }

                request = (HttpWebRequest)WebRequest.Create("https://wax.api.atomicassets.io/atomicassets/v1/burns?collection_name=hotwheels&schema_name=coin&template_id=564477&page=1&limit=100&order=desc");
                request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))

                {
                    string text = reader.ReadToEnd();

                    PacksRoot packs = JsonConvert.DeserializeObject<PacksRoot>(text);

                    int sum = 0;

                    foreach (var data in packs.data)
                    {
                        sum += int.Parse(data.assets);
                    }


                    string remaining = "\r\n\r\nS2000 Coins Burned: " + sum + " or ";
                    double value = sum / 1428.0;
                    remaining += value.ToString("#0.##%");

                    int remain = 1428 - sum;
                    remaining += "\r\nNot Redeemed S2000 Coins: " + remain + " or ";
                    value = remain / 1428.0;
                    remaining += value.ToString("#0.##%");
                    
                    string tokensGivenout = "1428 of 1500";
                    remaining += "\r\nS2000 Coins Distributed against Max Possible: " + tokensGivenout + " or ";
                    value = 1428.0 / 1500.0;
                    remaining += value.ToString("#0.##%");

                    string tokensRedeemed = sum + " of 1500";
                    remaining += "\r\nS2000 Coins Redeemed against Max Possible: " + tokensRedeemed + " or ";
                    value = sum / 1500.0;
                    remaining += value.ToString("#0.##%");
                    
                    body += remaining;
                    

                }

                request = (HttpWebRequest)WebRequest.Create("https://wax.api.atomicassets.io/atomicassets/v1/burns?collection_name=hotwheels&schema_name=coin&template_id=564476&page=1&limit=100&order=desc");
                request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    string text = reader.ReadToEnd();

                    PacksRoot packs = JsonConvert.DeserializeObject<PacksRoot>(text);

                    int sum = 0;

                    foreach (var data in packs.data)
                    {
                        sum += int.Parse(data.assets);
                    }


                    string remaining = "\r\n\r\nCorvette Coins Burned: " + sum + " or ";
                    double value = sum / 1372.0;
                    remaining += value.ToString("#0.##%");

                    int remain = 1372 - sum;
                    remaining += "\r\nNot Redeemed Corvette Coins: " + remain + " or ";
                    value = remain / 1372.0;
                    remaining += value.ToString("#0.##%");

                    string tokensGivenout = "1372 of 1500";
                    remaining += "\r\nCorvette Coins Distributed against Max Possible: " + tokensGivenout + " or ";
                    value = 1372.0 / 1500.0;
                    remaining += value.ToString("#0.##%");
                    
                    string tokensRedeemed = sum + " of 1500";
                    remaining += "\r\nCorvette Coins Redeemed against Max Possible: " + tokensRedeemed + " or ";
                    value = sum / 1500.0;
                    remaining += value.ToString("#0.##%");
                    

                    body += remaining;
                    

                }

                request = (HttpWebRequest)WebRequest.Create("https://wax.api.atomicassets.io/atomicassets/v1/burns?collection_name=hotwheels&schema_name=coin&template_id=564475&page=1&limit=100&order=desc");
                request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    string text = reader.ReadToEnd();

                    PacksRoot packs = JsonConvert.DeserializeObject<PacksRoot>(text);

                    int sum = 0;

                    foreach (var data in packs.data)
                    {
                        sum += int.Parse(data.assets);
                    }


                    string remaining = "\r\n\r\nAristo Rat Coins Burned: " + sum + " or ";
                    double value = sum / 1357.0;
                    remaining += value.ToString("#0.##%");
    
                    int remain = 1357 - sum;
                    remaining += "\r\nNot Redeemed Aristo Rat Coins: " + remain + " or ";
                    value = remain / 1357.0;
                    remaining += value.ToString("#0.##%");

                    string tokensGivenout = "1357 of 1500";
                    remaining += "\r\nAristo Rat Coins Distributed against Max Possible: " + tokensGivenout + " or ";
                    value = 1357.0 / 1500.0;
                    remaining += value.ToString("#0.##%");
                    
                    string tokensRedeemed = sum + " of 1500";
                    remaining += "\r\nAristo Rat Coins Redeemed against Max Possible: " + tokensRedeemed + " or ";
                    value = sum / 1500.0;
                    remaining += value.ToString("#0.##%");

                    body += remaining;
                    
                }

                request = (HttpWebRequest)WebRequest.Create("https://wax.api.atomicassets.io/atomicassets/v1/burns?collection_name=hotwheels&schema_name=coin&template_id=564479&page=1&limit=100&order=desc");
                request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    string text = reader.ReadToEnd();

                    PacksRoot packs = JsonConvert.DeserializeObject<PacksRoot>(text);

                    int sum = 0;

                    foreach (var data in packs.data)
                    {
                        sum += int.Parse(data.assets);
                    }


                    string remaining = "\r\n\r\nGasser Coins Burned: " + sum + " or ";
                    double value = sum / 919.0;
                    remaining += value.ToString("#0.##%");

                    int remain = 919 - sum;
                    remaining += "\r\nNot Redeemed Gasser Coins: " + remain + " or ";
                    value = remain / 919.0;
                    remaining += value.ToString("#0.##%");

                    string tokensGivenout = "919 of 1000";
                    remaining += "\r\nGasser Coins Distributed against Max Possible: " + tokensGivenout + " or ";
                    value = 919.0 / 1000.0;
                    remaining += value.ToString("#0.##%");

                    string tokensRedeemed = sum + " of 1000";
                    remaining += "\r\nGasser Coins Redeemed against Max Possible: " + tokensRedeemed + " or ";
                    value = sum / 1000.0;
                    remaining += value.ToString("#0.##%");

                    body += remaining;
                    
                }
            
                await RespondAsync($"**{body}**");

        

        }


        [SlashCommand("allsets", "Count of all set holders")]
        public async Task AllSetHolders()
        {
            await DeferAsync();
            string body;

            string[] templates = { "353670", "353671", "353672", "353673", "353674", "353675", "353676", "353677", "353678", "353679", "353681", "353682", "353683", "353685", "353691", "353686", "353687", "353688", "353689", "353690", "353693", "353694", "353695", "353696", "353697", "353698", "353700", "353701", "353702", "353703", "353704", "353706", "353707", "353708", "353709", "362065", "362066", "362067", "362068", "353680" };

            HttpWebRequest request;

            Dictionary<string, Dictionary<string, int>> accountS1Dict = new Dictionary<string, Dictionary<string, int>>();

            int i = 0;

            while (i < templates.Length)
            {
                try
                {
                    string t = templates[i];

                    string address = "https://wax.api.atomicassets.io/atomicassets/v1/accounts?collection_name=hotwheels&schema_name=series1&template_id=" + t + "&page=1&limit=5000&order=desc";
                    request = (HttpWebRequest)WebRequest.Create(address);
                    request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;


                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    using (Stream stream = response.GetResponseStream())
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        string text = reader.ReadToEnd();

                        AccountsRoot accountsRoot = JsonConvert.DeserializeObject<AccountsRoot>(text);
                        foreach (var data in accountsRoot.data)
                        {
                            if (accountS1Dict.ContainsKey(data.account))
                            {
                                accountS1Dict[data.account][t] = int.Parse(data.assets);
                            }
                            else if (t == "353670")
                            {
                                Dictionary<string, int> temp = new Dictionary<string, int>();
                                foreach (string plate in templates)
                                {
                                    temp.Add(plate, 0);
                                }

                                accountS1Dict.Add(data.account, temp);
                                accountS1Dict[data.account][t] = int.Parse(data.assets);
                            }
                        }


                    }
                    System.Threading.Thread.Sleep(1000);
                    i++;
                }
                catch (Exception)
                {
                }
            }

            accountS1Dict.Remove("premint.nft");
            Dictionary<string, int> completeS1Sets = new Dictionary<string, int>();
            int sets = 0;

            foreach (var a in accountS1Dict)
            {
                int val = a.Value["353670"];

                foreach (var b in a.Value)
                {
                    if (b.Value < val)
                    {
                        val = b.Value;
                    }
                    if (b.Value == 0)
                    {
                        val = b.Value;
                        break;
                    }
                }
                if (val != 0)
                {
                    completeS1Sets.Add(a.Key, val);
                    sets += val;
                }
            }


                body = "\r\nNumber of Completed Series 1 Sets(1-40): " + sets;
                body += "\r\nUnique Owners of Completed Series 1 Sets(1-40): " + completeS1Sets.Count;

            



            string[] templatesS2 = { "473732", "476740", "476739", "476738", "476737", "476736", "473734", "473733", "473730", "473729", "473728", "473727", "473726", "473725", "473724", "473723", "473722", "473720", "473719", "473718", "473717", "473716", "473715", "473714", "473713", "473712", "473710", "473709", "473708", "473707", "473706", "473705", "473704", "473703", "473702", "473700", "473699", "473698", "473697", "473696", "473695", "473694", "473693" };


            Dictionary<string, Dictionary<string, int>> accountS2Dict = new Dictionary<string, Dictionary<string, int>>();

            i = 0;

            while (i < templatesS2.Length)
            {
                try
                {
                    string t = templatesS2[i];

                    string address = "https://wax.api.atomicassets.io/atomicassets/v1/accounts?collection_name=hotwheels&schema_name=series2&template_id=" + t + "&page=1&limit=5000&order=desc";
                    request = (HttpWebRequest)WebRequest.Create(address);
                    request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;


                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    using (Stream stream = response.GetResponseStream())
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        string text = reader.ReadToEnd();

                        AccountsRoot accountsRoot = JsonConvert.DeserializeObject<AccountsRoot>(text);
                        foreach (var data in accountsRoot.data)
                        {
                            if (accountS2Dict.ContainsKey(data.account))
                            {
                                accountS2Dict[data.account][t] = int.Parse(data.assets);
                            }
                            else if (t == "473732")
                            {
                                Dictionary<string, int> temp = new Dictionary<string, int>();
                                foreach (string plate in templatesS2)
                                {
                                    temp.Add(plate, 0);
                                }

                                accountS2Dict.Add(data.account, temp);
                                accountS2Dict[data.account][t] = int.Parse(data.assets);
                            }
                        }


                    }
                    System.Threading.Thread.Sleep(1000);
                    i++;
                }
                catch (Exception)
                {
                }
            }




            accountS2Dict.Remove("premint.nft");
            Dictionary<string, int> completeS2Sets = new Dictionary<string, int>();
            sets = 0;

            foreach (var a in accountS2Dict)
            {
                int val = a.Value["473732"];

                foreach (var b in a.Value)
                {
                    if (b.Value < val)
                    {
                        val = b.Value;
                    }
                    if (b.Value == 0)
                    {
                        val = b.Value;
                        break;
                    }
                }
                if (val != 0)
                {
                    completeS2Sets.Add(a.Key, val);
                    sets += val;
                }
            }

         


                body += "\r\nNumber of Completed Series 2 Sets(1-43): " + sets;
                body += "\r\nUnique Owners of Completed Series 2 Sets(1-43): " + completeS2Sets.Count;
            



            string[] templatesS3 = { "543001", "542222", "542260", "542272", "542247", "542234", "542271", "542270", "542269", "542268", "542267", "542266", "542265", "542264", "542263", "542262", "542261", "542259", "542258", "542257", "542256", "542255", "542254", "542253", "542252", "542251", "542250", "542249", "542248", "542246", "542245", "542244", "542243", "542242", "542241", "542240", "542239", "542238", "542237", "542236", "542235", "542233", "542232", "542231", "542230", "542229", "542228", "542227", "542226", "542225", "542224", "542223", "542475", "542476" };

            Dictionary<string, Dictionary<string, int>> accountDictS3 = new Dictionary<string, Dictionary<string, int>>();

            i = 0;

            while (i < templatesS3.Length)
            {
                string t = templatesS3[i];
                try
                {
                    string address = "https://wax.api.atomicassets.io/atomicassets/v1/accounts?collection_name=hotwheels&schema_name=series3&template_id=" + t + "&page=1&limit=5000&order=desc";
                    request = (HttpWebRequest)WebRequest.Create(address);
                    request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;


                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    using (Stream stream = response.GetResponseStream())
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        string text = reader.ReadToEnd();

                        AccountsRoot accountsRoot = JsonConvert.DeserializeObject<AccountsRoot>(text);
                        foreach (var data in accountsRoot.data)
                        {
                            if (accountDictS3.ContainsKey(data.account))
                            {
                                accountDictS3[data.account][t] = int.Parse(data.assets);
                            }
                            else if (t == "543001")
                            {
                                Dictionary<string, int> temp = new Dictionary<string, int>();
                                foreach (string plate in templatesS3)
                                {
                                    temp.Add(plate, 0);
                                }

                                accountDictS3.Add(data.account, temp);
                                accountDictS3[data.account][t] = int.Parse(data.assets);
                            }
                        }


                    }
                    System.Threading.Thread.Sleep(1000);
                    i++;

                }
                catch (Exception)
                {

                }

            }

            accountDictS3.Remove("premint.nft");
            Dictionary<string, int> completeSetsS3 = new Dictionary<string, int>();
            int setsS3 = 0;

            foreach (var a in accountDictS3)
            {
                int val = a.Value["543001"];

                foreach (var b in a.Value)
                {
                    if (b.Value < val)
                    {
                        val = b.Value;
                    }
                    if (b.Value == 0)
                    {
                        val = b.Value;
                        break;
                    }
                }
                if (val != 0)
                {
                    completeSetsS3.Add(a.Key, val);
                    setsS3 += val;
                }
            }

                body += "\r\nNumber of Completed Series 3 Sets(1-54): " + setsS3;
                body += "\r\nUnique Owners of Completed Series 3 Sets(1-43): " + completeSetsS3.Count;


            sets = 0;
            Dictionary<string, int> completeAllSets = new Dictionary<string, int>();
            foreach (var a in completeS1Sets)
            {
                if (completeS2Sets.ContainsKey(a.Key) && completeSetsS3.ContainsKey(a.Key))
                {
                    if (completeS2Sets[a.Key] <= a.Value && completeSetsS3[a.Key] <= a.Value)
                    {
                        completeAllSets.Add(a.Key, completeS2Sets[a.Key]);
                        if (completeS2Sets[a.Key] <= a.Value)
                            sets += completeS2Sets[a.Key];
                        else if (completeSetsS3[a.Key] <= a.Value)
                            sets += completeSetsS3[a.Key];
                    }
                }
            }

                body += "\r\nNumber of Owners of Series 1 through Series 3 Completed Sets: " + sets;
                body += "\r\nNumber of Unique Owners of Series 1 through Series 3 Completed Sets: " + completeAllSets.Count;
            
            await FollowupAsync($"**{body}**");
        }


        [SlashCommand("s1s2", "Count of S1 and S2 set holders")]
        public async Task S1S2Holders()
        {
            await DeferAsync();
            string body;

                            string[] templates = { "353670", "353671", "353672", "353673", "353674", "353675", "353676", "353677", "353678", "353679", "353681", "353682", "353683", "353685", "353691", "353686", "353687", "353688", "353689", "353690", "353693", "353694", "353695", "353696", "353697", "353698", "353700", "353701", "353702", "353703", "353704", "353706", "353707", "353708", "353709", "362065", "362066", "362067", "362068", "353680" };

                HttpWebRequest request;

                Dictionary<string, Dictionary<string, int>> accountS1Dict = new Dictionary<string, Dictionary<string, int>>();

                int i = 0;

                while (i < templates.Length)
                {
                    try
                    {
                        string t = templates[i];

                        string address = "https://wax.api.atomicassets.io/atomicassets/v1/accounts?collection_name=hotwheels&schema_name=series1&template_id=" + t + "&page=1&limit=5000&order=desc";
                        request = (HttpWebRequest)WebRequest.Create(address);
                        request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;


                        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                        using (Stream stream = response.GetResponseStream())
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            string text = reader.ReadToEnd();

                            AccountsRoot accountsRoot = JsonConvert.DeserializeObject<AccountsRoot>(text);
                            foreach (var data in accountsRoot.data)
                            {
                                if (accountS1Dict.ContainsKey(data.account))
                                {
                                    accountS1Dict[data.account][t] = int.Parse(data.assets);
                                }
                                else if (t == "353670")
                                {
                                    Dictionary<string, int> temp = new Dictionary<string, int>();
                                    foreach (string plate in templates)
                                    {
                                        temp.Add(plate, 0);
                                    }

                                    accountS1Dict.Add(data.account, temp);
                                    accountS1Dict[data.account][t] = int.Parse(data.assets);
                                }
                            }


                        }
                        System.Threading.Thread.Sleep(1000);
                        i++;
                    }
                    catch (Exception)
                    {
                    }
                }



                accountS1Dict.Remove("premint.nft");
                Dictionary<string, int> completeS1Sets = new Dictionary<string, int>();
                int sets = 0;

                foreach (var a in accountS1Dict)
                {
                    int val = a.Value["353670"];

                    foreach (var b in a.Value)
                    {
                        if (b.Value < val)
                        {
                            val = b.Value;
                        }
                        if (b.Value == 0)
                        {
                            val = b.Value;
                            break;
                        }
                    }
                    if (val != 0)
                    {
                        completeS1Sets.Add(a.Key, val);
                        sets += val;
                    }
                }

                    body = "\r\nNumber of Completed Series 1 Sets(1-40): " + sets;
                    body += "\r\nUnique Owners of Completed Series 1 Sets(1-40): " + completeS1Sets.Count;
                

                string[] templatesS2 = { "473732", "476740", "476739", "476738", "476737", "476736", "473734", "473733", "473730", "473729", "473728", "473727", "473726", "473725", "473724", "473723", "473722", "473720", "473719", "473718", "473717", "473716", "473715", "473714", "473713", "473712", "473710", "473709", "473708", "473707", "473706", "473705", "473704", "473703", "473702", "473700", "473699", "473698", "473697", "473696", "473695", "473694", "473693" };


                Dictionary<string, Dictionary<string, int>> accountS2Dict = new Dictionary<string, Dictionary<string, int>>();

                i = 0;

                while (i < templatesS2.Length)
                {
                    try
                    {
                        string t = templatesS2[i];

                        string address = "https://wax.api.atomicassets.io/atomicassets/v1/accounts?collection_name=hotwheels&schema_name=series2&template_id=" + t + "&page=1&limit=5000&order=desc";
                        request = (HttpWebRequest)WebRequest.Create(address);
                        request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;


                        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                        using (Stream stream = response.GetResponseStream())
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            string text = reader.ReadToEnd();

                            AccountsRoot accountsRoot = JsonConvert.DeserializeObject<AccountsRoot>(text);
                            foreach (var data in accountsRoot.data)
                            {
                                if (accountS2Dict.ContainsKey(data.account))
                                {
                                    accountS2Dict[data.account][t] = int.Parse(data.assets);
                                }
                                else if (t == "473732")
                                {
                                    Dictionary<string, int> temp = new Dictionary<string, int>();
                                    foreach (string plate in templatesS2)
                                    {
                                        temp.Add(plate, 0);
                                    }

                                    accountS2Dict.Add(data.account, temp);
                                    accountS2Dict[data.account][t] = int.Parse(data.assets);
                                }
                            }


                        }
                        System.Threading.Thread.Sleep(1000);
                        i++;
                    }
                    catch (Exception)
                    {
                    }
                }

                accountS2Dict.Remove("premint.nft");
                Dictionary<string, int> completeS2Sets = new Dictionary<string, int>();
                sets = 0;

                foreach (var a in accountS2Dict)
                {
                    int val = a.Value["473732"];

                    foreach (var b in a.Value)
                    {
                        if (b.Value < val)
                        {
                            val = b.Value;
                        }
                        if (b.Value == 0)
                        {
                            val = b.Value;
                            break;
                        }
                    }
                    if (val != 0)
                    {
                        completeS2Sets.Add(a.Key, val);
                        sets += val;
                    }
                }

                    body += "\r\nNumber of Completed Series 2 Sets(1-43): " + sets;
                    body += "\r\nUnique Owners of Completed Series 2 Sets(1-43): " + completeS2Sets.Count;

                sets = 0;
                Dictionary<string, int> completeAllSets = new Dictionary<string, int>();
                foreach (var a in completeS1Sets)
                {
                    if (completeS2Sets.ContainsKey(a.Key))
                    {
                        if (completeS2Sets[a.Key] <= a.Value)
                        {
                            completeAllSets.Add(a.Key, completeS2Sets[a.Key]);
                                sets += completeS2Sets[a.Key];

                        }
                    }
                }
                    body += "\r\nNumber of Owners of Series 1 through Series 2 Completed Sets: " + sets;
                    body += "\r\nNumber of Unique Owners of Series 1 through Series 2 Completed Sets: " + completeAllSets.Count;

            await FollowupAsync($"**{body}**");
        }
    }
}
