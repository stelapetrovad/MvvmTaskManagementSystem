using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
namespace MvvmTaskManagementSystem.Models
{
    public class UserTask : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged("Id"); }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged("Name"); }
        }

        private DateTime createdDateTask;

        public DateTime CreatedDateTask
        {
            get { return createdDateTask; }
            set { createdDateTask = value; OnPropertyChanged("CreatedDateTask"); }
        }

        private DateTime requiredByDateTask;

        public DateTime RequiredByDateTask
        {
            get { return requiredByDateTask; }
            set { requiredByDateTask = value; OnPropertyChanged("RequiredByDateTask"); }
        }

        private string taskDescription;

        public string TaskDescription
        {
            get { return taskDescription; }
            set { taskDescription = value; OnPropertyChanged("TaskDescription"); }
        }

        private string taskStatus;

        public string TaskStatus
        {
            get { return taskStatus; }
            set { taskStatus = value; OnPropertyChanged("TaskStatus"); }
        }

        private string taskType;

        public string TaskType
        {
            get { return taskType; }
            set { taskType = value; OnPropertyChanged("TaskType"); }
        }

        private string usersTask;

        public string UsersTask
        {
            get { return usersTask; }
            set { usersTask = value; OnPropertyChanged("UsersTask"); }
        }

    }
}
