-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Kaz
-- Create date: 04/26/2016
-- Description:	delete Post
-- =============================================
CREATE PROCEDURE DeletePost 
	-- Add the parameters for the stored procedure here
	@PostId int 

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM Post_Tag
	WHERE PostId = @PostId

	DELETE FROM Comment
	WHERE PostId = @PostId

	DELETE FROM PostImageUrls
	WHERE PostId = @PostId

	DELETE FROM Post
	WHERE PostId = @PostId
END
GO
