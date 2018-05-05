﻿namespace Forum.App.Controllers
{
    using Forum.App.Controllers.Contracts;
    using Forum.App.Services;
    using Forum.App.UserInterface;
    using Forum.App.UserInterface.Contracts;
    using Forum.App.Views;
    using System;

    public class LogInController : IController, IReadUserInfoController
    {
        public LogInController()
        {
            this.ResetLogin();
        }

        public string Username { get; private set; }

        private string Password { get; set; }

        private bool Error { get; set; }

        private enum Command
        {
            ReadUsername, ReadPassword, Login, Back
        }

        private void ResetLogin()
        {
            this.Error = false;
            this.Username = string.Empty;
            this.Password = string.Empty;
        }

        public MenuState ExecuteCommand(int index)
        {
            switch ((Command)index)
            {
                case Command.ReadUsername:
                    this.ReadUsername();
                    return MenuState.Login;
                case Command.ReadPassword:
                    this.ReadPassword();
                    return MenuState.Login;
                case Command.Login:
                    bool loggedIn = UserService.TryLogInUser(this.Username, this.Password);
                    if (loggedIn)
                    {
                        return MenuState.SuccessfulLogIn;
                    }
                    this.Error = true;
                    return MenuState.Error;
                case Command.Back:
                    this.ResetLogin();
                    return MenuState.Back;
            }
            throw new InvalidOperationException();
        }

        public IView GetView(string userName)
        {
            return new LogInView(this.Error, this.Username, this.Password.Length);
        }

        public void ReadPassword()
        {
            this.Password = ForumViewEngine.ReadRow();
            ForumViewEngine.HideCursor();
        }

        public void ReadUsername()
        {
            this.Username = ForumViewEngine.ReadRow();
            ForumViewEngine.HideCursor();
        }
    }
}
