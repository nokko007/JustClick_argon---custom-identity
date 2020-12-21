using JustClick.DataAccess.Data;
using JustClick.DataAccess.Repository.IRepository;
using JustClick.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace JustClick.DataAccess.Repository
{
    public class ProjectConfigRepository : Repository<ProjectConfigModel>, IProjectConfigRepository

    {

        private readonly ApplicationDbContext _db;
        public ProjectConfigRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(ProjectConfigModel ProjectConfig)
        {

            var objFromDb = _db.TBL_PROJECT_CONFIG.FirstOrDefault(s => s.URN == ProjectConfig.URN);
            if (objFromDb != null)
            {
                objFromDb.PROJECT_CODE = ProjectConfig.PROJECT_CODE;
                objFromDb.PROJECT_NAME = ProjectConfig.PROJECT_NAME;
                objFromDb.OWNER = ProjectConfig.OWNER;
                objFromDb.SCRIPT_1 = ProjectConfig.SCRIPT_1;
                objFromDb.SCRIPT_2 = ProjectConfig.SCRIPT_2;
                objFromDb.SCRIPT_3 = ProjectConfig.SCRIPT_3;
                objFromDb.SCRIPT_4 = ProjectConfig.SCRIPT_4;
                objFromDb.SCRIPT_5 = ProjectConfig.SCRIPT_5;
                objFromDb.SCRIPT_6 = ProjectConfig.SCRIPT_6;
                objFromDb.SCRIPT_7 = ProjectConfig.SCRIPT_7;
                objFromDb.SCRIPT_8 = ProjectConfig.SCRIPT_8;
                objFromDb.SCRIPT_9 = ProjectConfig.SCRIPT_9;
                objFromDb.SCRIPT_10 = ProjectConfig.SCRIPT_10;
                objFromDb.WARNINGCALL = ProjectConfig.WARNINGCALL;
                objFromDb.MAXCALL = ProjectConfig.MAXCALL;
                objFromDb.MAXCALLBACK = ProjectConfig.MAXCALLBACK;
                objFromDb.ENDOFPROJECT = ProjectConfig.ENDOFPROJECT;
                //objFromDb.DCRS = ProjectConfig.DCRS;
                objFromDb.PATHREPORT = ProjectConfig.PATHREPORT;
                objFromDb.MAXNOCONTACT = ProjectConfig.MAXNOCONTACT;
                objFromDb.PBXIP = ProjectConfig.PBXIP;
                objFromDb.SP_STATUS = ProjectConfig.SP_STATUS;


       

            }

        }


    }
}
