using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studiensammlung.Lib;

public class Entry
{
    public bool Favorite { get; set; } = false;
    public string User { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string StudyCourse { get; set; } = string.Empty;
    public int StudyLength { get; set; } = 0;
    public string Title { get; set; } = string.Empty;
    public string Id { get; set; } = string.Empty;

    public Entry(string user, string password, string studycourse, int studylength, string title, bool favorite, string id)
    {
        this.User = user;
        this.Password = password;
        this.StudyCourse = studycourse;
        this.StudyLength = studylength;
        this.Title = title;
        this.Favorite = favorite;
        this.Id = id;
    }

    public Entry(string user, string password, string studycourse, int studylength, string title, bool favorite)
    {
        this.Id = Guid.NewGuid().ToString();
        this.User = user;
        this.Password = password;
        this.StudyCourse = studycourse;
        this.StudyLength = studylength;
        this.Title = title;
        this.Favorite = favorite;
    }

    public Entry()
    {
        
    }
}
