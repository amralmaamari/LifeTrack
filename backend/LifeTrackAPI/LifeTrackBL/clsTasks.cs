
using System;
using System.Data;
using System.Data.SqlClient;
using LifeTrackDL;

namespace LifeTrackDB_Business
{
    public class clsTasks
    {


        public enum enMode { AddNew = 0, Update = 1 }
        public static enMode Mode = enMode.AddNew;

        public TasksDTO tasksDTO
        {
            get
            {
                return new TasksDTO(
              this.TaskID,
              this.ChallengeID,
              this.IsCompleted,
              this.CreatedAt,
              this.UpdatedAt


               );
            }
        }

        public int TaskID { get; set; }
        public int ChallengeID { get; set; }
        public clsChallenges ChallengesInfo { get; set; }   
        public bool IsCompleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }


        public clsTasks()
        {
            this.TaskID = -1;

            this.ChallengeID = -1;

            this.IsCompleted = false;

            this.CreatedAt = DateTime.Now;

            this.UpdatedAt = DateTime.Now;

            Mode = enMode.AddNew;
        }


        public clsTasks(TasksDTO tasks, enMode mode = enMode.AddNew)
        {

            this.TaskID = tasks.TaskID;

            this.ChallengeID = tasks.ChallengeID;

            this.ChallengesInfo =clsChallenges.GetChallengesInfoByID(ChallengeID);

            this.IsCompleted = tasks.IsCompleted;

            this.CreatedAt = tasks.CreatedAt;

            this.UpdatedAt = tasks.UpdatedAt;

            Mode = mode;
        }

        public static List<TasksDTO> GetAllTasks()
        {
            return clsTasksData.GetAllTasks();

        }


        public static clsTasks GetTasksInfoByID(int TaskID)
        {
            TasksDTO tasksDTO = clsTasksData.GetTasksInfoByID(TaskID);

            if (tasksDTO != null)
            {
                return new clsTasks(tasksDTO, enMode.Update);
            }
            else
            {
                return null;
            }
        }

        private bool _AddNewTasks()
        {

            this.TaskID = (int)clsTasksData.AddNewTasks(this.tasksDTO);
            return (this.TaskID != -1);

        }

        private bool _UpdateTasks()
        {

            return (clsTasksData.UpdateTasks(this.tasksDTO));
        }

        public bool Save()
        {

            if (Mode == enMode.AddNew)
            {
                if (_AddNewTasks())
                {
                    Mode = enMode.Update;
                    return true;
                }
                else
                    return false;
            }
            else
            {
                return _UpdateTasks();
            }

        }

        public static bool DeleteTasks(int TaskID)
        {
            return clsTasksData.DeleteTasks(TaskID);

        }



    }
}


