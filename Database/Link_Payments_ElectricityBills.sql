CREATE TABLE [dbo].[Link_Payments_ElectricityBills](
	[Id] [uniqueidentifier] NOT NULL,
	[PaymentId] [uniqueidentifier] NOT NULL,
	[ElectricityBillId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Link_Payments_ElectricityBills] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Link_Payments_ElectricityBills]  WITH CHECK ADD  CONSTRAINT [FK_Link_Payments_ElectricityBills_ElectricityBills] FOREIGN KEY([ElectricityBillId])
REFERENCES [dbo].[ElectricityBills] ([Id])
GO
ALTER TABLE [dbo].[Link_Payments_ElectricityBills] CHECK CONSTRAINT [FK_Link_Payments_ElectricityBills_ElectricityBills]
GO
ALTER TABLE [dbo].[Link_Payments_ElectricityBills]  WITH CHECK ADD  CONSTRAINT [FK_Link_Payments_ElectricityBills_Payments] FOREIGN KEY([PaymentId])
REFERENCES [dbo].[Payments] ([Id])
GO
ALTER TABLE [dbo].[Link_Payments_ElectricityBills] CHECK CONSTRAINT [FK_Link_Payments_ElectricityBills_Payments]
GO