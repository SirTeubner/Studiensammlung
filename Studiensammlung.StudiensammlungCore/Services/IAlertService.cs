using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studiensammlung.StudiensammlungCore.Services;

public interface IAlertService
{
    void ShowAlert(string title, string message);
    Task ShowAlertAsync(string title, string message);
}
