using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using gym.Repository;
using gym.Models.Entities;
using gym.Commands;
using gym.Models;
using System.Collections.ObjectModel;

namespace gym.ViewModel
{
    public class JudgeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        Dll _dll;
        public JudgeViewModel()
        {
            _dll = new Dll();
            LoadJudge();
            CurrentJudge = new Judge();
            CurrentJudge.Birth = DateTime.Now;
            ChangeContent();
            _saveCommand = new RelayCommand(SaveUpdate);
            _deleteCommand = new RelayCommand(Delete);
            newCommand = new RelayCommand(NewJudge);
        }
        private ObservableCollection<Judge> judgeList;
        public ObservableCollection<Judge> JudgeList
        {
            get { return judgeList; }
            set { judgeList = value; OnPropertyChanged("JudgeList"); }
        }
        private string _message;
        public string Message
        {
            get { return _message; }
            set { _message = value; OnPropertyChanged("Message"); }
        }
        private void LoadJudge()
        {
            JudgeList = new ObservableCollection<Judge>(_dll.ShowJudges());
        }
        private Judge _currentJudge;
        public Judge CurrentJudge
        {
            get { return _currentJudge; }
            set
            {
                _currentJudge = value;
                ChangeContent();
                OnPropertyChanged("CurrentJudge");
                OnPropertyChanged("Content");
            }
        }
        public bool Validation()
        {
            if (!string.IsNullOrWhiteSpace(CurrentJudge.FirstName) && !string.IsNullOrWhiteSpace(CurrentJudge.LastName) && !string.IsNullOrWhiteSpace(CurrentJudge.Country))
            {
                return true;
            }
            else
            {
                Message = "Please fill";
                return false;
            }
        }
        #region Save
        private RelayCommand _saveCommand;
        public RelayCommand SaveCommand
        {
            get { return _saveCommand; }
        }
        public void Save()
        {
            try
            {
                if (Validation())
                {
                    var isSaved = _dll.InsertJudge(CurrentJudge);
                    LoadJudge();
                    NewJudge();
                    if (isSaved)
                    {
                        Message = "Judge saved";
                    }
                    else
                    {
                        Message = "Save failed";
                    }
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
        #endregion
        #region Update
        public void Update()
        {
            try
            {
                var isUpdated = _dll.UpdateJudge(_currentJudge);
                if (isUpdated)
                {
                    Message = "Judge updated";
                    LoadJudge();
                    NewJudge();
                }
                else
                {
                    Message = "Update operation failed";
                }
            }
            catch (Exception ex)
            {

                Message = ex.Message;
            }
        }
        #endregion
        #region Delete
        private RelayCommand _deleteCommand;
        public RelayCommand DeleteCommand
        {
            get { return _deleteCommand; }
        }
        public void Delete()
        {
            try
            {
                var isDeleted = _dll.DeleteJudge(CurrentJudge.Id);
                if (isDeleted)
                {
                    Message = "Judge deleted";
                    LoadJudge();
                    NewJudge();
                }
                else
                {
                    Message = "Delete operation failed";
                }
            }
            catch (Exception ex)
            {

                Message = ex.Message;
            }
        }
        #endregion
        #region New
        private RelayCommand newCommand;
        public RelayCommand NewCommand
        {
            get { return newCommand; }
        }
        public void NewJudge()
        {
            Judge j = new Judge();
            j.Birth = DateTime.Now;
            CurrentJudge = j;
        }
        #endregion
        #region ButtonContentSaveOrUpdate
        private string _content;
        public string Content
        {
            get { return _content; }
            set
            {
                _content = value;
                OnPropertyChanged("Content");
                OnPropertyChanged("CurrentJudge");
            }
        }
        public void ChangeContent()
        {
            if (CurrentJudge!=null && CurrentJudge.Id == 0)
            {
                Content = "Save";
            }
            else
            {
                Content = "Update";
            }
        }
        public void SaveUpdate()
        {
            if (Content == "Save")
            {
                Save();
            }
            else
            {
                Update();
            }
        }
        #endregion
    }
}
