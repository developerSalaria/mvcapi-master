using TPA.Common.Core.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace TPA.Data.DAL.Repositories
{
   public  class SampleDataRepository : BaseRepository
    {
        public List<SampleTest> GetSampleTestsByQuery()
        {
            return QueryExecutor.Query<SampleTest>(SQLs.GetSampleTest.ToString(), null, CommandType.Text).ToList();
        }

        public List<SampleTest> GetSampleTestsBySP()
        {
            return QueryExecutor.Query<SampleTest>(StoreProcedures.spGetSampleTestsSample.ToString(), null, CommandType.StoredProcedure).ToList();
        }

        public SampleTest GetSampleTestsSPById(int Id)
        {
            return QueryExecutor.Query<SampleTest>(StoreProcedures.spGetSampleTestById.ToString(), new { SampleTestId = Id }, CommandType.StoredProcedure).FirstOrDefault();
        }

        public int GetLastGeneratedId(int SampleTestId)
        {
            var Result = QueryExecutor.ExecuteScalar(StoreProcedures.spGetLastId.ToString(), new { SampleTestId = SampleTestId });
            if (Result != null)
                return Convert.ToInt32(Result);
            else
                return 0;
        }

        public List<SampleTest> Get()
        {
            return QueryExecutor.Query<SampleTest>(StoreProcedures.sp_GetSampleTestsName.ToString(), null, CommandType.StoredProcedure).ToList();
        }

        public SampleTest GetByIdWithQuery(int SampleTestId)
        {
            return QueryExecutor.Query<SampleTest>(StoreProcedures.sp_GetByIdSampleTestName.ToString(), new { SampleTestId }, CommandType.StoredProcedure).ToList().FirstOrDefault();
        }

        public List<SampleTest> GetByQuery(string name)
        {
            return QueryExecutor.Query<SampleTest>(SQLs.GetSampleTestWithParameter.ToString(),new { name }, CommandType.Text).ToList();
        }

        public DataTable GetDataTable()
        {
            return QueryExecutor.GetDataTable(SQLs.GetSampleTest.ToString(), null, CommandType.Text);
        }

        public List<SampleTest> GetReadDataTableToList()
        {
            var result = new List<SampleTest>();
            var dt = QueryExecutor.GetDataTable(SQLs.GetSampleTest.ToString(), null, CommandType.Text);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var be = new SampleTest();
                be.SampleTestId = Convert.ToInt32(dt.Rows[i]["SampleTestId"]);
                be.Name = Convert.ToString(dt.Rows[i]["Name"]);
                be.CreatedBy = Convert.ToString(dt.Rows[i]["CreatedBy"]);
                result.Add(be);
            }
            return result;
        }

        public SampleTest GetByIdExample(int SampleTest)
        {
            return QueryExecutor.Query<SampleTest>(StoreProcedures.sp_GetByIdSampleTestName.ToString(), new { SampleTestId = SampleTest }, CommandType.StoredProcedure).FirstOrDefault();
        }

        public int DeleteSampleTestById(int Id)
        {
            return QueryExecutor.Execute(StoreProcedures.spDeleteSampleTest.ToString(), new { SampleTestId = Id }, CommandType.StoredProcedure);
        }

        public int DeleteById(int SampleTestId)
        {
            return QueryExecutor.Execute(StoreProcedures.sp_DeleteSampleTestName.ToString(), new { SampleTestId }, CommandType.StoredProcedure);
        }

        public int UpdateWithDynamicParameters(SampleTest obj)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@SampleTestId", obj.SampleTestId);
            param.Add("@Name", obj.Name);
            param.Add("@CreatedBy", obj.CreatedBy);
            return QueryExecutor.ExecuteWithParameter(StoreProcedures.spUpdateSampleTest.ToString(),param);
        }

        public int UpdateWithParameters(SampleTest obj)
        {
            return QueryExecutor.Execute(StoreProcedures.spUpdateSampleTest.ToString(),new { SampleTestId = obj.SampleTestId, Name = obj.Name, Address = obj.CreatedBy });
        }

        public int Update(SampleTest obj)
        {
            return QueryExecutor.Execute(StoreProcedures.sp_UpdateSampleTestName.ToString(), new { obj.SampleTestId, obj.Name, obj.CreatedBy });
        }
        
        public int Insert(SampleTest obj)
        {
            return QueryExecutor.Execute(StoreProcedures.sp_InsertSampleTestName.ToString(), new { obj.Name, obj.CreatedBy });
        }

        public int InsertWithDynamicParametersAndReturnValueOutPutParameter(SampleTest obj)
        {
            string ReturnValue = "ReturnValue";

            DynamicParameters param = new DynamicParameters();
            param.Add("@Name", obj.Name);
            param.Add("@CreatedBy", obj.CreatedBy);
            param.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.Output);
            return QueryExecutor.ExecuteWithReturnValue<int>(StoreProcedures.spInsertSampleTest.ToString(), ReturnValue, param);
        }

        public bool IsSampleTestExist(string value, int SampleTestId)
        {
            var ReturnValue = QueryExecutor.Query<bool>(StoreProcedures.sp_IsSampleTestExist.ToString(), new { value, SampleTestId }, CommandType.StoredProcedure).FirstOrDefault();
            return ReturnValue;
        }
    }
}
