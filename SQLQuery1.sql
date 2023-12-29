--Select BillID, MembersID, Date, Amount ,MemberFName , MemberLName from BillsTable As BillsTable
--	Inner Join MembersTable As MembersTable.MembersID = BillsTable.MembersID 
--		where MembersTable.MembersID = BillsTable.MembersID";

--SELECT
--	MembersTable.MembersID,MembersTable.MemberFName,MembersTable.MemberLName,BillsTable.BillId,BillsTable.Date,BillsTable.Amount FROM MembersTable JOIN BillsTable ON MembersTable.MembersID = BillsTable.MembersID;