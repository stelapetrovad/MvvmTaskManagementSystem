using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmTaskManagementSystem.Models
{
    public class TaskService
    {
        private static List<UserTask> ObjTasksList;
        
        public TaskService()
        {
            ObjTasksList = new List<UserTask>()
            {
                new UserTask { Id=101, Name="Task1" }
            };
        }

        public List<UserTask> GetAll()
        {
            return ObjTasksList;
        }
        
        public bool Add(UserTask objNewTask)
        {
            ObjTasksList.Add(objNewTask);
            return true;
        }

        public bool Update(UserTask objTaskToUpdate)
        {
            bool IsUpdated = false;
            for (int index = 0; index < ObjTasksList.Count; index++)
            {
                if(ObjTasksList[index].Id == objTaskToUpdate.Id)
                {
                    ObjTasksList[index].Name = objTaskToUpdate.Name;
                    ObjTasksList[index].CreatedDateTask = objTaskToUpdate.CreatedDateTask;
                    ObjTasksList[index].RequiredByDateTask = objTaskToUpdate.RequiredByDateTask;
                    ObjTasksList[index].TaskDescription = objTaskToUpdate.TaskDescription;
                    ObjTasksList[index].TaskStatus = objTaskToUpdate.TaskStatus;
                    ObjTasksList[index].TaskType = objTaskToUpdate.TaskType;
                    ObjTasksList[index].User = objTaskToUpdate.User;
                    IsUpdated = true;
                    break;
                }
            }
            return IsUpdated;
        }

        public bool Delete(int id)
        {
            bool IsDeleted = false;
            for(int index=0; index<ObjTasksList.Count; index++)
            {
                if(ObjTasksList[index].Id == id)
                {
                    ObjTasksList.RemoveAt(index);
                    IsDeleted = true;
                    break;
                }
            }
            return IsDeleted;
        }

    }
}
