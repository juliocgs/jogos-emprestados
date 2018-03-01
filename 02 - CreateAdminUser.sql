INSERT INTO [dbo].[app_user]
           ([id]
           ,[username]
           ,[password]
           ,[last_login]
           ,[registration_date])
     VALUES
           (NEWID()
           ,'admin'
           ,'7uIhkjrcpmxVcc1CsF5DsY/QSYmKorqjxrkJt4utXUlIEi/o' -- 123mudar
           ,null
           ,GETDATE())