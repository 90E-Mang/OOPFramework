using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex06_Try_Catch
{
    class DB_Try
    {
        /*
            string constr=@"server=it10-01\sqlexpress;databse=pubs;uid=sa;pwd=knit";
            SqlConnection conn = new SqlConnection(constr);
            string sql = "select * from titles";
            SqlCommand comm = new SqlCommand();
            comm.CommandText = sql;
            comm.Connection = conn;
            conn.Open();
            Console.WriteLine(conn.State);
            try
            {
                SqlDataReader dr = comm.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine("{0} - {1} - {2} - {3}", dr["title_id"], dr["title"], dr["type"], dr[16]);
                }
                dr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.Source);
            }
            finally                     // 예외바 발생하던 말던 강제적으로 수행되는 블럭 (DB)
            {
                conn.Close();       // 이 코드를 통해서 DB 연결을 해제함               
                Console.WriteLine(conn.State);    
            }
         */
    }
}
