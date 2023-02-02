using internet_sellings.classes;
using internet_sellings.entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Internet_Sellings_MSTesting
{
    [TestClass]
    public class UnitTest1
    {
        EntityController EntityController;
        public UnitTest1()
        {
            EntityController = EntityController.Instance;
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

            Assert.IsNotNull(user);
        }

        [TestMethod]
        public void FetchUsers()
        {

        } 

        [TestMethod]
        public void AddUser()
        {

        }

        [TestMethod]
        public void UpdateUser()
        {

        }

        [TestMethod]
        public void DeleteUser()
        {

        }

        [TestMethod]
        public void FetchRoles()
        {

        }

        [TestMethod]
        public void AddRole()
        {

        }

        [TestMethod] 
        public void DeleteRole()
        {

        }

        [TestMethod]
        public void UpdateRole()
        {

        }

        [TestMethod]
        public void CorrectWindowShowByRole()
        {

        }
    }
}
