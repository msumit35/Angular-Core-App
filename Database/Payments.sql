CREATE TABLE [dbo].[Payments](
	[Id] [uniqueidentifier] NOT NULL,
	[PaymentModeId] [uniqueidentifier] NOT NULL,
	[PaymentStatusId] [uniqueidentifier] NOT NULL,
	[Amount] NUMERIC NOT NULL,
	[FailureDescription] [nvarchar](250) NULL,
	[CreatedOn] [datetimeoffset](7) NOT NULL
 CONSTRAINT [PK_Payments_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Payments]  WITH CHECK ADD  CONSTRAINT [FK_Payments_PaymentModes] FOREIGN KEY([PaymentModeId])
REFERENCES [dbo].[PaymentModes] ([Id])
GO
ALTER TABLE [dbo].[Payments] CHECK CONSTRAINT [FK_Payments_PaymentModes]
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD  CONSTRAINT [FK_Payments_PaymentStatuses] FOREIGN KEY([PaymentStatusId])
REFERENCES [dbo].[PaymentStatuses] ([Id])
GO
ALTER TABLE [dbo].[Payments] CHECK CONSTRAINT [FK_Payments_PaymentStatuses]
GO