USE [UserManagement]
GO

/****** Object:  StoredProcedure [dbo].[spListUserRoles]    Script Date: 24/09/2024 10:48:27 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[spListUserRoles]
AS
Begin
	SELECT * from UserRoles
End
GO


