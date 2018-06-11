SELECT
	ROW_NUMBER() AS [RowNum],
	[SalesOrderNumber],
	[OrderDate],
	[DueDate],
	[ShipDate],
	[Status],
	[PurchaseOrderNumber],
	[AccountNumber],
	[SubTotal] AS [SubtotalAmount],
	[TaxAmt] AS [TaxAmount],
	[Freight] AS [FreightAmount],
	[TotalDue] AS [TotalAmountDue],
	[SalesPersonLast] AS [SalesPersonLastName],
	[SalesPersonFirst] AS [SalesPersonFirstName]
FROM [aex].[SalesOrder]