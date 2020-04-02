using practicalblazor.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace practicalblazor.Services
{
  public class Users
  {
    private List<UserModel> _users = new List<UserModel>() {
      new UserModel() { Id = 1, FirstName = "Peter", LastName = "Shaw", Age = 21, Location = "North East England", Photo = "peter.jpg"},
      new UserModel() { Id = 1, FirstName = "Fred", LastName = "Flintstone", Age = 30, Location = "Bedrock", Photo = "fred.jpg"},
      new UserModel() { Id = 1, FirstName = "Yosamity", LastName = "Sam", Age = 50, Location = "Cartoon Land", Photo = "yosam.jpg"},
      new UserModel() { Id = 1, FirstName = "Pink", LastName = "Panther", Age = 20, Location = "Durham, Durham", Photo = "panther.jpg"}
    };

    public UserModel FetchUser(int id)
    {
      return _users.FirstOrDefault(r => r.Id == id);
    }

    public List<UserModel> FetchAll()
    {
      return _users;
    }

  }
}
