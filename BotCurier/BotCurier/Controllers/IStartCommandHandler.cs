using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace BotCurier.UserCase
{
    public interface IStartCommandHandler
    {
        Task ExecuteAsync(Message message, CancellationToken cancellationToken);
    }
}
