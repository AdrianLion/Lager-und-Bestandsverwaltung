﻿CREATE PROCEDURE [dbo].[spOrder_GetLast]
AS
BEGIN
	SELECT IDENT_CURRENT ('Order');
END