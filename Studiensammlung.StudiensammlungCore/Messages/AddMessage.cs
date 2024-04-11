using CommunityToolkit.Mvvm.Messaging.Messages;
using Studiensammlung.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studiensammlung.StudiensammlungCore.Messages;

public class AddMessage : ValueChangedMessage<Entry>
{
    public AddMessage(Entry value) : base(value)
    {
    }
}
