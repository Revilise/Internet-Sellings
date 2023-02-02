  using Microsoft.VisualStudio.TestTools.UnitTesting;
using internet_sellings.classes;
using internet_sellings.entities;
using internet_sellings.windows;
using System.Linq;
using System.Windows;

namespace Internet_Sellings_MSTesting
{
    [TestClass]
    public class UnitTest1
    {
        EntityController EntityController;
        ApplicationContext db;

        public UnitTest1()
        {
           db = ApplicationContext.GetInstance(@"Data Source=localhost\SQLEXPRESS; Initial Catalog=up_02-01-indi; Integrated Security=true;");
           EntityController = new EntityController();
        }

        [TestMethod]
        public void AuthUser()
        {

            CurrantUser user = CurrantUser.AuthUser(
                new User {
                    Login = "admin",
                    Password = "admin"
                }
            );

            Assert.IsTrue(user.IsLogged());
        }

        [TestMethod]
        public void LogOutUser()
        {
            AuthUser();
            CurrantUser user = CurrantUser.GetInstance();
            Assert.IsTrue(user.IsLogged());
            user.IsLogged(true);
            Assert.IsFalse(user.IsLogged());
        }

        [TestMethod]
        public void FetchUsers()
        {
            var bl = EntityController.Users.BindingList;

            CollectionAssert.AllItemsAreInstancesOfType(bl, typeof(User));
        } 

        [TestMethod]
        public void AddUser()
        {
            User user = new User
            {
                Login = "tested-user",
                Password = "tested-pass",
                Name = "TEST",
                Role = db.Roles.First(r => true),
                Role_Id = 1
            };

            EntityController.Users.BindingList.Add(user);
            db.SaveChanges();
            EntityController.Users.Load();
            
            User actual = EntityController.Users.BindingList.First(
                x => x.Login == user.Login && x.Password == user.Password && x.Role_Id == user.Role_Id
            );

            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void UpdateUser()
        {
            User user = EntityController.Users.BindingList.FirstOrDefault(x => x.Login == "tested-user");

            if (user == null)
            {
                AddUser();
                user = EntityController.Users.BindingList.FirstOrDefault(x => x.Login == "tested-user");
            }

            user.Login = "Updated-user";
            db.SaveChanges();

            User actual = EntityController.Users.BindingList.FirstOrDefault(
               x => x.Login == user.Login
            );

            User deleted = EntityController.Users.BindingList.FirstOrDefault(
                x => x.Login == "tested-user"
            );

            Assert.AreEqual(user, actual);
            Assert.IsNull(deleted);
        }

        [TestMethod]
        public void DeleteUser()
        {
            User user = EntityController.Users.BindingList.FirstOrDefault(x => x.Login == "tested-user");

            if (user == null)
            {
                AddUser();
                user = EntityController.Users.BindingList.FirstOrDefault(x => x.Login == "tested-user");
            }

            EntityController.Users.BindingList.Remove(user);
            db.SaveChanges();

            User deleted = EntityController.Users.BindingList.FirstOrDefault(x => user.Id == x.Id);

            Assert.IsNull(deleted);
        }

        [TestMethod]
        public void FetchRoles()
        {
            var bl = EntityController.Roles.BindingList;

            CollectionAssert.AllItemsAreInstancesOfType(bl, typeof(Role));
        }

        [TestMethod]
        public void AddRole()
        {
            Role role = new Role
            {
                Name = "TEST"
            };

            EntityController.Roles.BindingList.Add(role);
            db.SaveChanges();
            EntityController.Roles.Load();

            Role actual = EntityController.Roles.BindingList.First(
                x => x.Name == role.Name
            );

            Assert.IsNotNull(actual);
        }
        [TestMethod]
        public void UpdateRole()
        {
            Role role = EntityController.Roles.BindingList.FirstOrDefault(x => x.Name == "TEST");

            if (role == null)
            {
                AddRole();
                role = EntityController.Roles.BindingList.FirstOrDefault(x => x.Name == "TEST");
            }

            role.Name = "UPD-TEST";
            db.SaveChanges();

            Role actual = EntityController.Roles.BindingList.FirstOrDefault(
               x => x.Id == role.Id
            );

            Role deleted = EntityController.Roles.BindingList.FirstOrDefault(
                x => x.Name == "TEST"
            );

            Assert.AreEqual(role, actual);
            
            Assert.IsNull(deleted);
        }
        [TestMethod] 
        public void DeleteRole()
        {
            Role role = EntityController.Roles.BindingList.FirstOrDefault(x => x.Name == "TEST");

            if (role  == null)
            {
                AddRole();
                role  = EntityController.Roles.BindingList.FirstOrDefault(x => x.Name == "TEST");
            }
            EntityController.Roles.BindingList.Remove(role);
            db.SaveChanges();

            User deleted = EntityController.Users.BindingList.FirstOrDefault(x => x.Id == role.Id);

            Assert.IsNull(deleted);
        }
    }
}
