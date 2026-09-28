using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem
{
    internal class Member
    {
        public Member(string memeberId, string memberName, long mobileNumber)
        {
            this.MemberId = memeberId;
            this.MemberName = memberName;
            this.MobileNumber = mobileNumber;
        }
        public string MemberId {  get; set; }
        public string MemberName {  get; set; }
        public long MobileNumber {  get; set; }
        public void DisplayMemberDetails()
        {
            Console.WriteLine("Member Id: " + MemberId);
            Console.WriteLine("Member Name: " + MemberName);
            Console.WriteLine("Mobile Number: " + MobileNumber);
        }
    }
}
