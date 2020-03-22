CREATE TABLE [dbo].[Link_Payments_MobileRechargeBills](
	[Id] [uniqueidentifier] NOT NULL,
	[PaymentId] [uniqueidentifier] NOT NULL,
	[MobileRechargeBillId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Link_Payments_MobileRechargeBills] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Link_Payments_MobileRechargeBills]  WITH CHECK ADD  CONSTRAINT [FK_Link_Payments_MobileRechargeBills_Payments] FOREIGN KEY([PaymentId])
REFERENCES [dbo].[Payments] ([Id])
GO
ALTER TABLE [dbo].[Link_Payments_MobileRechargeBills] CHECK CONSTRAINT [FK_Link_Payments_MobileRechargeBills_Payments]
GO
ALTER TABLE [dbo].[Link_Payments_MobileRechargeBills]  WITH CHECK ADD  CONSTRAINT [FK_LinkPaymentsMobileRechargeBills_MobileRechargeBills] FOREIGN KEY([MobileRechargeBillId])
REFERENCES [dbo].[MobileRechargeBills] ([Id])
GO
ALTER TABLE [dbo].[Link_Payments_MobileRechargeBills] CHECK CONSTRAINT [FK_LinkPaymentsMobileRechargeBills_MobileRechargeBills]
GO