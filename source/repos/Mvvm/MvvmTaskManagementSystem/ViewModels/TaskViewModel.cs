using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using MvvmTaskManagementSystem.Models;
using MvvmTaskManagementSystem.Commands;
using System.Collections.ObjectModel;
namespace MvvmTaskManagementSystem.ViewModels
{
    public class TaskViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<string> statusCollection = new ObservableCollection<string>();

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        TaskService ObjTaskService;
        public TaskViewModel()
        {

            ObjTaskService = new TaskService();
            LoadData();
            CurrentTask = new UserTask();
            saveCommand = new RelayCommand(Save);
            updateCommand = new RelayCommand(Update);
            deleteCommand = new RelayCommand(Delete);
        }

        #region DisplayOperation
        private ObservableCollection<UserTask> tasksList;
        public ObservableCollection<UserTask> TasksList
        {
            get { return tasksList; }
            set { tasksList = value; OnPropertyChanged("TasksList"); }
        }

        private void LoadData()
        {
            TasksList = new ObservableCollection<UserTask>(ObjTaskService.GetAll());
        }
        #endregion

        private UserTask currentTask;
        public UserTask CurrentTask
        {
            get { return currentTask; }
            set { currentTask = value; }
        }

        #region SaveOperation
        private RelayCommand saveCommand;
        public RelayCommand SaveCommand
        {
            get { return saveCommand; }
        }

        public void Save()
        {
            try
            {
                var IsSaved = ObjTaskService.Add(CurrentTask);
                LoadData();
            }
            catch(Exception ex)
            {

            }
        }
        #endregion

        #region UpdateOperation
        private RelayCommand updateCommand;
        public RelayCommand UpdateCommand
        {
            get { return updateCommand; }
        }

        public void Update()
        {
            try
            {
                var IsUpdated = ObjTaskService.Update(CurrentTask);
                if(IsUpdated)
                {
                    LoadData();
                }
            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        #region DeleteOperation
        private RelayCommand deleteCommand;
        public RelayCommand DeleteCommand
        {
            get { return deleteCommand; }
        }

        public void Delete()
        {
            try
            {
                var IsDelete = ObjTaskService.Delete(CurrentTask.Id);
                if(IsDelete)
                {
                    LoadData();
                }
            }
            catch(Exception ex)
            {

            }
        }
        #endregion
    }
}
