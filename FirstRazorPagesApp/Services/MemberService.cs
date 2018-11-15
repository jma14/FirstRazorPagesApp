using FirstRazorPagesApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRazorPagesApp.Services
{
    public class MemberService : IMemberService
    {
        public List<Member> GetAll()
        {
            List<Member> members = new List<Member>();
            foreach (DataRow row in DataTier.GetDataTable("SELECT * FROM MemberDirectory_Members").Rows)
            {
                members.Add(new Member(
                    (int)row["MemberID"],
                    row["MemberFirstName"].ToString(),
                    row["MemberLastName"].ToString(),
                    row["MemberTitle"].ToString(),
                    row["MemberEmail"].ToString()
                    ));
            }
            return members;
        }

        public Member LoadByID(int ID)
        {
            DataTable dt = DataTier.GetDataTable("SELECT TOP 1 * FROM MemberDirectory_Members WHERE MemberID = {0}", ID);
            if(dt.Rows.Count > 0)
                return new Member((int)dt.Rows[0]["MemberID"],
                    dt.Rows[0]["MemberFirstName"].ToString(),
                    dt.Rows[0]["MemberLastName"].ToString(),
                    dt.Rows[0]["MemberTitle"].ToString(),
                    dt.Rows[0]["MemberEmail"].ToString()
                    );

            return new Member();
        }

        public void Save(Member member)
        {
            if(member.ID > 0)
                DataTier.ExecuteNonQuery("UPDATE MemberDirectory_Members SET MemberFirstName = {0}, MemberLastName = {1}, MemberTitle = {2}, MemberEmail = {3} WHERE MemberID = {4}", member.FirstName, member.LastName, member.Title, member.Email, member.ID);
            else
                DataTier.ExecuteNonQuery("INSERT INTO MemberDirectory_Members (MemberFirstName,MemberLastName,MemberTitle,MemberEmail) VALUES ({0},{1},{2},{3})", member.FirstName, member.LastName, member.Title, member.Email);
        }
    }
}
