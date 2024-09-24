USE [UserManagement]
GO

/****** Object:  StoredProcedure [dbo].[spspInsertUserRole]    Script Date: 22/09/2024 12:49:22 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spspInsertUserRole]
	@RoleName nvarchar(30),
	@RoleDescription nvarchar(255) = null
AS
Begin
	insert into UserRoles (RoleName, RoleDescription)
	values (@RoleName, @RoleDescription)
End
GO


