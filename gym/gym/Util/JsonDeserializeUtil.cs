using gym.Models;
using gym.Models.Entities;
using gym.Models.JsonList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace gym.Util
{
    public class JsonDeserializeUtil
    {
        string _pathJudge = "C:/Users/Ahdim/source/repos/JudgeEntity/JudgeEntity/JsonFiles/Judges.json";
        public JudgeJsonList _jsonDataJudge;
        public List<Judge> _judges;
        public void JudgeDeserialize()
        {
            _judges = new List<Judge>();
            try
            {
                string _readJson = File.ReadAllText(_pathJudge);
                _jsonDataJudge = Newtonsoft.Json.JsonConvert.DeserializeObject<JudgeJsonList>(_readJson);
                foreach (var jsonData in _jsonDataJudge.JudgesList)
                {
                    Judge judge = new Judge();
                    judge.Birth = jsonData.Birth;
                    judge.Category = jsonData.Category;
                    judge.Country = jsonData.Country;
                    judge.Discipline = jsonData.Discipline;
                    judge.FirstName = jsonData.FirstName;
                    judge.Gender = jsonData.Gender;
                    judge.JsonId = jsonData.JsonId;
                    judge.LastName = jsonData.LastName;
                    _judges.Add(judge);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void CheckJudge(GymContext db)
        {
            foreach (var item in _judges)
            {
                var judgeExists = db.Judges.Any(x => x.JsonId == item.JsonId && x.Discipline == item.Discipline);
                if (!judgeExists)
                {
                    db.Judges.Add(item);
                }
            }
            db.SaveChanges();
        }
    }
}
