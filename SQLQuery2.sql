 SELECT MembersTable.MembersID, CONCAT(MembersTable.MemberFName ,' ', MembersTable.MemberLName ,' ') AS Member , MembersTable.DOB, MembersTable.JoinDate, MembershipsTable.MembershipType, MembersTable.Phone, MembersTable.Timing, MembersTable.BloodType, MembersTable.Gender,
 CONCAT(TrainersTable.TrainerFName ,' ', TrainersTable.TrainerLName ,' ') AS Trainer 
 FROM MembersTable 
 JOIN MembershipsTable ON MembersTable.MembershipID = MembershipsTable.MembershipID
 JOIN TrainersTable ON MembersTable.TrainersID = TrainersTable.TrainersID 