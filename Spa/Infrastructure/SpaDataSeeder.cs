﻿using System;
using Microsoft.AspNet.Identity;
using Spa.Entities;

namespace Spa.Infrastructure
{
    public class SpaDataSeeder
    {
        private readonly AppDbContext _ctx;
        public SpaDataSeeder(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        static readonly string[] CustomerNames = 
        { 
            "Taiseer,Joudeh,Male,hotmail.com", 
            "Hasan,Ahmad,Male,mymail.com", 
            "Moatasem,Ahmad,Male,outlook.com", 
            "Salma,Tamer,Female,outlook.com", 
            "Ahmad,Radi,Male,gmail.com", 
            "Bill,Gates,Male,yahoo.com", 
            "Shareef,Khaled,Male,gmail.com", 
            "Aram,Naser,Male,gmail.com", 
            "Layla,Ibrahim,Female,mymail.com", 
            "Rema,Oday,Female,hotmail.com",
            "Fikri,Husein,Male,gmail.com",
            "Noura,Ahmad,Female,outlook.com"
        };

        public string[] SplitValue(string val)
        {
            return val.Split(',');
        }

        public string RandomString(int size)
        {
            Random random = new Random((int)DateTime.Now.Ticks);
            string _char = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            char[] buffer = new char[size];
            for (int i = 0; i < size; i++)
            {
                buffer[i] = _char[random.Next(_char.Length)];
            }
            return new string(buffer);
        }
        public void Seed()
        {
            try
            {
                var userManager = new UserManager<User, int>(new CustomUserStore(new AppDbContext()));

                var appUser = new User()
                {
                    FirstName = "Maksim",
                    LastName = "Ivanov",
                    Email = "maximustag@gmail.com",
                    EmailConfirmed = true,
                    UserName = "maximus",
                    Roles = { }
                };

                userManager.Create(appUser, "Password!");

                var group = new CustomerGroup()
                {
                    GroupName = "Default",
                    Discount = 10
                };
                _ctx.CustomerGroups.Add(group);

                foreach (var customerName in CustomerNames)
                {
                    var nameGenderMail = SplitValue(customerName);
                    var user = new User()
                    {
                        FirstName = String.Format("{0}", nameGenderMail[0]),
                        LastName = String.Format("{0}", nameGenderMail[1]),
                        RegistrationDate = DateTime.Now,
                        DateOfBirth = DateTime.Now,
                        UserName = String.Format("{0}{1}", nameGenderMail[0], nameGenderMail[1]),
                        PasswordHash = RandomString(8),
                        Email = String.Format("{0}.{1}@{2}", nameGenderMail[0], nameGenderMail[1], nameGenderMail[3]),
                        SubscribedNews = true,
                        CustomerGroup = group,
                    };
                    _ctx.Users.Add(user);
                }
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                string message = ex.ToString();
                throw;
            }
        }
    }
}