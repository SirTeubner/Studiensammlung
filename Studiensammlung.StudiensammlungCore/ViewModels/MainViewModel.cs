using CommunityToolkit.Mvvm.ComponentModel;
using Studiensammlung.Lib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studiensammlung.StudiensammlungApp.ViewModels;

public partial class MainViewModel(IRepository repository) : ObservableObject
{
    public string Header => "Studiensammlung";
    IRepository _repository = repository;
    private bool _isLoaded = false;

    [ObservableProperty]
    ObservableCollection<Lib.Entry> _entries = [];

    [ObservableProperty]
    Lib.Entry? _selectedEntry = null;

    #region Properties


    [ObservableProperty]
    string _user = string.Empty;
    string _password = string.Empty;
    string _studyCourse = string.Empty;
    int _studyLength = 0;
    string _title = string.Empty;

    #endregion





}
