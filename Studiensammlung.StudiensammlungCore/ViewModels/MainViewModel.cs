using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Studiensammlung.Lib;
using Studiensammlung.StudiensammlungCore.Messages;
using Studiensammlung.StudiensammlungCore.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entry = Studiensammlung.Lib.Entry;

namespace Studiensammlung.StudiensammlungCore.ViewModels;

public partial class MainViewModel(IRepository repository, IAlertService alertService) : ObservableObject
{
    public string Header => "Studiensammlung";
    IRepository _repository = repository;
    IAlertService _alertService = alertService;
    private bool _isLoaded = false;

    [ObservableProperty]
    ObservableCollection<Lib.Entry> _entries = [];

    [ObservableProperty]
    Lib.Entry? _selectedEntry = null;

    #region Properties


    [ObservableProperty]
    string _user = string.Empty;

    [ObservableProperty]
    string _password = string.Empty;

    [ObservableProperty]
    string _studyCourse = string.Empty;

    [ObservableProperty]
    int _studyLength = 0;

    [ObservableProperty]
    string _title = string.Empty;

    #endregion

    [RelayCommand]
    void ToggleFavorite(Lib.Entry entry)
    {
        entry.Favorite = !entry.Favorite;

        var result = _repository.Update(entry);

        if (result)
        {
            int pos = this.Entries.IndexOf(entry);

            if (pos != -1)
            {
                this.Entries[pos] = entry;
                _alertService.ShowAlert("Erfolg", "Der Status wurde verändert!");
            }
        
        }
        else
        {
            _alertService.ShowAlert("Fehler", "Der Status wurde nicht verändert!");
        }
    }

    [RelayCommand]
    void Delete(Lib.Entry entry)
    {
        Lib.Entry entrytodelete = _repository.Find(entry.Id);

        if (entrytodelete != null)
        {
            var res = _repository.Delete(entrytodelete);

            if (res)
            {
                this.SelectedEntry = null;
                this.Entries.Remove(entry);

                _alertService.ShowAlert("Erfolg", "Der Eintrag wurde erfolgreich gelöscht");
            }
            else
            {
                _alertService.ShowAlert("Fehler", "Der Eintrag wurde nicht gelöscht");
            }
        }
        else
        {
            _alertService.ShowAlert("Fehler", "Der Eintrag wurde nicht gefunden");
        }

    }

    [RelayCommand]
    void Update(Lib.Entry entry)
    {
        Lib.Entry entrytoupdate = _repository.Find(entry.Id);

        if(entrytoupdate != null)
        {
            this.Entries.Remove(entry);

            this.Entries.Add(new Lib.Entry(this.User, this.Password, this.StudyCourse, this.StudyLength, this.Title, entrytoupdate.Favorite, entrytoupdate.Id));

            var resultupdate = _repository.Update(entry);

            if (resultupdate)
            {
                _alertService.ShowAlert("Erfolg", "Der Eintrag wurde geändert");
            }

            else
            {
                _alertService.ShowAlert("Fehler", "Der Eintrag konnte nicht gefunden werden");
            }

        }
    }


    [RelayCommand]
    void LoadData()
    {
        if (!_isLoaded)
        {
            var entries = _repository.GetAll();

            foreach (var entry in entries)
            {
                Entries.Add(entry);
            }
            _isLoaded = true;
        }
    }

    [RelayCommand]
    void Add()
    {
        Lib.Entry entry = new(this.User, this.Password, this.StudyCourse, this.StudyLength, this.Title, false);

        var result = _repository.Add(entry);

        if (result)
        {
            this.Entries.Add(entry);
            this.User = string.Empty;
            this.Password = string.Empty;
            this.StudyCourse = string.Empty;
            this.StudyLength = 0;

            WeakReferenceMessenger.Default.Send(new AddMessage(entry));
        }
    }


}
