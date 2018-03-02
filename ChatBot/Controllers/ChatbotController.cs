using ChatBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChatBot.Controllers
{
    public class ChatbotController : Controller
    {
        public static string userreplies = "";
        public static string botreplies = "";
        public static int noofentries = 0;
        public static string timestampsss = "";
        public static string usertimess = "";

        // GET: Chatbot
        public ActionResult Bot()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Bot(UserMessage um)
        {
            //System.Diagnostics.Debug.WriteLine(um.msg);
            List<BotReply> br = new List<BotReply>();
            BotReply b = new BotReply();
            switch (um.msg.ToLower())
            {
                case "hi":
                case "sup":
                case "hey":
                case "hello":
                    b.message = "Hey! How can i help you today? \\";
                    b.message += "If you need any help in the inputs available, type \"help\" or \"--h\"";
                    break;
                case "bye":
                case "good bye":
                case "goodbye":
                case "bye bye":
                case "byebye":
                case "gotta go":
                case "gotta go!":
                case "see you again!":
                case "see you again":
                case "ttyl":
                case "talk to you later":
                    b.message = "Ok bye! See you again!";
                    break;
                case "what is this?":
                case "what is this":
                    b.message = "This is a simple chat bot like application that takes your input and gives you a reply \\";
                    b.message += "This was inspired by the Microsoft Bot Framework \\";
                    b.message += "Do check out the Bot Framework and see how you can host your very own bot in Azure!";
                    break;
                case "copyright":
                    b.message = "Coded by Kok Wah in 2018";
                    break;
                case "how to use?":
                    b.message = "To configure it you just need to add on to the switch statement \\";
                    b.message += "case \"What the user will enter\": \\";
                    b.message += "b.message = \"What your bot will reply\"; \\";
                    b.message += "break; \\";
                    b.message += "To set up a default reply, when non of the user input matches \\";
                    b.message += "Add this to the end of the switch statement \\";
                    b.message += "default: \\";
                    b.message += "b.message = \"What your bot will reply\"; \\";
                    b.message += "break;";
                    break;
                case "help":
                case "\\h":
                case "\\help":
                case "--h":
                case "/help":
                case "/h":
                    b.message = "Here are some valid inputs: \\";
                    b.message += "Greetings - Hey, Hi, Sup, Hello \\";
                    b.message += "Bye - Bye, Good Bye, Bye Bye, Gotta Go, See You Again, TTYL \\";
                    b.message += "Find out about the app - What is this? \\";
                    b.message += "Copyright - Copyright \\";
                    b.message += "How to configure this to suit your needs - How To Use?";
                    break;
                default:
                    b.message = "That input is not available type \"help\" or \"--h\" to see what is valid!";
                    break;
            }

            //userinput message
            b.usertyped = um.msg;

            DateTime today = DateTime.Now;
            //user timestamp
            b.usertime = today.ToString("d") + " " + today.ToString("T");
            //delay for bot timestamp
            DateTime bottime = today.AddSeconds(3);
            b.timestamp = bottime.ToString("d") + " " + bottime.ToString("T");

            //keep track of everything
            if (noofentries >= 1)
            {
                //System.Diagnostics.Debug.WriteLine("old user reply: " + userreplies + " old bot reply: " + botreplies + " old timestamp: " + timestampsss + " old user time: " + usertimess);
                userreplies = userreplies + "\'" + b.usertyped;
                botreplies = botreplies + "\'" + b.message;
                timestampsss = timestampsss + "\'" + b.timestamp;
                usertimess = usertimess + "\'" + b.usertime;

                //System.Diagnostics.Debug.WriteLine("new user reply: " + userreplies + " new bot reply: " + botreplies + " new timestamp: " + timestampsss + " new user time: " + usertimess);
                String[] temp1 = userreplies.Split('\'');
                //System.Diagnostics.Debug.WriteLine("First " + temp1[0] + " next " + temp1[1]);
                String[] temp2 = botreplies.Split('\'');
                //System.Diagnostics.Debug.WriteLine("First " + temp2[0] + " next " + temp2[1]);
                String[] temp3 = timestampsss.Split('\'');
                //System.Diagnostics.Debug.WriteLine("First " + temp3[0] + " next " + temp3[1]);
                String[] temp4 = usertimess.Split('\'');
                //System.Diagnostics.Debug.WriteLine("First " + temp4[0] + " next " + temp4[1]);


                for (int i = 0; i < temp1.Length; i++)
                {
                    BotReply save = new BotReply();
                    save.usertyped = temp1[i];
                    //System.Diagnostics.Debug.WriteLine("Went in "+temp1[i]);
                    save.message = temp2[i];
                    //System.Diagnostics.Debug.WriteLine("Went in " + temp2[i]);
                    save.timestamp = temp3[i];
                    //System.Diagnostics.Debug.WriteLine("Went in " + temp3[i]);
                    save.usertime = temp4[i];
                    //System.Diagnostics.Debug.WriteLine("Went in " + temp4[i]);
                    //System.Diagnostics.Debug.WriteLine();
                    br.Add(save);
                }
            }
            else
            {
                userreplies = b.usertyped;
                botreplies = b.message;
                timestampsss = b.timestamp;
                usertimess = b.usertime;
                br.Add(b);
            }

            noofentries++;

            /*
            for(int i=0; i<br.Count; i++)
            {
                System.Diagnostics.Debug.WriteLine(br.Count);
                System.Diagnostics.Debug.WriteLine(i);
                System.Diagnostics.Debug.WriteLine("What is in br " + br[i].message);
                System.Diagnostics.Debug.WriteLine("What is in br " + br[i].timestamp);
                System.Diagnostics.Debug.WriteLine("What is in br " + br[i].usertyped);
                System.Diagnostics.Debug.WriteLine("What is in br " + br[i].usertime);
            }*/
            return View(br);
        }
    }
}