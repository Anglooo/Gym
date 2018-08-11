using MvvmCross;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using GymApp.Core.Services;
using GymApp.Core.ViewModels;
using GymApp.Core.Repositories;
using System;
using System.IO;

namespace GymApp.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            Mvx.RegisterSingleton<IMenuItemService>(new MenuItemService(Mvx.Resolve<IMvxNavigationService>()));

            RegisterAppStart<RootViewModel>();

            //TEST
            base.Initialize();
        }

        static WorkoutDatabase workoutDatabase;

        public static WorkoutDatabase WorkoutDatabase
        {
            get
            {
                if (workoutDatabase == null)
                {
                    workoutDatabase = new WorkoutDatabase(
                      Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "WorkoutSQLite.db3"));
                }
                return workoutDatabase;
            }
        }

        static LoggedWorkoutDatabase loggedWorkoutDatabase;

        public static LoggedWorkoutDatabase LoggedWorkoutDatabase
        {
            get
            {
                if (loggedWorkoutDatabase == null)
                {
                    loggedWorkoutDatabase = new LoggedWorkoutDatabase(
                      Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "LoggedWorkoutSQLite.db3"));
                }
                return loggedWorkoutDatabase;
            }
        }

        static ExcersizeDatabase excersizeDatabase;

        public static ExcersizeDatabase ExcersizeDatabase
        {
            get
            {
                if (excersizeDatabase == null)
                {
                    excersizeDatabase = new ExcersizeDatabase(
                      Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ExcersizeSQLite.db3"));
                }
                return excersizeDatabase;
            }
        }
    }
}
