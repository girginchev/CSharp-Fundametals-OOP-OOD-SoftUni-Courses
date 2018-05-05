﻿namespace Forum.App
{
    using Contracts;
    using Factories;
    using Forum.App.Models;
    using Forum.App.Services;
    using Forum.Data;
    using Microsoft.Extensions.DependencyInjection;
    using System;

    public class StartUp
	{
		public static void Main(string[] args)
		{
            IServiceProvider serviceProvider = ConfigureServices();
            IMainController menu = serviceProvider.GetService<IMainController>();

            Engine engine = new Engine(menu);
            engine.Run();
        }

		private static IServiceProvider ConfigureServices()
		{
            IServiceCollection services = new ServiceCollection();

            #region Factory Services
            services.AddSingleton<ITextAreaFactory, TextAreaFactory>();
            services.AddSingleton<ILabelFactory, LabelFactory>();
            services.AddSingleton<IMenuFactory, MenuFactory>();
            services.AddSingleton<ICommandFactory, CommandFactory>();
            #endregion

            #region Database Services
            services.AddSingleton<ForumData>();
            services.AddTransient<IPostService, PostService>();
            services.AddTransient<IUserService, UserService>();
            #endregion

            #region Other Services
            services.AddSingleton<ISession, Session>();
            services.AddSingleton<IForumViewEngine, ForumViewEngine>();
            services.AddSingleton<IMainController, MenuController>();

            services.AddTransient<IForumReader, ForumConsoleReader>();
            services.AddTransient<ITextInputArea, TextInputArea>();
            #endregion

            IServiceProvider serviceProvider = services.BuildServiceProvider();

            return serviceProvider;
        }
    }
}
