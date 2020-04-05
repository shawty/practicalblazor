using practicalblazor.Data;
using System.Collections.Generic;
using System.Linq;

namespace practicalblazor.Services
{
  public class Users
  {
    private List<UserModel> _users = new List<UserModel>() {
      new UserModel() { Id = 1, FirstName = "Peter", LastName = "Shaw", Age = 21, Location = "North East England", Photo = "peter.jpg", LoginName="shawty"},
      new UserModel() { Id = 2, FirstName = "Fred", LastName = "Flintstone", Age = 30, Location = "Bedrock", Photo = "fred.jpg", LoginName="fred"},
      new UserModel() { Id = 3, FirstName = "Yosamity", LastName = "Sam", Age = 50, Location = "Cartoon Land", Photo = "yosam.jpg", LoginName="sam"},
      new UserModel() { Id = 4, FirstName = "Pink", LastName = "Panther", Age = 20, Location = "Durham, Durham", Photo = "panther.jpg", LoginName="panther"}
    };

    public UserModel FetchUser(int id)
    {
      return _users.FirstOrDefault(r => r.Id == id);
    }

    public UserModel FetchUser(string loginName)
    {
      return _users.FirstOrDefault(r => r.LoginName == loginName);
    }

    public List<UserModel> FetchAll()
    {
      return _users;
    }

    public void Authenticate(string userName, string password)
    {

    }

  }
}
