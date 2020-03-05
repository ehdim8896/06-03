using gym.Models;
using gym.Models.Entities;
using gym.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gym.Repository
{
    public class Dll
    {
        GymContext _db;
        JsonDeserializeUtil _jsonUtil;
        public Dll()
        {
            _db = new GymContext();
            _jsonUtil = new JsonDeserializeUtil();
            _jsonUtil.JudgeDeserialize();
            _jsonUtil.CheckJudge(_db);
        }
        public List<Judge> ShowJudges()
        {
            return _db.Judges.ToList();
        }
        public bool CheckJudgeExist(Judge judge)
        {
            var judgeExistsSave = _db.Judges.Any(x => x.FirstName == judge.FirstName && x.Discipline == judge.Discipline && x.LastName == judge.LastName && x.Gender == judge.Gender);
            if (!judgeExistsSave)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool InsertJudge(Judge j)
        {
            if (CheckJudgeExist(j))
            {
                j.JsonId = _db.Judges.OrderByDescending(i => i.JsonId).FirstOrDefault().JsonId + 1;
                _db.Judges.Add(j);
                _db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool UpdateJudge(Judge j)
        {
            bool isUpdated = false;
            for (int i = 0; i < _db.Judges.Count(); i++)
            {
                if (_db.Judges.ToList()[i].Id == j.Id)
                {
                    _db.Judges.ToList()[i].FirstName = j.FirstName;
                    _db.Judges.ToList()[i].LastName = j.LastName;
                    _db.Judges.ToList()[i].Birth = j.Birth;
                    _db.Judges.ToList()[i].Category = j.Category;
                    _db.Judges.ToList()[i].Country = j.Country;
                    _db.Judges.ToList()[i].Discipline = j.Discipline;
                    _db.Judges.ToList()[i].Gender = j.Gender;
                    _db.Judges.ToList()[i].JsonId = j.JsonId;
                    _db.SaveChanges();
                    isUpdated = true;
                    break;
                }
            }
            return isUpdated;
        }
        public bool DeleteJudge(int id)
        {
            bool isDeleted = false;
            if(_db.Judges.Any(x => x.Id == id))
            {
                var deletedJudge = _db.Judges.First(x => x.Id == id);
                _db.Judges.Remove(deletedJudge);
                _db.SaveChanges();
                isDeleted = true;
            }
            return isDeleted;
        }
    }
}
