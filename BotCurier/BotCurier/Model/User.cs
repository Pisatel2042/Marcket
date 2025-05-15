using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotCurier.Model
{
    public class User
    {
        public string Id { get; set; }
        public string TelegramName { get; set; }
        public string TelegramId { get; set; }
        public string FirstName { get; set; }    
        public string LastName { get; set; }
        public string Phone { get; set; }   
        public bool isAdmin { get; set; }

    }
}
