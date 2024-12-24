CREATE TABLE [dbo].[bloodtable] (
    [blood_id] INT      IDENTITY (1, 1) NOT NULL,
    [type]     CHAR (3) NULL
);


CREATE TABLE [dbo].[expensestable] (
    [expense_id]  INT             IDENTITY (1, 1) NOT NULL,
    [description] NVARCHAR (50)   NULL,
    [date]        DATE            NULL,
    [cost]        DECIMAL (18, 2) NULL,
    [currency]    NVARCHAR (50)   NULL,
    [remarks]     NVARCHAR (50)   NULL
);


CREATE TABLE [dbo].[membershiptable] (
    [membership_id] INT             IDENTITY (1, 1) NOT NULL,
    [description]   VARCHAR (50)    NULL,
    [cost]          DECIMAL (18, 2) NULL,
    [currency]      VARCHAR (50)    NULL
);


CREATE TABLE [dbo].[memberstable] (
    [member_id]     INT           IDENTITY (1, 1) NOT NULL,
    [firstname]     VARCHAR (50)  NULL,
    [lastname]      VARCHAR (50)  NULL,
    [dob]           DATE          NULL,
    [joindate]      DATE          NULL,
    [phonenumber]   NVARCHAR (50) NOT NULL,
    [membership_id] INT           NULL,
    [blood_id]      INT           NULL,
    [isactive]      BIT           NULL
);

CREATE TABLE [dbo].[incomestable] (
    [income_id]   INT             IDENTITY (1, 1) NOT NULL,
    [member_id]   INT             NOT NULL,
    [description] NVARCHAR (50)   NULL,
    [date]        DATE            NULL,
    [cost]        DECIMAL (18, 2) NULL,
    [currency]    NVARCHAR (10)   NULL,
    [remarks]     NVARCHAR (50)   NULL
);


CREATE TABLE [dbo].[trainerstable] (
    [trainer_id]  INT           IDENTITY (1, 1) NOT NULL,
    [firstname]   VARCHAR (50)  NULL,
    [lastname]    VARCHAR (50)  NULL,
    [dob]         DATE          NULL,
    [experience]  INT           NULL,
    [phonenumber] NVARCHAR (50) NULL,
    [startdate]   DATE          NULL,
    [enddate]     DATE          NULL,
    [blood_id]    INT           NULL,
    [isactive]    BIT           NULL
);


CREATE TABLE [dbo].[userstable] (
    [id_user]  INT          IDENTITY (1, 1) NOT NULL,
    [username] VARCHAR (50) NULL,
    [password] VARCHAR (50) NULL,
    [isadmin]  BIT          NULL
);